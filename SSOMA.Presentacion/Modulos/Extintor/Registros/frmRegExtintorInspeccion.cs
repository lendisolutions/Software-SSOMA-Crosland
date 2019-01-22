using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SSOMA.Presentacion.Utils;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;


namespace SSOMA.Presentacion.Modulos.Extintor.Registros
{
    public partial class frmRegExtintorInspeccion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ExtintorInspeccionBE> mLista = new List<ExtintorInspeccionBE>();
        private List<ExtintorInspeccionBE> mListaInspeccion = new List<ExtintorInspeccionBE>();

        #endregion

        #region "Eventos"

        public frmRegExtintorInspeccion()
        {
            InitializeComponent();
        }

        private void frmRegExtintorInspeccion_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0, Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            tlbMenu.Ensamblado = this.Tag.ToString();
            deFechaDesde.EditValue = new DateTime(2000, 1, 1);
            deFechaHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegExtintorInspeccionEdit objManExtintorInspeccion = new frmRegExtintorInspeccionEdit();
                objManExtintorInspeccion.lstExtintorInspeccion = mLista;
                objManExtintorInspeccion.pOperacion = frmRegExtintorInspeccionEdit.Operacion.Nuevo;
                objManExtintorInspeccion.IdExtintorInspeccion = 0;
                objManExtintorInspeccion.StartPosition = FormStartPosition.CenterParent;
                objManExtintorInspeccion.ShowDialog();
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
                        ExtintorInspeccionBE objE_ExtintorInspeccion = new ExtintorInspeccionBE();
                        objE_ExtintorInspeccion.IdExtintorInspeccion = int.Parse(gvExtintorInspeccion.GetFocusedRowCellValue("IdExtintorInspeccion").ToString());
                        objE_ExtintorInspeccion.Usuario = Parametros.strUsuarioLogin;
                        objE_ExtintorInspeccion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ExtintorInspeccion.IdEmpresa = Parametros.intEmpresaId;

                        ExtintorInspeccionBL objBL_ExtintorInspeccion = new ExtintorInspeccionBL();
                        objBL_ExtintorInspeccion.Elimina(objE_ExtintorInspeccion);
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

