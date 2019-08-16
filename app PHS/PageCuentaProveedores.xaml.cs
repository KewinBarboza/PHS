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
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;

namespace app_PHS
{
    /// <summary>
    /// Lógica de interacción para PageCuentaProveedores.xaml
    /// </summary>
    public partial class PageCuentaProveedores : Page
    {
        public PageCuentaProveedores()
        {
            InitializeComponent();
        }

        private void mensajes(string mensaje)
        {
            messege.IsActive=true;
            messege.MessageQueue.Enqueue( mensaje );
        }
        private void consultarCuentaProveedores(string compañia, string codigo, string descripcion, int opc)
        {
            DataTable dt = new DataTable();
            dt=NegCuentaProveedores.consultarCuentaProveedores( compañia, codigo, descripcion, opc );

            if (dt.Rows.Count == 0)
            {
                mensajes("Código invalido intente de nuevo");
            }
            else
            {
                GridCuentasProveedor.ItemsSource=dt.DefaultView;

                for (int i = 0; i<2; i++)
                {
                    GridCuentasProveedor.Columns[i].Visibility=Visibility.Collapsed;
                }

                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    txtCompañia.Text=dr["compañia"].ToString();
                    txtProveedor.Text=dr["codProveedor"].ToString()+' '+dr["proveedor"].ToString();
                }
            }
        }

        private void consultarCuentaProveedoresDescripcion(string compañia, string codigo, string descripcion, int opc)
        {
            DataTable dt = new DataTable();
            dt=NegCuentaProveedores.consultarCuentaProveedores( compañia, codigo, descripcion, opc );

            if (dt.Rows.Count==0)
            {
                mensajes( "Descripción invalida intente de nuevo" );
            }
            else
            {
                GridProveedor.ItemsSource=dt.DefaultView;
            }
            
        }
        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageCompras() );
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (comboCompañia.SelectedItem==null&&txtCodigoProveedor.Text==""&&txtDesBuscar.Text!="")
            {
                consultarCuentaProveedoresDescripcion( "", "", txtDesBuscar.Text, 2 );
            }
            else if (comboCompañia.SelectedItem!=null&&txtCodigoProveedor.Text!=""&&txtDesBuscar.Text=="")
            {
                consultarCuentaProveedores( "04", txtCodigoProveedor.Text, "", 1 );
            }
            else if (comboCompañia.SelectedItem==null&&txtCodigoProveedor.Text==""&&txtDesBuscar.Text=="")
            {
                mensajes( "Ingrese un valor para ejecutar esta acción" );
            }
            else if (comboCompañia.SelectedItem==null||txtCodigoProveedor.Text=="")
            {
                mensajes( "Ingrese un valor para ejecutar esta acción" );
            }
        }

        private void GridProveedor_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void txtCodigoProveedor_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
