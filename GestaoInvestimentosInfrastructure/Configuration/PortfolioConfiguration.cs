using GestaoInvestimentosCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace GestaoInvestimentosInfrastructure.Configuration
{
    [ExcludeFromCodeCoverage]
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.ToTable("Portfolio");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.UsuarioId).HasColumnType("INT").IsRequired();
        }
    }
}
