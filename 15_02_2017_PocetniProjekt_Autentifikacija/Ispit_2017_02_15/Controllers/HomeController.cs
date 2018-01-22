using System.Linq;
using Ispit_2017_02_15.EF;
using Ispit_2017_02_15.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ispit_2017_02_15.Controllers
{
    public class HomeController : Controller
    {
        private MojContext _context;
        private IHttpContextAccessor httpContext;


        public HomeController(MojContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            this.httpContext = httpContext;
        }

        public ActionResult Login()
        {
            if (Autentifikacija.GetLogiraniKorisnik(httpContext.HttpContext) == null)
                return RedirectToAction("Index", "Login");
            return View();
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