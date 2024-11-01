using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace wsTienda
{
    /// <summary>
    /// Descripción breve de wsTienda
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsTienda : System.Web.Services.WebService
    {
        private clssConnection clsConn = new clssConnection();
        private XmlDocument schema;

        public void MiClass(){
            schema = new XmlDocument();
            schema.Load(String.Concat(AppDomain.CurrentDomain.BaseDirectory, "App_Data\\Schemas\\wsTienda\\wsTienda.xml"));
         }

        [WebMethod]
        public DataTable HelloWorld()
        {
            string strSql;
            var dts = new DataTable("detalle_ventas");
            try
            {
                MiClass();
                clsConn.cnx.Open();
                using (SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    strSql = schema.GetElementsByTagName("getDetalleVenta").Item(0).InnerText;  
                    cmd.Connection = clsConn.cnx;
                    cmd.CommandText = strSql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("idCliente", SqlDbType.Int).Value = 0;
                    var adp = new System.Data.SqlClient.SqlDataAdapter();
                    adp.SelectCommand = cmd;
                    adp.Fill(dts);
                }
            }
            catch (Exception ex)
            {
                clsConn.cnx.Close();
                return dts;
                //strSql = ex.Message;
            }
            finally
            {
                clsConn.cnx.Close();
            }
            return dts;
        }

        [WebMethod]
        public DataTable GetHistorial(int nombre, int clave, string estatus)
        {
            string strSql;
            var dts = new DataTable("GetHistorial");
            try
            {
                MiClass();
                clsConn.cnx.Open();
                using (SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.Connection = clsConn.cnx;
                    cmd.CommandText = "Tienda.historailVentas";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@nombre", SqlDbType.Int).Value = nombre;
                    cmd.Parameters.Add("@clave", SqlDbType.Int).Value = clave;
                    cmd.Parameters.Add("@estatus", SqlDbType.VarChar).Value = estatus;
                    cmd.CommandType = CommandType.StoredProcedure;
                    var adp = new System.Data.SqlClient.SqlDataAdapter();
                    adp.SelectCommand = cmd;
                    adp.Fill(dts);
                }
            }
            catch (Exception ex)
            {
                clsConn.cnx.Close();
                return dts;
                //strSql = ex.Message;
            }
            finally
            {
                clsConn.cnx.Close();
            }
            return dts;
        }

        [WebMethod]
        public DataTable getDetalleCompra(int venta_id)
        {
            string strSql;
            var dts = new DataTable("getDetalleCompra");
            try
            {
                MiClass();
                clsConn.cnx.Open();
                using (SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.Connection = clsConn.cnx;
                    cmd.CommandText = "Tienda.getDetalleCompra";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@venta_id", SqlDbType.Int).Value = venta_id;
                    cmd.CommandType = CommandType.StoredProcedure;
                    var adp = new System.Data.SqlClient.SqlDataAdapter();
                    adp.SelectCommand = cmd;
                    adp.Fill(dts);
                }
            }
            catch (Exception ex)
            {
                clsConn.cnx.Close();
                return dts;
                //strSql = ex.Message;
            }
            finally
            {
                clsConn.cnx.Close();
            }
            return dts;
        }
        

        [WebMethod]
        public DataTable getProductos(string estatus)
        {
            string strSql;
            var dts = new DataTable("getProductos");
            try
            {
                MiClass();
                clsConn.cnx.Open();
                using (SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    strSql = schema.GetElementsByTagName("getProductos").Item(0).InnerText;
                    cmd.Connection = clsConn.cnx;
                    cmd.CommandText = strSql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@estatus", SqlDbType.VarChar).Value = estatus;
                    var adp = new System.Data.SqlClient.SqlDataAdapter();
                    adp.SelectCommand = cmd;
                    adp.Fill(dts);
                }
            }
            catch (Exception ex)
            {
                clsConn.cnx.Close();
                return dts;
                //strSql = ex.Message;
            }
            finally
            {
                clsConn.cnx.Close();
            }
            return dts;
        }

        [WebMethod]
        public DataTable getClientes(string estatus)
        {
            string strSql;
            var dts = new DataTable("getClientes");
            try
            {
                MiClass();
                clsConn.cnx.Open();
                using (SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    strSql = schema.GetElementsByTagName("getClientes").Item(0).InnerText;
                    cmd.Connection = clsConn.cnx;
                    cmd.CommandText = strSql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@estatus", SqlDbType.VarChar).Value = estatus;
                    var adp = new System.Data.SqlClient.SqlDataAdapter();
                    adp.SelectCommand = cmd;
                    adp.Fill(dts);
                }
            }
            catch (Exception ex)
            {
                clsConn.cnx.Close();
                return dts;
                //strSql = ex.Message;
            }
            finally
            {
                clsConn.cnx.Close();
            }
            return dts;
        }

        [WebMethod]
        public DataTable getStatus(string estatus)
        {
            string strSql;
            var dts = new DataTable("getStatus");
            try
            {
                MiClass();
                clsConn.cnx.Open();
                using (SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    strSql = schema.GetElementsByTagName("getStatus").Item(0).InnerText;
                    cmd.Connection = clsConn.cnx;
                    cmd.CommandText = strSql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@estatus", SqlDbType.VarChar).Value = estatus;
                    var adp = new System.Data.SqlClient.SqlDataAdapter();
                    adp.SelectCommand = cmd;
                    adp.Fill(dts);
                }
            }
            catch (Exception ex)
            {
                clsConn.cnx.Close();
                return dts;
                //strSql = ex.Message;
            }
            finally
            {
                clsConn.cnx.Close();
            }
            return dts;
        }


        [WebMethod]
        public string saveVenta(int cliente_id, DataTable detalle_compras)
        {
            string strSql;
            int r;
            try
            {
                MiClass();
                clsConn.cnx.Open();
                using (SqlTransaction tran = clsConn.cnx.BeginTransaction())
                {
                    using (SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                    {
                        strSql = schema.GetElementsByTagName("saveVenta").Item(0).InnerText;
                        cmd.Connection = clsConn.cnx;
                        cmd.Transaction = tran;
                        cmd.CommandText = strSql;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@cliente_id", SqlDbType.Int).Value = cliente_id;
                        r = (int)cmd.ExecuteScalar();
                        cmd.Parameters.Clear();

                        cmd.CommandText = schema.GetElementsByTagName("saveVenta_detalle").Item(0).InnerText;
                        foreach (DataRow dr in detalle_compras.Rows)
                        {
                            cmd.Parameters.Add("@producto_id", SqlDbType.Int).Value = dr[0].ToString();
                            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = dr[1].ToString();
                            cmd.Parameters.Add("@descuento", SqlDbType.Decimal).Value = dr[2].ToString();
                            cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = dr[3].ToString();
                            cmd.Parameters.Add("@venta_id", SqlDbType.Int).Value = r;
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                    }
                    tran.Commit();
                    return "exito";
                }
            }
            catch (Exception ex)
            {
                clsConn.cnx.Close();
                return "error";
                //strSql = ex.Message;
            }
            finally
            {
                clsConn.cnx.Close();
            }
            return "error";
        }
    }
}
