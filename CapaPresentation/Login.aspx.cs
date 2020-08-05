using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;
using CapaEntidad;
using CapaPresentation.Modelado;
using SimpleCrypto;
using NLog;

namespace CapaPresentation
{
    public partial class Login1 : System.Web.UI.Page
    {

        private AsumeDataContext db = new AsumeDataContext();
        private static Logger logger = LogManager.GetLogger("AppLoggerRule");

        protected void Page_Load(object sender, EventArgs e)
        {
            //se ejecuta si viene de otra pagina
            if (!IsPostBack)
            {
                //si el usuario tiene cookie de autenticacion
                if (Context.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
        }
        

        protected void btnIniciar_Click1(object sender, EventArgs e)
        {
            //Se pasan los valor de los textbox a integer y string
            int cedulaAsociado = int.Parse(txtUsuario.Text.Trim());
            string contrasenna = txtPassword.Text.Trim();
            
            //Cuando la contrasena no es nula
            if ( contrasenna != "")
            {
                //Se busca el usuario que coincida con la cedula digitada
                var usuario = db.Usuarios.Where(x => x.cedulaAsociado == cedulaAsociado).FirstOrDefault();

                //Si el usuario existe
                if (usuario != null)
                {
                    //se llama a la liberia de encriptacion
                    ICryptoService cryptoService = new PBKDF2();
                    //se le da la llave de encriptacion
                    string contraseniaEncriptada = cryptoService.Compute(contrasenna, usuario.salt);

                    //si la contrasena encriptada es igual a la contrasenna guardada en el sistema
                    if (cryptoService.Compare(usuario.contrasenna, contraseniaEncriptada))
                    {
                        //se guarda en la bitacora un inicio exitoso con los datos de usuario utilizados para ingresar
                        logger.Info("Inicio de sesion exitoso: " + cedulaAsociado + ", " + contraseniaEncriptada);
                        //Crea una cookie permanente con el nombre de usuario
                        string correoAsociado = usuario.cedulaAsociado + " " + usuario.correoElectronico;
                        FormsAuthentication.RedirectFromLoginPage(correoAsociado, false);

                        // Se hace la sesion con el id del rol del usuarios
                        Session["UserRole"] = usuario.idRol.ToString(); 
                        
                    }
                    else
                    {
                        //se guarda en la bitacora un inicio fallido con los datos de usuario utilizados para ingresar
                        logger.Info("Inicio de sesion fallido, usuario ingresado: " + cedulaAsociado + ", contrasenna ingresada:"+ contraseniaEncriptada);
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "AlertaLoginContrasenia", "window.onload = function(){ alert('La contraseña es incorrecta.'); };", true);
                    }
                }
                else
                {
                    //se guarda en la bitacora un fallido exitoso con los datos de usuario utilizados para ingresar
                    logger.Info("Inicio de sesion fallido, usuario ingresado: " + cedulaAsociado);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "AlertaLoginUsuario", "window.onload = function(){ alert('El usuario no existe.'); };", true);
                }
            }
        }
    }
}

