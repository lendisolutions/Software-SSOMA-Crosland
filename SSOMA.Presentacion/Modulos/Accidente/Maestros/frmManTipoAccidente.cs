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
    public partial class frmManTipoAccidente : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TipoAccidenteBE> mLista = new List<TipoAccidenteBE>();

        #endregion

        #region "Eventos"

        public frmManTipoAccidente()
        {
            InitializeComponent();
        }

        private void frmManTipoAccidente_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTipoAccidenteEdit objManTipoAccidente = new frmManTipoAccidenteEdit();
                objManTipoAccidente.lstTipoAccidente = mLista;
                objManTipoAccidente.pOperacion = frmManTipoAccidenteEdit.Operacion.Nuevo;
                objManTipoAccidente.IdTipoAccidente = 0;
                objManTipoAccidente.StartPosition = FormStartPosition.CenterParent;
                objManTipoAccidente.ShowDialog();
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
                        TipoAccidenteBE objE_TipoAccidente = new TipoAccidenteBE();
                        objE_TipoAccidente.IdTipoAccidente = int.Parse(gvTipoAccidente.GetFocusedRowCellValue("IdTipoAccidente").ToString());
                        objE_TipoAccidente.Usuario = Parametros.strUsuarioLogin;
                        objE_TipoAccidente.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_TipoAccidente.IdEmpresa = Parametros.intEmpresaId;

                        TipoAccidenteBL objBL_TipoAccidente = new TipoAccidenteBL();
                        objBL_TipoAccidente.Elimina(objE_TipoAccidente);
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

            //    List<ReporteTipoAccidenteElementoBE> lstReporte = null;
            //    lstReporte = new ReporteTipoAccidenteElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptTipoAccidenteElemento = new RptVistaReportes();
            //            objRptTipoAccidenteElemento.VerRptTipoAccidenteElemento(lstReporte);
            //            objRptTipoAccidenteElemento.ShowDialog();
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
            string _fileName = "ListadoTipoAccidentes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTipoAccidente.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTipoAccidente_DoubleClick(object sender, EventArgs e)
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
            mLista = new TipoAccidenteBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcTipoAccidente.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTipoAccidente.DataSource = mLista.Where(obj =>
                                                   obj.DescTipoAccidente.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTipoAccidente.RowCount > 0)
            {
                TipoAccidenteBE objTipoAccidente = new TipoAccidenteBE();
                objTipoAccidente.IdTipoAccidente = int.Parse(gvTipoAccidente.GetFocusedRowCellValue("IdTipoAccidente").ToString());
                objTipoAccidente.DescTipoAccidente = gvTipoAccidente.GetFocusedRowCellValue("DescTipoAccidente").ToString();
                objTipoAccidente.FlagEstado = Convert.ToBoolean(gvTipoAccidente.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManTipoAccidenteEdit objManTipoAccidenteEdit = new frmManTipoAccidenteEdit();
                objManTipoAccidenteEdit.pOperacion = frmManTipoAccidenteEdit.Operacion.Modificar;
                objManTipoAccidenteEdit.IdTipoAccidente = objTipoAccidente.IdTipoAccidente;
                objManTipoAccidenteEdit.pTipoAccidenteBE = objTipoAccidente;
                objManTipoAccidenteEdit.StartPosition = FormStartPosition.CenterParent;
                objManTipoAccidenteEdit.ShowDialog();

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

            if (gvTipoAccidente.GetFocusedRowCellValue("IdTipoAccidente").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una TipoAccidente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}