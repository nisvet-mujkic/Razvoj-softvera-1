using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1_Ispit_2017_06_21_v1.EF;
using RS1_Ispit_2017_06_21_v1.Models;
using RS1_Ispit_2017_06_21_v1.ViewModels;

namespace RS1_Ispit_2017_06_21_v1.Controllers
{
    public class IspitiController : Controller
    {
        #region DI
        private MojContext db;
        public IspitiController(MojContext db)
        {
            this.db = db;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            IspitiIndexViewModel vm = new IspitiIndexViewModel()
            {
                Rows = db.MaturskiIspit.Select(x => new IspitiIndexViewModel.Row()
                {
                    MaturskiIspitId = x.Id,
                    Datum = x.Datum,
                    Ispitivac = x.Nastavnik.ImePrezime,
                    Odjeljenje = x.Odjeljenje.Naziv,
                    ProsjecniBodovi = db.MaturskiIspitStavka.Where(k => k.MaturskiIspitId == x.Id).Average(k => k.Bodovi) ?? 0
                }).ToList()
            };

            return View(vm);
        }
        #endregion

        #region Dodaj
        public IActionResult Dodaj()
        {
            #region PunjenjeDD

            List<Odjeljenje> odjeljenja = db.Odjeljenje.Include(x => x.Nastavnik).ToList();
            List<SelectListItem> ddOdjeljenja = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = string.Empty,
                    Text = "Odaberite odjeljenje"
                }
            };

            ddOdjeljenja.AddRange(odjeljenja.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Nastavnik.ImePrezime
            }));

            List<Nastavnik> ispitivaci = db.Nastavnik.ToList();
            List<SelectListItem> ddIspitivaci = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = string.Empty,
                    Text = "Odaberite odjeljenje"
                }
            };

            ddIspitivaci.AddRange(ispitivaci.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.ImePrezime
            }));
            #endregion

            IspitiDodajViewModel vm = new IspitiDodajViewModel()
            {
                MaturskiIspit = new MaturskiIspit(),
                Odjeljenja = ddOdjeljenja,
                Ispitivaci = ddIspitivaci
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Dodaj(IspitiDodajViewModel vm)
        {
            MaturskiIspit maturskiIspit = vm.MaturskiIspit;
            db.MaturskiIspit.Add(maturskiIspit);

            Odjeljenje x = db.Odjeljenje.FirstOrDefault(k => k.Id == maturskiIspit.OdjeljenjeId);

            List<UpisUOdjeljenje> y = db.UpisUOdjeljenje.Where(k => k.OdjeljenjeId == x.Id && k.OpciUspjeh > 1).ToList();

            foreach (var o in y)
            {
                MaturskiIspitStavka maturskiIspitStavka = new MaturskiIspitStavka()
                {
                    Bodovi = null,
                    Oslobodjen = o.OpciUspjeh == 5 ? true : false,
                    MaturskiIspitId = maturskiIspit.Id,
                    UpisUOdjeljenjeId = o.Id
                };

                db.MaturskiIspitStavka.Add(maturskiIspitStavka);
            }

            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Detalji
        public IActionResult Detalji(int id)
        {
            IspitiDetaljiViewModel vm = new IspitiDetaljiViewModel()
            {
                MaturskiIspit = db.MaturskiIspit.Include(x => x.Nastavnik).Include(x => x.Odjeljenje).FirstOrDefault(x => x.Id == id)
            };

            return View(vm);
        }
        #endregion

    }
}