using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class clsLogin
    {
        private Conexion conexion = new Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //public int numFactura { get; set; }
        public string nomUsuario { get; set; }
        public string contraseña { get; set; }
        public DataTable inicioSesion(string nomUsuario, string contraseña)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "inicioSesion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomUsuario", nomUsuario);
            comando.Parameters.AddWithValue("@contraseña", contraseña);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
