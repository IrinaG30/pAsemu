namespace CapaEntidad
{
    public class EstadoRegPrestamosEntidad
    {

        private string estado;
        private int idEstadoRegPrestamos;
        public int id
        {
            get { return idEstadoRegPrestamos; }
            set { idEstadoRegPrestamos = value; }
        }
        public string tipoEstado
        {
            get { return estado; }
            set { estado = value; }
        }

    }
}
