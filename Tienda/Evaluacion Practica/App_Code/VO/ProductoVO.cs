using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluacion_Practica.App_Code.VO
{
    public class ProductoVO
    {
        private int p_producto_id;
        private string p_descripcion;
        private decimal p_costo;

        public int producto_id { get => p_producto_id; set => p_producto_id = value; }
        public string descripcion { get => p_descripcion; set => p_descripcion = value; }
        public decimal costo { get => p_costo; set => p_costo = value; }
    }
}