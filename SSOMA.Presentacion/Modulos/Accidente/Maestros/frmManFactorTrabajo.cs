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

namespace SSOMA.Presentacion.Modulos.Accidente.Maestros
{
    public partial class frmManFactorTrabajo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<FactorTrabajoBE> mLista = new List<FactorTrabajoBE>();

        #endregion

        #region "Eventos"

        public frmManFactorTrabajo()
        {
            InitializeComponent();
        }

        private void frmManFactorTrabajo_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManFactorTrabajoEdit objManFactorTrabajo = new frmManFactorTrabajoEdit();
                objManFactorTrabajo.lstFactorTrabajo = mLista;
                objManFactorTrabajo.pOperacion = frmManFactorTrabajoEdit.Operacion.Nuevo;
                objManFactorTrabajo.IdFactorTrabajo = 0;
                objManFactorTrabajo.StartPosition = FormStartPosition.CenterParent;
                objManFactorTrabajo.ShowDialog();
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
                        FactorTrabajoBE objE_FactorTrabajo = new FactorTrabajoBE();
                        objE_FactorTrabajo.IdFactorTrabajo = int.Parse(gvFactorTrabajo.GetFocusedRowCellValue("IdFactorTrabajo").ToString());
                        objE_FactorTrabajo.Usuario = Parametros.strUsuarioLogin;
                        objE_FactorTrabajo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_FactorTrabajo.IdEmpresa = Parametros.intEmpresaId;

                        FactorTrabajoBL objBL_FactorTrabajo = new FactorTrabajoBL();
                        objBL_FactorTrabajo.Elimina(objE_FactorTrabajo);
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

            //    List<ReporteFactorTrabajoElementoBE> lstReporte = null;
            //    lstReporte = new ReporteFactorTrabajoElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptFactorTrabajoElemento = new RptVistaReportes();
            //            objRptFactorTrabajoElemento.VerRptFactorTrabajoElemento(lstReporte);
            //            objRptFactorTrabajoElemento.ShowDialog();
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
            string _fileName = "ListadoFactorTrabajos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvFactorTrabajo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvFactorTrabajo_DoubleClick(object sender, EventArgs e)
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
            mLista = new FactorTrabajoBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcFactorTrabajo.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcFactorTrabajo.DataSource = mLista.Where(obj =>
                                                   obj.DescFactorTrabajo.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvFactorTrabajo.RowCount > 0)
            {
                FactorTrabajoBE objFactorTrabajo = new FactorTrabajoBE();
                objFactorTrabajo.IdFactorTrabajo = int.Parse(gvFactorTrabajo.GetFocusedRowCellValue("IdFactorTrabajo").ToString());
                objFactorTrabajo.DescFactorTrabajo = gvFactorTrabajo.GetFocusedRowCellValue("DescFactorTrabajo").ToString();
                objFactorTrabajo.FlagEstado = Convert.ToBoolean(gvFactorTrabajo.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManFactorTrabajoEdit objManFactorTrabajoEdit = new frmManFactorTrabajoEdit();
                objManFactorTrabajoEdit.pOperacion = frmManFactorTrabajoEdit.Operacion.Modificar;
                objManFactorTrabajoEdit.IdFactorTrabajo = objFactorTrabajo.IdFactorTrabajo;
                objManFactorTrabajoEdit.pFactorTrabajoBE = objFactorTrabajo;
                objManFactorTrabajoEdit.StartPosition = FormStartPosition.CenterParent;
                objManFactorTrabajoEdit.ShowDialog();

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

            if (gvFactorTrabajo.GetFocusedRowCellValue("IdFactorTrabajo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una FactorTrabajo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}