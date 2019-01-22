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
    public partial class frmRegDescansoMedico : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<DescansoMedicoBE> mLista = new List<DescansoMedicoBE>();

        #endregion

        #region "Eventos"

        public frmRegDescansoMedico()
        {
            InitializeComponent();
        }

        private void frmRegDescansoMedico_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            deFechaDesde.EditValue = new DateTime(Parametros.intPeriodo,1,1);
            deFechaHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegDescansoMedicoEdit objManDescansoMedico = new frmRegDescansoMedicoEdit();
                objManDescansoMedico.pOperacion = frmRegDescansoMedicoEdit.Operacion.Nuevo;
                objManDescansoMedico.IdDescansoMedico = 0;
                objManDescansoMedico.StartPosition = FormStartPosition.CenterParent;
                objManDescansoMedico.ShowDialog();
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
                if (XtraMessageBox.Show("Esta seguro de anular el Descanso Medico?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int intIdDescansoMedico = int.Parse(gvDescansoMedico.GetFocusedRowCellValue("IdDescansoMedico").ToString());
                    int intIdSituacion = int.Parse(gvDescansoMedico.GetFocusedRowCellValue("IdSituacion").ToString());

                    if (intIdSituacion != Parametros.intDMCesado)
                    {
                        DescansoMedicoBL objBL_DescansoMedico = new DescansoMedicoBL();
                        objBL_DescansoMedico.ActualizaSituacion(intIdDescansoMedico, Parametros.intSLCAnulado);
                        XtraMessageBox.Show("El Descanso Médico se anuló correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede anular un descanso médico cuando ya esta anulada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            //    if (gvDescansoMedico.RowCount > 0)
            //    {
            //        int IdDescansoMedico = 0;
            //        IdDescansoMedico = int.Parse(gvDescansoMedico.GetFocusedRowCellValue("IdDescansoMedico").ToString());
            //        List<ReporteDescansoMedicoBE> lstReporte = null;

            //        lstReporte = new ReporteDescansoMedicoBL().Listado(IdDescansoMedico);

            //        if (lstReporte != null)
            //        {
            //            RptVistaReportes objRptAccUsu = new RptVistaReportes();
            //            objRptAccUsu.VerRptDescansoMedico(lstReporte);
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
            string _fileName = "ListadoDescansoMedicos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDescansoMedico.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvDescansoMedico_DoubleClick(object sender, EventArgs e)
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
           mLista = new DescansoMedicoBL().ListaFecha(0, 0, 0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString())); 
           gcDescansoMedico.DataSource = mLista;
        }

        private void CargarNumero(int Numero)
        {
            mLista = new DescansoMedicoBL().ListaNumero(Numero);
            gcDescansoMedico.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvDescansoMedico.RowCount > 0)
            {
                DescansoMedicoBE objDescansoMedico = new DescansoMedicoBE();
                objDescansoMedico.IdDescansoMedico = int.Parse(gvDescansoMedico.GetFocusedRowCellValue("IdDescansoMedico").ToString());

                frmRegDescansoMedicoEdit objManDescansoMedicoEdit = new frmRegDescansoMedicoEdit();
                objManDescansoMedicoEdit.pOperacion = frmRegDescansoMedicoEdit.Operacion.Modificar;
                objManDescansoMedicoEdit.IdDescansoMedico = objDescansoMedico.IdDescansoMedico;
                objManDescansoMedicoEdit.StartPosition = FormStartPosition.CenterParent;
                objManDescansoMedicoEdit.btnGrabar.Enabled = true;
                objManDescansoMedicoEdit.ShowDialog();
                
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

            if (gvDescansoMedico.GetFocusedRowCellValue("IdDescansoMedico").ToString() == "")
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