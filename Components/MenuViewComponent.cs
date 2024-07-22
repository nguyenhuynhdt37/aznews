using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aznews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aznews.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly MyDbContext _context;
        public MenuViewComponent(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofMenu = await _context.TblMenus.Where(p => p.IsActive && p.Position == 1).ToListAsync();
            return await Task.FromResult((IViewComponentResult)View("Default", listofMenu));
        }
    }
}