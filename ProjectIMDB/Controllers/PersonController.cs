using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectIMDB.Models.ORM.Context;
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
            List<PersonListVM> personLists = _context.People.Where(q => q.IsDeleted == false).Select(q => new PersonListVM()
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
    }
}
