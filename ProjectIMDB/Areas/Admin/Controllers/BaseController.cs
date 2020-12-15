using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        private readonly IMDBContext _context;
        private readonly IMemoryCache _memoryCache;

        public BaseController(IMDBContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            List<AdminMenu> adminMenus = new List<AdminMenu>();
            bool isExist = _memoryCache.TryGetValue("menus", out adminMenus);
            if (!isExist)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60));

                adminMenus = _context.AdminMenus.ToList();
                _memoryCache.Set("menus", adminMenus, cacheEntryOptions);
            }

            ViewBag.menus = adminMenus;
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
