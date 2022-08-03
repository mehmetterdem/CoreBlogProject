using CoreBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CoreBlog.Areas.Admin.Controllers
{
    
    public class WriterController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Area("Admin")]
        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        [Area("Admin")]
        public IActionResult GetWriterById(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x => x.id == writerid);
            var jsonWriter=JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriter);
        }

        [Area("Admin")]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }

        [Area("Admin")]
        public IActionResult DeleteWriter(int id)
        {
            var writer=writers.FirstOrDefault(x=>x.id==id);
            writers.Remove(writer);
            return Json(writer);

        }


        public static List<WriterClass> writers = new List<WriterClass>
        {
           new WriterClass
           {
               id=1,
               name="Ayse"
           },
           new WriterClass
           {
               id=2,
               name="Ali"
           },
           new WriterClass
           {
               id=3,
               name="Mehmet"
           }
        };
    }
}
