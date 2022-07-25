using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Areas.ViewComponents
{
    public class Statistic1:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
