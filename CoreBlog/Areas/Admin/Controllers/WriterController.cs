﻿using CoreBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterById(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x => x.id == writerid);
            var jsonWriter=JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriter);
        }

        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }

        public IActionResult DeleteWriter(int id)
        {
            var writer=writers.FirstOrDefault(x=>x.id==id);
            writers.Remove(writer);
            return Json(writer);

        }
     

        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.id == w.id);
            writer.name=w.name;
            var jsonWriter = JsonConvert.SerializeObject(writer);
            return Json(jsonWriter);

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
