using ClosedXML.Excel;
using CoreBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

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
    }

}
