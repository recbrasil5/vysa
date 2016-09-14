using System;
using VYSA.WebApi.Filters;

namespace VYSA.WebApi.Controllers
{
    [AdminAuthorizationFilter]
    public class BaseAdminController : BaseController
    {
    }
}
