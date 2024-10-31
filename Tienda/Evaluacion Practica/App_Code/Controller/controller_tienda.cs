using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Evaluacion_Practica.App_Code.Controller
{
    public class controller_tienda
    {
        public void MiClass()
        {

        }
        public string getDetalle_venta()
        {
            var wsTienda = new wsTienda.wsTienda();
            DataSet dt = wsTienda.HelloWorld();
            return "dt";
        }
    }
}