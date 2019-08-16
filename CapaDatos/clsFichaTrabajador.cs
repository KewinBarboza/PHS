using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class clsFichaTrabajador
    {
        Conexion conexion = new Conexion();

        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();
        DataTable tabla = new  DataTable();

        public DataTable consultarFichaTrabajador(string buscar, int opc)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="consultarFichaTrabajador";
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
