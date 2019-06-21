using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class clsClientes
    {
        private Conexion conexion  = new Conexion();

        SqlDataReader leer;
        DataTable tabla =new DataTable();
        SqlCommand comando =new SqlCommand();

        public string nomCliente { get; set; }
        public string numRif { get; set; }
        public int status { get; set; }

        public DataTable consultarClienteRif(string numRif)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="consultarClienteRif";
            comando.CommandType=CommandType.StoredProcedure;
            comando.Parameters.AddWithValue( "@numRif", numRif );
            leer=comando.ExecuteReader();
            tabla.Load( leer );
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable consultarClientesNombre(string nomCliente)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="consultarClientesNombre";
            comando.CommandType=CommandType.StoredProcedure;
            comando.Parameters.AddWithValue( "@nomCliente", nomCliente );
            leer=comando.ExecuteReader();
            tabla.Load( leer );
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable cunsultarClientesActivos(int status)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="cunsultarClientesActivos";
            comando.CommandType=CommandType.StoredProcedure;
            comando.Parameters.AddWithValue( "@status", status );
            leer=comando.ExecuteReader();
            tabla.Load( leer );
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
