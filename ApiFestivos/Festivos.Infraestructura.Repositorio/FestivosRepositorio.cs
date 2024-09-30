using Festivos.Core.Repositorios;
using Festivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Infraestructura.Repositorio
{
    public class FestivosRepositorio : IFestivosRepositorios
    {
        Task IFestivosRepositorios.AgregarFestivo(Festivo festivos)
        {
            throw new NotImplementedException();
        }

        Task IFestivosRepositorios.EliminarFestivo(DateTime date)
        {
            throw new NotImplementedException();
        }

        Task<Festivo> IFestivosRepositorios.ObtenerPorFecha(DateTime date)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Festivo>> IFestivosRepositorios.obtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
