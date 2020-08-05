using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class RegistroPagosDatos
    {

        SqlConnection cnx;
        RegistroPagosEntidad mcEntidad = new RegistroPagosEntidad();
        Conexion MiConexi = new Conexion();
        SqlCommand cmd = new SqlCommand();
        bool vexito;

        public RegistroPagosDatos()
        {
            cnx = new SqlConnection(MiConexi.GetConex());
        }

        public bool InsertarRegistroPago(RegistroPagosEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_CrearRegistroPagos";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@numeroPrestamo", SqlDbType.Int));
                cmd.Parameters["@numeroPrestamo"].Value = mcEntidad.numPrestamo;
                cmd.Parameters.Add(new SqlParameter("@numeroEmpleado", SqlDbType.Int));
                cmd.Parameters["@numeroEmpleado"].Value = mcEntidad.numEmpleado;
                cmd.Parameters.Add(new SqlParameter("@fechaPago", SqlDbType.DateTime));
                cmd.Parameters["@fechaPago"].Value = mcEntidad.fechPago;
                cmd.Parameters.Add(new SqlParameter("@idPlazo", SqlDbType.Int));
                cmd.Parameters["@idPlazo"].Value = mcEntidad.idPla;
                cmd.Parameters.Add(new SqlParameter("@fechaProxPago", SqlDbType.DateTime));
                cmd.Parameters["@fechaProxPago"].Value = mcEntidad.fechProxPago;
                cmd.Parameters.Add(new SqlParameter("@idEstado", SqlDbType.Int));
                cmd.Parameters["@idEstado"].Value = mcEntidad.idEstad;
                cmd.Parameters.Add(new SqlParameter("@montoAPagar", SqlDbType.Int));
                cmd.Parameters["@montoAPagar"].Value = mcEntidad.montAPagar;
                cmd.Parameters.Add(new SqlParameter("@totalPagado", SqlDbType.Int));
                cmd.Parameters["@totalPagado"].Value = mcEntidad.totaPagado;
                cmd.Parameters.Add(new SqlParameter("@idPrestamo", SqlDbType.Int));
                cmd.Parameters["@idPrestamo"].Value = mcEntidad.idPres;
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

        //public bool ActualizarRegistroPago(RegistroPagosEntidad mcEntidad)
        //{
        //    cmd.Connection = cnx;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "SP_ModificarRegistroPagos";
        //    try
        //    {
        //        cmd.Parameters.Add(new SqlParameter("@idRegistroPago", SqlDbType.Int));
        //        cmd.Parameters["@idRegistroPago"].Value = mcEntidad.id;
        //        cmd.Parameters.Add(new SqlParameter("@numeroPrestamo", SqlDbType.Int));
        //        cmd.Parameters["@numeroPrestamo"].Value = mcEntidad.numPrestamo;
        //        cmd.Parameters.Add(new SqlParameter("@numeroEmpleado", SqlDbType.Int));
        //        cmd.Parameters["@numeroEmpleado"].Value = mcEntidad.numEmpleado;
        //        cmd.Parameters.Add(new SqlParameter("@fechaPago", SqlDbType.DateTime));
        //        cmd.Parameters["@fechaPago"].Value = mcEntidad.fechPago;
        //        cmd.Parameters.Add(new SqlParameter("@idPlazo", SqlDbType.Int));
        //        cmd.Parameters["@idPlazo"].Value = mcEntidad.idPla;
        //        cmd.Parameters.Add(new SqlParameter("@fechaProxPago", SqlDbType.DateTime));
        //        cmd.Parameters["@fechaProxPago"].Value = mcEntidad.fechProxPago;
        //        cmd.Parameters.Add(new SqlParameter("@idEstado", SqlDbType.Int));
        //        cmd.Parameters["@idEstado"].Value = mcEntidad.idEstad;
        //        cmd.Parameters.Add(new SqlParameter("@montoAPagar", SqlDbType.Int));
        //        cmd.Parameters["@montoAPagar"].Value = mcEntidad.montAPagar;
        //        cmd.Parameters.Add(new SqlParameter("@totalPagado", SqlDbType.Int));
        //        cmd.Parameters["@totalPagado"].Value = mcEntidad.totaPagado;
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

        //public bool EliminarRegistroPago(RegistroPagosEntidad mcEntidad)
        //{
        //    cmd.Connection = cnx;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "SP_DesactivarRegistroPagos";
        //    try
        //    {
        //        cmd.Parameters.Add(new SqlParameter("@idRegistroPago", SqlDbType.Int));
        //        cmd.Parameters["@idRegistroPago"].Value = mcEntidad.id;
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

        public DataTable ListarRegistroPago(string parametro)
        {
            DataSet dts = new DataSet();
            try
            {
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ListarRegistroPagos";
                cmd.Parameters.Add(new SqlParameter("@numeroPrestamo", parametro));
                SqlDataAdapter miada;
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "RegistroPagos");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
            }
            return (dts.Tables["RegistroPagos"]);
        }

        public RegistroPagosEntidad BuscarRegistroPago(int id)
        {
            try
            {
                SqlDataReader dtr;
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarRegistroPagos";
                cmd.Parameters.Add(new SqlParameter("@idRegistroPago", SqlDbType.Int));
                cmd.Parameters["@idRegistroPago"].Value = id;
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    mcEntidad.id = Convert.ToInt32(dtr[0]);
                    mcEntidad.numPrestamo = Convert.ToInt32(dtr[1]);
                    mcEntidad.numEmpleado = Convert.ToInt32(dtr[2]);
                    mcEntidad.fechPago = Convert.ToDateTime(dtr[3]);
                    mcEntidad.idPla = Convert.ToInt32(dtr[4]);
                    mcEntidad.fechProxPago = Convert.ToDateTime(dtr[5]);
                    mcEntidad.idEstad = Convert.ToInt32(dtr[6]);
                    mcEntidad.montAPagar = Convert.ToInt32(dtr[7]);
                    mcEntidad.totaPagado = Convert.ToInt32(dtr[8]);
                    mcEntidad.idPres = Convert.ToInt32(dtr[9]);
                }
                cnx.Close();
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
                }
                cmd.Parameters.Clear();
            }
        }

        public bool CambiarEstado (RegistroPagosEntidad mcEntidad)
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_CambioEstadoRegPrestamos";
            try
            {

                cmd.Parameters.Add(new SqlParameter("@numeroPrestamo", SqlDbType.Int));
                cmd.Parameters["@numeroPrestamo"].Value = mcEntidad.numPrestamo;
                
                cmd.Parameters.Add(new SqlParameter("@fechaProxPago", SqlDbType.Date, 60));
                cmd.Parameters["@fechaProxPago"].Value = mcEntidad.fechProxPago;

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
    }
}
