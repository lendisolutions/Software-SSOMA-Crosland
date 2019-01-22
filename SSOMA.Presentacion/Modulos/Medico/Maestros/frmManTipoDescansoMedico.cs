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

namespace SSOMA.Presentacion.Modulos.Medico.Maestros
{
    public partial class frmManTipoDescansoMedico : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TipoDescansoMedicoBE> mLista = new List<TipoDescansoMedicoBE>();
        
        #endregion

        #region "Eventos"

        public frmManTipoDescansoMedico()
        {
            InitializeComponent();
        }

        private void frmManTipoDescansoMedico_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTipoDescansoMedicoEdit objManTipoDescansoMedico = new frmManTipoDescansoMedicoEdit();
                objManTipoDescansoMedico.lstTipoDescansoMedico = mLista;
                objManTipoDescansoMedico.pOperacion = frmManTipoDescansoMedicoEdit.Operacion.Nuevo;
                objManTipoDescansoMedico.IdTipoDescansoMedico = 0;
                objManTipoDescansoMedico.StartPosition = FormStartPosition.CenterParent;
                objManTipoDescansoMedico.ShowDialog();
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
                        TipoDescansoMedicoBE objE_TipoDescansoMedico = new TipoDescansoMedicoBE();
                        objE_TipoDescansoMedico.IdTipoDescansoMedico = int.Parse(gvTipoDescansoMedico.GetFocusedRowCellValue("IdTipoDescansoMedico").ToString());
                        objE_TipoDescansoMedico.Usuario = Parametros.strUsuarioLogin;
                        objE_TipoDescansoMedico.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_TipoDescansoMedico.IdEmpresa = Parametros.intEmpresaId;

                        TipoDescansoMedicoBL objBL_TipoDescansoMedico = new TipoDescansoMedicoBL();
                        objBL_TipoDescansoMedico.Elimina(objE_TipoDescansoMedico);
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

            //    List<ReporteTipoDescansoMedicoElementoBE> lstReporte = null;
            //    lstReporte = new ReporteTipoDescansoMedicoElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptTipoDescansoMedicoElemento = new RptVistaReportes();
            //            objRptTipoDescansoMedicoElemento.VerRptTipoDescansoMedicoElemento(lstReporte);
            //            objRptTipoDescansoMedicoElemento.ShowDialog();
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
            string _fileName = "ListadoTipoDescansoMedicos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTipoDescansoMedico.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTipoDescansoMedico_DoubleClick(object sender, EventArgs e)
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
            mLista = new TipoDescansoMedicoBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcTipoDescansoMedico.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTipoDescansoMedico.DataSource = mLista.Where(obj =>
                                                   obj.DescTipoDescansoMedico.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTipoDescansoMedico.RowCount > 0)
            {
                TipoDescansoMedicoBE objTipoDescansoMedico = new TipoDescansoMedicoBE();
                objTipoDescansoMedico.IdTipoDescansoMedico = int.Parse(gvTipoDescansoMedico.GetFocusedRowCellValue("IdTipoDescansoMedico").ToString());
                objTipoDescansoMedico.DescTipoDescansoMedico = gvTipoDescansoMedico.GetFocusedRowCellValue("DescTipoDescansoMedico").ToString();
                objTipoDescansoMedico.FlagEstado = Convert.ToBoolean(gvTipoDescansoMedico.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManTipoDescansoMedicoEdit objManTipoDescansoMedicoEdit = new frmManTipoDescansoMedicoEdit();
                objManTipoDescansoMedicoEdit.pOperacion = frmManTipoDescansoMedicoEdit.Operacion.Modificar;
                objManTipoDescansoMedicoEdit.IdTipoDescansoMedico = objTipoDescansoMedico.IdTipoDescansoMedico;
                objManTipoDescansoMedicoEdit.pTipoDescansoMedicoBE = objTipoDescansoMedico;
                objManTipoDescansoMedicoEdit.StartPosition = FormStartPosition.CenterParent;
                objManTipoDescansoMedicoEdit.ShowDialog();

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

            if (gvTipoDescansoMedico.GetFocusedRowCellValue("IdTipoDescansoMedico").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una TipoDescansoMedico", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}