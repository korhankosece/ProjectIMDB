using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.VM;

namespace ProjectIMDB.Areas.Adminsite.Controllers
{
   
    public class RateController : Controller
    {
        private readonly IMDBContext _context;

        public RateController(IMDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            List<RateVM> rates = _context.Rates.Include(x => x.Movie).Include(x => x.User).Where(q => q.IsDeleted == false).Select(q => new RateVM()
            {
                id = q.ID,
                point = q.Point,
                username = q.User.Name + " " + q.User.SurName,
                moviename = q.Movie.Name,
                adddate = q.AddDate,
                updatedate = q.UpdateDate,

            }).ToList();

            return View(rates);

        }
    }
}
