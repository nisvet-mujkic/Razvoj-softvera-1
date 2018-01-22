using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_02_15.EF;
using Ispit_2017_02_15.Helper;
using Ispit_2017_02_15.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ispit_2017_02_15.Controllers
{
    public class LoginController : Controller
    {
        private MojContext db;
        private IHttpContextAccessor httpContext;
        public LoginController(MojContext db, IHttpContextAccessor httpContext)
        {
            this.db = db;
            this.httpContext = httpContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Provjera(string username, string password)
        {

            Nastavnik nastavnik = db.Nastavnik.Where(x => x.Username == username).FirstOrDefault();
            Autentifikacija.SetLogiraniKorisnik(nastavnik, httpContext.HttpContext);
            if (nastavnik == null)
                return RedirectToAction("Index", "Login");
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
    }
}