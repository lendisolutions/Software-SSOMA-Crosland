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
using DevExpress.XtraGrid.Columns;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Iperc.Maestros
{
    public partial class frmManSeveridad : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SeveridadBE> mLista = new List<SeveridadBE>();

        #endregion

        #region "Eventos"

        public frmManSeveridad()
        {
            InitializeComponent();
        }

        private void frmManSeveridad_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManSeveridadEdit objManSeveridad = new frmManSeveridadEdit();
                objManSeveridad.lstSeveridad = mLista;
                objManSeveridad.pOperacion = frmManSeveridadEdit.Operacion.Nuevo;
                objManSeveridad.IdSeveridad = 0;
                objManSeveridad.StartPosition = FormStartPosition.CenterParent;
                objManSeveridad.ShowDialog();
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
                        SeveridadBE objE_Severidad = new SeveridadBE();
                        objE_Severidad.IdSeveridad = int.Parse(gvSeveridad.GetFocusedRowCellValue("IdSeveridad").ToString());
                        objE_Severidad.Usuario = Parametros.strUsuarioLogin;
                        objE_Severidad.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Severidad.IdEmpresa = Parametros.intEmpresaId;

                        SeveridadBL objBL_Severidad = new SeveridadBL();
                        objBL_Severidad.Elimina(objE_Severidad);
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

            //    List<ReporteSeveridadElementoBE> lstReporte = null;
            //    lstReporte = new ReporteSeveridadElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptSeveridadElemento = new RptVistaReportes();
            //            objRptSeveridadElemento.VerRptSeveridadElemento(lstReporte);
            //            objRptSeveridadElemento.ShowDialog();
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
            string _fileName = "ListadoSeveridads";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvSeveridad.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvSeveridad_DoubleClick(object sender, EventArgs e)
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
            mLista = new SeveridadBL().ListaTodosActivo(0);
            gcSeveridad.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcSeveridad.DataSource = mLista.Where(obj =>
                                                   obj.DescSeveridad.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvSeveridad.RowCount > 0)
            {
                SeveridadBE objSeveridad = new SeveridadBE();
                objSeveridad.IdSeveridad = int.Parse(gvSeveridad.GetFocusedRowCellValue("IdSeveridad").ToString());

                frmManSeveridadEdit objManSeveridadEdit = new frmManSeveridadEdit();
                objManSeveridadEdit.pOperacion = frmManSeveridadEdit.Operacion.Modificar;
                objManSeveridadEdit.IdSeveridad = objSeveridad.IdSeveridad;
                objManSeveridadEdit.pSeveridadBE = objSeveridad;
                objManSeveridadEdit.StartPosition = FormStartPosition.CenterParent;
                objManSeveridadEdit.ShowDialog();

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

            if (gvSeveridad.GetFocusedRowCellValue("IdSeveridad").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Severidad", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}