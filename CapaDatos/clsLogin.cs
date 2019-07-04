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

        public string nomUsuario { get; set; }
        public string contraseña { get; set; }
        public int idRo { get; set; }
        public int idUs { get; set; }
        public string idUsuario { get; set; }
        public int opcion { get; set; }
        public string idRol { get; set; }
        public bool factura { get; set; }
        public bool RRHH { get; set; }
        public bool finanza { get; set; }
        public bool contabilidad { get; set; }
        public bool inventario { get; set; }
        public bool compras { get; set; }
        public bool despacho { get; set; }
        public bool ing_contabilidad { get; set; }
        public bool configuracion { get; set; }

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

        public string registrarUsuarios(clsLogin obj)
        {
            string rpta="";

            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="registrarUsuario";
            comando.CommandType=CommandType.StoredProcedure;

            comando.Parameters.AddWithValue( "@idUs", obj.idUs );
            comando.Parameters.AddWithValue( "@idRo", obj.idRo );
            comando.Parameters.AddWithValue( "@idUsuario", obj.idUsuario );
            comando.Parameters.AddWithValue( "@nom_usuario", obj.nomUsuario );
            comando.Parameters.AddWithValue( "@clave", obj.contraseña );
            comando.Parameters.AddWithValue( "@idRol", obj.idRol );
            comando.Parameters.AddWithValue( "@factura", obj.factura );
            comando.Parameters.AddWithValue( "@RRHH", obj.RRHH );
            comando.Parameters.AddWithValue( "@finanza", obj.finanza );
            comando.Parameters.AddWithValue( "@contabilidad", obj.contabilidad );
            comando.Parameters.AddWithValue( "@inventario", obj.inventario );
            comando.Parameters.AddWithValue( "@compras", obj.compras );
            comando.Parameters.AddWithValue( "@despacho", obj.despacho );
            comando.Parameters.AddWithValue( "@ing_contabilidad", obj.ing_contabilidad );
            comando.Parameters.AddWithValue( "@configuracion", obj.configuracion );

            rpta=comando.ExecuteNonQuery()==1 ? "OK" : "NO";
            return rpta;
        }

        public DataTable consultarUsuarios(int opcion, string idRol)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="consultarUsuarios";
            comando.CommandType=CommandType.StoredProcedure;
            comando.Parameters.AddWithValue( "@opc", opcion );
            comando.Parameters.AddWithValue( "@idRol", idRol );
            leer=comando.ExecuteReader();
            tabla.Load( leer );
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable eliminarUsuarios( string idRol)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText="eliminarUsuarios";
            comando.CommandType=CommandType.StoredProcedure;
            //comando.Parameters.AddWithValue( "@id", opcion );
            comando.Parameters.AddWithValue( "@idRol", idRol );
            leer=comando.ExecuteReader();
            tabla.Load( leer );
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
