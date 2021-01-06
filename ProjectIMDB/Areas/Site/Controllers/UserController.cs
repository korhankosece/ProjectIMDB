using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectIMDB.Models.Attributes;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.ORM.Entities;
using ProjectIMDB.Models.VM;

namespace ProjectIMDB.Areas.Site.Controllers
{
    [Area("Site")]
    [Authorize]

    public class UserController : BaseController
    {
        private readonly IMDBContext _context;

        public UserController(IMDBContext context) : base(context)
        {
            _context = context;
        }

        public IActionResult Watchlist()
        {
            int id = Convert.ToInt32(TempData["ID"]);
            UserPageVM model = new UserPageVM();

            model.UserWatch = _context.WatchLists.Include(x => x.Movie).ThenInclude(Movie => Movie.MoviePeople).ThenInclude(MoviePerson => MoviePerson.Person ).Where(q => q.UserID == id).ToList();


            return View(model);

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


        
        public IActionResult Edit(int id)
        {
            UserVM model = new UserVM();

            User user = _context.Users.FirstOrDefault(q => q.ID == id);
            //  model.id = user.ID; //dene olmalı mı
            model.username = user.UserName;
            model.email = user.EMail;
            model.name = user.Name;
            model.surname = user.SurName;
            model.country = user.Country;
            model.birthdate = user.BirthDate;
            model.password = user.Password;


            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UserVM model)
        {
            User user = _context.Users.FirstOrDefault(x => x.ID == model.id);


            if (ModelState.IsValid)
            {

                //user.ID = model.id;  olmalı mı
                user.UserName = model.username;
                user.Name = model.name;
                user.SurName = model.surname;
                user.EMail = model.email;
                user.Country = model.country;
                user.BirthDate = model.birthdate;
                //user.Password = model.newpassword; ??
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");


            }

            else
            {
                model.username = user.UserName;
                model.email = user.EMail;
                model.name = user.Name;
                model.surname = user.SurName;
                model.country = user.Country;
                model.birthdate = user.BirthDate;
                model.password = user.Password;
                return View(model);
            }
        }





        [HttpPost]
        public IActionResult Change(UserVM model)
        {

            User user = _context.Users.FirstOrDefault(x => x.ID == model.id);

            if (model.password == model.oldpassword && model.newpassword == model.confirmpassword)
            {

                user.Password = model.newpassword;
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                model.username = user.UserName;
                model.email = user.EMail;
                model.name = user.Name;
                model.surname = user.SurName;
                model.country = user.Country;
                model.birthdate = user.BirthDate;
                model.password = user.Password;
                return RedirectToAction("Edit", "User", model);
            }


        }



    }
}
