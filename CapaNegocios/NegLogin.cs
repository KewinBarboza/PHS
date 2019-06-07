using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    public class NegLogin
    {
        public static DataTable inicioSesion(string nomUsuario, string contraseña)
        {
            return new clsLogin().inicioSesion(nomUsuario, contraseña);
        }
    }
}
