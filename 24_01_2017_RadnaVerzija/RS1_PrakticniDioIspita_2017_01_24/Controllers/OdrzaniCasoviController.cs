using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_PrakticniDioIspita_2017_01_24.EF;
using RS1_PrakticniDioIspita_2017_01_24.ViewModels;

namespace RS1_PrakticniDioIspita_2017_01_24.Controllers
{
    public class OdrzaniCasoviController : Controller
    {
        #region DI
        private MojContext db;

        public OdrzaniCasoviController(MojContext db)
        {
            this.db = db;
        }

        #endregion

        #region Index
        public IActionResult Index()
        {
            OdrzaniCasoviIndexViewModel vm = new OdrzaniCasoviIndexViewModel()
            {
                Rows = db.OdrzaniCasDetalji.Select(x => new OdrzaniCasoviIndexViewModel.Row()
                {
                    OdrzaniCasDetaljId = x.Id,
                    Datum = x.OdrzaniCas.datum,
                    Odjeljenje = x.UpisUOdjeljenje.Odjeljenje.Oznaka,
                    Predmet = x.OdrzaniCas.Angazovan.Predmet.Naziv
                }).ToList()
            };

            return View(vm);
        }
        #endregion
    }
}