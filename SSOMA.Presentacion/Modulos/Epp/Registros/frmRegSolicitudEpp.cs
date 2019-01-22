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
    public partial class frmRegSolicitudEpp : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SolicitudEppBE> mLista = new List<SolicitudEppBE>();
        
        #endregion

        #region "Metodos"

        public frmRegSolicitudEpp()
        {
            InitializeComponent();
            gcFechaSolicitud.Caption = "Fecha\nSolicitud";
            gcEmpresaResponsable.Caption = "Empresa\nResponsable";
            gcUnidadMineraResponsable.Caption = "Sede\nResponsable";
            gcAreaResponsable.Caption = "Area\nReponsable";
            
        }

        private void frmRegSolicitudEpp_Load(object sender, EventArgs e)
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
                frmRegSolicitudEppEdit objManSolicitudEpp = new frmRegSolicitudEppEdit();
                objManSolicitudEpp.pOperacion = frmRegSolicitudEppEdit.Operacion.Nuevo;
                objManSolicitudEpp.IdSolicitudEpp = 0;
                objManSolicitudEpp.StartPosition = FormStartPosition.CenterParent;
                objManSolicitudEpp.ShowDialog();
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
                if (XtraMessageBox.Show("Esta seguro de anular la solicitud de EPP?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int intIdSolicitudEpp = int.Parse(gvSolicitudEpp.GetFocusedRowCellValue("IdSolicitudEpp").ToString());
                    int intIdSituacion = int.Parse(gvSolicitudEpp.GetFocusedRowCellValue("IdSituacion").ToString());

                    if (intIdSituacion == Parametros.intSLCPendiente)
                    {
                        SolicitudEppBL objBL_SolicitudEpp = new SolicitudEppBL();
                        objBL_SolicitudEpp.ActualizaSituacion(intIdSolicitudEpp, Parametros.intSLCAnulado);
                        XtraMessageBox.Show("La solicitud de EPP se anuló correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede anular una solicitud diferente al Estado Pendiente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            //    if (gvSolicitudEpp.RowCount > 0)
            //    {
            //        int IdSolicitudEpp = 0;
            //        IdSolicitudEpp = int.Parse(gvSolicitudEpp.GetFocusedRowCellValue("IdSolicitudEpp").ToString());
            //        List<ReporteSolicitudEppBE> lstReporte = null;

            //        lstReporte = new ReporteSolicitudEppBL().Listado(IdSolicitudEpp);

            //        if (lstReporte != null)
            //        {
            //            RptVistaReportes objRptAccUsu = new RptVistaReportes();
            //            objRptAccUsu.VerRptSolicitudEpp(lstReporte);
            //            objRptAccUsu.ShowDialog();

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
            string _fileName = "ListadoSolicitudEpps";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvSolicitudEpp.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvSolicitudEpp_DoubleClick(object sender, EventArgs e)
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

        private void gvSolicitudEpp_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "Situacion")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Situacion"]);
                        if (Situacion == "ATENDIDO")
                        {
                            e.Appearance.ForeColor = Color.Blue;
                        }
                        if (Situacion == "PENDIENTE")
                        {
                            e.Appearance.ForeColor = Color.Red;
                        }
                        if (Situacion == "ANULADO")
                        {
                            e.Appearance.ForeColor = Color.Black;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Eventos"

        private void Cargar()
        {
            if (Parametros.intPerfilId == 1)
                mLista = new SolicitudEppBL().ListaFecha(Parametros.intEmpresaId, 0, 0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            else
                mLista = new SolicitudEppBL().ListaFecha(Parametros.intEmpresaId, Parametros.intUnidadMineraId, Parametros.intAreaId, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            
            gcSolicitudEpp.DataSource = mLista;
        }

        private void CargarNumero(int Numero)
        {
            mLista = new SolicitudEppBL().ListaNumero(Numero);
            gcSolicitudEpp.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvSolicitudEpp.RowCount > 0)
            {
                SolicitudEppBE objSolicitudEpp = new SolicitudEppBE();
                objSolicitudEpp.IdSolicitudEpp = int.Parse(gvSolicitudEpp.GetFocusedRowCellValue("IdSolicitudEpp").ToString());

                int intIdSituacion = int.Parse(gvSolicitudEpp.GetFocusedRowCellValue("IdSituacion").ToString());
                if (intIdSituacion == Parametros.intSLCPendiente)
                {
                    frmRegSolicitudEppEdit objManSolicitudEppEdit = new frmRegSolicitudEppEdit();
                    objManSolicitudEppEdit.pOperacion = frmRegSolicitudEppEdit.Operacion.Modificar;
                    objManSolicitudEppEdit.IdSolicitudEpp = objSolicitudEpp.IdSolicitudEpp;
                    objManSolicitudEppEdit.StartPosition = FormStartPosition.CenterParent;
                    objManSolicitudEppEdit.btnGrabar.Enabled = true;
                    objManSolicitudEppEdit.ShowDialog();
                }

                if (intIdSituacion == Parametros.intSLCAtendido || intIdSituacion == Parametros.intSLCAnulado)
                {
                    frmRegSolicitudEppEdit objManSolicitudEppEdit = new frmRegSolicitudEppEdit();
                    objManSolicitudEppEdit.pOperacion = frmRegSolicitudEppEdit.Operacion.Modificar;
                    objManSolicitudEppEdit.IdSolicitudEpp = objSolicitudEpp.IdSolicitudEpp;
                    objManSolicitudEppEdit.StartPosition = FormStartPosition.CenterParent;
                    objManSolicitudEppEdit.btnGrabar.Enabled = false;
                    objManSolicitudEppEdit.ShowDialog();
                }

                

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

            if (gvSolicitudEpp.GetFocusedRowCellValue("IdSolicitudEpp").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Solicitud", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
        
    }
}