﻿using System;
using System.Web.Http;
using System.Web.Http.Description;
using VYSA.Domain.Concrete;
using VYSA.WebApi.Filters;
using VYSA.WebApi.Models.Resource;
using VYSA.WebApi.Services;

namespace VYSA.WebApi.Controllers
{
    [ModelValidator, RoutePrefix("ContactUs")]
    public class ContactUsController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private ContactUsService contactUsService;
        public ContactUsController()
        {
            contactUsService = new ContactUsService(unitOfWork);
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(ContactUsMessageResourceModel))]
        public IHttpActionResult SendMessage(ContactUsMessageResourceModel resourceModel)
        {
            if (!resourceModel.EmailAddrIsValid)
            {
                /*even though client-side does validation, it doesn't always work the same way as the constructor for MailAddress(emailAddress)*/
                return BadRequest(string.Format("{0} is not a valid email address", resourceModel.EmailAddr));
            }

            var newContactUsMessageDto = contactUsService.SendAndSaveContactUsMessage(resourceModel);
            return Ok(newContactUsMessageDto);

        }
    }
}