using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1_PrakticniDioIspita_2017_01_24.EF;
using RS1_PrakticniDioIspita_2017_01_24.Models;
using RS1_PrakticniDioIspita_2017_01_24.ViewModels;

namespace RS1_PrakticniDioIspita_2017_01_24.Controllers
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

        public IActionResult Nastavnici()
        {
            CasoviNastavniciViewModel vm = new CasoviNastavniciViewModel()
            {
                Rows = db.Nastavnik.Select(x => new CasoviNastavniciViewModel.Row()
                {
                    NastavnikId = x.Id,
                    Nastavnik = x.Ime
                }).ToList()
            };

            return View(vm);
        }

        public IActionResult Index(int nastavnikId)
        {
            
            CasoviIndexViewModel vm = new CasoviIndexViewModel()
            {
                Nastavnik = db.Nastavnik.Find(nastavnikId),
                Rows = db.OdrzaniCas.Select(x => new CasoviIndexViewModel.Row()
                {
                    OdrzaniCasId = x.Id,
                    Datum = x.datum,
                    Odjeljenje = x.Angazovan.Odjeljenje.Oznaka,
                    Predmet = x.Angazovan.Predmet.Naziv,
                    UkupnoPrisutnih = db.OdrzaniCasDetalj.Where(k => k.OdrzaniCasId == x.Id).Count(k => k.Odsutan),
                    UkupnoUcenika = db.OdrzaniCasDetalj.Count(k => k.OdrzaniCasId == x.Id)
                }).ToList()
            };

            return View(vm);
        }
        #endregion

        #region Add
        public IActionResult Add(int nastavnikId)
        {
            List<Angazovan> angazovan = db.Angazovan.Include(x => x.Odjeljenje).Include(x => x.Predmet).Where(x => x.NastavnikId == nastavnikId).ToList();
            List<SelectListItem> ddList = new List<SelectListItem>()
            {
                new SelectListItem(){Value = string.Empty, Text = "Odaberite: "}
            };

            ddList.AddRange(angazovan.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = $"{x.Odjeljenje.Oznaka} / {x.Predmet.Naziv}" }));

            CasoviAddViewModel vm = new CasoviAddViewModel()
            {
                Nastavnik = db.Nastavnik.Find(nastavnikId),
                OdrzaniCas = new OdrzaniCas(),
                OdjeljenjePredmet = ddList
            };

            return View(vm);
        }

      

        [HttpPost]
        public IActionResult Add(CasoviAddViewModel vm)
        {
            OdrzaniCas odrzaniCas = vm.OdrzaniCas;
            db.OdrzaniCas.Add(odrzaniCas);

            Angazovan angazovan = db.Angazovan.Find(vm.OdrzaniCas.AngazovanId);
            Nastavnik nastavnik = db.Nastavnik.Find(angazovan.NastavnikId);

            List<UpisUOdjeljenje> upis = db.UpisUOdjeljenje.Where(x => x.OdjeljenjeId == angazovan.OdjeljenjeId).ToList();

            foreach (var item in upis)
            {
                db.OdrzaniCasDetalj.Add(new OdrzaniCasDetalj()
                {
                    OdrzaniCasId = odrzaniCas.Id,
                    UpisUOdjeljenjeId = item.Id
                });
            };

            db.SaveChanges();
            return RedirectToAction(nameof(Index), new { nastavnikId = nastavnik.Id });
        }
        #endregion

        #region Edit
        public IActionResult Edit(int odrzaniCasId)
        {
            OdrzaniCas odrzaniCas = db.OdrzaniCas.Find(odrzaniCasId);
            Angazovan angazovan = db.Angazovan.Find(odrzaniCas.AngazovanId);

            List<Angazovan> angazovanList = db.Angazovan.Include(x => x.Odjeljenje).Include(x => x.Predmet).Where(x => x.NastavnikId == angazovan.NastavnikId).ToList();
            List<SelectListItem> ddList = new List<SelectListItem>()
            {
                new SelectListItem(){Value = string.Empty, Text = "Odaberite: "}
            };

            ddList.AddRange(angazovanList.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = $"{x.Odjeljenje.Oznaka} / {x.Predmet.Naziv}" }));

            CasoviEditViewModel vm = new CasoviEditViewModel()
            {
                OdrzaniCas = odrzaniCas,
                NastavnikId = angazovan.NastavnikId.Value,
                OdjeljenjePredmet = ddList
            };

            return View(vm);
        }
        #endregion
    }
}