using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
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
            ViewBag.v2 = c.Messages.Where(x => x.ReceiverId == writerid).Count();
            ViewBag.v1 = c.Messages.Where(x => x.SenderId == writerid).Count();
            var values = mm.GetInboxListByWriter(writerid);
            return View(values);
        }

        public IActionResult SendBox()
        {
            
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var writerid = c.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterId).FirstOrDefault();
            ViewBag.v1= c.Messages.Where(x => x.SenderId == writerid).Count();
            ViewBag.v2 = c.Messages.Where(x => x.ReceiverId == writerid).Count();
            var values = mm.GetSendBoxListByWriter(writerid);
            return View(values);
        }

        [HttpGet]
        public IActionResult ComposeMail()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var writerid = c.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterId).FirstOrDefault();
            ViewBag.v1 = c.Messages.Where(x => x.SenderId == writerid).Count();
            ViewBag.v2 = c.Messages.Where(x => x.ReceiverId == writerid).Count();
            return View();
        }

        [HttpPost]
        public IActionResult ComposeMail(Message p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var writerid = c.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterId).FirstOrDefault();

            p.MessageStatus = true;
            p.SenderId = writerid;
            p.ReceiverId = 2;
            p.MessageDate =Convert.ToDateTime(DateTime.Now.ToShortDateString());

            
            
            mm.TAdd(p);
            return RedirectToAction("SendBox");

        }



    }

   
}
