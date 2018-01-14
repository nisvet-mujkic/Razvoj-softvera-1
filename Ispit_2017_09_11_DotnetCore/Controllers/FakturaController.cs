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
    public class FakturaController : Controller
    {
        #region DI
        private MojContext db;
        public FakturaController(MojContext db)
        {
            this.db = db;

        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            FakturaIndexViewModel vm = new FakturaIndexViewModel()
            {
                Rows = db.Faktura.Select(x => new FakturaIndexViewModel.Row()
                {
                    Datum = x.Datum,
                    FakturaId = x.Id,
                    Klijent = x.Klijent.ImePrezime
                }).ToList()
            };

            return View(vm);
        }
        #endregion

        #region Dodaj
        public IActionResult Dodaj()
        {
            #region DD
            List<Klijent> klijenti = db.Klijent.ToList();
            List<SelectListItem> ddKlijenti = new List<SelectListItem>();
            ddKlijenti.Add(new SelectListItem() { Value = string.Empty, Text = "Odaberite klijenta" });
            ddKlijenti.AddRange(klijenti.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.ImePrezime }));


            List<Ponuda> nefakturisanePonude = db.Ponuda.Where(x => x.FakturaID == null).ToList();
            List<SelectListItem> ddPonude = new List<SelectListItem>();
            ddPonude.Add(new SelectListItem() { Value = string.Empty, Text = "Odaberite nefakturisanu ponudu" });
            ddPonude.AddRange(nefakturisanePonude.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = $"{x.Klijent.ImePrezime} - {x.Datum}" }));


            #endregion

            FakturaDodajViewModel vm = new FakturaDodajViewModel()
            {
                Faktura = new Faktura(),
                Klijenti = ddKlijenti,
                NefakturisanePonude = ddPonude
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Dodaj(FakturaDodajViewModel vm)
        {
            Faktura faktura = vm.Faktura;
            db.Faktura.Add(faktura);

            if(vm.IzabranaPonuda != null)
            {
                Ponuda ponuda = db.Ponuda.Where(x => x.Id == vm.IzabranaPonuda).FirstOrDefault();
                ponuda.FakturaID = faktura.Id;
                db.Ponuda.Update(ponuda);

                List<PonudaStavka> ponudeStavke = db.PonudaStavka.Where(x => x.PonudaId == vm.IzabranaPonuda).ToList();

                foreach (var ponudaStavka in ponudeStavke)
                {
                    FakturaStavka fakturaStavka = new FakturaStavka()
                    {
                        FakturaID = faktura.Id,
                        Kolicina = ponudaStavka.Kolicina,
                        ProizvodID = ponudaStavka.ProizvodId,
                        PopustProcenat = 0.05f
                    };

                    db.FakturaStavka.Add(fakturaStavka);
                }
            }

            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Detalji

        public IActionResult Detalji(int id)
        {
            FakturaDetaljiViewModel vm = new FakturaDetaljiViewModel()
            {
                Faktura = db.Faktura.Include(x => x.Klijent).FirstOrDefault(x => x.Id == id)
            };
            
            return View(vm);
        }

        #endregion


    }
}