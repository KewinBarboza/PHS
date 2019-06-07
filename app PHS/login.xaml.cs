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

            foreach (DataRow row in dt.Rows)
            {
                if (dt.Rows.Count == 0)
                {
                    mensajes("Usuario o contraseña inválida intente de nuevo");
                    contraseña.Password = "";
                    nomUsuario.Text = "";

                }
                else
                {
                    clsGeneral.gTipoUsuario = row["rol"].ToString();
                    PHS form = new PHS();
                    this.Hide();
                    form.ShowDialog();
                }
            }

        }

        public void prueba()
        {
            Home p = new Home();
            p.btnFacturas.IsEnabled = true;
            MessageBox.Show("sss");
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

    }
}
