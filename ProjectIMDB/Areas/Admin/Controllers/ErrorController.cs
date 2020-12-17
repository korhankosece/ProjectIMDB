using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ProjectIMDB.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ErrorController : BaseController
    {
        private readonly IMDBContext _context;

        public ErrorController(IMDBContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _context = context;
        }
        public IActionResult UnauthorizedAccess()
        {
            return View();
        }
    }
}
