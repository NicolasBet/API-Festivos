using Festivos.Core.Repositorios;
using Festivos.Dominio.Entidades;
using Festivos.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Festivos.Infraestructura.Repositorio
{
    public class TipoRepositorio : ITipoRepositorio
    {
        private readonly FestivosContext _context;

        public TipoRepositorio(FestivosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await _context.Tipo.ToListAsync();
        }

        public async Task<Tipo> ObtenerPorId(int id)
        {
            return await _context.Tipo.FindAsync(id);
        }

        public async Task AgregarTipo(Tipo tipo)
        {
            _context.Tipo.Add(tipo);
            await _context.SaveChangesAsync();
        }
    }
}
