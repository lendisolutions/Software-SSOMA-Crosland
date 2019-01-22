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
    public partial class frmManTipoCapacitacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TipoCapacitacionBE> mLista = new List<TipoCapacitacionBE>();
        
        #endregion

        #region "Eventos"

        public frmManTipoCapacitacion()
        {
            InitializeComponent();
        }

        private void frmManTipoCapacitacion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTipoCapacitacionEdit objManTipoCapacitacion = new frmManTipoCapacitacionEdit();
                objManTipoCapacitacion.lstTipoCapacitacion = mLista;
                objManTipoCapacitacion.pOperacion = frmManTipoCapacitacionEdit.Operacion.Nuevo;
                objManTipoCapacitacion.IdTipoCapacitacion = 0;
                objManTipoCapacitacion.StartPosition = FormStartPosition.CenterParent;
                objManTipoCapacitacion.ShowDialog();
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
                        TipoCapacitacionBE objE_TipoCapacitacion = new TipoCapacitacionBE();
                        objE_TipoCapacitacion.IdTipoCapacitacion = int.Parse(gvTipoCapacitacion.GetFocusedRowCellValue("IdTipoCapacitacion").ToString());
                        objE_TipoCapacitacion.Usuario = Parametros.strUsuarioLogin;
                        objE_TipoCapacitacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_TipoCapacitacion.IdEmpresa = Parametros.intEmpresaId;

                        TipoCapacitacionBL objBL_TipoCapacitacion = new TipoCapacitacionBL();
                        objBL_TipoCapacitacion.Elimina(objE_TipoCapacitacion);
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

            //    List<ReporteTipoCapacitacionElementoBE> lstReporte = null;
            //    lstReporte = new ReporteTipoCapacitacionElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptTipoCapacitacionElemento = new RptVistaReportes();
            //            objRptTipoCapacitacionElemento.VerRptTipoCapacitacionElemento(lstReporte);
            //            objRptTipoCapacitacionElemento.ShowDialog();
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
            string _fileName = "ListadoTipoCapacitacions";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTipoCapacitacion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTipoCapacitacion_DoubleClick(object sender, EventArgs e)
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
            mLista = new TipoCapacitacionBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcTipoCapacitacion.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTipoCapacitacion.DataSource = mLista.Where(obj =>
                                                   obj.DescTipoCapacitacion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTipoCapacitacion.RowCount > 0)
            {
                TipoCapacitacionBE objTipoCapacitacion = new TipoCapacitacionBE();
                objTipoCapacitacion.IdTipoCapacitacion = int.Parse(gvTipoCapacitacion.GetFocusedRowCellValue("IdTipoCapacitacion").ToString());
                objTipoCapacitacion.DescTipoCapacitacion = gvTipoCapacitacion.GetFocusedRowCellValue("DescTipoCapacitacion").ToString();
                objTipoCapacitacion.FlagEstado = Convert.ToBoolean(gvTipoCapacitacion.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManTipoCapacitacionEdit objManTipoCapacitacionEdit = new frmManTipoCapacitacionEdit();
                objManTipoCapacitacionEdit.pOperacion = frmManTipoCapacitacionEdit.Operacion.Modificar;
                objManTipoCapacitacionEdit.IdTipoCapacitacion = objTipoCapacitacion.IdTipoCapacitacion;
                objManTipoCapacitacionEdit.pTipoCapacitacionBE = objTipoCapacitacion;
                objManTipoCapacitacionEdit.StartPosition = FormStartPosition.CenterParent;
                objManTipoCapacitacionEdit.ShowDialog();

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

            if (gvTipoCapacitacion.GetFocusedRowCellValue("IdTipoCapacitacion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una TipoCapacitacion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
        
    }
}