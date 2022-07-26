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
           
            return View();
        }
    }
}
