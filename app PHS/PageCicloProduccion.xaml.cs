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
    /// Lógica de interacción para PageCicloProduccion.xaml
    /// </summary>
    public partial class PageCicloProduccion : Page
    {
        public PageCicloProduccion()
        {
            InitializeComponent();
        }

        private void mensajes(string mensaje)
        {
            messege.IsActive=true;
            messege.MessageQueue.Enqueue( mensaje );
        }

        private void consultarCicloProcesos()
        {
            DataTable dt =new DataTable();
            dt=NegCicloProceso.consultarCicloProcesos(textBuscar.Text,"","",0);

            if (dt.Rows.Count == 0)
            {
                mensajes( "Código inválido intente de nuevo" );
            }
            else
            {
                int max = 0; int temp=0;
                int max2 = 0; int temp2=0;
                for (int i = 0; i<dt.Rows.Count; i++)
                {

                    codCiclo.Text=dt.Rows[i]["CODIGO"].ToString();
                    comboIndMod.Items.Add(dt.Rows[i]["IM"].ToString());
                    comboIndPro.Items.Add(dt.Rows[i]["ind_proceso"].ToString());

                    temp=max;
                    temp2=max2;
                    if (Convert.ToInt32( dt.Rows[i]["IM"].ToString() )>max && Convert.ToInt32( dt.Rows[i]["ind_proceso"].ToString() )>max2)
                    {
                        max=Convert.ToInt32( dt.Rows[i]["IM"].ToString() );
                        max2=Convert.ToInt32( dt.Rows[i]["ind_proceso"].ToString() );
                    }

                    consultarCicloProcesosIndices(codCiclo.Text,"0"+Convert.ToString( max ), "0"+Convert.ToString( max2 ), 1);
                }
                comboIndMod.IsEnabled=true;
                comboIndPro.IsEnabled=true;
            }


        }

        private void consultarCicloProcesosIndices(string codigo,string indProceso,string indModificacion,int opc)
        {
            DataTable dt = new DataTable();
            dt=NegCicloProceso.consultarCicloProcesos( codigo, indProceso, indModificacion, opc );

            if (dt.Rows.Count ==0 )
            {
                mensajes( "Código inválido intente de nuevo" );
            }
            else
            {
                GridCicloProduccion.ItemsSource=dt.DefaultView;

                for (int i = 0; i<6; i++)
                {
                    GridCicloProduccion.Columns[i].Visibility=Visibility.Hidden;
                }

                decimal suma = 0;
                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    suma+=Convert.ToDecimal( dt.Rows[i]["TIM_STAND"].ToString() );

                    txtTimEstantar.Text=suma.ToString();
                    codCiclo.Text=dt.Rows[i]["CODIGO"].ToString();
                    txtDescripcion.Text=dt.Rows[i]["DESCRIPCION"].ToString();
                    txtDiseño.Text=dt.Rows[i]["IndiceDeModificación"].ToString();
                    txtProceso.Text=dt.Rows[i]["IndiceDeProceso"].ToString();
                    txtFecEmision.Text=dt.Rows[i]["FEC_EMI"].ToString();
                }
            }
        }
        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageIngProyecto() );
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            if (codCiclo.Text!="000000000")
            {
                WindowRepFactura p  = new WindowRepFactura();
                p.reporteCicloProceso( codCiclo.Text, txtDiseño.Text, txtProceso.Text,1 );
                p.Show();
            }
            else
            {
                mensajes( "ingrese un código para ejecutar esta acción" );
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (textBuscar.Text=="")
            {
                mensajes( "Ingrese un codigo para ejecutar esta acción" );
            }
            else
            {
                comboIndPro.Items.Clear();
                comboIndMod.Items.Clear();
                consultarCicloProcesos();
            }
            
        }

        private void btnIndices_Click(object sender, RoutedEventArgs e)
        {
            if (comboIndMod.Text==""||comboIndPro.Text=="")
            {
                mensajes( "Seleccione un codigo para ejecutar esta acción" );
            }
            else
            {
                consultarCicloProcesosIndices( textBuscar.Text, comboIndMod.SelectedItem.ToString(), comboIndPro.SelectedItem.ToString(), 1 );

            }
        }

        private void textBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                btnBuscar_Click( null, null );
            }
        }

        private void textBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBuscar.Text=="")
            {
                comboIndMod.IsEnabled=false;
                comboIndPro.IsEnabled=false;
                comboIndMod.Items.Clear();
                comboIndPro.Items.Clear();
            }
        }

        private void comboIndPro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                btnIndices_Click( null, null );
            }
        }

        private void comboIndMod_Loaded(object sender, RoutedEventArgs e)
        {
            comboIndMod.IsEnabled=false;
            comboIndPro.IsEnabled=false;
        }
    }
}
