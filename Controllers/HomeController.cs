using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aznews.Models;
using Microsoft.EntityFrameworkCore;

namespace aznews.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyDbContext _context;

    public HomeController(ILogger<HomeController> logger, MyDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [Route("/post-{abc}-{id:long}.html", Name = "Details")]
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null) return NotFound();
        var content = await _context.TblPosts.FirstOrDefaultAsync(p => p.PostId == id && (p.IsActive ?? false));
        if (content == null) return NotFound();
        return View(content);
    }
}
