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
            dt=NegCicloProceso.consultarCicloProcesos(textBuscar.Text,"","","",0);

            if (dt.Rows.Count == 0)
            {
                mensajes( "Código inválido intente de nuevo" );
            }
            else
            {
                GridCicloProduccionIndices.ItemsSource=dt.DefaultView;
                int max = 0; int temp=0;
                int max2 = 0; int temp2=0;
                for (int i = 0; i<dt.Rows.Count; i++)
                {

                    codCiclo.Text=dt.Rows[i]["CODIGO"].ToString();
                    //comboIndMod.Items.Add(dt.Rows[i]["IM"].ToString());
                    //comboIndPro.Items.Add(dt.Rows[i]["ind_proceso"].ToString());

                    temp=max;
                    temp2=max2;
                    if (Convert.ToInt32( dt.Rows[i]["ind_Diseño"].ToString() )>max && Convert.ToInt32( dt.Rows[i]["ind_Proceso"].ToString() )>max2)
                    {
                        max=Convert.ToInt32( dt.Rows[i]["ind_Diseño"].ToString() );
                        max2=Convert.ToInt32( dt.Rows[i]["ind_Proceso"].ToString() );
                    }

                    consultarCicloProcesosIndices(codCiclo.Text,"0"+Convert.ToString( max ), "0"+Convert.ToString( max2 ),"", 1);
                }
            }


        }

        private void consultarCicloProcesosIndices(string codigo,string indProceso,string indModificacion,string desc,int opc)
        {
            DataTable dt = new DataTable();
            dt=NegCicloProceso.consultarCicloProcesos( codigo, indProceso, indModificacion,desc, opc );

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
        private void consultarCicloProduccionDescripcion(string descripcion)
        {
            DataTable dt = new DataTable();
            dt=NegCicloProceso.consultarCicloProcesos( "", "", "", descripcion, 2 );
            if (dt.Rows.Count==0)
            {
                mensajes( "Descripción inválida intente de nuevo" );
            }
            else
            {
                GridCicloProduccionIndices.ItemsSource=dt.DefaultView;
            }
        }
        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            if (codCiclo.Text!="000000000")
            {
                WindowRepFactura p  = new WindowRepFactura();
                p.reporteCicloProceso( codCiclo.Text, txtDiseño.Text, txtProceso.Text,"",1 );
                p.Show();
            }
            else
            {
                mensajes( "ingrese un código para ejecutar esta acción" );
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (textBuscar.Text=="" && txtDescripcionIndice.Text=="")
            {
                mensajes( "Ingrese un codigo para ejecutar esta acción" );
            }
            else if (textBuscar.Text!=""&&txtDescripcionIndice.Text!="")
            {
                mensajes( "Ingrese un valor unico" );
            }
            else if(textBuscar.Text!="" && txtDescripcionIndice.Text=="")
            {
                consultarCicloProcesos();
                txtDescripcionIndice.Text=string.Empty;
                textBuscar.Text=string.Empty;
            }
            else if(textBuscar.Text==""&&txtDescripcionIndice.Text!="")
            {
                consultarCicloProduccionDescripcion( txtDescripcionIndice.Text );
                txtDescripcionIndice.Text=string.Empty;
                textBuscar.Text=string.Empty;
            }
            
        }

        private void textBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                btnBuscar_Click( null, null );
            }
        }
        private void GridCicloProduccionIndices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            consultarCicloProcesosIndices( (GridCicloProduccionIndices.CurrentItem as DataRowView ).Row.ItemArray[0].ToString(), (GridCicloProduccionIndices.CurrentItem as DataRowView).Row.ItemArray[1].ToString(), (GridCicloProduccionIndices.CurrentItem as DataRowView).Row.ItemArray[2].ToString(),"",1 );
        }

        private void txtDescripcionIndice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                btnBuscar_Click( null, null );
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageIngProyecto() );
        }
    }
}
