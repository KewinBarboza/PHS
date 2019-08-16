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
    public class NegInventarioAdministradora
    {
        public static DataTable consultarInventarioAdministradora(string movimiento, string material, string fechaDesde, string fechaHasta, int opc)
        {
            return new clsInventarioAdministradora().consultarInventarioAdministradora( movimiento, material, fechaDesde, fechaHasta, opc );
        }
    }
}
