using Capa_Negocios;
using CapaEntidad;
using System;
using System.Web.UI;

namespace CapaPresentation
{
    public partial class EditorFiadores : System.Web.UI.Page
    {
        FiadoresNegocio FiadoresNeg = new FiadoresNegocio();
        FiadoresEntidad FiadoresEnt = new FiadoresEntidad();

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
                if (Session["idFiador"] != null)
                {
                    string cod = Session["idFiador"].ToString();
                    FiadoresEnt = FiadoresNeg.ConsultarFiador(cod);
                    {
                        txtIdFiadores.Text = Session["idFiador"].ToString();
                        txtFiador.Text = FiadoresEnt.tipo;
                        btnGrabar.Enabled = false;
                        btnActualizar.Enabled = true;
                        btnCancelar.Enabled = true;
                    }
                }
            //}
            //catch (Exception)
            //{
            //    Response.Redirect("~/CreaFiadores.aspx");
            //}
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if (this.txtFiador.Text.Trim() != "")
            {
                try
                {

                    FiadoresEnt.tipo = txtFiador.Text;
                    FiadoresEnt.estado = 1;
                    if (FiadoresNeg.CrearFiador(FiadoresEnt) == true)
                    {
                        lblMensaje.Text = "Registro Guardado Correctamente";
                        Response.Redirect("~/CreaFiadores.aspx");
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
            if (this.txtFiador.Text.Trim() != "")
            {
                try
                {

                    FiadoresEnt.id = Convert.ToInt32(Session["idFiador"].ToString());
                    FiadoresEnt.tipo = txtFiador.Text;
                    FiadoresEnt.estado = 1;
                    if (FiadoresNeg.ModificarFiador(FiadoresEnt) == true)
                    {
                        lblMensaje.Text = "Registro Actualizado Correctamente";
                        Session["idFiador"] = null;
                        Response.Redirect("~/CreaFiadores.aspx");
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
            Session["idFiador"] = null;
            Response.Redirect("~/CreaFiadores.aspx");

        }
    }
}