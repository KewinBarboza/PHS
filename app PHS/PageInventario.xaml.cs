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
    /// Lógica de interacción para PageInventario.xaml
    /// </summary>
    public partial class PageInventario : Page
    {
        public PageInventario()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Home());
        }

        private void btnAdministradora_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageInventarioAdministradora());
        }

        private void btnTratamaq_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageInventarioTratamaq() );
        }

        private void btnInversora_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageInventarioInversora() );
        }
    }
}
