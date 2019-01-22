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

namespace SSOMA.Presentacion.Modulos.Extintor.Registros
{
    public partial class frmRegMovimientoExtintor : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<MovimientoExtintorBE> mLista = new List<MovimientoExtintorBE>();
        
        #endregion

        #region "Eventos"

        public frmRegMovimientoExtintor()
        {
            InitializeComponent();
            //gcCodigo.Caption = "Código\nExtintor";
        }

        private void frmRegMovimientoExtintor_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            deFechaDesde.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            deFechaHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegMovimientoExtintorEdit objManMovimientoExtintor = new frmRegMovimientoExtintorEdit();
                objManMovimientoExtintor.lstMovimientoExtintor = mLista;
                objManMovimientoExtintor.pOperacion = frmRegMovimientoExtintorEdit.Operacion.Nuevo;
                objManMovimientoExtintor.IdMovimientoExtintor = 0;
                objManMovimientoExtintor.StartPosition = FormStartPosition.CenterParent;
                objManMovimientoExtintor.ShowDialog();
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
                        MovimientoExtintorBE objE_MovimientoExtintor = new MovimientoExtintorBE();
                        objE_MovimientoExtintor.IdMovimientoExtintor = int.Parse(gvExtintorInspeccion.GetFocusedRowCellValue("IdMovimientoExtintor").ToString());
                        objE_MovimientoExtintor.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoExtintor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoExtintor.IdEmpresa = Parametros.intEmpresaId;

                        MovimientoExtintorBL objBL_MovimientoExtintor = new MovimientoExtintorBL();
                        objBL_MovimientoExtintor.Elimina(objE_MovimientoExtintor);
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
            try
            {
                Cursor = Cursors.WaitCursor;

                //if (gvMovimientoExtintor.RowCount > 0)
                //{
                //    int IdMovimientoExtintor = 0;
                //    IdMovimientoExtintor = int.Parse(gvMovimientoExtintor.GetFocusedRowCellValue("IdMovimientoExtintor").ToString());
                //    List<ReporteMovimientoExtintorBE> lstReporte = null;

                //    lstReporte = new ReporteMovimientoExtintorBL().Listado(IdMovimientoExtintor);

                //    if (lstReporte != null)
                //    {
                //        RptVistaReportes objRptAccUsu = new RptVistaReportes();
                //        objRptAccUsu.VerRptMovimientoExtintor(lstReporte);
                //        objRptAccUsu.ShowDialog();

                //    }
                //    else
                //        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoMovimientoExtintors";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvExtintorInspeccion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvMovimientoExtintor_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //CargarNumero(txtCodigo.Text);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new MovimientoExtintorBL().ListaFecha(Parametros.intEmpresaId, Parametros.intUnidadMineraId, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcExtintorInspeccion.DataSource = mLista;
        }

        private void CargarNumero(string Numero)
        {
            mLista = new MovimientoExtintorBL().ListaCodigo(Numero);
            gcExtintorInspeccion.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvExtintorInspeccion.RowCount > 0)
            {
                MovimientoExtintorBE objMovimientoExtintor = new MovimientoExtintorBE();
                objMovimientoExtintor.IdMovimientoExtintor = int.Parse(gvExtintorInspeccion.GetFocusedRowCellValue("IdMovimientoExtintor").ToString());

                frmRegMovimientoExtintorEdit objManMovimientoExtintorEdit = new frmRegMovimientoExtintorEdit();
                objManMovimientoExtintorEdit.pOperacion = frmRegMovimientoExtintorEdit.Operacion.Modificar;
                objManMovimientoExtintorEdit.IdMovimientoExtintor = objMovimientoExtintor.IdMovimientoExtintor;
                objManMovimientoExtintorEdit.StartPosition = FormStartPosition.CenterParent;
                objManMovimientoExtintorEdit.ShowDialog();

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

            if (gvExtintorInspeccion.GetFocusedRowCellValue("IdMovimientoExtintor").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una MovimientoExtintor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}