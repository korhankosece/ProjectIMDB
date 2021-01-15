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
            model.MovieList = _context.Movies.Include(x => x.MovieGenres).ThenInclude(MovieGenres => MovieGenres.Genre).Include(x => x.MoviePeople).ThenInclude(MoviePerson => MoviePerson.Person).Include(x => x.Comments).ThenInclude(Comment => Comment.User).Include(x => x.Rates).Where(q => q.IsDeleted == false).OrderByDescending(q => q.ID).Take(21).ToList();

            model.GenreList = _context.Genres.ToList();

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            int userID = Convert.ToInt32(TempData["ID"]);

            MoviePageVM model = new MoviePageVM();
            model.MovieDetail = _context.Movies.Include(x => x.MovieGenres).ThenInclude(MovieGenres => MovieGenres.Genre).Include(x => x.MoviePeople).ThenInclude(MoviePerson => MoviePerson.Person).Include(x => x.Comments).ThenInclude(Comment => Comment.User).Include(x => x.WatchLists).Include(x => x.Rates).Include(q => q.MovieImages).Include(q => q.MovieVideos).Where(q => q.IsDeleted == false && q.ID == id).FirstOrDefault(q => q.ID == id);

            model.MovieList = _context.Movies.Include(x => x.MovieGenres).ThenInclude(MovieGenres => MovieGenres.Genre).Include(x => x.MoviePeople).ThenInclude(MoviePerson => MoviePerson.Person).Include(x => x.Comments).ThenInclude(Comment => Comment.User).Include(x => x.Rates).Include(x => x.WatchLists).Where(q => q.IsDeleted == false).OrderByDescending(q => q.ID).Take(21).ToList();

            model.Rate = _context.Rates.Include(x => x.Movie).Where(q => q.MovieID == id && q.UserID == userID && q.IsDeleted == false).FirstOrDefault();


            return View(model);
        }

        public IActionResult HomeSearch(SearchVM search)
        {
            MoviePageVM model = new MoviePageVM();

            model.MovieList = _context.Movies.Include(x => x.MovieGenres).ThenInclude(MovieGenres => MovieGenres.Genre).Include(x => x.MoviePeople).ThenInclude(MoviePerson => MoviePerson.Person).Where(q => q.Name.ToLower().Contains(search.name) || q.MoviePeople.Where(q => q.Person.Name.ToLower().Contains(search.name)).Any() || q.MoviePeople.Where(q => q.Person.SurName.ToLower().Contains(search.name)).Any() && q.IsDeleted == false).Include(q => q.Rates).Where(Movie => Movie.IsDeleted == false).OrderByDescending(q => q.ID).Take(21).ToList();

            model.GenreList = _context.Genres.Where(q => q.IsDeleted == false).ToList();
            return View("Index", model);

        }

        public IActionResult SearchForMovie(SearchVM search)
        {

            var data = _context.Movies.Include(x => x.MovieGenres).ThenInclude(MovieGenres => MovieGenres.Genre).Include(x => x.MoviePeople).ThenInclude(MoviePerson => MoviePerson.Person).Include(q => q.Rates).Where(q => q.IsDeleted == false).ToList();

            if (!string.IsNullOrEmpty(search.name))
            {
                data = data.Where(q => q.Name.ToLower().Contains(search.name)).Where(Movie => Movie.IsDeleted == false).ToList();
            }

            if (search.genrename != null && search.genrename.Count() != 0)
            {
                data = data.Where(q => q.MovieGenres.Where(q => search.genrename.Contains(q.Genre.ID) && q.IsDeleted == false).Any()).Where(Movie => Movie.IsDeleted == false).ToList();
            }

            if (!string.IsNullOrEmpty(search.raterange))
            {
                data = data.Where(q => q.AvrPoint >= Convert.ToDouble(search.raterange.Split("-")[0]) && q.AvrPoint <= Convert.ToDouble(search.raterange.Split("-")[1])).Where(Movie => Movie.IsDeleted == false).ToList();
            }

            if (search.yearrangefrom != 0)
            {
                data = data.Where(q => q.ReleaseDate.Year > search.yearrangefrom).Where(Movie => Movie.IsDeleted == false).ToList();
            }

            if (search.yearrangeto != 0)
            {
                data = data.Where(q => q.ReleaseDate.Year < search.yearrangeto).Where(Movie => Movie.IsDeleted == false).ToList();
            }

            var MoviePageVM = new MoviePageVM
            {
                MovieList = data,
                GenreList = _context.Genres.ToList()
            };


            return View("Index", MoviePageVM);

        }

    }
}

