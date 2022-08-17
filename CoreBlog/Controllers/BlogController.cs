using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {


        private readonly UserManager<AppUser> _userManager;

        public BlogController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();



        public IActionResult Index()
        {
            var result = bm.GetBlogListWithCategory();
            return View(result);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.Id = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterId).FirstOrDefault();
            var result = c.Users.Where(x => x.Id == writerID).Select(x => x.Id).FirstOrDefault();
            var values = bm.GetListWithCategoryByWriterBm(result);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {

            List<SelectListItem> categotyvalue = (from x in cm.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.cv = categotyvalue;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BlogAdd(Blog blog)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterId).FirstOrDefault();
            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(blog);
            if (result.IsValid)
            {
                List<SelectListItem> categoryvalue = (from x in cm.TGetList()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.CategoryName,
                                                          Value = x.CategoryId.ToString()
                                                      }).ToList();
                ViewBag.cv = categoryvalue;
                blog.BlogStatus = true;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = writerID;
                bm.TAdd(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");

        }


        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            List<SelectListItem> categotyvalue = (from x in cm.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.cv = categotyvalue;
            var blogvalue = bm.TGetById(id);

            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterId).FirstOrDefault();
            blog.BlogStatus = true;
            blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.WriterId = writerID;
            bm.TUpdate(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
