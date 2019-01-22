using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Funciones;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Capacitacion.Registros
{
    public partial class frmRegPlanAnual : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PlanAnualBE> mLista = new List<PlanAnualBE>();

        private GridColumn gcColumnTotal;
        
        #endregion

        #region "Eventos"

        public frmRegPlanAnual()
        {
            InitializeComponent();
        }

        private void frmRegPlanAnual_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();

            gvPlanAnual.OptionsView.ShowFooter = true;
            gvPlanAnual.Layout += new EventHandler(gvPlanAnual_Layout);

            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;

            txtPeriodo.EditValue = DateTime.Now.Year;
            

            AttachSummaryCosto();
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
            }
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegPlanAnualEdit objManPlanAnual = new frmRegPlanAnualEdit();
                objManPlanAnual.lstPlanAnual = mLista;
                objManPlanAnual.pOperacion = frmRegPlanAnualEdit.Operacion.Nuevo;
                objManPlanAnual.intIdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                objManPlanAnual.intIdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
                objManPlanAnual.IdPlanAnual = 0;
                objManPlanAnual.StartPosition = FormStartPosition.CenterParent;
                objManPlanAnual.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        PlanAnualBE objE_PlanAnual = new PlanAnualBE();
                        objE_PlanAnual.IdPlanAnual = int.Parse(gvPlanAnual.GetFocusedRowCellValue("IdPlanAnual").ToString());
                        objE_PlanAnual.Usuario = Parametros.strUsuarioLogin;
                        objE_PlanAnual.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_PlanAnual.IdEmpresa = Parametros.intEmpresaId;

                        PlanAnualBL objBL_PlanAnual = new PlanAnualBL();
                        objBL_PlanAnual.Elimina(objE_PlanAnual);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (gvPlanAnual.RowCount > 0)
                {
                    int IdPlanAnual = 0;
                    IdPlanAnual = int.Parse(gvPlanAnual.GetFocusedRowCellValue("IdPlanAnual").ToString());
                    List<ReportePlanAnualBE> lstReporte = null;

                    lstReporte = new ReportePlanAnualBL().Listado(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboUnidadMinera.EditValue), Convert.ToInt32(txtPeriodo.EditValue));

                    if (lstReporte != null)
                    {
                        RptVistaReportes objRptAccUsu = new RptVistaReportes();
                        objRptAccUsu.VerRptPlanAnual(lstReporte);
                        objRptAccUsu.ShowDialog();

                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_ExportClick()
        {
            ExportarPlanillaExcel("");
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPlanAnual_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtPeriodo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cargar();
            }
        }

        private void gvPlanAnual_Layout(object sender, EventArgs e)
        {
            AttachSummaryCosto();
        }

        private void gvPlanAnual_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (e.Column.FieldName == "DescTipoCapacitacion")
                {
                    string Tipo = View.GetRowCellDisplayText(e.RowHandle, View.Columns["DescTipoCapacitacion"]);
                    if (Tipo == "CAPACITACIÓN")
                    {
                        e.Appearance.BackColor = Color.Green;
                        e.Appearance.ForeColor = Color.Black;
                    }
                    if (Tipo == "SENSIBILIZACIÓN" || Tipo == "DIFUSIÓN")
                    {
                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.ForeColor = Color.Black;
                    }
                    if (Tipo == "ENTRENAMIENTO")
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
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
            mLista = new PlanAnualBL().ListaPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboUnidadMinera.EditValue), Convert.ToInt32(txtPeriodo.EditValue));
            gcPlanAnual.DataSource = mLista;

            AttachSummaryCosto();
        }

        public void InicializarModificar()
        {
            if (gvPlanAnual.RowCount > 0)
            {
                PlanAnualBE objPlanAnual = new PlanAnualBE();
                objPlanAnual.IdPlanAnual = int.Parse(gvPlanAnual.GetFocusedRowCellValue("IdPlanAnual").ToString());

                frmRegPlanAnualEdit objManPlanAnualEdit = new frmRegPlanAnualEdit();
                objManPlanAnualEdit.pOperacion = frmRegPlanAnualEdit.Operacion.Modificar;
                objManPlanAnualEdit.IdPlanAnual = objPlanAnual.IdPlanAnual;
                objManPlanAnualEdit.intIdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                objManPlanAnualEdit.intIdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
                objManPlanAnualEdit.StartPosition = FormStartPosition.CenterParent;
                objManPlanAnualEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvPlanAnual.GetFocusedRowCellValue("IdPlanAnual").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una PlanAnual", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void AttachSummaryCosto()
        {
            GridColumn SecondColumn = gvPlanAnual.VisibleColumns.Count == 0 ? null : gvPlanAnual.VisibleColumns[8];
            if (gcColumnTotal == SecondColumn) return;
            if (gcColumnTotal != null)
            {
                gcColumnTotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;
            }

            gcColumnTotal = SecondColumn;

            if (gcColumnTotal != null)
            {
                gcColumnTotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gcColumnTotal.SummaryItem.DisplayFormat = "SUM={0:#,0.00}";
            }
        }

        void ExportarPlanillaExcel(string filename)
        {
            //if (filename.Trim() == "")
            //    return;

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Programa Anual de Capacitaciones.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 8;
                int Secuencia = 1;

                List<PlanAnualBE> lstPlanAnual = null;
                lstPlanAnual = new PlanAnualBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue),Convert.ToInt32(cboUnidadMinera.EditValue),Convert.ToInt32(txtPeriodo.EditValue));

                if (lstPlanAnual.Count > 0)
                {
                    picImage.Image = new FuncionBase().Bytes2Image((byte[])lstPlanAnual[0].Logo);
                    string strRuta = Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg");

                    picImage.Image.Save(strRuta, System.Drawing.Imaging.ImageFormat.Jpeg);

                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 21, 12, 60, 50);

                   
                    xlHoja.Cells[4, 5] = cboEmpresa.Text;
                    xlHoja.Cells[4, 12] = cboUnidadMinera.Text;
                    xlHoja.Cells[4, 21] = txtPeriodo.Text;

                    foreach (var item in lstPlanAnual)
                    {
                        xlHoja.Cells[Row, 3] = item.DescTema;
                        if (item.IdTipoCapacitacion == Parametros.intTCCapacitacionGeneral)
                        {
                            xlHoja.Cells[Row, 5] = "X";
                        }
                        if (item.IdTipoCapacitacion == Parametros.intTCCapacitacionEspecifica)
                        {
                            xlHoja.Cells[Row, 6] = "X";
                        }
                        if (item.IdTipoCapacitacion == Parametros.intTCEntrenamiento)
                        {
                            xlHoja.Cells[Row, 7] = "X";
                        }
                        if (item.IdTipoCapacitacion == Parametros.intTCSensibilizacion)
                        {
                            xlHoja.Cells[Row, 7] = "X";
                        }
                        if (item.IdClaseCapacitacion == 23)
                        {
                            xlHoja.Cells[Row, 8] = "X";
                        }
                        if (item.IdClaseCapacitacion == 24)
                        {
                            xlHoja.Cells[Row, 9] = "X";
                        }

                        xlHoja.Cells[Row, 11] = item.DescResponsableCapacitacion;
                        xlHoja.Cells[Row, 12] = item.Duracion;

                        //MESES
                        List<PlanAnualDetalleBE> lstPlanAnualDetalle = null;
                        lstPlanAnualDetalle = new PlanAnualDetalleBL().ListaTodosActivo(item.IdPlanAnual);

                        foreach (var itemmes in lstPlanAnualDetalle)
                        {
                            if (itemmes.DescMes == "ENERO")
                            {
                                xlHoja.Cells[Row, 13] = "X";
                            }

                            if (itemmes.DescMes == "FEBRERO")
                            {
                                xlHoja.Cells[Row, 14] = "X";
                            }

                            if (itemmes.DescMes == "MARZO")
                            {
                                xlHoja.Cells[Row, 15] = "X";
                            }

                            if (itemmes.DescMes == "ABRIL")
                            {
                                xlHoja.Cells[Row, 16] = "X";
                            }

                            if (itemmes.DescMes == "MAYO")
                            {
                                xlHoja.Cells[Row, 17] = "X";
                            }

                            if (itemmes.DescMes == "JUNIO")
                            {
                                xlHoja.Cells[Row, 18] = "X";
                            }

                            if (itemmes.DescMes == "JULIO")
                            {
                                xlHoja.Cells[Row, 19] = "X";
                            }

                            if (itemmes.DescMes == "AGOSTO")
                            {
                                xlHoja.Cells[Row, 20] = "X";
                            }

                            if (itemmes.DescMes == "SETIEMBRE")
                            {
                                xlHoja.Cells[Row, 21] = "X";
                            }

                            if (itemmes.DescMes == "OCTUBRE")
                            {
                                xlHoja.Cells[Row, 22] = "X";
                            }

                            if (itemmes.DescMes == "NOVIEMBRE")
                            {
                                xlHoja.Cells[Row, 23] = "X";
                            }

                            if (itemmes.DescMes == "DICIEMBRE")
                            {
                                xlHoja.Cells[Row, 24] = "X";
                            }
                        }



                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("D:\\Programa Anual de Capacitaciones.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show("El Programa Anual de Capacitaciones se exportó correctamente \n Se generó el archivo D:\\Programa Anual de Capacitaciones.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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