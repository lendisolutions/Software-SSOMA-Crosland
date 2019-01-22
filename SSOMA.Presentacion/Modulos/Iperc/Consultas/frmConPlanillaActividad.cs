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
    public partial class frmConPlanillaActividad : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PlanillaBE> mLista = new List<PlanillaBE>();

        #endregion

        #region "Eventos"

        public frmConPlanillaActividad()
        {
            InitializeComponent();
            gcIndicePersona.Caption = "Indice de Personas \n Expuestas";
            gcIndiceProcedimiento.Caption = "Indice de Procedimientos \n de Trabajo";
            gcIndiceCapacitacion.Caption = "Indice de Capacitacion y \n Entranamiento";
            gcIndiceFrecuencia.Caption = "Indice de Frecuencia \n de Exposición";
            gcSeveridad.Caption = "Consecuencia \n (Severidad)";
            gcValoracionRiesgo.Caption = "Valoración \n del Riesgo";
            gcCalificacionRiesgo.Caption = "Calificación \n del Riesgo";
            gcTratamiento.Caption = "Tratamiento, Control o Aislamiento \n de los Peligros y Riesgos";
            gcControlAdministrativo.Caption = "Señalización, Advertencia y/o \n Controles Administrativo";
            gcIndicePersonaRR.Caption = "Indice de Personas \n Expuestas";
            gcIndiceProcedimientoRR.Caption = "Indice de Procedimientos \n de Trabajo";
            gcIndiceCapacitacionRR.Caption = "Indice de Capacitacion y \n Entranamiento";
            gcIndiceFrecuenciaRR.Caption = "Indice de Frecuencia \n de Exposición";
            gcSeveridadRR.Caption = "Consecuencia \n (Severidad)";
            gcValoracionRiesgoRR.Caption = "Valoración \n del Riesgo";
            gcCalificacionRiesgoRR.Caption = "Calificación \n del Riesgo";
        }

        private void frmConPlanillaActividad_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            mLista = new PlanillaBL().ListaActividad(Convert.ToInt32(cboEmpresa.EditValue), 0, 0, 0, txtDescTarea.Text);
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

        private void gvPlanilla_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "CalificacionRiesgo")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["CalificacionRiesgo"]);
                        if (Situacion == "INACEPTABLE")
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "ALTO RIESGO")
                        {
                            e.Appearance.BackColor = Color.FromArgb(255, 192, 0);
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "MODERADO")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "TOLERABLE")
                        {
                            e.Appearance.BackColor = Color.Green;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "TRIVIAL")
                        {
                            e.Appearance.BackColor = Color.Green;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }

                    if (e.Column.FieldName == "CalificacionRiesgoRR")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["CalificacionRiesgoRR"]);
                        if (Situacion == "INACEPTABLE")
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "ALTO RIESGO")
                        {
                            e.Appearance.BackColor = Color.FromArgb(255, 192, 0);
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "MODERADO")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "TOLERABLE")
                        {
                            e.Appearance.BackColor = Color.Green;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "TRIVIAL")
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Planilla.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //xlLibro = xlApp.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 11;
                int Secuencia = 1;

                prgPlanilla.Minimum = 1;
                prgPlanilla.Maximum = gvPlanilla.DataRowCount + 1;
                Application.DoEvents();
                prgPlanilla.Value = 1;
                Application.DoEvents();

                if (gvPlanilla.DataRowCount > 0)
                {
                    xlHoja.Cells[4, 8] = cboEmpresa.Text;

                    for (int i = 0; i < gvPlanilla.DataRowCount; i++)
                    {
                        xlHoja.Cells[Row, 1] = Secuencia;
                        xlHoja.Cells[Row, 2] = gvPlanilla.GetRowCellValue(i, "DescUnidadMinera").ToString();
                        xlHoja.Cells[Row, 3] = gvPlanilla.GetRowCellValue(i, "DescArea").ToString();
                        xlHoja.Cells[Row, 4] = gvPlanilla.GetRowCellValue(i, "DescSector").ToString();
                        xlHoja.Cells[Row, 5] = gvPlanilla.GetRowCellValue(i, "DescActividad").ToString();
                        if (bool.Parse(gvPlanilla.GetRowCellValue(i, "FlagRutinaria").ToString()))
                            xlHoja.Cells[Row, 6] = "X";
                        else
                            xlHoja.Cells[Row, 6] = "";

                        if (bool.Parse(gvPlanilla.GetRowCellValue(i, "FlagNoRutinaria").ToString()))
                            xlHoja.Cells[Row, 7] = "X";
                        else
                            xlHoja.Cells[Row, 7] = "";

                        if (bool.Parse(gvPlanilla.GetRowCellValue(i, "FlagEmergencia").ToString()))
                            xlHoja.Cells[Row, 8] = "X";
                        else
                            xlHoja.Cells[Row, 8] = "";

                        if (bool.Parse(gvPlanilla.GetRowCellValue(i, "FlagPropio").ToString()))
                            xlHoja.Cells[Row, 9] = "X";
                        else
                            xlHoja.Cells[Row, 9] = "";
                        if (bool.Parse(gvPlanilla.GetRowCellValue(i, "FlagTercero").ToString()))
                            xlHoja.Cells[Row, 10] = "X";
                        else
                            xlHoja.Cells[Row, 10] = "";

                        xlHoja.Cells[Row, 11] = gvPlanilla.GetRowCellValue(i, "DescPeligro").ToString();
                        xlHoja.Cells[Row, 12] = gvPlanilla.GetRowCellValue(i, "DetallePeligro").ToString();
                        xlHoja.Cells[Row, 13] = gvPlanilla.GetRowCellValue(i, "TipoPeligro").ToString();
                        xlHoja.Cells[Row, 14] = gvPlanilla.GetRowCellValue(i, "DescRiesgo").ToString();
                        xlHoja.Cells[Row, 15] = Convert.ToInt32(gvPlanilla.GetRowCellValue(i, "IndicePersona").ToString());
                        xlHoja.Cells[Row, 16] = Convert.ToInt32(gvPlanilla.GetRowCellValue(i, "IndiceProcedimiento").ToString());
                        xlHoja.Cells[Row, 17] = Convert.ToInt32(gvPlanilla.GetRowCellValue(i, "IndiceCapacitacion").ToString());
                        xlHoja.Cells[Row, 18] = Convert.ToInt32(gvPlanilla.GetRowCellValue(i, "IndiceFrecuencia").ToString());
                        xlHoja.Cells[Row, 19] = Convert.ToInt32(gvPlanilla.GetRowCellValue(i, "Severidad").ToString());
                        if (gvPlanilla.GetRowCellValue(i, "Eliminacion").ToString().Trim() == "")
                            xlHoja.Cells[Row, 23] = ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,";
                        else
                            xlHoja.Cells[Row, 23] = gvPlanilla.GetRowCellValue(i, "Eliminacion").ToString();
                        if (gvPlanilla.GetRowCellValue(i, "Situacion").ToString().Trim() == "")
                            xlHoja.Cells[Row, 24] = ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,";
                        else
                            xlHoja.Cells[Row, 24] = gvPlanilla.GetRowCellValue(i, "Situacion").ToString();
                        if (gvPlanilla.GetRowCellValue(i, "Tratamiento").ToString().Trim() == "")
                            xlHoja.Cells[Row, 25] = ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,";
                        else
                            xlHoja.Cells[Row, 25] = gvPlanilla.GetRowCellValue(i, "Tratamiento").ToString();
                        if (gvPlanilla.GetRowCellValue(i, "ControlAdministrativo").ToString().Trim() == "")
                            xlHoja.Cells[Row, 26] = ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,";
                        else
                            xlHoja.Cells[Row, 26] = gvPlanilla.GetRowCellValue(i, "ControlAdministrativo").ToString();
                        if (gvPlanilla.GetRowCellValue(i, "EquipoProteccion").ToString().Trim() == "")
                            xlHoja.Cells[Row, 27] = ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,";
                        else
                            xlHoja.Cells[Row, 27] = gvPlanilla.GetRowCellValue(i, "EquipoProteccion").ToString();
                        xlHoja.Cells[Row, 29] = Convert.ToInt32(gvPlanilla.GetRowCellValue(i, "IndicePersonaRR").ToString());
                        xlHoja.Cells[Row, 30] = Convert.ToInt32(gvPlanilla.GetRowCellValue(i, "IndiceProcedimientoRR").ToString());
                        xlHoja.Cells[Row, 31] = Convert.ToInt32(gvPlanilla.GetRowCellValue(i, "IndiceCapacitacionRR").ToString());
                        xlHoja.Cells[Row, 32] = Convert.ToInt32(gvPlanilla.GetRowCellValue(i, "IndiceFrecuenciaRR").ToString());
                        xlHoja.Cells[Row, 33] = Convert.ToInt32(gvPlanilla.GetRowCellValue(i, "SeveridadRR").ToString());
                        Row = Row + 1;
                        Secuencia = Secuencia + 1;

                        prgPlanilla.Value = prgPlanilla.Value + 1;
                        Application.DoEvents();
                    }
                }



                xlLibro.SaveAs("D:\\Planilla.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show("La Matriz IPERC se exportó correctamente \n Se generó el archivo D:\\Planilla.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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