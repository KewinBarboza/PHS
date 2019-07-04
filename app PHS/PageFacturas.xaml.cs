using System;
using System.Data;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using CapaNegocios;


namespace app_PHS
{
    /// <summary>
    /// Lógica de interacción para PageFactura.xaml
    /// </summary>
    public partial class PageFacturas
    {
        public PageFacturas()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageVentas() );
        }

        public void consultarFactura(string codFactura)
        {
            int codFact = Convert.ToInt32( codFactura );
            System.Data.DataTable dt = new System.Data.DataTable();
            dt=NegFacturas.consultarFactura( codFact );

            if (dt.Rows.Count==0)
            {
                mensajes( "Codigo factura no existe" );
            }
            else
            {
                GridFactura.ItemsSource=dt.DefaultView;

                for (int i = 0; i<17; i++)
                {
                    GridFactura.Columns[i].Visibility=Visibility.Collapsed;
                }

                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    numFactura.Text=dr["id_factura"].ToString();
                    nomCliente.Text=dr["des_cliente"].ToString();
                    fecFactura.Text=dr["fec_factura"].ToString().Substring(0,10);
                    fecDespacho.Text=dr["fec_despacho"].ToString();
                    status.Text=dr["ESTATUS"].ToString();
                    numGUia.Text=dr["num_guia"].ToString();
                    numTransporte.Text=dr["cod_trasporte"].ToString();
                    fecRecibido.Text=dr["fec_recibido"].ToString();
                    monFlete.Text=dr["mon_flete"].ToString();
                    porFlete.Text=dr["por_flete"].ToString();
                    monto.Text=dr["monto"].ToString();
                    desc.Text=dr["tot_descuento"].ToString();
                    neto.Text=dr["mon_neto"].ToString();
                    iva.Text=dr["mon_iva"].ToString();
                    total.Text=dr["tot_pagar"].ToString();
                }
            }
        }

        public void consultarFacturaFecha()
        {
            System.Data.DataTable dt =new System.Data.DataTable();
            dt=NegFacturas.consultarFacturaFecha(fechaIni.Text,fechaFin.Text);

            if (dt.Rows.Count==0)
            {
                mensajes( "No se emitieron facturas en estas fechas" );
            }
            else
            {
                GridFacturas.ItemsSource=dt.DefaultView;
            }
        }

        public void consultarFacturaCodigoCliente(string codCliente)
        {
            int codClientes=Convert.ToInt32(codCliente);
            System.Data.DataTable dt = new System.Data.DataTable();
            dt=NegFacturas.consultarFacturaCodigoCliente(codClientes);

            if (dt.Rows.Count == 0)
            {
                mensajes( "Codigo cliente no existe" );
            }
            else
            {
                GridFacturas.ItemsSource=dt.DefaultView;
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (textBuscar.Text=="")
            {
                mensajes( "Ingrese un numero valido" );
            }
            else
            {
                consultarFactura(textBuscar.Text);
            }
        }

        private void btnBuscarFecha_Click(object sender, RoutedEventArgs e)
        {
            if (fechaFin.Text=="" || fechaIni.Text=="")
            {
                mensajes( "Ingrese un fecha valida" );
            }
            else
            {
                consultarFacturaFecha();
            }
        }

        private void btnBuscarCodCliente_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscarCodCliente.Text=="")
            {
                mensajes( "Ingrese un numero valido" );
            }
            else
            {
                consultarFacturaCodigoCliente(txtBuscarCodCliente.Text);
            }
        }

        private void textBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                btnBuscar_Click( null, null );
            }
        }
        private void txtBuscarCodCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                btnBuscarCodCliente_Click( null, null );
            }
        }

        private void GridFacturas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            consultarFactura( (GridFacturas.CurrentItem as DataRowView).Row.ItemArray[0].ToString() );
        }

        private void mensajes(string mensaje)
        {
            messege.IsActive = true;
            messege.MessageQueue.Enqueue(mensaje);
        }
        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            WindowRepFactura p  = new WindowRepFactura();
            p.reporte( Convert.ToInt32( numFactura.Text ) );
            p.Show();
        }

        private void Clientes_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
