using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1_PrakticniDioIspita_2017_01_24.EF;
using RS1_PrakticniDioIspita_2017_01_24.Models;
using RS1_PrakticniDioIspita_2017_01_24.ViewModels;

namespace RS1_PrakticniDioIspita_2017_01_24.Controllers
{
    public class UceniciController : Controller
    {
        #region DI
        private MojContext db;

        public UceniciController(MojContext db)
        {
            this.db = db;
        }
        #endregion
                     

        #region Index
        public IActionResult Index(int odrzaniCasId)
        {


            UceniciIndexViewModel vm = new UceniciIndexViewModel()
            {
                OdrzaniCasId = odrzaniCasId,
                Rows = db.OdrzaniCasDetalj.Where(x => x.OdrzaniCasId == odrzaniCasId).Select(x => new UceniciIndexViewModel.Row()
                {
                    Ocjena = x.Ocjena,
                    OdrzaniCasDetaljId = x.Id,
                    Odsutan = x.Odsutan,
                    OpravdanoOdsutan = x.OpravdanoOdsutan,
                    Ucenik = x.UpisUOdjeljenje.Ucenik.Ime
                }).ToList()
            };
            return PartialView(vm);
        }
        #endregion

        #region Uredi
        public IActionResult Uredi(int id)
        {
            OdrzaniCasDetalj odrzaniCasDetalj = db.OdrzaniCasDetalj.Find(id);

            if(odrzaniCasDetalj.Odsutan)
                return PartialView(odrzaniCasDetalj);
            return PartialView(odrzaniCasDetalj);
        }
        #endregion

    }
}