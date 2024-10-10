using Festivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Core.Repositorios
{
    public interface ITipoRepositorio
    {
        Task<IEnumerable<Tipo>> ObtenerTodos();
        Task<Tipo> ObtenerPorId(int id);
        Task AgregarTipo(Tipo tipo);
    }
}

