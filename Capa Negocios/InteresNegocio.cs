using Capa_Datos;
using CapaEntidad;
using System.Data;

namespace Capa_Negocios
{
    public class InteresNegocio
    {
        InteresDatos _InteresDatos = new InteresDatos();

        public bool CrearInteres(InteresEntidad InteresNegocio)
        {
            return _InteresDatos.InsertarInteres(InteresNegocio);
        }

        public bool ModificarInteres(InteresEntidad InteresNegocio)
        {
            return _InteresDatos.ActualizarInteres(InteresNegocio);
        }

        public bool EliminarInteres(InteresEntidad InteresNegocio)
        {
            return _InteresDatos.EliminarInteres(InteresNegocio);
        }

        public DataTable ListarInteres(string parametro)
        {
            return _InteresDatos.ListarInteres(parametro);
        }
        public InteresEntidad ConsultarInteres(string codigo)
        {
            return _InteresDatos.BuscarInteres(codigo);
        }

    }
}
