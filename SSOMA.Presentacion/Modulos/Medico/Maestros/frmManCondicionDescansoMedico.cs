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
    public partial class frmManCondicionDescansoMedico : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CondicionDescansoMedicoBE> mLista = new List<CondicionDescansoMedicoBE>();
        
        #endregion

        #region "Eventos"

        public frmManCondicionDescansoMedico()
        {
            InitializeComponent();
        }

        private void frmManCondicionDescansoMedico_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManCondicionDescansoMedicoEdit objManCondicionDescansoMedico = new frmManCondicionDescansoMedicoEdit();
                objManCondicionDescansoMedico.lstCondicionDescansoMedico = mLista;
                objManCondicionDescansoMedico.pOperacion = frmManCondicionDescansoMedicoEdit.Operacion.Nuevo;
                objManCondicionDescansoMedico.IdCondicionDescansoMedico = 0;
                objManCondicionDescansoMedico.StartPosition = FormStartPosition.CenterParent;
                objManCondicionDescansoMedico.ShowDialog();
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
                        CondicionDescansoMedicoBE objE_CondicionDescansoMedico = new CondicionDescansoMedicoBE();
                        objE_CondicionDescansoMedico.IdCondicionDescansoMedico = int.Parse(gvCondicionDescansoMedico.GetFocusedRowCellValue("IdCondicionDescansoMedico").ToString());
                        objE_CondicionDescansoMedico.Usuario = Parametros.strUsuarioLogin;
                        objE_CondicionDescansoMedico.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_CondicionDescansoMedico.IdEmpresa = Parametros.intEmpresaId;

                        CondicionDescansoMedicoBL objBL_CondicionDescansoMedico = new CondicionDescansoMedicoBL();
                        objBL_CondicionDescansoMedico.Elimina(objE_CondicionDescansoMedico);
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

            //    List<ReporteCondicionDescansoMedicoElementoBE> lstReporte = null;
            //    lstReporte = new ReporteCondicionDescansoMedicoElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptCondicionDescansoMedicoElemento = new RptVistaReportes();
            //            objRptCondicionDescansoMedicoElemento.VerRptCondicionDescansoMedicoElemento(lstReporte);
            //            objRptCondicionDescansoMedicoElemento.ShowDialog();
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
            string _fileName = "ListadoCondicionDescansoMedicos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCondicionDescansoMedico.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCondicionDescansoMedico_DoubleClick(object sender, EventArgs e)
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
            mLista = new CondicionDescansoMedicoBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcCondicionDescansoMedico.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcCondicionDescansoMedico.DataSource = mLista.Where(obj =>
                                                   obj.DescCondicionDescansoMedico.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvCondicionDescansoMedico.RowCount > 0)
            {
                CondicionDescansoMedicoBE objCondicionDescansoMedico = new CondicionDescansoMedicoBE();
                objCondicionDescansoMedico.IdCondicionDescansoMedico = int.Parse(gvCondicionDescansoMedico.GetFocusedRowCellValue("IdCondicionDescansoMedico").ToString());
                objCondicionDescansoMedico.DescCondicionDescansoMedico = gvCondicionDescansoMedico.GetFocusedRowCellValue("DescCondicionDescansoMedico").ToString();
                objCondicionDescansoMedico.FlagEstado = Convert.ToBoolean(gvCondicionDescansoMedico.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManCondicionDescansoMedicoEdit objManCondicionDescansoMedicoEdit = new frmManCondicionDescansoMedicoEdit();
                objManCondicionDescansoMedicoEdit.pOperacion = frmManCondicionDescansoMedicoEdit.Operacion.Modificar;
                objManCondicionDescansoMedicoEdit.IdCondicionDescansoMedico = objCondicionDescansoMedico.IdCondicionDescansoMedico;
                objManCondicionDescansoMedicoEdit.pCondicionDescansoMedicoBE = objCondicionDescansoMedico;
                objManCondicionDescansoMedicoEdit.StartPosition = FormStartPosition.CenterParent;
                objManCondicionDescansoMedicoEdit.ShowDialog();

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

            if (gvCondicionDescansoMedico.GetFocusedRowCellValue("IdCondicionDescansoMedico").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una CondicionDescansoMedico", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}