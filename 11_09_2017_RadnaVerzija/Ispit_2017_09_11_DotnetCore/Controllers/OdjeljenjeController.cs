using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Ispit_2017_09_11_DotnetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ispit_2017_09_11_DotnetCore.Controllers
{
    public class OdjeljenjeController : Controller
    {
        #region DI
        private MojContext db;

        public OdjeljenjeController(MojContext db)
        {
            this.db = db;
        }

        #endregion

        #region Index
        public IActionResult Index()
        {
            OdjeljenjeIndexViewModel vm = new OdjeljenjeIndexViewModel()
            {
                Rows = db.Odjeljenje.Select(x => new OdjeljenjeIndexViewModel.Row()
                {
                    OdjeljenjeId = x.Id,
                    Oznaka = x.Oznaka,
                    Razred = x.Razred,
                    Prebaceno = x.IsPrebacenuViseOdjeljenje ? "Da" : "Ne",
                    Razrednik = x.Nastavnik.ImePrezime,
                    SkolskaGodina = x.SkolskaGodina,
                    ProsjekOcjena = db.DodjeljenPredmet.Where(k => k.OdjeljenjeStavka.OdjeljenjeId == x.Id)
                                                       .Average(k => k.ZakljucnoKrajGodine as int?) ?? 0,
                    NajboljiUcenik = (from t1 in db.Ucenik
                                      join t2 in db.OdjeljenjeStavka on t1.Id equals t2.UcenikId
                                      join t3 in db.DodjeljenPredmet on t2.Id equals t3.OdjeljenjeStavkaId
                                      where t2.OdjeljenjeId == x.Id
                                      select t1.ImePrezime).Take(1).ToString()
                }).ToList()
            };

            return View(vm);
        }
        #endregion

        #region Add
        public IActionResult Add()
        {
            #region Lists
            List<Nastavnik> nastavnici = db.Nastavnik.ToList();
            List<SelectListItem> ddNastavnici = new List<SelectListItem>()
            {
                new SelectListItem(){Value = string.Empty, Text = "Odaberite razrednika"}
            };
            ddNastavnici.AddRange(nastavnici.Select(x => new SelectListItem() {Value = x.NastavnikID.ToString(), Text = x.ImePrezime }));

            List<Odjeljenje> neprebacenaOdjeljenja = db.Odjeljenje.Where(x => !x.IsPrebacenuViseOdjeljenje).ToList();
            List<SelectListItem> ddNeprebacenaOdjeljenja = new List<SelectListItem>()
            {
                new SelectListItem(){Value = string.Empty, Text = "Odaberite Odjeljenje"}
            };
            ddNeprebacenaOdjeljenja.AddRange(neprebacenaOdjeljenja.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = $"{x.SkolskaGodina}, {x.Oznaka}"}));

            #endregion


            OdjeljenjeAddViewModel vm = new OdjeljenjeAddViewModel()
            {
                Odjeljenje = new Odjeljenje(),
                NeprebacenaOdjeljenja = ddNeprebacenaOdjeljenja,
                Razrednici = ddNastavnici
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(OdjeljenjeAddViewModel vm)
        {
            Odjeljenje o2 = vm.Odjeljenje;
            db.Odjeljenje.Add(o2);

            if (vm.IzabranoOdjeljenje != null)
            {
                Odjeljenje o1 = db.Odjeljenje.FirstOrDefault(x => x.Id == vm.IzabranoOdjeljenje);
                o1.IsPrebacenuViseOdjeljenje = true;
                db.Odjeljenje.Update(o1);

                List<OdjeljenjeStavka> odjeljenjeStavka = db.OdjeljenjeStavka.Where(x => x.OdjeljenjeId == o1.Id).ToList();

                foreach (var s1 in odjeljenjeStavka)
                {
                    int z = db.DodjeljenPredmet.Where(x => x.OdjeljenjeStavkaId == s1.Id).Count(x => x.ZakljucnoKrajGodine == 1);
                    if(z == 0)
                    {
                        OdjeljenjeStavka s2 = new OdjeljenjeStavka()
                        {
                            BrojUDnevniku = 0,
                            OdjeljenjeId = o2.Id,
                            UcenikId = s1.UcenikId
                        };
                                                
                        db.OdjeljenjeStavka.Add(s2);

                        List<Predmet> predmeti = db.Predmet.Where(k => k.Razred == o2.Razred).ToList();

                        foreach (var p in predmeti)
                        {
                            DodjeljenPredmet dodjeljenPredmet = new DodjeljenPredmet()
                            {
                                OdjeljenjeStavkaId = s2.Id,
                                PredmetId = p.Id,
                                ZakljucnoKrajGodine = 0,
                                ZakljucnoPolugodiste = 0
                            };

                            db.DodjeljenPredmet.Add(dodjeljenPredmet);
                        }
                    }
                }
            }
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            db.Odjeljenje.Remove(db.Odjeljenje.Find(id));
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Details
        public IActionResult Details(int id)
        {
            Odjeljenje odjeljenje = db.Odjeljenje.Include(x => x.Nastavnik).FirstOrDefault(x => x.Id == id);
            OdjeljenjeDetailsViewModel vm = new OdjeljenjeDetailsViewModel()
            {
                OdjeljenjeId = odjeljenje.Id,
                Oznaka = odjeljenje.Oznaka,
                Razred = odjeljenje.Razred,
                Razrednik = odjeljenje.Nastavnik.ImePrezime,
                SkolskaGodina = odjeljenje.SkolskaGodina,
                BrojPredmeta = db.Predmet.Count(x => odjeljenje.Razred == x.Razred)
            };

            return View(vm);
        }
        #endregion
    }
}