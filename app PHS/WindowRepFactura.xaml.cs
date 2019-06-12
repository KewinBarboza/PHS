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
using System.Windows.Shapes;

namespace app_PHS
{
    /// <summary>
    /// Lógica de interacción para WindowRepFactura.xaml
    /// </summary>
    public partial class WindowRepFactura : Window
    {
        public WindowRepFactura()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            reporte();
        }

        public void reporte()
        {
            PageFactura num = new PageFactura();
            crystalReportViewer1.Owner=this;
            CrystalReport1 reporte = new CrystalReport1();
            //crystalReportViewer1 = new CrystalReportViewer();
            reporte.SetParameterValue( "@numFactura", Convert.ToInt32( num.numFactura.Text ) );
            crystalReportViewer1.ViewerCore.ReportSource=reporte;
        }


    }
}
