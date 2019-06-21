using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
   public class NegClientes
    {
        public static DataTable consultarClienteRif(string numRif)
        {
            return new clsClientes().consultarClienteRif( numRif );
        }

        public static DataTable consultarClientesNombre(string nomCliente)
        {
            return new clsClientes().consultarClientesNombre( nomCliente );
        }

        public static DataTable cunsultarClientesActivos(int status)
        {
            return new clsClientes().cunsultarClientesActivos( status );
        }
    }
}
