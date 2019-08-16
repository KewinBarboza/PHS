using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class clsInventarioAdministradora
    {
        Conexion conexion = new Conexion();

        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();
        DataTable tabla = new  DataTable();

        public DataTable consultarInventarioAdministradora(string movimiento, string material, string fechaDesde, string fechaHasta, int opc)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="consultarInventarioAdministradora";
            comando.CommandType=CommandType.StoredProcedure;

            comando.Parameters.AddWithValue( "@Movimiento", movimiento );
            comando.Parameters.AddWithValue( "@Material", material );
            comando.Parameters.AddWithValue( "@fechaDesde", fechaDesde );
            comando.Parameters.AddWithValue( "@fechaHasta", fechaHasta );
            comando.Parameters.AddWithValue( "@opc", opc );

            leer=comando.ExecuteReader();
            tabla.Load( leer );
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
