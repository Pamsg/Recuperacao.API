using Microsoft.EntityFrameworkCore;
using Recuperacao.API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recuperacao.API.Context
{
    public class RecuperacaoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }

        public RecuperacaoContext()
        {

        }

        public RecuperacaoContext(DbContextOptions<RecuperacaoContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog= Recuperacao; Trusted_Connection=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
    }

    
    }