                if (gvExtintorInspeccion.RowCount>0)
                {
                    mListaInspeccion.Clear();

                    int IdExtintorInspeccion = 0;
                    IdExtintorInspeccion = int.Parse(gvExtintorInspeccion.GetFocusedRowCellValue("IdExtintorInspeccion").ToString());
                    mListaInspeccion = new ExtintorInspeccionBL().ListaReporte(IdExtintorInspeccion);

                    ExportarFormatoExcel("");
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
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoExtintorInspeccions";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvExtintorInspeccion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvExtintorInspeccion_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ExtintorInspeccionBL().ListaFecha(Convert.ToInt32(cboEmpresa.EditValue), 0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcExtintorInspeccion.DataSource = mLista;
        }

        
        public void InicializarModificar()
        {
            if (gvExtintorInspeccion.RowCount > 0)
            {
                ExtintorInspeccionBE objExtintorInspeccion = new ExtintorInspeccionBE();
                objExtintorInspeccion.IdExtintorInspeccion = int.Parse(gvExtintorInspeccion.GetFocusedRowCellValue("IdExtintorInspeccion").ToString());

                frmRegExtintorInspeccionEdit objManExtintorInspeccionEdit = new frmRegExtintorInspeccionEdit();
                objManExtintorInspeccionEdit.pOperacion = frmRegExtintorInspeccionEdit.Operacion.Modificar;
                objManExtintorInspeccionEdit.IdExtintorInspeccion = objExtintorInspeccion.IdExtintorInspeccion;
                objManExtintorInspeccionEdit.StartPosition = FormStartPosition.CenterParent;
                objManExtintorInspeccionEdit.ShowDialog();

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

            if (gvExtintorInspeccion.GetFocusedRowCellValue("IdExtintorInspeccion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una ExtintorInspeccion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Inspeccion Extintores.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int intItem = 1;
                int intRow = 9;

                xlHoja.Cells[5, "F"] = mListaInspeccion[0].DescTipoInspeccion;
                xlHoja.Cells[5, "AC"] = mListaInspeccion[0].DescUnidadMinera;
                xlHoja.Cells[6, "D"] = mListaInspeccion[0].InspeccionadoPor;
                xlHoja.Cells[6, "K"] = mListaInspeccion[0].Cargo;
                xlHoja.Cells[6, "Z"] = mListaInspeccion[0].FechaInspeccion;

                foreach (var item in mListaInspeccion)
                {
                    xlHoja.Cells[intRow, "B"] = item.Codigo;
                    xlHoja.Cells[intRow, "C"] = item.Serie;
                    xlHoja.Cells[intRow, "D"] = item.Abreviatura;
                    xlHoja.Cells[intRow, "E"] = item.Capacidad;
                    xlHoja.Cells[intRow, "F"] = item.Ubicacion;
                    xlHoja.Cells[intRow, "G"] = item.Marca;
                    if (item.Uno)
                        xlHoja.Cells[intRow, "H"] = "X";
                    else
                        xlHoja.Cells[intRow, "H"] = "";
                    if (item.Dos)
                        xlHoja.Cells[intRow, "I"] = "X";
                    else
                        xlHoja.Cells[intRow, "I"] = "";
                    if (item.Tres)
                        xlHoja.Cells[intRow, "J"] = "X";
                    else
                        xlHoja.Cells[intRow, "J"] = "";
                    if (item.Cuatro)
                        xlHoja.Cells[intRow, "K"] = "X";
                    else
                        xlHoja.Cells[intRow, "K"] = "";
                    if (item.Cinco)
                        xlHoja.Cells[intRow, "L"] = "X";
                    else
                        xlHoja.Cells[intRow, "L"] = "";
                    if (item.Seis)
                        xlHoja.Cells[intRow, "M"] = "X";
                    else
                        xlHoja.Cells[intRow, "M"] = "";
                    if (item.Siete)
                        xlHoja.Cells[intRow, "N"] = "X";
                    else
                        xlHoja.Cells[intRow, "N"] = "";
                    if (item.Ocho)
                        xlHoja.Cells[intRow, "O"] = "X";
                    else
                        xlHoja.Cells[intRow, "O"] = "";
                    if (item.Nueve)
                        xlHoja.Cells[intRow, "P"] = "X";
                    else
                        xlHoja.Cells[intRow, "P"] = "";
                    if (item.Diez)
                        xlHoja.Cells[intRow, "Q"] = "X";
                    else
                        xlHoja.Cells[intRow, "Q"] = "";
                    if (item.Once)
                        xlHoja.Cells[intRow, "R"] = "X";
                    else
                        xlHoja.Cells[intRow, "R"] = "";
                    if (item.Doce)
                        xlHoja.Cells[intRow, "S"] = "X";
                    else
                        xlHoja.Cells[intRow, "S"] = "";
                    if (item.Trece)
                        xlHoja.Cells[intRow, "T"] = "X";
                    else
                        xlHoja.Cells[intRow, "T"] = "";
                    if (item.Catorce)
                        xlHoja.Cells[intRow, "U"] = "X";
                    else
                        xlHoja.Cells[intRow, "U"] = "";
                    if (item.Quince)
                        xlHoja.Cells[intRow, "V"] = "X";
                    else
                        xlHoja.Cells[intRow, "V"] = "";
                    if (item.Diecisies)
                        xlHoja.Cells[intRow, "W"] = "X";
                    else
                        xlHoja.Cells[intRow, "W"] = "";
                    if (item.Diecisiete)
                        xlHoja.Cells[intRow, "X"] = "X";
                    else
                        xlHoja.Cells[intRow, "X"] = "";

                    xlHoja.Cells[intRow, "Y"] = item.FechaVencimiento;
                    xlHoja.Cells[intRow, "Z"] = item.RecargadoPor;
                    xlHoja.Cells[intRow, "AA"] = item.Observacion;
                    xlHoja.Cells[intRow, "AC"] = item.FechaVencimientoPruebaHidrostatica;

                    intItem++;
                    intRow++;
                }


                string strMensaje = "";
                xlLibro.SaveAs("D:\\Inspeccion Extintores.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                strMensaje = "La Inspeccion de Exintores se exportó correctamente \n Se generó el archivo D:\\Inspeccion Extintores.xlsx";

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