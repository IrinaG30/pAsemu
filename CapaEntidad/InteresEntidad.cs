namespace CapaEntidad
{
    public class InteresEntidad
    {
        private string tipoInteres;
        private int idInteres, porcentajeInteres, idEstadoDatos;
        public int id
        {
            get { return idInteres; }
            set { idInteres = value; }
        }
        public int porcentaje
        {
            get { return porcentajeInteres; }
            set { porcentajeInteres = value; }
        }
        public string tipo
        {
            get { return tipoInteres; }
            set { tipoInteres = value; }
        }
        public int estado
        {
            get { return idEstadoDatos; }
            set { idEstadoDatos = value; }
        }

    }
}
