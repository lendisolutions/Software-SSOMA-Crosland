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
    public partial class frmManServicioExtintor : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ServicioExtintorBE> mLista = new List<ServicioExtintorBE>();
        
        #endregion

        #region "Eventos"

        public frmManServicioExtintor()
        {
            InitializeComponent();
        }

        private void frmManServicioExtintor_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManServicioExtintorEdit objManServicioExtintor = new frmManServicioExtintorEdit();
                objManServicioExtintor.lstServicioExtintor = mLista;
                objManServicioExtintor.pOperacion = frmManServicioExtintorEdit.Operacion.Nuevo;
                objManServicioExtintor.IdServicioExtintor = 0;
                objManServicioExtintor.StartPosition = FormStartPosition.CenterParent;
                objManServicioExtintor.ShowDialog();
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
                        ServicioExtintorBE objE_ServicioExtintor = new ServicioExtintorBE();
                        objE_ServicioExtintor.IdServicioExtintor = int.Parse(gvServicioExtintor.GetFocusedRowCellValue("IdServicioExtintor").ToString());
                        objE_ServicioExtintor.Usuario = Parametros.strUsuarioLogin;
                        objE_ServicioExtintor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ServicioExtintor.IdEmpresa = Parametros.intEmpresaId;

                        ServicioExtintorBL objBL_ServicioExtintor = new ServicioExtintorBL();
                        objBL_ServicioExtintor.Elimina(objE_ServicioExtintor);
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

            //    List<ReporteServicioExtintorElementoBE> lstReporte = null;
            //    lstReporte = new ReporteServicioExtintorElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptServicioExtintorElemento = new RptVistaReportes();
            //            objRptServicioExtintorElemento.VerRptServicioExtintorElemento(lstReporte);
            //            objRptServicioExtintorElemento.ShowDialog();
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
            string _fileName = "ListadoServicioExtintors";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvServicioExtintor.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvServicioExtintor_DoubleClick(object sender, EventArgs e)
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
            mLista = new ServicioExtintorBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcServicioExtintor.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcServicioExtintor.DataSource = mLista.Where(obj =>
                                                   obj.DescServicioExtintor.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvServicioExtintor.RowCount > 0)
            {
                ServicioExtintorBE objServicioExtintor = new ServicioExtintorBE();
                objServicioExtintor.IdServicioExtintor = int.Parse(gvServicioExtintor.GetFocusedRowCellValue("IdServicioExtintor").ToString());
                objServicioExtintor.DescServicioExtintor = gvServicioExtintor.GetFocusedRowCellValue("DescServicioExtintor").ToString();
                objServicioExtintor.FlagEstado = Convert.ToBoolean(gvServicioExtintor.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManServicioExtintorEdit objManServicioExtintorEdit = new frmManServicioExtintorEdit();
                objManServicioExtintorEdit.pOperacion = frmManServicioExtintorEdit.Operacion.Modificar;
                objManServicioExtintorEdit.IdServicioExtintor = objServicioExtintor.IdServicioExtintor;
                objManServicioExtintorEdit.pServicioExtintorBE = objServicioExtintor;
                objManServicioExtintorEdit.StartPosition = FormStartPosition.CenterParent;
                objManServicioExtintorEdit.ShowDialog();

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

            if (gvServicioExtintor.GetFocusedRowCellValue("IdServicioExtintor").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una ServicioExtintor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}