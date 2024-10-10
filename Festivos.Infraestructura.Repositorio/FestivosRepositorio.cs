using Festivos.Core.Repositorios;
using Festivos.Dominio.Entidades;
using Festivos.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _context.Festivos.Add(festivo);
            await _context.SaveChangesAsync(); 
        }


        public async Task<Festivo> ObtenerPorFecha(DateTime date)
        {
            return await _context.Festivos
                                 .FirstOrDefaultAsync(f => f.Dia == date.Day && f.Mes == date.Month);
        }


        public async Task EliminarFestivo(DateTime date)
        {
            var festivo = await _context.Festivos
                                        .FirstOrDefaultAsync(f => f.Dia == date.Day && f.Mes == date.Month);
            if (festivo != null)
            {
                _context.Festivos.Remove(festivo);
                await _context.SaveChangesAsync();
            }
        }



        public async Task<IEnumerable<Festivo>> obtenerTodos()
        {
            return await _context.Festivos.ToListAsync();
        }
    }

}
