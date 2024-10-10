using Festivos.Core.Repositorios;
using Festivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Core.Servicios
{
    public interface ITipoServicios
    {
        Task<IEnumerable<Tipo>> ObtenerTodosLosTipos();

        Task<Tipo> ObtenerDetallesDeTipo(int id);

        Task AgregarNuevoTipo(Tipo tipo);
    }
}