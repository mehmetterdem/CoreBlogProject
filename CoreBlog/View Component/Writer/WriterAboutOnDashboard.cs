using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreBlog.View_Component.Writer
{

    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writerID=c.Writers.Where(x=>x.WriterMail==usermail).Select(y=>y.WriterId).FirstOrDefault();
            var values = wm.GetWriterById(writerID);
            return View(values);
        }


    }
}
