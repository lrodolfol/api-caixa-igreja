using api_caixa_igreja.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace api_caixa_igreja.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        private void InicializarModels(ModelBuilder builder)
        {
            builder.Entity<Cargos>()
                .HasData(
                new Cargos { Id = 1, Nome = "Membro", Descricao = "Pessoa com ficha de membro frequente aos cultos" },
                new Cargos { Id = 2, Nome = "Obreiro", Descricao = "Pessoa Membra com responsabilidades na obra" },
                new Cargos { Id = 3, Nome = "Diacono", Descricao = "Pessoa auxiliadora do ministerio diaconal" },
                new Cargos { Id = 4, Nome = "Levita", Descricao = "Pessoa Obreita integrante do ministerio de louvor" }
                );

            builder.Entity<Membros>()
                .HasData(
                    new Membros { Id = 1, CargoId = 1, DataNascimento = DateTime.Parse("1995-06-05"), Nome = "Rodolfo Jesus Silva" },
                    new Membros { Id = 2, CargoId = 2, DataNascimento = DateTime.Parse("1993-06-08"), Nome = "Kelly Cristina Martins" },
                    new Membros { Id = 3, CargoId = 3, DataNascimento = DateTime.Parse("2006-02-06"), Nome = "Gustavo de Jesus Silva" },
                    new Membros { Id = 4, CargoId = 4, DataNascimento = DateTime.Parse("2000-01-06"), Nome = "Casy Martins da Silva" }
                );

            builder.Entity<TipoCulto>()
                .HasData(
                new TipoCulto { Id = 1, Nome = "Santa Ceia", Descricao = "Último domingo de cada mês. Ceia do Senhor para batizados nas águas." },
                new TipoCulto { Id = 2, Nome = "Centésima ovelha", Descricao = "No 4º domingo do mês quando há 5 domingos no mês." },
                new TipoCulto { Id = 3, Nome = "Missões", Descricao = "3º Domingo do mês. Ofertas destinadas para missão não ficam no caixa da igreja" },
                new TipoCulto { Id = 4, Nome = "Properidade", Descricao = "2º Domingo. Geralmente nesse dia são devolvidos Dizimos e primicias" },
                new TipoCulto { Id = 5, Nome = "Poder", Descricao = "1º Domingo do mês. Culto para batismo e renovo do espirito santo" },
                new TipoCulto { Id = 6, Nome = "Graça", Descricao = "Todos os dias de semana. Seg a Sex" }
                );

            builder.Entity<TipoOferta>()
                .HasData(
                new TipoOferta { Id = 1, Nome = "Cédulas C.", Descricao = "Dinheiro em especie no culto." },
                new TipoOferta { Id = 2, Nome = "Cédulas F.", Descricao = "Dinheiro em especia fora do culto" },
                new TipoOferta { Id = 3, Nome = "Transferência", Descricao = "Transferencia de conta. (TED, DOC, PIX)" },
                new TipoOferta { Id = 4, Nome = "Cheques", Descricao = "Cheques fora do culto" },
                new TipoOferta { Id = 5, Nome = "Cartão", Descricao = "Feito com cartão crédito/debito" }
                );
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Membros>()
            .HasOne(membros => membros.Cargo)
            .WithMany(cargo => cargo.Membros)
            .HasForeignKey(membro => membro.CargoId)
            .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Ofertas>()
                .HasOne(oferta => oferta.MembroMinistrante)
                .WithMany(membro => membro.OfertasMinistradas)
                .HasForeignKey(oferta => oferta.IdMembroMinistrante)
                .OnDelete(DeleteBehavior.NoAction);

            /*
            builder.Entity<Ofertas>()
                .HasOne(ofertas => ofertas.MembroOfertante)
                .WithMany(membro => membro.OfertasRealizadas)
                .HasForeignKey(oferta => oferta.IdMembroOfertante)
                .OnDelete(DeleteBehavior.NoAction);*/

            builder.Entity<Ofertas>()
                .HasOne(ofertas => ofertas.TipoCulto)
                .WithMany(tipoCulto => tipoCulto.OfertasAlcadas)
                .HasForeignKey(oferta => oferta.IdTipoCulto)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Ofertas>()
                .HasOne(ofertas => ofertas.TipoOferta)
                .WithMany(tipoOferta => tipoOferta.OfertasAlcadas)
                .HasForeignKey(oferta => oferta.IdTipoOferta)
                .OnDelete(DeleteBehavior.NoAction);

            InicializarModels(builder);
        }

        public DbSet<Cargos> Cargos { get; set; }
        public DbSet<Membros> Membros { get; set; }
        public DbSet<TipoOferta> TipoOferta { get; set; }
        public DbSet<TipoCulto> TipoCulto { get; set; }
        public DbSet<Ofertas> Ofertas { get; set; }

    }
}
