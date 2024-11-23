using Festivos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

public class FestivosContext : DbContext
{
    public FestivosContext(DbContextOptions<FestivosContext> options) : base(options)
    {
    }

    public DbSet<Festivo> Festivo { get; set; }
    public DbSet<Tipo> Tipo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Festivo>()
            .HasOne(f => f.Tipo)
            .WithMany()
            .HasForeignKey(f => f.IdTipo)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
