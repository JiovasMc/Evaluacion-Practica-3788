using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluacion_Practica.App_Code.VO
{
    public class estatusVO
    {
        private string p_catalogo_id;
        private string p_descripcion;
        public estatusVO() { }

        public string catalogo_id { get => p_catalogo_id; set => p_catalogo_id = value; }
        public string descripcion { get => p_descripcion; set => p_descripcion = value; }
    }
}