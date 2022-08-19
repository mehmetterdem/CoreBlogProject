using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreBlog.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Controllers
{

    public class WriterController : Controller
    {
        Context c = new Context();
        UserManager um = new UserManager(new EfUserRepository());
        WriterManager wm = new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
           
        }
         
        


        [Authorize]
        public IActionResult Index()
        {
            var username = User.Identity.Name;
            Context c = new Context();
            var usermail = c.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var writerName = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v1 = usermail;
            ViewBag.v2 = writerName;
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {

           
            return PartialView();
        }

        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.namesurname = values.NameSurname;
            model.mail = values.Email;
            model.username = values.UserName;
            model.imageurl = values.İmageUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel p)
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = p.mail;
            values.NameSurname = p.namesurname;
            values.İmageUrl = p.imageurl;
            values.UserName = p.username;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.password);
            var result=await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult WriterAdd(AddProfileImage writer)
        {
            Writer w = new Writer();
            if (writer.WriterImage != null)
            {
                var extension = Path.GetExtension(writer.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                writer.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterMail = writer.WriterMail;
            w.WriterName = writer.WriterName;
            w.WriterPassword = writer.WriterPassword;
            w.WriterAbout = writer.WriterAbout;
            w.WriterStatus = true;


            wm.TAdd(w);
            return RedirectToAction("index", "Dashboard");
        }
    }
}
