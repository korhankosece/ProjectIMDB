using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.ORM.Entities;
using ProjectIMDB.Models.VM;

namespace ProjectIMDB.Areas.Site.Controllers
{
    [Area("Site")]
    public class MoviePageController : Controller
    {
        private readonly IMDBContext _context;

        public MoviePageController(IMDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            MoviePageVM model = new MoviePageVM();
            model.MovieList = _context.Movies.Include(x => x.MovieGenres).ThenInclude(MovieGenres => MovieGenres.Genre).Include(x => x.MoviePeople).ThenInclude(MoviePerson => MoviePerson.Person).Where(q => q.IsDeleted == false).OrderByDescending(q => q.ID).Take(10).ToList();

            return View(model);
        }


        public IActionResult Detail(int id)
        {
            MoviePageVM model = new MoviePageVM();
            model.MovieDetail = _context.Movies.Include(x => x.MovieGenres).ThenInclude(MovieGenres => MovieGenres.Genre).Include(x => x.MoviePeople).ThenInclude(MoviePerson => MoviePerson.Person).Where(q => q.IsDeleted == false && q.ID == id).FirstOrDefault(q =>q.ID==id);

            model.MovieList = _context.Movies.Include(x => x.MovieGenres).ThenInclude(MovieGenres => MovieGenres.Genre).Include(x => x.MoviePeople).ThenInclude(MoviePerson => MoviePerson.Person).Where(q => q.IsDeleted == false).OrderByDescending(q => q.ID).Take(10).ToList();


            return View(model);
        }
    }
}
