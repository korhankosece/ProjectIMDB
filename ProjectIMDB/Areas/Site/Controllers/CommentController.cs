using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectIMDB.Models.Attributes;
using ProjectIMDB.Models.ORM.Context;
using ProjectIMDB.Models.ORM.Entities;
using ProjectIMDB.Models.VM;
using ProjectIMDB.Models.Helpers;

namespace ProjectIMDB.Areas.Site.Controllers
{
    [SiteAuth]

    [Area("Site")]
    public class CommentController : BaseController
    {

        private readonly IMDBContext _context;

        public CommentController(IMDBContext context) : base(context)
        {
            _context = context;
        }

        [Route("/comment/{id}")]

        public IActionResult Add(int id)
        {
            CommentVM model = new CommentVM();



            int a = Convert.ToInt32(TempData["ID"]);
            User user = _context.Users.Where(q => q.IsDeleted == false).FirstOrDefault(q => q.ID == a);

            model.movieid = id;
            model.username = user.UserName;
            return View(model);
        }




        [HttpPost]

        public IActionResult Add(CommentVM model)
        {
            Comment comment = new Comment();
            comment.Content = model.content;
            comment.UserID = Convert.ToInt32(TempData["ID"]);
            comment.MovieID = model.movieid;
            comment.Header = model.header;

            int id = model.movieid;
            Movie movie = _context.Movies.Include(q => q.Comments.Where(q => q.IsDeleted == false)).FirstOrDefault(q => q.ID == id);
            var name = movie.Name;



            _context.Comments.Add(comment);
            _context.SaveChanges();

            string url = "/movie/" + id + "/" + UrlHelper.FriendlyUrl(name);
            return Redirect(url);

        }


        [Route("/commentedit/{id}")]

        public IActionResult Edit(int id)
        {
            Comment comment = _context.Comments.FirstOrDefault(q => q.ID == id);
            CommentVM model = new CommentVM();

            model.header = comment.Header;
            model.content = comment.Content;
            model.movieid = comment.MovieID;
            model.id = comment.ID;


            return View(model);
        }





        [HttpPost]

        public IActionResult Edit(CommentVM model)
        {
            Comment comment = _context.Comments.FirstOrDefault(q => q.ID == model.id);
            comment.Header = model.header;
            comment.Content = model.content;
            comment.MovieID = model.movieid;
            //comment.UserID = Convert.ToInt32(ViewBag.ID);

            var id = comment.MovieID;
            Movie movie = _context.Movies.Include(q => q.Comments.Where(q => q.IsDeleted == false)).FirstOrDefault(q => q.ID == id);
            var name = movie.Name;

            _context.SaveChanges();
            string url = "/movie/" + id + "/" + UrlHelper.FriendlyUrl(name);
            return Redirect(url);




        }




        [HttpPost]

        public IActionResult Delete(int idb)
        {
            Comment comment = _context.Comments.FirstOrDefault(q => q.ID == idb);


            var id = comment.MovieID;
            Movie movie = _context.Movies.Include(q => q.Comments.Where(q => q.IsDeleted == false)).FirstOrDefault(q => q.ID == id);
            var name = movie.Name;

            comment.IsDeleted = true;
            _context.SaveChanges();

            string url = "/movie/" + id + "/" + UrlHelper.FriendlyUrl(name);
            return Redirect(url);
            //return Json("Silme işlemi başarılı!!");
        }

    }
}
