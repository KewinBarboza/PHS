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
    /// Lógica de interacción para PageRecursoHumano.xaml
    /// </summary>
    public partial class PageRecursoHumano : Page
    {
        public PageRecursoHumano()
        {
            InitializeComponent();
        }

        private void btnFichaTrabajador_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageFichaTrabajador());
        }

        private void btnHistoricoSueldo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageHistoricoSueldo());
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new Home() );
        }
    }
}
