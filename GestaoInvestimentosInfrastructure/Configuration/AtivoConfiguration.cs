using GestaoInvestimentosCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoInvestimentosInfrastructure.Configuration
{
    public class AtivoConfiguration : IEntityTypeConfiguration<Ativo>
    {
        public void Configure(EntityTypeBuilder<Ativo> builder)
        {
            builder.ToTable("Ativo");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(a => a.TipoAtivo).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(a => a.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(a => a.Codigo).HasColumnType("VARCHAR(50)").IsRequired();
        }
    }
}
