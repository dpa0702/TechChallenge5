using GestaoInvestimentosCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace GestaoInvestimentosInfrastructure.Configuration
{
    [ExcludeFromCodeCoverage]
    public class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Transacao");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(t => t.TipoTransacao).HasColumnType("INT").IsRequired();
            builder.Property(t => t.Quantidade).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(t => t.Preco).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(t => t.DataTransacao).HasColumnType("VARCHAR(100)").IsRequired();

            builder.Property(t => t.PortfolioId).HasColumnType("INT").IsRequired();
            //builder.HasOne(p => p.Portfolio).WithMany(t => t.Transacoes).HasForeignKey(p => p.PortfolioId);

            builder.Property(t => t.AtivoId).HasColumnType("INT").IsRequired();
            //builder.HasOne(a => a.Ativo).WithMany(t => t.Transacoes).HasForeignKey(a => a.AtivoId);
        }
    }
}
