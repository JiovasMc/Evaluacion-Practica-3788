using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluacion_Practica.App_Code.VO
{
    public class detalleVentaVO
    {

        private string p_clave;
        private string p_nombre;
        private string p_mail;
        private string p_fecha;
        private decimal p_total;
        private int p_venta_id;
        public detalleVentaVO() { }

        public string clave { get => p_clave; set => p_clave = value; }
        public string nombre { get => p_nombre; set => p_nombre = value; }
        public string mail { get => p_mail; set => p_mail = value; }
        public string fecha { get => p_fecha; set => p_fecha = value; }
        public decimal total { get => p_total; set => p_total = value; }
        public int venta_id { get => p_venta_id; set => p_venta_id = value; }
    }
}