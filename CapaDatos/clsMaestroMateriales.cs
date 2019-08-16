using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class clsMaestroMateriales
    {
        private Conexion conexion = new Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public string codigo { get; set; }
        public string indModificacion { get; set; }
        public int opc { get; set; }

        public DataTable consultarMaestroMateriales(string codigo, string indModificacion,string desc, int opc)
        { 
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="mstroMateriales";
            comando.CommandType=CommandType.StoredProcedure;
            comando.Parameters.AddWithValue( "@codigo", codigo );
            comando.Parameters.AddWithValue( "@indModificacion", indModificacion );
            comando.Parameters.AddWithValue( "@desc", desc );
            comando.Parameters.AddWithValue( "@opc", opc );
            leer=comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
