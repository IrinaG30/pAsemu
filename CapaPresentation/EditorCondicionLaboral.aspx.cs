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
    public partial class EditorCondicionLaboral : System.Web.UI.Page
    {
        CondicionLaboralNegocio CLNego = new CondicionLaboralNegocio();
        CondicionLaboralEntidad CLEntid = new CondicionLaboralEntidad();

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
                if (Session["idCondicionLaboral"] != null)
                {
                    string cod = Session["idCondicionLaboral"].ToString();
                    CLEntid = CLNego.BuscarCondicionLaboral(cod);
                    {
                        txtIDCL.Text = Session["idCondicionLaboral"].ToString();
                        txtNombre.Text = CLEntid.nom;
                        btnGuardar.Enabled = false;
                        btnActualizar.Enabled = true;
                        btnCancelar.Enabled = true;
                    }
                }
            //}
            //catch (Exception)
            //{
            //    Response.Redirect("~/CreaCondicionLaboral.aspx");
            //}
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if (this.txtNombre.Text.Trim() != "")
            {
                try
                {

                    CLEntid.nom = txtNombre.Text;
                    CLEntid.idEstado = 1;
                    if (CLNego.CrearCondicionLaboral(CLEntid) == true)
                    {
                        lblMensaje.Text = "Registro Guardado Correctamente";
                        Response.Redirect("~/CreaCondicionLaboral.aspx");
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
            if (this.txtNombre.Text.Trim() != "")
            {
                try
                {
                    CLEntid.id = Convert.ToInt32(Session["idCondicionLaboral"].ToString());
                    CLEntid.nom = txtNombre.Text;


                    if (CLNego.ModificarCondicionLaboral(CLEntid) == true)
                    {
                        lblMensaje.Text = "Registro Actualizado Correctamente";
                        Session["idCondicionLaboral"] = null;
                        Response.Redirect("~/CreaCondicionLaboral.aspx");
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
            Session["idCondicionLaboral"] = null;
            Response.Redirect("~/CreaCondicionLaboral.aspx");
        }
    }
}