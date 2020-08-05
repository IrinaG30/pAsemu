using Capa_Negocios;
using CapaEntidad;
using System;
using System.Web.Security;
using System.Web.UI;

namespace CapaPresentation
{
    public partial class Prestamos : System.Web.UI.Page
    {
        PrestamosNegocio PrestamosNeg = new PrestamosNegocio();
        PrestamosEntidad PrestamosEnt = new PrestamosEntidad();

        PuestosNegocio PuestosNeg = new PuestosNegocio();

        PlazosNegocio PlazosNeg = new PlazosNegocio();

        InteresNegocio InteresNeg = new InteresNegocio();

        FiadoresNegocio FiadoresNeg = new FiadoresNegocio();

        TipoCreditosNegocio TipoCreditosNeg = new TipoCreditosNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Ejecuta esta linea si viene de otra pagina
            if (!Page.IsPostBack)
            {
                CargarDropdownList();
                VerificarSesion();
                btnActualizar.Enabled = false;
                btnRegistrarPago.Enabled = false;
            }
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //Se evalua si la casilla del numero de prestamo tiene un valor
                if (txtNumPrestamo != null)
                {
                    //Con el numero ingresado en el numero de prestamo se hace una consulta de los prestamos almacenados
                    string numPres = txtNumPrestamo.Text;
                    PrestamosEnt = PrestamosNeg.BuscarPrestamo(numPres);
                    {
                        //Se rellenan los textbox con los valores del prestamo consultado
                        txtId.Text = PrestamosEnt.idPrestamos.ToString();
                        txtNumPrestamo.Text = numPres;
                        txtCedula.Text = PrestamosEnt.cedAsociado.ToString();
                        txtNumEmpleado.Text = PrestamosEnt.numEmpleado.ToString();
                        txtNumCuenta.Text = PrestamosEnt.numCuenta.ToString();
                        txtMontoCuota.Text = PrestamosEnt.montoCuot.ToString();
                        txtFecha1.Text = PrestamosEnt.fechaInci.ToString();
                        txtFecha2.Text = PrestamosEnt.fechaFina.ToString();
                        txtMontoSol.Text = PrestamosEnt.montSolicitado.ToString();
                        txtMontoPagar.Text = PrestamosEnt.monAPagar.ToString();
                        txtSalBruto.Text = PrestamosEnt.salBruto.ToString();
                        txtSalNeto.Text = PrestamosEnt.salNeto.ToString();
                        txtCuotaFianza.Text = PrestamosEnt.coutFianza.ToString();
                        txtComision.Text = PrestamosEnt.comiCargos.ToString();
                        txtEstado.Text = PrestamosEnt.estados;


                        //Se desactiva el boton de guardar prestamos, puesto que el prestamo existe
                        btnGuardar.Enabled = false;
                        btnActualizar.Enabled = true;
                        btnRegistrarPago.Enabled = true;
                    }
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alertaError", "window.onload = function() { alert('Opps!! Parece que este numero de prestamo, no esta asociado a ningun prestamo resgistrado'); }", true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.txtNumPrestamo.Text.Trim() != "")
            {
                try
                {


                    PrestamosEnt.numPrestamo = Convert.ToInt32(txtNumPrestamo.Text);
                    PrestamosEnt.cedAsociado = Convert.ToInt32(txtCedula.Text);
                    PrestamosEnt.numEmpleado = Convert.ToInt32(txtNumEmpleado.Text);
                    PrestamosEnt.idPuestos = Convert.ToInt32(dpPuesto.SelectedValue);
                    PrestamosEnt.numCuenta = Convert.ToInt32(txtNumCuenta.Text);
                    PrestamosEnt.idTipoCreditos = Convert.ToInt32(dpCredito.SelectedValue);
                    PrestamosEnt.idPlazos = Convert.ToInt32(dpPlazo.SelectedValue);
                    PrestamosEnt.montoCuot = Convert.ToInt32(txtMontoCuota.Text);
                    PrestamosEnt.fechaInci = Convert.ToDateTime(txtFecha1.Text);
                    PrestamosEnt.fechaFina = Convert.ToDateTime(txtFecha2.Text);
                    PrestamosEnt.idIntere = Convert.ToInt32(dpInteres.SelectedValue);
                    PrestamosEnt.idTipFiador = Convert.ToInt32(dpFiador.SelectedValue);
                    PrestamosEnt.montSolicitado = Convert.ToInt32(txtMontoSol.Text);
                    PrestamosEnt.monAPagar = Convert.ToInt32(txtMontoPagar.Text);
                    PrestamosEnt.salBruto = Convert.ToInt32(txtSalBruto.Text);
                    PrestamosEnt.salNeto = Convert.ToInt32(txtSalNeto.Text);
                    PrestamosEnt.coutFianza = Convert.ToInt32(txtCuotaFianza.Text);
                    PrestamosEnt.comiCargos = Convert.ToInt32(txtComision.Text);
                    PrestamosEnt.estados = txtEstado.Text;


                    if (PrestamosNeg.InsertarPrestamo(PrestamosEnt) == true)
                    {
                        lblMensaje.Text = "Registro Guardado Correctamente";
                    }
                    else
                    {
                        lblMensaje.Text = "Error de grabación de datos";
                    }
                }
                catch (Exception exc)
                {
                    lblMensaje.Text = exc.Message.ToString();
                }
            }
            else
            {
                lblMensaje.Text = "Todo los Campos son Obligatorios.";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.txtNumPrestamo.Text.Trim() != "")
            {
                try
                {

                    PrestamosEnt.idPrestamos = Convert.ToInt32(txtId.Text);
                    PrestamosEnt.numPrestamo = Convert.ToInt32(txtNumPrestamo.Text);
                    PrestamosEnt.cedAsociado = Convert.ToInt32(txtCedula.Text);
                    PrestamosEnt.numEmpleado = Convert.ToInt32(txtNumEmpleado.Text);
                    PrestamosEnt.idPuestos = Convert.ToInt32(dpPuesto.SelectedValue);
                    PrestamosEnt.numCuenta = Convert.ToInt32(txtNumCuenta.Text);
                    PrestamosEnt.idTipoCreditos = Convert.ToInt32(dpCredito.SelectedValue);
                    PrestamosEnt.idPlazos = Convert.ToInt32(dpPlazo.SelectedValue);
                    PrestamosEnt.montoCuot = Convert.ToInt32(txtMontoCuota.Text);
                    PrestamosEnt.fechaInci = Convert.ToDateTime(txtFecha1.Text);
                    PrestamosEnt.fechaFina = Convert.ToDateTime(txtFecha2.Text);
                    PrestamosEnt.idIntere = Convert.ToInt32(dpInteres.SelectedValue);
                    PrestamosEnt.idTipFiador = Convert.ToInt32(dpFiador.SelectedValue);
                    PrestamosEnt.montSolicitado = Convert.ToInt32(txtMontoSol.Text);
                    PrestamosEnt.monAPagar = Convert.ToInt32(txtMontoPagar.Text);
                    PrestamosEnt.salBruto = Convert.ToInt32(txtSalBruto.Text);
                    PrestamosEnt.salNeto = Convert.ToInt32(txtSalNeto.Text);
                    PrestamosEnt.coutFianza = Convert.ToInt32(txtCuotaFianza.Text);
                    PrestamosEnt.comiCargos = Convert.ToInt32(txtComision.Text);
                    PrestamosEnt.estados = txtEstado.Text;



                    if (PrestamosNeg.ActualizarPrestamo(PrestamosEnt) == true)
                    {
                        lblMensaje.Text = "Registro Actualizado Correctamente";
                    }
                    else
                    {
                        lblMensaje.Text = "Error de Actualización de datos";
                    }

                }
                catch (Exception exc)
                {
                    lblMensaje.Text = exc.Message.ToString();
                }
            }
            else
            {
                lblMensaje.Text = "Todo los Campos son Obligatorios.";
            }
        }

