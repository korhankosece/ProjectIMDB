using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.ORM.Entities;
using ProjectIMDB.Models.VM;

namespace ProjectIMDB.Areas.Site.Controllers
{
    [Area("Site")]
    public class MoviePageController : BaseController
    {
        private readonly IMDBContext _context;

        public MoviePageController(IMDBContext context) : base(context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            MoviePageVM model = new MoviePageVM();
            model.MovieList = _context.Movies.Include(x => x.MovieGenres).ThenInclude(MovieGenres => MovieGenres.Genre).Include(x => x.MoviePeople).ThenInclude(MoviePerson => MoviePerson.Person).Include(x =>x.Comments).ThenInclude(Comment => Comment.User).Where(q => q.IsDeleted == false).OrderByDescending(q => q.ID).Take(10).ToList();

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            int userID = Convert.ToInt32(TempData["ID"]);

            MoviePageVM model = new MoviePageVM();
            model.MovieDetail = _context.Movies.Include(x => x.MovieGenres).ThenInclude(MovieGenres => MovieGenres.Genre).Include(x => x.MoviePeople).ThenInclude(MoviePerson => MoviePerson.Person).Include(x =>x.Comments).ThenInclude(Comment => Comment.User).Include(x =>x.WatchLists).Include(x => x.Rates).Where(q => q.IsDeleted == false && q.ID == id).FirstOrDefault(q =>q.ID==id);


            model.MovieList = _context.Movies.Include(x => x.MovieGenres).ThenInclude(MovieGenres => MovieGenres.Genre).Include(x => x.MoviePeople).ThenInclude(MoviePerson => MoviePerson.Person).Include(x => x.Comments).ThenInclude(Comment => Comment.User).Include(x => x.WatchLists).Where(q => q.IsDeleted == false).OrderByDescending(q => q.ID).Take(10).ToList();

            model.Rate = _context.Rates.Include(x => x.Movie).Where(q => q.MovieID == id && q.UserID == userID && q.IsDeleted == false).FirstOrDefault();


            return View(model);
        }
    }
}
