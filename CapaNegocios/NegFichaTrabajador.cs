using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocios
{
    public class NegFichaTrabajador
    {
        public static DataTable consultarFichaTrabajador(string buscar, int opc)
        {
            return new clsFichaTrabajador().consultarFichaTrabajador( buscar, opc );
        }
    }
}
