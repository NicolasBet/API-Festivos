using Festivos.Core.Repositorios;
using Festivos.Dominio.Entidades;
using Festivos.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Festivos.Infraestructura.Repositorio
{
    public class FestivosRepositorio : IFestivosRepositorios
    {
        private readonly FestivosContext _context;

        public FestivosRepositorio(FestivosContext context)
        {
            _context = context;
        }

   
        public async Task AgregarFestivo(Festivo festivo)
        {
            _context.Festivo.Add(festivo);
            await _context.SaveChangesAsync(); 
        }


        public async Task<Festivo> ObtenerPorFecha(DateTime date)
        {
            return await _context.Festivo
                                 .FirstOrDefaultAsync(f => f.Dia == date.Day && f.Mes == date.Month);
        }


        public async Task EliminarFestivo(DateTime date)
        {
            var festivo = await _context.Festivo
                                        .FirstOrDefaultAsync(f => f.Dia == date.Day && f.Mes == date.Month);
            if (festivo != null)
            {
                _context.Festivo.Remove(festivo);
                await _context.SaveChangesAsync();
            }
        }



        public async Task<IEnumerable<Festivo>> obtenerTodos()
        {
            return await _context.Festivo.ToListAsync();
        }
    }

}
