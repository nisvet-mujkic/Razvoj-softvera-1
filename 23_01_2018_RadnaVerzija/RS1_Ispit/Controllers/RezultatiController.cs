using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index(int uputnicaId)
        {
            RezultatiIndexViewModel vm = new RezultatiIndexViewModel()
            {
                UputnicaId = uputnicaId,
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
    }
}