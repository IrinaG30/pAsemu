using Capa_Datos;
using CapaEntidad;
using System.Data;

namespace Capa_Negocios
{
    public class RolesNegocio
    {

        RolesDatos _RolesDatos = new RolesDatos();

        public bool CrearRol(RolesEntidad RolNegocio)
        {
            return _RolesDatos.InsertarRol(RolNegocio);
        }

        public bool ModificarRol(RolesEntidad RolNegocio)
        {
            return _RolesDatos.ActualizarRol(RolNegocio);
        }

        public bool EliminarRol (RolesEntidad RolNegocio)
        {
            return _RolesDatos.EliminarRol(RolNegocio);
        }

        public DataTable ListarRoles(string parametro)
        {
            return _RolesDatos.ListarRoles(parametro);
        }
        public RolesEntidad ConsultarRol(string codigo)
        {
            return _RolesDatos.BuscarRol(codigo);
        }
    }
}