        protected void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            //Se envian los campos de numPrestamo y idPrestamo al registro de pagos por medio de sessiones
            Session["numPrestamo"] = txtNumPrestamo.Text;
            Session["idPrestamo"] = txtId.Text;
            Response.Redirect("~/RegistroPagos.aspx");
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            //Se rellenan los textbox con los valores del prestamo consultado
            txtId.Text = "";
            txtNumPrestamo.Text = "";
            txtCedula.Text = "";
            txtNumEmpleado.Text = ""; 
            txtNumCuenta.Text = "";
            txtMontoCuota.Text = "";
            txtFecha1.Text = "";
            txtFecha2.Text = "";
            txtMontoSol.Text = "";
            txtMontoPagar.Text = "";
            txtSalBruto.Text = "";
            txtSalNeto.Text = "";
            txtCuotaFianza.Text = "";
            txtComision.Text = "";
            txtEstado.Text = "";


            //Se activa el boton de guardar prestamos, y se desactivan los botones restantes
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            btnRegistrarPago.Enabled = false;
        }

        //METODO PARA CARGAR LAS LISTAS DROPDOWN    
        private void CargarDropdownList()
        {
            //Se cargan al DropdownList de Puestos, los valores encontrados en la tabla de puestos BD que se encuentren activos
            dpPuesto.DataSource = PuestosNeg.ListarPuesto("");
            dpPuesto.DataTextField = "nombre";
            dpPuesto.DataValueField = "idPuesto";
            dpPuesto.DataBind();

            //Se cargan al DropdownList de Credito, los valores encontrados en la tabla de Credito BD que se encuentren activos
            dpCredito.DataSource = TipoCreditosNeg.ListarTipoCredito("");
            dpCredito.DataTextField = "nombreCredito";
            dpCredito.DataValueField = "idTipoCredito";
            dpCredito.DataBind();

            //Se cargan al DropdownList de plazo, los valores encontrados en la tabla de plazo BD que se encuentren activos
            dpPlazo.DataSource = PlazosNeg.ListarPlazo("");
            dpPlazo.DataTextField = "plazo";
            dpPlazo.DataValueField = "idPlazo";
            dpPlazo.DataBind();

            //Se cargan al DropdownList de Interes, los valores encontrados en la tabla de Interes BD que se encuentren activos
            dpInteres.DataSource = InteresNeg.ListarInteres("");
            dpInteres.DataTextField = "tipoInteres";
            dpInteres.DataValueField = "idInteres";
            dpInteres.DataBind();

            //Se cargan al DropdownList de Fiador, los valores encontrados en la tabla de Fiador BD que se encuentren activos
            dpFiador.DataSource = FiadoresNeg.ListarFiadores("");
            dpFiador.DataTextField = "tipoFiador";
            dpFiador.DataValueField = "idTipoFiador";
            dpFiador.DataBind();
        }

        //METODO DE VERIFICAR SESION ROL
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