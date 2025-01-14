﻿using GestaoInvestimentosCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace GestaoInvestimentosInfrastructure.Configuration
{
    [ExcludeFromCodeCoverage]
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(u => u.Nome).HasColumnName("Nome").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.Email).HasColumnType("VARCHAR(100)");
            builder.Property(u => u.Senha).HasColumnType("VARCHAR(150)").IsRequired();
        }
    }
}
