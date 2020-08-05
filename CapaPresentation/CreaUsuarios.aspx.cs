using CapaEntidad;
using CapaPresentation.Modelado;
using SimpleCrypto;
using System;
using System.Web.Security;
using System.Web.UI;
using CapaPresentation.Modelado;
//using CapaPresentation.Modelado;
using CapaEntidad;
using SimpleCrypto;

namespace CapaPresentation
{
    public partial class CreaUsuarios : System.Web.UI.Page
    {

        //Instanciar el contexto de la db
        private AsumeDataContext db = new AsumeDataContext();

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
            //Verifica que el rol del usuario que inicio sesion 
            if (Session["UserRole"].ToString() != "1")
            {
                //Si no es admin (1) redirija al inicio
                Response.Redirect("Inicio.aspx");
            }
        }
        

        //METODO DE GUARDAR USUARIO 
        protected void txtGuardar_Click(object sender, EventArgs e)
        {
            int cedulaUsuario = int.Parse(txtcedulaUsuario.Text.Trim());
            string correoElectronico = txtnombreCompleto.Text.Trim();
            int idRol = int.Parse(txtRol.Text.Trim());
            string contrasenia = txtcontrasenna.Text.Trim();



            //Para encriptar protocolo
            ICryptoService cryptoService = new PBKDF2();

            //Generar algoritmo de encriptación
            string salt = cryptoService.GenerateSalt();

            string contraseniaEncriptada = cryptoService.Compute(contrasenia);

            ModelPersona usuario = new ModelPersona();
            usuario.cedulaAsociado = cedulaUsuario;
            usuario.correoElectronico = correoElectronico;
            usuario.idRol = idRol;
            usuario.contrasenna = contraseniaEncriptada;
            usuario.salt = salt;
            usuario.idEstadoDatos = 1;
            int resultado = usuario.CrearUsuario();

            if (resultado == 1)
            {
                

                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alertaExito", "window.onload = function() { alert('Mensajero registrado exitosamente.'); }", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alertaError", "window.onload = function() { alert('Opps!! Ocurrio un error al registrar el usuario.'); }", true);
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