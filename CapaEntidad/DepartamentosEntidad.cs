namespace CapaEntidad
{
    public class DepartamentosEntidad
    {

        private string nombreDepartamento;
        private int idDepartamento, idEstadoDatos;
        public int id
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }
        public string tipo
        {
            get { return nombreDepartamento; }
            set { nombreDepartamento = value; }
        }
        public int estado
        {
            get { return idEstadoDatos; }
            set { idEstadoDatos = value; }
        }

    }
}
