using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RS1.Ispit.Web.Models;
using RS1_Ispit_asp.net_core.ViewModels;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class UputnicaController : Controller
    {
        #region DI
        private MojContext db;

        public UputnicaController(MojContext db)
        {
            this.db = db;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            UputnicaIndexViewModel vm = new UputnicaIndexViewModel()
            {
                Rows = db.Uputnica.Select(x => new UputnicaIndexViewModel.Row()
                {
                    UputnicaId = x.Id,
                    DatumRezultata = x.DatumRezultata,
                    DatumUputnice = x.DatumUputnice,
                    Pacijent = x.Pacijent.Ime,
                    UputioLjekar = x.UputioLjekar.Ime,
                    VrstaPretrage = x.VrstaPretrage.Naziv
                }).ToList()
            };

            return View(vm);
        }
        #endregion

        #region Dodaj
        public IActionResult Dodaj()
        {
            #region PadajuceListe
            List<Ljekar> dbLjekari = db.Ljekar.ToList();
            List<SelectListItem> ddLjekari = new List<SelectListItem>()
            {
                new SelectListItem(){Value = string.Empty, Text = "Odaberite:"}
            };
            ddLjekari.AddRange(dbLjekari.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Ime }));

            List<Pacijent> dbPacijenti = db.Pacijent.ToList();
            List<SelectListItem> ddPacijenti = new List<SelectListItem>()
            {
                new SelectListItem(){Value = string.Empty, Text = "Odaberite:"}
            };
            ddPacijenti.AddRange(dbPacijenti.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Ime }));

            List<VrstaPretrage> dbVrstePretrage = db.VrstaPretrage.ToList();
            List<SelectListItem> ddVrstePretrage = new List<SelectListItem>()
            {
                new SelectListItem(){Value = string.Empty, Text = "Odaberite:"}
            };
            ddVrstePretrage.AddRange(dbVrstePretrage.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Naziv }));
            #endregion

            UputnicaDodajViewModel vm = new UputnicaDodajViewModel()
            {
                Uputnica = new Uputnica(),
                LjekarUputio = ddLjekari,
                Pacijenti = ddPacijenti,
                VrstePretrage = ddVrstePretrage
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Dodaj(UputnicaDodajViewModel vm)
        {
            Uputnica uputnica = vm.Uputnica;
            db.Uputnica.Add(uputnica);

            List<LabPretraga> listLabPretraga = db.LabPretraga.Where(x => x.VrstaPretrageId == uputnica.VrstaPretrageId).ToList();

            foreach (var p in listLabPretraga)
            {
                RezultatPretrage rezultatPretrage = new RezultatPretrage()
                {
                    LabPretragaId = p.Id,
                    UputnicaId = uputnica.Id
                };

                db.RezultatPretrage.Add(rezultatPretrage);
            }

            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Detalji
        public IActionResult Detalji(int uputnicaId)
        {
            UputnicaDetaljiViewModel vm = new UputnicaDetaljiViewModel()
            {
                Uputnica = db.Uputnica.Where(x => x.Id == uputnicaId).Select(x => new UputnicaDetaljiViewModel.Detalj()
                {
                    UputnicaId = uputnicaId,
                    DatumRezultata = x.DatumRezultata,
                    DatumUputnice = x.DatumUputnice,
                    Pacijent = x.Pacijent.Ime
                }).FirstOrDefault()
            };

            return View(vm);
        }
        #endregion

        #region ZavrsenUnos
        public IActionResult ZavrsiUnos(int uputnicaId)
        {
            Uputnica uputnica = db.Uputnica.Find(uputnicaId);

            uputnica.IsGotovNalaz = true;
            uputnica.DatumRezultata = DateTime.Now;

            db.Uputnica.Update(uputnica);

            db.SaveChanges();
            return RedirectToAction("Index", "Rezultati", new { uputnicaId });
        }
        #endregion

        #region ValidirajDatum
        public IActionResult ValidirajDatum(string datum)
        {
            Regex pravilo = new Regex(@"(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d");
            if (!pravilo.IsMatch(datum))
                return Json("Datum nije u ispravnom formatu.");
            return Json(true);
        }
        #endregion

    }
}