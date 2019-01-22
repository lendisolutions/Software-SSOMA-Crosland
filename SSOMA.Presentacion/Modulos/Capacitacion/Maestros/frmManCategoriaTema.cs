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
    public partial class frmManCategoriaTema : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CategoriaTemaBE> mLista = new List<CategoriaTemaBE>();

        #endregion

        #region "Eventos"

        public frmManCategoriaTema()
        {
            InitializeComponent();
        }

        private void frmManCategoriaTema_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManCategoriaTemaEdit objManCategoriaTema = new frmManCategoriaTemaEdit();
                objManCategoriaTema.lstCategoriaTema = mLista;
                objManCategoriaTema.pOperacion = frmManCategoriaTemaEdit.Operacion.Nuevo;
                objManCategoriaTema.IdCategoriaTema = 0;
                objManCategoriaTema.StartPosition = FormStartPosition.CenterParent;
                objManCategoriaTema.ShowDialog();
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
                        CategoriaTemaBE objE_CategoriaTema = new CategoriaTemaBE();
                        objE_CategoriaTema.IdCategoriaTema = int.Parse(gvCategoriaTema.GetFocusedRowCellValue("IdCategoriaTema").ToString());
                        objE_CategoriaTema.Usuario = Parametros.strUsuarioLogin;
                        objE_CategoriaTema.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_CategoriaTema.IdEmpresa = Parametros.intEmpresaId;

                        CategoriaTemaBL objBL_CategoriaTema = new CategoriaTemaBL();
                        objBL_CategoriaTema.Elimina(objE_CategoriaTema);
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

            //    List<ReporteCategoriaTemaElementoBE> lstReporte = null;
            //    lstReporte = new ReporteCategoriaTemaElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptCategoriaTemaElemento = new RptVistaReportes();
            //            objRptCategoriaTemaElemento.VerRptCategoriaTemaElemento(lstReporte);
            //            objRptCategoriaTemaElemento.ShowDialog();
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
            string _fileName = "ListadoCategoriaTemas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCategoriaTema.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCategoriaTema_DoubleClick(object sender, EventArgs e)
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
            mLista = new CategoriaTemaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcCategoriaTema.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcCategoriaTema.DataSource = mLista.Where(obj =>
                                                   obj.DescCategoriaTema.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvCategoriaTema.RowCount > 0)
            {
                CategoriaTemaBE objCategoriaTema = new CategoriaTemaBE();
                objCategoriaTema.IdCategoriaTema = int.Parse(gvCategoriaTema.GetFocusedRowCellValue("IdCategoriaTema").ToString());
                objCategoriaTema.DescCategoriaTema = gvCategoriaTema.GetFocusedRowCellValue("DescCategoriaTema").ToString();
                objCategoriaTema.FlagEstado = Convert.ToBoolean(gvCategoriaTema.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManCategoriaTemaEdit objManCategoriaTemaEdit = new frmManCategoriaTemaEdit();
                objManCategoriaTemaEdit.pOperacion = frmManCategoriaTemaEdit.Operacion.Modificar;
                objManCategoriaTemaEdit.IdCategoriaTema = objCategoriaTema.IdCategoriaTema;
                objManCategoriaTemaEdit.pCategoriaTemaBE = objCategoriaTema;
                objManCategoriaTemaEdit.StartPosition = FormStartPosition.CenterParent;
                objManCategoriaTemaEdit.ShowDialog();

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

            if (gvCategoriaTema.GetFocusedRowCellValue("IdCategoriaTema").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una CategoriaTema", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion


    }
}