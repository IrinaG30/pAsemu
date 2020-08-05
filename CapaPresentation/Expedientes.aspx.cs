using Capa_Negocios;
using CapaEntidad;
using System;
using System.Web.Security;
using System.Web.UI;

namespace CapaPresentation
{
    public partial class Expedientes : System.Web.UI.Page
    {
        ExpedientesNegocio expedienteNeg = new ExpedientesNegocio();
        ExpedientesEntidad expedienteEnt = new ExpedientesEntidad();

        PuestosNegocio PuestosNeg = new PuestosNegocio();

        DepartamentosNegocio DepaNeg = new DepartamentosNegocio();

        CondicionLaboralNegocio CLNeg = new CondicionLaboralNegocio();

        ExpedientesNegocio exp = new ExpedientesNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Ejecuta esta linea si viene de otra pagina
            if (!Page.IsPostBack)
            {
                VerificarSesion();
                CargarDropdownList();
            }
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //Se evalua si la casilla del numero de prestamo tiene un valor
                if (txtCedula != null)
                {
                    //Con el numero ingresado en el numero de prestamo se hace una consulta de los prestamos almacenados
                    string numEmp = txtNumEmpleado.Text;
                    expedienteEnt = expedienteNeg.ConsultarExpedientes(numEmp);
                    {
                        //Se rellenan los textbox con los valores del prestamo consultado
                        txtId.Text = expedienteEnt.id.ToString();
                        txtCedula.Text = expedienteEnt.cedula.ToString();
                        txtNumEmpleado.Text = numEmp;
                        txtNombre.Text = expedienteEnt.nomAsociado.ToString();
                        txtApellido1.Text = expedienteEnt.ape1.ToString();
                        txtApellido2.Text = expedienteEnt.ape2.ToString();
                        txtTel.Text = expedienteEnt.tel.ToString();
                        txtDireccion.Text = expedienteEnt.dire.ToString();
                        txtCorreo.Text = expedienteEnt.correoElectr.ToString();
                        txtFechaI.Text = expedienteEnt.feIngreso.ToString();
                        txtFechaS.Text = expedienteEnt.feSalida.ToString();
                        txtTiempo.Text = expedienteEnt.tiemAfiliado.ToString();
                        txtNumCuenta.Text = expedienteEnt.numCuenta.ToString();
                        dlEstado.Text = expedienteEnt.idEstado.ToString();


                        //Se desactiva el boton de guardar prestamos, puesto que el prestamo existe
                        btnGuardar.Enabled = false;
                        // btnActualizar.Enabled = true;
                        //btnRegistrarPago.Enabled = true;
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
            //si la cedula no esta vacia 
            if (this.txtCedula.Text.Trim() != "")
            {
                try
                {
                    //se almacenan los datos ingresados a la entidad de expedientes

                    expedienteEnt.cedula = Convert.ToInt32(txtCedula.Text);
                    expedienteEnt.numEmple = Convert.ToInt32(txtNumEmpleado.Text);
                    expedienteEnt.nomAsociado = (txtNombre.Text);
                    expedienteEnt.ape1 = (txtApellido1.Text);
                    expedienteEnt.ape2 = (txtApellido2.Text);
                    expedienteEnt.tel = Convert.ToInt32(txtTel.Text);
                    expedienteEnt.dire = (txtDireccion.Text);
                    expedienteEnt.correoElectr = (txtCorreo.Text);
                    expedienteEnt.idPues = Convert.ToInt32(dlPuesto.SelectedValue);
                    expedienteEnt.idDepar = Convert.ToInt32(dlDepa.SelectedValue);
                    expedienteEnt.feIngreso = Convert.ToDateTime(txtFechaI.Text);
                    expedienteEnt.feSalida = Convert.ToDateTime(txtFechaS.Text);
                    expedienteEnt.idCondiLab = Convert.ToInt32(dlCon.SelectedValue);
                    expedienteEnt.tiemAfiliado = Convert.ToString(txtTiempo.Text);
                    expedienteEnt.numCuenta = Convert.ToInt32(txtNumCuenta.Text);
                    expedienteEnt.idEstado = Convert.ToInt32(dlEstado.Text);

                    // se ejectuta desde la capa de negocio el procedimiento crear expedientes
                    if (expedienteNeg.CrearExpedientes(expedienteEnt) == true)
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
                    // en caso de que no se pueda almacenar los datos en la entidad se muestra un mensaje expecificando el error
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
            if (this.txtNumEmpleado.Text.Trim() != "" && this.txtCedula.Text.Trim() != "")
            {
                try
                {

                    //se almacenan los datos ingresados a la entidad de expedientes

                    expedienteEnt.cedula = Convert.ToInt32(txtCedula.Text);
                    expedienteEnt.numEmple = Convert.ToInt32(txtNumEmpleado.Text);
                    expedienteEnt.nomAsociado = (txtNombre.Text);
                    expedienteEnt.ape1 = (txtApellido1.Text);
                    expedienteEnt.ape2 = (txtApellido2.Text);
                    expedienteEnt.tel = Convert.ToInt32(txtTel.Text);
                    expedienteEnt.dire = (txtDireccion.Text);
                    expedienteEnt.correoElectr = (txtCorreo.Text);
                    expedienteEnt.idPues = Convert.ToInt32(dlPuesto.SelectedValue);
                    expedienteEnt.idDepar = Convert.ToInt32(dlDepa.SelectedValue);
                    expedienteEnt.feIngreso = Convert.ToDateTime(txtFechaI.Text);
                    expedienteEnt.feSalida = Convert.ToDateTime(txtFechaS.Text);
                    expedienteEnt.idCondiLab = Convert.ToInt32(dlCon.SelectedValue);
                    expedienteEnt.tiemAfiliado = Convert.ToString(txtTiempo.Text);
                    expedienteEnt.numCuenta = Convert.ToInt32(txtNumCuenta.Text);
                    expedienteEnt.idEstado = Convert.ToInt32(dlEstado.Text);



                    if (expedienteNeg.ModificarExpedientes(expedienteEnt) == true)
                    {
                        lblMensaje.Text = "Registro Actualizado Correctamente";
                    }
                    else
                    {
                        lblMensaje.Text = "Error de Actualización de datos";
                    }

                }
                catch (Exception ee)
                {
                    lblMensaje.Text = ee.Message.ToString();
                }
            }
            else
            {
                lblMensaje.Text = "Todo los Campos son Obligatorios.";
            }
        }

        protected void CalendarI_SelectionChanged(object sender, EventArgs e)
        {
            //la fecha seleccionada se muestra en el textbox correspondientes
            String fechaI = CalendarI.SelectedDate.ToString("yyyy-MM-dd HH:mm:ss");
            txtFechaI.Text = fechaI;
        }

        protected void CalendarS_SelectionChanged(object sender, EventArgs e)
        {
            //la fecha seleccionada se muestra en el textbox correspondientes
            String fechaS = CalendarI.SelectedDate.ToString("yyyy-MM-dd HH:mm:ss");
            txtFechaS.Text = fechaS;
        }

        //METODO PARA 
        private void CargarDropdownList()
        {
            //Se cargan al DropdownList de Puestos, los valores encontrados en la tabla de puestos BD que se encuentren activos
            dlPuesto.DataSource = PuestosNeg.ListarPuesto("");
            dlPuesto.DataTextField = "nombre";
            dlPuesto.DataValueField = "idPuesto";
            dlPuesto.DataBind();


            //Se cargan al DropdownList de Credito, los valores encontrados en la tabla de Credito BD que se encuentren activos
            dlDepa.DataSource = DepaNeg.ListarDepartamento("");
            dlDepa.DataTextField = "nombreDepartamento";
            dlDepa.DataValueField = "idDepartamento";
            dlDepa.DataBind();

            //Se cargan al DropdownList de plazo, los valores encontrados en la tabla de plazo BD que se encuentren activos
            dlCon.DataSource = CLNeg.ListarCondicionLab("");
            dlCon.DataTextField = "nombre";
            dlCon.DataValueField = "idCondicionLaboral";
            dlCon.DataBind();


        }

        //METODO DE VERIFICAR SESION
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