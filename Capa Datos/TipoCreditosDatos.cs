using CapaEntidad;
using NLog;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class TipoCreditosDatos
    {
        private static Logger logger = LogManager.GetLogger("AppLoggerRule");

        SqlConnection cnx;
        TipoCreditosEntidad mcEntidad = new TipoCreditosEntidad();
        Conexion MiConexi = new Conexion();
        SqlCommand cmd = new SqlCommand();
        bool vexito;

        public TipoCreditosDatos()
        {
            cnx = new SqlConnection(MiConexi.GetConex());
        }

        public bool InsertarTipoCredito(TipoCreditosEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_CrearTipoCreditos";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@nombreCredito", SqlDbType.VarChar, 50));
                cmd.Parameters["@nombreCredito"].Value = mcEntidad.nomCredito;
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
        public bool ActualizarTipoCredito(TipoCreditosEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ModificarTipoCreditos";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@idTipoCredito", SqlDbType.Int));
                cmd.Parameters["@idTipoCredito"].Value = mcEntidad.id;
                cmd.Parameters.Add(new SqlParameter("@nombreCredito", SqlDbType.VarChar, 50));
                cmd.Parameters["@nombreCredito"].Value = mcEntidad.nomCredito;
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
        public bool EliminarTipoCredito(TipoCreditosEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DesactivarTipoCreditos";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@idTipoCredito", SqlDbType.Int));
                cmd.Parameters["@idTipoCredito"].Value = mcEntidad.id;
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

        public DataTable ListarTipoCredito(string parametro)
        {
            DataSet dts = new DataSet();
            try
            {
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ListarTipoCreditos";
                cmd.Parameters.Add(new SqlParameter("@nombreCredito", parametro));
                SqlDataAdapter miada;
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "TipoCreditos");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
            }
            return (dts.Tables["TipoCreditos"]);
        }

        public TipoCreditosEntidad BuscarTipoCredito(string id)
        {
            try
            {
                SqlDataReader dtr;
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarTipoCreditos";
                cmd.Parameters.Add(new SqlParameter("@idTipoCredito", SqlDbType.Int));
                cmd.Parameters["@idTipoCredito"].Value = id;
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
                    mcEntidad.nomCredito = Convert.ToString(dtr[0]);
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
