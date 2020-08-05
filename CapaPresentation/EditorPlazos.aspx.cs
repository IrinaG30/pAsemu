using Capa_Negocios;
using CapaEntidad;
using System;
using System.Web.UI;

namespace CapaPresentation
{
    public partial class EditorPlazos : System.Web.UI.Page
    {
        PlazosNegocio PlazosNeg = new PlazosNegocio();
        PlazosEntidad PlazosEnt = new PlazosEntidad();

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
                if (Session["idPlazo"] != null)
                {
                    string cod = Session["idPlazo"].ToString();
                    PlazosEnt = PlazosNeg.ConsultarPlazo(cod);
                    {
                        txtIdPlazo.Text = Session["idPlazo"].ToString();
                        txtPlazo.Text = PlazosEnt.plazos;
                        btnGrabar.Enabled = false;
                        btnActualizar.Enabled = true;
                        btnCancelar.Enabled = true;
                    }
                }
            //}
            //catch (Exception)
            //{
            //    Response.Redirect("~/CreaPlazos.aspx");
            //}
        }


        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if (this.txtPlazo.Text.Trim() != "")
            {
                try
                {



                    PlazosEnt.plazos = txtPlazo.Text;
                    PlazosEnt.estado = 1;
                    if (PlazosNeg.CrearPlazo(PlazosEnt) == true)
                    {
                        lblMensaje.Text = "Registro Guardado Correctamente";
                        Response.Redirect("~/CreaPlazos.aspx");
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
            if (this.txtPlazo.Text.Trim() != "")
            {
                try
                {



                    PlazosEnt.id = Convert.ToInt32(Session["idPlazo"].ToString());
                    PlazosEnt.plazos = txtPlazo.Text;
                    PlazosEnt.estado = 1;
                    if (PlazosNeg.ModificarPlazo(PlazosEnt) == true)
                    {
                        lblMensaje.Text = "Registro Actualizado Correctamente";
                        Session["idPlazo"] = null;
                        Response.Redirect("~/CreaPlazos.aspx");
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


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }


        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["idPlazo"] = null;
            Response.Redirect("~/CreaPlazos.aspx");

        }
    }
}