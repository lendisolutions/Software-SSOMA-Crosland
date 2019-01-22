using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using System.IO;
using System.Reflection;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion.Utils;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace SSOMA.Presentacion.Modulos.Inspeccion.Consultas
{
    public partial class frmConInspeccion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<InspeccionTrabajoDetalleBE> mLista = new List<InspeccionTrabajoDetalleBE>();

        #endregion

        #region "Eventos"

        public frmConInspeccion()
        {
            InitializeComponent();
        }

        private void frmConInspeccion_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(Parametros.intEmpresaId,Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);

            deFechaDesde.EditValue = DateTime.Now.AddDays(-30);
            deFechaHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            if (mLista.Count > 0)
            {
                ExportarFormatoExcel("");
            }
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvInspeccionTrabajoDetalle_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "DescSituacion")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["DescSituacion"]);
                        if (Situacion == "PENDIENTE")
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "PROCESO")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "EJECUTADO")
                        {
                            e.Appearance.BackColor = Color.Green;
                            e.Appearance.ForeColor = Color.Black;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new InspeccionTrabajoDetalleBL().ListaTipo(Convert.ToInt32(cboEmpresa.EditValue), 0, 0, 0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcInspeccionTrabajoDetalle.DataSource = mLista;
        }

        void ExportarFormatoExcel(string filename)
        {
            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Seguimiento de Inspecciones.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int intItem = 1;
                int intRow = 7;

                picImage.Image = new FuncionBase().Bytes2Image((byte[])mLista[0].Logo);
                string strRuta = Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg");

                picImage.Image.Save(strRuta, System.Drawing.Imaging.ImageFormat.Jpeg);

                xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 15, 2, 45, 35);

                xlHoja.Cells[5, "C"] = cboEmpresa.Text;

                foreach (var item in mLista)
                {
                    xlHoja.Cells[intRow, "A"] = intItem.ToString();
                    xlHoja.Cells[intRow, "B"] = item.Fecha;
                    xlHoja.Cells[intRow, "C"] = item.Objetivo;
                    xlHoja.Cells[intRow, "D"] = item.DescUnidadMinera;
                    xlHoja.Cells[intRow, "E"] = item.DescSector;
                    xlHoja.Cells[intRow, "F"] = item.Lugar;
                    xlHoja.Cells[intRow, "G"] = item.CondicionSubEstandar;
                    xlHoja.Cells[intRow, "K"] = item.AccionCorrectiva;
                    xlHoja.Cells[intRow, "O"] = item.Responsable;
                    xlHoja.Cells[intRow, "P"] = item.FechaEjecucion;
                    xlHoja.Cells[intRow, "Q"] = item.DescSituacion;
                    xlHoja.Cells[intRow, "R"] = item.InspeccionadoPor;
                    xlHoja.Cells[intRow, "S"] = item.Observacion;

                    intItem++;
                    intRow++;
                }


                string strMensaje = "";
                xlLibro.SaveAs("D:\\Seguimiento de Inspecciones.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                strMensaje = "El Seguimiento de las Inspecciones se exportó correctamente \n Se generó el archivo D:\\Seguimiento de Inspecciones.xlsx";
                
                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;

                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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