using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ProjectIMDB.Models.ORM.Context;

namespace ProjectIMDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : BaseController
    {
        private readonly IMDBContext _context;

        public AdminController(IMDBContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
