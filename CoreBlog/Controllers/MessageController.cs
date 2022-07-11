using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
   
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        [AllowAnonymous]
        public IActionResult Inbox()
        {
            int id = 2;
            var result = mm.GetInboxListByWriter(id);
            return View(result);
        }
        [AllowAnonymous]
        public IActionResult MessageDetails(int id)
        {
            var result = mm.TGetById(id);
            return View(result);
        }
    }
}
