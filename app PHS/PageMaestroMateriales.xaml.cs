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
using CapaNegocios;

namespace app_PHS
{
    /// <summary>
    /// Lógica de interacción para PageMaestroMateriales.xaml
    /// </summary>
    public partial class PageMaestroMateriales : Page
    {
        public PageMaestroMateriales()
        {
            InitializeComponent();
        }

        private void mensajes(string mensaje)
        {
            messege.IsActive=true;
            messege.MessageQueue.Enqueue( mensaje );
        }

        private void consultarMaestroMateriales()
        {
            DataTable dt = new DataTable();
            dt=NegMaestroMateriales.consultarMaestroMateriales( textBuscar.Text,"",0);
            if (dt.Rows.Count == 0)
            {
                mensajes( "Código inválido intente de nuevo" );
            }
            else
            {
                int max = 0; int temp=0;
                for (int i = 0; i<dt.Rows.Count; i++)
                {
                   codEstructura.Text=dt.Rows[i]["Material"].ToString();
                   comboIndModificacion.Items.Add(  dt.Rows[i]["ind_modificacion"].ToString());

                    temp=max;
                    if (Convert.ToInt32( dt.Rows[i]["ind_modificacion"].ToString() ) > max)
                    {
                        max=Convert.ToInt32( dt.Rows[i]["ind_modificacion"].ToString() );
                    }

                    consultarMaestroMaterialesInd( codEstructura.Text,"0"+Convert.ToString(max),1);
                }
                comboIndModificacion.IsEnabled=true;
            }
        }

        private void consultarMaestroMaterialesInd(string codigo,string indModificacion,int opc)
        {
            DataTable dt = new DataTable();
            dt=NegMaestroMateriales.consultarMaestroMateriales( codigo, indModificacion, opc );

            if (dt.Rows.Count == 0)
            {
                mensajes( "Código inválido intente de nuevo" );
            }
            else
            {
                GridMaestroMateriales.ItemsSource=dt.DefaultView;
                for (int i = 0; i<6; i++)
                {
                    GridMaestroMateriales.Columns[i].Visibility=Visibility.Collapsed;
                }

                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    codEstructura.Text=dt.Rows[i]["Material"].ToString();
                    txtDescripcion.Text=dt.Rows[i]["Descripción"].ToString();
                    txtIndModificacion.Text=dt.Rows[i]["ind_modificacion"].ToString();
                    txtFecEmision.Text=dt.Rows[i]["fec_emicion"].ToString();
                
                }
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageIngProyecto() );
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (textBuscar.Text =="")
            {
                mensajes( "Ingrese un codigo para ejecutar esta acción" );
            }
            else
            {
                comboIndModificacion.Items.Clear();
                consultarMaestroMateriales();
            }
        }

        private void btnIndices_Click(object sender, RoutedEventArgs e)
        {
            if (comboIndModificacion.SelectedIndex.ToString() =="-1")
            {
                mensajes( "Ingrese un codigo para ejecutar esta acción" );
            }else
            {
                consultarMaestroMaterialesInd(textBuscar.Text,comboIndModificacion.SelectedItem.ToString(),1);
            }
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            if (codEstructura.Text!="000000000")
            {
                WindowRepFactura p  = new WindowRepFactura();
                p.reporteMaestroMateriales( codEstructura.Text, txtIndModificacion.Text, 1 );
                p.Show();
            }
            else
            {
                mensajes( "ingrese un código para ejecutar esta acción" );
            }
        }

        private void textBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBuscar.Text=="")
            {
                comboIndModificacion.IsEnabled=false;
                comboIndModificacion.Items.Clear();
            }
        }

        private void textBuscar_Loaded(object sender, RoutedEventArgs e)
        {
            comboIndModificacion.IsEnabled=false;
        }

        private void textBuscar_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                btnBuscar_Click( null, null );
            }
        }
    }
}
