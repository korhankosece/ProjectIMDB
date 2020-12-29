using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.ORM.Entities;
using ProjectIMDB.Models.VM;

namespace ProjectIMDB.Areas.Site.Controllers
{
    [Area("Site")]
    public class UserController : BaseController
    {
        private readonly IMDBContext _context;

        public UserController(IMDBContext context) : base (context)
        {
            _context = context;
        }
      

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterVM model)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.UserName = model.username;
                user.EMail = model.email;
                user.Password = model.password;
                _context.Users.Add(user);
                _context.SaveChanges();

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
