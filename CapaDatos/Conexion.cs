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
