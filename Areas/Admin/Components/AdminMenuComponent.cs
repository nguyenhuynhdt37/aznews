using System.ComponentModel;
using aznews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace aznews.Components
{
    [ViewComponent(Name = "AdminMenu")]
    public class AdminMenuComponent : Component
    {
        private readonly MyDbContext _context;
        public AdminMenuComponent(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mslist = await _context.AdminMenus.Where(a => a.IsActive == true).ToListAsync();
            return View("", mslist);
        }

    }
}