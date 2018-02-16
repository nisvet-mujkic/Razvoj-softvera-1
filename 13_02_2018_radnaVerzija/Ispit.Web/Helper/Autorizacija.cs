using System.Threading.Tasks;
using eUniverzitet.Web.Helper;
using Ispit.Data.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ispit.Web.Helper
{

    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute()
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] {  };
        }
    }


    public class MyAuthorizeImpl : IAsyncActionFilter
    {
        public MyAuthorizeImpl()
        {
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            KorisnickiNalog k = filterContext.HttpContext.GetLogiraniKorisnik();

            if (k == null)
            {
                if (filterContext.Controller is Controller controller)
                {
                    controller.TempData["error_poruka"] = "Niste logirani";
                }

                filterContext.Result = new RedirectToActionResult("Index", "Autentifikacija", new { @area = "" });
                return;
            }

                await next(); //ok - ima pravo pristupa
           
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // throw new NotImplementedException();
        }
    }
}

