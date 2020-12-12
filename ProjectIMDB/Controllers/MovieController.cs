using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.ORM.Entities;
using ProjectIMDB.Models.VM;

namespace ProjectIMDB.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMDBContext _context;

        public MovieController(IMDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<MovieVM> movies = _context.Movies.Include(x => x.MovieGenres).ThenInclude(MovieGenres => MovieGenres.Genre).Include(x => x.MoviePeople).ThenInclude(MoviePerson => MoviePerson.Person).Where(q => q.IsDeleted == false).Select(q => new MovieVM()
            {
                id = q.ID,
                name = q.Name,
                duration = q.Duration,
                releasedate = q.ReleaseDate,
                posterurl = q.PosterURL,
                adddate = q.AddDate,
                updatedate = q.UpdateDate,
                moviegenres = q.MovieGenres.Where(x => x.IsDeleted == false).ToList(),
                moviepeople = q.MoviePeople.Where(x => x.IsDeleted == false).ToList()

            }).ToList();

            return View(movies);
        }

        public IActionResult Add()
        {
            MovieVM model = new MovieVM();
            model.genres = _context.Genres.ToList();
            model.personJobs = _context.PersonJobs.Include(q => q.Person).Where(x => x.IsDeleted == false).ToList();

            return View(model);
        }


        [HttpPost]
        public IActionResult Add(MovieVM model, int[] genres, int[] directorarray, int[] scenaristarray, int[] stararray)
        {
            string imagepath = "";
            if (model.movieposter != null)
            {
                var guid = Guid.NewGuid().ToString();
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/adminsite/movieposter", guid + ".jpg");
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    model.movieposter.CopyTo(stream);
                }
                imagepath = guid + ".jpg";
            }

            if (ModelState.IsValid)
            {
                Movie movie = new Movie();
                movie.Name = model.name;
                movie.Duration = model.duration;
                movie.ReleaseDate = model.releasedate;
                movie.PosterURL = imagepath;

                _context.Movies.Add(movie);
                _context.SaveChanges();

                int MovieID = movie.ID;

                foreach (var item in genres)
                {
                    MovieGenre movieGenre = new MovieGenre();
                    movieGenre.MovieID = MovieID;
                    movieGenre.GenreID = item;

                    _context.MovieGenres.Add(movieGenre);
                }
                foreach (var item in directorarray)
                {
                    MoviePerson moviePerson = new MoviePerson();
                    moviePerson.MovieID = MovieID;
                    moviePerson.PersonID = item;
                    moviePerson.JobID = 1;
                    _context.MoviePeople.Add(moviePerson);

                }

                foreach (var item in scenaristarray)
                {
                    MoviePerson moviePerson = new MoviePerson();
                    moviePerson.MovieID = MovieID;
                    moviePerson.PersonID = item;
                    moviePerson.JobID = 2;
                    _context.MoviePeople.Add(moviePerson);

                }

                foreach (var item in stararray)
                {
                    MoviePerson moviePerson = new MoviePerson();
                    moviePerson.MovieID = MovieID;
                    moviePerson.PersonID = item;
                    moviePerson.JobID = 3;
                    _context.MoviePeople.Add(moviePerson);

                }
                _context.SaveChanges();

                return RedirectToAction("Index", "Movie");
            }

            else
            {
                ViewBag.genresbag = _context.Genres.ToList();
                ViewBag.jobsbag = _context.PersonJobs.Include(q => q.Person).Where(x => x.IsDeleted == false).ToList();

                return View();

            }

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(q => q.ID == id);
            movie.IsDeleted = true;
            _context.SaveChanges();

            return Json("Silme işlemi başarılı!!");
        }


        public IActionResult Edit(int id)
        {
            Movie movie = _context.Movies.Include(x => x.MovieGenres).ThenInclude(MovieGenre => MovieGenre.Genre).Include(x => x.MoviePeople).ThenInclude(MoviePerson => MoviePerson.Person).FirstOrDefault(x => x.ID == id);

            MovieVM model = new MovieVM();

            model.id = movie.ID;
            model.name = movie.Name;
            model.duration = movie.Duration;
            model.releasedate = movie.ReleaseDate;
            model.posterurl = movie.PosterURL;
            model.genres = _context.Genres.ToList();
            model.moviegenres = movie.MovieGenres.Where(x => x.IsDeleted == false).ToList();

            model.moviepeople = movie.MoviePeople.Where(x => x.IsDeleted == false).ToList();
            model.personJobs = _context.PersonJobs.Include(q => q.Person).Where(x => x.IsDeleted == false).ToList();

            //var path = Path.Combine(Directory.GetCurrentDirectory(),
            //"wwwroot/adminsite/movieposter", movie.PosterURL);

            //var imageFileStream = System.IO.File.OpenRead(path);
            //model.movieposter = File(imageFileStream, "image/jpeg");



            return View(model);


        }

        [HttpPost]
        public IActionResult Edit(MovieVM model, int[] genres, int[] directorarray, int[] scenaristarray, int[] stararray)
        {
            Movie movie = _context.Movies.Include(x => x.MovieGenres).ThenInclude(MovieGenre => MovieGenre.Genre).Include(x => x.MoviePeople).ThenInclude(MoviePerson => MoviePerson.Person).FirstOrDefault(x => x.ID == model.id);

            if (ModelState.IsValid)
            {
                movie.Name = model.name;
                movie.Duration = model.duration;
                movie.ReleaseDate = model.releasedate;
                movie.PosterURL = model.posterurl;
                movie.UpdateDate = model.updatedate;

                _context.SaveChanges();

                int MovieID = movie.ID;
                List<MovieGenre> movie2 = movie.MovieGenres.ToList();

                foreach (var item in movie2)
                {
                    item.IsDeleted = true;
                }

                foreach (var item in genres)
                {
                    MovieGenre movieGenre = new MovieGenre();
                    movieGenre.GenreID = item;
                    movieGenre.MovieID = MovieID;

                    _context.MovieGenres.Add(movieGenre);
                }

                List<MoviePerson> moviePeople = movie.MoviePeople.ToList();

                foreach (var item in moviePeople)
                {
                    _context.MoviePeople.Remove(item);
                    //item.IsDeleted = true;
                }

                foreach (var item in directorarray)
                {
                    MoviePerson moviePerson = new MoviePerson();
                    moviePerson.MovieID = MovieID;
                    moviePerson.PersonID = item;
                    moviePerson.JobID = 1;
                    _context.MoviePeople.Add(moviePerson);

                }

                foreach (var item in scenaristarray)
                {
                    MoviePerson moviePerson = new MoviePerson();
                    moviePerson.MovieID = MovieID;
                    moviePerson.PersonID = item;
                    moviePerson.JobID = 2;
                    _context.MoviePeople.Add(moviePerson);

                }

                foreach (var item in stararray)
                {
                    MoviePerson moviePerson = new MoviePerson();
                    moviePerson.MovieID = MovieID;
                    moviePerson.PersonID = item;
                    moviePerson.JobID = 3;
                    _context.MoviePeople.Add(moviePerson);

                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Movie");
            }
            else
            {
                ViewBag.genresbag = _context.Genres.ToList();
                ViewBag.jobsbag = _context.PersonJobs.Include(q => q.Person).Where(x => x.IsDeleted == false).ToList();

                return View();
            }

        }

    }
}
