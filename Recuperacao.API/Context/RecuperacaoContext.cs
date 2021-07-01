using Microsoft.EntityFrameworkCore;
using Recuperacao.API.Domains;

namespace Recuperacao.Context
{
    public class RecuperacaoContext : DbContext
    {
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-1CB35NO; Initial Catalog= Recuperacao; Trusted_Connection=True;");

        }
    }
}
