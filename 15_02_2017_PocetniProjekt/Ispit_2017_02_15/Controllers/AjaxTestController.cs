using Microsoft.AspNetCore.Mvc;

namespace Ispit_2017_02_15.Controllers
{
    public class AjaxTestController : Controller
    {
        // GET: AjaxTest
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxTestAction()
        {
            return View("_AjaxTestView");
        }
    }
}