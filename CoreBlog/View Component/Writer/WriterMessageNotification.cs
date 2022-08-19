using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreBlog.View_Component.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var writerid = c.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterId).FirstOrDefault(); ;
            var values = mm.GetInboxListByWriter(writerid);
            return View(values);
        }
    }
}
