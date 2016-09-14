using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using VYSA.Domain.Concrete;
using VYSA.Domain.Enums;
using VYSA.WebApi.Filters;
using VYSA.WebApi.Models.Binding;
using VYSA.WebApi.Models.Resource;
using VYSA.WebApi.Models.ViewModel;
using VYSA.WebApi.Services;

namespace VYSA.WebApi.Controllers
{
    [RoutePrefix("Admin/MailingListMember")]
    public class AdminMailingListMemberController : BaseAdminController
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly MailingListMemberService mlmService;

        public AdminMailingListMemberController()
        {
            mlmService = new MailingListMemberService(_unitOfWork);
        }

        [HttpPost]
        [Route("filter")]
        [ResponseType(typeof(MailingListMemberViewModel))]
        public IHttpActionResult GetMailingListViewModelFilter(MailingListMemberFilterBindingModel mlmFilterBindingModel)
        {
            var vm = !mlmFilterBindingModel.IsConfigDefined ?
            new MailingListMemberViewModel { MailingList = new List<MailingListMemberResourceModel>(), EmailList = "", Count = 0 }
            : new MailingListMemberViewModel
            {
                MailingList = mlmService.GetMailingListFilter(mlmFilterBindingModel, Enums.FilterReturnType.Filter),
                EmailList = mlmService.GetMailingListFilterEmailList(mlmFilterBindingModel, Enums.FilterReturnType.DelimittedString)
            };

            if (mlmFilterBindingModel.IsConfigDefined)
            {
                vm.Count = mlmService.GetMailingListFilterCount(mlmFilterBindingModel, Enums.FilterReturnType.Count);
            }

            return Ok(vm);
        }

        //[HttpPost]
        //[Route("filter/emailList")]
        //[ResponseType(typeof(string))]
        //public IHttpActionResult GetEmailListFilter(MailingListMemberFilterBindingModel mlmFilterBindingModel)
        //{
        //    var emailList = mlmService
        //        .GetMailingListFilterEmailList(mlmFilterBindingModel, Enums.FilterReturnType.DelimittedString);

        //    return Ok(emailList);
        //}
    }
}
