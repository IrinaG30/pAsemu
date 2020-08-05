using Capa_Datos;
using CapaEntidad;
using System.Data;

namespace Capa_Negocios
{
    public class DepartamentosNegocio
    {

        DepartamentosDatos _DepartamentoDatos = new DepartamentosDatos();

        public bool CrearDepartamento(DepartamentosEntidad DepartamentoNegocio)
        {
            return _DepartamentoDatos.InsertarDepartamento(DepartamentoNegocio);
        }

        public bool ModificarDepartamento(DepartamentosEntidad DepartamentoNegocio)
        {
            return _DepartamentoDatos.ActualizarDepartamento(DepartamentoNegocio);
        }

        public bool EliminarDepartamento(DepartamentosEntidad DepartamentoNegocio)
        {
            return _DepartamentoDatos.EliminarDepartamento(DepartamentoNegocio);
        }

        public DataTable ListarDepartamento(string parametro)
        {
            return _DepartamentoDatos.ListarDepartamento(parametro);
        }
        public DepartamentosEntidad ConsultarDepartamento(string codigo)
        {
            return _DepartamentoDatos.BuscarDepartamento(codigo);
        }

    }
}
