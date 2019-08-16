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
    public class NegInventarioTratamaq
    {
        public static DataTable consultarInventarioTratamaq(string movimiento, string material, string fechaDesde, string fechaHasta, int opc)
        {
            return new clsInventarioTratamaq().consultarInventarioTratamaq( movimiento, material, fechaDesde, fechaHasta, opc );
        }
    }
}
