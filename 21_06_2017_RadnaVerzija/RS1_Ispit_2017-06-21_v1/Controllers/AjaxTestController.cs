using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RS1_Ispit_2017_06_21_v1.Controllers
{
    public class AjaxTestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxTestAction()
        {
            return PartialView("_AjaxTestView");
        }
    }
}