using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluacion_Practica.App_Code.VO
{
    public class ClienteVO
    {
        private int p_cliente_id;
        private string p_nombre;
        private string p_clave;
        private string p_email;

        public ClienteVO() { }

        public int cliente_id { get => p_cliente_id; set => p_cliente_id = value; }
        public string nombre { get => p_nombre; set => p_nombre = value; }
        public string clave { get => p_clave; set => p_clave = value; }
        public string email { get => p_email; set => p_email = value; }
    }
}