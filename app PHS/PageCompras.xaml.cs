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
    /// Lógica de interacción para PageCompras.xaml
    /// </summary>
    public partial class PageCompras : Page
    {
        public PageCompras()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new Home() );
        }

        private void btnHistoricoCompras_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageHistoricoCompras() );
        }

        private void btnCuentaProveedores_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageCuentaProveedores() );
        }

        private void btnMaestroProveedores_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageMaestroProveedores() );
        }
    }
}
