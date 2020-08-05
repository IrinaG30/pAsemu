namespace CapaEntidad
{
    public class FiadoresEntidad
    {
        private string tipoFiador;
        private int idTipoFiadores, idEstadoDatos;
        public int id
        {
            get { return idTipoFiadores; }
            set { idTipoFiadores = value; }
        }
        public string tipo
        {
            get { return tipoFiador; }
            set { tipoFiador = value; }
        }
        public int estado
        {
            get { return idEstadoDatos; }
            set { idEstadoDatos = value; }
        }
    }
}
