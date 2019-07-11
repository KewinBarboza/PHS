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
    /// Lógica de interacción para PageIngProyecto.xaml
    /// </summary>
    public partial class PageProcesos : Page
    {
        public PageProcesos()
        {
            InitializeComponent();
        }

        private void mensajes(string mensaje)
        {
            messege.IsActive=true;
            messege.MessageQueue.Enqueue( mensaje );
        }

        private void consultarPartesPiezas()
        {
            DataTable dt = new DataTable();
            dt=NegProcesos.consultarPartesPiezas(textBuscar.Text);
            if (dt.Rows.Count == 0)
            {
                mensajes( "Código inválido intente de nuevo" );
            }
            else
            {
                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    codCiclo.Text=dt.Rows[i]["codigo"].ToString();

                    comboIndMod.Items.Add( dt.Rows[i]["ind_modificacion"].ToString() );
                    comboIndPro.Items.Add( dt.Rows[i]["ind_proceso"].ToString() );

                    consultarParasPiezasIndice( codCiclo.Text, dt.Rows[i]["ind_modificacion"].ToString(), dt.Rows[i]["ind_proceso"].ToString() );
                }
                comboIndMod.IsEnabled=true;
                comboIndPro.IsEnabled=true;
            }
           
        }

        private void consultarParasPiezasIndice(string codigo, string indModificacion, string indProceso)
        {
            DataTable dt = new DataTable();
            dt=NegProcesos.consultarParasPiezasIndice( codigo, indModificacion, indProceso );

            if (dt.Rows.Count==0)
            {
                mensajes( "Código inválido intente de nuevo" );
            }
            else
            {
                GridPartesPiezas.ItemsSource=dt.DefaultView;

                for (int i = 0; i<5; i++)
                {
                    GridPartesPiezas.Columns[i].Visibility=Visibility.Collapsed;
                }
                decimal suma = 0;
                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    suma += Convert.ToDecimal(dt.Rows[i]["Tiempo_St"].ToString());
                    codCiclo.Text=dt.Rows[i]["codigo"].ToString();
                    txtDescripcion.Text=dt.Rows[i]["Descripcion"].ToString();
                    txtDiseño.Text=dt.Rows[i]["ind_modificacion"].ToString();
                    txtProceso.Text=dt.Rows[i]["ind_proceso"].ToString();
                    txtFecEmision.Text=dt.Rows[i]["fec_emicion"].ToString();
                    txtTimEstantar.Text=suma.ToString();
                }
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageIngProyecto() );
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (textBuscar.Text=="")
            {
                mensajes( "Ingrese un codigo para ejecutar esta acción");
            }
            else
            {
                comboIndPro.Items.Clear();
                comboIndMod.Items.Clear();
                consultarPartesPiezas();
            }
        }

        private void btnIndices_Click(object sender, RoutedEventArgs e)
        {
            if (comboIndMod.Text=="" || comboIndPro.Text=="")
            {
                mensajes( "Seleccione un codigo para ejecutar esta acción" );
            }
            else
            {
                consultarParasPiezasIndice( textBuscar.Text, comboIndMod.SelectedItem.ToString(), comboIndPro.SelectedItem.ToString() );
            }
        }

        private void textBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBuscar.Text=="")
            {
                comboIndMod.IsEnabled=false;
                comboIndPro.IsEnabled=false;
                comboIndPro.Items.Clear();
                comboIndMod.Items.Clear();
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            comboIndMod.IsEnabled=false;
            comboIndPro.IsEnabled=false;
        }



        private void comboIndPro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                btnIndices_Click( null, null );
            }
        }

        private void textBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                btnBuscar_Click( null, null );
            }
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            if (codCiclo.Text!="000000000")
            {
                WindowRepFactura p  = new WindowRepFactura();
                p.reportePartesPiezasIndice( codCiclo.Text, txtProceso.Text, txtDiseño.Text );
                p.Show();
            }
            else
            {
              mensajes("ingrese un código para ejecutar esta acción");
            }
            
        }
    }
}
