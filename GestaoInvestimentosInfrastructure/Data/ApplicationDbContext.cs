using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GestaoInvestimentosInfrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext() { }

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_configuration != null)
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            else
                optionsBuilder.UseInMemoryDatabase("TestDatabaseInMemory");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            InsertData(modelBuilder);
        }

        private void InsertData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario(1, "Demetrios Pandelis Arghirachis", "rm352321@fiap.com.br", "1q2w3e4r@#"),
                new Usuario(2, "Erick Felipe Vieira da Silva", "rm351017@fiap.com.br", "1q2w3e4r@#"),
                new Usuario(1, "MARINA SANT'ANA MIRANDA DE OLIVEIRA", "rm352116@fiap.com.br", "1q2w3e4r@#"),
                new Usuario(2, "Pamela Suellen Souza Caffa", "rm352127@fiap.com.br", "1q2w3e4r@#")
                );

            modelBuilder.Entity<Ativo>().HasData(
                new Ativo(1, TipoAtivo.Acao, "Nome Ativo 1", "ATV01"),
                new Ativo(2, TipoAtivo.Titulo, "Nome Ativo 2", "ATV02"),
                new Ativo(3, TipoAtivo.Criptomoeda, "Nome Ativo 3", "ATV03"),
                new Ativo(4, TipoAtivo.Titulo, "Nome Ativo 4", "ATV04")
                );

            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio(1, 1, "Portfolio Demetrios", "Descricao Portfolio"),
                new Portfolio(2, 2, "Portfolio Erick", "Descricao Portfolio"),
                new Portfolio(1, 1, "Portfolio MARINA", "Descricao Portfolio"),
                new Portfolio(2, 2, "Portfolio Pamela", "Descricao Portfolio")
                );

            modelBuilder.Entity<Transacao>().HasData(
                new Transacao(1, 1, 1, TipoTransacao.Compra, 10, 150, DateTime.Now),
                new Transacao(2, 1, 2, TipoTransacao.Venda, 20, 300, DateTime.Now),
                new Transacao(3, 1, 3, TipoTransacao.Compra, 50, 600, DateTime.Now),
                new Transacao(4, 1, 4, TipoTransacao.Venda, 90, 900, DateTime.Now),
                new Transacao(1, 2, 1, TipoTransacao.Compra, 10, 150, DateTime.Now),
                new Transacao(2, 2, 2, TipoTransacao.Venda, 20, 300, DateTime.Now),
                new Transacao(3, 2, 3, TipoTransacao.Compra, 50, 600, DateTime.Now),
                new Transacao(4, 2, 4, TipoTransacao.Venda, 90, 900, DateTime.Now),
                new Transacao(1, 3, 1, TipoTransacao.Compra, 10, 150, DateTime.Now),
                new Transacao(2, 3, 2, TipoTransacao.Venda, 20, 300, DateTime.Now),
                new Transacao(3, 3, 3, TipoTransacao.Compra, 50, 600, DateTime.Now),
                new Transacao(4, 3, 4, TipoTransacao.Venda, 90, 900, DateTime.Now),
                new Transacao(1, 4, 1, TipoTransacao.Compra, 10, 150, DateTime.Now),
                new Transacao(2, 4, 2, TipoTransacao.Venda, 20, 300, DateTime.Now),
                new Transacao(3, 4, 3, TipoTransacao.Compra, 50, 600, DateTime.Now),
                new Transacao(4, 4, 4, TipoTransacao.Venda, 90, 900, DateTime.Now)
                );
        }
    }
}
