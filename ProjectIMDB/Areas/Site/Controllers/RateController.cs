using Microsoft.AspNetCore.Mvc;
using ProjectIMDB.Models.Attributes;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.ORM.Entities;
using ProjectIMDB.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Areas.Site.Controllers
{
    [Area("Site")]
    [SiteAuth]

    public class RateController : BaseController
    {
        private readonly IMDBContext _context;

        public RateController(IMDBContext context) : base(context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Add(RateVM model)
        {

            int id = model.movieid;
            int userID = Convert.ToInt32(TempData["ID"]);
            var oldRates = _context.Rates.Where(q => q.MovieID == id && q.UserID == userID).ToList();

            foreach (var item in oldRates)
            {
                item.IsDeleted = true;
            }
            _context.SaveChanges();

            Rate rate = new Rate();
            rate.MovieID = id;
            rate.Point = model.point;
            rate.UserID = userID;

            _context.Rates.Add(rate);
            _context.SaveChanges();

            return Redirect("/Site/MoviePage/Detail/"+id);
        }
    }
}

