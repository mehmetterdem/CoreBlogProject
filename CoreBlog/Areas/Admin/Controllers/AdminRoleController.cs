using CoreBlog.Areas.Admin.Models;
using CoreBlog.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
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

        public IActionResult UserRoleList()
        {
           var values= _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var roles = _roleManager.Roles.ToList();
            var user = _userManager.Users.Where(x => x.Id == id).FirstOrDefault();

            TempData["userId"]=user.Id;
            var userRoles=await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> model=new List<RoleAssignViewModel>();

            foreach (var item in roles)
            {
                RoleAssignViewModel p = new RoleAssignViewModel();
                p.Id = item.Id;
                p.Name = item.Name;
                p.exist = userRoles.Contains(item.Name);
                model.Add(p);
            }

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userid = (int)TempData["userId"];

            var user = _userManager.Users.Where(x => x.Id == userid).FirstOrDefault();

            foreach (var item in model)
            {
                if (item.exist)
                {
                   await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);    
                }
            }

            return RedirectToAction("UserRoleList");
        }
    }
}
