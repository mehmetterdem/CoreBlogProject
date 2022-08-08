using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreBlog.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44374/api/Default");

            var jsonString=await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public IActionResult EmployeeAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeAdd(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content=new StringContent(jsonEmployee, System.Text.Encoding.UTF8,"application/json");
           
            var responseMessage = await httpClient.PostAsync("https://localhost:44374/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View(p);
        }

    }
    public class Class1
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
