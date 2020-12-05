using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectIMDB.Models.ORM.Context;

namespace ProjectIMDB.Controllers
{
    public class UserController : Controller
    {
        private readonly IMDBContext _context;

        public UserController(IMDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
