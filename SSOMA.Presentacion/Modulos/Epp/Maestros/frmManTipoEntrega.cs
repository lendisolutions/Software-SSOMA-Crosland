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

namespace SSOMA.Presentacion.Modulos.Epp.Maestros
{
    public partial class frmManTipoEntrega : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TipoEntregaBE> mLista = new List<TipoEntregaBE>();
        
        #endregion

        #region "Eventos"

        public frmManTipoEntrega()
        {
            InitializeComponent();
        }

        private void frmManTipoEntrega_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTipoEntregaEdit objManTipoEntrega = new frmManTipoEntregaEdit();
                objManTipoEntrega.lstTipoEntrega = mLista;
                objManTipoEntrega.pOperacion = frmManTipoEntregaEdit.Operacion.Nuevo;
                objManTipoEntrega.IdTipoEntrega = 0;
                objManTipoEntrega.StartPosition = FormStartPosition.CenterParent;
                objManTipoEntrega.ShowDialog();
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
                        TipoEntregaBE objE_TipoEntrega = new TipoEntregaBE();
                        objE_TipoEntrega.IdTipoEntrega = int.Parse(gvTipoEntrega.GetFocusedRowCellValue("IdTipoEntrega").ToString());
                        objE_TipoEntrega.Usuario = Parametros.strUsuarioLogin;
                        objE_TipoEntrega.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_TipoEntrega.IdEmpresa = Parametros.intEmpresaId;

                        TipoEntregaBL objBL_TipoEntrega = new TipoEntregaBL();
                        objBL_TipoEntrega.Elimina(objE_TipoEntrega);
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

            //    List<ReporteTipoEntregaElementoBE> lstReporte = null;
            //    lstReporte = new ReporteTipoEntregaElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptTipoEntregaElemento = new RptVistaReportes();
            //            objRptTipoEntregaElemento.VerRptTipoEntregaElemento(lstReporte);
            //            objRptTipoEntregaElemento.ShowDialog();
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
            string _fileName = "ListadoTipoEntregas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTipoEntrega.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTipoEntrega_DoubleClick(object sender, EventArgs e)
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
            mLista = new TipoEntregaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcTipoEntrega.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTipoEntrega.DataSource = mLista.Where(obj =>
                                                   obj.DescTipoEntrega.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTipoEntrega.RowCount > 0)
            {
                TipoEntregaBE objTipoEntrega = new TipoEntregaBE();
                objTipoEntrega.IdTipoEntrega = int.Parse(gvTipoEntrega.GetFocusedRowCellValue("IdTipoEntrega").ToString());
                objTipoEntrega.DescTipoEntrega = gvTipoEntrega.GetFocusedRowCellValue("DescTipoEntrega").ToString();
                objTipoEntrega.FlagEstado = Convert.ToBoolean(gvTipoEntrega.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManTipoEntregaEdit objManTipoEntregaEdit = new frmManTipoEntregaEdit();
                objManTipoEntregaEdit.pOperacion = frmManTipoEntregaEdit.Operacion.Modificar;
                objManTipoEntregaEdit.IdTipoEntrega = objTipoEntrega.IdTipoEntrega;
                objManTipoEntregaEdit.pTipoEntregaBE = objTipoEntrega;
                objManTipoEntregaEdit.StartPosition = FormStartPosition.CenterParent;
                objManTipoEntregaEdit.ShowDialog();

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

            if (gvTipoEntrega.GetFocusedRowCellValue("IdTipoEntrega").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una TipoEntrega", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }


        #endregion

        
    }
}