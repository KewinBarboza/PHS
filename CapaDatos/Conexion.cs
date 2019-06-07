using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        //public static string cn = "Data Source=192.168.0.68\\MSSQLSERVER2014;Initial Catalog=bdPHS;User ID=sa";
        private SqlConnection cnPHS = new SqlConnection("Data Source=192.168.0.68\\MSSQLSERVER2014;Initial Catalog=bdPHS;User ID=sa");
        public SqlConnection AbrirConexion()
        {
            if (cnPHS.State==ConnectionState.Closed)
                cnPHS.Open();

            return cnPHS;
        }

        public SqlConnection CerrarConexion()
        {
            if (cnPHS.State==ConnectionState.Open)
                cnPHS.Close();

            return cnPHS;
        }
    }
}
