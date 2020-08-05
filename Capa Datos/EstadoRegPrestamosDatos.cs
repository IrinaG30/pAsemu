using CapaEntidad;
using NLog;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class EstadoRegPrestamosDatos
    {
        private static Logger logger = LogManager.GetLogger("AppLoggerRule");

        SqlConnection cnx;
        EstadoRegPrestamosEntidad mcEntidad = new EstadoRegPrestamosEntidad();
        Conexion MiConexi = new Conexion();
        SqlCommand cmd = new SqlCommand();
        bool vexito;

        public EstadoRegPrestamosDatos()
        {
            cnx = new SqlConnection(MiConexi.GetConex());
        }

        public bool InsertarEstadoRegPrestamos(EstadoRegPrestamosEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_CrearEstadoRegPrestamos";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 50));
                cmd.Parameters["@estado"].Value = mcEntidad.tipoEstado;
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
        public bool ActualizarEstadoRegPrestamos(EstadoRegPrestamosEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ModificarEstadoRegPrestamos";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@idEstadoRegPrestamos", SqlDbType.Int));
                cmd.Parameters["@idEstadoRegPrestamos"].Value = mcEntidad.id;
                cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 50));
                cmd.Parameters["@estado"].Value = mcEntidad.tipoEstado;
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

        public bool EliminarEstadoRegPrestamos(EstadoRegPrestamosEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DesactivarEstadoRegPrestamos";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@idEstadoRegPrestamos", SqlDbType.Int));
                cmd.Parameters["@idEstadoRegPrestamos"].Value = mcEntidad.id;
                cmd.Parameters.Add(new SqlParameter("@idEstadoDatos", SqlDbType.Int));
                cmd.Parameters["@idEstadoDatos"].Value = mcEntidad.tipoEstado;
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

        public DataTable ListarEstadoRegPrestamos(string parametro)
        {
            DataSet dts = new DataSet();
            try
            {
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ListarEstadoRegPrestamos";
                cmd.Parameters.Add(new SqlParameter("@estado", parametro));
                SqlDataAdapter miada;
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "EstadoRegPrestamos");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
            }
            return (dts.Tables["EstadoRegPrestamos"]);
        }

        public EstadoRegPrestamosEntidad BuscarEstadoRegPrestamos(string id)
        {
            try
            {
                SqlDataReader dtr;
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarEstadoRegPrestamos";
                cmd.Parameters.Add(new SqlParameter("@idEstadoRegPrestamos", SqlDbType.Int));
                cmd.Parameters["@idEstadoRegPrestamos"].Value = id;
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
                    mcEntidad.tipoEstado = Convert.ToString(dtr[0]);
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
