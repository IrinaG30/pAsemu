using Capa_Negocios;
using CapaEntidad;
using System;
using System.Web.UI;

namespace CapaPresentation
{
    public partial class EditorEstadoRegPrestamo : System.Web.UI.Page
    {
        EstadoRegPrestamosNegocio estadoRegPrestamosNeg = new EstadoRegPrestamosNegocio();
        EstadoRegPrestamosEntidad estadoRegPrestamosEnt = new EstadoRegPrestamosEntidad();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MostrarDatos();
            }
        }

        private void MostrarDatos()
        {
            //try
            //{
                if (Session["idEstado"] != null)
                {
                    string cod = Session["idEstado"].ToString();
                    estadoRegPrestamosEnt = estadoRegPrestamosNeg.ConsultarEstadoRegPrestamo(cod);
                    {
                        txtIdEstado.Text = Session["idEstado"].ToString();
                        txtEstado.Text = estadoRegPrestamosEnt.tipoEstado;
                        btnGrabar.Enabled = false;
                        btnActualizar.Enabled = true;
                        btnCancelar.Enabled = true;
                    }
                }
            //}
            //catch (Exception)
            //{
            //    Response.Redirect("~/CreaEstadoRegPrestamos.aspx");
            //}
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if (this.txtEstado.Text.Trim() != "")
            {
                try
                {

                    estadoRegPrestamosEnt.tipoEstado = txtEstado.Text;
                    if (estadoRegPrestamosNeg.CrearEstadoRegPrestamo(estadoRegPrestamosEnt) == true)
                    {
                        lblMensaje.Text = "Registro Guardado Correctamente";
                        Response.Redirect("~/CreaEstadoRegPrestamos.aspx");
                    }
                    //else
                    //{
                    //    lblMensaje.Text = "Error de grabación de datos";
                    //}
                }
                catch (Exception exc)
                {
                    lblMensaje.Text = exc.Message.ToString();
                }
            }
            //else
            //{
            //    lblMensaje.Text = "Todo los Campos son Obligatorios.";
            //}
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.txtEstado.Text.Trim() != "")
            {
                try
                {

                    estadoRegPrestamosEnt.id = Convert.ToInt32(Session["idEstado"].ToString());
                    estadoRegPrestamosEnt.tipoEstado = txtEstado.Text;

                    if (estadoRegPrestamosNeg.ModificarEstadoRegPrestamo(estadoRegPrestamosEnt) == true)
                    {
                        lblMensaje.Text = "Registro Actualizado Correctamente";
                        Session["idEstado"] = null;
                        Response.Redirect("~/CreaEstadoRegPrestamos.aspx");
                    }
                    //else
                    //{
                    //    lblMensaje.Text = "Error de Actualización de datos";
                    //}

                }
                catch (Exception exc)
                {
                    lblMensaje.Text = exc.Message.ToString();
                }
            }
            //else
            //{
            //    lblMensaje.Text = "Todo los Campos son Obligatorios.";
            //}
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["idEstado"] = null;
            Response.Redirect("~/CreaEstadoRegPrestamos.aspx");

        }


    }
}