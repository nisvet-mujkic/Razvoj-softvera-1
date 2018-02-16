using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ispit.Data;
using Ispit.Data.EntityModels;
using Ispit.Web.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace eUniverzitet.Web.Helper
{
    public static class Autentifikacija
    {
        private const string LogiraniKorisnik = "logirani_korisnik";

        public static void SetLogiraniKorisnik(this HttpContext context, KorisnickiNalog korisnik, bool snimiUCookie=false)
        {

            MyContext db = context.RequestServices.GetService<MyContext>();

            string stariToken = context.Request.GetCookieJson<string>(LogiraniKorisnik);
            if (stariToken != null)
            {
                AutorizacijskiToken obrisati = db.AutorizacijskiToken.FirstOrDefault(x => x.Vrijednost == stariToken);
                if (obrisati != null)
                {
                    db.AutorizacijskiToken.Remove(obrisati);
                    db.SaveChanges();
                }
            }

            if (korisnik != null)
            {

                string token = Guid.NewGuid().ToString();
                db.AutorizacijskiToken.Add(new AutorizacijskiToken
                {
                    Vrijednost = token,
                    KorisnickiNalogId = korisnik.Id,
                    VrijemeEvidentiranja = DateTime.Now
                });
                db.SaveChanges();
                context.Response.SetCookieJson(LogiraniKorisnik, token);
            }
        }

        public static string GetTrenutniToken(this HttpContext context)
        {
            return context.Request.GetCookieJson<string>(LogiraniKorisnik);
        }

        public static KorisnickiNalog GetLogiraniKorisnik(this HttpContext context)
        {
            MyContext db = context.RequestServices.GetService<MyContext>();

            string token = context.Request.GetCookieJson<string>(LogiraniKorisnik);
            if (token == null)
                return null;

            return db.AutorizacijskiToken
                .Where(x => x.Vrijednost == token)
                .Select(s => s.KorisnickiNalog)
                .SingleOrDefault();

        }

    }
}