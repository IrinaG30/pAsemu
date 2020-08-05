using CapaEntidad;
using NLog;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class PrestamosDatos
    {
        private static Logger logger = LogManager.GetLogger("AppLoggerRule");

        SqlConnection cnx;
        PrestamosEntidad mcEntidad = new PrestamosEntidad();
        Conexion MiConexi = new Conexion();
        SqlCommand cmd = new SqlCommand();
        bool vexito;

        public PrestamosDatos()
        {
            cnx = new SqlConnection(MiConexi.GetConex());
        }

        public bool InsertarPrestamo(PrestamosEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_CrearPrestamo";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@numeroPrestamo", SqlDbType.Int));
                cmd.Parameters["@numeroPrestamo"].Value = mcEntidad.numPrestamo;

                cmd.Parameters.Add(new SqlParameter("@cedulaAsociado", SqlDbType.Int));
                cmd.Parameters["@cedulaAsociado"].Value = mcEntidad.cedAsociado;

                cmd.Parameters.Add(new SqlParameter("@numeroEmpleado", SqlDbType.Int));
                cmd.Parameters["@numeroEmpleado"].Value = mcEntidad.numEmpleado;

                cmd.Parameters.Add(new SqlParameter("@idPuesto", SqlDbType.Int));
                cmd.Parameters["@idPuesto"].Value = mcEntidad.idPuestos;

                cmd.Parameters.Add(new SqlParameter("@numeroCuenta", SqlDbType.Int));
                cmd.Parameters["@numeroCuenta"].Value = mcEntidad.numCuenta;

                cmd.Parameters.Add(new SqlParameter("@idTipoCredito", SqlDbType.Int));
                cmd.Parameters["@idTipoCredito"].Value = mcEntidad.idTipoCreditos;

                cmd.Parameters.Add(new SqlParameter("@idPlazo", SqlDbType.Int));
                cmd.Parameters["@idPlazo"].Value = mcEntidad.idPlazos;

                cmd.Parameters.Add(new SqlParameter("@montoCuota", SqlDbType.Int));
                cmd.Parameters["@montoCuota"].Value = mcEntidad.montoCuot;

                cmd.Parameters.Add(new SqlParameter("@fechaInicio", SqlDbType.Date, 60));
                cmd.Parameters["@fechaInicio"].Value = mcEntidad.fechaInci;

                cmd.Parameters.Add(new SqlParameter("@fechaFinal", SqlDbType.Date, 60));
                cmd.Parameters["@fechaFinal"].Value = mcEntidad.fechaFina;

                cmd.Parameters.Add(new SqlParameter("@idInteres", SqlDbType.Int));
                cmd.Parameters["@idInteres"].Value = mcEntidad.idIntere;

                cmd.Parameters.Add(new SqlParameter("@idTipoFiador", SqlDbType.Int));
                cmd.Parameters["@idTipoFiador"].Value = mcEntidad.idTipFiador;

                cmd.Parameters.Add(new SqlParameter("@montoSolicitado", SqlDbType.Int));
                cmd.Parameters["@montoSolicitado"].Value = mcEntidad.montSolicitado;

                cmd.Parameters.Add(new SqlParameter("@montoAPagar", SqlDbType.Int));
                cmd.Parameters["@montoAPagar"].Value = mcEntidad.monAPagar;

                cmd.Parameters.Add(new SqlParameter("@salarioBruto", SqlDbType.Int));
                cmd.Parameters["@salarioBruto"].Value = mcEntidad.salBruto;

                cmd.Parameters.Add(new SqlParameter("@salarioNeto", SqlDbType.Int));
                cmd.Parameters["@salarioNeto"].Value = mcEntidad.salNeto;

                cmd.Parameters.Add(new SqlParameter("@cuotaFianza", SqlDbType.Int));
                cmd.Parameters["@cuotaFianza"].Value = mcEntidad.coutFianza;

                cmd.Parameters.Add(new SqlParameter("@comisionCargos", SqlDbType.Int));
                cmd.Parameters["@comisionCargos"].Value = mcEntidad.comiCargos;

                cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 50));
                cmd.Parameters["@estado"].Value = mcEntidad.estados;

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

        public bool ActualizarPrestamo(PrestamosEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ModificarPrestamo";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 50));
                cmd.Parameters["@estado"].Value = mcEntidad.estados;
                cmd.Parameters.Add(new SqlParameter("@fechaInicio", SqlDbType.Date, 60));
                cmd.Parameters["@fechaInicio"].Value = mcEntidad.fechaInci;
                cmd.Parameters.Add(new SqlParameter("@fechaFinal", SqlDbType.Date, 60));
                cmd.Parameters["@fechaFinal"].Value = mcEntidad.fechaFina;

                cmd.Parameters.Add(new SqlParameter("@idPrestamo", SqlDbType.Int));
                cmd.Parameters["@idPrestamo"].Value = mcEntidad.idPrestamos;

                cmd.Parameters.Add(new SqlParameter("@numeroPrestamo", SqlDbType.Int));
                cmd.Parameters["@numeroPrestamo"].Value = mcEntidad.numPrestamo;

                cmd.Parameters.Add(new SqlParameter("@cedulaAsociado", SqlDbType.Int));
                cmd.Parameters["@cedulaAsociado"].Value = mcEntidad.cedAsociado;

                cmd.Parameters.Add(new SqlParameter("@numeroEmpleado", SqlDbType.Int));
                cmd.Parameters["@numeroEmpleado"].Value = mcEntidad.numEmpleado;

                cmd.Parameters.Add(new SqlParameter("@idPuesto", SqlDbType.Int));
                cmd.Parameters["@idPuesto"].Value = mcEntidad.idPuestos;

                cmd.Parameters.Add(new SqlParameter("@numeroCuenta", SqlDbType.Int));
                cmd.Parameters["@numeroCuenta"].Value = mcEntidad.numCuenta;

                cmd.Parameters.Add(new SqlParameter("@idTipoCredito", SqlDbType.Int));
                cmd.Parameters["@idTipoCredito"].Value = mcEntidad.idTipoCreditos;

                cmd.Parameters.Add(new SqlParameter("@idPlazo", SqlDbType.Int));
                cmd.Parameters["@idPlazo"].Value = mcEntidad.idPlazos;

                cmd.Parameters.Add(new SqlParameter("@montoCuota", SqlDbType.Int));
                cmd.Parameters["@montoCuota"].Value = mcEntidad.montoCuot;

                cmd.Parameters.Add(new SqlParameter("@idInteres", SqlDbType.Int));
                cmd.Parameters["@idInteres"].Value = mcEntidad.idIntere;

                cmd.Parameters.Add(new SqlParameter("@idTipoFiador", SqlDbType.Int));
                cmd.Parameters["@idTipoFiador"].Value = mcEntidad.idTipFiador;

                cmd.Parameters.Add(new SqlParameter("@montoSolicitado", SqlDbType.Int));
                cmd.Parameters["@montoSolicitado"].Value = mcEntidad.montSolicitado;

                cmd.Parameters.Add(new SqlParameter("@montoAPagar", SqlDbType.Int));
                cmd.Parameters["@montoAPagar"].Value = mcEntidad.monAPagar;

                cmd.Parameters.Add(new SqlParameter("@salarioBruto", SqlDbType.Int));
                cmd.Parameters["@salarioBruto"].Value = mcEntidad.salBruto;

                cmd.Parameters.Add(new SqlParameter("@salarioNeto", SqlDbType.Int));
                cmd.Parameters["@salarioNeto"].Value = mcEntidad.salNeto;

                cmd.Parameters.Add(new SqlParameter("@cuotaFianza", SqlDbType.Int));
                cmd.Parameters["@cuotaFianza"].Value = mcEntidad.coutFianza;

                cmd.Parameters.Add(new SqlParameter("@comisionCargos", SqlDbType.Int));
                cmd.Parameters["@comisionCargos"].Value = mcEntidad.comiCargos;

                cnx.Open();

                //se guarda en la bitacora una conexion abierta
                logger.Info("Usuario administrador abrio conexion con la base de datos");

                cmd.ExecuteNonQuery();
                vexito = true;
            }
            catch (SqlException ee)
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

        //public bool EliminarPrestamo(PrestamosEntidad mcEntidad)
        //{
        //    //cmd.Connection = cnx;
        //    //cmd.CommandType = CommandType.StoredProcedure;
        //    //cmd.CommandText = "SP_DesactivarDepartamento";
        //    //try
        //    //{
        //    //    cmd.Parameters.Add(new SqlParameter("@idDepartamento", SqlDbType.Int));
        //    //    cmd.Parameters["@idDepartamento"].Value = mcEntidad.id;
        //    //    cnx.Open();
        //    //    cmd.ExecuteNonQuery();
        //    //    vexito = true;
        //    //}
        //    //catch (SqlException)
        //    //{
        //    //    vexito = false;
        //    //}
        //    //finally
        //    //{
        //    //    if (cnx.State == ConnectionState.Open)
        //    //    {
        //    //        cnx.Close();
        //    //    }
        //    //    cmd.Parameters.Clear();
        //    //}
        //    return vexito;
        //}

        //public DataTable ListarPrestamo(string parametro)
        //{
        //    DataSet dts = new DataSet();
        //    try
        //    {
        //        cmd.Connection = cnx;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "SP_ListarPrestamo";
        //        cmd.Parameters.Add(new SqlParameter("@numeroPrestamo", parametro));
        //        SqlDataAdapter miada;
        //        miada = new SqlDataAdapter(cmd);
        //        miada.Fill(dts, "Prestamos");
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        cmd.Parameters.Clear();
        //    }
        //    return (dts.Tables["Prestamos"]);
        //}

        public PrestamosEntidad BuscarPrestamo(string id)
        {
            try
            {
                SqlDataReader dtr;
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarPrestamo";
                cmd.Parameters.Add(new SqlParameter("@numPrestamo", SqlDbType.Int));
                cmd.Parameters["@numPrestamo"].Value = id;
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
                    mcEntidad.idPrestamos = Convert.ToInt32(dtr[0]);
                    mcEntidad.numPrestamo = Convert.ToInt32(dtr[1]);
                    mcEntidad.cedAsociado = Convert.ToInt32(dtr[2]);
                    mcEntidad.numEmpleado = Convert.ToInt32(dtr[3]);
                    mcEntidad.idPuestos = Convert.ToInt32(dtr[4]);
                    mcEntidad.numCuenta = Convert.ToInt32(dtr[5]);
                    mcEntidad.idTipoCreditos = Convert.ToInt32(dtr[6]);
                    mcEntidad.idPlazos = Convert.ToInt32(dtr[7]);
                    mcEntidad.montoCuot = Convert.ToInt32(dtr[8]);
                    mcEntidad.fechaInci = Convert.ToDateTime(dtr[9]);
                    mcEntidad.fechaFina = Convert.ToDateTime(dtr[10]);
                    mcEntidad.montSolicitado = Convert.ToInt32(dtr[11]);
                    mcEntidad.monAPagar = Convert.ToInt32(dtr[12]);
                    mcEntidad.salBruto = Convert.ToInt32(dtr[13]);
                    mcEntidad.salNeto = Convert.ToInt32(dtr[14]);
                    mcEntidad.coutFianza = Convert.ToInt32(dtr[15]);
                    mcEntidad.comiCargos = Convert.ToInt32(dtr[16]);
                    mcEntidad.estados = Convert.ToString(dtr[17]);
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
