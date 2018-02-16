using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eUniverzitet.Web.Helper;
using Ispit.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Ispit.Data;
using Ispit.Data.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Web.Controllers
{
    [Autorizacija]
    public class OznaceniDogadajiController : Controller
    {
        
        public IActionResult Index()
        {

         

            return View();
        }

     


    }
}