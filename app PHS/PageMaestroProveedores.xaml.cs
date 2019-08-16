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
using System.Data.SqlClient;
using CapaNegocios;
namespace app_PHS
{
    /// <summary>
    /// Lógica de interacción para PageMaestroProveedores.xaml
    /// </summary>
    public partial class PageMaestroProveedores : Page
    {
        public PageMaestroProveedores()
        {
            InitializeComponent();
        }
        private void mensajes(string mensaje)
        {
            messege.IsActive=true;
            messege.MessageQueue.Enqueue( mensaje );
        }

        private void consultarMaestroProveedores(string buscar, int opc)
        {
            DataTable dt = new DataTable();
            dt=NegMaestroProveedores.consultarMaestroProveedores( buscar, opc );
            for (int i = 0; i<dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                txtNomProveedor.Text=dr["nombre"].ToString();
                txtCodProveedor.Text=dr["codigo"].ToString();
                txtNomBreve.Text=dr["siglas"].ToString();
                txtRif.Text=dr["rif"].ToString();
                txtTipo.Text=dr["tipo"].ToString();
                txtFax.Text=dr["nroFax"].ToString();

                txtTelefonos.Text=dr["telefono1"].ToString().Trim()+'/'+dr["telefono2"].ToString().Trim()+'/'+dr["telefono3"].ToString().Trim();
                txtCorreo.Text=dr["correo"].ToString();
                //txtWeb.Text=dr[""].ToString();
                txtNomContacto.Text=dr["contacto1"].ToString()+'/'+dr["contacto2"].ToString().Trim();

                //txtCiudad.Text=dr[""].ToString();
                //txtCodPostal.Text=dr[""].ToString();
                //txtPais.Text=dr[""].ToString();
                txtDireccion.Text=dr["direccion"].ToString();

                txtReferido.Text=dr["labor3"].ToString().Trim();
                //txtUltActualizacion.Text=dr[""].ToString();
                txtLabor.Text=dr["labor1"].ToString().Trim()+'/'+dr["labor2"].ToString().Trim();

            }
        }

        private void consultarMaestroProveedoresDescripcion(string buscar, int opc)
        {
            DataTable dt = new DataTable();
            dt=NegMaestroProveedores.consultarMaestroProveedores( buscar, opc );
            GridProveedor.ItemsSource=dt.DefaultView;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                Mouse.OverrideCursor=Cursors.Wait;
                btnBuscar_Click( null, null );
                Mouse.OverrideCursor=Cursors.Arrow;
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Return)
            {
                Mouse.OverrideCursor=Cursors.Wait;
                btnBuscar_Click( null, null );
                Mouse.OverrideCursor=Cursors.Arrow;
            }
        }

        private void GridProveedor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            consultarMaestroProveedores( (GridProveedor.CurrentItem as DataRowView).Row.ItemArray[0].ToString(), 1 ); 
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new PageCompras() );
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text != "" && txtCodigo.Text=="")
            {
                consultarMaestroProveedoresDescripcion( txtBuscar.Text, 2 );
                txtBuscar.Text=string.Empty;
            }
            else if(txtBuscar.Text==""&&txtCodigo.Text!="")
            {
                consultarMaestroProveedores( txtCodigo.Text, 1 );
                txtCodigo.Text=string.Empty;
            }
            else if (txtBuscar.Text==""&&txtCodigo.Text=="")
            {
                mensajes( "Ingrese un valor para ejecutar esta acción" );
            }
            else if (txtBuscar.Text!=""&&txtCodigo.Text!="")
            {
                mensajes( "Ingrese un valor único" );
            }
            
            
        }
    }
}
