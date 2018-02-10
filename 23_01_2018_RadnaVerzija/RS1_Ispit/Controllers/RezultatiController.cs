using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1.Ispit.Web.Models;
using RS1_Ispit_asp.net_core.ViewModels;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class RezultatiController : Controller
    {
        #region DI
        private MojContext db;

        public RezultatiController(MojContext db)
        {
            this.db = db;
        }

        #endregion       

        #region Index
        public IActionResult Index(int uputnicaId)
        {
            Uputnica uputnica = db.Uputnica.Find(uputnicaId);
            RezultatiIndexViewModel vm = new RezultatiIndexViewModel()
            {
                UputnicaId = uputnicaId,
                IsGotovNalaz = uputnica.IsGotovNalaz,
                Rows = db.RezultatPretrage.Where(x => x.UputnicaId == uputnicaId).Select(x => new RezultatiIndexViewModel.Row()
                {
                    ModalitetId = x.ModalitetId,
                    LabPretragaId = x.LabPretragaId,
                    RezultatPretrageId = x.Id,
                    IzmjerenaVrijednost = x.NumerickaVrijednost,
                    MjernaJedinica = x.LabPretraga.MjernaJedinica,
                    VrstaPretrage = x.LabPretraga.Naziv,
                    VrstaVrijednosti = x.LabPretraga.VrstaVr,
                    Modalitet = x.Modalitet.Opis,
                    ReferentnaVrijednostMax = x.LabPretraga.ReferentnaVrijednostMax,
                    ReferentnaVrijednostMin = x.LabPretraga.ReferentnaVrijednostMin,
                    IsReferentnaNumericka = x.LabPretraga.VrstaVr == VrstaVrijednosti.NumerickaVrijednost && x.NumerickaVrijednost >= x.LabPretraga.ReferentnaVrijednostMin
                                                      && x.NumerickaVrijednost <= x.LabPretraga.ReferentnaVrijednostMax
                                                      ? true
                                                      : false,
                    IsReferentnaModalitet = x.LabPretraga.VrstaVr == VrstaVrijednosti.Modalitet && x.Modalitet.IsReferentnaVrijednost
                                            ? true
                                            : false,
                    ReferentniModaliteti = string.Join(", ", db.Modalitet.Where(k => k.LabPretragaId == x.LabPretragaId && k.IsReferentnaVrijednost).Select(k => k.Opis).ToList())
                }).ToList()
            };

            // GenerateSelectListOfModalitets je funkcije koja sluzi za kreiranje padajuce liste za odgovarajucu lab pretragu,
            // funkcija je definisana u regionu Helpers
            foreach (var x in vm.Rows)
                x.Modaliteti = GenerateSelectListOfModalitets(x.LabPretragaId);

            return PartialView(vm);
        }
        #endregion

        #region Uredi
        public IActionResult Uredi(int rezultatPretrageId)
        {
            RezultatPretrage rezultatPretrage = db.RezultatPretrage.Include(x => x.LabPretraga).Where(x => x.Id == rezultatPretrageId).FirstOrDefault();

            List<Modalitet> dbModaliteti = db.Modalitet.Where(x => x.LabPretragaId == rezultatPretrage.LabPretragaId).ToList();
            List<SelectListItem> ddModalitet = new List<SelectListItem>()
                {
                    new SelectListItem(){Value = string.Empty, Text = "Odaberite modalitet:"}
                };
            ddModalitet.AddRange(dbModaliteti.Select(x => new SelectListItem() { Text = x.Opis, Value = x.Id.ToString() }));

            RezultatiUrediViewModel vm = new RezultatiUrediViewModel()
            {
                VrstaVrijednosti = rezultatPretrage.NumerickaVrijednost != null ? VrstaVrijednosti.NumerickaVrijednost : VrstaVrijednosti.Modalitet,
                RezultatPretrageId = rezultatPretrageId,
                Pretraga = rezultatPretrage.LabPretraga.Naziv
            };

            if (vm.VrstaVrijednosti == VrstaVrijednosti.NumerickaVrijednost)
            {
                vm.Numericka = db.RezultatPretrage.Where(x => x.Id == rezultatPretrageId).Select(x => new RezultatiUrediViewModel.RezultatUrediNumericka()
                {
                    MjernaJedinica = x.LabPretraga.MjernaJedinica,
                    NumerickaVrijednost = x.NumerickaVrijednost
                }).FirstOrDefault();
            }
            else
            {
                vm.Modalitet = db.RezultatPretrage.Where(x => x.Id == rezultatPretrageId).Select(x => new RezultatiUrediViewModel.RezultatUrediModalitet()
                {
                    ModalitetId = x.ModalitetId,
                    Modaliteti = ddModalitet
                }).FirstOrDefault();
            }

            return PartialView(vm);
        }
        #endregion

        #region Save
        public IActionResult Save(RezultatiUrediViewModel vm)
        {
            RezultatPretrage rezultatPretrage = db.RezultatPretrage.Find(vm.RezultatPretrageId);

            if (vm.VrstaVrijednosti == VrstaVrijednosti.NumerickaVrijednost)
                rezultatPretrage.NumerickaVrijednost = vm.Numericka.NumerickaVrijednost;
            else
                rezultatPretrage.ModalitetId = vm.Modalitet.ModalitetId;

            db.RezultatPretrage.Update(rezultatPretrage);
            db.SaveChanges();

            return RedirectToAction(nameof(Index), new { uputnicaId = rezultatPretrage.UputnicaId });
        }
        #endregion

        #region InRowChange
        public IActionResult InRowChange(int rezultatPretrageId, string vrstaVrijednosti, double? numerickaVrijednost, int? modalitetId)
        {
            RezultatPretrage rezultatPretrage = db.RezultatPretrage.Find(rezultatPretrageId);

            if (vrstaVrijednosti == "num")
                rezultatPretrage.NumerickaVrijednost = numerickaVrijednost;
            else
                rezultatPretrage.ModalitetId = modalitetId;

            db.RezultatPretrage.Update(rezultatPretrage);
            db.SaveChanges();
            return RedirectToAction(nameof(Index), new { uputnicaId = rezultatPretrage.UputnicaId });
        }
        #endregion

        #region Helpers
        private List<SelectListItem> GenerateSelectListOfModalitets(int labPretragaId)
        {
            List<Modalitet> dbModaliteti = db.Modalitet.Where(x => x.LabPretragaId == labPretragaId).ToList();
            List<SelectListItem> ddModalitet = new List<SelectListItem>()
                {
                    new SelectListItem(){Value = string.Empty, Text = "Odaberite modalitet:"}
                };
            ddModalitet.AddRange(dbModaliteti.Select(x => new SelectListItem() { Text = x.Opis, Value = x.Id.ToString() }));

            return ddModalitet;
        }
        #endregion
    }
}