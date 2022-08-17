using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreBlog.Controllers
{
   
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        Context c=new Context();

        [AllowAnonymous]
        public IActionResult Inbox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var writerid = c.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterId).FirstOrDefault(); ;
            var result = mm.GetInboxListByWriter(writerid);
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
