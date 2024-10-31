using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using controller_tienda;

namespace Evaluacion_Practica.Forms.Compra
{
    public partial class detalleCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod (UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static string GetHistorial() 
        {
            Miclase controller_tienda = new controller_tienda.Miclase();
            string mensaje = "nuevo mensaje";
            mensaje += "nuevo mensaje";
            return mensaje;
        }

    }
}