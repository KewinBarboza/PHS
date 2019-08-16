using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class clsHistoricoCompras
    {
        private Conexion conexion  = new Conexion();

        SqlDataReader leer;
        DataTable tabla =new DataTable();
        SqlCommand comando =new SqlCommand();

        public DataTable consultarHistoricoCompras(string compañia, string material, string codProveedor,int opc)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="consultarHistoricoCompras";
            comando.CommandType=CommandType.StoredProcedure;
            comando.Parameters.AddWithValue( "@compañia", compañia );
            comando.Parameters.AddWithValue( "@material", material );
            comando.Parameters.AddWithValue( "@codProveedor", codProveedor );
            comando.Parameters.AddWithValue( "@opc", opc );
            leer=comando.ExecuteReader();
            tabla.Load( leer );
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable consultarHistoricoComprasDescripcion( string @descripcion,  int opc)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="consultarHistoricoComprasDescripcion";
            comando.CommandType=CommandType.StoredProcedure;
            comando.Parameters.AddWithValue( "@descripcion", descripcion );
            comando.Parameters.AddWithValue( "@opc", opc );
            leer=comando.ExecuteReader();
            tabla.Load( leer );
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
 