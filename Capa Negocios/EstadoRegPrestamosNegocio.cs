using Capa_Datos;
using CapaEntidad;
using System.Data;

namespace Capa_Negocios
{
    public class EstadoRegPrestamosNegocio
    {

        EstadoRegPrestamosDatos _EstadoRegPrestamosDatos = new EstadoRegPrestamosDatos();

        public bool CrearEstadoRegPrestamo(EstadoRegPrestamosEntidad RolNegocio)
        {
            return _EstadoRegPrestamosDatos.InsertarEstadoRegPrestamos(RolNegocio);
        }

        public bool ModificarEstadoRegPrestamo(EstadoRegPrestamosEntidad RolNegocio)
        {
            return _EstadoRegPrestamosDatos.ActualizarEstadoRegPrestamos(RolNegocio);
        }

        public bool EliminarEstadoRegPrestamo(EstadoRegPrestamosEntidad RolNegocio)
        {
            return _EstadoRegPrestamosDatos.EliminarEstadoRegPrestamos(RolNegocio);
        }

        public DataTable ListarEstadoRegPrestamo(string parametro)
        {
            return _EstadoRegPrestamosDatos.ListarEstadoRegPrestamos(parametro);
        }
        public EstadoRegPrestamosEntidad ConsultarEstadoRegPrestamo(string codigo)
        {
            return _EstadoRegPrestamosDatos.BuscarEstadoRegPrestamos(codigo);
        }

    }
}
