using Capa_Negocios;
using CapaEntidad;
using System;
using System.Web.UI;

namespace CapaPresentation
{
    public partial class PruebaRoles : System.Web.UI.Page
    {
        RolesNegocio RolesNeg = new RolesNegocio();
        RolesEntidad RolesEnt = new RolesEntidad();

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
                if (Session["idRol"] != null)
                {
                    string cod = Session["idRol"].ToString();
                    RolesEnt = RolesNeg.ConsultarRol(cod);
                    {
                        txtIdRol.Text = Session["idRol"].ToString();
                        txtTipoRol.Text = RolesEnt.tipo;
                        btnGrabar.Enabled = false;
                        btnActualizar.Enabled = true;
                        btnCancelar.Enabled = true;
                    }
                }
            //}
            //catch (Exception)
            //{
            //    Response.Redirect("~/CreaRoles.aspx");
            //}
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if ( this.txtTipoRol.Text.Trim() != "")
            {
                try
                {
                    
                    RolesEnt.tipo = txtTipoRol.Text;
                    RolesEnt.estado = 1;
                    if (RolesNeg.CrearRol(RolesEnt) == true)
                    {
                        lblMensaje.Text = "Registro Guardado Correctamente";
                        Response.Redirect("~/CreaRoles.aspx");
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
            if (this.txtTipoRol.Text.Trim() != "")
            {
                try
                {

                    RolesEnt.id = Convert.ToInt32(Session["idRol"].ToString());
                    RolesEnt.tipo = txtTipoRol.Text;
                    RolesEnt.estado = 1;
                    if (RolesNeg.ModificarRol(RolesEnt) == true)
                    {
                        lblMensaje.Text = "Registro Actualizado Correctamente";
                        Session["idRol"] = null;
                        Response.Redirect("~/CreaRoles.aspx");
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
            Session["idRol"] = null;
            Response.Redirect("~/CreaRoles.aspx");

        }
    }
}