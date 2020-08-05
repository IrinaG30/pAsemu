using Capa_Negocios;
using CapaEntidad;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentation
{
    public partial class RegistroPagos : System.Web.UI.Page
    {
        RegistroPagosNegocio RegistroNeg = new RegistroPagosNegocio();
        RegistroPagosEntidad RegistroEnt = new RegistroPagosEntidad();

        PlazosNegocio PlazosNeg = new PlazosNegocio();

        EstadoRegPrestamosNegocio EstadoNeg = new EstadoRegPrestamosNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                VerificarSesion();
                CargarDropdownList();
                ListarDatos();
                txtIdPrestamo.Text = Session["idPrestamo"].ToString();
                txtNumPrestamo.Text = Session["numPrestamo"].ToString();
            }
        }

        private void ListarDatos()
        {
            try
            {
                GridViewDatos.DataSource = RegistroNeg.ListarRegistroPago(Session["numPrestamo"].ToString());
                GridViewDatos.DataBind();
            }
            catch (Exception)
            {

            }
        }

        private void BuscarDatos()
        {
            try
            {
                if (Session["idRegistroPrestamo"] != null)
                {
                    int cod = Convert.ToInt32(Session["idRegistroPrestamo"].ToString());

                    RegistroEnt = RegistroNeg.ConsultarRegistroPago(cod);
                    {
                        txtId.Text = RegistroEnt.id.ToString();
                        txtNumPrestamo.Text = RegistroEnt.numPrestamo.ToString();
                        txtNumEmpleado.Text = RegistroEnt.numEmpleado.ToString();
                        txtFechaPago.Text = RegistroEnt.fechPago.ToString();
                        //dpPlazo.SelectedIndex = RegistroEnt.idPla;
                        txtFechaProxPago.Text = RegistroEnt.fechProxPago.ToString();
                        //dpEstado.SelectedIndex = RegistroEnt.idEstad;
                        txtMonto.Text = RegistroEnt.montAPagar.ToString();
                        txtTotal.Text = RegistroEnt.totaPagado.ToString();
                        txtIdPrestamo.Text = RegistroEnt.idPres.ToString();
                    }
                }
            }
            catch (Exception)
            {
                lblMensaje.Text = "Ha ocurrido un error, registro no encontrado";
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.txtNumPrestamo.Text.Trim() != "")
            {
                try
                {

                    RegistroEnt.numPrestamo = Convert.ToInt32(txtNumPrestamo.Text);
                    RegistroEnt.numEmpleado = Convert.ToInt32(txtNumEmpleado.Text);
                    RegistroEnt.fechPago = Convert.ToDateTime(txtFechaPago.Text);
                    RegistroEnt.idPla = Convert.ToInt32(dpPlazo.SelectedValue);
                    
                    if (txtFechaProxPago.Text.Trim() != "")
                    {
                        RegistroEnt.fechProxPago = Convert.ToDateTime(txtFechaProxPago.Text);
                    } 
                    else
                    {
                        RegistroEnt.fechProxPago = null;
                    }

                    RegistroEnt.idEstad = Convert.ToInt32(dpEstado.SelectedValue);
                    RegistroEnt.montAPagar = Convert.ToInt32(txtMonto.Text);
                    RegistroEnt.totaPagado = Convert.ToInt32(txtTotal.Text);
                    RegistroEnt.idPres = Convert.ToInt32(Session["idPrestamo"]);

                    if (RegistroNeg.CrearRegistroPago(RegistroEnt) == true)
                    {
                        lblMensaje.Text = "Registro Guardado Correctamente";
                        ListarDatos();
                        CambiarEstadoPrestamo();
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

        protected void CambiarEstadoPrestamo()
        {
            if (this.txtNumPrestamo.Text.Trim() != "")
            {
                try
                {
                    RegistroEnt.numPrestamo = Convert.ToInt32(txtNumPrestamo.Text);

                    if (txtFechaProxPago.Text.Trim() != "")
                    {
                        RegistroEnt.fechProxPago = Convert.ToDateTime(txtFechaProxPago.Text);
                    }
                    else
                    {
                        RegistroEnt.fechProxPago = null;
                    }

                    if (RegistroNeg.CambiarEstado(RegistroEnt) == true)
                    {
                        lblMensaje.Text = "Registro Guardado Correctamente. Estado de prestamo actualizado";
                        ListarDatos();
                    }
                    else
                    {
                        lblMensaje.Text = "Error de actualización";
                    }
                }
                catch (Exception exc)
                {
                    lblMensaje.Text = exc.Message.ToString();
                }
            }
            else
            {
                lblMensaje.Text = "Número de prestamo es un campo obligatorio.";
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["idPrestamo"] = null;
            Session["numPrestamo"] = null;
            Response.Redirect("~/Prestamos.aspx");
        }

        protected void GridViewDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                short indicefila;
                indicefila = Convert.ToInt16(e.CommandArgument);
                string cod;
                if (indicefila >= 0 & indicefila < GridViewDatos.Rows.Count)
                {
                    cod = GridViewDatos.Rows[indicefila].Cells[1].Text;
                    if (e.CommandName == "Revisar")
                    {
                        Session["idRegistroPrestamo"] = cod;
                        BuscarDatos();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void GridViewDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridViewDatos.PageIndex = e.NewPageIndex;
                GridViewDatos.DataBind();
                ListarDatos();
            }
            catch (Exception)
            {
            }
        }

        //METODO DE RELLENAR DROPDOWN LIST
        private void CargarDropdownList()
        {
            //Se cargan al DropdownList de Puestos, los valores encontrados en la tabla de puestos BD que se encuentren activos
            dpEstado.DataSource = EstadoNeg.ListarEstadoRegPrestamo("");
            dpEstado.DataTextField = "estado";
            dpEstado.DataValueField = "idEstadoRegPrestamos";
            dpEstado.DataBind();

            //Se cargan al DropdownList de plazo, los valores encontrados en la tabla de plazo BD que se encuentren activos
            dpPlazo.DataSource = PlazosNeg.ListarPlazo("");
            dpPlazo.DataTextField = "plazo";
            dpPlazo.DataValueField = "idPlazo";
            dpPlazo.DataBind();
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


    }
}