using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aznews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PagedList.Core;

namespace aznews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly MyDbContext _context;
        public PostController(MyDbContext context)
        {
            _context = context;
        }


        [Route("/Admin/post-index{page:int}.html", Name = "PostIndex")]
        public IActionResult Index(int page = 1)
        {
            var post = _context.TblPosts.OrderByDescending(p => p.PostId);
            int pageSize = 5;
            PagedList<TblPost> models = new(post, page, pageSize);
            if (!models.Any()) return NotFound();
            return View(models);
        }

        public async Task<IActionResult> Create()
        {
            var mslist = await (from m in _context.TblMenus
                                select new SelectListItem()
                                {
                                    Text = m.MenuName,
                                    Value = m.MenuId.ToString()
                                }
                                ).ToListAsync();

            mslist.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = string.Empty
            });

            return View(mslist);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TblPost post)
        {
            if (ModelState.IsValid)
            {
                await _context.TblPosts.AddAsync(post);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}