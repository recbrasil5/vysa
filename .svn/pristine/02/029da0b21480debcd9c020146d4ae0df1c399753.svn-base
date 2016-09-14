using System;
using System.Collections.Generic;
using System.Linq;
using VYSA.Domain.Abstract;
using VYSA.Domain.Concrete;
using VYSA.Domain.Entities;
using VYSA.WebApi.Models.Binding;
using VYSA.WebApi.Models.Resource;

namespace VYSA.WebApi.Services
{
    public class BoardService
    {
        private readonly UnitOfWork _unitOfWork;

        public BoardService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }

        public IEnumerable<BoardMember> GetBoardMembers()
        {
            return _unitOfWork.BoardMemberRepository.Get(b => b.IsActive, null, "User, KeyValue");     
        }

        public IEnumerable<BoardMemberResourceModel> GetBoardMemberResourceModels()
        {
            var list = new List<BoardMemberResourceModel>();
            var board = GetBoardMembers().ToList();
            board.ForEach(x => list.Add(x.ConvertToResourceModel()));
            return list;
        }

        //public IEnumerable<MailingListResourceModel> GetMailingList()
        //{
        //    return _unitOfWork.BoardMemberRepository.Get(b => b.IsActive)
        //        .Select(x => new MailingListResourceModel
        //        {
        //            Name = x.Name,
        //            Email = x.Email
        //        });
        //}

        public BoardMemberResourceModel GetBoardMember(int id)
        {
            var boardMember = _unitOfWork.BoardMemberRepository.GetByID(id);
            return boardMember == null ? null : boardMember.ConvertToResourceModel();
        }

        public BoardMemberResourceModel UpdateBoardMember(BoardMemberBindingModel bindingModel, string lastUpdateBy)
        {
            var boardMember = _unitOfWork.BoardMemberRepository.GetByID(bindingModel.Id);
            if (boardMember == null) return null;

            //do update
            boardMember.PopulateEntityWithResourceModel(bindingModel, lastUpdateBy, false);

            _unitOfWork.BoardMemberRepository.Update(boardMember);
            _unitOfWork.Save();

            return boardMember.ConvertToResourceModel();
        }

        public BoardMemberResourceModel AddBoardMember(BoardMemberBindingModel bindingModel, string lastUpdateBy)
        {
            BoardMember boardMember = new BoardMember().PopulateEntityWithResourceModel(bindingModel, lastUpdateBy, true);
            _unitOfWork.BoardMemberRepository.Insert(boardMember);
            _unitOfWork.Save();

            return boardMember.ConvertToResourceModel();
        }

        public BoardMemberResourceModel SoftDeleteBoardMember(int id, string lastUpdateBy)
        {
            var boardMember = _unitOfWork.BoardMemberRepository.GetByID(id);
            if (boardMember == null) return null;

            boardMember.IsActive = false;
            boardMember.LastUpdateUtc = DateTime.UtcNow;
            boardMember.LastUpdateBy = lastUpdateBy;
            _unitOfWork.BoardMemberRepository.Update(boardMember);
            _unitOfWork.Save();

            return boardMember.ConvertToResourceModel();
        }
    }

}