using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_PHS
{
    class clsGeneral
    {
        //----------------------------------------------------------
        // Variable globales de la aplicación 
        //----------------------------------------------------------

        public static bool factura { get; set; }
        public static bool RRHH { get; set; }
        public static bool finanza { get; set; }
        public static bool contabilidad { get; set; }
        public static bool inventario { get; set; }
        public static bool compras { get; set; }
        public static bool despacho { get; set; }
        public static bool ing_contabilidad { get; set; }
        public static bool configuracion { get; set; }

        //private void mensajes(string mensaje)
        //{
        //    messege.IsActive = true;
        //    messege.MessageQueue.Enqueue(mensaje);
        //}
    }
}
