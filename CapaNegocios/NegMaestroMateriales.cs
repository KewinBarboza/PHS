using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NegMaestroMateriales
    {
        public static DataTable consultarMaestroMateriales(string codigo, string indModificacion,string desc, int opc)
        {
            return new clsMaestroMateriales().consultarMaestroMateriales( codigo, indModificacion,desc, opc );
        }
    }
}
 