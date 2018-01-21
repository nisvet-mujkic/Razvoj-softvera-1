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
    public class OdjeljenjeStavkeController : Controller
    {
        #region DI
        private MojContext db;

        public OdjeljenjeStavkeController(MojContext db)
        {
            this.db = db;
        }
        #endregion

        #region Index
        public IActionResult Index(int id)
        {
            OdjeljenjeStavkeIndexViewModel vm = new OdjeljenjeStavkeIndexViewModel()
            {
                OdjeljenjeId = id,
                Rows = db.OdjeljenjeStavka.Where(x => x.OdjeljenjeId == id).Select(x => new OdjeljenjeStavkeIndexViewModel.Row()
                {
                    BrojUDnevniku = x.BrojUDnevniku,
                    OdjeljenjeStavkaId = x.Id,
                    Ucenik = x.Ucenik.ImePrezime,
                    BrojZakljucenihOcjena = db.DodjeljenPredmet.Where(k => k.OdjeljenjeStavkaId == x.Id).Count(k => k.ZakljucnoKrajGodine != 0)
                }).OrderBy(x => x.BrojUDnevniku).ToList()
            };
            return PartialView(vm);
        }
        #endregion

        #region Add
        public IActionResult Add(int id)
        {
            List<Ucenik> ucenici = db.Ucenik.ToList();
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Value = string.Empty, Text = "Odaberite ucenika"}
            };
            list.AddRange(ucenici.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.ImePrezime }));

            OdjeljenjeStavkaAddViewModel vm = new OdjeljenjeStavkaAddViewModel()
            {
                OdjeljenjeId = id,
                OdjeljenjeStavka = new OdjeljenjeStavka(),
                Ucenici = list
            };
            return PartialView(vm);
        }

     

        public IActionResult Save(OdjeljenjeStavkaAddViewModel vm)
        {
            OdjeljenjeStavka odjeljenjeStavka = vm.OdjeljenjeStavka;
            odjeljenjeStavka.OdjeljenjeId = vm.OdjeljenjeId;
            db.OdjeljenjeStavka.Add(odjeljenjeStavka);

            db.SaveChanges();
            return RedirectToAction("Index", "OdjeljenjeStavke", new {id = vm.OdjeljenjeStavka.OdjeljenjeId});
        }

        #endregion

        #region Edit
        public IActionResult Edit(int id)
        {
            List<Ucenik> ucenici = db.Ucenik.ToList();
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Value = string.Empty, Text = "Odaberite ucenika"}
            };
            list.AddRange(ucenici.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.ImePrezime }));

            OdjeljenjeStavka odjeljenjeStavka = db.OdjeljenjeStavka.FirstOrDefault(x => x.Id == id);

            OdjeljenjeStavkaAddViewModel vm = new OdjeljenjeStavkaAddViewModel()
            {
                OdjeljenjeId = odjeljenjeStavka.OdjeljenjeId,
                OdjeljenjeStavka = odjeljenjeStavka,
                Ucenici = list
            };

            return PartialView(vm);
        }

        [HttpPost]
        public IActionResult Edit(OdjeljenjeStavkaAddViewModel vm)
        {
            OdjeljenjeStavka odjeljenjeStavka = vm.OdjeljenjeStavka;
            odjeljenjeStavka.OdjeljenjeId = vm.OdjeljenjeId;
            db.OdjeljenjeStavka.Update(odjeljenjeStavka);

            db.SaveChanges();
            return RedirectToAction("Index", "OdjeljenjeStavke", new { id = vm.OdjeljenjeStavka.OdjeljenjeId });
        }
        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            OdjeljenjeStavka odjeljenjeStavka = db.OdjeljenjeStavka.Find(id);
            int odjeljenjeId = odjeljenjeStavka.OdjeljenjeId;
            db.OdjeljenjeStavka.Remove(odjeljenjeStavka);

            db.SaveChanges();
            return RedirectToAction("Index", "OdjeljenjeStavke", new { id = odjeljenjeId });
        }

        #endregion

        #region reGenerateNumbers

        public IActionResult GenerateNumbers(int id)
        {
            List<OdjeljenjeStavka> lista = db.OdjeljenjeStavka.Include(x => x.Ucenik).Where(x => x.OdjeljenjeId == id).OrderBy(x => x.Ucenik.ImePrezime).ToList();
            int brojac = 1;
            foreach (var item in lista)
            {
                item.BrojUDnevniku = brojac;
                db.OdjeljenjeStavka.Update(item);

                brojac++;
            }

            db.SaveChanges();
            return RedirectToAction("Index", "OdjeljenjeStavke", new { id });
        }

        #endregion

    }
}