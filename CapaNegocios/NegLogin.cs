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

        public static string registrarUsuarios(int idUs,int idRo,string idUsuario, string nomUsuario, string contraseña, string idRol, bool factura, bool RRHH, bool finanza, bool contabilidad, bool inventario,bool compras, bool despacho,bool ing_contabilidad, bool configuracion)
        {
            clsLogin obj = new clsLogin();
            obj.idUs=idUs;
            obj.idRo=idRo;
            obj.idUsuario=idUsuario;
            obj.nomUsuario=nomUsuario;
            obj.contraseña=contraseña;
            obj.idRol=idRol;
            obj.factura=factura;
            obj.RRHH=RRHH;
            obj.finanza=finanza;
            obj.contabilidad=contabilidad;
            obj.inventario=inventario;
            obj.compras=compras;
            obj.despacho=despacho;
            obj.ing_contabilidad=ing_contabilidad;
            obj.configuracion=configuracion;

            return obj.registrarUsuarios( obj );
        }

        public static DataTable consultarUsuarios(int opcion, string idRol)
        {
            return new clsLogin().consultarUsuarios( opcion, idRol );
        }

        public static DataTable eliminarUsuarios( string idRol)
        {
            return new clsLogin().eliminarUsuarios(  idRol );
            
        }
    } 
}
