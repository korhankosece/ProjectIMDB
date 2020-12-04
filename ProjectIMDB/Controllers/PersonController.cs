using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.ORM.Entities;
using ProjectIMDB.Models.VM;

namespace ProjectIMDB.Controllers
{
    public class PersonController : Controller
    {
        private readonly IMDBContext _context;

        public PersonController(IMDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<PersonVM> personLists = _context.People.Where(q => q.IsDeleted == false).Select(q => new PersonVM()
            {
                id = q.ID,
                name = q.Name,
                surname = q.SurName,
                birthdate = q.BirthDate,
                nationality = q.Nationality,
                adddate = q.AddDate,
                updatedate = q.UpdateDate,
                isdeleted = q.IsDeleted,

            }).ToList();

            return View(personLists);

        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PersonVM model)
        {

            if (ModelState.IsValid)
            {
                Person person = new Person();
                person.Name = model.name;
                person.SurName = model.surname;
                person.BirthDate = model.birthdate;
                person.Nationality = model.nationality;

                _context.People.Add(person);
                _context.SaveChanges();
                return RedirectToAction("Index", "Person");
            }

            else
            {
                return View();

            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Person person = _context.People.FirstOrDefault(q => q.ID == id);
            person.IsDeleted = true;
            _context.SaveChanges();

            return Json("Silme işlemi başarılı!!");
        }

        public IActionResult Edit(int id)
        {
            PersonVM personVM = new PersonVM();
            Person person = _context.People.FirstOrDefault(q => q.ID == id);
            personVM.id = person.ID;
            personVM.name = person.Name;
            personVM.surname = person.SurName;
            personVM.nationality = person.Nationality;
            personVM.birthdate = person.BirthDate;
            return View(personVM);
        }
        [HttpPost]
        public IActionResult Edit(PersonVM model)
        {
            Person person = _context.People.FirstOrDefault(q => q.ID == model.id);

            if (ModelState.IsValid)
            {
                person.Name = model.name;
                person.SurName = model.surname;
                person.Nationality = model.nationality;
                person.BirthDate = model.birthdate;
                person.UpdateDate = model.updatedate;

                _context.SaveChanges();
                return RedirectToAction("Index", "Person");
            }
            else
            {
                return View();
            }

        }

    }
}
