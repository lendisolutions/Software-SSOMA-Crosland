using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using System.Reflection;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SSOMA.Presentacion.Utils;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace SSOMA.Presentacion.Modulos.Medico.Registros
{
    public partial class frmRegSctr : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SctrBE> mLista = new List<SctrBE>();

        #endregion

        #region "Eventos"

        public frmRegSctr()
        {
            InitializeComponent();
        }

        private void frmRegSctr_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            deFechaDesde.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            deFechaHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegSctrEdit objManSctr = new frmRegSctrEdit();
                objManSctr.pOperacion = frmRegSctrEdit.Operacion.Nuevo;
                objManSctr.IdSctr = 0;
                objManSctr.StartPosition = FormStartPosition.CenterParent;
                objManSctr.ShowDialog();
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
                if (XtraMessageBox.Show("Esta seguro de anular el SCTR?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int intIdSctr = int.Parse(gvSctr.GetFocusedRowCellValue("IdSctr").ToString());
                    int intIdSituacion = int.Parse(gvSctr.GetFocusedRowCellValue("IdSituacion").ToString());

                    if (intIdSituacion == Parametros.intSCTRGenerada)
                    {
                        SctrBL objBL_Sctr = new SctrBL();
                        objBL_Sctr.ActualizaSituacion(intIdSctr, Parametros.intSCTRAnulada);
                        XtraMessageBox.Show("El SCTR se anuló correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede anular un SCTR diferente al Estado Generada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                ExportarFormatoExcel("");


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
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoSctrs";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvSctr.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvSctr_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtPeriodo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarNumero(Convert.ToInt32(txtPeriodo.Text));
            }
        }

        private void gvSctr_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "DescSituacion")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["DescSituacion"]);
                        if (Situacion == "GENERADA")
                        {
                            e.Appearance.ForeColor = Color.Blue;
                        }
                        if (Situacion == "ATENDIDA")
                        {
                            e.Appearance.ForeColor = Color.Green;
                        }
                        if (Situacion == "ANULADA")
                        {
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

        private void atenderAfiliacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de atender la afiliación de SCTR?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int intIdSctr = int.Parse(gvSctr.GetFocusedRowCellValue("IdSctr").ToString());
                    int intIdSituacion = int.Parse(gvSctr.GetFocusedRowCellValue("IdSituacion").ToString());

                    if (intIdSituacion == Parametros.intSCTRGenerada)
                    {
                        SctrBL objBL_Sctr = new SctrBL();
                        objBL_Sctr.ActualizaSituacion(intIdSctr, Parametros.intSCTRAtendida);
                        XtraMessageBox.Show("El SCTR se atendió correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede anular un SCTR diferente al Estado Generada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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



        #endregion

        #region "Metodos"

        private void Cargar()
        {
            if (Parametros.intPerfilId == 1)
                mLista = new SctrBL().ListaFecha(0, 0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            else
                mLista = new SctrBL().ListaFecha(Parametros.intEmpresaId, Parametros.intPersonaId, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

            gcSctr.DataSource = mLista;
        }

        private void CargarNumero(int Numero)
        {
            mLista = new SctrBL().ListaNumero(Numero);
            gcSctr.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvSctr.RowCount > 0)
            {
                SctrBE objSctr = new SctrBE();
                objSctr.IdSctr = int.Parse(gvSctr.GetFocusedRowCellValue("IdSctr").ToString());

                int intIdSituacion = int.Parse(gvSctr.GetFocusedRowCellValue("IdSituacion").ToString());
                if (intIdSituacion == Parametros.intSCTRGenerada)
                {
                    frmRegSctrEdit objManSctrEdit = new frmRegSctrEdit();
                    objManSctrEdit.pOperacion = frmRegSctrEdit.Operacion.Modificar;
                    objManSctrEdit.IdSctr = objSctr.IdSctr;
                    objManSctrEdit.StartPosition = FormStartPosition.CenterParent;
                    objManSctrEdit.btnGrabar.Enabled = true;
                    objManSctrEdit.ShowDialog();
                }

                if (intIdSituacion == Parametros.intSCTRAtendida || intIdSituacion == Parametros.intSCTRAnulada)
                {
                    frmRegSctrEdit objManSctrEdit = new frmRegSctrEdit();
                    objManSctrEdit.pOperacion = frmRegSctrEdit.Operacion.Modificar;
                    objManSctrEdit.IdSctr = objSctr.IdSctr;
                    objManSctrEdit.StartPosition = FormStartPosition.CenterParent;
                    objManSctrEdit.btnGrabar.Enabled = false;
                    objManSctrEdit.ShowDialog();
                }

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

            if (gvSctr.GetFocusedRowCellValue("IdSctr").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Sctr", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        void ExportarFormatoExcel(string filename)
        {
            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Plantilla SCTR.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            string strNumero = "";
            int intRow = 2;

            try
            {
                if (mLista.Count > 0)
                {
                    foreach (var item in mLista)
                    {
                        xlHoja.Cells[intRow, "A"] = item.RazonSocial;
                        xlHoja.Cells[intRow, "B"] = item.DescMes;
                        xlHoja.Cells[intRow, "C"] = item.TipoDocumento;
                        xlHoja.Cells[intRow, "D"] = item.NumeroDocumento;

                        String[] strSolicitante = item.Solicitante.Split(' ');
                        string strPrimerNombre = "";
                        string strSegundoNombre = "";
                        string strApellidoPaterno = "";
                        string strApellidoMaterno = "";

                        int intContardor = 0;
                        foreach (string sitem in strSolicitante)
                        {
                            intContardor++;
                        }

                        if (intContardor > 3)
                        {
                            strPrimerNombre = strSolicitante[2].ToString();
                            strSegundoNombre = strSolicitante[3].ToString();
                            strApellidoMaterno = strSolicitante[1].ToString();
                            strApellidoPaterno = strSolicitante[0].ToString();
                        }
                        else
                        {
                            strPrimerNombre = strSolicitante[2].ToString();
                            strApellidoMaterno = strSolicitante[1].ToString();
                            strApellidoPaterno = strSolicitante[0].ToString();
                        }

                        xlHoja.Cells[intRow, "E"] = strApellidoMaterno;
                        xlHoja.Cells[intRow, "F"] = strApellidoPaterno;
                        xlHoja.Cells[intRow, "G"] = strPrimerNombre;
                        xlHoja.Cells[intRow, "H"] = strSegundoNombre;
                        xlHoja.Cells[intRow, "I"] = item.Sexo;
                        xlHoja.Cells[intRow, "J"] = item.FechaNacimiento;
                        xlHoja.Cells[intRow, "K"] = item.Nacionalidad;
                        xlHoja.Cells[intRow, "L"] = "3";
                        xlHoja.Cells[intRow, "M"] = item.Cargo;
                        intRow++;
                    }
                }

                string strMensaje = "";
                xlLibro.SaveAs("D:\\Plantilla SCTR.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                strMensaje = "La Plantilla SCTR se exportó correctamente \n Se generó el archivo D:\\Plantilla SCTR.xlsx";

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