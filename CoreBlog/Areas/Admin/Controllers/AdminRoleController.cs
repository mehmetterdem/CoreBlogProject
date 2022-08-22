using CoreBlog.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public AdminRoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)

            {
                AppRole appRole = new AppRole
                {
                    Name = model.Name
                };
                var result = await _roleManager.CreateAsync(appRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values= _roleManager.Roles.FirstOrDefault(x=>x.Id==id);
            UpdateRoleViewModel model = new UpdateRoleViewModel
            {
                Id = values.Id,
                Name = values.Name,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == model.Id);
            values.Id = model.Id;
            values.Name = model.Name;
            var result=await _roleManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("index");
            }
            return View(result);
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();
            var result=await _roleManager.DeleteAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("index");

            }
            return View(result);

        }
    }
}
