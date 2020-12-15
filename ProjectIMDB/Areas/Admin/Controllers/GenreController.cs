using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.ORM.Entities;
using ProjectIMDB.Models.VM;

namespace ProjectIMDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GenreController : BaseController
    {
        private readonly IMDBContext _context;

        public GenreController(IMDBContext context, IMemoryCache memoryCache) : base(context, memoryCache)

        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<GenreVM> genres = _context.Genres.Where(q => q.IsDeleted == false).Select(q => new GenreVM()
            {
                id = q.ID,
                name = q.Name,
                adddate = q.AddDate,
                updatedate = q.UpdateDate,

            }).ToList();

            return View(genres);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(GenreVM model)
        {
            if (ModelState.IsValid)
            {
                Genre genre = new Genre();
                genre.Name = model.name;

                _context.Genres.Add(genre);
                _context.SaveChanges();
                return RedirectToAction("Index", "Genre");
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Genre genre = _context.Genres.FirstOrDefault(q => q.ID == id);
            genre.IsDeleted = true;
            _context.SaveChanges();

            return Json("Silme işlemi başarılı!!");
        }

        public IActionResult Edit(int id)
        {
            Genre genre = _context.Genres.FirstOrDefault(x => x.ID == id);
            GenreVM model = new GenreVM();

            model.id = genre.ID;
            model.name = genre.Name;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(GenreVM model)
        {
            Genre genre = _context.Genres.FirstOrDefault(x => x.ID == model.id);

            if (ModelState.IsValid)
            {
                genre.Name = model.name;
                genre.UpdateDate = model.updatedate;

                _context.SaveChanges();
                return RedirectToAction("Index", "Genre");
            }
            else
            {
                return View();
            }
        }
    }
}
