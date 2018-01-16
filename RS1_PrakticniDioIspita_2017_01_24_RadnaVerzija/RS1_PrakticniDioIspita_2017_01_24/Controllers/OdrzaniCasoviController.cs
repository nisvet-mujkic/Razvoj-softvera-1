using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
                    OdrzaniCasDetaljiId = x.Id,
                    Datum = x.OdrzaniCas.datum.ToShortDateString(),
                    Ocjena = x.Ocjena,
                    Odjeljenje = x.OdrzaniCas.Angazovan.Odjeljenje.Oznaka,
                    OpravdanoOdsutan = x.OpravdanoOdsutan.Value,
                    Odsutan = x.Odsutan,
                    Predmet = x.OdrzaniCas.Angazovan.Predmet.Naziv,
                    UkupnoUcenika = db.OdrzaniCasDetalji.Where(k => k.OdrzaniCasId == x.OdrzaniCasId).Count(),
                    UkupnoPrisutnih = db.OdrzaniCasDetalji.Count(k => k.OdrzaniCasId == x.OdrzaniCasId && !k.Odsutan)
                }).ToList()
            };

            return View(vm);
        }
        #endregion
    }
}