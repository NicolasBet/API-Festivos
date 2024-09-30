using Festivos.Core.Repositorios;
using Festivos.Dominio.Entidades;
using Festivos.Dominio.Entidades;
using Festivos.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
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
            return await _context.Tipos.ToListAsync();
        }

        public async Task<Tipo> ObtenerPorId(int id)
        {
            return await _context.Tipos.FindAsync(id);
        }

        public async Task AgregarTipo(Tipo tipo)
        {
            _context.Tipos.Add(tipo);
            await _context.SaveChangesAsync();
        }
    }
}
