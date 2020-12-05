using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.VM;

namespace ProjectIMDB.Controllers
{
    public class CommentController : Controller
    {
        private readonly IMDBContext _context;

        public CommentController(IMDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            List<CommentVM> comments = _context.Comments.Include(x => x.Movie).Include(x => x.User).Where(q => q.IsDeleted == false).Select(q => new CommentVM()
            {
                id = q.ID,
                content = q.Content,
                username = q.User.Name + " " + q.User.SurName,
                moviename = q.Movie.Name,
                adddate = q.AddDate,
                updatedate = q.UpdateDate,

            }).ToList();

            return View(comments);

        }
    }
}
