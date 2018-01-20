using Ispit_2017_09_11_DotnetCore.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Ispit_2017_09_11_DotnetCore.EF
{
    public class MojContext : DbContext
    {
        public MojContext(DbContextOptions<MojContext> options)
            : base(options)
        {
        }
     

        public DbSet<Predmet> Predmet { get; set; }
        public DbSet<DodjeljenPredmet> DodjeljenPredmet { get; set; }
        public DbSet<Ucenik> Ucenik { get; set; }
        public DbSet<OdjeljenjeStavka> OdjeljenjeStavka { get; set; }
        public DbSet<Odjeljenje> Odjeljenje { get; set; }
        public DbSet<Nastavnik> Nastavnik { get; set; }
    }
}
