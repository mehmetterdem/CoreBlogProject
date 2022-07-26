using CoreBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreBlog.Areas.Admin.Controllers
{
    public class ChartController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                CategoryCount = 10,
                CategoryName = "Teknoloji"
            }) ;
            list.Add(new CategoryClass
            {
                CategoryCount = 15,
                CategoryName = "Yazılım"
            });
            list.Add(new CategoryClass
            {
                CategoryCount = 5,
                CategoryName = "Spor"
            });
            return Json(new {jsonlist=list});
        }
    }
}
