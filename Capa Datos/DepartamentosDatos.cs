using CapaEntidad;
using NLog;
using System;
using System.Data;
using System.Data.SqlClient;
namespace Capa_Datos
{
    public class DepartamentosDatos
    {
        private static Logger logger = LogManager.GetLogger("AppLoggerRule");


        SqlConnection cnx;
        DepartamentosEntidad mcEntidad = new DepartamentosEntidad();
        Conexion MiConexi = new Conexion();
        SqlCommand cmd = new SqlCommand();
        bool vexito;

        public DepartamentosDatos()
        {
            cnx = new SqlConnection(MiConexi.GetConex());
        }

        public bool InsertarDepartamento(DepartamentosEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_CrearDepartamento";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@nombreDepartamento", SqlDbType.VarChar, 50));
                cmd.Parameters["@nombreDepartamento"].Value = mcEntidad.tipo;
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

        public bool ActualizarDepartamento(DepartamentosEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ModificarDepartamento";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@idDepartamento", SqlDbType.Int));
                cmd.Parameters["@idDepartamento"].Value = mcEntidad.id;
                cmd.Parameters.Add(new SqlParameter("@nombreDepartamento", SqlDbType.VarChar, 50));
                cmd.Parameters["@nombreDepartamento"].Value = mcEntidad.tipo;
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

        public bool EliminarDepartamento(DepartamentosEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DesactivarDepartamento";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@idDepartamento", SqlDbType.Int));
                cmd.Parameters["@idDepartamento"].Value = mcEntidad.id;
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

        public DataTable ListarDepartamento(string parametro)
        {
            DataSet dts = new DataSet();
            try
            {
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ListarDepartamento";
                cmd.Parameters.Add(new SqlParameter("@nombreDepartamento", parametro));
                SqlDataAdapter miada;
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Departamentos");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
            }
            return (dts.Tables["Departamentos"]);
        }

        public DepartamentosEntidad BuscarDepartamento(string id)
        {
            try
            {
                SqlDataReader dtr;
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarDepartamento";
                cmd.Parameters.Add(new SqlParameter("@idDepartamento", SqlDbType.Int));
                cmd.Parameters["@idDepartamento"].Value = id;
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
                    mcEntidad.tipo = Convert.ToString(dtr[0]);
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
