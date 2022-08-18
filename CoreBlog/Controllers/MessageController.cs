using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CoreBlog.Controllers
{
   
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        Context c=new Context();

        public IActionResult Inbox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var writerid = c.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterId).FirstOrDefault(); ;
            var result = mm.GetInboxListByWriter(writerid);
            return View(result);
        }


        public IActionResult MessageDetails(int id)
        {
            var result = mm.TGetById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SendMessage(Message p)
        {

            var username = User.Identity.Name;
            var usermail= c.Users.Where(x => x.UserName == username).Select(x=>x.Email).FirstOrDefault();
            var writerid=c.Writers.Where(c => c.WriterMail == usermail).Select(c => c.WriterId).FirstOrDefault();
            
            p.SenderId = writerid;
            p.ReceiverId = 2;
            p.MessageStatus = true;
            p.MessageDate =Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.TAdd(p);
            return RedirectToAction("inbox", "Message");



        }
    }
}
