using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_02_15.EF;
using Ispit_2017_02_15.Models;
using Ispit_2017_02_15.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ispit_2017_02_15.Controllers
{
    public class CasoviController : Controller
    {
        #region DI
        private MojContext db;

        public CasoviController(MojContext db)
        {
            this.db = db;
        }

        #endregion

        #region Index
        public IActionResult Index()
        {
            CasoviIndexViewModel vm = new CasoviIndexViewModel()
            {
                Rows = db.Nastavnik.Select(x => new CasoviIndexViewModel.Row()
                {
                    Nastavnik = x.Ime + " " + x.Prezime,
                    NastavnikId = x.Id
                }).ToList()
            };
            return View(vm);
        }
        #endregion

        #region OdrzaniCasovi
        public IActionResult OdrzaniCasovi(int id)
        {
            Nastavnik nastavnik = db.Nastavnik.Find(id);
            CasoviOdrzaniCasoviViewModel vm = new CasoviOdrzaniCasoviViewModel()
            {
                Nastavnik = nastavnik.Ime + " " + nastavnik.Prezime,
                NastavnikId = nastavnik.Id,
                Rows = db.OdrzaniCasovi.Select(x => new CasoviOdrzaniCasoviViewModel.Row()
                {
                    AkademskaGodina = x.Angazovan.AkademskaGodina.Opis,
                    Datum = x.Datum,
                    OdrzaniCasId = x.Id,
                    Predmet = x.Angazovan.Predmet.Naziv,
                    UkupnoUcenika = db.OdrzaniCasDetalji.Count(k => k.OdrzaniCasId == x.Id),
                    PrisutnoUcenika= db.OdrzaniCasDetalji.Count(k => k.OdrzaniCasId == x.Id && k.Prisutan),
                    Prosjek = db.SlusaPredmet.Where(k => k.Angazovan.PredmetId == x.Angazovan.PredmetId).Average(k => (double?)k.Ocjena) ?? 0
                }).ToList()
            };
            return View(vm);
        }
        #endregion

        #region Add
        public IActionResult Add(int id)
        {
            List<Angazovan> angazovan = db.Angazovan.Include(x => x.AkademskaGodina).Include(x => x.Predmet).Where(x => x.NastavnikId == id).ToList();
            List<SelectListItem> ddAngazovan = new List<SelectListItem>()
            {
                new SelectListItem(){Value = string.Empty, Text = "Odaberite:"}
            };
            ddAngazovan.AddRange(angazovan.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = $"{x.AkademskaGodina.Opis} / {x.Predmet.Naziv}" }));


            CasoviAddViewModel vm = new CasoviAddViewModel()
            {
                Nastavnik = db.Nastavnik.Find(id),
                OdrzaniCas = new OdrzaniCas(),
                AkGodinaPredmet = ddAngazovan
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(CasoviAddViewModel vm)
        {
            OdrzaniCas odrzaniCas = vm.OdrzaniCas;
            db.OdrzaniCasovi.Add(odrzaniCas);

            List<SlusaPredmet> slusaPredmet = db.SlusaPredmet.Where(x => x.AngazovanId == vm.OdrzaniCas.AngazovanId).ToList();

            foreach (var student in slusaPredmet)
            {
                db.OdrzaniCasDetalji.Add(new OdrzaniCasDetalji()
                {
                    OdrzaniCasId = odrzaniCas.Id,
                    SlusaPredmetId = student.Id
                });
            }

            db.SaveChanges();
            return RedirectToAction(nameof(OdrzaniCasovi), new { id = vm.Nastavnik.Id });
        }
        #endregion

        #region Edit
        public IActionResult Edit(int id)
        {
            OdrzaniCas odrzaniCas = db.OdrzaniCasovi.Where(x => x.Id == id).FirstOrDefault();

            Angazovan angazovan = db.Angazovan.Find(odrzaniCas.AngazovanId);
            Nastavnik nastavnik = db.Nastavnik.Find(angazovan.NastavnikId);
            AkademskaGodina akademska = db.AkademskaGodina.Find(angazovan.AkademskaGodinaId);
            Predmet predmet = db.Predmet.Find(angazovan.PredmetId);

            CasoviEditViewModel vm = new CasoviEditViewModel()
            {
                OdrzaniCas = odrzaniCas,
                Nastavnik = nastavnik.Ime + " " + nastavnik.Prezime,
                AkGodinaPredmet = akademska.Opis + " / " + predmet.Naziv
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(CasoviEditViewModel vm)
        {
            OdrzaniCas odrzaniCas = vm.OdrzaniCas;
            Angazovan angazovan = db.Angazovan.Find(odrzaniCas.AngazovanId);
            odrzaniCas.Angazovan = angazovan;
            db.OdrzaniCasovi.Update(odrzaniCas);
            db.SaveChanges();

            return RedirectToAction(nameof(OdrzaniCasovi), new { id = vm.OdrzaniCas.Angazovan.NastavnikId });
        }
        #endregion
    }
}