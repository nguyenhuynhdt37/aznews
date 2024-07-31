using aznews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ViewComponent(Name = "AdminMenu")]
public class AdminMenuComponent : ViewComponent
{
    private readonly MyDbContext _context;

    public AdminMenuComponent(MyDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var mslist = await _context.AdminMenus.Where(a => a.IsActive == true).ToListAsync();
        return View("Default", mslist);
    }
}