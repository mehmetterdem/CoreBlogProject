using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        Context c=new Context();    
     
        public IActionResult Inbox()
        {
            var username=User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var writerid=c.Writers.Where(x=>x.WriterMail == usermail).Select(x => x.WriterId).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerid);
            return View(values);
        }

        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var writerid = c.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterId).FirstOrDefault();
            var values = mm.GetSendBoxListByWriter(writerid);
            return View(values);
        }

        public IActionResult ComposeMail()
        {
            return View();
        }
    }
}
