﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
namespace CoreBlog.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        [Area("Admin")]
        public IActionResult Index(int page=1)
        {
            var values=cm.TGetList().ToPagedList(page,3);
            return View(values);
        }
    }
}
