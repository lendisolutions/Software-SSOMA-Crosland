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

namespace SSOMA.Presentacion.Modulos.Extintor.Maestros
{
    public partial class frmManClasificacionExtintor : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ClasificacionExtintorBE> mLista = new List<ClasificacionExtintorBE>();
        
        #endregion

        #region "Eventos"

        public frmManClasificacionExtintor()
        {
            InitializeComponent();
        }

        private void frmManClasificacionExtintor_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManClasificacionExtintorEdit objManClasificacionExtintor = new frmManClasificacionExtintorEdit();
                objManClasificacionExtintor.lstClasificacionExtintor = mLista;
                objManClasificacionExtintor.pOperacion = frmManClasificacionExtintorEdit.Operacion.Nuevo;
                objManClasificacionExtintor.IdClasificacionExtintor = 0;
                objManClasificacionExtintor.StartPosition = FormStartPosition.CenterParent;
                objManClasificacionExtintor.ShowDialog();
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
                        ClasificacionExtintorBE objE_ClasificacionExtintor = new ClasificacionExtintorBE();
                        objE_ClasificacionExtintor.IdClasificacionExtintor = int.Parse(gvClasificacionExtintor.GetFocusedRowCellValue("IdClasificacionExtintor").ToString());
                        objE_ClasificacionExtintor.Usuario = Parametros.strUsuarioLogin;
                        objE_ClasificacionExtintor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ClasificacionExtintor.IdEmpresa = Parametros.intEmpresaId;

                        ClasificacionExtintorBL objBL_ClasificacionExtintor = new ClasificacionExtintorBL();
                        objBL_ClasificacionExtintor.Elimina(objE_ClasificacionExtintor);
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

            //    List<ReporteClasificacionExtintorElementoBE> lstReporte = null;
            //    lstReporte = new ReporteClasificacionExtintorElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptClasificacionExtintorElemento = new RptVistaReportes();
            //            objRptClasificacionExtintorElemento.VerRptClasificacionExtintorElemento(lstReporte);
            //            objRptClasificacionExtintorElemento.ShowDialog();
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
            string _fileName = "ListadoClasificacionExtintors";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvClasificacionExtintor.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvClasificacionExtintor_DoubleClick(object sender, EventArgs e)
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
            mLista = new ClasificacionExtintorBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcClasificacionExtintor.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcClasificacionExtintor.DataSource = mLista.Where(obj =>
                                                   obj.DescClasificacionExtintor.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvClasificacionExtintor.RowCount > 0)
            {
                ClasificacionExtintorBE objClasificacionExtintor = new ClasificacionExtintorBE();
                objClasificacionExtintor.IdClasificacionExtintor = int.Parse(gvClasificacionExtintor.GetFocusedRowCellValue("IdClasificacionExtintor").ToString());
                objClasificacionExtintor.Abreviatura = gvClasificacionExtintor.GetFocusedRowCellValue("Abreviatura").ToString();
                objClasificacionExtintor.DescClasificacionExtintor = gvClasificacionExtintor.GetFocusedRowCellValue("DescClasificacionExtintor").ToString();
                objClasificacionExtintor.FlagEstado = Convert.ToBoolean(gvClasificacionExtintor.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManClasificacionExtintorEdit objManClasificacionExtintorEdit = new frmManClasificacionExtintorEdit();
                objManClasificacionExtintorEdit.pOperacion = frmManClasificacionExtintorEdit.Operacion.Modificar;
                objManClasificacionExtintorEdit.IdClasificacionExtintor = objClasificacionExtintor.IdClasificacionExtintor;
                objManClasificacionExtintorEdit.pClasificacionExtintorBE = objClasificacionExtintor;
                objManClasificacionExtintorEdit.StartPosition = FormStartPosition.CenterParent;
                objManClasificacionExtintorEdit.ShowDialog();

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

            if (gvClasificacionExtintor.GetFocusedRowCellValue("IdClasificacionExtintor").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una ClasificacionExtintor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}