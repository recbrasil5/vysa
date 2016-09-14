using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VYSA.Domain.Abstract;
using VYSA.Domain.Concrete;
using VYSA.Domain.Entities;
using VYSA.Domain.Enums;
using VYSA.WebApi.Models.Binding;
using VYSA.WebApi.Models.Resource;
using VYSA.WebApi.Properties;
using VYSA.WebApi.Providers;
using VYSA.WebApi.Util;

namespace VYSA.WebApi.Services
{
    public class ContactUsService : BaseService
    {
        private readonly UnitOfWork _unitOfWork;

        public ContactUsService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }

        public ContactUsMessageResourceModel SendAndSaveContactUsMessage(ContactUsMessageResourceModel newContactUsMessageDto)
        {
            var contactUsMessage = new ContactUsMessage().PopulateEntityWithResourceModel(newContactUsMessageDto);
            _unitOfWork.ContactUsRepository.Insert(contactUsMessage);
            _unitOfWork.Save();

            if (Settings.Default.EmailContactUs)
            {
                var subject = string.Format("{0} [{1}]", newContactUsMessageDto.Subject, newContactUsMessageDto.Name);
                EmailProvider.SendEmail(Settings.Default.EmailTo,
                    newContactUsMessageDto.EmailAddr,
                    subject,
                    newContactUsMessageDto.Message);
            }

            return contactUsMessage.ConvertToContactUsMessageResourceModel();
        }

        public ICollection<ContactUsInboxResourceModel> GetInboxFilter(FilterBindingModel bm)
        {
            QueryObject queryObject = BuildFilterQuery(bm, false);
            return
                _unitOfWork.Context.Database.SqlQuery<ContactUsInboxResourceModel>(queryObject.Query,
                    queryObject.FilterParameters.ToArray()).ToList();
        }

        public int GetInboxFilterCount(FilterBindingModel bm)
        {
            QueryObject queryObject = BuildFilterQuery(bm, true);
            return
                _unitOfWork.Context.Database.SqlQuery<int>(queryObject.Query, queryObject.FilterParameters.ToArray())
                    .ToList()
                    .First();
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
                    case "name":
                        orderBy += "[Name]";
                        break;
                    case "email":
                        orderBy += "[EmailAddr]";
                        break;
                    case "subject":
                        orderBy = "[Subject]";
                        break;
                    case "message":
                        orderBy = "[message]";
                        break;
                    case "createddate":
                    case "timestamp":
                        orderBy = "[CreatedDateUtc]";
                        break;
                    default:
                        orderBy = "[Id]";
                        break;
                }

                orderBy += (bm.Ascending == null || bm.Ascending) ? " ASC" : " DESC";

                #endregion
            }

            #region Select

            // Select Clause
            var sql = count
                ? string.Format(@"SELECT COUNT([Id])
                                FROM [dbo].[ContactUsMessages]
                                WHERE {0}", string.Join(" AND ", filterConditionList))
                : string.Format(@"SELECT * 
                                FROM (
	                                SELECT ROW_NUMBER() OVER (ORDER BY {1}) AS RowNum, *
	                                FROM (
		                                SELECT ROW_NUMBER() OVER (PARTITION BY [Id] ORDER BY {1}) AS PartNum, *
		                                FROM (
			                                SELECT [Id]
                                                  ,[Name]
                                                  ,[EmailAddr]
                                                  ,[Subject]
                                                  ,[Message]
                                                  ,[CreatedDateUtc]
                                            FROM [dbo].[ContactUsMessages]
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

        private void BuildFilterWhereClause(FilterBindingModel bm, out List<string> filterConditionList,
            out List<object> filterParameters)
        {
            filterParameters = new List<object>();
            filterConditionList = new List<string> { "[IsActive] = 1" };
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

    }
}