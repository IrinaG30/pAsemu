using Capa_Datos;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Negocios
{
    public class PuestosNegocio
    {

        PuestosDatos _PuestosDatos = new PuestosDatos();

        public bool CrearPuesto(PuestosEntidad PuestosNegocio)
        {
            return _PuestosDatos.InsertarPuesto(PuestosNegocio);
        }

        public bool ModificarPuesto(PuestosEntidad PuestosNegocio)
        {
            return _PuestosDatos.ActualizarPuesto(PuestosNegocio);
        }

        public bool EliminarPuesto(PuestosEntidad PuestosNegocio)
        {
            return _PuestosDatos.EliminarPuesto(PuestosNegocio);
        }

        public DataTable ListarPuesto(string parametro)
        {
            return _PuestosDatos.ListarPuesto(parametro);
        }
        public PuestosEntidad ConsultarPuesto(string codigo)
        {
            return _PuestosDatos.BuscarPuesto(codigo);
        }

        //public SqlDataReader SeleccionarPuesto ()
        //{
        //    return _PuestosDatos.SelectPuestos();
        //} 

    }
}
