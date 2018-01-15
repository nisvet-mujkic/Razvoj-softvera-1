using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1_Ispit_2017_06_21_v1.EF;
using RS1_Ispit_2017_06_21_v1.Models;

namespace RS1_Ispit_2017_06_21_v1.Controllers
{
    public class HomeController : Controller
    {
        private MojContext db;

        public HomeController(MojContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult TestDB()
        {
            if (!db.Ucenik.Any())
                MojDBInitializer.Seed(db);
            return View(db);
        }


    }
}
