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

        public void miclase(){
            schema = new XmlDocument();
            schema.Load(String.Concat(AppDomain.CurrentDomain.BaseDirectory, "App_Data\\Schemas\\wsTienda.xml"));
         }

        [WebMethod]
        public DataSet HelloWorld()
        {
             string strSql;
             var dts = new DataSet();
            try
            {
                clsConn.cnx.Open();
                using (SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    strSql = schema.GetElementsByTagName("getDetalleVenta").Item(0).InnerText;  
                    cmd.Connection = clsConn.cnx;
                    cmd.CommandText = strSql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("idCliente", SqlDbType.Int).Value = 0;
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
    }
}
