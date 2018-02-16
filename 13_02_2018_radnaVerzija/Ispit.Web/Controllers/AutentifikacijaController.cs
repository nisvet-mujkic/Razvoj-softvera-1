using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eUniverzitet.Web.Helper;
using eUniverzitet.Web.ViewModels;
using Ispit.Data;
using Ispit.Data.EntityModels;
using Ispit.Web.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eUniverzitet.Web.Controllers
{
    public class AutentifikacijaController : Controller
    {
        private readonly MyContext _context;

        public AutentifikacijaController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!_context.Dogadjaj.Any())
                MojDBInitializer.Izvrsi(_context);

            return View(new LoginVM()
            {
                  usersList = _context.KorisnickiNalog.Select(x=>new SelectListItem
                  {
                      Text = x.KorisnickoIme,
                      Value = x.KorisnickoIme
                  }).ToList()
            });
        }

        public IActionResult Login(LoginVM input)
        {
            KorisnickiNalog korisnik = _context.KorisnickiNalog
                .SingleOrDefault(x => x.KorisnickoIme == input.username);

            if (korisnik == null)
            {
                TempData["error_poruka"] = "pogrešan username ili password";
                return View("Index", input);
            }

            HttpContext.SetLogiraniKorisnik(korisnik);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {

            return RedirectToAction("Index");
        }
    }
}