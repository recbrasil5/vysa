using System.Collections.Generic;
using System.Web.Http;
using VYSA.Domain.Concrete;
using VYSA.WebApi.Filters;
using VYSA.WebApi.Models.ViewModel;
using VYSA.WebApi.Services;

namespace VYSA.WebApi.Controllers
{
    [AdminAuthorizationFilter, RoutePrefix("Admin/Divisions")]
    public class AdminDivisionsController : BaseAdminController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private DivisionService divisionService;
        public AdminDivisionsController()
        {
            divisionService = new DivisionService(unitOfWork);
        }

        [HttpGet] 
        [Route("")]
        public IEnumerable<DropdownItemViewModel> GetDivisions()
        {
            return divisionService.GetDivisionDropdownVms();
        }
    }
}
