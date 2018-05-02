using AvaliacaoMg.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaliacaoMg.Data.EntityConfig
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.IdCliente);

            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Endereco).IsRequired();

            builder.Property(x => x.Nome).HasMaxLength(150);
            builder.Property(x => x.Cnpj).HasMaxLength(50);
            builder.Property(x => x.Cep).HasMaxLength(10);
            builder.Property(x => x.Endereco).HasMaxLength(150);
            
            builder.HasMany(x => x.Socios).WithOne(x => x.Cliente);
            builder.HasMany(x => x.Contatos).WithOne(x => x.Cliente);
        }
    }
}
