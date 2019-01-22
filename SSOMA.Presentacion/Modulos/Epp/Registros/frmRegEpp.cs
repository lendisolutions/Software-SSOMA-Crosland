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

namespace SSOMA.Presentacion.Modulos.Epp.Registros
{
    public partial class frmRegEpp : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EppBE> mLista = new List<EppBE>();
        
        #endregion

        #region "Eventos"

        public frmRegEpp()
        {
            InitializeComponent();
            gcFechaEntrega.Caption = "Fecha\nEntrega";
            gcEmpresaInvolucrada.Caption = "Empresa\nResponsable";
            gcAreaInvolucrada.Caption = "Area\nResponsable";
            gcSectorResponsable.Caption = "Sector\nResponsable";
        }

        private void frmRegEpp_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            deFechaDesde.EditValue = DateTime.Now.AddDays(-30);
            deFechaHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegEppEdit objManEpp = new frmRegEppEdit();
                objManEpp.pOperacion = frmRegEppEdit.Operacion.Nuevo;
                objManEpp.IdEpp = 0;
                objManEpp.StartPosition = FormStartPosition.CenterParent;
                objManEpp.ShowDialog();
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
                        EppBE objE_Epp = new EppBE();
                        objE_Epp.IdEpp = int.Parse(gvEpp.GetFocusedRowCellValue("IdEpp").ToString());
                        objE_Epp.IdSolicitudEpp = int.Parse(gvEpp.GetFocusedRowCellValue("IdSolicitudEpp").ToString());
                        objE_Epp.Usuario = Parametros.strUsuarioLogin;
                        objE_Epp.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Epp.IdEmpresa = Parametros.intEmpresaId;

                        EppBL objBL_Epp = new EppBL();
                        objBL_Epp.Elimina(objE_Epp);
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

                if (gvEpp.RowCount > 0)
                {
                    int IdEpp = 0;
                    IdEpp = int.Parse(gvEpp.GetFocusedRowCellValue("IdEpp").ToString());
                    List<ReporteEppBE> lstReporte = null;

                    lstReporte = new ReporteEppBL().Listado(IdEpp);

                    if (lstReporte != null)
                    {
                        RptVistaReportes objRptAccUsu = new RptVistaReportes();
                        objRptAccUsu.VerRptEpp(lstReporte, Parametros.strUsuarioNombres, "CROSLAND LOGISTICA S.A.C.");
                        objRptAccUsu.ShowDialog();

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
            string _fileName = "ListadoEpps";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvEpp.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvEpp_DoubleClick(object sender, EventArgs e)
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
            mLista = new EppBL().ListaFecha(Parametros.intEmpresaId,0,0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcEpp.DataSource = mLista;
        }

        private void CargarNumero(int Numero)
        {
            mLista = new EppBL().ListaNumero(Numero);
            gcEpp.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvEpp.RowCount > 0)
            {
                EppBE objEpp = new EppBE();
                objEpp.IdEpp = int.Parse(gvEpp.GetFocusedRowCellValue("IdEpp").ToString());

                frmRegEppEdit objManEppEdit = new frmRegEppEdit();
                objManEppEdit.pOperacion = frmRegEppEdit.Operacion.Modificar;
                objManEppEdit.IdEpp = objEpp.IdEpp;
                objManEppEdit.StartPosition = FormStartPosition.CenterParent;
                objManEppEdit.ShowDialog();

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

            if (gvEpp.GetFocusedRowCellValue("IdEpp").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Epp", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
        
    }
}