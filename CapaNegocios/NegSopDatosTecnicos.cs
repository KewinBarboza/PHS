using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaNegocios
{
    public class NegSopDatosTecnicos
    {
        public static DataTable consultarSopDatosTecnicos(string codigo,string indModificacion,string indProceso,string operacion,int opc)
        {
            return new clsSopDatosTecnicos().consultarSopDatosTecnicos(codigo,indModificacion,indProceso,operacion,opc);
        }
    }
}
