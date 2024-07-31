using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aznews.Areas.Admin.Models;
using aznews.Models;
using aznews.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace aznews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly MyDbContext _context;
        public RegisterController(MyDbContext contex) => _context = contex;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AdminUsers users)
        {
            if (users == null) return NotFound();

            try
            {
                var check = await _context.AdminUsers.FirstOrDefaultAsync(p => p.UserName == users.UserName);
                if (check != null)
                {
                    Function._Message = "Tên đăng nhập đã tồn tại";
                    return RedirectToAction("Index", "Register");
                }
                Function._Message = string.Empty;
                users.Password = Function.ComputeMD5Hash(users.Password);
                await _context.AdminUsers.AddAsync(users);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return NotFound();
            }
        }
    }
}