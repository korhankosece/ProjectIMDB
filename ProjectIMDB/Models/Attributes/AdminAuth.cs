using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.Attributes
{
    public class AdminAuth : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string siterole = context.HttpContext.User.Claims.ToArray()[2].Value;

                if (siterole == "Admin")
                {
                    //context.HttpContext.Response.Redirect("/SiteHome/Books");

                }
                else
                {
                    context.HttpContext.Response.Redirect("/Admin/Admin");
                }
            }
            else
            {
                context.HttpContext.Response.Redirect("/Admin/Admin");

            }
        }
    }
}
