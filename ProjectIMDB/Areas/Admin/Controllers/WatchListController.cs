using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.VM;

namespace ProjectIMDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WatchListController : BaseController
    {
        private readonly IMDBContext _context;

        public WatchListController(IMDBContext context, IMemoryCache memoryCache) : base(context, memoryCache)

        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<WatchlistVM> watchlists = _context.WatchLists.Include(x => x.Movie).Include(x => x.User).Where(q => q.IsDeleted == false).Select(q => new WatchlistVM()
            {
                id = q.ID,
                username = q.User.Name + " " + q.User.SurName,
                moviename = q.Movie.Name,
                adddate = q.AddDate,
                updatedate = q.UpdateDate,

            }).ToList();

            return View(watchlists);
        }
    }
}
