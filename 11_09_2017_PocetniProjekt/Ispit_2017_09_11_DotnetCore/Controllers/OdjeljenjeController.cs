using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Ispit_2017_09_11_DotnetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Clauses;

namespace Ispit_2017_09_11_DotnetCore.Controllers
{
    public class OdjeljenjeController : Controller
    {
        private MojContext db;

        public OdjeljenjeController(MojContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            OdjeljenjeIndexVM model = new OdjeljenjeIndexVM();

            model.Rows = db.Odjeljenje
                
                .Select(x => new OdjeljenjeIndexVM.Row
                {
                    SkolskaGodina = x.SkolskaGodina,
                    Prebacen = x.IsPrebacenuViseOdjeljenje,
                    Razrednik = x.Nastavnik.ImePrezime,
                    Oznaka = x.Oznaka,
                    Razred = x.Razred,
                    OdjeljenjeID = x.Id
                }).ToList();


            return View("Index", model);
        }

        public IActionResult Dodaj()
        {
            OdjeljenjeDodajVM model = new OdjeljenjeDodajVM
            {
                nastavnici = db.Nastavnik.ToList()
            };

            return View("Dodaj", model);
        }

        public IActionResult Obrisi(int odjeljenjeId)
        {
            Odjeljenje r = db.Odjeljenje.Find(odjeljenjeId);
            db.Odjeljenje.Remove(r);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

            public IActionResult Snimi(string skolaGodina, int razred, string oznaka, int razrednikID)
        {
            Odjeljenje odjeljenje = new Odjeljenje
            {
                SkolskaGodina = skolaGodina,
                Razred = razred,
                Oznaka = oznaka,
                NastavnikID = razrednikID,

            };
            db.Odjeljenje.Add(odjeljenje);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}