using Capa_Negocios;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentation
{
    public partial class EditorTipoCreditos : System.Web.UI.Page
    {
        TipoCreditosNegocio TipoCreditoNeg = new TipoCreditosNegocio();
        TipoCreditosEntidad TipoCreditoEnt = new TipoCreditosEntidad();

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
                if (Session["idTipoCredito"] != null)
                {
                    string cod = Session["idTipoCredito"].ToString();
                    TipoCreditoEnt = TipoCreditoNeg.ConsultarTipoCredito(cod);
                    {
                        txtIdTipoCredito.Text = Session["idTipoCredito"].ToString();
                        txtnombreCredito.Text = TipoCreditoEnt.nomCredito;
                        btnGrabar.Enabled = false;
                        btnActualizar.Enabled = true;
                        btnCancelar.Enabled = true;
                    }
                }
            //}
            //catch (Exception)
            //{
            //    Response.Redirect("~/CreaTipoCredito.aspx");
            //}
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if (this.txtnombreCredito.Text.Trim() != "")
            {
                try
                {

                    TipoCreditoEnt.nomCredito = txtnombreCredito.Text;
                    TipoCreditoEnt.estado = 1;
                    if (TipoCreditoNeg.CrearTipoCredito(TipoCreditoEnt) == true)
                    {
                        lblMensaje.Text = "Registro Guardado Correctamente";
                        Response.Redirect("~/CreaTipoCredito.aspx");
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
            if (this.txtnombreCredito.Text.Trim() != "")
            {
                try
                {

                    TipoCreditoEnt.id = Convert.ToInt32(Session["idTipoCredito"].ToString());
                    TipoCreditoEnt.nomCredito = txtnombreCredito.Text;
                    TipoCreditoEnt.estado = 1;
                    if (TipoCreditoNeg.ModificarTipoCredito(TipoCreditoEnt) == true)
                    {
                        lblMensaje.Text = "Registro Actualizado Correctamente";
                        Session["idTipoCredito"] = null;
                        Response.Redirect("~/CreaTipoCredito.aspx");
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
            Session["idTipoCredito"] = null;
            Response.Redirect("~/CreaTipoCredito.aspx");

        }
    }
}