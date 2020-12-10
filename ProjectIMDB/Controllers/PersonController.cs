using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.ORM.Entities;
using ProjectIMDB.Models.Types;
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


            List<PersonVM> personLists = _context.People.Include(q => q.PersonJobs).Where(q => q.IsDeleted == false).Select(q => new PersonVM()
            {
                id = q.ID,
                name = q.Name,
                surname = q.SurName,
                birthdate = q.BirthDate,
                country = q.Country,
                adddate = q.AddDate,
                updatedate = q.UpdateDate,
                jobs = q.PersonJobs.Where(x => x.IsDeleted == false).Select(q => q.JobID == Convert.ToInt32(EnumJob.Director) ? EnumJob.Director.ToString() :
               (q.JobID == Convert.ToInt32(EnumJob.Scenarist) ? EnumJob.Scenarist.ToString() : EnumJob.Star.ToString())).ToList(),

            }).ToList();

            return View(personLists);

        }
        public IActionResult Add()

        {
            List<EnumJob> model = new List<EnumJob>();
            PersonVM model2 = new PersonVM();
            model.Add(EnumJob.Director);
            model.Add(EnumJob.Star);
            model.Add(EnumJob.Scenarist);

            model2.enumJobs = model;
            return View(model2);
        }

        [HttpPost]
        public IActionResult Add(PersonVM model, int[] jobs)
        {

            if (ModelState.IsValid)
            {
                Person person = new Person();
                person.Name = model.name;
                person.SurName = model.surname;
                person.BirthDate = model.birthdate;
                person.Country = model.country;

                _context.People.Add(person);
                _context.SaveChanges();

                int PersonID = person.ID;

                foreach (var item in jobs)
                {
                    PersonJob personJob = new PersonJob();
                    personJob.PersonID = PersonID;
                    personJob.JobID = item;

                    _context.PersonJobs.Add(personJob);
                }
                _context.SaveChanges();


                return RedirectToAction("Index", "Person");
            }

            else
            {
                List<EnumJob> jobmodel = new List<EnumJob>();
                jobmodel.Add(EnumJob.Director);
                jobmodel.Add(EnumJob.Star);
                jobmodel.Add(EnumJob.Scenarist);

                ViewBag.jobbag = jobmodel;


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
            Person person = _context.People.Include(q => q.PersonJobs).FirstOrDefault(q => q.ID == id);
            personVM.id = person.ID;
            personVM.name = person.Name;
            personVM.surname = person.SurName;
            personVM.country = person.Country;
            personVM.birthdate = person.BirthDate;


            personVM.selectedJobs = person.PersonJobs.Where(x => x.IsDeleted == false).Select(q => q.JobID == Convert.ToInt32(EnumJob.Director) ? EnumJob.Director :
               (q.JobID == Convert.ToInt32(EnumJob.Scenarist) ? EnumJob.Scenarist: EnumJob.Star)).ToList();


            List<EnumJob> model = new List<EnumJob>();
            model.Add(EnumJob.Director);
            model.Add(EnumJob.Star);
            model.Add(EnumJob.Scenarist);
            personVM.enumJobs = model;

            return View(personVM);
        }

        [HttpPost]
        public IActionResult Edit(PersonVM model, int[] selectedJobs)
        {
            Person person = _context.People.Include(q => q.PersonJobs).FirstOrDefault(q => q.ID == model.id);

            if (ModelState.IsValid)
            {
                person.Name = model.name;
                person.SurName = model.surname;
                person.Country = model.country;
                person.BirthDate = model.birthdate;
                person.UpdateDate = model.updatedate;

                _context.SaveChanges();

                int PersonID = person.ID;

                List<PersonJob> model2 = person.PersonJobs.ToList();

                foreach (var item in model2)
                {
                    item.IsDeleted = true;
                }

                foreach (var item in selectedJobs)
                {
                    PersonJob personJob = new PersonJob();
                    personJob.PersonID = PersonID;
                    personJob.JobID = item;

                    _context.PersonJobs.Add(personJob);
                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Person");
            }
            else
            {
                List<EnumJob> jobmodel = new List<EnumJob>();
                jobmodel.Add(EnumJob.Director);
                jobmodel.Add(EnumJob.Star);
                jobmodel.Add(EnumJob.Scenarist);
                ViewBag.jobbag = jobmodel;

                return View();
            }

        }

    }
}
