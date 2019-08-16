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
    /// Lógica de interacción para PageHistoricoSueldo.xaml
    /// </summary>
    public partial class PageHistoricoSueldo : Page
    {
        public PageHistoricoSueldo()
        {
            InitializeComponent();
        }
        private void mensajes(string mensaje)
        {
            messege.IsActive=true;
            messege.MessageQueue.Enqueue( mensaje );
        }
        private void consultarHistoricoSueldoCodigo(string codigo)
        {
            DataTable dt = new DataTable();
            dt=NegHistoricoSueldo.consultarHistoricoSueldo( codigo, 1 );
            if (dt.Rows.Count==0)
            {
                mensajes( "Código incorrecto" );
            }
            else
            {
                GridHistoricoSueldo.ItemsSource=dt.DefaultView;

                for (int i = 0; i<6; i++)
                {
                    GridHistoricoSueldo.Columns[i].Visibility=Visibility.Collapsed;
                }

                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    txtNombre.Text=quitarEspacios( dr["nombre"].ToString() )+" / "+dr["clase"].ToString();
                    txtCodTrabajador.Text=dr["codigo"].ToString();
                    txtCedula.Text=dr["cedula"].ToString();
                    txtFecIng.Text=dr["fecIngreso"].ToString();
                    txtCargo.Text=dr["cargo"].ToString();
                    txtNivEduc.Text=dr["nivel"].ToString();
                }
            }
            
        }

        private void consultarHistoricoSueldoNombreCedula()
        {
            DataTable dt = new DataTable();
            dt=NegHistoricoSueldo.consultarHistoricoSueldo( txtBuscar.Text, 2 );

            if (dt.Rows.Count ==0)
            {
                mensajes( "Nombre o cedula incorrecto" );
            }
            else
            {
                GridSueldo.ItemsSource=dt.DefaultView;
            }
        }

        static string quitarEspacios(string nombre)
        {
            while (nombre.Contains( "  " ))
            {
                nombre=nombre.Replace( "  ", " " );
            }
            return nombre;
        }
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text!=""&&txtCodigo.Text=="")
            {
                consultarHistoricoSueldoNombreCedula();
                txtBuscar.Text=string.Empty;
            }
            else if (txtCodigo.Text!=""&&txtBuscar.Text=="")
            {
                consultarHistoricoSueldoCodigo( txtCodigo.Text );
                txtCodigo.Text=string.Empty;
            }
            else if (txtBuscar.Text!=""&&txtCodigo.Text!="")
            {
                mensajes( "Ingrese un único valor" );
            }
        }
        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodTrabajador.Text=="xxxxxxxxx")
            {
                mensajes( "Realice una consulta para ejecutar esta acción" );
            }
            else
            {
                WindowRepFactura p  = new WindowRepFactura();
                p.ReportHistoricoSueldo( txtCodTrabajador.Text, 1 );
                p.Show();
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageRecursoHumano());
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                Mouse.OverrideCursor=Cursors.Wait;
                btnBuscar_Click( null, null );
                Mouse.OverrideCursor=Cursors.Arrow;
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                Mouse.OverrideCursor=Cursors.Wait;
                btnBuscar_Click( null, null );
                Mouse.OverrideCursor=Cursors.Arrow;
            }
        }

        private void GridSueldo_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            consultarHistoricoSueldoCodigo( (GridSueldo.CurrentItem as DataRowView).Row.ItemArray[0].ToString() );
        }
    }
}
