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
    public class NegHistoricoCompras
    {
        public static DataTable consultarHistoricoCompras(string compañia, string material, string codProveedor, int opc)
        {
            return new clsHistoricoCompras().consultarHistoricoCompras( compañia , material, codProveedor, opc );
        }

        public static DataTable consultarHistoricoComprasDescripcion( string descripcion, int opc)
        {
            return new clsHistoricoCompras().consultarHistoricoComprasDescripcion( descripcion, opc );
        }
    }
}
