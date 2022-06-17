using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreBlog.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        public PartialViewResult PartialAddComment(Comment comment)
        {
            comment.CommentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            comment.BlogId = 2;
            cm.Add(comment);
             
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            var values = cm.ListAll(id);
            return PartialView(values);
        }
    }
}
