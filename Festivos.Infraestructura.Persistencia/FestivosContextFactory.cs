using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Infraestructura.Persistencia
{
    public class FestivosContextFactory : IDesignTimeDbContextFactory<FestivosContext>
    {
        public FestivosContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FestivosContext>();
            optionsBuilder.UseSqlServer("Server=NICOLµS\\SQLEXPRESS;Database=Festivos;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"); // Cambia por tu cadena de conexión

            return new FestivosContext(optionsBuilder.Options);
        }
    }
}
