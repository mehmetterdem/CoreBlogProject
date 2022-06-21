using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreBlog.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.CreateDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.ContactStatus = true;
            cm.TAdd(contact);
            return RedirectToAction("Index", "Blog");
        }
    }
}
