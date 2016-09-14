using System;
using System.ComponentModel.DataAnnotations;
using VYSA.Domain.Entities;
using VYSA.WebApi.Models.Binding;

namespace VYSA.WebApi.Models.Resource
{
    public class BoardMemberResourceModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

    }

    public static class BoardMemberExtensions
    {
        public static BoardMember PopulateEntityWithResourceModel(this BoardMember boardMember, BoardMemberBindingModel bindingModel, string lastUpdateBy, bool onCreate)
        {
            boardMember.Id = bindingModel.Id;
            boardMember.IsActive = true;
            boardMember.LastUpdateBy = lastUpdateBy;
            boardMember.LastUpdateUtc = DateTime.UtcNow;

            if (onCreate)
            {
                boardMember.CreatedBy = lastUpdateBy;
                boardMember.CreatedDateUtc = DateTime.UtcNow;
            }

            return boardMember;
        }

        public static BoardMemberResourceModel ConvertToResourceModel(this BoardMember member)
        {
            return new BoardMemberResourceModel
            {
                Id = member.Id,
                Title = member.KeyValue.Value,
                Name = member.User.FirstName + " " + member.User.LastName,
                Email = member.User.Email
            };
        }
    }
}