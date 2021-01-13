using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [SiteAuth]

    [Area("Site")]

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

            Movie movie = _context.Movies.Include(q => q.Rates.Where(q => q.IsDeleted ==false)).FirstOrDefault(q => q.ID == id);

            double totalrate = 0;

            foreach (var item in  movie.Rates.Where(item => item.IsDeleted == false))
            {
                totalrate += item.Point;

            }
            //movie.TotalRate = totalrate;

            //_context.SaveChanges();

            double rated = movie.Rates.Where(q =>q.IsDeleted==false).Count();
            double awrpoint = totalrate / rated;
            double awerate = Math.Round(awrpoint, 1, MidpointRounding.AwayFromZero);



            movie.AvrPoint = awerate;

            _context.SaveChanges();

            return Redirect("/Site/MoviePage/Detail/" + id);


        }
    }
}

