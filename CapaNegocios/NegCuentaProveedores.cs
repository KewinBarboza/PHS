using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocios
{
    public class NegCuentaProveedores
    {
        public static DataTable consultarCuentaProveedores(string compañia, string codigo, string descripcion, int opc)
        {
            return new clsCuentaProveedores().consultarCuentaProveedores( compañia, codigo, descripcion, opc );
        }
    }
}
