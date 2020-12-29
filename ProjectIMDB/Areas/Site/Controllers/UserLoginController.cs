using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.ORM.Entities;
using ProjectIMDB.Models.VM;

namespace ProjectIMDB.Areas.Site.Controllers
{
    [Area("Site")]
    public class UserLoginController : Controller
    {
        private readonly IMDBContext _context;

        public UserLoginController(IMDBContext blogcontext)
        {
            _context = blogcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginVM model)
        {

            if (ModelState.IsValid)
            {
                User user = _context.Users.FirstOrDefault(x => x.UserName == model.username && x.Password == model.password);

                if (user != null)
                {
                    var claims = new List<Claim>
                 {
                new Claim(ClaimTypes.Name, model.username),
               
                 };

                    var userIdentity = new ClaimsIdentity(claims, "login");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);

                    user.LastLoginDate = DateTime.Now;

                    _context.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Username or password wrong!";

                    //return Json("Username or password wrong!");

                    //ModelState.AddModelError(nameof(user.UserName), "Incorrect UserName"); ModelState.AddModelError(nameof(user.Password), "Incorrect password");
                    return RedirectToAction("Index", "Home");


                }
            }
            else
            {

                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }



    }
}
