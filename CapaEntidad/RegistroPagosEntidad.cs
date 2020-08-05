using System;

namespace CapaEntidad
{
    public class RegistroPagosEntidad
    {

        private int idRegistroPago, numeroPrestamo, numeroEmpleado, idPlazo, idEstado,
            montoAPagar, totalPagado, idPrestamo;
        private DateTime fechaPago;
        private DateTime? fechaProxPago;
        public int id
        {
            get { return idRegistroPago; }
            set { idRegistroPago = value; }
        }
        public int numPrestamo
        {
            get { return numeroPrestamo; }
            set { numeroPrestamo = value; }
        }
        public int numEmpleado
        {
            get { return numeroEmpleado; }
            set { numeroEmpleado = value; }
        }
        public DateTime fechPago
        {
            get { return fechaPago; }
            set { fechaPago = value; }
        }
        public int idPla
        {
            get { return idPlazo; }
            set { idPlazo = value; }
        }
        public DateTime? fechProxPago
        {
            get { return fechaProxPago; }
            set { fechaProxPago = value; }
        }
        public int idEstad
        {
            get { return idEstado; }
            set { idEstado = value; }
        }
        public int montAPagar
        {
            get { return montoAPagar; }
            set { montoAPagar = value; }
        }
        public int totaPagado
        {
            get { return totalPagado; }
            set { totalPagado = value; }
        }

        public int idPres
        {
            get { return idPrestamo; }
            set { idPrestamo = value; }
        }
    }
}
