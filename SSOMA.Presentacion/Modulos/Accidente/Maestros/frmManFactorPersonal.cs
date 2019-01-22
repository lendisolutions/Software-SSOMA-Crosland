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

namespace SSOMA.Presentacion.Modulos.Accidente.Maestros
{
    public partial class frmManFactorPersonal : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<FactorPersonalBE> mLista = new List<FactorPersonalBE>();

        #endregion

        #region "Eventos"

        public frmManFactorPersonal()
        {
            InitializeComponent();
        }

        private void frmManFactorPersonal_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManFactorPersonalEdit objManFactorPersonal = new frmManFactorPersonalEdit();
                objManFactorPersonal.lstFactorPersonal = mLista;
                objManFactorPersonal.pOperacion = frmManFactorPersonalEdit.Operacion.Nuevo;
                objManFactorPersonal.IdFactorPersonal = 0;
                objManFactorPersonal.StartPosition = FormStartPosition.CenterParent;
                objManFactorPersonal.ShowDialog();
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
                        FactorPersonalBE objE_FactorPersonal = new FactorPersonalBE();
                        objE_FactorPersonal.IdFactorPersonal = int.Parse(gvFactorPersonal.GetFocusedRowCellValue("IdFactorPersonal").ToString());
                        objE_FactorPersonal.Usuario = Parametros.strUsuarioLogin;
                        objE_FactorPersonal.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_FactorPersonal.IdEmpresa = Parametros.intEmpresaId;

                        FactorPersonalBL objBL_FactorPersonal = new FactorPersonalBL();
                        objBL_FactorPersonal.Elimina(objE_FactorPersonal);
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

            //    List<ReporteFactorPersonalElementoBE> lstReporte = null;
            //    lstReporte = new ReporteFactorPersonalElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptFactorPersonalElemento = new RptVistaReportes();
            //            objRptFactorPersonalElemento.VerRptFactorPersonalElemento(lstReporte);
            //            objRptFactorPersonalElemento.ShowDialog();
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
            string _fileName = "ListadoFactorPersonals";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvFactorPersonal.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvFactorPersonal_DoubleClick(object sender, EventArgs e)
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
            mLista = new FactorPersonalBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcFactorPersonal.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcFactorPersonal.DataSource = mLista.Where(obj =>
                                                   obj.DescFactorPersonal.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvFactorPersonal.RowCount > 0)
            {
                FactorPersonalBE objFactorPersonal = new FactorPersonalBE();
                objFactorPersonal.IdFactorPersonal = int.Parse(gvFactorPersonal.GetFocusedRowCellValue("IdFactorPersonal").ToString());
                objFactorPersonal.DescFactorPersonal = gvFactorPersonal.GetFocusedRowCellValue("DescFactorPersonal").ToString();
                objFactorPersonal.FlagEstado = Convert.ToBoolean(gvFactorPersonal.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManFactorPersonalEdit objManFactorPersonalEdit = new frmManFactorPersonalEdit();
                objManFactorPersonalEdit.pOperacion = frmManFactorPersonalEdit.Operacion.Modificar;
                objManFactorPersonalEdit.IdFactorPersonal = objFactorPersonal.IdFactorPersonal;
                objManFactorPersonalEdit.pFactorPersonalBE = objFactorPersonal;
                objManFactorPersonalEdit.StartPosition = FormStartPosition.CenterParent;
                objManFactorPersonalEdit.ShowDialog();

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

            if (gvFactorPersonal.GetFocusedRowCellValue("IdFactorPersonal").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una FactorPersonal", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}