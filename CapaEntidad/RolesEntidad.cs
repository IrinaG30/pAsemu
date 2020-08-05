namespace CapaEntidad
{
    public class RolesEntidad
    {

        private string tipoRol;
        private int idRoles,idEstadoDatos;
        public int id
        {
            get { return idRoles; }
            set { idRoles = value; }
        }
        public string tipo
        {
            get { return tipoRol; }
            set { tipoRol = value; }
        }
        public int estado
        {
            get { return idEstadoDatos; }
            set { idEstadoDatos = value; }
        }

    }
}
