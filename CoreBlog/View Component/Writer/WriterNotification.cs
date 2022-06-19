using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.View_Component.Writer
{
    public class WriterNotification:ViewComponent

    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
