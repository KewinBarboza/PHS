using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class clsFacturas
    {
        private Conexion conexion  = new Conexion();

        SqlDataReader leer;
        DataTable tabla =new DataTable();
        SqlCommand comando =new SqlCommand();

        public int numFactura { get; set; }
        public string fechaIni { get; set; }
        public string fechaFin { get; set; }

        public DataTable consultarFactura(int numFactura)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="consultarFactura";
            comando.CommandType=CommandType.StoredProcedure;
            comando.Parameters.AddWithValue( "@numFactura", numFactura );
            leer=comando.ExecuteReader();
            tabla.Load( leer );
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable consultarFacturaFecha(string fechaIni, string fechaFin)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="consultarFacturaFecha";
            comando.CommandType=CommandType.StoredProcedure;
            comando.Parameters.AddWithValue( "@fechaIni", fechaIni );
            comando.Parameters.AddWithValue( "@fechaFin", fechaFin );
            leer=comando.ExecuteReader();
            tabla.Load( leer );
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable consultarFacturaCodigoCliente(int codCliente)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="consultarFacturaCodigoCliente";
            comando.CommandType=CommandType.StoredProcedure;
            comando.Parameters.AddWithValue( "@codCliente", codCliente );
            leer=comando.ExecuteReader();
            tabla.Load( leer );
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
