namespace CapaEntidad
{
    public class PuestosEntidad
    {

        private string nombre;
        private int idPuesto, idEstadoDatos;
        public int id
        {
            get { return idPuesto; }
            set { idPuesto = value; }
        }
        public string nombres
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int estado
        {
            get { return idEstadoDatos; }
            set { idEstadoDatos = value; }
        }

    }
}
