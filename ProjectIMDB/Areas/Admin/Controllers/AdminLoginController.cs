using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.ORM.Entities;
using ProjectIMDB.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectIMDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLoginController : Controller
    {
        private readonly IMDBContext _context;

        public AdminLoginController(IMDBContext blogcontext)
        {
            _context = blogcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginVM model)
        {

            if (ModelState.IsValid)
            {
                AdminUser adminuser = _context.AdminUsers.FirstOrDefault(x => x.EMail == model.EMail && x.Password == model.Password);

                if (adminuser != null)
                {
                    var claims = new List<Claim>
                 {
                new Claim(ClaimTypes.Name, model.EMail),
                new Claim(ClaimTypes.Role, adminuser.Roles)
                 };

                    var userIdentity = new ClaimsIdentity(claims, "login");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);

                    adminuser.LastLoginDate = DateTime.Now;

                    _context.SaveChanges();

                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.error = "Email or password wrong!";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

    }
}

