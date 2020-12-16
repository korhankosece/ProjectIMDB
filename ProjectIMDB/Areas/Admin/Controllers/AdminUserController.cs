using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.ORM.Entities;
using ProjectIMDB.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUserController : BaseController
    {
        private readonly IMDBContext _context;

        public AdminUserController(IMDBContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<AdminUserVM> users = _context.AdminUsers.Where(q => q.IsDeleted == false).Select(q => new AdminUserVM()
            {
                id = q.ID,
                name = q.Name,
                surname = q.SurName,
                email = q.EMail,
                password = q.Password,
                adddate = q.AddDate,
                updatedate = q.UpdateDate,

            }).ToList();
            return View(users);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            AdminUser adminUser = _context.AdminUsers.FirstOrDefault(q => q.ID == id);
            adminUser.IsDeleted = true;
            _context.SaveChanges();

            return Json("Silme işlemi başarılı!!");
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AdminUserVM model)
        {
            if (ModelState.IsValid)
            {
                AdminUser adminUser = new AdminUser();
                adminUser.Name = model.name;
                adminUser.SurName = model.surname;
                adminUser.EMail = model.email;
                adminUser.Password = model.password;

                _context.AdminUsers.Add(adminUser);
                _context.SaveChanges();
                return RedirectToAction("Index", "AdminUser");
            }
            else
            {
                return View();
            }

        }
        public IActionResult Edit(int id)
        {
            AdminUser adminUser = _context.AdminUsers.FirstOrDefault(x => x.ID == id);
            AdminUserVM model = new AdminUserVM();

            model.id = adminUser.ID;
            model.name = adminUser.Name;
            model.surname = adminUser.SurName;
            model.email = adminUser.EMail;
            model.password = adminUser.Password;
            model.confirmpassword = adminUser.Password;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(AdminUserVM model)
        {
            AdminUser adminUser = _context.AdminUsers.FirstOrDefault(x => x.ID == model.id);

            if (ModelState.IsValid)
            {
                adminUser.Name = model.name;
                adminUser.SurName = model.surname;
                adminUser.EMail = model.email;
                adminUser.Password = model.password;
                adminUser.UpdateDate = model.updatedate;

                _context.SaveChanges();
                return RedirectToAction("Index", "AdminUser");
            }
            else
            {
                return View();
            }
        }
    }
}
