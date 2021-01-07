using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.ORM.Entities;
using ProjectIMDB.Models.VM;

namespace ProjectIMDB.Areas.Site.Controllers
{
    [Authorize]
    [Area("Site")]
    public class WatchListController : BaseController
    {


        private readonly IMDBContext _context;

        public WatchListController(IMDBContext context) : base(context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Add(int id)
        //{
        //    WatchlistVM model = new WatchlistVM();

        //    model.movieid = id;
        //    return View(model);
        //}


        [HttpPost]

        public IActionResult Add(WatchlistVM model )
        {
            WatchList watchList = new WatchList();
            watchList.MovieID = model.movieid;
            watchList.UserID = Convert.ToInt32(TempData["ID"]);

            _context.WatchLists.Add(watchList);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
