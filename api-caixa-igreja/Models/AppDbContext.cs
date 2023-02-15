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
                new Cargos { Id = 4, Nome = "Levita", Descricao = "Pessoa Obreita integrante do ministerio de louvor" });

            builder.Entity<Membros>()
                .HasData(
                    new Membros { Id = 1, CargoId = 1, DataNascimento = DateTime.Parse("1995-06-05"), Nome = "Rodolfo Jesus Silva", DataBatismo = DateTime.Parse("2010-08-07") },
                    new Membros { Id = 2, CargoId = 2, DataNascimento = DateTime.Parse("1993-06-08"), Nome = "Kelly Cristina Martins", DataBatismo = DateTime.Parse("2008-05-01") },
                    new Membros { Id = 3, CargoId = 3, DataNascimento = DateTime.Parse("2006-02-06"), Nome = "Gustavo de Jesus Silva" },
                    new Membros { Id = 4, CargoId = 4, DataNascimento = DateTime.Parse("2000-01-06"), Nome = "Casy Martins da Silva" },
                    new Membros { Id = 5, CargoId = 4, DataNascimento = DateTime.Parse("1974-11-15"), Nome = "André Martinele Alves"});

            builder.Entity<TipoCulto>()
                .HasData(
                new TipoCulto { Id = 1, Nome = "Santa Ceia", Descricao = "Último domingo de cada mês. Ceia do Senhor para batizados nas águas." },
                new TipoCulto { Id = 2, Nome = "Centésima ovelha", Descricao = "No 4º domingo do mês quando há 5 domingos no mês." },
                new TipoCulto { Id = 3, Nome = "Missões", Descricao = "3º Domingo do mês. Ofertas destinadas para missão não ficam no caixa da igreja" },
                new TipoCulto { Id = 4, Nome = "Properidade", Descricao = "2º Domingo. Geralmente nesse dia são devolvidos Dizimos e primicias" },
                new TipoCulto { Id = 5, Nome = "Poder", Descricao = "1º Domingo do mês. Culto para batismo e renovo do espirito santo" },
                new TipoCulto { Id = 6, Nome = "Graça", Descricao = "Todos os dias de semana. Seg a Sex" });

            builder.Entity<TipoOfertas>()
                .HasData(
                new TipoOfertas { Id = 1, Nome = "Cédulas C.", Descricao = "Dinheiro em especie no culto." },
                new TipoOfertas { Id = 2, Nome = "Cédulas F.", Descricao = "Dinheiro em especia fora do culto" },
                new TipoOfertas { Id = 3, Nome = "Transferência", Descricao = "Transferencia de conta. (TED, DOC, PIX)" },
                new TipoOfertas { Id = 4, Nome = "Cheques", Descricao = "Cheques fora do culto" },
                new TipoOfertas { Id = 5, Nome = "Cartão", Descricao = "Feito com cartão crédito/debito" });

            builder.Entity<Ofertas>()
                .HasData(
                new Ofertas
                {
                    Id= 1, IdMembroMinistrante = 1, IdTipoCulto = 1, IdTipoOferta = 1, QtdAdultos = 26, QtdCriancas = 5, Dia = DateTime.Parse("2022-06-01"), totalOferta = 550.25
                });

            builder.Entity<Primicias>()
                .HasData(
                new Primicias { Id= 1, Dia = DateTime.Parse("2022-07-17"), IdMembro = 1, Periodo="07/2021", IdTipoOferta=1, Valor = 400.65 },
                new Primicias { Id= 2, Dia = DateTime.Parse("2022-07-15"), IdMembro = 2, Periodo="06/2021", IdTipoOferta=2, Valor = 150.80 }
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

            builder.Entity<Dizimos>()
                .HasOne(dizimo => dizimo.MembroDizimista)
                .WithMany(membro => membro.DizimosDevolvidos)
                .HasForeignKey(dizimo => dizimo.IdMembroDizimista)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Primicias>()
                .HasOne(primicias => primicias.Membro)
                .WithMany(membro => membro.PrimiciasOfertadas)
                .HasForeignKey(primicias => primicias.IdMembro)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Primicias>()
                .HasOne(primicias => primicias.TipoOferta)
                .WithMany(tipoOferta => tipoOferta.PrimiciasOfertadas)
                .HasForeignKey(primicias => primicias.IdTipoOferta)
                .OnDelete(DeleteBehavior.NoAction);

            InicializarModels(builder);
        }

        public DbSet<Cargos> Cargos { get; set; }
        public DbSet<Membros> Membros { get; set; }
        public DbSet<TipoOfertas> TipoOferta { get; set; }
        public DbSet<TipoCulto> TipoCulto { get; set; }
        public DbSet<Ofertas> Ofertas { get; set; }
        public DbSet<Dizimos> Dizimos { get; set; }
        public DbSet<Primicias> Primicias { get; set; }

    }
}
