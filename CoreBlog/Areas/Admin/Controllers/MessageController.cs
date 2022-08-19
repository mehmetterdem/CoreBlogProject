using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Areas.Admin.Controllers
{
    public class MessageController : Controller
    {
        [Area("admin")]
        public IActionResult Inbox()
        {
            return View();
        }
    }
}
