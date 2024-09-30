using Microsoft.EntityFrameworkCore;
using Festivos.Dominio.Entidades;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Festivos.Infraestructura.Persistencia
{
    public class FestivosContext : DbContext
    {
        public FestivosContext(DbContextOptions<FestivosContext> options) : base(options)
        {
        }

        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Festivo> Festivos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
