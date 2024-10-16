using Festivos.Core.Repositorios;
using Festivos.Core.Servicios;
using Festivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Festivos.Aplicacion.Servicios
{
    public class FestivoServicios : IFestivosServicios
    {
        private readonly IFestivosRepositorios _repositorio;

        public FestivoServicios(IFestivosRepositorios repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await _repositorio.obtenerTodos();
        }

        public async Task<bool> EsFestivo(DateTime date)
        {
            var festivo = await _repositorio.ObtenerPorFecha(date);
            return festivo != null;
        }

        public async Task AgregarNuevoFestivo(Festivo festivo)
        {
            await _repositorio.AgregarFestivo(festivo);
        }

        public async Task EliminarFestivo(DateTime date)
        {
            await _repositorio.EliminarFestivo(date);
        }
    }
}
