﻿using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using VYSA.Domain.Concrete;
using VYSA.Domain.Entities;
using VYSA.WebApi.Models.Binding;
using VYSA.WebApi.Models.Resource;
using VYSA.WebApi.Services;

namespace VYSA.WebApi.Controllers
{
    [RoutePrefix("Admin/Board")]
    public class AdminBoardController : BaseAdminController
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly BoardService boardService;
        public AdminBoardController()
        {
            boardService = new BoardService(_unitOfWork);
        }

        [HttpGet] //Admin/api/Board
        [Route("")]
        [ResponseType(typeof(BoardMemberResourceModel))]
        public IHttpActionResult GetBoardMembers() //webApi hybrid call
        {
            return Ok(boardService.GetBoardMemberResourceModels());
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetBoardById")]
        [ResponseType(typeof(BoardMemberResourceModel))]
        public IHttpActionResult GetBoardMember(int id)
        {
            BoardMemberResourceModel boardMember = boardService.GetBoardMember(id);

            // return it if you got it
            if (boardMember == null)
            {
                return NotFound();
            }

            return Ok(boardMember);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(BoardMemberResourceModel))]
        public IHttpActionResult UpdateBoardMember(int id, BoardMemberBindingModel bindingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bindingModel.Id)
            {
                return BadRequest();
            }

            var updatedBoardMemberDTO = boardService.UpdateBoardMember(bindingModel, User.Identity.Name);

            if (updatedBoardMemberDTO == null)
            {
                //can't find the record to update
                return NotFound();
            }

            return Ok(updatedBoardMemberDTO);
        }


        [HttpPost]
        [Route("")]
        [ResponseType(typeof(BoardMemberResourceModel))]
        public IHttpActionResult CreateBoardMember(BoardMemberBindingModel bindingModel)
        {
            var newBoardMemberDTO = boardService.AddBoardMember(bindingModel, User.Identity.Name);

            //for some reason this CreatedAtRoute doesn't work like it should for me - can't find GetBoardById
            //return CreatedAtRoute("GetBoardById", new { id = newBoardMemberDTO.Id }, newBoardMemberDTO);
            return Ok(newBoardMemberDTO);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(BoardMemberResourceModel))]
        public IHttpActionResult DeleteBoardMember(int id)
        {
            var boardMember = boardService.SoftDeleteBoardMember(id, User.Identity.Name);
            if (boardMember == null)
            {
                return NotFound();
            }

            return Ok(boardMember);
        }
       
        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}