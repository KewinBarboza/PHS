using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CapaNegocios;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace app_PHS
{
    /// <summary>
    /// Lógica de interacción para login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void inicioSesion()
        {
            DataTable dt = new DataTable();
            dt = NegLogin.inicioSesion(nomUsuario.Text, contraseña.Password.ToString());

            if (dt.Rows.Count ==0)
            {
                mensajes( "Usuario o contraseña inválida intente de nuevo" );
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {

                    clsGeneral.factura=Convert.ToBoolean( row["factura"].ToString() );
                    clsGeneral.RRHH=Convert.ToBoolean( row["RRHH"].ToString() );
                    clsGeneral.finanza=Convert.ToBoolean( row["finanza"].ToString() );
                    clsGeneral.contabilidad=Convert.ToBoolean( row["contabilidad"].ToString() );
                    clsGeneral.inventario=Convert.ToBoolean( row["inventario"].ToString() );
                    clsGeneral.compras=Convert.ToBoolean( row["compras"].ToString() );
                    clsGeneral.despacho=Convert.ToBoolean( row["despacho"].ToString() );
                    clsGeneral.ing_contabilidad=Convert.ToBoolean( row["ing_contabilidad"].ToString() );
                    clsGeneral.configuracion=Convert.ToBoolean( row["configuracion"].ToString() );


                    PHS form = new PHS();
                    this.Hide();
                    form.ShowDialog();

                }
            }
            

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            if (nomUsuario.Text == "" || contraseña.Password == "")
            {
                mensajes("Ingrese nombre de usuario y contraseña");
            }
            else
            {
                inicioSesion();
            }

        }
        private void mensajes(string mensaje)
        {
            messege.IsActive = true;
            messege.MessageQueue.Enqueue(mensaje);
        }

        private void contraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                BtnInicio_Click( null, null );
            }
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            contraseña.Focusable=true;
            contraseña.Focus();
           
        }
    }
}
