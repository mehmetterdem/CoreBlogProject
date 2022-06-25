using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.View_Component.Writer
{
    public class WriterNotification : ViewComponent

    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values=nm.TGetList();
            return View(values);
        }
    }
}
