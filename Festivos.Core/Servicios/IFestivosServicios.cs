using Festivos.Core.Repositorios;
using Festivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Core.Servicios
{
    public interface IFestivosServicios
    {
        Task<IEnumerable<Festivo>> ObtenerTodos();

        Task<bool> EsFestivo(DateTime date);

        Task AgregarNuevoFestivo(Festivo festivo);

        Task EliminarFestivo(DateTime date);
    }
}
