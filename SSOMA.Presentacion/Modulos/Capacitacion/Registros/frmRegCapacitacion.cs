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

namespace SSOMA.Presentacion.Modulos.Capacitacion.Registros
{
    public partial class frmRegCapacitacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CapacitacionBE> mLista = new List<CapacitacionBE>();

        #endregion

        #region "Eventos"

        public frmRegCapacitacion()
        {
            InitializeComponent();
        }

        private void frmRegCapacitacion_Load(object sender, EventArgs e)
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
                frmRegCapacitacionEdit objManCapacitacion = new frmRegCapacitacionEdit();
                objManCapacitacion.lstCapacitacion = mLista;
                objManCapacitacion.pOperacion = frmRegCapacitacionEdit.Operacion.Nuevo;
                objManCapacitacion.IdCapacitacion = 0;
                objManCapacitacion.StartPosition = FormStartPosition.CenterParent;
                objManCapacitacion.ShowDialog();
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
                        CapacitacionBE objE_Capacitacion = new CapacitacionBE();
                        objE_Capacitacion.IdCapacitacion = int.Parse(gvCapacitacion.GetFocusedRowCellValue("IdCapacitacion").ToString());
                        objE_Capacitacion.Usuario = Parametros.strUsuarioLogin;
                        objE_Capacitacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Capacitacion.IdEmpresa = Parametros.intEmpresaId;

                        CapacitacionBL objBL_Capacitacion = new CapacitacionBL();
                        objBL_Capacitacion.Elimina(objE_Capacitacion);
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

                if (gvCapacitacion.RowCount > 0)
                {
                    int IdCapacitacion = 0;
                    IdCapacitacion = int.Parse(gvCapacitacion.GetFocusedRowCellValue("IdCapacitacion").ToString());
                    List<ReporteCapacitacionBE> lstReporte = null;

                    lstReporte = new ReporteCapacitacionBL().Listado(IdCapacitacion);

                    if (lstReporte != null)
                    {
                        RptVistaReportes objRptCapacitacion = new RptVistaReportes();
                        objRptCapacitacion.VerRptCapacitacion(lstReporte);
                        objRptCapacitacion.ShowDialog();

                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

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
            string _fileName = "ListadoCapacitacions";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCapacitacion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCapacitacion_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtPeriodo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarNumero(Convert.ToInt32(txtPeriodo.Text));
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new CapacitacionBL().ListaFecha(Parametros.intEmpresaId, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcCapacitacion.DataSource = mLista;
        }

        private void CargarNumero(int Numero)
        {
            mLista = new CapacitacionBL().ListaNumero(Numero);
            gcCapacitacion.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvCapacitacion.RowCount > 0)
            {
                CapacitacionBE objCapacitacion = new CapacitacionBE();
                objCapacitacion.IdCapacitacion = int.Parse(gvCapacitacion.GetFocusedRowCellValue("IdCapacitacion").ToString());

                frmRegCapacitacionEdit objManCapacitacionEdit = new frmRegCapacitacionEdit();
                objManCapacitacionEdit.pOperacion = frmRegCapacitacionEdit.Operacion.Modificar;
                objManCapacitacionEdit.IdCapacitacion = objCapacitacion.IdCapacitacion;
                objManCapacitacionEdit.StartPosition = FormStartPosition.CenterParent;
                objManCapacitacionEdit.ShowDialog();

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

            if (gvCapacitacion.GetFocusedRowCellValue("IdCapacitacion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Capacitacion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}