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
    /// Lógica de interacción para PageClientes.xaml
    /// </summary>
    public partial class PageClientes : Page
    {
        public PageClientes()
        {
            InitializeComponent();
        }
        private void mensajes(string mensaje)
        {
            messege.IsActive=true;
            messege.MessageQueue.Enqueue( mensaje );
        }
        public void consultarClienteRif(string numRif)
        {
            DataTable dt = new DataTable();
            dt=NegClientes.consultarClienteRif( numRif);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    nomCliente.Text=dr["nomCliente"].ToString();
                    codCliente.Text=dr["codCliente"].ToString();
                    rif.Text=dr["numRif"].ToString();
                    fax.Text=dr["numFax"].ToString();
                    codAnterior.Text=dr["codAnterior"].ToString();

                    celCliente.Text=dr["celular"].ToString()+","+dr["telefono1"].ToString()+","+dr["telefono2"].ToString()+","+dr["telefono3"].ToString();
                    corCliente.Text=dr["email"].ToString();
                    webCliente.Text=dr["web"].ToString();
                    conCliente.Text=dr["contacto"].ToString()+"-"+dr["cargo"];

                    ciudad.Text=dr["ciudad"].ToString();
                    dirCliente.Text=dr["dirección"].ToString();
                    zonaMin.Text=dr["minZona"].ToString();
                    codPostal.Text=dr["codPostal"].ToString();
                    locCliente.Text=dr["dirLocal"].ToString();

                    agteRet.Text=dr["agteRet"].ToString();
                    cliEspcial.Text=dr["clientEsp"].ToString();
                    lote.Text=dr["lote"].ToString();
                    dctoPp.Text=dr["dctpPp"].ToString();
                    fecAtcv.Text=dr["fechaAct"].ToString();
                    saldo.Text=dr["saldo"].ToString();
                    clientAso.Text=dr["clientAso"].ToString();
                    tipClient.Text=dr["tipCliente"].ToString();
                    condPago.Text=dr["condPago"].ToString();
                    diasGrac.Text=dr["diasGrac"].ToString();
                    limCred.Text=dr["limCred"].ToString();
                    estatus.Text=dr["estatus"].ToString();
                    tipo.Text=dr["tipo"].ToString();
                    totCred.Text=dr["totCred"].ToString();
                }
            }else
            {
                mensajes( "Numero de Rif no existe" );
            }
            
        }

        private void consultarClientesNombre(string nomCliente)
        {
            DataTable dt = new DataTable();
            dt=NegClientes.consultarClientesNombre( nomCliente );

            if (dt.Rows.Count != 0)
            {
                dataGridCliente.ItemsSource=dt.DefaultView;
            }
            else
            {
                mensajes("Nombre de cliente no existe");
            }

        }

        private void cunsultarClientesActivos(int status)
        {
            DataTable dt = new DataTable();
            dt=NegClientes.cunsultarClientesActivos(status);

            if (dt.Rows.Count!=0)
            {
                dataGridCliente.ItemsSource=dt.DefaultView;
            }
            else
            {
                mensajes( "Status no valido" );
            }
            
        }

        private void txtRifCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                btnNomCliente_Click( null, null );
            }
        }


        private void btnNomCliente_Click(object sender, RoutedEventArgs e)
        {
            if (txtnomCliente.Text =="" && txtRifCliente.Text =="" && status.SelectedItem ==null)
            {
                mensajes( "Inserte un dato valido" );
            }
            else if (txtnomCliente.Text != "" && txtRifCliente.Text != "" || txtnomCliente.Text!=""&&status.SelectedItem!=null ||txtRifCliente.Text!=""&&status.SelectedItem!=null)
            {
                mensajes( "Ingrese un único valor" );
                txtRifCliente.Text=string.Empty;
                txtnomCliente.Text=string.Empty;
                status.SelectedItem=null;
            }
            else
            {
                if (txtRifCliente.Text==""&&status.SelectedItem==null)
                {
                    if (txtnomCliente.Text =="")
                    {
                        mensajes( "Inserte un nombre valido" );
                    }
                    else
                    {
                        consultarClientesNombre( txtnomCliente.Text );
                        txtnomCliente.Text=string.Empty;
                    }
                }
                else if (txtnomCliente.Text =="" &&status.SelectedItem==null)
                {
                    if (txtRifCliente.Text!="")
                    {
                        consultarClienteRif( txtRifCliente.Text );
                        txtRifCliente.Text=string.Empty;
                    }
                    else
                    {
                        mensajes( "Inserte un valor valido" );
                    }
                }
                else if (txtnomCliente.Text =="" && txtRifCliente.Text=="")
                {
                    cunsultarClientesActivos( Convert.ToInt32( status.SelectedIndex.ToString() ) );
                    status.SelectedItem=null;
                }

            }
           
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            if (rif.Text!="0000")
            {
                WindowRepFactura p  = new WindowRepFactura();
                p.reporteClientes( rif.Text );
                p.Show();
            }
            else
            {
                mensajes( "Seleccione un cliente para poder crear el reporte" );
            }
            
        }
        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageVentas() );
        }

        private void dataGridCliente_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            consultarClienteRif( (dataGridCliente.CurrentItem as DataRowView).Row.ItemArray[0].ToString() );
        }

        private void btnImprimirGrid_Click(object sender, RoutedEventArgs e)
        {
            int numStatus =  Convert.ToInt32( status.SelectedIndex.ToString() );

            if (numStatus == 0 || numStatus == 1)
            {
                WindowRepFactura p  = new WindowRepFactura();
                p.reporteClientesStatus( numStatus );
                p.Show();
            }
            else
            {
                mensajes( "Consulte el status para crear el reporte" );
            }
        }

        private void status_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                btnNomCliente_Click( null, null );
            }
        }
        private void txtnomCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                btnNomCliente_Click( null, null );
            }
        }
    }
}
