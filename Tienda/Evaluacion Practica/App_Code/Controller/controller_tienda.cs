using Evaluacion_Practica.App_Code.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Script.Serialization;

namespace Evaluacion_Practica.App_Code.Controller
{
    public class controller_tienda
    {
        private JavaScriptSerializer srlr = new JavaScriptSerializer();
        public void MiClass()
        {
            //DataTable dt = wsTienda.HelloWorld();
        }

        public string getDetalleCompra(int venta_id)
        {
            var wsTienda = new wsTienda.wsTienda();

          DataTable dt = wsTienda.getDetalleCompra(venta_id);
            var lstReturn = new List<Detalle_comprasVO>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Detalle_comprasVO detalleVenta = new Detalle_comprasVO()
                    {
                        producto_id = (int)dr["producto_id"],
                        descripcion = dr["descripcion"].ToString(),
                        cantidad = (int)dr["cantidad"],
                        costo_unitario = (decimal)dr["costo_unitario"],
                        total = (decimal)dr["total"]
                    };
                    lstReturn.Add(detalleVenta);
                }
                return srlr.Serialize(lstReturn);
            }
            else
            {
                return "error";
            }


            return "dt";
        }


        public string GetHistorial(int nombre, int clave, string estatus)
        {
            var wsTienda = new wsTienda.wsTienda();
            DataTable dt = wsTienda.GetHistorial(nombre, clave, estatus);
            var lstReturn = new List<detalleVentaVO>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    detalleVentaVO detalleVenta = new detalleVentaVO()
                    {
                        clave = dr["clave"].ToString(),
                        nombre = dr["nombre"].ToString(),
                        mail = dr["mail"].ToString(),
                        fecha = dr["fecha"].ToString(),
                        total = (decimal)dr["total"],
                        venta_id = (int)dr["venta_id"]
                    };
                    lstReturn.Add(detalleVenta);
                }
                return srlr.Serialize(lstReturn);
            }
            else
            {
                return "error";
            }


            return "dt";
        }

        public string getProductos(string estatus)
        {
            var wsTienda = new wsTienda.wsTienda();
            DataTable dt = wsTienda.getProductos(estatus);

            var lstReturn = new List<ProductoVO>();
            if(dt != null)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    ProductoVO producto = new ProductoVO()
                    {
                        producto_id = Convert.ToInt32(dr["producto_id"].ToString()),
                        descripcion = dr["descripcion"].ToString(),
                        costo = Convert.ToDecimal(dr["costo_unitario"].ToString())
                    };
                    lstReturn.Add(producto);
                }
                return srlr.Serialize(lstReturn);
            }
            else
            {
                return "error";
            }
        }

        public string getClientes(string estatus)
        {
            var wsTienda = new wsTienda.wsTienda();
            DataTable dt = wsTienda.getClientes(estatus);

            var lstReturn = new List<ClienteVO>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ClienteVO cliente = new ClienteVO()
                    {
                        cliente_id = Convert.ToInt32(dr["cliente_id"].ToString()),
                        nombre = dr["nombre"].ToString(),
                        clave = dr["clave"].ToString(),
                        email = dr["mail"].ToString()
                    };
                    lstReturn.Add(cliente);
                }
                return srlr.Serialize(lstReturn);
            }
            else
            {
                return "error";
            }
        }

        public string getStatus(string estatus)
        {
            var wsTienda = new wsTienda.wsTienda();
            DataTable dt = wsTienda.getStatus(estatus);

            var lstReturn = new List<estatusVO>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    estatusVO estatus1 = new estatusVO()
                    {
                        catalogo_id = dr["catalogo_id"].ToString(),
                        descripcion = dr["descripcion"].ToString()
                    };
                    lstReturn.Add(estatus1);
                }
                return srlr.Serialize(lstReturn);
            }
            else
            {
                return "error";
            }
        }

        

        public string saveVenta(int cliente_id, List<Detalle_comprasVO> detalle_compras)
        {
            var wsTienda = new wsTienda.wsTienda();
            DataTable datalle_venta = new DataTable("datalle_venta");
            datalle_venta.Columns.Add("producto_id", typeof(int));
            datalle_venta.Columns.Add("cantidad", typeof(int));
            datalle_venta.Columns.Add("descunto", typeof(decimal));
            datalle_venta.Columns.Add("total", typeof(decimal));

            foreach (Detalle_comprasVO detalle in detalle_compras)
            {
                DataRow row1 = datalle_venta.NewRow();
                row1["producto_id"] = detalle.producto_id;
                row1["cantidad"] = detalle.cantidad;
                row1["descunto"] = detalle.descuento;
                row1["total"] = detalle.total;
                datalle_venta.Rows.Add(row1);
            }
                return wsTienda.saveVenta(cliente_id, datalle_venta);
                //return "";
        }

        
    }
}