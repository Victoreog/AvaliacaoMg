using AvaliacaoMg.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaliacaoMg.Data.EntityConfig
{
    public class SocioConfiguration : IEntityTypeConfiguration<Socio>
    {
        public void Configure(EntityTypeBuilder<Socio> builder)
        {
            builder.HasKey(x => x.IdSocio);

            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Cpf).IsRequired();

            builder.Property(x => x.Nome).HasMaxLength(150);
            builder.Property(x => x.Cpf).HasMaxLength(15);
        }
    }
}
