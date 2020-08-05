using System;

namespace CapaEntidad
{
    public class PrestamosEntidad
    {
        private DateTime fechaInicio, fechaFinal;
        private string estado;
        private int idPrestamo, numeroPrestamo, cedulaAsociado,
            numeroEmpleado, idPuesto, numeroCuenta, idTipoCredito, idPlazo,
            montoCuota, idInteres,
            idTipoFiador, montoSolicitado, montoAPagar, salarioBruto,
            salarioNeto, coutaFianza, comisionCargos;


        public string estados
        {
            get { return estado; }
            set { estado = value; }
        }
        public int idPrestamos
        {
            get { return idPrestamo; }
            set { idPrestamo = value; }
        }
        public int numPrestamo
        {
            get { return numeroPrestamo; }
            set { numeroPrestamo = value; }
        }
        public int cedAsociado
        {
            get { return cedulaAsociado; }
            set { cedulaAsociado = value; }
        }
        public int numEmpleado
        {
            get { return numeroEmpleado; }
            set { numeroEmpleado = value; }
        }
        public int idPuestos
        {
            get { return idPuesto; }
            set { idPuesto = value; }
        }
        public int numCuenta
        {
            get { return numeroCuenta; }
            set { numeroCuenta = value; }
        }
        public int idTipoCreditos
        {
            get { return idTipoCredito; }
            set { idTipoCredito = value; }
        }
        public int idPlazos
        {
            get { return idPlazo; }
            set { idPlazo = value; }
        }
        public int montoCuot
        {
            get { return montoCuota; }
            set { montoCuota = value; }
        }
        public DateTime fechaInci
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }
        public DateTime fechaFina
        {
            get { return fechaFinal; }
            set { fechaFinal = value; }
        }
        public int idIntere
        {
            get { return idInteres; }
            set { idInteres = value; }
        }
        public int idTipFiador
        {
            get { return idTipoFiador; }
            set { idTipoFiador = value; }
        }
        public int montSolicitado
        {
            get { return montoSolicitado; }
            set { montoSolicitado = value; }
        }
        public int monAPagar
        {
            get { return montoAPagar; }
            set { montoAPagar = value; }
        }
        public int salBruto
        {
            get { return salarioBruto; }
            set { salarioBruto = value; }
        }
        public int salNeto
        {
            get { return salarioNeto; }
            set { salarioNeto = value; }
        }
        public int coutFianza
        {
            get { return coutaFianza; }
            set { coutaFianza = value; }
        }
        public int comiCargos
        {
            get { return comisionCargos; }
            set { comisionCargos = value; }
        }

    }
}
