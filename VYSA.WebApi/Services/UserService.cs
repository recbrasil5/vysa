﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using VYSA.Domain.Abstract;
using VYSA.Domain.Concrete;
using VYSA.Domain.Entities;
using VYSA.WebApi.Models.Binding;
using VYSA.WebApi.Models.Resource;
using VYSA.WebApi.Properties;
using VYSA.WebApi.Providers;

namespace VYSA.WebApi.Services
{
    public class UserService : BaseService
    {
        private readonly UnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public User GetUser(int id)
        {
            return _unitOfWork.UserRepository.GetUser(id);
        }

        public User GetUser(string email)
        {
            return _unitOfWork.UserRepository.GetUser(email);
        }

        public bool EmailExists(string email)
        {
            return _unitOfWork.UserRepository.EmailExists(email);
        }

        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.UserRepository.ActiveUsers.AsEnumerable();
        }

        public ICollection<UserResourceModel> GetUsersFilter(FilterBindingModel bm)
        {
            QueryObject queryObject = BuildFilterQuery(bm, false);
            return _unitOfWork.Context.Database.SqlQuery<UserResourceModel>(queryObject.Query, queryObject.FilterParameters.ToArray()).ToList();
        }

        public int GetUsersFilterCount(FilterBindingModel bm)
        {
            QueryObject queryObject = BuildFilterQuery(bm, true);
            return _unitOfWork.Context.Database.SqlQuery<int>(queryObject.Query, queryObject.FilterParameters.ToArray()).ToList().First();
        }

