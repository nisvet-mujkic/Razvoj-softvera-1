using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_02_15.EF;
using Ispit_2017_02_15.Models;
using Ispit_2017_02_15.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ispit_2017_02_15.Controllers
{
    public class StudentiController : Controller
    {
        #region DI
        private MojContext db;

        public StudentiController(MojContext db)
        {
            this.db = db;
        }

        #endregion

        #region Index
        public IActionResult Index(int odrzaniCasId)
        {
            StudentiIndexViewModel vm = new StudentiIndexViewModel()
            {
                OdrzaniCasId = odrzaniCasId,
                Rows = db.OdrzaniCasDetalji.Where(x => x.OdrzaniCasId == odrzaniCasId).Select(x => new StudentiIndexViewModel.Row()
                {
                    OdrzaniCasDetaljId = x.Id,
                    Bodovi = x.BodoviNaCasu,
                    Prisutan = x.Prisutan,
                    Student = x.SlusaPredmet.UpisGodine.Student.Ime + " " + x.SlusaPredmet.UpisGodine.Student.Prezime
                }).ToList()
            };

            return PartialView(vm);
        }
        #endregion

        #region StudentJePrisutan
        public IActionResult StudentJePrisutan(int studentId)
        {
            OdrzaniCasDetalji odrzaniCasDetalji = db.OdrzaniCasDetalji.FirstOrDefault(x => x.Id == studentId);
            if (!odrzaniCasDetalji.Prisutan)
                odrzaniCasDetalji.Prisutan = true;

            db.OdrzaniCasDetalji.Update(odrzaniCasDetalji);

            db.SaveChanges();

            return RedirectToAction("Index", "Studenti", new { odrzaniCasId = odrzaniCasDetalji.OdrzaniCasId });
        }
        #endregion

        #region StudentJeOdsutan
        public IActionResult StudentJeOdsutan(int studentId)
        {
            OdrzaniCasDetalji odrzaniCasDetalji = db.OdrzaniCasDetalji.FirstOrDefault(x => x.Id == studentId);
            if (odrzaniCasDetalji.Prisutan)
                odrzaniCasDetalji.Prisutan = false;

            db.OdrzaniCasDetalji.Update(odrzaniCasDetalji);

            db.SaveChanges();

            return RedirectToAction("Index", "Studenti", new { odrzaniCasId = odrzaniCasDetalji.OdrzaniCasId });
        }
        #endregion

        #region Uredi

        public IActionResult Uredi(int studentId)
        {
            StudentiUrediViewModel vm = new StudentiUrediViewModel()
            {
                OdrzaniCasDetalj = db.OdrzaniCasDetalji.Where(x => x.Id == studentId).Select(x => new StudentiUrediViewModel.Detalj() {
                    OdrzaniCasDetaljId = x.Id,
                    OdrzaniCasId = x.OdrzaniCasId,
                    Bodovi = x.BodoviNaCasu,
                    Student = $"{x.SlusaPredmet.UpisGodine.Student.Ime} {x.SlusaPredmet.UpisGodine.Student.Prezime}"
                }).FirstOrDefault()
            };

            return PartialView(vm);
        }

        public IActionResult Save(StudentiUrediViewModel vm)
        {
            OdrzaniCasDetalji odrzaniCasDetalji = db.OdrzaniCasDetalji.FirstOrDefault(x => x.Id == vm.OdrzaniCasDetalj.OdrzaniCasDetaljId);

            odrzaniCasDetalji.BodoviNaCasu = vm.OdrzaniCasDetalj.Bodovi;

            db.OdrzaniCasDetalji.Update(odrzaniCasDetalji);

            db.SaveChanges();
            return RedirectToAction("Index", "Studenti", new { odrzaniCasId = odrzaniCasDetalji.OdrzaniCasId });

        }

        #endregion


    }
}