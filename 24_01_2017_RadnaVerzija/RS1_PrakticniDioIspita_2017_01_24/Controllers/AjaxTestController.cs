using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RS1_PrakticniDioIspita_2017_01_24.Controllers
{
    public class AjaxTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxTestAction()
        {
            return PartialView("_AjaxTestView");
        }
    }
}