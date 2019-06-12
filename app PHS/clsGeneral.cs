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

        public static int factura { get; set; }
        public static int RRHH { get; set; }
        public static int finanza { get; set; }
        public static int contabilidad { get; set; }
        public static int inventario { get; set; }
        public static int compras { get; set; }
        public static int despacho { get; set; }
        public static int ing_contabilidad { get; set; }

        //private void mensajes(string mensaje)
        //{
        //    messege.IsActive = true;
        //    messege.MessageQueue.Enqueue(mensaje);
        //}
    }
}
