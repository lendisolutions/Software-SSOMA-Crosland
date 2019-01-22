using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Funciones;
using Excel = Microsoft.Office.Interop.Excel;

namespace SSOMA.Presentacion.Modulos.Iperc.Consultas
{
    public partial class frmConPlanillaSector : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PlanillaBE> mLista = new List<PlanillaBE>();

        #endregion

        #region "Eventos"

        public frmConPlanillaSector()
        {
            InitializeComponent();
        }

        private void frmConPlanillaSector_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            mLista = new PlanillaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), 0, 0, 0, 0);
            gcPlanilla.DataSource = mLista;
            lblMensaje.Text = mLista.Count.ToString() + " Registros";

            Cursor = Cursors.Default;
        }

        private void gvPlanilla_ColumnFilterChanged(object sender, EventArgs e)
        {
            if (gvPlanilla.DataRowCount > 0)
            {
                lblMensaje.Text = gvPlanilla.DataRowCount.ToString() + " Registros";
            }
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            if (mLista.Count == 0)
            {
                XtraMessageBox.Show("Seleccione un filtro para obtener una Matrix IPERC", this.Text);
                return;
            }

            ExportarPlanillaExcel("");
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Lista de Peligros.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //xlLibro = xlApp.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 7;
                int Secuencia = 1;

                prgPlanilla.Minimum = 1;
                prgPlanilla.Maximum = gvPlanilla.DataRowCount + 1;
                Application.DoEvents();
                prgPlanilla.Value = 1;
                Application.DoEvents();

                if (gvPlanilla.DataRowCount > 0)
                {
                    xlHoja.Cells[5, 3] = cboEmpresa.Text;

                    for (int i = 0; i < gvPlanilla.DataRowCount; i++)
                    {
                        xlHoja.Cells[Row, 2] = gvPlanilla.GetRowCellValue(i, "DescSector").ToString();
                        xlHoja.Cells[Row, 3] = gvPlanilla.GetRowCellValue(i, "DescPeligro").ToString();
                        xlHoja.Cells[Row, 4] = gvPlanilla.GetRowCellValue(i, "TipoPeligro").ToString();
                        xlHoja.Cells[Row, 5] = gvPlanilla.GetRowCellValue(i, "DescRiesgo").ToString();
                        
                        Row = Row + 1;
                        Secuencia = Secuencia + 1;

                        prgPlanilla.Value = prgPlanilla.Value + 1;
                        Application.DoEvents();
                    }
                }



                xlLibro.SaveAs("D:\\Lista de Peligros.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show("La Lista de Peligros se exportó correctamente \n Se generó el archivo D:\\Lista de Peligros.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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