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

namespace SSOMA.Presentacion.Modulos.Medico.Registros
{
    public partial class frmRegSolicitudEPS : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SolicitudBE> mLista = new List<SolicitudBE>();

        #endregion

        #region "Eventos"

        public frmRegSolicitudEPS()
        {
            InitializeComponent();
        }

        private void frmRegSolicitudEPS_Load(object sender, EventArgs e)
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
                frmRegSolicitudEPSEdit objManSolicitud = new frmRegSolicitudEPSEdit();
                objManSolicitud.pOperacion = frmRegSolicitudEPSEdit.Operacion.Nuevo;
                objManSolicitud.IdSolicitud = 0;
                objManSolicitud.StartPosition = FormStartPosition.CenterParent;
                objManSolicitud.ShowDialog();
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
                if (XtraMessageBox.Show("Esta seguro de anular la solicitud de EPS?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int intIdSolicitud = int.Parse(gvSolicitud.GetFocusedRowCellValue("IdSolicitud").ToString());
                    int intIdSituacion = int.Parse(gvSolicitud.GetFocusedRowCellValue("IdSituacion").ToString());

                    if (intIdSituacion == Parametros.intSCEPSGenerada)
                    {
                        SolicitudBL objBL_Solicitud = new SolicitudBL();
                        objBL_Solicitud.ActualizaSituacion(intIdSolicitud, Parametros.intSCEPSAnulada);
                        XtraMessageBox.Show("La solicitud de EPS se anuló correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede anular una solicitud diferente al Estado Generada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            //    if (gvSolicitud.RowCount > 0)
            //    {
            //        int IdSolicitud = 0;
            //        IdSolicitud = int.Parse(gvSolicitud.GetFocusedRowCellValue("IdSolicitud").ToString());
            //        List<ReporteSolicitudBE> lstReporte = null;

            //        lstReporte = new ReporteSolicitudBL().Listado(IdSolicitud);

            //        if (lstReporte != null)
            //        {
            //            RptVistaReportes objRptAccUsu = new RptVistaReportes();
            //            objRptAccUsu.VerRptSolicitud(lstReporte);
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
            string _fileName = "ListadoSolicitudes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvSolicitud.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvSolicitud_DoubleClick(object sender, EventArgs e)
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

        private void gvSolicitud_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "DescSituacion")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["DescSituacion"]);
                        if (Situacion == "GENERADA")
                        {
                            e.Appearance.ForeColor = Color.Blue;
                        }
                        if (Situacion == "ATENDIDA")
                        {
                            e.Appearance.ForeColor = Color.Green;
                        }
                        if (Situacion == "ANULADA")
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

        private void atenderAfiliacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de atender la solicitud de EPS?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int intIdSolicitud = int.Parse(gvSolicitud.GetFocusedRowCellValue("IdSolicitud").ToString());
                    int intIdSituacion = int.Parse(gvSolicitud.GetFocusedRowCellValue("IdSituacion").ToString());

                    if (intIdSituacion == Parametros.intSCEPSGenerada)
                    {
                        SolicitudBL objBL_Solicitud = new SolicitudBL();
                        objBL_Solicitud.ActualizaSituacion(intIdSolicitud, Parametros.intSCEPSAtendida);
                        XtraMessageBox.Show("La solicitud de EPS se atendió correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede atender una solicitud diferente al estado Generada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            if (Parametros.intPerfilId == 1)
                mLista = new SolicitudBL().ListaFecha(0, 0, 0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            else
                mLista = new SolicitudBL().ListaFecha(Parametros.intEmpresaId, Parametros.intUnidadMineraId, Parametros.intAreaId, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

            gcSolicitud.DataSource = mLista;
        }

        private void CargarNumero(int Numero)
        {
            mLista = new SolicitudBL().ListaNumero(Numero);
            gcSolicitud.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvSolicitud.RowCount > 0)
            {
                SolicitudBE objSolicitud = new SolicitudBE();
                objSolicitud.IdSolicitud = int.Parse(gvSolicitud.GetFocusedRowCellValue("IdSolicitud").ToString());

                int intIdSituacion = int.Parse(gvSolicitud.GetFocusedRowCellValue("IdSituacion").ToString());
                if (intIdSituacion == Parametros.intSCEPSGenerada)
                {
                    frmRegSolicitudEPSEdit objManSolicitudEdit = new frmRegSolicitudEPSEdit();
                    objManSolicitudEdit.pOperacion = frmRegSolicitudEPSEdit.Operacion.Modificar;
                    objManSolicitudEdit.IdSolicitud = objSolicitud.IdSolicitud;
                    objManSolicitudEdit.StartPosition = FormStartPosition.CenterParent;
                    objManSolicitudEdit.btnGrabar.Enabled = true;
                    objManSolicitudEdit.ShowDialog();
                }

                if (intIdSituacion == Parametros.intSCEPSAtendida || intIdSituacion == Parametros.intSCEPSAnulada)
                {
                    frmRegSolicitudEPSEdit objManSolicitudEdit = new frmRegSolicitudEPSEdit();
                    objManSolicitudEdit.pOperacion = frmRegSolicitudEPSEdit.Operacion.Modificar;
                    objManSolicitudEdit.IdSolicitud = objSolicitud.IdSolicitud;
                    objManSolicitudEdit.StartPosition = FormStartPosition.CenterParent;
                    objManSolicitudEdit.btnGrabar.Enabled = false;
                    objManSolicitudEdit.ShowDialog();
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

            if (gvSolicitud.GetFocusedRowCellValue("IdSolicitud").ToString() == "")
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