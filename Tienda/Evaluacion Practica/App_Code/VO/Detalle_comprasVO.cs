using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluacion_Practica.App_Code.VO
{
    public class Detalle_comprasVO
    {
        private int p_producto_id;
        private int p_cantidad;
        private decimal p_descuento;
        private decimal p_total;
        private string p_descripcion;
        private decimal p_costo_unitario;
        public Detalle_comprasVO() { }

        public int producto_id { get => p_producto_id; set => p_producto_id = value; }
        public int cantidad { get => p_cantidad; set => p_cantidad = value; }
        public decimal descuento { get => p_descuento; set => p_descuento = value; }
        public decimal total { get => p_total; set => p_total = value; }
        public string descripcion { get => p_descripcion; set => p_descripcion = value; }
        public decimal costo_unitario { get => p_costo_unitario; set => p_costo_unitario = value; }
    }
}