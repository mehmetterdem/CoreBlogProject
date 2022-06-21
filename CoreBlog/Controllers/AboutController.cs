using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            var result = abm.TGetList();
            return View(result);
        }
        public PartialViewResult SocialMediaAbout()
        {
            
            return PartialView();
        }
    }
}
