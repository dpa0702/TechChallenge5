using GestaoInvestimentosCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoInvestimentosInfrastructure.Configuration
{
    public class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Transacao");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(u => u.TipoTransacao).HasColumnType("INT").IsRequired();
            builder.Property(u => u.Quantidade).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(u => u.Preco).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.DataTransacao).HasColumnType("VARCHAR(100)").IsRequired();

            builder.Property(u => u.PortfolioId).HasColumnType("INT").IsRequired();
            builder.HasOne(u => u.Portfolio).WithMany(p => p.Transacoes).HasForeignKey(u => u.PortfolioId);

            builder.Property(u => u.AtivoId).HasColumnType("INT").IsRequired();
            builder.HasOne(u => u.Ativo).WithMany(p => p.Transacoes).HasForeignKey(u => u.AtivoId);
        }
    }
}
