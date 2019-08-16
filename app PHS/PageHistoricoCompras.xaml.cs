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
using System.Data.SqlClient;
using System.Data;
using CapaNegocios;
namespace app_PHS
{
    /// <summary>
    /// Lógica de interacción para PageHistoricoCompras.xaml
    /// </summary>
    public partial class PageHistoricoCompras : Page
    {
        public PageHistoricoCompras()
        {
            InitializeComponent();
        }
        private void consultarHistoricoCompras(string compañia, string material,  string codProveedor, int opc)
        {
            DataTable dt = new DataTable();
            dt=NegHistoricoCompras.consultarHistoricoCompras( compañia, material,  codProveedor, opc );

            for (int i = 0; i<dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (opc == 1)
                {

                    txtCodMaterial.Text=dr["material"].ToString()+' '+dr["desMaterial"].ToString();
                }
                else if(opc == 2)
                {
                    txtCodProveedor.Text=dr["cdProveedor"].ToString()+' '+dr["nomProveedor"].ToString();
                }
               
            }
        }

        private void consultarHistoricoComprasDescripcion (string descripcion,int opc)
        {
            DataTable dt = new DataTable();
            dt=NegHistoricoCompras.consultarHistoricoComprasDescripcion( descripcion, opc );
            GridCompras.ItemsSource=dt.DefaultView;
        }
        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageCompras());
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comMaterial_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sumiProveedor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (comMaterial.IsChecked == true)
            {
                if (txtCodBuscar.Text != "" && txtDesBuscar.Text == "")
                {
                    consultarHistoricoCompras( "04", txtCodBuscar.Text, "", 1 );
                }
                else if (txtDesBuscar.Text !="")
                {
                    consultarHistoricoComprasDescripcion(txtDesBuscar.Text,1);
                }
            }
            else if(sumiProveedor.IsChecked ==true)
            {
                if (txtCodBuscar.Text!="")
                {
                    consultarHistoricoCompras( "04", "", txtCodBuscar.Text, 2 );
                }
                else if (txtDesBuscar.Text!="")
                {
                    consultarHistoricoComprasDescripcion( txtDesBuscar.Text, 2 );
                }
            }
            
        }

        private void GridCompras_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
