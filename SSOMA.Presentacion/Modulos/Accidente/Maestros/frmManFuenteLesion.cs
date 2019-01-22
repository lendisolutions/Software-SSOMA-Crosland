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
    public partial class frmManFuenteLesion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<FuenteLesionBE> mLista = new List<FuenteLesionBE>();

        #endregion

        #region "Eventos"

        public frmManFuenteLesion()
        {
            InitializeComponent();
        }

        private void frmManFuenteLesion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManFuenteLesionEdit objManFuenteLesion = new frmManFuenteLesionEdit();
                objManFuenteLesion.lstFuenteLesion = mLista;
                objManFuenteLesion.pOperacion = frmManFuenteLesionEdit.Operacion.Nuevo;
                objManFuenteLesion.IdFuenteLesion = 0;
                objManFuenteLesion.StartPosition = FormStartPosition.CenterParent;
                objManFuenteLesion.ShowDialog();
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
                        FuenteLesionBE objE_FuenteLesion = new FuenteLesionBE();
                        objE_FuenteLesion.IdFuenteLesion = int.Parse(gvFuenteLesion.GetFocusedRowCellValue("IdFuenteLesion").ToString());
                        objE_FuenteLesion.Usuario = Parametros.strUsuarioLogin;
                        objE_FuenteLesion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_FuenteLesion.IdEmpresa = Parametros.intEmpresaId;

                        FuenteLesionBL objBL_FuenteLesion = new FuenteLesionBL();
                        objBL_FuenteLesion.Elimina(objE_FuenteLesion);
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

            //    List<ReporteFuenteLesionElementoBE> lstReporte = null;
            //    lstReporte = new ReporteFuenteLesionElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptFuenteLesionElemento = new RptVistaReportes();
            //            objRptFuenteLesionElemento.VerRptFuenteLesionElemento(lstReporte);
            //            objRptFuenteLesionElemento.ShowDialog();
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
            string _fileName = "ListadoFuenteLesions";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvFuenteLesion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvFuenteLesion_DoubleClick(object sender, EventArgs e)
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
            mLista = new FuenteLesionBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcFuenteLesion.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcFuenteLesion.DataSource = mLista.Where(obj =>
                                                   obj.DescFuenteLesion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvFuenteLesion.RowCount > 0)
            {
                FuenteLesionBE objFuenteLesion = new FuenteLesionBE();
                objFuenteLesion.IdFuenteLesion = int.Parse(gvFuenteLesion.GetFocusedRowCellValue("IdFuenteLesion").ToString());
                objFuenteLesion.DescFuenteLesion = gvFuenteLesion.GetFocusedRowCellValue("DescFuenteLesion").ToString();
                objFuenteLesion.FlagEstado = Convert.ToBoolean(gvFuenteLesion.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManFuenteLesionEdit objManFuenteLesionEdit = new frmManFuenteLesionEdit();
                objManFuenteLesionEdit.pOperacion = frmManFuenteLesionEdit.Operacion.Modificar;
                objManFuenteLesionEdit.IdFuenteLesion = objFuenteLesion.IdFuenteLesion;
                objManFuenteLesionEdit.pFuenteLesionBE = objFuenteLesion;
                objManFuenteLesionEdit.StartPosition = FormStartPosition.CenterParent;
                objManFuenteLesionEdit.ShowDialog();

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

            if (gvFuenteLesion.GetFocusedRowCellValue("IdFuenteLesion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una FuenteLesion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}