using System;

namespace CapaEntidad
{
    public class ExpedientesEntidad
    {
        private int idExpedientes, cedulaAsociado, numeroEmpleado, telefono,
            idPuesto, idDepartamento, idCondicionLaboral, numeroCuenta, idEstadoDatos;
        private string nombreAsociado, apellido1, apellido2, direccion, tiempoAfiliado, correoElectronico;
        private DateTime fechaIngreso, fechaSalida;

        public int id
        {
            get { return idExpedientes; }
            set { idExpedientes = value; }
        }

        public int cedula
        {
            get { return cedulaAsociado; }
            set { cedulaAsociado = value; }
        }

        public int numEmple
        {
            get { return numeroEmpleado; }
            set { numeroEmpleado = value; }
        }


        public string nomAsociado
        {
            get { return nombreAsociado; }
            set { nombreAsociado = value; }
        }



        public string ape1
        {
            get { return apellido1; }
            set { apellido1 = value; }
        }

        public string ape2
        {
            get { return apellido2; }
            set { apellido2 = value; }
        }


        public int tel
        {
            get { return telefono; }
            set { telefono = value; }
        }


        public string dire
        {
            get { return direccion; }
            set { direccion = value; }
        }


        public string correoElectr
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }


        public int idPues
        {
            get { return idPuesto; }
            set { idPuesto = value; }
        }

        public int idDepar
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }

        public DateTime feIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        public DateTime feSalida
        {
            get { return fechaSalida; }
            set { fechaSalida = value; }
        }

        public int idCondiLab
        {
            get { return idCondicionLaboral; }
            set { idCondicionLaboral = value; }
        }


        public string tiemAfiliado
        {
            get { return tiempoAfiliado; }
            set { tiempoAfiliado = value; }
        }

        public int numCuenta
        {
            get { return numeroCuenta; }
            set { numeroCuenta = value; }
        }

        public int idEstado
        {
            get { return idEstadoDatos; }
            set { idEstadoDatos = value; }
        }

    }
}
