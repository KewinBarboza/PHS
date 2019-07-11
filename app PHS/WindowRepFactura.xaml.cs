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
            //reporte();
        }

        public void reporte(int numF)
        {
            crystalReportViewer1.Owner=this;
            ReportFactura reporte = new ReportFactura();
            reporte.SetParameterValue( "@numFactura", Convert.ToInt32( numF ) );
            crystalReportViewer1.ViewerCore.ReportSource=reporte;
        }

        public void reporteClientes(string numRif)
        {
            crystalReportViewer1.Owner=this;
            ReportClientes reporte = new ReportClientes();
            reporte.SetParameterValue( "@numRif",  numRif  );
            crystalReportViewer1.ViewerCore.ReportSource=reporte;
        }

        public void reporteClientesStatus(int numStatus)
        {
            crystalReportViewer1.Owner=this;
            ReportClienteStatus reporte = new ReportClienteStatus();
            reporte.SetParameterValue( "@status", numStatus );
            crystalReportViewer1.ViewerCore.ReportSource=reporte;
        }

        public void reportePartesPiezasIndice(string codigo, string indProceso, string indDiseño)
        {
            crystalReportViewer1.Owner=this;
            ReportProcesos reporte = new ReportProcesos();
            reporte.SetParameterValue( "@codigo", codigo );
            reporte.SetParameterValue( "@indProceso", indProceso );
            reporte.SetParameterValue( "@IndModificacion", indDiseño );
            crystalReportViewer1.ViewerCore.ReportSource=reporte;
        }

        public void reporteMaestroMateriales(string codigo, string indModificacion, int opc)
        {
            crystalReportViewer1.Owner=this;
            ReportMaestroMateriales reporte = new ReportMaestroMateriales();
            reporte.SetParameterValue( "@codigo", codigo );
            reporte.SetParameterValue( "@indModificacion", indModificacion );
            reporte.SetParameterValue( "@opc", opc );
            crystalReportViewer1.ViewerCore.ReportSource=reporte;
        }

        public void reporteCicloProceso(string codigo, string indModificacion,string indProceso, int opc)
        {
            crystalReportViewer1.Owner=this;
            ReportCicloProduccion reporte = new ReportCicloProduccion();
            reporte.SetParameterValue( "@codigo", codigo );
            reporte.SetParameterValue( "@indModificacion", indModificacion );
            reporte.SetParameterValue( "@indProceso", indProceso );
            reporte.SetParameterValue( "@opc", opc );
            crystalReportViewer1.ViewerCore.ReportSource=reporte;
        }
    }
}
