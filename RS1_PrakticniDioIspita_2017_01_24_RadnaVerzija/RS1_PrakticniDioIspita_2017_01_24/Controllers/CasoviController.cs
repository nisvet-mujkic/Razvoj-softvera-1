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
        public IActionResult Prikazi()
        {
            CasoviPrikazViewModel vm = new CasoviPrikazViewModel()
            {
                Nastavnici = db.Nastavnik.Select(x => new CasoviPrikazViewModel.Row()
                {
                    Nastavnik = x.Ime,
                    NastavnikId = x.Id
                }).ToList()
            };

            return View(vm);
        }

        #region Index
        public IActionResult Index(int id)
        {
            CasoviIndexViewModel vm = new CasoviIndexViewModel()
            {
                Rows = db.OdrzaniCas.Include(x => x.Angazovan).Where(x => x.Angazovan.NastavnikId == id).Select(x => new CasoviIndexViewModel.Row()
                {
                    OdrzaniCasId = x.Id,
                    Datum = x.datum, 
                    Odjeljenje = x.Angazovan.Odjeljenje.Oznaka,
                    Predmet = x.Angazovan.Predmet.Naziv
                }).ToList()
            };

            return View(vm);
        }
        #endregion

        #region Dodaj
        public IActionResult Dodaj()
        {
            #region Padajuce liste

            List<Nastavnik> nastavnici = db.Nastavnik.ToList();
            List<SelectListItem> ddNastavnici = new List<SelectListItem>()
            {
                new SelectListItem(){ Value = string.Empty, Text = "Odaberite nastavnika:"}
            };

            ddNastavnici.AddRange(nastavnici.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Ime }));

            List<Angazovan> listaAngazovanih = db.Angazovan.Include(x => x.Odjeljenje).Include(x => x.Predmet).ToList();
            List<SelectListItem> ddAngazovani = new List<SelectListItem>()
            {
                new SelectListItem(){Value = string.Empty, Text = "Odaberite:"}
            };

            ddAngazovani.AddRange(listaAngazovanih.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = $"{x.Odjeljenje.Oznaka} / {x.Predmet.Naziv}" }));

            #endregion

            CasoviDodajViewModel vm = new CasoviDodajViewModel()
            {
                OdrzaniCas = new OdrzaniCas(),
                Nastavnici = ddNastavnici,
                OdjeljenjePredmet = ddAngazovani
            };

            return View(vm);
        }
        #endregion

    }
}