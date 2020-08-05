using Capa_Datos;
using CapaEntidad;
using System.Data;

namespace Capa_Negocios
{
    public class PrestamosNegocio
    {

        PrestamosDatos _PrestamosDatos = new PrestamosDatos();

        public bool InsertarPrestamo(PrestamosEntidad PrestamosNegocio)
        {
            return _PrestamosDatos.InsertarPrestamo(PrestamosNegocio);
        }

        public bool ActualizarPrestamo(PrestamosEntidad PrestamosNegocio)
        {
            return _PrestamosDatos.ActualizarPrestamo(PrestamosNegocio);
        }

        //public bool EliminarPrestamo(PrestamosEntidad PrestamosNegocio)
        //{
        //    return _PrestamosDatos.EliminarPrestamo(PrestamosNegocio);
        //}

        //public DataTable ListarPrestamo(string parametro)
        //{
        //    return _PrestamosDatos.ListarPrestamo(parametro);
        //}
        public PrestamosEntidad BuscarPrestamo(string codigo)
        {
            return _PrestamosDatos.BuscarPrestamo(codigo);
        }

    }
}
