using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.ORM.Entities;
using ProjectIMDB.Models.VM;

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
            List<UserVM> users = _context.Users.Where(q => q.IsDeleted == false).Select(q => new UserVM()
            {

                id = q.ID,
                name = q.Name,
                surname = q.SurName,
                birthdate = q.BirthDate,
                nationality = q.Nationality,
                email = q.EMail,
                adddate = q.AddDate,
                updatedate = q.UpdateDate,
               


            }).ToList();
            return View(users);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            User user = _context.Users.FirstOrDefault(q => q.ID == id);
            user.IsDeleted = true;
            _context.SaveChanges();

            return Json("Silme işlemi başarılı!!");
        }
    }
}
