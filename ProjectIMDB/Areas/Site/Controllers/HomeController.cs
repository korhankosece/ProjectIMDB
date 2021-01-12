using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.VM;

namespace ProjectIMDB.Areas.Site.Controllers
{
    [Area("Site")]
    public class HomeController : BaseController
    {
        private readonly IMDBContext _context;

        public HomeController(IMDBContext context) : base(context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            SiteHomeVM model = new SiteHomeVM();
            model.BannerMovies = _context.Movies.Include(x => x.MovieGenres).ThenInclude(MovieGenres => MovieGenres.Genre).Include(x => x.MoviePeople).ThenInclude(MoviePerson => MoviePerson.Person).Include(x => x.Rates).Include(x=>x.WatchLists).Where(q => q.IsDeleted == false).OrderByDescending(q => q.ID).Take(21).ToList();

            return View(model);


        }




    }

}

