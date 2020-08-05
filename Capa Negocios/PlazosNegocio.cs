using Capa_Datos;
using CapaEntidad;
using System.Data;

namespace Capa_Negocios
{
    public class PlazosNegocio
    {

        PlazosDatos _PlazosDatos = new PlazosDatos();

        public bool CrearPlazo(PlazosEntidad PlazoNegocio)
        {
            return _PlazosDatos.InsertarPlazo(PlazoNegocio);
        }

        public bool ModificarPlazo(PlazosEntidad PlazoNegocio)
        {
            return _PlazosDatos.ActualizarPlazo(PlazoNegocio);
        }

        public bool EliminarPlazo(PlazosEntidad PlazoNegocio)
        {
            return _PlazosDatos.EliminarPlazo(PlazoNegocio);
        }

        public DataTable ListarPlazo(string parametro)
        {
            return _PlazosDatos.ListarPlazo(parametro);
        }
        public PlazosEntidad ConsultarPlazo(string codigo)
        {
            return _PlazosDatos.BuscarPlazo(codigo);
        }

    }
}
