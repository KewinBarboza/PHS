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
            if (clsGeneral.factura==false)
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
            if (clsGeneral.RRHH==false)
            {
                mensajes( "Acceso denegado" );
            }
            else
            {
                NavigationService.Navigate( new PageRecursoHumano() );
            }
        }

        private void btnFinanza_Click(object sender, RoutedEventArgs e)
        {
            if (clsGeneral.finanza==false)
            {
                mensajes( "Acceso denegado" );
            }
            else
            {
                //NavigationService.Navigate( new PageVentas() );
            }
        }

        private void BtnContabilidad_Click(object sender, RoutedEventArgs e)
        {
            if (clsGeneral.contabilidad==false)
            {
                mensajes( "Acceso denegado" );
            }
            else
            {
                //NavigationService.Navigate( new PageVentas() );
            }
        }

        private void BtnInventario_Click(object sender, RoutedEventArgs e)
        {
            if (clsGeneral.inventario==false)
            {
                mensajes( "Acceso denegado" );
            }
            else
            {
                NavigationService.Navigate( new PageInventario() );
            }
        }

        private void BtnCompras_Click(object sender, RoutedEventArgs e)
        {
            if (clsGeneral.compras==false)
            {
                mensajes( "Acceso denegado" );
            }
            else
            {
                NavigationService.Navigate( new PageCompras() );
            }
        }

        private void BtnDespacho_Click(object sender, RoutedEventArgs e)
        {
            if (clsGeneral.despacho==false)
            {
                mensajes( "Acceso denegado" );
            }
            else
            {
                //NavigationService.Navigate( new PageVentas() );
            }
        }

        private void BtnIngProyecto_Click(object sender, RoutedEventArgs e)
        {
            if (clsGeneral.ing_contabilidad==false)
            {
                mensajes( "Acceso denegado" );
            }
            else
            {
                NavigationService.Navigate( new PageIngProyecto() );
            }
        }

        private void BtnConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            if (clsGeneral.configuracion==false)
            {
                mensajes( "Acceso denegado" );
            }
            else
            {
                NavigationService.Navigate( new PageConfiguracion() );
            }

        }

       
    }
}
