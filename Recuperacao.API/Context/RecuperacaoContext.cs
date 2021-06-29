using Microsoft.EntityFrameworkCore;
using Recuperacao.API.Domains;
using System;
using System.Data.Common;
using System.Linq;

namespace Recuperacao.Api.Contexts
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
        {

            try
            {
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
                {
                    if (new Guid(entry.Property("Id").CurrentValue.ToString()) == Guid.Empty)
                        entry.Property("Id").CurrentValue = Guid.NewGuid();

                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("DataCriacao").CurrentValue = DateTime.Now;
                        entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("DataCriacao").IsModified = false;
                        entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                    }
                }

                return base.SaveChanges();
            }
            catch (DbException db)
            {
                throw new Exception(db.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.Message);
                }

                throw new Exception(ex.Message);
            }
        }
    }
}
