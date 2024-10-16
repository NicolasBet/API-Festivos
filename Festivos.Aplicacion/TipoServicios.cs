using Festivos.Core.Repositorios;
using Festivos.Core.Servicios;
using Festivos.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Festivos.Aplicacion.Servicios
{
    public class TipoServicios : ITipoServicios
    {
        private readonly ITipoRepositorio _repositorio;

        public TipoServicios(ITipoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Tipo>> ObtenerTodosLosTipos()
        {
            return await _repositorio.ObtenerTodos();
        }

        public async Task<Tipo> ObtenerDetallesDeTipo(int id)
        {
            return await _repositorio.ObtenerPorId(id);
        }

        public async Task AgregarNuevoTipo(Tipo tipo)
        {
            await _repositorio.AgregarTipo(tipo);
        }
    }
}

