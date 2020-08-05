namespace CapaEntidad
{
    public class TipoCreditosEntidad
    {

        private string nombreCredito;
        private int idTipoCredito, idEstadoDatos;
        public int id
        {
            get { return idTipoCredito; }
            set { idTipoCredito = value; }
        }
        public string nomCredito
        {
            get { return nombreCredito; }
            set { nombreCredito = value; }
        }
        public int estado
        {
            get { return idEstadoDatos; }
            set { idEstadoDatos = value; }
        }

    }
}
