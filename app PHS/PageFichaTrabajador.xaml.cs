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
    /// Lógica de interacción para PageFichaTrabajador.xaml
    /// </summary>
    public partial class PageFichaTrabajador : Page
    {
        public PageFichaTrabajador()
        {
            InitializeComponent();
        }
        private void mensajes(string mensaje)
        {
            messege.IsActive=true;
            messege.MessageQueue.Enqueue( mensaje );
        }
        private void consultarFichaTrabajadorCodigo(string codigo)
        {
            DataTable dt = new DataTable();
            dt=NegFichaTrabajador.consultarFichaTrabajador(codigo,1);
            if (dt.Rows.Count==0)
            {
                mensajes( "Código incorrecto" );
            }
            else
            {
                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    nomTrabajador.Text=quitarEspacios(dr["nombre"].ToString())+' '+quitarEspacios(dr["apellido"].ToString())+'/'+dr["clase"].ToString();
                    codTrabajador.Text=dr["codigo"].ToString();
                    txtCedula.Text=dr["cedula"].ToString();
                    txtNacimiento.Text=dr["fecNacimiento"].ToString()+'/'+dr["paisNacionalidad"].ToString().TrimEnd()+'/'+dr["cidNacimiento"].ToString().TrimEnd();
                    txtSexo.Text=dr["sexo"].ToString();
                    txtEstCivil.Text=dr["edoCivil"].ToString();

                    txtTelefono.Text=dr["telefono"].ToString();
                    txtCorreo.Text=dr["correo"].ToString();
                    txtDireccion.Text=dr["direccion"].ToString();

                    txtSueldo.Text=dr["sueldo"].ToString().Trim();
                    txtBonos.Text="Social:"+dr["bonoSocial"].ToString().Trim()+" Prod:"+dr["bonoProduccion"].ToString().Trim()+" Salarial: "+dr["bonoSalarial"].ToString();
                    txtCesTick.Text=dr["cestTick"].ToString().Trim();
                    txtFormPago.Text=dr["forPago"].ToString();
                    txtFrePago.Text=dr["fecPago"].ToString();
                    txtBanCuenta.Text=dr["banco"].ToString().Trim()+"/ Cuenta: "+dr["tipCuenta"].ToString();
                    txtNmrCuenta.Text=dr["cuentaBancaria"].ToString().Trim();

                    //txtDotacion.Text=dr[""].ToString().Trim();
                    txtFecIngreso.Text=dr["fecIngreso"].ToString().Trim();
                    txtFecRetiro.Text=dr["fecRetiro"].ToString().Trim();
                    txtHijos.Text=dr["hijos"].ToString().Trim();
                    txtConyugue.Text=dr["conyugue"].ToString().Trim();
                    txtMontepio.Text=dr["montepio"].ToString().Trim();
                    txtGraInstruccion.Text=dr["graInstruccion"].ToString().Trim();
                    txtDiscapacidad.Text=dr["discapacidad"].ToString().Trim();
                    //txtSSO.Text=dr[""].ToString().Trim();
                    txtNmrSSO.Text=dr["nroSSO"].ToString().Trim();
                    txtSindicato.Text=dr["sindicado"].ToString().Trim();
                    txtISLR.Text=dr["ISLR"].ToString().Trim();
                    txtTurno.Text=dr["turno"].ToString();
                    txtTalla.Text="Camisa:"+dr["tallCamisa"].ToString().Trim()+" Pantalon:"+dr["tallPantalon"].ToString().Trim()+" Zapatos:"+dr["tallZapatos"].ToString().Trim()+" Bata:"+dr["tallBata"].ToString().Trim();
                }
            }
        }

        private void consultarFichaTrabajadorNombreCedula()
        {
            DataTable dt = new DataTable();
            dt=NegFichaTrabajador.consultarFichaTrabajador( txtBuscar.Text, 2 );

            if (dt.Rows.Count==0)
            {
                mensajes( "Nombre o cedula incorrecto" );
            }
            else
            {
                GridTrabajador.ItemsSource=dt.DefaultView;
            }
        }
        private void GridTrabajador_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            consultarFichaTrabajadorCodigo( (GridTrabajador.CurrentItem as DataRowView).Row.ItemArray[0].ToString());
        }
        static string quitarEspacios(string nombre)
        {
            while (nombre.Contains( "  " ))
            {
                nombre=nombre.Replace( "  ", " " );
            }
            return nombre;
        }
        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageRecursoHumano());
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            if (codTrabajador.Text=="0000")
            {
                mensajes( "Realice una consulta para ejecutar esta acción" );
            }
            else
            {
                WindowRepFactura p  = new WindowRepFactura();
                p.ReportFichaTrabajador( codTrabajador.Text, 1 );
                p.Show();
            }
            
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text != "" && txtCodigo.Text =="")
            {
                consultarFichaTrabajadorNombreCedula();
                txtBuscar.Text=string.Empty;
            }
            else if (txtCodigo.Text != "" && txtBuscar.Text =="")
            {
                consultarFichaTrabajadorCodigo( txtCodigo.Text );
                txtCodigo.Text=string.Empty;
            }
            else if (txtBuscar.Text !="" && txtCodigo.Text!="")
            {
                mensajes( "Ingrese un único valor" );
            }
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

       
    }
}
