using CapaEntidad;
using NLog;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class PlazosDatos
    {
        private static Logger logger = LogManager.GetLogger("AppLoggerRule");

        SqlConnection cnx;
        PlazosEntidad mcEntidad = new PlazosEntidad();
        Conexion MiConexi = new Conexion();
        SqlCommand cmd = new SqlCommand();
        bool vexito;

        public PlazosDatos()
        {
            cnx = new SqlConnection(MiConexi.GetConex());
        }

        public bool InsertarPlazo(PlazosEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_CrearPlazo";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@plazo", SqlDbType.VarChar, 50));
                cmd.Parameters["@plazo"].Value = mcEntidad.plazos;
                cmd.Parameters.Add(new SqlParameter("@idEstadoDatos", SqlDbType.Int));
                cmd.Parameters["@idEstadoDatos"].Value = mcEntidad.estado;
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
        public bool ActualizarPlazo(PlazosEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ModificarPlazo";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@idPlazo", SqlDbType.Int));
                cmd.Parameters["@idPlazo"].Value = mcEntidad.id;
                cmd.Parameters.Add(new SqlParameter("@plazo", SqlDbType.VarChar, 50));
                cmd.Parameters["@plazo"].Value = mcEntidad.plazos;
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
        public bool EliminarPlazo(PlazosEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DesactivarPlazo";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@idPlazo", SqlDbType.Int));
                cmd.Parameters["@idPlazo"].Value = mcEntidad.id;
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
        public DataTable ListarPlazo(string parametro)
        {
            DataSet dts = new DataSet();
            try
            {
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ListarPlazos";
                cmd.Parameters.Add(new SqlParameter("@plazo", parametro));
                SqlDataAdapter miada;
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Plazos");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
            }
            return (dts.Tables["Plazos"]);
        }
        public PlazosEntidad BuscarPlazo(string id)
        {
            try
            {
                SqlDataReader dtr;
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarPlazo";
                cmd.Parameters.Add(new SqlParameter("@idPlazo", SqlDbType.Int));
                cmd.Parameters["@idPlazo"].Value = id;
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
                    mcEntidad.plazos = Convert.ToString(dtr[0]);
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