        private QueryObject BuildFilterQuery(FilterBindingModel bm, bool count)
        {
            var filterConditionList = new List<string>();
            var filterParameters = new List<object>();
            var orderBy = string.Empty;

            // Where Clause
            BuildFilterWhereClause(bm, out filterConditionList, out filterParameters);

            if (!count)
            {
                // Paging Params
                AddPagingParameters(bm, ref filterParameters);

                if (string.IsNullOrEmpty(bm.OrderByFieldName)) bm.OrderByFieldName = string.Empty;

                #region Ordering
                switch (bm.OrderByFieldName.ToLower())
                {
                    case "username":
                        orderBy += "[Username]";
                        break;
                    case "email":
                        orderBy += "[Email]";
                        break;
                    case "role":
                        orderBy = "[Role]";
                        break;
                    default:
                        orderBy = "[Username]";
                        break;
                }

                orderBy += (bm.Ascending == null || bm.Ascending) ? " ASC" : " DESC";

                #endregion
            }

            #region Select
            // Select Clause
            var sql = count ?
                string.Format(@"SELECT COUNT(u.[Id])
                                FROM [dbo].[Users] u
                                WHERE {0}", string.Join(" AND ", filterConditionList))
                :
                string.Format(@"DECLARE @now AS DATETIME = GETDATE()
                                SELECT * 
                                FROM (
	                                SELECT ROW_NUMBER() OVER (ORDER BY {1}) AS RowNum, *
	                                FROM (
		                                SELECT ROW_NUMBER() OVER (PARTITION BY [Id] ORDER BY {1}) AS PartNum, *
		                                FROM (
			                               SELECT distinct u.[Id]
                                                          ,[UserName]
                                                          ,[Email]
                                                          ,[LastLoginDateTimeUtc]
                                                          ,u.[IsActive]
                                                          ,(select stuff((
		                                                    SELECT ',' + Name 
		                                                    FROM [dbo].[Roles] as r2
		                                                    where r2.Id in (select RoleId 
		                                                    from [dbo].[UserRoles]  
		                                                    where UserId = u.Id)
		                                                    for xml path('')
		                                                    ),1,1,'')) as Roles
                                                      FROM [dbo].[Users] u inner join [dbo].[UserRoles] ur on u.Id = ur.UserId
                                                      inner join [dbo].[Roles] r on r.Id = ur.RoleId
			                                WHERE {0}
			                                ) AS DataTbl
		                                ) AS PartNumTbl
		                                WHERE PartNum = 1
                                 ) AS OrderByTbl
                                WHERE [RowNum] >= @rowStart AND [RowNum] < @rowEnd",
            string.Join(" AND ", filterConditionList), orderBy);
            #endregion

            var queryObject = new QueryObject { Query = sql, FilterParameters = filterParameters };
            return queryObject;
        }

        private void BuildFilterWhereClause(FilterBindingModel bm, out List<string> filterConditionList, out List<object> filterParameters)
        {
            filterParameters = new List<object>();
            filterConditionList = new List<string> { "u.[IsActive] = 1" };

            #region example code
            //if (dto.CategoryId.HasValue)
            //{
            //    filterConditionList.Add("ls.[LeadSourceCategoryId] = " + dto.CategoryId);
            //}
            //else if (dto.LeadSourceId.HasValue)
            //{
            //    filterConditionList.Add("adv.[LeadSourceId] = " + dto.LeadSourceId);
            //}
            //else if (dto.AdvertisementId.HasValue)
            //{
            //    filterConditionList.Add("cost.[AdvertisementId] = " + dto.AdvertisementId);
            //}

            //FromExpenseUtcDate
            //if (dto.FromDateTime != DateTime.MinValue)
            //{
            //    filterConditionList.Add("cost.[ExpenseUtcDate] >= @fromExpenseUtcDate");

            //    filterParameters.Add(new SqlParameter
            //    {
            //        ParameterName = "fromExpenseUtcDate",
            //        SqlDbType = SqlDbType.DateTime,
            //        Value = dto.FromDateTime
            //    });
            //}

            ////ToExpenseUtcDate
            //if (dto.ToDateTime != DateTime.MinValue)
            //{
            //    filterConditionList.Add("cost.[ExpenseUtcDate] <= @toExpenseUtcDate");

            //    filterParameters.Add(new SqlParameter
            //    {
            //        ParameterName = "toExpenseUtcDate",
            //        SqlDbType = SqlDbType.DateTime,
            //        Value = dto.ToDateTime
            //    });
            //}
            #endregion
        }

        private void AddPagingParameters(FilterBindingModel bm, ref List<object> filterParameters)
        {
            int numofRecords = (bm.NumofRecords > 1000) ? 1000 : bm.NumofRecords;
            int offset = (bm.PageNum - 1) * numofRecords;
            int rowEnd = offset + numofRecords;

            filterParameters.Add(new SqlParameter
            {
                ParameterName = "rowStart",
                SqlDbType = SqlDbType.Int,
                Value = offset
            });

            filterParameters.Add(new SqlParameter
            {
                ParameterName = "rowEnd",
                SqlDbType = SqlDbType.Int,
                Value = rowEnd
            });
        }

        public IEnumerable<UserResourceModel> GetUserResourceModels()
        {
            var list = new List<UserResourceModel>();
            var users = GetUsers().ToList();
            users.ForEach(x => list.Add(x.ConvertToResourceModel()));
            return list;
        }

        public UserResourceModel GetUserResourceModel(int id)
        {
            var user = GetUser(id);
            return user == null ? null : user.ConvertToResourceModel();
        }

        public UserResourceModel GetUserResourceModel(string username)
        {
            var user = GetUser(username);
            return user == null ? null : user.ConvertToResourceModel();
        }

        public int GetUserIdFromUserName(string username)
        {
            var user = GetUser(username);
            return user != null ? user.Id : -1;
        }

        //public UserResourceModel UpdateUser(UserResourceModel updatedUserDto, string lastUpdateBy)
        //{
        //    var user = _unitOfWork.UserRepository.GetUser(updatedUserDto.Id);
        //    if (user == null) return null;

        //    //do update
        //    user.PopulateEntityWithResourceModel(updatedUserDto, lastUpdateBy, false);

        //    //todo: how to do an update, what changed? perhaps i need specific calls instead.
        //    //_unitOfWork.UserRepository.(User);
        //    _unitOfWork.Save();

        //    return updatedUserDto;
        //}

        public UserResourceModel AddUser(UserResourceModel newUserDto, string lastUpdateBy)
        {
            //think about which role a user is...

            var user = new User().PopulateEntityWithResourceModel(newUserDto, lastUpdateBy, true);

            //todo: adduser
            //var membershipProvider = new EFMembershipProvider(_unitOfWork, lastUpdateBy);
            //MembershipCreateStatus status =
            //    new AccountMembershipService(membershipProvider, lastUpdateBy)
            //    .CreateUser(newUserDto.UserName, "password", newUserDto.Email);

            #region todo
            //todo: handle staus on failure
            //switch (status)
            //{
            //    case MembershipCreateStatus.DuplicateEmail:
            //        break;
            //    case MembershipCreateStatus.DuplicateUserName:
            //        break;
            //    case MembershipCreateStatus.InvalidPassword:
            //        break;
            //}
            #endregion

            return user.ConvertToResourceModel();
        }

        public UserResourceModel SoftDeleteUser(int id, string lastUpdateBy)
        {
            var user = GetUser(id);

            if (user == null)
                return null;

            user.IsActive = false;
            user.LastUpdateBy = lastUpdateBy;
            user.LastUpdateUtc = DateTime.UtcNow;

            _unitOfWork.UserRepository.Save(user);
            return user.ConvertToResourceModel();
        }

        public bool ResetPassword(string email)
        {
            var user = _unitOfWork.UserRepository.GetUserByEmail(email);

            if(user == null) return false;

            var newPassword = _unitOfWork.UserRepository.ResetPassword(email);

            var subject = "www.holmenvysa.com password reset!";
            var msg = string.Format("Your new password is {0}", newPassword);
            EmailProvider.SendEmail(email,
                                    Settings.Default.ErrorMsgFrom,
                                    subject,
                                    msg);

            return true;
        }

        //public IEnumerable<MailingListDto> GetMailingList()
        //{
        //    return _unitOfWork.UserRepository.ActiveUsers.ToList()
        //        .Select(x => new MailingListDto
        //        {
        //            Name = string.Format("{0} {1}", x.FirstName, x.LastName),
        //            Email = x.Email
        //        });
        //}
    }
}