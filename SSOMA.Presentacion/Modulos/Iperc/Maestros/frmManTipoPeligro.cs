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

namespace SSOMA.Presentacion.Modulos.Iperc.Maestros
{
    public partial class frmManTipoPeligro : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TipoPeligroBE> mLista = new List<TipoPeligroBE>();

        #endregion

        #region "Eventos"

        public frmManTipoPeligro()
        {
            InitializeComponent();
        }

        private void frmManTipoPeligro_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTipoPeligroEdit objManTipoPeligro = new frmManTipoPeligroEdit();
                objManTipoPeligro.lstTipoPeligro = mLista;
                objManTipoPeligro.pOperacion = frmManTipoPeligroEdit.Operacion.Nuevo;
                objManTipoPeligro.IdTipoPeligro = 0;
                objManTipoPeligro.StartPosition = FormStartPosition.CenterParent;
                objManTipoPeligro.ShowDialog();
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
                        TipoPeligroBE objE_TipoPeligro = new TipoPeligroBE();
                        objE_TipoPeligro.IdTipoPeligro = int.Parse(gvTipoPeligro.GetFocusedRowCellValue("IdTipoPeligro").ToString());
                        objE_TipoPeligro.Usuario = Parametros.strUsuarioLogin;
                        objE_TipoPeligro.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_TipoPeligro.IdEmpresa = Parametros.intEmpresaId;

                        TipoPeligroBL objBL_TipoPeligro = new TipoPeligroBL();
                        objBL_TipoPeligro.Elimina(objE_TipoPeligro);
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

            //    List<ReporteTipoPeligroElementoBE> lstReporte = null;
            //    lstReporte = new ReporteTipoPeligroElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptTipoPeligroElemento = new RptVistaReportes();
            //            objRptTipoPeligroElemento.VerRptTipoPeligroElemento(lstReporte);
            //            objRptTipoPeligroElemento.ShowDialog();
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
            string _fileName = "ListadoTipoPeligros";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTipoPeligro.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTipoPeligro_DoubleClick(object sender, EventArgs e)
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
            mLista = new TipoPeligroBL().ListaTodosActivo(0);
            gcTipoPeligro.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTipoPeligro.DataSource = mLista.Where(obj =>
                                                   obj.DescTipoPeligro.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTipoPeligro.RowCount > 0)
            {
                TipoPeligroBE objTipoPeligro = new TipoPeligroBE();
                objTipoPeligro.IdTipoPeligro = int.Parse(gvTipoPeligro.GetFocusedRowCellValue("IdTipoPeligro").ToString());
                objTipoPeligro.DescTipoPeligro = gvTipoPeligro.GetFocusedRowCellValue("DescTipoPeligro").ToString();
                objTipoPeligro.FlagEstado = Convert.ToBoolean(gvTipoPeligro.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManTipoPeligroEdit objManTipoPeligroEdit = new frmManTipoPeligroEdit();
                objManTipoPeligroEdit.pOperacion = frmManTipoPeligroEdit.Operacion.Modificar;
                objManTipoPeligroEdit.IdTipoPeligro = objTipoPeligro.IdTipoPeligro;
                objManTipoPeligroEdit.pTipoPeligroBE = objTipoPeligro;
                objManTipoPeligroEdit.StartPosition = FormStartPosition.CenterParent;
                objManTipoPeligroEdit.ShowDialog();

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

            if (gvTipoPeligro.GetFocusedRowCellValue("IdTipoPeligro").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una TipoPeligro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}