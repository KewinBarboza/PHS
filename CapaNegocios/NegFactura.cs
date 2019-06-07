using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    public class NegFactura
    {
        public static DataTable consultarFactura(int numFactura)
        {
            return new clsFactura().consultarFactura( numFactura );
        }

        public static DataTable consultarFacturaFecha(string fechaIni, string fechaFin)
        {
            return new clsFactura().consultarFacturaFecha( fechaIni, fechaFin );
        }

        public static DataTable consultarFacturaCodigoCliente(int codCliente)
        {
            return new clsFactura().consultarFacturaCodigoCliente( codCliente );
        }
    }
}
