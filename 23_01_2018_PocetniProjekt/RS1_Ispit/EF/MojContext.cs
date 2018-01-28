using Microsoft.EntityFrameworkCore;
using RS1.Ispit.Web.Models;

namespace Ispit_2017_09_11_DotnetCore.EF
{
    public class MojContext : DbContext
    {
        public MojContext(DbContextOptions<MojContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RezultatPretrage>().HasOne(x => x.Uputnica)
                .WithMany().OnDelete(DeleteBehavior.Restrict);

        }

        public DbSet<VrstaPretrage> VrstaPretrage { get; set; }
        public DbSet<Ljekar> Ljekar { get; set; }
        public DbSet<Pacijent> Pacijent { get; set; }
        public DbSet<RezultatPretrage> RezultatPretrage { get; set; }
        public DbSet<Uputnica> Uputnica { get; set; }
        public DbSet<LabPretraga> LabPretraga { get; set; }
        public DbSet<Modalitet> Modalitet { get; set; }
    }
}
