using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Evaluacion_Practica.App_Code.Controller;
using Evaluacion_Practica.App_Code.VO;

namespace Evaluacion_Practica.Forms.Compra
{
    public partial class detalleCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod (UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static string GetHistorial(int nombre, int clave, string estatus) 
        {
            var controller_tienda = new controller_tienda();
            return controller_tienda.GetHistorial(nombre, clave, estatus);
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static string getDrls(string opt, string estatus)
        {
            var controller_tienda = new controller_tienda();
            switch (opt)
            {
                case "1":
                    return controller_tienda.getProductos(estatus);
                    break;
                case "2":
                    return controller_tienda.getClientes(estatus);
                    break;
                case "3":
                    return controller_tienda.getStatus(estatus);
                    break;
                default:
                    return "";
                    break;

            }

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static string saveVenta(int cliente_id, List<Detalle_comprasVO> detalle_compras)
        {
            var controller_tienda = new controller_tienda();
            return controller_tienda.saveVenta(cliente_id, detalle_compras);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static string getDetalleCompra(int venta_id)
        {
            var controller_tienda = new controller_tienda();
            return controller_tienda.getDetalleCompra(venta_id);
        }
        

    }
}