using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace wsTienda
{
    public class clssConnection
    {
        static string strCnx = ConfigurationManager.ConnectionStrings["conectionDB"].ConnectionString;

        public SqlConnection cnx = new SqlConnection(strCnx);
    }
}