using CoreBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreBlog.View_Component
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = new List<UserComment>
            {
                new UserComment
                {
                    ID = 1,
                    UserName="Mehmet"
                },
                new UserComment {
                    ID = 2,
                    UserName="Gamze"
                },
                new UserComment
                {
                    ID=3,
                    UserName="Melih"
                }

            };
            return View(values);
        }
    }
}
