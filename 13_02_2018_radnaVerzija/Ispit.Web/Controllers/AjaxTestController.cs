using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ispit_2017_09_11_DotnetCore.Controllers
{
    public class AjaxTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AjaxTestAction()
        {
            return PartialView("_AjaxTestView");
        }
    }
}