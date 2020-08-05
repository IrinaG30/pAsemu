using CapaEntidad;
using NLog;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class InteresDatos
    {
        private static Logger logger = LogManager.GetLogger("AppLoggerRule");

        SqlConnection cnx;
        InteresEntidad mcEntidad = new InteresEntidad();
        Conexion MiConexi = new Conexion();
        SqlCommand cmd = new SqlCommand();
        bool vexito;

        public InteresDatos()
        {
            cnx = new SqlConnection(MiConexi.GetConex());
        }
        public bool InsertarInteres(InteresEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_CrearInteres";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@porcentajeInteres", SqlDbType.Decimal));
                cmd.Parameters["@porcentajeInteres"].Value = mcEntidad.porcentaje;
                cmd.Parameters.Add(new SqlParameter("@tipoInteres", SqlDbType.VarChar, 50));
                cmd.Parameters["@tipoInteres"].Value = mcEntidad.tipo;
                cmd.Parameters.Add(new SqlParameter("@idEstadoDatos", SqlDbType.Int));
                cmd.Parameters["@idEstadoDatos"].Value = mcEntidad.estado;
                cnx.Open();

                //se guarda en la bitacora una conexion abierta
                logger.Info("Usuario administrador abrio conexion con la base de datos");

                cmd.ExecuteNonQuery();
                vexito = true;
            }
            catch (SqlException e)
            {
                vexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();

                    //se guarda en la bitacora una conexion cerrada
                    logger.Info("Usuario administrador abrio cerro con la base de datos");
                }
                cmd.Parameters.Clear();
            }
            return vexito;
        }
        public bool ActualizarInteres(InteresEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ModificarInteres";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@idInteres", SqlDbType.Int));
                cmd.Parameters["@idInteres"].Value = mcEntidad.id;
                cmd.Parameters.Add(new SqlParameter("@porcentajeInteres", SqlDbType.Decimal));
                cmd.Parameters["@porcentajeInteres"].Value = mcEntidad.porcentaje;
                cmd.Parameters.Add(new SqlParameter("@tipoInteres", SqlDbType.VarChar, 50));
                cmd.Parameters["@tipoInteres"].Value = mcEntidad.tipo;
                cnx.Open();

                //se guarda en la bitacora una conexion abierta
                logger.Info("Usuario administrador abrio conexion con la base de datos");

                cmd.ExecuteNonQuery();
                vexito = true;
            }
            catch (SqlException e)
            {
                vexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();

                    //se guarda en la bitacora una conexion cerrada
                    logger.Info("Usuario administrador cerro conexion con la base de datos");
                }
                cmd.Parameters.Clear();
            }
            return vexito;
        }
        public bool EliminarInteres(InteresEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DesactivarInteres";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@idInteres", SqlDbType.Int));
                cmd.Parameters["@idInteres"].Value = mcEntidad.id;
                cnx.Open();

                //se guarda en la bitacora una conexion abierta
                logger.Info("Usuario administrador abrio conexion con la base de datos");

                cmd.ExecuteNonQuery();
                vexito = true;
            }
            catch (SqlException)
            {
                vexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();

                    //se guarda en la bitacora una conexion cerrada
                    logger.Info("Usuario administrador cerro conexion con la base de datos");
                }
                cmd.Parameters.Clear();
            }
            return vexito;
        }
        public DataTable ListarInteres(string parametro)
        {
            DataSet dts = new DataSet();
            try
            {
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ListarInteres";
                cmd.Parameters.Add(new SqlParameter("@tipoInteres", parametro));
                SqlDataAdapter miada;
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Interes");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
            }
            return (dts.Tables["Interes"]);
        }
        public InteresEntidad BuscarInteres(string id)
        {
            try
            {
                SqlDataReader dtr;
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarInteres";
                cmd.Parameters.Add(new SqlParameter("@idInteres", SqlDbType.Int));
                cmd.Parameters["@idInteres"].Value = id;
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();

                    //se guarda en la bitacora una conexion abierta
                    logger.Info("Usuario administrador abrio conexion con la base de datos");
                }
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    mcEntidad.porcentaje = Convert.ToInt32(dtr[0]);
                    mcEntidad.tipo = Convert.ToString(dtr[1]);
                }
                cnx.Close();

                //se guarda en la bitacora una conexion cerrada
                logger.Info("Usuario administrador cerro conexion con la base de datos");

                cmd.Parameters.Clear();
                return mcEntidad;
            }
            catch (SqlException)
            {
                throw new Exception();
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();

                    //se guarda en la bitacora una conexion cerrada
                    logger.Info("Usuario administrador cerro conexion con la base de datos");
                }
                cmd.Parameters.Clear();
            }
        }

    }
}
