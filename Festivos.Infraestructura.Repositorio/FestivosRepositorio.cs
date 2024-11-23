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
            // 1. Buscar primero festivos fijos
            var festivo = await _context.Festivo
                .Include(f => f.Tipo)
                .FirstOrDefaultAsync(f => f.Dia == date.Day && f.Mes == date.Month);

            // 2. Si no se encuentra en los fijos, buscar en los móviles
            if (festivo == null)
            {
                // Calcular la fecha del domingo de Pascua
                var pascua = CalcularDomingoDePascua(date.Year);

                // Buscar festivo móvil
                festivo = await _context.Festivo
                    .Include(f => f.Tipo)
                    .FirstOrDefaultAsync(f => f.DiasPascua != 0 &&
                                              pascua.AddDays(f.DiasPascua).Date == date.Date);
            }

            return festivo;
        }

        // Método para calcular el Domingo de Pascua (algoritmo de computus)
        private DateTime CalcularDomingoDePascua(int year)
        {
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int month = (h + l - 7 * m + 114) / 31;
            int day = ((h + l - 7 * m + 114) % 31) + 1;

            return new DateTime(year, month, day);
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
