﻿using System.Web.Http;
using System.Web.Http.Description;
using VYSA.Domain.Concrete;
using VYSA.WebApi.Filters;
using VYSA.WebApi.Models.Binding;
using VYSA.WebApi.Models.ViewModel;
using VYSA.WebApi.Services;

namespace VYSA.WebApi.Controllers
{
    [RoutePrefix("Admin/ContactUs")]
    public class AdminContactUsController : BaseAdminController
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly ContactUsService cuService;

        public AdminContactUsController()
        {
            cuService = new ContactUsService(_unitOfWork);
        }

        [HttpPost]
        [Route("filter")]
        [ResponseType(typeof(ContactUsInboxViewModel))]
        public IHttpActionResult GetContactUsInboxViewModelFilter(FilterBindingModel bindingModel)
        {
            var vm = new ContactUsInboxViewModel
            {
                Inbox = cuService.GetInboxFilter(bindingModel)
            };

            if (bindingModel.GetCount)
            {
                vm.Count = cuService.GetInboxFilterCount(bindingModel);
            }

            return Ok(vm);
        }
    }
}