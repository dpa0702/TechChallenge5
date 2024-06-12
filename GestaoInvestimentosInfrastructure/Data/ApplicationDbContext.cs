using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace GestaoInvestimentosInfrastructure.Data
{
    [ExcludeFromCodeCoverage]
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext() {
            //var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Investimentos;User ID=sa;Password=1q2w3e4r@#;Trusted_Connection=False; TrustServerCertificate=True;");
        }

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
            //optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Investimentos;User ID=sa;Password=1q2w3e4r@#;Trusted_Connection=False; TrustServerCertificate=True;");
            //optionsBuilder.UseInMemoryDatabase("TestDatabaseInMemory");
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
            //Senha padrão: 1q2w3e4r@#
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario() { Id = 1, Nome = "Demetrios Pandelis Arghirachis", Email = "rm352321@fiap.com.br", Senha = "AEA45ZjxGEaVS/nMOv6iLh+yXq+nLo3RhngEN88IadBPn6GtcKREtLJVX0ezE4TBTw==" },
                new Usuario() { Id = 2, Nome = "Erick Felipe Vieira da Silva", Email = "rm351017@fiap.com.br", Senha = "AL3kMTAV6y4Ty9M5yq6EmDqWfCAoPf0Anz2xqLuIzTD0PvpHGQYEingUa7Je5DoBiw==" },
                new Usuario() { Id = 3, Nome = "MARINA SANT'ANA MIRANDA DE OLIVEIRA", Email = "rm352116@fiap.com.br", Senha = "AO/R/7ijuoYCcg6qrYpUjyUEbAjZlYmg/6Fh9WNxsFmcGpN20Aq4Ab4sNbpunAFLZg==" },
                new Usuario() { Id = 4, Nome = "Pamela Suellen Souza Caffa", Email = "rm352127@fiap.com.br", Senha = "AO02lkhYnwlszcuSRTEpPO86qR6WESIaET7WEbCv2VghefI7F8/7xTt49CaNIYQhQg==" }
                );

            modelBuilder.Entity<Ativo>().HasData(
                new Ativo() { Id = 1, TipoAtivo = TipoAtivo.Acao, Nome = "Nome Ativo Acao 001", Codigo = "NAA001" },
                new Ativo() { Id = 2, TipoAtivo = TipoAtivo.Titulo, Nome = "Nome Ativo Titulo 001", Codigo = "NAT001" },
                new Ativo() { Id = 3, TipoAtivo = TipoAtivo.Criptomoeda, Nome = "Nome Ativo Criptomoeda 001", Codigo = "NAC001" },
                new Ativo() { Id = 4, TipoAtivo = TipoAtivo.Titulo, Nome = "Nome Ativo Titulo 002", Codigo = "NAT002" }
                );

            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio() { Id = 1, UsuarioId = 1, Nome = "Portfolio Demetrios", Descricao = "Descricao Portfolio Demetrios" },
                new Portfolio() { Id = 2, UsuarioId = 2, Nome = "Portfolio Erick", Descricao = "Descricao Portfolio Erick" },
                new Portfolio() { Id = 3, UsuarioId = 3, Nome = "Portfolio MARINA", Descricao = "Descricao Portfolio MARINA" },
                new Portfolio() { Id = 4, UsuarioId = 4, Nome = "Portfolio Pamela", Descricao = "Descricao Portfolio Pamela" }
                );

            modelBuilder.Entity<Transacao>().HasData(
                new Transacao() { Id = 1, AtivoId = 1, PortfolioId = 1, TipoTransacao = TipoTransacao.Compra, Quantidade = 10, Preco = 150, DataTransacao = DateTime.Now },
                new Transacao() { Id = 2, AtivoId = 2, PortfolioId = 1, TipoTransacao = TipoTransacao.Venda, Quantidade = 10, Preco = 150, DataTransacao = DateTime.Now },
                new Transacao() { Id = 3, AtivoId = 3, PortfolioId = 1, TipoTransacao = TipoTransacao.Compra, Quantidade = 10, Preco = 150, DataTransacao = DateTime.Now },
                new Transacao() { Id = 4, AtivoId = 4, PortfolioId = 1, TipoTransacao = TipoTransacao.Venda, Quantidade = 10, Preco = 150, DataTransacao = DateTime.Now },
                new Transacao() { Id = 5, AtivoId = 1, PortfolioId = 2, TipoTransacao = TipoTransacao.Compra, Quantidade = 10, Preco = 150, DataTransacao = DateTime.Now },
                new Transacao() { Id = 6, AtivoId = 2, PortfolioId = 2, TipoTransacao = TipoTransacao.Venda, Quantidade = 10, Preco = 150, DataTransacao = DateTime.Now },
                new Transacao() { Id = 7, AtivoId = 3, PortfolioId = 2, TipoTransacao = TipoTransacao.Compra, Quantidade = 10, Preco = 150, DataTransacao = DateTime.Now },
                new Transacao() { Id = 8, AtivoId = 4, PortfolioId = 2, TipoTransacao = TipoTransacao.Venda, Quantidade = 10, Preco = 150, DataTransacao = DateTime.Now },
                new Transacao() { Id = 9, AtivoId = 1, PortfolioId = 3, TipoTransacao = TipoTransacao.Compra, Quantidade = 10, Preco = 150, DataTransacao = DateTime.Now },
                new Transacao() { Id = 10, AtivoId = 2, PortfolioId = 3, TipoTransacao = TipoTransacao.Venda, Quantidade = 10, Preco = 150, DataTransacao = DateTime.Now },
                new Transacao() { Id = 11, AtivoId = 3, PortfolioId = 3, TipoTransacao = TipoTransacao.Compra, Quantidade = 10, Preco = 150, DataTransacao = DateTime.Now },
                new Transacao() { Id = 12, AtivoId = 4, PortfolioId = 3, TipoTransacao = TipoTransacao.Venda, Quantidade = 10, Preco = 150, DataTransacao = DateTime.Now },
                new Transacao() { Id = 13, AtivoId = 1, PortfolioId = 4, TipoTransacao = TipoTransacao.Compra, Quantidade = 10, Preco = 150, DataTransacao = DateTime.Now },
                new Transacao() { Id = 14, AtivoId = 2, PortfolioId = 4, TipoTransacao = TipoTransacao.Venda, Quantidade = 10, Preco = 150, DataTransacao = DateTime.Now },
                new Transacao() { Id = 15, AtivoId = 3, PortfolioId = 4, TipoTransacao = TipoTransacao.Compra, Quantidade = 10, Preco = 150, DataTransacao = DateTime.Now },
                new Transacao() { Id = 16, AtivoId = 4, PortfolioId = 4, TipoTransacao = TipoTransacao.Venda, Quantidade = 10, Preco = 150, DataTransacao = DateTime.Now }
                );
        }
    }
}
