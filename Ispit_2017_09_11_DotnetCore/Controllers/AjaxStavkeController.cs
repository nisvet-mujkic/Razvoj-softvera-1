using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Ispit_2017_09_11_DotnetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ispit_2017_09_11_DotnetCore.Controllers
{
    public class AjaxStavkeController : Controller
    {
        private MojContext db;

        public AjaxStavkeController(MojContext db)
        {
            this.db = db;
        }

        #region Index
        public IActionResult Index(int fakturaId)
        {
            AjaxStavkeIndexViewModel vm = new AjaxStavkeIndexViewModel()
            {
                FakturaId = fakturaId,
                Rows = db.FakturaStavka.Where(x => x.FakturaID == fakturaId).Select(x => new AjaxStavkeIndexViewModel.Row()
                {
                    Cijena = x.Proizvod.Cijena,
                    Kolicina = x.Kolicina,
                    Proizvod = x.Proizvod.Naziv,
                    FakturaStavkaID = x.Id,
                    Popust = x.PopustProcenat,
                    Iznos = (x.Kolicina * x.Proizvod.Cijena) * (1 - x.PopustProcenat)
                }).ToList()
            };
            return PartialView(vm);
        }
        #endregion

        #region Obrisi

        public IActionResult Obrisi(int fakturaStavkaId)
        {
            FakturaStavka fakturaStavka = db.FakturaStavka.FirstOrDefault(x => x.Id == fakturaStavkaId);
            int fId = fakturaStavka.FakturaID;

            db.FakturaStavka.Remove(fakturaStavka);
            db.SaveChanges();

            return Redirect("/AjaxStavke/Index?fakturaId="+fId);
        }

        #endregion

        #region Dodaj

        public IActionResult Dodaj(int fakturaId)
        {
            List<Proizvod> proizvodi = db.Proizvod.ToList();
            List<SelectListItem> ddProizvodi = new List<SelectListItem>();

            ddProizvodi.Add(new SelectListItem() { Value = string.Empty, Text = "Odaberite proizvod" });

            ddProizvodi.AddRange(proizvodi.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Naziv }));

            AjaxStavkeDodajViewModel vm = new AjaxStavkeDodajViewModel()
            {
                FakturaId = fakturaId,
                Kolicina = 0,
                Proizvodi = ddProizvodi,
                ProizvodId = 0
            };

            return PartialView(vm);
        }

        #endregion

        #region Snimi

        public IActionResult Snimi(AjaxStavkeDodajViewModel vm)
        {
            FakturaStavka fakturaStavka;

            if (vm.FakturaStavkaId == 0)
            {
                fakturaStavka = new FakturaStavka();
                db.FakturaStavka.Add(fakturaStavka);
            }
            else
            {
                fakturaStavka = db.FakturaStavka.Find(vm.FakturaStavkaId);
            }

            fakturaStavka.Kolicina = vm.Kolicina;
            fakturaStavka.ProizvodID = vm.ProizvodId;
            fakturaStavka.FakturaID = vm.FakturaId;

            db.SaveChanges();
            return Redirect("/AjaxStavke/Index?fakturaId=" + fakturaStavka.FakturaID);
        }
        #endregion


        #region Uredi
        public IActionResult Uredi(int fakturaStavkaId)
        {
            FakturaStavka fakturaStavka = db.FakturaStavka.FirstOrDefault(x => x.Id == fakturaStavkaId);
            List<Proizvod> proizvodi = db.Proizvod.ToList();
            List<SelectListItem> ddProizvodi = new List<SelectListItem>
            {
                new SelectListItem() { Value = string.Empty, Text = "Odaberite proizvod" }
            };

            ddProizvodi.AddRange(proizvodi.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Naziv }));

            AjaxStavkeDodajViewModel vm = new AjaxStavkeDodajViewModel()
            {
                FakturaId = fakturaStavka.FakturaID,
                FakturaStavkaId = fakturaStavkaId,
                Kolicina = fakturaStavka.Kolicina,
                Proizvodi = ddProizvodi,
                ProizvodId = fakturaStavka.ProizvodID
            };

            return PartialView("Dodaj", vm);
        }
        #endregion
    }
}