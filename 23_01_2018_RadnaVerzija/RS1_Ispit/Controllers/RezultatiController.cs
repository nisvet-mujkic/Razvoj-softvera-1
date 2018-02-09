using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Microsoft.AspNetCore.Mvc;
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
                    RezultatPretrageId = x.Id,
                    IzmjerenaVrijednost = x.NumerickaVrijednost,
                    MjernaJedinica = x.LabPretraga.MjernaJedinica,
                    VrstaPretrage = x.LabPretraga.VrstaPretrage.Naziv
                }).ToList()
            };

            return PartialView(vm);
        }
        #endregion

        #region Uredi
        public IActionResult Uredi(int rezultatPretrageId)
        {
            RezultatPretrage rezultatPretrage = db.RezultatPretrage.Find(rezultatPretrageId);



            return View();
        }
        #endregion

        #region Save
        public IActionResult Save()
        {
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}