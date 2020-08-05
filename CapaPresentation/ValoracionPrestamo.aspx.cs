using System;
using System.Web.Security;
using System.Web.UI;

namespace CapaPresentation
{
    public partial class ValoracionPrestamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Ejecuta esta linea si viene de otra pagina
            if (!Page.IsPostBack)
            {
                VerificarSesion();
            }
        }

        //CALCULO DEL ASOCIADO
        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            //Se reinician los labels indicadores de fracaso o exito para un nuevo calculo
            lblMensajeExito.Text = "";
            lblMensajeFracaso.Text = "";

            try
            {
                //Se inicializan todos los valores de la valoracion para el prestamo.
                double plazo = Convert.ToDouble(txtPlazo.Text) * 12;
                double interes = CalcInteresAnual();
                double comision = CalcComision();
                double montoSolicitado = Convert.ToDouble(txtMontoSolic.Text);
                double montoAprob = Math.Round(montoSolicitado + comision, 2);
                double poliza = CalcPoliza(montoSolicitado);
                double cuotaMensual = CalcCuotaMes(montoAprob, interes, plazo, poliza);
                double posibleCuota = cuotaMensual;
                double salBruto = Convert.ToDouble(txtSalBruto.Text);
                double salNeto = calcSalarioNeto(salBruto, posibleCuota);
                double porcSalLibre = Math.Round((salNeto / salBruto) * 100, 2);
                double porcSalCompr = Math.Round(100 - porcSalLibre, 2);

                if (poliza != 0)
                {
                    txtPoliza.Text = poliza.ToString(); ;
                }
                else
                {
                    txtPoliza.Text = "No Aplica";
                }


                //Los resultados de las valoraciones se ingresan a los textboxes
                txtPlazoValor.Text = plazo.ToString();
                txtInteres.Text = interes.ToString();
                txtComision.Text = comision.ToString();
                txtMontoSolic.Text = montoSolicitado.ToString();
                txtMontoAprobado.Text = montoAprob.ToString();
                txtCuotaMes.Text = cuotaMensual.ToString();
                txtCuotaPosible.Text = posibleCuota.ToString();
                txtSalNeto.Text = salNeto.ToString();
                txtSalLibre.Text = porcSalLibre.ToString();
                txtSalCompr.Text = porcSalCompr.ToString();


                if (porcSalLibre > 30)
                {
                    lblMensajeExito.Text = "Aprobado, mayor a 30%";
                }
                else
                {
                    lblMensajeFracaso.Text = "Reprobado, menor a 30%";
                }
            }
            catch (Exception)
            {

                lblMensajeFracaso.Text = "No se han ingresado los datos requeridos";
            }
            
        }

        //CALCULO DEL FIADOR
        protected void btnCalcularFia_Click(object sender, EventArgs e)
        {
            //Se reinician los labels indicadores de fracaso o exito para un nuevo calculo
            lblMensajeExitoFiador.Text = "";
            lblMensajeFracasoFiador.Text = "";

            try
            {
                //Se calculan los datos de solicitante
                btnCalcular_Click(sender, e);

                //Se inicializan todos los valores de la valoracion para el prestamo.
                double plazo = Convert.ToDouble(txtPlazo.Text);
                double interes = Convert.ToDouble(txtInteres.Text);
                double comision = Convert.ToDouble(txtComision.Text);
                double montoSolicitado = Convert.ToDouble(txtMontoSolic.Text);
                double montoAprob = Convert.ToDouble(txtMontoAprobado.Text);
                double cuotaMensual = Convert.ToDouble(txtCuotaMes.Text);
                double posibleCuota = cuotaMensual;
                double salBruto = Convert.ToDouble(txtSalBrutoFia.Text);
                double salNeto = calcSalarioNetoFiador(salBruto, posibleCuota);
                double porcSalLibre = Math.Round((salNeto / salBruto) * 100, 2);
                double porcSalCompr = Math.Round(100 - porcSalLibre, 2);


                //Los resultados de las valoraciones se ingresan a los textboxes
                txtCreditoFia.Text = dpTipoCredito.Text;
                txtMontoSolFia.Text = montoSolicitado.ToString();
                txtPlazoFia.Text = plazo.ToString();
                txtInteresFia.Text = interes.ToString();
                txtComisionFia.Text = comision.ToString();
                txtMontoAprobFia.Text = montoAprob.ToString();
                txtCuotaMesFia.Text = cuotaMensual.ToString();
                txtPosibleCuotaFia.Text = posibleCuota.ToString();
                txtSalNetoFia.Text = salNeto.ToString();
                txtSalLibreFia.Text = porcSalLibre.ToString();
                txtSalCompromFia.Text = porcSalCompr.ToString();


                if (porcSalLibre > 30)
                {
                    lblMensajeExitoFiador.Text = "Aprobado, mayor a 30%";
                }
                else
                {
                    lblMensajeFracasoFiador.Text = "Reprobado, menor a 30%";
                }
            }
            catch (Exception)
            {

                lblMensajeFracasoFiador.Text = "No se han ingresado los datos requeridos";
            }
            
        }

        //LIMPIAR ASOCIADO
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            //Se reinician los labels indicadores de fracaso o exito 
            lblMensajeExito.Text = "";
            lblMensajeFracaso.Text = "";

            txtCedula.Text = "";
            txtPlazo.Text = "";
            txtNombre.Text = "";
            txtInteres.Text = "";
            txtMontoSolic.Text = "";
            txtNumEmpleado.Text = "";
            txtSalBruto.Text = "";
            txtPlazoValor.Text = "";
            txtInteres.Text = "";
            txtComision.Text = "";
            txtDeducciones.Text = "";
            txtCuotaFianzas.Text = "";
            txtMontoSolic.Text = "";
            txtMontoAprobado.Text = "";
            txtCuotaMes.Text = "";
            txtCuotaPosible.Text = "";
            txtSalNeto.Text = "";
            txtSalLibre.Text = "";
            txtSalCompr.Text = "";
        }

        //LIMPIAR FIADOR
        protected void btnLimpiarFiador_Click(object sender, EventArgs e)
        {
            //Se reinician los labels indicadores de fracaso o exito 
            lblMensajeExito.Text = "";
            lblMensajeFracaso.Text = "";

            txtCedulaFia.Text = "";
            txtPlazoFia.Text = "";
            txtNombreFia.Text = "";
            txtInteresFia.Text = "";
            txtMontoSolFia.Text = "";
            txtNumEmpleadoFia.Text = "";
            txtSalBrutoFia.Text = "";
            txtPlazoFia.Text = "";
            txtInteresFia.Text = "";
            txtComisionFia.Text = "";
            txtDeduccionesFia.Text = "";
            txtCuotaFianzasFia.Text = "";
            txtMontoSolFia.Text = "";
            txtMontoAprobFia.Text = "";
            txtCuotaMesFia.Text = "";
            txtPosibleCuotaFia.Text = "";
            txtSalNetoFia.Text = "";
            txtSalLibreFia.Text = "";
            txtSalCompromFia.Text = "";
        }

        private double calcSalarioNeto(double salarioBruto, double posibleCuota)
        {

            //Se saca las deducciones del valor digitado por el usuario
            double deducciones = Convert.ToDouble(txtDeducciones.Text);

            //Se saca la cuota de fianzas del valor digitado por el usuario
            double cuotaFianzas = Convert.ToDouble(txtCuotaFianzas.Text);

            //Se resta del salario bruto las deducciones, cuota de fianzas, y la posible cuota que se recibe como parametro.
            double resultado = Math.Round(salarioBruto - deducciones - cuotaFianzas - posibleCuota, 2);

            //Se devulve el resultado de la operacion
            return resultado;
        }

        private double calcSalarioNetoFiador(double salarioBruto, double posibleCuota)
        {

            //Se saca las deducciones del valor digitado por el usuario
            double deducciones = Convert.ToDouble(txtDeduccionesFia.Text);

            //Se saca la cuota de fianzas del valor digitado por el usuario
            double cuotaFianzas = Convert.ToDouble(txtCuotaFianzasFia.Text);

            //Se resta del salario bruto las deducciones, cuota de fianzas, y la posible cuota que se recibe como parametro.
            double resultado = Math.Round(salarioBruto - deducciones - cuotaFianzas - posibleCuota, 2);

            //Se devulve el resultado de la operacion
            return resultado;
        }

        private double CalcPoliza(double monto)
        {
            double resultado = 0;
            //Se saca el valor seleccionado en el tipo de credito
            string credito = dpTipoCredito.SelectedValue;
            //Segun el valor seleccionado se asigna un porcentaje de comision
            if (credito == "3" || credito == "5")
            {
                resultado = Math.Round(((monto / 1000000)*2168)/12, 2);
            }
            return resultado;
        }

        private double CalcCuotaMes(double monto, double interesAnual, double plazo, double poliza)
        {
            //Se calcula el interes mensual al dividir el interes anual entre 12 meses
            double interesMensual = (interesAnual / 12) / 100;

            //Se calcula la cuota mensual utizando el monto e interes mensual. Y se redondea a dos decimales
            double resultado = Math.Round(monto * interesMensual / (1 - Math.Pow(1 + interesMensual, -plazo)) , 2) + poliza;

            //Se devuelve el resultado de la operacion.
            return resultado;
        }

        private double CalcComision()
        {
            //Se saca el valor del monto solicitado digitado por el usuario
            double monto = Convert.ToDouble(txtMontoSolic.Text);
            //Se inicializa el valor del porcentaje de comision y la comision de cargos
            double prcj = 0;
            double comision = 0;
            //Se saca el valor seleccionado en el tipo de credito
            string credito = dpTipoCredito.SelectedValue;
            //Segun el valor seleccionado se asigna un porcentaje de comision
            if (credito == "3" || credito == "7")
            {
                prcj = 0.015;
            }
            else
            {
                prcj = 0.03;
            }

            //Se devuelve el resultado del monto solicitado x porcentaje de comision.
            comision = Math.Round(monto * prcj, 2);
            return comision;

        }

        private double CalcInteresAnual()
        {
            //Se incializa el valor selecionado en el tipo de credito
            string credito = dpTipoCredito.SelectedValue;
            //Se inicializa la variable de valor de interes, la cual sera el resultado final del metodo
            double valorInteres = 0;

            //Dependiendo del credito se determina el valor de interes.
            if (credito == "1" || credito == "2" || credito == "7")
            {
                valorInteres = 18;
            }
            else if (credito == "3" || credito == "5" || credito == "8" || credito == "9")
            {
                valorInteres = 9;
            }
            else if (credito == "4" || credito == "6")
            {
                valorInteres = 15;
            }
            //Se devuelve el resultado.
            return valorInteres;
        }


        //METODO DE VERIFICACION DE SESION
        private void VerificarSesion()
        {
            //Verifica que el rol del usuario que inicio sesion 
            if (Session["UserRole"].ToString() != "1" && Session["UserRole"].ToString() != "2")
            {
                //Si no es admin (1) ni Secretaria (2) redirija al inicio
                Response.Redirect("Inicio.aspx");
            }
        }


        //METODO DE CERRAR SESION
        //protected void btnCerrarSesion_Click(object sender, EventArgs e)
        //{
        //    //Por medio del onclick 
        //    //Se cierra la autenticacion y se pierden las cookies
        //    FormsAuthentication.SignOut();
        //    //Se redirije a la pagina de login
        //    FormsAuthentication.RedirectToLoginPage();
        //}

        
    }
}