using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aznews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aznews.Components
{
    [ViewComponent(Name = "post")]
    public class PostComponent : ViewComponent
    {
        private readonly MyDbContext db;
        public PostComponent(MyDbContext _db) => db = _db;
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listPost = await db.TblPosts.Where(p => p.IsActive == true).OrderByDescending(p => p.PostOrder).Take(8).ToListAsync();
            return View("Default", listPost);
        }
    }
}