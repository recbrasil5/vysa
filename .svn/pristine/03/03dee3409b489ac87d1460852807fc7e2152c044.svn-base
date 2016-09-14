using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using VYSA.WebApi.Controllers;
using VYSA.WebApi.Models.Resource;

namespace VYSA.WebApi.Extensions
{
    public static class BaseControllerExtensions
    {
        public static string GetEmail(this BaseController controller)
        {
            var claim = controller.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name);
            return claim != null && !String.IsNullOrEmpty(claim.Value) ? claim.Value : "";
        }

        public static IEnumerable<string> GetRoles(this BaseController controller)
        {
            var claim = controller.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Role);
            if (claim == null || string.IsNullOrEmpty(claim.Value)) 
                return new List<string>();

            return claim.Value.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static TokenResourceModel GetTokenResourceModel(this BaseController controller)
        {
            var token = new TokenResourceModel
            {
                Email = GetEmail(controller),
                Roles = GetRoles(controller)
            };

            return token;
        }

    }
}