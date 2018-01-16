using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_Ispit_2017_06_21_v1.EF;
using RS1_Ispit_2017_06_21_v1.Models;
using RS1_Ispit_2017_06_21_v1.ViewModels;

namespace RS1_Ispit_2017_06_21_v1.Controllers
{
    public class AjaxStavkeController : Controller
    {
        #region DI
        private MojContext db;

        public AjaxStavkeController(MojContext db)
        {
            this.db = db;
        }
        #endregion

        #region Index
        public IActionResult Index(int maturskiIspitId)
        {
            AjaxStavkeIndexViewModel vm = new AjaxStavkeIndexViewModel()
            {
                MaturskiIspitId = maturskiIspitId,
                Rows = db.MaturskiIspitStavka.Where(x => x.MaturskiIspitId == maturskiIspitId).Select(x => new AjaxStavkeIndexViewModel.Row()
                {
                    Bodovi = x.Bodovi,
                    MaturskiIspitStavkaId = x.Id,
                    OpciUspjeh = x.UpisUOdjeljenje.OpciUspjeh,
                    Oslobodjen = x.Oslobodjen ? "Da" : "Ne",
                    Ucenik = x.UpisUOdjeljenje.Ucenik.ImePrezime
                }).ToList()
            };

            return PartialView(vm);
        }
        #endregion

        #region Uredi
        public IActionResult Uredi(int maturskiIspitStavkaId)
        {
            MaturskiIspitStavka maturskiIspitStavka = db.MaturskiIspitStavka.Include(x => x.UpisUOdjeljenje).ThenInclude(x => x.Ucenik).FirstOrDefault(x => x.Id == maturskiIspitStavkaId);
            AjaxStavkeUrediViewModel vm = new AjaxStavkeUrediViewModel()
            {
                Bodovi = maturskiIspitStavka.Bodovi,
                MaturskiIspitId = maturskiIspitStavka.MaturskiIspitId,
                MaturskiIspitStavkaId = maturskiIspitStavkaId,
                Ucenik = maturskiIspitStavka.UpisUOdjeljenje.Ucenik.ImePrezime
            };

            return PartialView(vm);
        }
        #endregion

        #region Spremi

        public IActionResult Save(AjaxStavkeUrediViewModel vm)
        {
            MaturskiIspitStavka maturskiIspitStavka = db.MaturskiIspitStavka.FirstOrDefault(x => x.Id == vm.MaturskiIspitStavkaId);
            maturskiIspitStavka.Bodovi = vm.Bodovi;

            db.SaveChanges();
            return Redirect("/AjaxStavke/Index?maturskiIspitId=" + vm.MaturskiIspitId);
        }

        #endregion

        #region SpremiBodove
        public IActionResult SpremiBodove(int maturskiIspitStavkaId, float? bodovi)
        {
            MaturskiIspitStavka maturskiIspitStavka = db.MaturskiIspitStavka.FirstOrDefault(x => x.Id == maturskiIspitStavkaId);
            maturskiIspitStavka.Bodovi = bodovi;

            db.MaturskiIspitStavka.Update(maturskiIspitStavka);

            db.SaveChanges();

            return Redirect("/AjaxStavke/Index?maturskiIspitId=" + maturskiIspitStavka.MaturskiIspitId);
        }
        #endregion

        #region PromijeniStatus
        public IActionResult PromijeniStatus(int maturskiIspitStavkaId)
        {
            MaturskiIspitStavka maturskiIspitStavka = db.MaturskiIspitStavka.FirstOrDefault(x => x.Id == maturskiIspitStavkaId);

            if (maturskiIspitStavka.Oslobodjen)
                maturskiIspitStavka.Oslobodjen = false;
            else
                maturskiIspitStavka.Oslobodjen = true;

            db.MaturskiIspitStavka.Update(maturskiIspitStavka);
            db.SaveChanges();

            return Redirect("/AjaxStavke/Index?maturskiIspitId=" + maturskiIspitStavka.MaturskiIspitId);
        }
        #endregion

    }
}