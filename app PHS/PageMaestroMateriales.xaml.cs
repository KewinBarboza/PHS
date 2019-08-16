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
            dt=NegMaestroMateriales.consultarMaestroMateriales( textBuscar.Text,"","",0);
            if (dt.Rows.Count == 0)
            {
                mensajes( "Código inválido intente de nuevo" );
            }
            else
            {
                dataGridModificacion.ItemsSource=dt.DefaultView;

                int max = 0; int temp=0;
                for (int i = 0; i<dt.Rows.Count; i++)
                {
                   codEstructura.Text=dt.Rows[i]["Material"].ToString();

                    temp=max;
                    if (Convert.ToInt32( dt.Rows[i]["ind_modificacion"].ToString() ) > max)
                    {
                        max=Convert.ToInt32( dt.Rows[i]["ind_modificacion"].ToString() );
                    }

                    consultarMaestroMaterialesInd( codEstructura.Text,"0"+Convert.ToString(max),1);
                }
            }
        }

        private void consultarMaestroMaterialesInd(string codigo,string indModificacion,int opc)
        {
            DataTable dt = new DataTable();
            dt=NegMaestroMateriales.consultarMaestroMateriales( codigo, indModificacion,"", opc );

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

        private void consultarMaestroMaterialesDesc()
        {
            DataTable dt = new DataTable();
            dt=NegMaestroMateriales.consultarMaestroMateriales( "", "", txtDescripciones.Text, 2 );
            dataGridModificacion.ItemsSource=dt.DefaultView;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageIngProyecto() );
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (textBuscar.Text =="" && txtDescripciones.Text ==""   )
            {
                mensajes( "Ingrese un codigo para ejecutar esta acción" );
            }
            else if (textBuscar.Text!=""&&txtDescripciones.Text!="")
            {
                mensajes( "Ingrese un unico valor" );
            }
            else if(textBuscar.Text != "" && txtDescripciones.Text =="")
            {
                consultarMaestroMateriales();
                textBuscar.Text=string.Empty;
            }
            else if(textBuscar.Text =="" && txtDescripciones.Text!="")
            {
                consultarMaestroMaterialesDesc();
                txtDescripciones.Text=string.Empty;
            }
        }
        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            if (codEstructura.Text!="000000000")
            {
                WindowRepFactura p  = new WindowRepFactura();
                p.reporteMaestroMateriales( codEstructura.Text, txtIndModificacion.Text,"", 1 );
                p.Show();
            }
            else
            {
                mensajes( "ingrese un código para ejecutar esta acción" );
            }
        }

        private void textBuscar_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                btnBuscar_Click( null, null );
            }
        }

        private void dataGridModificacion_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            consultarMaestroMaterialesInd( (dataGridModificacion.CurrentItem as DataRowView).Row.ItemArray[1].ToString(), (dataGridModificacion.CurrentItem as DataRowView).Row.ItemArray[0].ToString(),1 );
        }
    }
}
