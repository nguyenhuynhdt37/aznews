using aznews.Areas.Admin.Models;
using aznews.Models;
using aznews.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace aznews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly MyDbContext _context;
        public LoginController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Index(AdminUsers user)
        {
            if (user == null) return NotFound();
            var pass = Function.ComputeMD5Hash(user.Password);
            var check = await _context.AdminUsers.FirstOrDefaultAsync(p => p.UserName == user.UserName && p.Password == pass);
            if (check == null)
            {
                Function._Message = "Tên đăng nhập hoặc mật khẩu không đúng !";
                return RedirectToAction("Index", "Login");
            }
            Function._Message = string.Empty;
            Function._Message = string.Empty;
            Function._UserID = check.UserID;
            Function._UserName = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            Function._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            return RedirectToAction("Index", "Home");
        }
    }
}