using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    /// Lógica de interacción para PageFacturas.xaml
    /// </summary>
    public partial class Home
    {
        public Home()
        {
            InitializeComponent();
        }

        private void mensajes(string mensaje)
        {
            messege.IsActive = true;
            messege.MessageQueue.Enqueue(mensaje);
        }

        private void btnVentas_Click(object sender, RoutedEventArgs e)
        {
            if (clsGeneral.factura==1)
            {
                mensajes( "Acceso denegado" );
            }
            else
            {
                NavigationService.Navigate( new PageVentas() );
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnRRHH_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFinanza_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnContabilidad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnInventario_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCompras_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDespacho_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnIngProyecto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageConfiguracion() );
        }

       
    }
}
