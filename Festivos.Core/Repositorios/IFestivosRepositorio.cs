using Festivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Core.Repositorios
{
    public interface IFestivosRepositorios
    {
        Task<IEnumerable<Festivo>> obtenerTodos();
        Task<Festivo> ObtenerPorFecha(DateTime date);
        Task AgregarFestivo(Festivo festivos);
        Task EliminarFestivo(DateTime date);

    }
}
