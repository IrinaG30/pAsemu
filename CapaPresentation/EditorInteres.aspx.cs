using Capa_Negocios;
using CapaEntidad;
using System;
using System.Web.UI;

namespace CapaPresentation
{
    public partial class EditorInteres : System.Web.UI.Page
    {
        InteresNegocio InteresNeg = new InteresNegocio();
        InteresEntidad InteresEnt = new InteresEntidad();

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
                if (Session["idInteres"] != null)
                {
                    string cod = Session["idInteres"].ToString();
                    InteresEnt = InteresNeg.ConsultarInteres(cod);
                    {
                        txtIdInteres.Text = Session["idInteres"].ToString();
                        txtPorcentaje.Text = Convert.ToString(InteresEnt.porcentaje);
                        txtTipoInteres.Text = Convert.ToString(InteresEnt.tipo);
                        btnGrabar.Enabled = false;
                        btnActualizar.Enabled = true;
                        btnCancelar.Enabled = true;
                    }
                }
            //}
            //catch (Exception)
            //{
            //    Response.Redirect("~/CreaInteres.aspx");
            //}
        }


        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if (this.txtPorcentaje.Text.Trim() != "" && this.txtTipoInteres.Text.Trim() != "")
            {
                try
                {
                    InteresEnt.porcentaje = Convert.ToInt32(txtPorcentaje.Text);
                    InteresEnt.tipo = Convert.ToString(txtTipoInteres.Text);
                    InteresEnt.estado = 1;
                    if (InteresNeg.CrearInteres(InteresEnt) == true)
                    {
                        lblMensaje.Text = "Registro Guardado Correctamente";
                        Response.Redirect("~/CreaInteres.aspx");
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
            if (this.txtPorcentaje.Text.Trim() != "" && this.txtTipoInteres.Text.Trim() != "")
            {
                try
                {
                    InteresEnt.id = Convert.ToInt32(Session["idInteres"].ToString());
                    InteresEnt.porcentaje = Convert.ToInt32(txtPorcentaje.Text);
                    InteresEnt.tipo = Convert.ToString(txtTipoInteres.Text);
                    InteresEnt.estado = 1;
                    if (InteresNeg.ModificarInteres(InteresEnt) == true)
                    {
                        lblMensaje.Text = "Registro Actualizado Correctamente";
                        Session["idInteres"] = null;
                        Response.Redirect("~/CreaInteres.aspx");
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
            Session["idInteres"] = null;
            Response.Redirect("~/CreaInteres.aspx");

        }
    }
}