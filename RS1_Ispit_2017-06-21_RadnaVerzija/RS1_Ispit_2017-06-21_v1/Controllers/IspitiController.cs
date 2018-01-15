using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1_Ispit_2017_06_21_v1.EF;

namespace RS1_Ispit_2017_06_21_v1.Controllers
{
    public class IspitiController : Controller
    {
        #region DI
        private MojContext db;
        public IspitiController(MojContext db)
        {
            this.db = db;
        }
        #endregion


        #region Index
        public IActionResult Index()
        {
            return View();
        }
        #endregion


    }
}