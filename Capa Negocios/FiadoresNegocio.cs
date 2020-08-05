using Capa_Datos;
using CapaEntidad;
using System.Data;

namespace Capa_Negocios
{
    public class FiadoresNegocio
    {

        FiadoresDatos _FiadoresDatos = new FiadoresDatos();

        public bool CrearFiador(FiadoresEntidad FiadorNegocio)
        {
            return _FiadoresDatos.InsertarFiador(FiadorNegocio);
        }

        public bool ModificarFiador(FiadoresEntidad FiadorNegocio)
        {
            return _FiadoresDatos.ActualizarFiador(FiadorNegocio);
        }

        public bool EliminarFiador(FiadoresEntidad FiadorNegocio)
        {
            return _FiadoresDatos.EliminarFiador(FiadorNegocio);
        }

        public DataTable ListarFiadores(string parametro)
        {
            return _FiadoresDatos.ListarFiador(parametro);
        }
        public FiadoresEntidad ConsultarFiador(string codigo)
        {
            return _FiadoresDatos.BuscarFiador(codigo);
        }

    }
}
