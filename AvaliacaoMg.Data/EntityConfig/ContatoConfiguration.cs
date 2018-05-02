using AvaliacaoMg.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaliacaoMg.Data.EntityConfig
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(x => x.IdContato);

            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.DDD).IsRequired();
            builder.Property(x => x.Numero).IsRequired();

            builder.Property(x => x.Tipo).HasMaxLength(50);
            builder.Property(x => x.DDD).HasMaxLength(5);
            builder.Property(x => x.Numero).HasMaxLength(25);
            builder.Property(x => x.Email).HasMaxLength(200);

        }
    }
}
