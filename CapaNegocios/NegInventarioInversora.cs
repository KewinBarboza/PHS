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
    public class NegInventarioInversora
    {
        public static DataTable consultarInventarioInversora(string movimiento,string material,string fechaDesde,string fechaHasta,int opc)
        {
             return new clsInventarioInversora().consultarInventarioInversora( movimiento,material,fechaDesde,fechaHasta,opc);
        }

        public static DataTable consultarMovimientos()
        {
            return new clsInventarioInversora().consultarMovimientos();
        }

        public static DataTable consultarDescripcionInventario(string descripcion, int opc)
        {
            return new clsInventarioInversora().consultarDescripcionInventario( descripcion, opc );
        }
    }
}
