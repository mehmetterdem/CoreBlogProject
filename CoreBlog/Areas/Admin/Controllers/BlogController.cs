using ClosedXML.Excel;
using CoreBlog.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoreBlog.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        [Area("Admin")]
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Calısma1");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Name";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformatsofficedocuments.spreadsheetml.sheet", "Calısma1.xlsx");
                }
            }

        }
        List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogList = new List<BlogModel>()
            {
                new BlogModel{ID=1,BlogName="C# Programlama"},
                new BlogModel{ID=2,BlogName="Algoritma mantığı"},
                new BlogModel{ID=3,BlogName="2020 Olimpiyatları"}
            };
            return blogList;
        }
        [Area("Admin")]
        public IActionResult BlogListExcel()
        {
            return View();
        }

        [Area("Admin")]
        public IActionResult ExportDynamicExcelBlogList()
        {
            using(var workbook=new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Dynamic Çalısma1");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Name";
                int BlogRowCount = 2;

                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.Id;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream(BlogRowCount))
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformatsofficedocuments.spreadsheetml.sheet", "DynamicCalısma1.xlsx");
                }
            }
        }
        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> bm = new List<BlogModel2>();
            using(var c=new Context())
            {
               bm= c.Blogs.Select(x => new BlogModel2
                {
                    BlogName = x.BlogTitle,
                    Id=x.BlogId,
                }).ToList();
            }
            return bm;
        }
        [Area("Admin")]
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }

}
