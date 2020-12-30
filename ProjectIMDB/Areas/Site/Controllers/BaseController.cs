using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectIMDB.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Areas.Site.Controllers
{
    public class BaseController : Controller
    {
        private readonly IMDBContext _context;

        public BaseController(IMDBContext context)
        {
            _context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.User.Identity.Name != null)
            {
                if (HttpContext.User.Claims.ToArray()[1].Value == "User")
                {
                    ViewBag.username = "Welcome! " + HttpContext.User.Claims.ToArray()[0].Value;

                }
            }

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
