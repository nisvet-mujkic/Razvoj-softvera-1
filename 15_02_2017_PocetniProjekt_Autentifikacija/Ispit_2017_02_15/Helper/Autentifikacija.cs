using Ispit_2017_02_15.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_02_15.Helper
{
    public class Autentifikacija
    {
        private IHttpContextAccessor accessor;

        public Autentifikacija(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public static Nastavnik GetLogiraniKorisnik(HttpContext context)
        {
            Nastavnik nastavnik = context.Session.Get<Nastavnik>("user");

            if (nastavnik != null)
                return nastavnik;
            return null;
        }

        public static void SetLogiraniKorisnik(Nastavnik nastavnik, HttpContext context)
        {
            context.Session.Set("user", nastavnik);
        }
    }
}
