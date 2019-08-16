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
                dataGridProceso.ItemsSource=dt.DefaultView;

                for (int i = 0; i<3; i++)
                {
                    dataGridProceso.Columns[i].Visibility=Visibility.Collapsed;
                }

                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    codCiclo.Text=dt.Rows[i]["codigo"].ToString();
                    consultarParasPiezasIndice( codCiclo.Text, dt.Rows[i]["ind_Diseño"].ToString(), dt.Rows[i]["ind_Proceso"].ToString() );
                }
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
                    txtDiseño.Text=dt.Rows[i]["ind_Diseño"].ToString();
                    txtProceso.Text=dt.Rows[i]["ind_Proceso"].ToString();
                    txtFecEmision.Text=dt.Rows[i]["fec_emicion"].ToString();
                    txtTimEstantar.Text=suma.ToString();
                }
            }
        }

        private void consultarPartesPiezasDescripcion()
        {
            DataTable dt = new DataTable();
            dt=NegProcesos.consultarPartesPiezasDescripcion( txtDescrpcionCiclo.Text );

            if (dt.Rows.Count == 0)
            {
                mensajes( "Descripción inválida intente de nuevo" );
            }
            else
            {
                dataGridProceso.ItemsSource=dt.DefaultView;
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageIngProyecto() );
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (textBuscar.Text=="" && txtDescrpcionCiclo.Text =="")
            {
                mensajes( "Ingrese un codigo para ejecutar esta acción");
            }
            else
            {
                if (textBuscar.Text =="" && txtDescrpcionCiclo.Text !="")
                {
                    //dataGridProceso.Items.Clear();
                    consultarPartesPiezasDescripcion();
                    txtDescrpcionCiclo.Text=string.Empty;
                }
                else if (textBuscar.Text!=""&&txtDescrpcionCiclo.Text=="")
                {
                    //dataGridProceso.Items.Clear();
                    consultarPartesPiezas();
                    textBuscar.Text=string.Empty;
                }
                else if(textBuscar.Text!=""&&txtDescrpcionCiclo.Text!="")
                {
                    mensajes( "Ingrese un unico valor" );
                }
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

        private void dataGridProceso_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
          consultarParasPiezasIndice( (dataGridProceso.CurrentItem as DataRowView).Row.ItemArray[0].ToString(), (dataGridProceso.CurrentItem as DataRowView).Row.ItemArray[3].ToString(), (dataGridProceso.CurrentItem as DataRowView).Row.ItemArray[4].ToString() );
        }

        private void txtDescrpcionCiclo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                btnBuscar_Click( null, null );
            }
        }
    }
}
