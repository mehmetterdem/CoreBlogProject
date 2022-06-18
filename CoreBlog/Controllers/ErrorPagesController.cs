using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    public class ErrorPagesController : Controller
    {
        public IActionResult Error1()
        {
            return View();
        }
    }
}
