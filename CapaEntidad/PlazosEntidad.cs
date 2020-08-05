namespace CapaEntidad
{
    public class PlazosEntidad
    {

        private string plazo;
        private int idPlazo, idEstadoDatos;
        public int id
        {
            get { return idPlazo; }
            set { idPlazo = value; }
        }
        public string plazos
        {
            get { return plazo; }
            set { plazo = value; }
        }
        public int estado
        {
            get { return idEstadoDatos; }
            set { idEstadoDatos = value; }
        }

    }
}
