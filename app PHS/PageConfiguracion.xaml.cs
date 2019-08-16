using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using CapaNegocios;
using System;
using System.Data;

namespace app_PHS
{
    /// <summary>
    /// Lógica de interacción para PageConfiguracion.xaml
    /// </summary>
    public partial class PageConfiguracion : Page
    {
        public PageConfiguracion()
        {
            InitializeComponent();
        }
        private void mensajes(string mensaje)
        {
            messege.IsActive=true;
            messege.MessageQueue.Enqueue( mensaje );
        }

        private void registrarUsuarios()
        {
            //encriptamos la cadena inicial       

            //ahora desencriptamos
            
            if (idUs.Text != "0" && idRo.Text != "0")
            {
                NegLogin.registrarUsuarios(Convert.ToInt32(idUs.Text), Convert.ToInt32( idRo.Text ),cedula.Text, nomUsuario.Text, clsSeguridad.Encriptar( contraseña.Password ), cedula.Text, Convert.ToBoolean( ventas.IsChecked ) , Convert.ToBoolean( RRHH.IsChecked ) , Convert.ToBoolean( finanzas.IsChecked ) , Convert.ToBoolean( contabilidad.IsChecked ) , Convert.ToBoolean( inventario.IsChecked ), Convert.ToBoolean( compras.IsChecked ), Convert.ToBoolean( despacho.IsChecked ), Convert.ToBoolean( ing_proyecto.IsChecked ), Convert.ToBoolean(configuracion.IsChecked) );
                mensajes("Usuario actualizado con exito");
            }
            else
            {
                NegLogin.registrarUsuarios( Convert.ToInt32( idUs.Text ), Convert.ToInt32( idRo.Text ), cedula.Text, nomUsuario.Text, clsSeguridad.Encriptar( contraseña.Password ), cedula.Text, Convert.ToBoolean( ventas.IsChecked ), Convert.ToBoolean( RRHH.IsChecked ), Convert.ToBoolean( finanzas.IsChecked ), Convert.ToBoolean( contabilidad.IsChecked ), Convert.ToBoolean( inventario.IsChecked ), Convert.ToBoolean( compras.IsChecked ), Convert.ToBoolean( despacho.IsChecked ), Convert.ToBoolean( ing_proyecto.IsChecked ), Convert.ToBoolean( configuracion.IsChecked ) );
                mensajes( "Usuario registrado con exito" );
            }
        }

        private void consultarUsuarios()
        {
            DataTable dt = new DataTable();
            dt = NegLogin.consultarUsuarios(0,"");

            for (int i = 0; i<dt.Rows.Count; i++)
            {
                listUsuarios.Items.Add(dt.Rows[i]["idRol"].ToString() );
            }

        }
        private void limpiarCampos()
        {
            nomUsuario.Text=string.Empty;
            cedula.Text=string.Empty;
            contraseña.Password=string.Empty;
            ventas.IsChecked=false;
            RRHH.IsChecked=false;
            finanzas.IsChecked=false;
            contabilidad.IsChecked=false;
            inventario.IsChecked=false;
            compras.IsChecked=false;
            despacho.IsChecked=false;
            ing_proyecto.IsChecked=false;
            configuracion.IsChecked=false;
            idRo.Text="0";
            idUs.Text="0";

        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new Home() );
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cedula.Text =="" || nomUsuario.Text=="" || contraseña.Password =="")
            {
                mensajes("Todos los campos son requeridos");
            }
            else
            {
                registrarUsuarios();
                limpiarCampos();
                listUsuarios.Items.Clear();
                btnEstado(false);
                txtEstado(true);
                consultarUsuarios();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            consultarUsuarios();
        }

        private void listUsuarios_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataTable dt = new DataTable();
            dt=NegLogin.consultarUsuarios(1, listUsuarios.SelectedItem.ToString());

            for (int i = 0; i<dt.Rows.Count; i++)
            {
                nomUsuario.Text = dt.Rows[i]["nom_usuario"].ToString();
                contraseña.Password=clsSeguridad.DesEncriptar( dt.Rows[i]["clave"].ToString() );
                cedula.Text=dt.Rows[i]["idRol"].ToString();
                idRo.Text=dt.Rows[i]["idRo"].ToString();
                idUs.Text=dt.Rows[i]["idUs"].ToString();
                ventas.IsChecked=Convert.ToBoolean( dt.Rows[i]["factura"].ToString() );
                RRHH.IsChecked=Convert.ToBoolean( dt.Rows[i]["RRHH"].ToString() );
                finanzas.IsChecked=Convert.ToBoolean( dt.Rows[i]["finanza"].ToString() );
                contabilidad.IsChecked=Convert.ToBoolean( dt.Rows[i]["contabilidad"].ToString() );
                inventario.IsChecked=Convert.ToBoolean( dt.Rows[i]["inventario"].ToString() );
                compras.IsChecked=Convert.ToBoolean( dt.Rows[i]["compras"].ToString() );
                despacho.IsChecked=Convert.ToBoolean( dt.Rows[i]["despacho"].ToString() );
                ing_proyecto.IsChecked=Convert.ToBoolean( dt.Rows[i]["ing_contabilidad"].ToString() );
                configuracion.IsChecked=Convert.ToBoolean( dt.Rows[i]["configuracion"].ToString() );

                btnEstado( true );
                txtEstado( false );

                if (idRo.Text =="1")
                {
                    btnEliminar.Visibility=Visibility.Hidden;
                }

            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (idUs.Text=="0" && idRo.Text =="0")
            {
                mensajes("seleccione un usuario para poder ejecutar esta acción ");
            }
            else
            {
                NegLogin.eliminarUsuarios( cedula.Text );
                limpiarCampos();
                listUsuarios.Items.Clear();
                btnEstado(false);
                txtEstado(true);
                consultarUsuarios();

                mensajes( "Usuario eliminado con exito" );
            }

        }

        private void cedula_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci>=48&&ascci<=57)
                e.Handled=false;
            else
                e.Handled=true;
        }

        private void nomUsuario_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci>=65&&ascci<=90||ascci>=97&&ascci<=122)
                e.Handled=false;
            else
                e.Handled=true;
        }
        private void btnEstado(bool estado)
        {
            if (estado)
            {
                btnEliminar.Visibility=Visibility;
                btnEditar.Visibility=Visibility;
                btnRegistrar.Visibility=Visibility;
            }
            else
            {
                btnEliminar.Visibility=Visibility.Hidden;
                btnEditar.Visibility=Visibility.Hidden;
                btnRegistrar.Visibility=Visibility.Hidden;
            }
        }
        private void txtEstado(bool estado)
        {
            if (estado)
            {
                nomUsuario.IsEnabled=true;
                cedula.IsEnabled=true;
                contraseña.IsEnabled=true;
            }
            else
            {
                nomUsuario.IsEnabled=false;
                cedula.IsEnabled=false;
                contraseña.IsEnabled=false;
            }
        }
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (idUs.Text=="0" && idRo.Text=="0")
            {
                mensajes( "seleccione un usuario para poder ejecutar esta acción " );
            }
            else
            {
                txtEstado( true );
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            limpiarCampos();
            txtEstado(true);
        }


    }
}
