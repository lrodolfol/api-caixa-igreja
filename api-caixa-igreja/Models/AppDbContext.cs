using api_caixa_igreja.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_caixa_igreja.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Membros>()
            .HasOne(membros => membros.Cargo)
            .WithMany(cargo => cargo.Membros)
            .HasForeignKey(membro => membro.CargoId);
        }


        public DbSet<Cargos> Cargos { get; set; }
        public DbSet<Membros> Membros { get; set; }

    }
}
