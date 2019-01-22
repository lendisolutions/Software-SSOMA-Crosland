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

namespace SSOMA.Presentacion.Modulos.Configuracion
{
    public partial class frmManOrdenInterna : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<OrdenInternaBE> mLista = new List<OrdenInternaBE>();

        #endregion

        #region "Eventos"

        public frmManOrdenInterna()
        {
            InitializeComponent();
        }

        private void frmManOrdenInterna_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManOrdenInternaEdit objManOrdenInterna = new frmManOrdenInternaEdit();
                objManOrdenInterna.lstOrdenInterna = mLista;
                objManOrdenInterna.pOperacion = frmManOrdenInternaEdit.Operacion.Nuevo;
                objManOrdenInterna.IdOrdenInterna = 0;
                objManOrdenInterna.StartPosition = FormStartPosition.CenterParent;
                objManOrdenInterna.ShowDialog();
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
                        OrdenInternaBE objE_OrdenInterna = new OrdenInternaBE();
                        objE_OrdenInterna.IdOrdenInterna = int.Parse(gvOrdenInterna.GetFocusedRowCellValue("IdOrdenInterna").ToString());
                        objE_OrdenInterna.Usuario = Parametros.strUsuarioLogin;
                        objE_OrdenInterna.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_OrdenInterna.IdEmpresa = Parametros.intEmpresaId;

                        OrdenInternaBL objBL_OrdenInterna = new OrdenInternaBL();
                        objBL_OrdenInterna.Elimina(objE_OrdenInterna);
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

            //    List<ReporteOrdenInternaElementoBE> lstReporte = null;
            //    lstReporte = new ReporteOrdenInternaElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptOrdenInternaElemento = new RptVistaReportes();
            //            objRptOrdenInternaElemento.VerRptOrdenInternaElemento(lstReporte);
            //            objRptOrdenInternaElemento.ShowDialog();
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
            string _fileName = "ListadoOrdenInternas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvOrdenInterna.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvOrdenInterna_DoubleClick(object sender, EventArgs e)
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

        private void gvOrdenInterna_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = (GridView)sender;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.Assign(view.GetViewInfo().PaintAppearance.GetAppearance("FocusedRow"));
            }
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new OrdenInternaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intUnidadMineraId);
            gcOrdenInterna.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcOrdenInterna.DataSource = mLista.Where(obj =>
                                                   obj.DescOrdenInterna.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvOrdenInterna.RowCount > 0)
            {
                OrdenInternaBE objOrdenInterna = new OrdenInternaBE();

                objOrdenInterna.IdOrdenInterna = int.Parse(gvOrdenInterna.GetFocusedRowCellValue("IdOrdenInterna").ToString());

                frmManOrdenInternaEdit objManOrdenInternaEdit = new frmManOrdenInternaEdit();
                objManOrdenInternaEdit.pOperacion = frmManOrdenInternaEdit.Operacion.Modificar;
                objManOrdenInternaEdit.IdOrdenInterna = objOrdenInterna.IdOrdenInterna;
                objManOrdenInternaEdit.pOrdenInternaBE = objOrdenInterna;
                objManOrdenInternaEdit.StartPosition = FormStartPosition.CenterParent;
                objManOrdenInternaEdit.ShowDialog();

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

            if (gvOrdenInterna.GetFocusedRowCellValue("IdOrdenInterna").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una OrdenInterna", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}