using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NegCicloProceso
    {
        public static DataTable consultarCicloProcesos(string codigo,string indModificacion, string indProceso, int opc)
        {
            return new clsCicloProceso().consultarCicloProcesos(codigo,indModificacion,indProceso,opc);
        }
    }
}
