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
            string roles = context.HttpContext.User.Claims.ToArray()[1].Value;



            if (roles != null)
            {
                string[] rolenames = roles.Split(';');

                bool yetkiVarmi = false;

                foreach (var item in rolenames)
                {
                    if (item == pagerol)
                    {
                        yetkiVarmi = true;
                    }
                }

                if (yetkiVarmi)
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
    }
}
