using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using SSOMA.Presentacion.Modulos.Otros;
using SSOMA.Presentacion;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;


namespace SSOMA.Presentacion.Modulos.Medico.Reportes
{
    public partial class frmRepDescansoMedicoConsolidado : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"

        public frmRepDescansoMedicoConsolidado()
        {
            InitializeComponent();
        }

        private void frmRepDescansoMedicoConsolidado_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            deFechaHasta.EditValue = DateTime.Now;

            deFechaDesde.Focus();
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            ExportarPlanillaExcel("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        void ExportarPlanillaExcel(string filename)
        {
            //if (filename.Trim() == "")
            //    return;

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Descanso Medico.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 2;
                int Secuencia = 1;

                List<DescansoMedicoBE> lstDescansoMedico = null;
                lstDescansoMedico = new DescansoMedicoBL().ListaFecha(0, 0, 0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                if (lstDescansoMedico.Count > 0)
                {
                    foreach (var item in lstDescansoMedico)
                    {
                        xlHoja.Cells[Row, 1] = item.RazonSocial;
                        xlHoja.Cells[Row, 2] = item.ApeNom;
                        xlHoja.Cells[Row, 3] = item.Cargo;
                        xlHoja.Cells[Row, 4] = item.DescUnidadMinera;
                        xlHoja.Cells[Row, 5] = item.DescTipoDescansoMedico;
                        xlHoja.Cells[Row, 6] = item.FechaIni;
                        xlHoja.Cells[Row, 7] = item.FechaFin;
                        xlHoja.Cells[Row, 8] = item.DescMes;
                        xlHoja.Cells[Row, 9] = item.Dias;
                        xlHoja.Cells[Row, 10] = item.Horas;
                        xlHoja.Cells[Row, 11] = item.Sueldo;
                        xlHoja.Cells[Row, 12] = item.Kpi;
                        xlHoja.Cells[Row, 13] = item.DescContingencia;
                        xlHoja.Cells[Row, 14] = item.Diagnostico;
                        xlHoja.Cells[Row, 15] = item.CentroMedico;
                        xlHoja.Cells[Row, 16] = item.Abreviatura;
                        xlHoja.Cells[Row, 17] = item.DescCondicionDescansoMedico;
                        
                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("D:\\Descanso Medico.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show("El Consolidado de Descansos Médicos se exportó correctamente \n Se generó el archivo D:\\Descanso Medico.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion


    }
}