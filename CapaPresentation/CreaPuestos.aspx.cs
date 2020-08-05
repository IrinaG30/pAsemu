using Capa_Negocios;
using CapaEntidad;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentation
{
    public partial class CreaPuestos : System.Web.UI.Page
    {
        PuestosNegocio PuestosNeg = new PuestosNegocio();
        PuestosEntidad PuestosEnt = new PuestosEntidad();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Ejecuta esta linea si viene de otra pagina
                if (!Page.IsPostBack)
                {
                    VerificarSesion();
                    ListarDatos();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        private void ListarDatos()
        {
            try
            {
                GridViewDatos.DataSource = PuestosNeg.ListarPuesto(txtPuesto.Text);
                GridViewDatos.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void btnNuevoPuesto_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EditorPuestos.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarDatos();
        }

        protected void GridViewDatos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //try
            //{
                GridViewRow row = GridViewDatos.Rows[e.RowIndex];
                string cod = Convert.ToString(row.Cells[2].Text);

                {
                    PuestosEnt.id = Convert.ToInt32(cod);
                }
                if (PuestosNeg.EliminarPuesto(PuestosEnt) == true)
                {
                    ListarDatos();
                }
                else
                {
                }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
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
                    cod = GridViewDatos.Rows[indicefila].Cells[2].Text;
                    if (e.CommandName == "Actualizar")
                    {
                        Session["idPuesto"] = cod;
                        Response.Redirect("~/EditorPuestos.aspx");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void GridViewDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //try
            //{
                GridViewDatos.PageIndex = e.NewPageIndex;
                GridViewDatos.DataBind();
                ListarDatos();
            //}
            //catch (Exception)
            //{
            //}
        }


        private void VerificarSesion()
        {

            //Verifica que el rol del usuario que inicio sesion 
            if (Session["UserRole"].ToString() != "1")
            {
                //Si no es admin (1) redirija al inicio
                Response.Redirect("Inicio.aspx");
            }
        }


        //METODO DE CERRAR SESION
        //protected void btnCerrarSesion_Click(object sender, EventArgs e)
        //{
        //    //Por medio del onclick 
        //    //Se cierra la autenticacion y se pierden las cookies
        //    FormsAuthentication.SignOut();
        //    //Se redirije a la pagina de login
        //    FormsAuthentication.RedirectToLoginPage();
        //}
    }
}