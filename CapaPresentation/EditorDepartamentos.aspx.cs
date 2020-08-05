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
    public partial class EditorDepartamentos : System.Web.UI.Page
    {
        DepartamentosNegocio DepNeg = new DepartamentosNegocio();
        DepartamentosEntidad DepEnt = new DepartamentosEntidad();

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
                if (Session["idDepar"] != null)
                {
                    string cod = Session["idDepar"].ToString();
                    DepEnt = DepNeg.ConsultarDepartamento(cod);
                    {
                        txtIdDepartamento.Text = Session["idDepar"].ToString();
                        txtnombreDepartamento.Text = DepEnt.tipo;
                        btnGrabar.Enabled = false;
                        btnActualizar.Enabled = true;
                        btnCancelar.Enabled = true;
                    }
                }
            //}
            //catch (Exception)
            //{
            //    Response.Redirect("~/CreaDepartamentos.aspx");
            //}
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if (this.txtnombreDepartamento.Text.Trim() != "")
            {
                try
                {

                    DepEnt.tipo = txtnombreDepartamento.Text;
                    DepEnt.estado = 1;
                    if (DepNeg.CrearDepartamento(DepEnt) == true)
                    {
                        lblMensaje.Text = "Registro Guardado Correctamente";
                        Response.Redirect("~/CreaDepartamentos.aspx");
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
            if (this.txtnombreDepartamento.Text.Trim() != "")
            {
                try
                {

                    DepEnt.id = Convert.ToInt32(Session["idDepar"].ToString());
                    DepEnt.tipo = txtnombreDepartamento.Text;
                    DepEnt.estado = 1;
                    if (DepNeg.ModificarDepartamento(DepEnt) == true)
                    {
                        lblMensaje.Text = "Registro Actualizado Correctamente";
                        Session["idDepar"] = null;
                        Response.Redirect("~/CreaDepartamentos.aspx");
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
            Session["idDepar"] = null;
            Response.Redirect("~/CreaDepartamentos.aspx");

        }
    }
}