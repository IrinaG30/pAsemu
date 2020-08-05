using CapaEntidad;
using NLog;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class ExpedientesDatos
    {


        private static Logger logger = LogManager.GetLogger("AppLoggerRule");

        SqlConnection cnx;
        ExpedientesEntidad mcEntidad = new ExpedientesEntidad();
        Conexion MiConexi = new Conexion();
        SqlCommand cmd = new SqlCommand();
        bool vexito;

        public ExpedientesDatos()
        {
            cnx = new SqlConnection(MiConexi.GetConex());
        }

        public bool InsertarExpedientes(ExpedientesEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Crear_Expedientes";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@cedulaAsociado", SqlDbType.Int));
                cmd.Parameters["@cedulaAsociado"].Value = mcEntidad.cedula;
                cmd.Parameters.Add(new SqlParameter("@numeroEmpleado", SqlDbType.Int));
                cmd.Parameters["@numeroEmpleado"].Value = mcEntidad.numEmple;
                cmd.Parameters.Add(new SqlParameter("@nombreAsociado", SqlDbType.VarChar, 50));
                cmd.Parameters["@nombreAsociado"].Value = mcEntidad.nomAsociado;
                cmd.Parameters.Add(new SqlParameter("@apellido1", SqlDbType.VarChar, 50));
                cmd.Parameters["@apellido1"].Value = mcEntidad.ape1;
                cmd.Parameters.Add(new SqlParameter("@apellido2", SqlDbType.VarChar, 50));
                cmd.Parameters["@apellido2"].Value = mcEntidad.ape2;
                cmd.Parameters.Add(new SqlParameter("@telefono", SqlDbType.Int));
                cmd.Parameters["@telefono"].Value = mcEntidad.tel;
                cmd.Parameters.Add(new SqlParameter("@direccion", SqlDbType.VarChar, 100));
                cmd.Parameters["@direccion"].Value = mcEntidad.dire;
                cmd.Parameters.Add(new SqlParameter("@correoElectronico", SqlDbType.VarChar, 100));
                cmd.Parameters["@correoElectronico"].Value = mcEntidad.correoElectr;
                cmd.Parameters.Add(new SqlParameter("@idPuesto", SqlDbType.Int));
                cmd.Parameters["@idPuesto"].Value = mcEntidad.idPues;
                cmd.Parameters.Add(new SqlParameter("@idDepartamento", SqlDbType.Int));
                cmd.Parameters["@idDepartamento"].Value = mcEntidad.idDepar;
                cmd.Parameters.Add(new SqlParameter("@fechaIngreso", SqlDbType.DateTime));
                cmd.Parameters["@fechaIngreso"].Value = mcEntidad.feIngreso;
                cmd.Parameters.Add(new SqlParameter("@fechaSalida", SqlDbType.DateTime));
                cmd.Parameters["@fechaSalida"].Value = mcEntidad.feSalida;
                cmd.Parameters.Add(new SqlParameter("@idCondicionLaboral", SqlDbType.Int));
                cmd.Parameters["@idCondicionLaboral"].Value = mcEntidad.idCondiLab;
                cmd.Parameters.Add(new SqlParameter("@tiempoAfiliado", SqlDbType.VarChar, 100));
                cmd.Parameters["@tiempoAfiliado"].Value = mcEntidad.tiemAfiliado;
                cmd.Parameters.Add(new SqlParameter("@numeroCuenta", SqlDbType.Int));
                cmd.Parameters["@numeroCuenta"].Value = mcEntidad.numCuenta;
                cmd.Parameters.Add(new SqlParameter("@idEstadoDatos", SqlDbType.Int));
                cmd.Parameters["@idEstadoDatos"].Value = mcEntidad.idEstado;

                cnx.Open();
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
                }
                cmd.Parameters.Clear();
            }
            return vexito;
        }
        public bool ActualizarExpedientes(ExpedientesEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ModificarExpedientes";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@cedulaAsociado", SqlDbType.Int));
                cmd.Parameters["@cedulaAsociado"].Value = mcEntidad.cedula;
                cmd.Parameters.Add(new SqlParameter("@numeroEmpleado", SqlDbType.Int));
                cmd.Parameters["@numeroEmpleado"].Value = mcEntidad.numEmple;
                cmd.Parameters.Add(new SqlParameter("@nombreAsociado", SqlDbType.VarChar, 50));
                cmd.Parameters["@nombreAsociado"].Value = mcEntidad.nomAsociado;
                cmd.Parameters.Add(new SqlParameter("@apellido1", SqlDbType.VarChar, 50));
                cmd.Parameters["@apellido1"].Value = mcEntidad.ape1;
                cmd.Parameters.Add(new SqlParameter("@apellido2", SqlDbType.VarChar, 50));
                cmd.Parameters["@apellido2"].Value = mcEntidad.ape2;
                cmd.Parameters.Add(new SqlParameter("@telefono", SqlDbType.Int));
                cmd.Parameters["@telefono"].Value = mcEntidad.tel;
                cmd.Parameters.Add(new SqlParameter("@direccion", SqlDbType.VarChar, 100));
                cmd.Parameters["@direccion"].Value = mcEntidad.dire;
                cmd.Parameters.Add(new SqlParameter("@correoElectronico", SqlDbType.VarChar, 100));
                cmd.Parameters["@correoElectronico"].Value = mcEntidad.correoElectr;
                cmd.Parameters.Add(new SqlParameter("@idPuesto", SqlDbType.Int));
                cmd.Parameters["@idPuesto"].Value = mcEntidad.idPues;
                cmd.Parameters.Add(new SqlParameter("@idDepartamento", SqlDbType.Int));
                cmd.Parameters["@idDepartamento"].Value = mcEntidad.idDepar;
                cmd.Parameters.Add(new SqlParameter("@fechaIngreso", SqlDbType.DateTime));
                cmd.Parameters["@fechaIngreso"].Value = mcEntidad.feIngreso;
                cmd.Parameters.Add(new SqlParameter("@fechaSalida", SqlDbType.DateTime));
                cmd.Parameters["@fechaSalida"].Value = mcEntidad.feSalida;
                cmd.Parameters.Add(new SqlParameter("@idCondicionLaboral", SqlDbType.Int));
                cmd.Parameters["@idCondicionLaboral"].Value = mcEntidad.idCondiLab;
                cmd.Parameters.Add(new SqlParameter("@tiempoAfiliado", SqlDbType.VarChar, 100));
                cmd.Parameters["@tiempoAfiliado"].Value = mcEntidad.tiemAfiliado;
                cmd.Parameters.Add(new SqlParameter("@numeroCuenta", SqlDbType.Int));
                cmd.Parameters["@numeroCuenta"].Value = mcEntidad.numCuenta;
                cnx.Open();
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
                }
                cmd.Parameters.Clear();
            }
            return vexito;
        }

        //public bool DeshabilitarExpediente(ExpedientesEntidad mcEntidad)
        //{
        //    cmd.Connection = cnx;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "SP_Desactivar_Expedientes";
        //    try
        //    {
        //        cmd.Parameters.Add(new SqlParameter("@numeroEmpleado", SqlDbType.Int));
        //        cmd.Parameters["@numeroEmpleado"].Value = mcEntidad.numEmple;
        //        cnx.Open();
        //        cmd.ExecuteNonQuery();
        //        vexito = true;
        //    }
        //    catch (SqlException)
        //    {
        //        vexito = false;
        //    }
        //    finally
        //    {
        //        if (cnx.State == ConnectionState.Open)
        //        {
        //            cnx.Close();
        //        }
        //        cmd.Parameters.Clear();
        //    }
        //    return vexito;
        //}

        public DataTable ListarExpedientes(string parametro)
        {
            DataSet dts = new DataSet();
            try
            {
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ListarExpedientes";
                cmd.Parameters.Add(new SqlParameter("@numeroEmpleado", parametro));
                SqlDataAdapter miada;
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Expedientes");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
            }
            return (dts.Tables["Expedientes"]);
        }

        public ExpedientesEntidad BuscarExpedientes(string id)
        {
            try
            {
                SqlDataReader dtr;
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarExpedientes";
                cmd.Parameters.Add(new SqlParameter("@numeroEmpleado", SqlDbType.Int));
                cmd.Parameters["@numeroEmpleado"].Value = id;
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
                    mcEntidad.id = Convert.ToInt32(dtr[0]);
                    mcEntidad.cedula = Convert.ToInt32(dtr[1]);
                    mcEntidad.numEmple = Convert.ToInt32(dtr[2]);
                    mcEntidad.nomAsociado = Convert.ToString(dtr[3]);
                    mcEntidad.ape1 = Convert.ToString(dtr[4]);
                    mcEntidad.ape2 = Convert.ToString(dtr[5]);
                    mcEntidad.tel = Convert.ToInt32(dtr[6]);
                    mcEntidad.dire = Convert.ToString(dtr[7]);
                    mcEntidad.correoElectr = Convert.ToString(dtr[8]);
                    mcEntidad.idPues = Convert.ToInt32(dtr[9]);
                    mcEntidad.idDepar = Convert.ToInt32(dtr[10]);
                    mcEntidad.feIngreso = Convert.ToDateTime(dtr[11]);
                    mcEntidad.feSalida = Convert.ToDateTime(dtr[12]);
                    mcEntidad.idCondiLab = Convert.ToInt32(dtr[13]);
                    mcEntidad.tiemAfiliado = Convert.ToString(dtr[14]);
                    mcEntidad.numCuenta = Convert.ToInt32(dtr[15]);
                    mcEntidad.idEstado = Convert.ToInt32(dtr[16]);
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
