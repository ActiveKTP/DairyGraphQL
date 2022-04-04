using DairyGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace DairyGraphQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions option) : base(option)
        {

        }

        public DbSet<Cow>? Cow { get; set; }

        public DbSet<Farm>? Farm { get; set; }

        public DbSet<Staff>? Staff { get; set; }

        public DbSet<Organization>? Organization { get; set; }

        public DbSet<Semen>? Semen { get; set; }

        //public DbSet<Platform>? Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Farm>()
                .HasMany(p => p.Cows)
                .WithOne(p => p.Farm!)
                .HasForeignKey(p => p.cFarmId);

            modelBuilder
                .Entity<Cow>()
                .HasOne(p => p.Farm)
                .WithMany(p => p.Cows)
                .HasForeignKey(p => p.cFarmId);

            modelBuilder
                .Entity<Semen>()
                .HasOne(c => c.Cow)
                .WithMany(c => c.Semens)
                .HasForeignKey(c => c.sSemenId)
                .HasPrincipalKey(c => c.ccowId);
        }
    }
}