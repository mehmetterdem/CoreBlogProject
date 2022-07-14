using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreBlog.Controllers
{
   
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.BlogSayısı = c.Blogs.Count().ToString();
            ViewBag.BlogSayın = c.Blogs.Where(x => x.WriterId == 1).Count().ToString();
            ViewBag.KategoriSayısı = c.Categories.Count().ToString();
            return View();
        }
    }
}
