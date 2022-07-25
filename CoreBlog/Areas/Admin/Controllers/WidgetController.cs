using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreBlog.Areas.Admin.Controllers
{
    public class WidgetController : Controller
    {

        Context c = new Context();
        BlogManager bm = new BlogManager(new EfBlogRepository());
         [Area("Admin")]
        public IActionResult Index()
        {
            ViewBag.v1 = bm.TGetList().Count();
            ViewBag.v2=c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();
            return View();
        }
    }
}
