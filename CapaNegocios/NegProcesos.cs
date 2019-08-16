using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NegProcesos
    {
        public static DataTable consultarPartesPiezas(string codigo)
        {
            return new clsProcesos().consultarPartesPiezas( codigo );
        }

        public static DataTable consultarParasPiezasIndice(string codigo, string IndModificacion, string indProceso)
        {
            return new clsProcesos().consultarParasPiezasIndice( codigo ,IndModificacion,indProceso);
        }

        public static DataTable consultarPartesPiezasDescripcion(string desc)
        {
            return new clsProcesos().consultarPartesPiezasDescripcion(desc);
        }
    }
}
