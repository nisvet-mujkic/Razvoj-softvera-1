using System;
using System.Collections.Generic;
using System.Linq;
using Ispit.Data.EntityModels;

namespace Ispit.Data
{
    public class MojDBInitializer
    {
        public static void Izvrsi(MyContext _context)
        {
            for (int i = 0; i < 20; i++)
            {
                   _context.Add(new Student() { ImePrezime = "Student " + DajRandom , KorisnickiNalog = new KorisnickiNalog{KorisnickoIme = "Student" + i} });
            }
            _context.SaveChanges();


            for (int i = 0; i < 20; i++)
            {
                Nastavnik nastavnik = new Nastavnik { ImePrezime = "Razrednik " + DajRandom, KorisnickiNalog = new KorisnickiNalog { KorisnickoIme = "Razrednik" + i } };
                _context.Add(nastavnik);

                Dogadjaj d = new Dogadjaj { Nastavnik = nastavnik, DatumOdrzavanja = DateTime.Now.AddDays(1), Opis = "Ispit " + DajRandom };
                _context.Add(d);

                for (int j = 0; j < 5; j++)
                {
                    Obaveza o = new Obaveza
                    {
                        Dogadjaj = d,
                        Naziv = "Obaveza " + i,
                        NotifikacijaDanaPrijeDefault = random.Next(1, 4),
                        NotifikacijeRekurizivnoDefault = random.Next(50) % 2 == 0
                    };
                    _context.Add(o);
                }
            }

            _context.SaveChanges();

        }

        private static string DajRandom
        {
            get { return Guid.NewGuid().ToString().Substring(0, 3); }
        }

        static Random random = new Random();
     
    }
}
