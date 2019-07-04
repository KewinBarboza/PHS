using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    class clsMaestroMateriales
    {
        private Conexion conexion = new Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable consultarMaestroMateriales(string codigo)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="";
            comando.CommandText=CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigo",codigo);
            leer=comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
