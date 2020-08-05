using Capa_Datos;
using CapaEntidad;
using System.Data;

namespace Capa_Negocios
{
    public class RegistroPagosNegocio
    {
        RegistroPagosDatos _RegistroPagosDatos = new RegistroPagosDatos();

        public bool CrearRegistroPago(RegistroPagosEntidad RegistroPagosNegocio)
        {
            return _RegistroPagosDatos.InsertarRegistroPago(RegistroPagosNegocio);
        }

        //public bool ModificarRegistroPago(RegistroPagosEntidad RegistroPagosNegocio)
        //{
        //    return _RegistroPagosDatos.ActualizarRegistroPago(RegistroPagosNegocio);
        //}

        //public bool EliminarRegistroPago(RegistroPagosEntidad RegistroPagosNegocio)
        //{
        //    return _RegistroPagosDatos.EliminarRegistroPago(RegistroPagosNegocio);
        //}

        public DataTable ListarRegistroPago(string parametro)
        {
            return _RegistroPagosDatos.ListarRegistroPago(parametro);
        }
        public RegistroPagosEntidad ConsultarRegistroPago(int codigo)
        {
            return _RegistroPagosDatos.BuscarRegistroPago(codigo);
        }

        public bool CambiarEstado (RegistroPagosEntidad RegistroPagosEntidad)
        {
            return _RegistroPagosDatos.CambiarEstado(RegistroPagosEntidad);
        }
    }
}
