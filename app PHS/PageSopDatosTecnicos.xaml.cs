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
using CapaNegocios;
using System.Data;

namespace app_PHS
{
    /// <summary>
    /// Lógica de interacción para PageSopDatosTecnicos.xaml
    /// </summary>
    public partial class PageSopDatosTecnicos : Page
    {
        public PageSopDatosTecnicos()
        {
            InitializeComponent();
        }
        private void mensajes(string mensaje)
        {
            messege.IsActive=true;
            messege.MessageQueue.Enqueue( mensaje );
        }
        private void consultarSopDatosTecnicos()
        {
            DataTable dt = new DataTable();
            dt=NegSopDatosTecnicos.consultarSopDatosTecnicos(textBuscar.Text,"","","",0);

            if (dt.Rows.Count==0)
            {
                mensajes( "Código inválido intente de nuevo" );
            }
            else
            {
                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    GridDatosTecnicos.ItemsSource=dt.DefaultView;
                }
                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    consultarSopDatosTecnicosOp( textBuscar.Text, dt.Rows[i]["IM"].ToString(), dt.Rows[i]["ind_proceso"].ToString(), dt.Rows[i]["OP"].ToString(), 1 );
                }
            }
            
        }

        private void consultarSopDatosTecnicosOp(string codigo,string indModificacion,string indProceso,string operacion,int opc)
        {
            DataTable dt = new DataTable();
            dt=NegSopDatosTecnicos.consultarSopDatosTecnicos( codigo, indModificacion, indProceso, operacion, opc );
            if (dt.Rows.Count==0)
            {
                mensajes( "Código inválido intente de nuevo" );
            }
            else
            {
                GridSopDatosTecnicos.ItemsSource=dt.DefaultView;
                for (int i = 0; i<7; i++)
                {
                    GridSopDatosTecnicos.Columns[i].Visibility=Visibility.Hidden;
                }
                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    codMaterial.Text=dt.Rows[i]["MATERIAL"].ToString();
                    txtDescripcion.Text=dt.Rows[i]["DESCRIPCION"].ToString();
                    txtDiseño.Text=dt.Rows[i]["IM"].ToString();
                    txtProceso.Text=dt.Rows[i]["IP"].ToString();
                    txtOperación.Text=dt.Rows[i]["OP"].ToString();
                }
            }
           
        }

        private void consultarDatosTecnicosDesc()
        {
            DataTable dt = new DataTable();
            dt=NegSopDatosTecnicos.consultarSopDatosTecnicos( textDescripcionDatosTecnicos.Text, "", "", "", 2 );


            for (int i = 0; i<dt.Rows.Count; i++)
            {
                GridDatosTecnicos.ItemsSource=dt.DefaultView;
            }
        }


        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (textBuscar.Text=="" && textDescripcionDatosTecnicos.Text=="")
            {
                mensajes( "Ingrese un codigo para ejecutar esta acción" );
            }
            else if(textDescripcionDatosTecnicos.Text !="" && textBuscar.Text !="")
            {
                mensajes( "Ingrese un valor unico" );
            }
            else if(textBuscar.Text != "" && textDescripcionDatosTecnicos.Text=="")
            {
                consultarSopDatosTecnicos();
                textBuscar.Text=string.Empty;
                textDescripcionDatosTecnicos.Text=string.Empty;

            }else if (textBuscar.Text =="" && textDescripcionDatosTecnicos.Text != "")
            {
                consultarDatosTecnicosDesc();
                textBuscar.Text=string.Empty;
                textDescripcionDatosTecnicos.Text=string.Empty;
            }

        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            if (codMaterial.Text!="000000000")
            {
                WindowRepFactura p  = new WindowRepFactura();
                p.reporteSopDatosTecnicos( codMaterial.Text, txtDiseño.Text, txtProceso.Text,txtOperación.Text,1 );
                p.Show();
            }
            else
            {
                mensajes( "ingrese un código para ejecutar esta acción" );
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageIngProyecto() );
        }

        private void textBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                btnBuscar_Click( null, null );
            }
        }

        private void GridDatosTecnicos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            consultarSopDatosTecnicosOp( (GridDatosTecnicos.CurrentItem as DataRowView).Row.ItemArray[0].ToString(), (GridDatosTecnicos.CurrentItem as DataRowView).Row.ItemArray[2].ToString(), (GridDatosTecnicos.CurrentItem as DataRowView).Row.ItemArray[3].ToString(), (GridDatosTecnicos.CurrentItem as DataRowView).Row.ItemArray[4].ToString(), 1 );
        }
    }
}
