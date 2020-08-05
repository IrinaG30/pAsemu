using Capa_Negocios;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentation
{
    public partial class GestorDocumental : System.Web.UI.Page
    {
        ExpedientesNegocio ExpNeg = new ExpedientesNegocio();

        PuestosNegocio PuestosNeg = new PuestosNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Ejecuta esta linea si viene de otra pagina
            if (!Page.IsPostBack)
            {
                VerificarSesion();
                CargarDropdownList();
                BindGrid();

            }
        }

        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["ASEMU"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    // cmd.CommandText = "select Id, Name from tblFiles";
                    try
                    {
                        cmd.CommandText = "Select idDocExpedientes, numeroEmpleado, documento from DocExpedientes";
                        cmd.Connection = con;
                        con.Open();
                        GridView1.DataSource = cmd.ExecuteReader();
                        GridView1.DataBind();
                        con.Close();
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
        }

        private void CargarDropdownList()
        {
            //Se cargan al DropdownList de Puestos, los valores encontrados en la tabla de EXPEDIENRTES BD que se encuentren activos
            dlNumEm.DataSource = ExpNeg.ListarExpedientes("");
            dlNumEm.DataTextField = "numeroEmpleado";
            dlNumEm.DataValueField = "numeroEmpleado";
            dlNumEm.DataBind();

            //Se cargan al DropdownList de Puestos, los valores encontrados en la tabla de puestos BD que se encuentren activos
            /*  dlNumEm.DataSource = PuestosNeg.ListarPuesto("");
              dlNumEm.DataTextField = "nombre";
              dlNumEm.DataValueField = "idPuesto";
              dlNumEm.DataBind();*/

        }

        protected void Upload(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;
            int NumEmple = Convert.ToInt32(dlNumEm.Text);
            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        //string query = "insert into tblFiles values (@Name, @ContentType, @Data)";
                        string query = "insert into DocExpedientes values ( @numeroEmpleado, @documento, @dato, @tipo)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            /* cmd.Parameters.AddWithValue("@Name", filename);
                             cmd.Parameters.AddWithValue("@ContentType", contentType);
                             cmd.Parameters.AddWithValue("@Data", bytes);*/
                            cmd.Parameters.AddWithValue("@numeroEmpleado", NumEmple);
                            cmd.Parameters.AddWithValue("@documento", filename);
                            cmd.Parameters.AddWithValue("@dato", bytes);
                            cmd.Parameters.AddWithValue("@tipo", contentType);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            int id = int.Parse((sender as ImageButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //cmd.CommandText = "select Name, Data, ContentType from tblFiles where Id=@Id";
                    cmd.CommandText = "select documento, dato, tipo from DocExpedientes where idDocExpedientes=@idDocExpedientes";
                    cmd.Parameters.AddWithValue("@idDocExpedientes", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        /* bytes = (byte[])sdr["Data"];
                         contentType = sdr["ContentType"].ToString();
                         fileName = sdr["Name"].ToString();*/
                        bytes = (byte[])sdr["dato"];
                        contentType = sdr["tipo"].ToString();
                        fileName = sdr["documento"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        protected void btnBuscar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {

        }

        private void VerificarSesion()
        {
            //Verifica que el rol del usuario que inicio sesion 
            if (Session["UserRole"].ToString() != "1" && Session["UserRole"].ToString() != "2" && Session["UserRole"].ToString() != "3")
            {
                //Si no es admin (1) ni Secretaria (2) ni Junta Directiva (3) redirija al inicio
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