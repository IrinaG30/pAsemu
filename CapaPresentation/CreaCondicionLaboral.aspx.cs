using Capa_Negocios;
using CapaEntidad;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentation
{
    public partial class CreaCondicionLaboral : System.Web.UI.Page
    {
        CondicionLaboralNegocio CLNego = new CondicionLaboralNegocio();
        CondicionLaboralEntidad CLEntid = new CondicionLaboralEntidad();

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
                GridViewCL.DataSource = CLNego.ListarCondicionLab(txtNombre.Text);
                GridViewCL.DataBind();
            }
            catch (Exception)
            {
            }
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarDatos();
        }

        protected void btnNuevoRol_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EditorCondicionLaboral.aspx");
        }

        protected void GridViewDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //try
            //{
                GridViewCL.PageIndex = e.NewPageIndex;
                GridViewCL.DataBind();
                ListarDatos();
            //}
            //catch (Exception)
            //{
            //}
        }

        protected void GridViewDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                short indicefila;
                indicefila = Convert.ToInt16(e.CommandArgument);
                string cod;
                if (indicefila >= 0 & indicefila < GridViewCL.Rows.Count)
                {
                    cod = GridViewCL.Rows[indicefila].Cells[2].Text;
                    if (e.CommandName == "Actualizar")
                    {
                        Session["idCondicionLaboral"] = cod;
                        Response.Redirect("~/EditorCondicionLaboral.aspx");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void GridViewDatos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //try
            //{
                GridViewRow row = GridViewCL.Rows[e.RowIndex];
                string cod = Convert.ToString(row.Cells[2].Text);
                {
                    CLEntid.id = Convert.ToInt32(cod);
                }
                if (CLNego.DesactivarCondicionLaboral(CLEntid) == true)
                {
                    ListarDatos();
                }
                //else
                //{
                //}
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
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