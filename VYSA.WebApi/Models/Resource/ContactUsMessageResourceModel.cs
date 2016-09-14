﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using VYSA.Domain.Entities;
using VYSA.Domain.Extensions;

namespace VYSA.WebApi.Models.Resource
{
    public class ContactUsMessageResourceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddr { get; set; }

        public string Subject { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [DataType(DataType.MultilineText)]
        [MaxLength(256)]
        public string Message { get; set; }

        public Boolean EmailAddrIsValid
        {
            get
            {
                try
                {
                    if (!String.IsNullOrWhiteSpace(EmailAddr))
                    {
                        var mailAddr = new MailAddress(EmailAddr);
                        return true;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }

    public class ContactUsInboxResourceModel : ContactUsMessageResourceModel
    {
        public DateTime CreatedDateUtc { get; set; }
    }

    public static class ContactUsMessageExtensions
    {
        public static ContactUsMessage PopulateEntityWithResourceModel(this ContactUsMessage contactUsMessage, ContactUsMessageResourceModel resourceModel)
        {
            contactUsMessage.Id = resourceModel.Id;
            contactUsMessage.Name = resourceModel.Name;
            contactUsMessage.EmailAddr = resourceModel.EmailAddr;
            contactUsMessage.Subject = resourceModel.Subject;
            contactUsMessage.Message = resourceModel.Message;
            contactUsMessage.IsActive = true;
            contactUsMessage.LastUpdateUtc = DateTime.UtcNow;
            contactUsMessage.CreatedDateUtc = DateTime.UtcNow;

            return contactUsMessage;
        }

        public static ContactUsMessageResourceModel ConvertToContactUsMessageResourceModel(this ContactUsMessage contactUsMessage)
        {
            return new ContactUsMessageResourceModel
            {
                Id = contactUsMessage.Id,
                Name = contactUsMessage.Name,
                EmailAddr = contactUsMessage.EmailAddr,
                Subject = contactUsMessage.Subject,
                Message = contactUsMessage.Message
            };
        }
    }

    public static class ContactUsInboxExtensions
    {
        public static ContactUsInboxResourceModel ConvertToContactUsInboxResourceModel(this ContactUsMessage contactUsMessage)
        {
            return new ContactUsInboxResourceModel
            {
                Id = contactUsMessage.Id,
                Name = contactUsMessage.Name,
                EmailAddr = contactUsMessage.EmailAddr,
                Subject = contactUsMessage.Subject,
                Message = contactUsMessage.Message,
                CreatedDateUtc = contactUsMessage.CreatedDateUtc,
            };
        }
    }
}