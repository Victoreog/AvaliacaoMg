using AvaliacaoMg.Data.EntityConfig;
using AvaliacaoMg.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaliacaoMg.Data.Context
{
    public class AvaliacaoMgContext : DbContext
    {
        public AvaliacaoMgContext()
        {

        }

        public AvaliacaoMgContext(DbContextOptions<AvaliacaoMgContext> options) : base(options)
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // adicionar mapeamento aqui (para evitar pluralization)
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Socio>().ToTable("Socio");
            modelBuilder.Entity<Contato>().ToTable("Contato");

            // adicionar aqui entity configuration
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new SocioConfiguration());
            modelBuilder.ApplyConfiguration(new ContatoConfiguration());
        }
    }
}
