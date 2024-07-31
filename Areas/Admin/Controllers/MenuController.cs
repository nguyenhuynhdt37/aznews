using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aznews.Models;
using Microsoft.AspNetCore.Mvc;

namespace aznews.Areas.Admin.Controllers
{
    [Area("Menu")]
    public class MenuController : Controller
    {
        private readonly MyDbContext _context;
        public MenuController(MyDbContext context)
        {
            _context = context;
        }
    }
}
