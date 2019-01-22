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

namespace SSOMA.Presentacion.Modulos.Inspeccion.Maestros
{
    public partial class frmManTipoInspeccion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TipoInspeccionBE> mLista = new List<TipoInspeccionBE>();

        #endregion

        #region "Eventos"

        public frmManTipoInspeccion()
        {
            InitializeComponent();
        }

        private void frmManTipoInspeccion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTipoInspeccionEdit objManTipoInspeccion = new frmManTipoInspeccionEdit();
                objManTipoInspeccion.lstTipoInspeccion = mLista;
                objManTipoInspeccion.pOperacion = frmManTipoInspeccionEdit.Operacion.Nuevo;
                objManTipoInspeccion.IdTipoInspeccion = 0;
                objManTipoInspeccion.StartPosition = FormStartPosition.CenterParent;
                objManTipoInspeccion.ShowDialog();
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
                        TipoInspeccionBE objE_TipoInspeccion = new TipoInspeccionBE();
                        objE_TipoInspeccion.IdTipoInspeccion = int.Parse(gvTipoInspeccion.GetFocusedRowCellValue("IdTipoInspeccion").ToString());
                        objE_TipoInspeccion.Usuario = Parametros.strUsuarioLogin;
                        objE_TipoInspeccion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_TipoInspeccion.IdEmpresa = Parametros.intEmpresaId;

                        TipoInspeccionBL objBL_TipoInspeccion = new TipoInspeccionBL();
                        objBL_TipoInspeccion.Elimina(objE_TipoInspeccion);
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

            //    List<ReporteTipoInspeccionElementoBE> lstReporte = null;
            //    lstReporte = new ReporteTipoInspeccionElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptTipoInspeccionElemento = new RptVistaReportes();
            //            objRptTipoInspeccionElemento.VerRptTipoInspeccionElemento(lstReporte);
            //            objRptTipoInspeccionElemento.ShowDialog();
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
            string _fileName = "ListadoTipoInspeccions";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTipoInspeccion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTipoInspeccion_DoubleClick(object sender, EventArgs e)
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
            mLista = new TipoInspeccionBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcTipoInspeccion.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTipoInspeccion.DataSource = mLista.Where(obj =>
                                                   obj.DescTipoInspeccion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTipoInspeccion.RowCount > 0)
            {
                TipoInspeccionBE objTipoInspeccion = new TipoInspeccionBE();
                objTipoInspeccion.IdTipoInspeccion = int.Parse(gvTipoInspeccion.GetFocusedRowCellValue("IdTipoInspeccion").ToString());
                objTipoInspeccion.DescTipoInspeccion = gvTipoInspeccion.GetFocusedRowCellValue("DescTipoInspeccion").ToString();
                objTipoInspeccion.FlagEstado = Convert.ToBoolean(gvTipoInspeccion.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManTipoInspeccionEdit objManTipoInspeccionEdit = new frmManTipoInspeccionEdit();
                objManTipoInspeccionEdit.pOperacion = frmManTipoInspeccionEdit.Operacion.Modificar;
                objManTipoInspeccionEdit.IdTipoInspeccion = objTipoInspeccion.IdTipoInspeccion;
                objManTipoInspeccionEdit.pTipoInspeccionBE = objTipoInspeccion;
                objManTipoInspeccionEdit.StartPosition = FormStartPosition.CenterParent;
                objManTipoInspeccionEdit.ShowDialog();

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

            if (gvTipoInspeccion.GetFocusedRowCellValue("IdTipoInspeccion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una TipoInspeccion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }


        #endregion

    }
}