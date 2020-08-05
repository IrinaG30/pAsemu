using Capa_Negocios;
using CapaEntidad;
using System;
using System.Web.UI;

namespace CapaPresentation
{
    public partial class EditorPuestos : System.Web.UI.Page
    {
        PuestosNegocio PuestosNeg = new PuestosNegocio();
        PuestosEntidad PuestosEnt = new PuestosEntidad();

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
                if (Session["idPuesto"] != null)
                {
                    string cod = Session["idPuesto"].ToString();
                    PuestosEnt = PuestosNeg.ConsultarPuesto(cod);
                    {
                        txtIdPuesto.Text = Session["idPuesto"].ToString();
                        txtPuesto.Text = PuestosEnt.nombres;
                        btnGrabar.Enabled = false;
                        btnActualizar.Enabled = true;
                        btnCancelar.Enabled = true;
                    }
                }
            //}
            //catch (Exception)
            //{
            //    Response.Redirect("~/CreaPuestos.aspx");
            //}
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if (this.txtPuesto.Text.Trim() != "")
            {
                try
                {

                    PuestosEnt.nombres = txtPuesto.Text;
                    PuestosEnt.estado = 1;
                    if (PuestosNeg.CrearPuesto(PuestosEnt) == true)
                    {
                        lblMensaje.Text = "Registro Guardado Correctamente";
                        Response.Redirect("~/CreaPuestos.aspx");
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
            if (this.txtPuesto.Text.Trim() != "")
            {
                try
                {

                    PuestosEnt.id = Convert.ToInt32(Session["idPuesto"].ToString());
                    PuestosEnt.nombres = txtPuesto.Text;
                    PuestosEnt.estado = 1;
                    if (PuestosNeg.ModificarPuesto(PuestosEnt) == true)
                    {
                        lblMensaje.Text = "Registro Actualizado Correctamente";
                        Session["idPuesto"] = null;
                        Response.Redirect("~/CreaPuestos.aspx");
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
            Session["idPuesto"] = null;
            Response.Redirect("~/CreaPuestos.aspx");

        }
    }
}