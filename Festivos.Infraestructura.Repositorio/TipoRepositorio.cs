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

        Task ITipoRepositorio.AgregarTipo(Tipo tipo)
        {
            throw new NotImplementedException();
        }

        Task<Tipo> ITipoRepositorio.ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Tipo>> ITipoRepositorio.ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
