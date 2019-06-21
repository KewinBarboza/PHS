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
    /// Lógica de interacción para PageVentas.xaml
    /// </summary>
    public partial class PageVentas : Page
    {
        public PageVentas()
        {
            InitializeComponent();
        }
        private void btnFacturas_Click(object sender, RoutedEventArgs e)
        {
            if (clsGeneral.factura==1)
            {
                //mensajes( "Acceso denegado" );
            }
            else
            {
                NavigationService.Navigate( new PageFacturas() );
            }
        }
        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new Home() );
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageClientes() );
        }
    }
}
