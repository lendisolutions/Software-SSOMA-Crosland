using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Security.Principal;
using System.Diagnostics;
using DevExpress.XtraEditors;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion.Utils;


namespace SSOMA.Presentacion.Modulos.Documentario.Maestros
{
    public partial class frmManDocumento : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<DocumentoBE> mLista = new List<DocumentoBE>();

        int intIdEmpresa = 0;
        int intIdCarpeta = 0;

        #endregion

        #region "Eventos"

        public frmManDocumento()
        {
            InitializeComponent();
        }

        private void frmManDocumento_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargaTreeview();
        }

        private void tlbMenu_NewClick()
        {
            try
            {

                if (intIdCarpeta == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar una carpeta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                frmManDocumentoEdit objManDocumento = new frmManDocumentoEdit();
                objManDocumento.lstDocumento = mLista;
                objManDocumento.pOperacion = frmManDocumentoEdit.Operacion.Nuevo;
                objManDocumento.IdCarpeta = intIdCarpeta;
                objManDocumento.IdDocumento = 0;
                objManDocumento.StartPosition = FormStartPosition.CenterParent;
                objManDocumento.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_EditClick()
        {
            if (gvDocumento.RowCount > 0)
            {
                int intIdDocumento = int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumento").ToString());

                frmManDocumentoEdit objManDocumentoEdit = new frmManDocumentoEdit();
                objManDocumentoEdit.pOperacion = frmManDocumentoEdit.Operacion.Modificar;
                objManDocumentoEdit.IdDocumento = intIdDocumento;
                objManDocumentoEdit.StartPosition = FormStartPosition.CenterParent;
                objManDocumentoEdit.ShowDialog();

                Cargar();
            }
         
            
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
                        DocumentoBE objE_Documento = new DocumentoBE();
                        objE_Documento.IdDocumento = int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumento").ToString());
                        objE_Documento.Usuario = Parametros.strUsuarioLogin;
                        objE_Documento.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Documento.IdEmpresa = Parametros.intEmpresaId;

                        DocumentoBL objBL_Area = new DocumentoBL();
                        objBL_Area.Elimina(objE_Documento);
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
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    List<ReporteDocumentoBE> lstReporte = null;
            //    lstReporte = new ReporteDocumentoBL().Listado(Parametros.intEmpresaId, Parametros.intCarpetaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptDocumento = new RptVistaReportes();
            //            objRptDocumento.VerRptDocumento(lstReporte);
            //            objRptDocumento.ShowDialog();
            //        }
            //        else
            //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_ExportClick()
        {
            ExportarPlanillaExcel("");
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvDocumento_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "EMP":
                    intIdCarpeta = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Cargar();
                    break;

            }
        }

        #endregion

        #region "Metodos"

        private void CargaTreeview()
        {
            tvwDatos.Nodes.Clear();

            TreeNode nuevoNodo = new TreeNode();
            nuevoNodo.Text = "SISTEMA DE GESTIÓN SSOMA";
            nuevoNodo.ImageIndex = 0;
            nuevoNodo.SelectedImageIndex = 0;
            tvwDatos.Nodes.Add(nuevoNodo);

            List<CarpetaBE> lstCarpeta = null;
            lstCarpeta = new CarpetaBL().ListaCombo(0);
            foreach (var item in lstCarpeta)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 1;
                nuevoNodoChild.SelectedImageIndex = 1;
                nuevoNodoChild.Text = item.DescCarpeta;
                nuevoNodoChild.Tag = "EMP" + item.IdCarpeta.ToString();
                nuevoNodo.Nodes.Add(nuevoNodoChild);
            }

            tvwDatos.ExpandAll();
        }


        private void Cargar()
        {
            mLista = new DocumentoBL().ListaTodosActivo(intIdEmpresa, intIdCarpeta);
            gcDocumento.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcDocumento.DataSource = mLista.Where(obj =>
                                                   obj.NombreArchivo.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvDocumento.RowCount > 0)
            {
                int intIdDocumento = int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumento").ToString());
                DocumentoBE objSSOMA = null;
                objSSOMA = new DocumentoBL().Selecciona(intIdDocumento);
                if (objSSOMA != null)
                {
                    string sFilePath = "";
                    byte[] Buffer;

                    Buffer = objSSOMA.Archivo;

                    sFilePath = Path.GetTempFileName();
                    File.Move(sFilePath, Path.ChangeExtension(sFilePath, ".pdf"));
                    sFilePath = Path.ChangeExtension(sFilePath, ".pdf");
                    File.WriteAllBytes(sFilePath, Buffer);

                    ProcessStartInfo start = new ProcessStartInfo();
                    //start.UseShellExecute = false;
                    // Enter in the command line arguments, everything you would enter after the executable name itself
                    start.Arguments = sFilePath + " 1";
                    // Enter the executable to run, including the complete path
                    start.FileName = Path.Combine(Directory.GetCurrentDirectory(), "Pdf\\PdfiumViewer.Demo.exe");
                    // Do you want to show a console window?
                    start.WindowStyle = ProcessWindowStyle.Hidden;
                    start.CreateNoWindow = true;
                    int exitCode;

                    // Run the external process & wait for it to finish
                    using (Process proc = Process.Start(start))
                    {
                        proc.WaitForExit();

                        // Retrieve the app's exit code
                        exitCode = proc.ExitCode;
                    }

                }




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

            if (gvDocumento.GetFocusedRowCellValue("IdDocumento").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Area", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Listado Maestro Documentos.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<DocumentoBE> lstDocumento = null;
                lstDocumento = new DocumentoBL().ListaTodosActivo(0, 0);

                if (lstDocumento.Count > 0)
                {
                    foreach (var item in lstDocumento)
                    {
                        xlHoja.Cells[Row, 1] = item.DescCarpeta;
                        xlHoja.Cells[Row, 2] = item.Codigo;
                        xlHoja.Cells[Row, 3] = item.NombreArchivo;
                        xlHoja.Cells[Row, 6] = item.Revision;
                        xlHoja.Cells[Row, 7] = item.FechaAprobacion;
                        if (item.FlagContabilidad)
                        {
                            xlHoja.Cells[Row, 8] = "X";
                        }
                        if (item.FlagSistemas)
                        {
                            xlHoja.Cells[Row, 8] = "X";
                        }
                        if (item.FlagLegal)
                        {
                            xlHoja.Cells[Row, 10] = "X";
                        }
                        if (item.FlagTesoreria)
                        {
                            xlHoja.Cells[Row, 11] = "X";
                        }
                        if (item.FlagAtraccion)
                        {
                            xlHoja.Cells[Row, 12] = "X";
                        }
                        if (item.FlagAdministracion)
                        {
                            xlHoja.Cells[Row, 13] = "X";
                        }
                        if (item.FlagComercial)
                        {
                            xlHoja.Cells[Row, 14] = "X";
                        }
                        if (item.FlagDesarrolloNegocio)
                        {
                            xlHoja.Cells[Row, 15] = "X";
                        }
                        if (item.FlagControlGestion)
                        {
                            xlHoja.Cells[Row, 16] = "X";
                        }
                        if (item.FlagAlmacen)
                        {
                            xlHoja.Cells[Row, 17] = "X";
                        }
                        if (item.FlagDespacho)
                        {
                            xlHoja.Cells[Row, 18] = "X";
                        }
                        if (item.FlagGerenciaGeneral)
                        {
                            xlHoja.Cells[Row, 19] = "X";
                        }
                        if (item.FlagMarketing)
                        {
                            xlHoja.Cells[Row, 20] = "X";
                        }
                        if (item.FlagOperacion)
                        {
                            xlHoja.Cells[Row, 21] = "X";
                        }
                        if (item.FlagProyecto)
                        {
                            xlHoja.Cells[Row, 22] = "X";
                        }
                        if (item.FlagServicioGeneral)
                        {
                            xlHoja.Cells[Row, 23] = "X";
                        }
                        if (item.FlagPlaneamiento)
                        {
                            xlHoja.Cells[Row, 24] = "X";
                        }
                        if (item.FlagCompensacion)
                        {
                            xlHoja.Cells[Row, 25] = "X";
                        }
                        if (item.FlagBienestar)
                        {
                            xlHoja.Cells[Row, 26] = "X";
                        }
                        if (item.FlagAlquiler)
                        {
                            xlHoja.Cells[Row, 27] = "X";
                        }


                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("D:\\Listado Maestro Documentos.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show("La Lista Maestra de Documentos se exportó correctamente \n Se generó el archivo D:\\Listado Maestro Documentos.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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