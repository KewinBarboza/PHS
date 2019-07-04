using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class clsProcesos
    {
        private Conexion conexion  = new Conexion();

        SqlDataReader leer;
        DataTable tabla =new DataTable();
        SqlCommand comando =new SqlCommand();

        public DataTable consultarPartesPiezas(string codigo)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="consultarPartesPiezas";
            comando.CommandType=CommandType.StoredProcedure;
            comando.Parameters.AddWithValue( "@codigo", codigo );
            leer=comando.ExecuteReader();
            tabla.Load( leer );
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable consultarParasPiezasIndice(string codigo, string IndModificacion, string indProceso)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="consultarParasPiezasIndice";
            comando.CommandType=CommandType.StoredProcedure;
            comando.Parameters.AddWithValue( "@codigo", codigo );
            comando.Parameters.AddWithValue( "@indProceso", indProceso );
            comando.Parameters.AddWithValue( "@IndModificacion", IndModificacion );
            leer=comando.ExecuteReader();
            tabla.Load( leer );
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
