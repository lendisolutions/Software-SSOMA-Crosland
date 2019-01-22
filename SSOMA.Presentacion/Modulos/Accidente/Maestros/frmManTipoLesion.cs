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
    public partial class frmManTipoLesion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TipoLesionBE> mLista = new List<TipoLesionBE>();

        #endregion

        #region "Eventos"

        public frmManTipoLesion()
        {
            InitializeComponent();
        }

        private void frmManTipoLesion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTipoLesionEdit objManTipoLesion = new frmManTipoLesionEdit();
                objManTipoLesion.lstTipoLesion = mLista;
                objManTipoLesion.pOperacion = frmManTipoLesionEdit.Operacion.Nuevo;
                objManTipoLesion.IdTipoLesion = 0;
                objManTipoLesion.StartPosition = FormStartPosition.CenterParent;
                objManTipoLesion.ShowDialog();
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
                        TipoLesionBE objE_TipoLesion = new TipoLesionBE();
                        objE_TipoLesion.IdTipoLesion = int.Parse(gvTipoLesion.GetFocusedRowCellValue("IdTipoLesion").ToString());
                        objE_TipoLesion.Usuario = Parametros.strUsuarioLogin;
                        objE_TipoLesion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_TipoLesion.IdEmpresa = Parametros.intEmpresaId;

                        TipoLesionBL objBL_TipoLesion = new TipoLesionBL();
                        objBL_TipoLesion.Elimina(objE_TipoLesion);
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

            //    List<ReporteTipoLesionElementoBE> lstReporte = null;
            //    lstReporte = new ReporteTipoLesionElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptTipoLesionElemento = new RptVistaReportes();
            //            objRptTipoLesionElemento.VerRptTipoLesionElemento(lstReporte);
            //            objRptTipoLesionElemento.ShowDialog();
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
            string _fileName = "ListadoTipoLesions";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTipoLesion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTipoLesion_DoubleClick(object sender, EventArgs e)
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
            mLista = new TipoLesionBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcTipoLesion.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTipoLesion.DataSource = mLista.Where(obj =>
                                                   obj.DescTipoLesion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTipoLesion.RowCount > 0)
            {
                TipoLesionBE objTipoLesion = new TipoLesionBE();
                objTipoLesion.IdTipoLesion = int.Parse(gvTipoLesion.GetFocusedRowCellValue("IdTipoLesion").ToString());
                objTipoLesion.DescTipoLesion = gvTipoLesion.GetFocusedRowCellValue("DescTipoLesion").ToString();
                objTipoLesion.FlagEstado = Convert.ToBoolean(gvTipoLesion.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManTipoLesionEdit objManTipoLesionEdit = new frmManTipoLesionEdit();
                objManTipoLesionEdit.pOperacion = frmManTipoLesionEdit.Operacion.Modificar;
                objManTipoLesionEdit.IdTipoLesion = objTipoLesion.IdTipoLesion;
                objManTipoLesionEdit.pTipoLesionBE = objTipoLesion;
                objManTipoLesionEdit.StartPosition = FormStartPosition.CenterParent;
                objManTipoLesionEdit.ShowDialog();

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

            if (gvTipoLesion.GetFocusedRowCellValue("IdTipoLesion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una TipoLesion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}