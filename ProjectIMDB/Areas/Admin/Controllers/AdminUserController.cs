using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ProjectIMDB.Models.Attributes;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.ORM.Entities;
using ProjectIMDB.Models.Types;
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

        //[RoleControl(EnumRole.AdminUserList)]
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
        //[RoleControl(EnumRole.AdminUserList)]
        //public IActionResult Index()
        //{
        //    List<AdminUserVM> admins = _bookcontext.AdminUsers.Where(q => q.IsDeleted == false).Select(q => new AdminUserVM()
        //    {
        //        UserID = q.ID,
        //        Name = q.Name,
        //        SurName = q.SurName,
        //        role = q.Role,
        //        Email = q.Email,
        //        Password = q.Password,
        //        AddDate = q.AddDate,
        //        UpdateDate = q.UpdateDate,
        //        IsDeleted = q.IsDeleted,
        //    }).ToList();


        //    List<EnumRole> role = new List<EnumRole>();
        //    role = Enum.GetValues(typeof(EnumRole)).Cast<EnumRole>().ToList();


        //    foreach (var item in admins)
        //    {
        //        item.rolelist = new List<string>();

        //        foreach (var data in role)
        //        {
        //            if (item.role != null)
        //            {
        //                string[] userroles = item.role.Split(';');
        //                foreach (var x in userroles)
        //                {
        //                    if (!String.IsNullOrEmpty(x))
        //                    {
        //                        if (Convert.ToInt32(x) == Convert.ToInt32(data))
        //                        {
        //                            item.rolelist.Add(data.ToString());
        //                            //item.roleview = item.roleview + " - " + data.ToString();
        //                        }
        //                    }
        //                }
        //            }

        //        }

        //    }

        //    return View(admins);
        //}
        //[RoleControl(EnumRole.AdminUserDelete)

        [HttpPost]
        public IActionResult Delete(int id)
        {
            AdminUser adminUser = _context.AdminUsers.FirstOrDefault(q => q.ID == id);
            adminUser.IsDeleted = true;
            _context.SaveChanges();

            return Json("Silme işlemi başarılı!!");
        }


        //[RoleControl(EnumRole.AdminUserAdd)]
        public IActionResult Add()
        {
            List<EnumRole> model = new List<EnumRole>();

            AdminUserVM model2 = new AdminUserVM();

            model = Enum.GetValues(typeof(EnumRole))
                .Cast<EnumRole>().ToList();


            //model.Add(EnumRole.AdminUserAdd);
            //model.Add(EnumRole.AdminUserList);
            model2.enumRoles = model;


            return View(model2);
        }
        [HttpPost]
        public IActionResult Add(AdminUserVM model, int[] roles)
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

                //int AdminUserID = adminUser.ID;
                //foreach (var item in roles)
                //{
                //    adminUser.ID = AdminUserID;
                //    adminUser.RoleID = item.ToString();

                //    _context.SaveChanges();


                //}

                string rolenames = " ";

                foreach (var item in roles)
                {
                    rolenames = rolenames + item.ToString() + ";";


                }
                adminUser.Roles = rolenames;

                _context.SaveChanges();




                return RedirectToAction("Index", "AdminUser");
            }
            else
            {
                return View();
            }

        }

        //[RoleControl(EnumRole.AdmminUserEdit)]

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
