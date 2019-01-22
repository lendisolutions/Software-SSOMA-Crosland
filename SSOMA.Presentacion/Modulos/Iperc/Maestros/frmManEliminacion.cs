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
    public partial class frmManEliminacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EliminacionBE> mLista = new List<EliminacionBE>();

        #endregion

        #region "Eventos"

        public frmManEliminacion()
        {
            InitializeComponent();
        }

        private void frmManEliminacion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManEliminacionEdit objManEliminacion = new frmManEliminacionEdit();
                objManEliminacion.lstEliminacion = mLista;
                objManEliminacion.pOperacion = frmManEliminacionEdit.Operacion.Nuevo;
                objManEliminacion.IdEliminacion = 0;
                objManEliminacion.StartPosition = FormStartPosition.CenterParent;
                objManEliminacion.ShowDialog();
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
                        EliminacionBE objE_Eliminacion = new EliminacionBE();
                        objE_Eliminacion.IdEliminacion = int.Parse(gvEliminacion.GetFocusedRowCellValue("IdEliminacion").ToString());
                        objE_Eliminacion.Usuario = Parametros.strUsuarioLogin;
                        objE_Eliminacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Eliminacion.IdEmpresa = Parametros.intEmpresaId;

                        EliminacionBL objBL_Eliminacion = new EliminacionBL();
                        objBL_Eliminacion.Elimina(objE_Eliminacion);
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

            //    List<ReporteEliminacionElementoBE> lstReporte = null;
            //    lstReporte = new ReporteEliminacionElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptEliminacionElemento = new RptVistaReportes();
            //            objRptEliminacionElemento.VerRptEliminacionElemento(lstReporte);
            //            objRptEliminacionElemento.ShowDialog();
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
            string _fileName = "ListadoEliminacions";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvEliminacion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvEliminacion_DoubleClick(object sender, EventArgs e)
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
            mLista = new EliminacionBL().ListaTodosActivo(0);
            gcEliminacion.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcEliminacion.DataSource = mLista.Where(obj =>
                                                   obj.DescEliminacion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvEliminacion.RowCount > 0)
            {
                EliminacionBE objEliminacion = new EliminacionBE();
                objEliminacion.IdEliminacion = int.Parse(gvEliminacion.GetFocusedRowCellValue("IdEliminacion").ToString());
                objEliminacion.DescEliminacion = gvEliminacion.GetFocusedRowCellValue("DescEliminacion").ToString();
                objEliminacion.FlagEstado = Convert.ToBoolean(gvEliminacion.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManEliminacionEdit objManEliminacionEdit = new frmManEliminacionEdit();
                objManEliminacionEdit.pOperacion = frmManEliminacionEdit.Operacion.Modificar;
                objManEliminacionEdit.IdEliminacion = objEliminacion.IdEliminacion;
                objManEliminacionEdit.pEliminacionBE = objEliminacion;
                objManEliminacionEdit.StartPosition = FormStartPosition.CenterParent;
                objManEliminacionEdit.ShowDialog();

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

            if (gvEliminacion.GetFocusedRowCellValue("IdEliminacion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Eliminacion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}