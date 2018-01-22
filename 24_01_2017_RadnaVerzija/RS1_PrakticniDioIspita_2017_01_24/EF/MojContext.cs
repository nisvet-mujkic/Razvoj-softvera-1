using Microsoft.EntityFrameworkCore;
using RS1_PrakticniDioIspita_2017_01_24.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_PrakticniDioIspita_2017_01_24.EF
{
    public class MojContext: DbContext
    {
        public MojContext(DbContextOptions<MojContext> options): base(options)
        {

        }

        public DbSet<Nastavnik> Nastavnik { get; set; }
        public DbSet<Predmet> Predmet { get; set; }
        public DbSet<Odjeljenje> Odjeljenje { get; set; }
        public DbSet<UpisUOdjeljenje> UpisUOdjeljenje { get; set; }
        public DbSet<Ucenik> Ucenik { get; set; }
        public DbSet<OdrzaniCas> OdrzaniCas { get; set; }
        public DbSet<OdrzaniCasDetalj> OdrzaniCasDetalj { get; set; }
        public DbSet<Angazovan> Angazovan { get; set; }

    }
}
