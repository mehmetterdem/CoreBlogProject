using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
namespace CoreBlog.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        [Area("Admin")]
        public IActionResult Index(int page=1)
        {
            var values=cm.TGetList().ToPagedList(page,3);
            return View(values);
        }
        [Area("Admin")]
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();  
        }
        [Area("Admin")]
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            CategoryValidator cv=new CategoryValidator();   
            ValidationResult result=cv.Validate(p);
            if (result.IsValid)
            {
                p.CategoryStatus = true;
                cm.TAdd(p);
                return RedirectToAction("Index","Category");   
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
