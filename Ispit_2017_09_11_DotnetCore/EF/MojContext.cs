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


        public DbSet<AkcijskiKatalog> AkcijskiKatalog { get; set; }
        public DbSet<KatalogStavka> KatalogStavka { get; set; }
        public DbSet<Klijent> Klijent { get; set; }
        public DbSet<Ponuda> Ponuda { get; set; }
        public DbSet<PonudaStavka> PonudaStavka { get; set; }
        public DbSet<Proizvod> Proizvod { get; set; }
        public DbSet<Faktura> Faktura { get; set; }
        public DbSet<FakturaStavka> FakturaStavka { get; set; }


    }
}
