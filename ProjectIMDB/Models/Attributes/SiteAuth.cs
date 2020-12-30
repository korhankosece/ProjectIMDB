using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.Attributes
{
    public class SiteAuth : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string siterole = context.HttpContext.User.Claims.ToArray()[1].Value;

                if (siterole == "User")
                {
                    //context.HttpContext.Response.Redirect("/SiteHome/Books");

                }
                else
                {
                    context.HttpContext.Response.Redirect("/Site/Home");
                }
            }
            else
            {
                context.HttpContext.Response.Redirect("/Site/Home");

            }
        }
    }
}
