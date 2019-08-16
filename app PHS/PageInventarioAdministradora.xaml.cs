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
    /// Lógica de interacción para PageInventarioAdministradora.xaml
    /// </summary>
    public partial class PageInventarioAdministradora : Page
    {
        public PageInventarioAdministradora()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            consultarMovimientos();
            comboTipMovimiento.IsEnabled=false;
            txtMaterialBuscar.IsEnabled=false;
            fechaIni.IsEnabled=false;
            fechaFin.IsEnabled=false;
        }
        private void mensajes(string mensaje)
        {
            messege.IsActive=true;
            messege.MessageQueue.Enqueue( mensaje );
        }
        private void consultarMovimientos()
        {
            DataTable dt = new DataTable();
            dt=NegInventarioInversora.consultarMovimientos();

            for (int i = 0; i<dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                comboTipMovimiento.Items.Add( dr["Codigo mov#"].ToString()+' '+dr["Descripcion"].ToString() );
            }
        }
        private void consultarInventarioInversoraTipoMovi(string movimiento, string material, string fechaDesde, string fechaHasta, int opc)
        {

            DataTable dt = new DataTable();
            dt=NegInventarioAdministradora.consultarInventarioAdministradora( movimiento, material, fechaDesde, fechaHasta, opc );

            if (dt.Rows.Count!=0)
            {
                GridInventarioAdministradora.ItemsSource=dt.DefaultView;

                if (tipMovimiento.IsChecked==true)
                {
                    GridInventarioAdministradora.Columns[5].Visibility=Visibility.Collapsed;

                    for (int i = 0; i<dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        txtMovimiento.Text=dr["Movimiento"].ToString();

                    }
                    txtFecDesde.Text=fechaIni.ToString();
                    txtFecHasta.Text=fechaFin.Text;
                }
                else if (codMaterial.IsChecked==true)
                {
                    GridInventarioAdministradora.Columns[0].Visibility=Visibility.Collapsed;
                    GridInventarioAdministradora.Columns[2].Visibility=Visibility.Collapsed;

                    for (int i = 0; i<dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        txtDescripción.Text=dr["descripcion"].ToString();
                        txtMaterialD.Text=dr["Material"].ToString();
                    }
                    txtFecDesde.Text=fechaIni.ToString();
                    txtFecHasta.Text=fechaFin.Text;
                }
                else if (matMovimiento.IsChecked==true)
                {
                    GridInventarioAdministradora.Columns[11].Visibility=Visibility.Collapsed;
                    GridInventarioAdministradora.Columns[0].Visibility=Visibility.Collapsed;
                    GridInventarioAdministradora.Columns[1].Visibility=Visibility.Collapsed;

                    for (int i = 0; i<dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        txtDescripción.Text=dr["descripcion"].ToString();
                        txtMaterialD.Text=dr["Material"].ToString();
                        txtMovimiento.Text=dr["Movimiento"].ToString();

                    }
                    txtFecDesde.Text=fechaIni.ToString();
                    txtFecHasta.Text=fechaFin.Text;
                }
            }
            else
            {
                mensajes( "Verifique los datos e intente de nuevo" );
            }
        }

        private void consultarDescripcionInventario()
        {
            DataTable dt = new DataTable();
            dt=NegInventarioInversora.consultarDescripcionInventario( txtDescripcion.Text, 2 );

            if (dt.Rows.Count!=0)
            {
                GridAdministradora.ItemsSource=dt.DefaultView;
            }
            else
            {
                mensajes( "Código o Descripción no valida" );
            }
        }

        private void codMaterial_Click(object sender, RoutedEventArgs e)
        {
            comboTipMovimiento.IsEnabled=false;
            txtMaterialBuscar.IsEnabled=true;
            fechaIni.IsEnabled=true;
            fechaFin.IsEnabled=true;
        }

        private void matMovimiento_Click(object sender, RoutedEventArgs e)
        {
            txtMaterialBuscar.IsEnabled=true;
            comboTipMovimiento.IsEnabled=true;
            fechaIni.IsEnabled=true;
            fechaFin.IsEnabled=true;
        }
        private void tipMovimiento_Click(object sender, RoutedEventArgs e)
        {
            txtMaterialBuscar.IsEnabled=false;
            comboTipMovimiento.IsEnabled=true;
            fechaIni.IsEnabled=true;
            fechaFin.IsEnabled=true;
        }
        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                Mouse.OverrideCursor=Cursors.Wait;
                btnBuscar_Click( null, null );
                Mouse.OverrideCursor=Cursors.Arrow;
            }
        }

        private void GridAdministradora_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtMaterialBuscar.Text=(GridAdministradora.CurrentItem as DataRowView).Row.ItemArray[0].ToString();
            comboTipMovimiento.SelectedItem=(GridAdministradora.CurrentItem as DataRowView).Row.ItemArray[2].ToString();

            tipMovimiento.IsChecked=true;
            tipMovimiento_Click( null, null );
            consultarInventarioInversoraTipoMovi( comboTipMovimiento.SelectedValue.ToString().Substring( 0, 2 ), "", "2013/01/01", "2018/12/31", 1 );

            txtFecDesde.Text="2013/01/01";
            txtFecHasta.Text="2018/12/31";
        }

        private void limpiarDatos()
        {
            txtMovimiento.Text="xxxxxxxxxx";
            txtDescripción.Text="xxxxxxxxx";
            txtMaterialD.Text="00000000000";
            txtFecDesde.Text="00/00/0000";
            txtFecHasta.Text="00/00/0000";
        }
        private void limpiarDatosConsulta()
        {
            comboTipMovimiento.Items.Clear();
            txtMaterialBuscar.Text=string.Empty;
            fechaIni.Text="";
            fechaFin.Text="";
            txtDescripcion.Text=string.Empty;
            tipMovimiento.IsChecked=false;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor=Cursors.Wait;
            if (txtDescripcion.Text!="")
            {
                consultarDescripcionInventario();
                limpiarDatosConsulta();
                tipMovimiento.IsChecked=false;
                codMaterial.IsChecked=false;
                matMovimiento.IsChecked=false;
                Page_Loaded( null, null );
            }
            else
            {
                if (tipMovimiento.IsChecked==true)
                {
                    if (comboTipMovimiento.SelectedItem==null||fechaIni.Text==""||fechaFin.Text=="")
                    {
                        mensajes( "Ingrese todos los campos para realizar esta acción" );
                    }
                    else
                    {
                        limpiarDatos();
                        var fecha1 = Convert.ToDateTime(fechaIni.Text).ToString("yyyy/MM/dd").Replace("/","");
                        var fecha2 = Convert.ToDateTime(fechaFin.Text).ToString("yyyy/MM/dd").Replace("/","");
                        
                        consultarInventarioInversoraTipoMovi( comboTipMovimiento.SelectedValue.ToString().Substring( 0, 2 ), "", fecha1, fecha2, 1 );
                    }
                }
                else if (codMaterial.IsChecked==true)
                {
                    if (txtMaterialBuscar.Text==""||fechaIni.Text==""||fechaFin.Text=="")
                    {
                        mensajes( "Ingrese todos los campos para realizar esta acción" );
                    }
                    else
                    {
                        limpiarDatos();
                        var fecha1 = Convert.ToDateTime(fechaIni.Text).ToString("yyyy/MM/dd").Replace("/","");
                        var fecha2 = Convert.ToDateTime(fechaFin.Text).ToString("yyyy/MM/dd").Replace("/","");
                        consultarInventarioInversoraTipoMovi( "", txtMaterialBuscar.Text, fecha1, fecha2, 2 );
                    }
                }
                else if (matMovimiento.IsChecked==true)
                {
                    if (comboTipMovimiento.SelectedItem==null||txtMaterialBuscar.Text==""||fechaIni.Text==""||fechaFin.Text=="")
                    {
                        mensajes( "Ingrese todos los campos para realizar esta acción" );
                    }
                    else
                    {
                        limpiarDatos();
                        var fecha1 = Convert.ToDateTime(fechaIni.Text).ToString("yyyy/MM/dd").Replace("/","");
                        var fecha2 = Convert.ToDateTime(fechaFin.Text).ToString("yyyy/MM/dd").Replace("/","");
                        consultarInventarioInversoraTipoMovi( comboTipMovimiento.SelectedValue.ToString().Substring( 0, 2 ), txtMaterialBuscar.Text, fecha1, fecha2, 3 );
                    }

                }
            }
            Mouse.OverrideCursor=Cursors.Arrow;
        }
        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            WindowRepFactura p  = new WindowRepFactura();

            if (tipMovimiento.IsChecked==true)
            {
                if (txtMovimiento.Text==""||txtFecDesde.Text==""||txtFecHasta.Text=="")
                {
                    mensajes( "Realice una consulta para ejecutar esta acción" );
                }
                else
                {
                    var fecha1 = Convert.ToDateTime(txtFecDesde.Text).ToString("yyyy/MM/dd").Replace("/","");
                    var fecha2 = Convert.ToDateTime(txtFecHasta.Text).ToString("yyyy/MM/dd").Replace("/","");
                    p.reporteInventarioAdministradoraMovimiento( comboTipMovimiento.SelectedItem.ToString().Substring( 0, 2 ), "", fecha1, fecha2, 1 );
                    p.Show();
                }
            }
            else if (codMaterial.IsChecked==true)
            {
                if (txtMaterialD.Text==""||txtFecDesde.Text==""||txtFecHasta.Text=="")
                {
                    mensajes( "Realice una consulta para ejecutar esta acción" );
                }
                else
                {
                    var fecha1 = Convert.ToDateTime(txtFecDesde.Text).ToString("yyyy/MM/dd").Replace("/","");
                    var fecha2 = Convert.ToDateTime(txtFecHasta.Text).ToString("yyyy/MM/dd").Replace("/","");
                    p.reporteInventarioAdministradoraMovimiento( "", txtMaterialBuscar.Text, fecha1, fecha2, 2 );
                    p.Show();
                }
            }
            else if (matMovimiento.IsChecked==true)
            {
                if (txtMovimiento.Text==""||txtMaterialD.Text==""||txtFecDesde.Text==""||txtFecHasta.Text=="")
                {
                    mensajes( "Realice una consulta para ejecutar esta acción" );
                }
                else
                {
                    var fecha1 = Convert.ToDateTime(txtFecDesde.Text).ToString("yyyy/MM/dd").Replace("/","");
                    var fecha2 = Convert.ToDateTime(txtFecHasta.Text).ToString("yyyy/MM/dd").Replace("/","");
                    p.reporteInventarioAdministradoraMovimiento( comboTipMovimiento.SelectedItem.ToString().Substring( 0, 2 ), txtMaterialBuscar.Text, fecha1, fecha2, 3 );
                    p.Show();
                }

            }
        }
        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageInventario() );
        }

        
    }
}
