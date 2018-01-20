using System;
using System.Collections.Generic;
using System.Linq;
using Ispit_2017_09_11_DotnetCore.EntityModels;

namespace Ispit_2017_09_11_DotnetCore.EF
{
    public  class MojDBInitializer
    {
        public static void Izvrsi(MojContext _context)
        {
            // Look for any students.
            if (_context.Ucenik.Any())
            {
                return;   // DB has been seeded
            }

            var ucenici = new List<Ucenik>();
            var predmeti = new List<Predmet>();
            var odjeljenja = new List<Odjeljenje>();

            for (int i = 0; i < 120; i++)
            {
                ucenici.Add(new Ucenik{ImePrezime = "Učenik " + Guid.NewGuid().ToString().Substring(0,3)});
            }
            for (int i = 0; i < 48; i++)
            {
                predmeti.Add(new Predmet { Naziv = "Predmet " + Guid.NewGuid().ToString().Substring(0, 3), Razred = i%4});
            }

            for (int i = 1; i <= 4; i++)
            {
                odjeljenja.Add(new Odjeljenje() {SkolskaGodina = "2015/16",Oznaka = i+"-a", Razred = i});
                odjeljenja.Add(new Odjeljenje() {SkolskaGodina = "2015/16",Oznaka = i+"-b", Razred = i});
            }
            int b = 0;
          
            foreach (Ucenik x in ucenici)
            {
               
                Odjeljenje o = odjeljenja[b % odjeljenja.Count];
                b++;
                var s = new OdjeljenjeStavka() {BrojUDnevniku = 0, Odjeljenje = o, Ucenik = x,};
                _context.OdjeljenjeStavka.Add(s);
                foreach (Predmet p in predmeti.Where(w=>w.Razred==o.Razred))
                {
                    _context.DodjeljenPredmet.Add(new DodjeljenPredmet()
                    {
                        OdjeljenjeStavka = s,
                        Predmet = p,
                        ZakljucnoPolugodiste = dajOcjenu(),
                        ZakljucnoKrajGodine = dajOcjenu()
                    });
                }
            }
            
            _context.SaveChanges();
        }
        static Random random = new Random();
        private static int dajOcjenu()
        {
            int x  =random.Next(1, 20);
            if (x > 1)
                x = x%4+2;
            return x;
        }
    }
}
