using System;
using System.Web.Security;
using System.Web.UI;

namespace CapaPresentation
{
    public partial class Reporteria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Ejecuta esta linea si viene de otra pagina
            if (!Page.IsPostBack)
            {
                VerificarSesion();
            }
        }

        private void VerificarSesion()
        {
            //Verifica que el rol del usuario que inicio sesion 
            if (Session["UserRole"].ToString() != "1" &&  Session["UserRole"].ToString() != "3")
            {
                //Si no es admin (1) ni Junta Directiva (3) redirija al inicio
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