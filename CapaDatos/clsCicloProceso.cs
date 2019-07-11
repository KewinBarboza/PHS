using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class clsCicloProceso
    {
        private Conexion conexion = new Conexion();

        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();
        DataTable tabla = new DataTable();

        public DataTable consultarCicloProcesos(string codigo, string IndModificacion, string indProceso,int opc)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="consultarCicloProcesos";
            comando.CommandType=CommandType.StoredProcedure;
            comando.Parameters.AddWithValue( "@codigo", codigo );
            comando.Parameters.AddWithValue( "@indProceso", indProceso );
            comando.Parameters.AddWithValue( "@IndModificacion", IndModificacion );
            comando.Parameters.AddWithValue( "@opc", opc );
            leer=comando.ExecuteReader();
            tabla.Load( leer );
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
