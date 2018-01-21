using System.Linq;
using Ispit_2017_02_15.EF;
using Microsoft.AspNetCore.Mvc;

namespace Ispit_2017_02_15.Controllers
{
    public class HomeController : Controller
    {
        private MojContext _context;

        public HomeController(MojContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestDB()
        {
            if (!_context.Nastavnik.Any())
                MojDBInitializer.Izvrsi(_context);
            return View(_context);
        }
    }
}