using Festivos.Core.Repositorios;
using Festivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Infraestructura.Repositorio
{
    public class TipoRepositorio : ITipoRepositorio
    {
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
