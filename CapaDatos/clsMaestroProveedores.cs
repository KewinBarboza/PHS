using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class clsMaestroProveedores
    {
        private Conexion conexion = new Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        public DataTable consultarMaestroProveedores(string buscar, int opc)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="consultarMaestroProveedores";
            comando.CommandType=CommandType.StoredProcedure;
            comando.Parameters.AddWithValue( "@buscar", buscar );
            comando.Parameters.AddWithValue( "@opc", opc );
            leer=comando.ExecuteReader();
            tabla.Load( leer );
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
