using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using VYSA.WebApi.Filters;

namespace VYSA.WebApi.Controllers
{
    [CustomExceptionFilter, ModelValidator]
    public class BaseController : ApiController
    {
        public IEnumerable<Claim> Claims
        {
            get
            {
                return Request.GetOwinContext().Authentication.User.Claims.ToList();
            }
        }
    }
}