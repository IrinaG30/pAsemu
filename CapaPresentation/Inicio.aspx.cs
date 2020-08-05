using System;
using System.Web.Security;
using System.Web.UI;

namespace CapaPresentation
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Ejecuta esta linea si viene de otra pagina
            if (!Page.IsPostBack)
            {
                //VerificarSesion();
            }
        }

        private void VerificarSesion()
        {
            //Verifica si la sesion ha sido inicializada
            if (Session["UserRole"] == null)
            {
                //Si es nula, redirije al login para que esta se inicialice
                FormsAuthentication.SignOut();
                //Se redirije a la pagina de login
                FormsAuthentication.RedirectToLoginPage();

            }
        }

        //METODO DE CERRAR SESION
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            //Por medio del onclick 
            //Se cierra la autenticacion y se pierden las cookies
            FormsAuthentication.SignOut();
            //Se redirije a la pagina de login
            FormsAuthentication.RedirectToLoginPage();
        }

    }
}