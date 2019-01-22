using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Capacitacion.Maestros
{
    public partial class frmManExpositor : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ExpositorBE> mLista = new List<ExpositorBE>();
        
        #endregion

        #region "Eventos"

        public frmManExpositor()
        {
            InitializeComponent();
        }

        private void frmManExpositor_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManExpositorEdit objManExpositor = new frmManExpositorEdit();
                objManExpositor.lstExpositor = mLista;
                objManExpositor.pOperacion = frmManExpositorEdit.Operacion.Nuevo;
                objManExpositor.IdExpositor = 0;
                objManExpositor.StartPosition = FormStartPosition.CenterParent;
                objManExpositor.ShowDialog();
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
                        ExpositorBE objE_Expositor = new ExpositorBE();
                        objE_Expositor.IdExpositor = int.Parse(gvExpositor.GetFocusedRowCellValue("IdExpositor").ToString());
                        objE_Expositor.Usuario = Parametros.strUsuarioLogin;
                        objE_Expositor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Expositor.IdEmpresa = Parametros.intEmpresaId;

                        ExpositorBL objBL_Expositor = new ExpositorBL();
                        objBL_Expositor.Elimina(objE_Expositor);
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

            //    List<ReporteExpositorElementoBE> lstReporte = null;
            //    lstReporte = new ReporteExpositorElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptExpositorElemento = new RptVistaReportes();
            //            objRptExpositorElemento.VerRptExpositorElemento(lstReporte);
            //            objRptExpositorElemento.ShowDialog();
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
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoExpositors";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvExpositor.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvExpositor_DoubleClick(object sender, EventArgs e)
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

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ExpositorBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcExpositor.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcExpositor.DataSource = mLista.Where(obj =>
                                                   obj.DescExpositor.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvExpositor.RowCount > 0)
            {
                ExpositorBE objExpositor = new ExpositorBE();
                objExpositor.IdExpositor = int.Parse(gvExpositor.GetFocusedRowCellValue("IdExpositor").ToString());
                objExpositor.DescEmpresa = gvExpositor.GetFocusedRowCellValue("DescEmpresa").ToString();
                objExpositor.DescExpositor = gvExpositor.GetFocusedRowCellValue("DescExpositor").ToString();
                objExpositor.Cargo = gvExpositor.GetFocusedRowCellValue("Cargo").ToString();
                objExpositor.FlagEstado = Convert.ToBoolean(gvExpositor.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManExpositorEdit objManExpositorEdit = new frmManExpositorEdit();
                objManExpositorEdit.pOperacion = frmManExpositorEdit.Operacion.Modificar;
                objManExpositorEdit.IdExpositor = objExpositor.IdExpositor;
                objManExpositorEdit.pExpositorBE = objExpositor;
                objManExpositorEdit.StartPosition = FormStartPosition.CenterParent;
                objManExpositorEdit.ShowDialog();

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

            if (gvExpositor.GetFocusedRowCellValue("IdExpositor").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Expositor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
        
    }
}