using Capa_Datos;
using CapaEntidad;
using System.Data;

namespace Capa_Negocios
{
    public class TipoCreditosNegocio
    {
        TipoCreditosDatos _TipoCreditosDatos = new TipoCreditosDatos();

        public bool CrearTipoCredito(TipoCreditosEntidad TipoCreditoNegocio)
        {
            return _TipoCreditosDatos.InsertarTipoCredito(TipoCreditoNegocio);
        }

        public bool ModificarTipoCredito(TipoCreditosEntidad TipoCreditoNegocio)
        {
            return _TipoCreditosDatos.ActualizarTipoCredito(TipoCreditoNegocio);
        }

        public bool EliminarTipoCredito(TipoCreditosEntidad TipoCreditoNegocio)
        {
            return _TipoCreditosDatos.EliminarTipoCredito(TipoCreditoNegocio);
        }

        public DataTable ListarTipoCredito(string parametro)
        {
            return _TipoCreditosDatos.ListarTipoCredito(parametro);
        }
        public TipoCreditosEntidad ConsultarTipoCredito(string codigo)
        {
            return _TipoCreditosDatos.BuscarTipoCredito(codigo);
        }

    }
}
