﻿// <auto-generated />
using GestaoInvestimentosInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestaoInvestimentosInfrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestaoInvestimentosCore.Entities.Ativo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("TipoAtivo")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.ToTable("Ativo", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Codigo = "NAA001",
                            Nome = "Nome Ativo Acao 001",
                            TipoAtivo = 1
                        },
                        new
                        {
                            Id = 2,
                            Codigo = "NAT001",
                            Nome = "Nome Ativo Titulo 001",
                            TipoAtivo = 2
                        },
                        new
                        {
                            Id = 3,
                            Codigo = "NAC001",
                            Nome = "Nome Ativo Criptomoeda 001",
                            TipoAtivo = 3
                        },
                        new
                        {
                            Id = 4,
                            Codigo = "NAT002",
                            Nome = "Nome Ativo Titulo 002",
                            TipoAtivo = 2
                        });
                });

            modelBuilder.Entity("GestaoInvestimentosCore.Entities.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Portfolio", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Descricao Portfolio Demetrios",
                            Nome = "Portfolio Demetrios",
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Descricao Portfolio Erick",
                            Nome = "Portfolio Erick",
                            UsuarioId = 2
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Descricao Portfolio MARINA",
                            Nome = "Portfolio MARINA",
                            UsuarioId = 3
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Descricao Portfolio Pamela",
                            Nome = "Portfolio Pamela",
                            UsuarioId = 4
                        });
                });

            modelBuilder.Entity("GestaoInvestimentosCore.Entities.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AtivoId")
                        .HasColumnType("INT");

                    b.Property<string>("DataTransacao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("INT");

                    b.Property<string>("Preco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Quantidade")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("TipoTransacao")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("AtivoId");

                    b.HasIndex("PortfolioId");

                    b.ToTable("Transacao", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AtivoId = 1,
                            DataTransacao = "2024-06-11 17:06:12.8595737",
                            PortfolioId = 1,
                            Preco = "150",
                            Quantidade = "10",
                            TipoTransacao = 1
                        },
                        new
                        {
                            Id = 2,
                            AtivoId = 2,
                            DataTransacao = "2024-06-11 17:06:12.8595753",
                            PortfolioId = 1,
                            Preco = "150",
                            Quantidade = "10",
                            TipoTransacao = 2
                        },
                        new
                        {
                            Id = 3,
                            AtivoId = 3,
                            DataTransacao = "2024-06-11 17:06:12.8595755",
                            PortfolioId = 1,
                            Preco = "150",
                            Quantidade = "10",
                            TipoTransacao = 1
                        },
                        new
                        {
                            Id = 4,
                            AtivoId = 4,
                            DataTransacao = "2024-06-11 17:06:12.8595757",
                            PortfolioId = 1,
                            Preco = "150",
                            Quantidade = "10",
                            TipoTransacao = 2
                        },
                        new
                        {
                            Id = 5,
                            AtivoId = 1,
                            DataTransacao = "2024-06-11 17:06:12.859576",
                            PortfolioId = 2,
                            Preco = "150",
                            Quantidade = "10",
                            TipoTransacao = 1
                        },
                        new
                        {
                            Id = 6,
                            AtivoId = 2,
                            DataTransacao = "2024-06-11 17:06:12.8595762",
                            PortfolioId = 2,
                            Preco = "150",
                            Quantidade = "10",
                            TipoTransacao = 2
                        },
                        new
                        {
                            Id = 7,
                            AtivoId = 3,
                            DataTransacao = "2024-06-11 17:06:12.8595764",
                            PortfolioId = 2,
                            Preco = "150",
                            Quantidade = "10",
                            TipoTransacao = 1
                        },
                        new
                        {
                            Id = 8,
                            AtivoId = 4,
                            DataTransacao = "2024-06-11 17:06:12.8595766",
                            PortfolioId = 2,
                            Preco = "150",
                            Quantidade = "10",
                            TipoTransacao = 2
                        },
                        new
                        {
                            Id = 9,
                            AtivoId = 1,
                            DataTransacao = "2024-06-11 17:06:12.859577",
                            PortfolioId = 3,
                            Preco = "150",
                            Quantidade = "10",
                            TipoTransacao = 1
                        },
                        new
                        {
                            Id = 10,
                            AtivoId = 2,
                            DataTransacao = "2024-06-11 17:06:12.8595772",
                            PortfolioId = 3,
                            Preco = "150",
                            Quantidade = "10",
                            TipoTransacao = 2
                        },
                        new
                        {
                            Id = 11,
                            AtivoId = 3,
                            DataTransacao = "2024-06-11 17:06:12.8595775",
                            PortfolioId = 3,
                            Preco = "150",
                            Quantidade = "10",
                            TipoTransacao = 1
                        },
                        new
                        {
                            Id = 12,
                            AtivoId = 4,
                            DataTransacao = "2024-06-11 17:06:12.8595777",
                            PortfolioId = 3,
                            Preco = "150",
                            Quantidade = "10",
                            TipoTransacao = 2
                        },
                        new
                        {
                            Id = 13,
                            AtivoId = 1,
                            DataTransacao = "2024-06-11 17:06:12.8595778",
                            PortfolioId = 4,
                            Preco = "150",
                            Quantidade = "10",
                            TipoTransacao = 1
                        },
                        new
                        {
                            Id = 14,
                            AtivoId = 2,
                            DataTransacao = "2024-06-11 17:06:12.859578",
                            PortfolioId = 4,
                            Preco = "150",
                            Quantidade = "10",
                            TipoTransacao = 2
                        },
                        new
                        {
                            Id = 15,
                            AtivoId = 3,
                            DataTransacao = "2024-06-11 17:06:12.8595782",
                            PortfolioId = 4,
                            Preco = "150",
                            Quantidade = "10",
                            TipoTransacao = 1
                        },
                        new
                        {
                            Id = 16,
                            AtivoId = 4,
                            DataTransacao = "2024-06-11 17:06:12.8595784",
                            PortfolioId = 4,
                            Preco = "150",
                            Quantidade = "10",
                            TipoTransacao = 2
                        });
                });

            modelBuilder.Entity("GestaoInvestimentosCore.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "rm352321@fiap.com.br",
                            Nome = "Demetrios Pandelis Arghirachis",
                            Senha = "1q2w3e4r@#"
                        },
                        new
                        {
                            Id = 2,
                            Email = "rm351017@fiap.com.br",
                            Nome = "Erick Felipe Vieira da Silva",
                            Senha = "1q2w3e4r@#"
                        },
                        new
                        {
                            Id = 3,
                            Email = "rm352116@fiap.com.br",
                            Nome = "MARINA SANT'ANA MIRANDA DE OLIVEIRA",
                            Senha = "1q2w3e4r@#"
                        },
                        new
                        {
                            Id = 4,
                            Email = "rm352127@fiap.com.br",
                            Nome = "Pamela Suellen Souza Caffa",
                            Senha = "1q2w3e4r@#"
                        });
                });

            modelBuilder.Entity("GestaoInvestimentosCore.Entities.Portfolio", b =>
                {
                    b.HasOne("GestaoInvestimentosCore.Entities.Usuario", null)
                        .WithMany("Portfolios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestaoInvestimentosCore.Entities.Transacao", b =>
                {
                    b.HasOne("GestaoInvestimentosCore.Entities.Ativo", null)
                        .WithMany("Transacoes")
                        .HasForeignKey("AtivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestaoInvestimentosCore.Entities.Portfolio", null)
                        .WithMany("Transacoes")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestaoInvestimentosCore.Entities.Ativo", b =>
                {
                    b.Navigation("Transacoes");
                });

            modelBuilder.Entity("GestaoInvestimentosCore.Entities.Portfolio", b =>
                {
                    b.Navigation("Transacoes");
                });

            modelBuilder.Entity("GestaoInvestimentosCore.Entities.Usuario", b =>
                {
                    b.Navigation("Portfolios");
                });
#pragma warning restore 612, 618
        }
    }
}
