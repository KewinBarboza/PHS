using CrystalDecisions.CrystalReports.Engine;
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

        public void reporteMaestroMateriales(string codigo, string indModificacion, string desc ,int opc)
        {
            crystalReportViewer1.Owner=this;
            ReportMaestroMateriales reporte = new ReportMaestroMateriales();
            reporte.SetParameterValue( "@codigo", codigo );
            reporte.SetParameterValue( "@indModificacion", indModificacion );
            reporte.SetParameterValue( "@desc", desc );
            reporte.SetParameterValue( "@opc", opc );
            crystalReportViewer1.ViewerCore.ReportSource=reporte;
        }

        public void reporteCicloProceso(string codigo, string indModificacion,string indProceso,string desc, int opc)
        {
            crystalReportViewer1.Owner=this;
            ReportCicloProduccion reporte = new ReportCicloProduccion();
            reporte.SetParameterValue( "@codigo", codigo );
            reporte.SetParameterValue( "@indModificacion", indModificacion );
            reporte.SetParameterValue( "@indProceso", indProceso );
            reporte.SetParameterValue( "@desc", desc );
            reporte.SetParameterValue( "@opc", opc );
            crystalReportViewer1.ViewerCore.ReportSource=reporte;
        }

        public void reporteSopDatosTecnicos(string codigo, string indModificacion, string indProceso,string operacion, int opc)
        {
            crystalReportViewer1.Owner=this;
            ReportSopDatosTecnicos reporte = new ReportSopDatosTecnicos();
            reporte.SetParameterValue( "@codigo", codigo );
            reporte.SetParameterValue( "@indModificacion", indModificacion );
            reporte.SetParameterValue( "@indProceso", indProceso );
            reporte.SetParameterValue( "@operacion", operacion );
            reporte.SetParameterValue( "@opc", opc );
            crystalReportViewer1.ViewerCore.ReportSource=reporte;
        }

        public void reporteInventarioInversoraMovimiento(string movimiento, string material, string fechaDesde, string fechaHasta, int opc)
        {
            if (opc == 1)
            {
                crystalReportViewer1.Owner=this;
                ReportInventarioInverosoraMovimiento reporte = new ReportInventarioInverosoraMovimiento();
                reporte.SetParameterValue( "@movimiento", movimiento );
                reporte.SetParameterValue( "@material", material );
                reporte.SetParameterValue( "@fechaDesde", fechaDesde );
                reporte.SetParameterValue( "@fechaHasta", fechaHasta );
                reporte.SetParameterValue( "@opc", opc );

                TextObject fechaInicio;
                fechaInicio=(TextObject)reporte.Section1.ReportObjects["fechaInicio"];
                fechaInicio.Text=fechaDesde;

                TextObject fechaFin;
                fechaFin=(TextObject)reporte.Section1.ReportObjects["fechaFin"];
                fechaFin.Text=fechaHasta;

                crystalReportViewer1.ViewerCore.ReportSource=reporte;
            }
            else if (opc==2)
            {
                crystalReportViewer1.Owner=this;
                ReportInventarioInversoraMaterial reporte = new ReportInventarioInversoraMaterial();
                reporte.SetParameterValue( "@movimiento", movimiento );
                reporte.SetParameterValue( "@material", material );
                reporte.SetParameterValue( "@fechaDesde", fechaDesde );
                reporte.SetParameterValue( "@fechaHasta", fechaHasta );
                reporte.SetParameterValue( "@opc", opc );

                TextObject fechaInicio;
                fechaInicio=(TextObject)reporte.Section1.ReportObjects["fechaInicio"];
                fechaInicio.Text=fechaDesde;

                TextObject fechaFin;
                fechaFin=(TextObject)reporte.Section1.ReportObjects["fechaFin"];
                fechaFin.Text=fechaHasta;

                crystalReportViewer1.ViewerCore.ReportSource=reporte;
            }
            else if (opc==3)
            {
                crystalReportViewer1.Owner=this;
                ReportInventarioInversoraMovMaterial reporte = new ReportInventarioInversoraMovMaterial();
                reporte.SetParameterValue( "@movimiento", movimiento );
                reporte.SetParameterValue( "@material", material );
                reporte.SetParameterValue( "@fechaDesde", fechaDesde );
                reporte.SetParameterValue( "@fechaHasta", fechaHasta );
                reporte.SetParameterValue( "@opc", opc );

                TextObject fechaInicio;
                fechaInicio=(TextObject)reporte.Section1.ReportObjects["fechaInicio"];
                fechaInicio.Text=fechaDesde;

                TextObject fechaFin;
                fechaFin=(TextObject)reporte.Section1.ReportObjects["fechaFin"];
                fechaFin.Text=fechaHasta;

                crystalReportViewer1.ViewerCore.ReportSource=reporte;
            }
            
        }

        public void reporteInventarioAdministradoraMovimiento(string movimiento, string material, string fechaDesde, string fechaHasta, int opc)
        {
            if (opc==1)
            {
                crystalReportViewer1.Owner=this;
                ReportInventarioAdministradoraMovimiento reporte = new ReportInventarioAdministradoraMovimiento();
                reporte.SetParameterValue( "@movimiento", movimiento );
                reporte.SetParameterValue( "@material", material );
                reporte.SetParameterValue( "@fechaDesde", fechaDesde );
                reporte.SetParameterValue( "@fechaHasta", fechaHasta );
                reporte.SetParameterValue( "@opc", opc );

                TextObject fechaInicio;
                fechaInicio=(TextObject)reporte.Section1.ReportObjects["fechaInicio"];
                fechaInicio.Text=fechaDesde;

                TextObject fechaFin;
                fechaFin=(TextObject)reporte.Section1.ReportObjects["fechaFin"];
                fechaFin.Text=fechaHasta;

                crystalReportViewer1.ViewerCore.ReportSource=reporte;
            }
            else if (opc==2)
            {
                crystalReportViewer1.Owner=this;
                ReportInventarioAdministradoraMaterial reporte = new ReportInventarioAdministradoraMaterial();
                reporte.SetParameterValue( "@movimiento", movimiento );
                reporte.SetParameterValue( "@material", material );
                reporte.SetParameterValue( "@fechaDesde", fechaDesde );
                reporte.SetParameterValue( "@fechaHasta", fechaHasta );
                reporte.SetParameterValue( "@opc", opc );

                TextObject fechaInicio;
                fechaInicio=(TextObject)reporte.Section1.ReportObjects["fechaInicio"];
                fechaInicio.Text=fechaDesde;

                TextObject fechaFin;
                fechaFin=(TextObject)reporte.Section1.ReportObjects["fechaFin"];
                fechaFin.Text=fechaHasta;

                crystalReportViewer1.ViewerCore.ReportSource=reporte;
            }
            else if (opc==3)
            {
                crystalReportViewer1.Owner=this;
                ReportInventarioAdministradoraMovMaterial reporte = new ReportInventarioAdministradoraMovMaterial();
                reporte.SetParameterValue( "@movimiento", movimiento );
                reporte.SetParameterValue( "@material", material );
                reporte.SetParameterValue( "@fechaDesde", fechaDesde );
                reporte.SetParameterValue( "@fechaHasta", fechaHasta );
                reporte.SetParameterValue( "@opc", opc );

                TextObject fechaInicio;
                fechaInicio=(TextObject)reporte.Section1.ReportObjects["fechaInicio"];
                fechaInicio.Text=fechaDesde;

                TextObject fechaFin;
                fechaFin=(TextObject)reporte.Section1.ReportObjects["fechaFin"];
                fechaFin.Text=fechaHasta;

                crystalReportViewer1.ViewerCore.ReportSource=reporte;
            }

        }

        public void reporteInventarioTratamaqMovimientos(string movimiento, string material, string fechaDesde, string fechaHasta, int opc)
        {
            if (opc==1)
            {
                crystalReportViewer1.Owner=this;
                ReportInventarioTratamaqMovimiento reporte = new ReportInventarioTratamaqMovimiento();
                reporte.SetParameterValue( "@movimiento", movimiento );
                reporte.SetParameterValue( "@material", material );
                reporte.SetParameterValue( "@fechaDesde", fechaDesde );
                reporte.SetParameterValue( "@fechaHasta", fechaHasta );
                reporte.SetParameterValue( "@opc", opc );

                TextObject fechaInicio;
                fechaInicio=(TextObject)reporte.Section1.ReportObjects["fechaInicio"];
                fechaInicio.Text=fechaDesde;

                TextObject fechaFin;
                fechaFin=(TextObject)reporte.Section1.ReportObjects["fechaFin"];
                fechaFin.Text=fechaHasta;

                crystalReportViewer1.ViewerCore.ReportSource=reporte;
            }
            else if (opc==2)
            {
                crystalReportViewer1.Owner=this;
               ReportInventarioTratamaqMaterial reporte = new ReportInventarioTratamaqMaterial();
                reporte.SetParameterValue( "@movimiento", movimiento );
                reporte.SetParameterValue( "@material", material );
                reporte.SetParameterValue( "@fechaDesde", fechaDesde );
                reporte.SetParameterValue( "@fechaHasta", fechaHasta );
                reporte.SetParameterValue( "@opc", opc );

                TextObject fechaInicio;
                fechaInicio=(TextObject)reporte.Section1.ReportObjects["fechaInicio"];
                fechaInicio.Text=fechaDesde;

                TextObject fechaFin;
                fechaFin=(TextObject)reporte.Section1.ReportObjects["fechaFin"];
                fechaFin.Text=fechaHasta;

                crystalReportViewer1.ViewerCore.ReportSource=reporte;
            }
            else if (opc==3)
            {
                crystalReportViewer1.Owner=this;
                ReportInventarioTratamaqMovMaterial reporte = new ReportInventarioTratamaqMovMaterial();
                reporte.SetParameterValue( "@movimiento", movimiento );
                reporte.SetParameterValue( "@material", material );
                reporte.SetParameterValue( "@fechaDesde", fechaDesde );
                reporte.SetParameterValue( "@fechaHasta", fechaHasta );
                reporte.SetParameterValue( "@opc", opc );

                TextObject fechaInicio;
                fechaInicio=(TextObject)reporte.Section1.ReportObjects["fechaInicio"];
                fechaInicio.Text=fechaDesde;

                TextObject fechaFin;
                fechaFin=(TextObject)reporte.Section1.ReportObjects["fechaFin"];
                fechaFin.Text=fechaHasta;

                crystalReportViewer1.ViewerCore.ReportSource=reporte;
            }

        }
        public void ReportFichaTrabajador(string codigo, int opc)
        {
            crystalReportViewer1.Owner=this;
            ReportFichaTrabajador reporte = new ReportFichaTrabajador();
            reporte.SetParameterValue( "@buscar", codigo );
            reporte.SetParameterValue( "@opc", opc );
            crystalReportViewer1.ViewerCore.ReportSource=reporte;
        }

        public void ReportHistoricoSueldo(string codigo, int opc)
        {
            crystalReportViewer1.Owner=this;
            ReportHistoricoSueldo reporte = new ReportHistoricoSueldo();
            reporte.SetParameterValue( "@buscar", codigo );
            reporte.SetParameterValue( "@opc", opc );
            crystalReportViewer1.ViewerCore.ReportSource=reporte;
        }
    }

}
