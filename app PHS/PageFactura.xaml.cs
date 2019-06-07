using System;
using System.Data;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using CapaNegocios;
using ClosedXML.Excel;
using System.Diagnostics;
using Microsoft.Win32;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using System.Windows.Controls;

namespace app_PHS
{
    /// <summary>
    /// Lógica de interacción para PageFactura.xaml
    /// </summary>
    public partial class PageFactura
    {
        public PageFactura()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new Home() );
        }

        public void consultarFactura(string codFactura)
        {
            int codFact = Convert.ToInt32( codFactura );
            System.Data.DataTable dt = new System.Data.DataTable();
            dt=NegFactura.consultarFactura( codFact );

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
            dt=NegFactura.consultarFacturaFecha(fechaIni.Text,fechaFin.Text);

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
            dt=NegFactura.consultarFacturaCodigoCliente(codClientes);

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

        private void exportarFacturaExcel()
        {


            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Excel (*.xls)|*.xls"
            };

            if (dialog.ShowDialog() == true)
            {

                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add(System.Reflection.Missing.Value);
                hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                //Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                //excel.Visible = true; //www.yazilimkodlama.com
                //Workbook workbook = excel.Workbooks.Add();
                //Worksheet hoja_trabajo = (Worksheet)workbook.Sheets[1];


                //hoja_trabajo.Range["A1:A1"].Value = "" + hoja_trabajo.Shapes.AddPicture(@"C:\Users\kbarboza\Desktop\proyecto\PROYECTO PHS\PHS\app PHS\Assets/LOCKEY.png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 50, 50, 100, 45) + "";
                //hoja_trabajo.Range["B1:J1"].Merge();
                //hoja_trabajo.Range["B1:J1"].Value = t1.Text + "\n" + t2.Text + "\n" + t3.Text + "\n" + t4.Text + "\n" + t5.Text + "\n" + t6.Text;
                //hoja_trabajo.Range["A2:A2"].Value = numFactura.Text;
                //hoja_trabajo.Range["B1:J1"].Font.Size = 10;
                //hoja_trabajo.Range["B1:J1"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                for (int j = 0; j < GridFactura.Columns.Count; j++) //Başlıklar için
                {
                    Range myRange = (Range)hoja_trabajo.Cells[1, j + 1];
                    hoja_trabajo.Cells[1, j + 1].Font.Bold = true; //Başlığın Kalın olması için
                    hoja_trabajo.Columns[j + 1].ColumnWidth = 15; //Sütun genişliği ayarı
                    myRange.Value2 = GridFactura.Columns[j].Header;
                }

                for (int i = 0; i < GridFactura.Columns.Count; i++)
                { //www.yazilimkodlama.com
                    for (int j = 0; j < GridFactura.Items.Count; j++)
                    {
                        //hoja_trabajo.Cells[i + 4, j + 1] = GridFactura.Columns[i].GetCellContent(GridFactura.Items[j]).ToString();
                        //TextBlock b = GridFactura.Columns[i].GetCellContent(GridFactura.Items[j]) as TextBlock;
                        //Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)hoja_trabajo.Cells[j + 2, i + 1];
                        //myRange.Value2 = b.Text;

                        hoja_trabajo.Cells[i + 4, j + 1] = GridFacturas.Columns[i].GetCellContent(GridFacturas.Items[j]).ToString();
                        Microsoft.Office.Interop.Excel.Range Rango = hoja_trabajo.Range["A" + (i + 4).ToString() + ":J" + (j + 1).ToString()];
                        Rango.Columns.AutoFit();

                       
                    }
                }

                //for (int i = 0; i < grd.Rows.Count; i++)
                //{
                //    for (int j = 0; j < grd.Columns.Count; j++)
                //    {
                //        hoja_trabajo.Cells[i + 4, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                //        Microsoft.Office.Interop.Excel.Range Rango = hoja_trabajo.Range["A" + (i + 4).ToString() + ":J" + (j + 1).ToString()];
                //        Rango.Columns.AutoFit();
                //    }
                //}


                libros_trabajo.SaveAs(dialog.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }



            //string pathReporte = @"C:\Users\kbarboza\Desktop\\plantillaRepIdeCestas.xlsx";


            //var workbook = new XLWorkbook(pathReporte.ToString());
            //var worksheet = workbook.Worksheets.Worksheet("Hoja1");
            //worksheet.Protect("lockeyInformatica");

            //worksheet.Cell("numFactura").Value = numFactura.Text;
            //worksheet.Cell("nomCliente").Value = nomCliente.Text;
            //worksheet.Cell("fecFactura").Value = fecFactura.Text;
            //worksheet.Cell("fecDespacho").Value = fecDespacho.Text;

            //worksheet.Cell("numGUia").Value = numGUia.Text;
            //worksheet.Cell("numTransporte").Value = numTransporte.Text;
            //worksheet.Cell("fecRecibido").Value = fecRecibido.Text;
            //worksheet.Cell("monFlete").Value = monFlete.Text;
            //worksheet.Cell("porFlete").Value = porFlete.Text;
            //worksheet.Cell("porFlete").Value = porFlete.Text;

            //worksheet.Cell("monto").Value = monto.Text;
            //worksheet.Cell("desc").Value = desc.Text;
            //worksheet.Cell("neto").Value = neto.Text;
            //worksheet.Cell("total").Value = total.Text;
            //worksheet.Cell("iva").Value = iva.Text;



            //for (var i = 0; i < GridFactura.Columns.Count; i++)
            //{
            //    Cell[1, i + 1] = GridFactura.Columns[i].ColumnName;
            //}

            // rows
            //for (var i = 0; i < GridFactura.Items.Count; i++)
            //{
            //    // to do: format datetime values before printing
            //    for (var j = 0; j < GridFactura.Columns.Count; j++)
            //    {
            //        foreach (var r in Enumerable.Range(1, 5))
            //            foreach (var c in Enumerable.Range(1, 5))
            //                worksheet.Cell(r, c).Value = i.ToString()+j.ToString();
            //    }
            //}





            //string nombreSalida = pathReporte.ToString() + ".xlsx";

            //workbook.SaveAs(nombreSalida.ToString());

            //Process proc = new Process();
            ////proc.EnableRaisingEvents=false;

            //proc.StartInfo.FileName = nombreSalida.ToString();
            //proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;

            //proc.StartInfo.Arguments = nombreSalida.ToString();
            //proc.Start();

        }


        private void ExportarExcel_Selected(object sender, RoutedEventArgs e)
        {
            //exportarFacturaExcel();
        }
    }
}
