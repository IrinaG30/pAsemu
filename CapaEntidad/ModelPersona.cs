using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaEntidad
{
    public class ModelPersona
    {

        public virtual int idUsuarios { get; set; }
        public virtual int cedulaAsociado { get; set; }
            public virtual string correoElectronico { get; set; }
            public virtual int idRol { get; set; }
            public virtual string contrasenna { get; set; }
            public virtual string salt { get; set; }
            public virtual int idEstadoDatos { get; set; }

        private SqlConnection con;
            private SqlCommand comando;
            private SqlParameter parametros;
            private SqlDataAdapter adaptador;

            private string StringConexion = ConfigurationManager.ConnectionStrings["ASEMU"].ConnectionString;

            public int CrearUsuario()
            {
                int respuesta = 0;

                using (con = new SqlConnection(StringConexion))
                {
                    con.Open();

                    comando = new SqlCommand("SP_CrearUsuarios", con);
                    comando.CommandType = CommandType.StoredProcedure;

                parametros = new SqlParameter("@cedulaAsociado", SqlDbType.VarChar, 50);
                parametros.Value = this.cedulaAsociado;
                comando.Parameters.Add(parametros);



                parametros = new SqlParameter("@correoElectronico", SqlDbType.VarChar, 150);
                parametros.Value = this.correoElectronico;
                comando.Parameters.Add(parametros);



                parametros = new SqlParameter("@idRol", SqlDbType.VarChar, 20);
                parametros.Value = this.idRol;
                comando.Parameters.Add(parametros);



                parametros = new SqlParameter("@contrasenna", SqlDbType.VarChar, 150);
                parametros.Value = this.contrasenna;
                comando.Parameters.Add(parametros);



                parametros = new SqlParameter("@sal", SqlDbType.VarChar, 150);
                parametros.Value = this.salt;
                comando.Parameters.Add(parametros);



                parametros = new SqlParameter("@idEstadoDatos", SqlDbType.VarChar, 20);
                parametros.Value = this.idEstadoDatos;
                comando.Parameters.Add(parametros);

                try
                    {
                     respuesta = comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                       respuesta = 0;
                    }
                }

                return respuesta;
            }

        }

    }
