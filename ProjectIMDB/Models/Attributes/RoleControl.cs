using Microsoft.AspNetCore.Mvc.Filters;
using ProjectIMDB.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.Attributes
{
    public class RoleControl : ActionFilterAttribute
    {
        string pagerol = "0";
        public RoleControl(EnumRole rolenumber)
        {
            pagerol = Convert.ToInt32(rolenumber).ToString();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string adminrole = context.HttpContext.User.Claims.ToArray()[2].Value;

                if (adminrole == "Admin")
                {
                    string roles = context.HttpContext.User.Claims.ToArray()[1].Value;

                    if (roles != null)
                    {
                        string[] rolenames = roles.Split(';');

                        bool authority = false;

                        foreach (var item in rolenames)
                        {
                            if (item.Trim() == pagerol)
                            {
                                authority = true;
                            }
                        }

                        if (authority)
                        {
                            base.OnActionExecuting(context);
                        }

                        else
                        {
                            context.HttpContext.Response.Redirect("/Admin/Error/UnauthorizedAccess");
                        }

                    }
                    else
                    {
                        context.HttpContext.Response.Redirect("/Admin/Error/UnauthorizedAccess");
                    }
                }

                else
                {
                    context.HttpContext.Response.Redirect("/Admin/AdminLogin/");
                }

            }
            else
            {
                context.HttpContext.Response.Redirect("/Admin/AdminLogin/");

            }


        }
      
        
    }
}
