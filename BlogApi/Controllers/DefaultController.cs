using BlogApi.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult EmployeeAdd(Employee e)
        {
            using var c=new Context();
            c.Add(e);
            c.SaveChanges();
            return Ok(e);
        }
    }
}
