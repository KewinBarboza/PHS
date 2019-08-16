using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class clsSopDatosTecnicos
    {
        Conexion conexion = new Conexion();

        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();
        DataTable tabla = new DataTable();

        public DataTable consultarSopDatosTecnicos(string codigo,string indModificacion,string indProceso, string operacion,int opc)
        {

            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="consultarSopDatosTecnicos";
            comando.CommandType=CommandType.StoredProcedure;

            comando.Parameters.AddWithValue( "@codigo",codigo);
            comando.Parameters.AddWithValue( "@indModificacion",indModificacion);
            comando.Parameters.AddWithValue( "@indProceso", indProceso);
            comando.Parameters.AddWithValue( "@operacion", operacion );
            comando.Parameters.AddWithValue( "@opc",opc);

            leer=comando.ExecuteReader();
            tabla.Load( leer );
            conexion.CerrarConexion();
            return tabla;

        }
        
    }
}
