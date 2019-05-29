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

namespace app_PHS.Pages
{
    /// <summary>
    /// Lógica de interacción para PageFactura.xaml
    /// </summary>
    public partial class PageFactura : Page
    {
        public PageFactura()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new Home() );
        }
    }
}
