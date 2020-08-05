using Capa_Datos;
using CapaEntidad;
using System.Data;

namespace Capa_Negocios
{
    public class ExpedientesNegocio
    {
        ExpedientesDatos _ExpedientesDatos = new ExpedientesDatos();

        public bool CrearExpedientes(ExpedientesEntidad ExpedientesNegocio)
        {
            return _ExpedientesDatos.InsertarExpedientes(ExpedientesNegocio);
        }

        public bool ModificarExpedientes(ExpedientesEntidad ExpedientesNegocio)
        {
            return _ExpedientesDatos.ActualizarExpedientes(ExpedientesNegocio);
        }

        //public bool DeshabilitarExpedientes(ExpedientesEntidad ExpedientesNegocio)
        //{
        //    return _ExpedientesDatos.DeshabilitarExpediente(ExpedientesNegocio);
        //}

        public DataTable ListarExpedientes(string parametro)
        {
            return _ExpedientesDatos.ListarExpedientes(parametro);
        }

        public ExpedientesEntidad ConsultarExpedientes(string codigo)
        {
            return _ExpedientesDatos.BuscarExpedientes(codigo);
        }
    }
}
