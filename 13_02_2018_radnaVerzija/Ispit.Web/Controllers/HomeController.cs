using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ispit.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.Web.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext db)
        {
            _context = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestDB()
        {
            if (!_context.Dogadjaj.Any())
                MojDBInitializer.Izvrsi(_context);
            return View(_context);
        }

    }
}
