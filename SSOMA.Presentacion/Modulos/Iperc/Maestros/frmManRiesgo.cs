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

namespace SSOMA.Presentacion.Modulos.Iperc.Maestros
{
    public partial class frmManRiesgo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<RiesgoBE> mLista = new List<RiesgoBE>();

        #endregion

        #region "Eventos"

        public frmManRiesgo()
        {
            InitializeComponent();
        }

        private void frmManRiesgo_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManRiesgoEdit objManRiesgo = new frmManRiesgoEdit();
                objManRiesgo.lstRiesgo = mLista;
                objManRiesgo.pOperacion = frmManRiesgoEdit.Operacion.Nuevo;
                objManRiesgo.IdRiesgo = 0;
                objManRiesgo.StartPosition = FormStartPosition.CenterParent;
                objManRiesgo.ShowDialog();
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
                        RiesgoBE objE_Riesgo = new RiesgoBE();
                        objE_Riesgo.IdRiesgo = int.Parse(gvRiesgo.GetFocusedRowCellValue("IdRiesgo").ToString());
                        objE_Riesgo.Usuario = Parametros.strUsuarioLogin;
                        objE_Riesgo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Riesgo.IdEmpresa = Parametros.intEmpresaId;

                        RiesgoBL objBL_Riesgo = new RiesgoBL();
                        objBL_Riesgo.Elimina(objE_Riesgo);
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

            //    List<ReporteRiesgoElementoBE> lstReporte = null;
            //    lstReporte = new ReporteRiesgoElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptRiesgoElemento = new RptVistaReportes();
            //            objRptRiesgoElemento.VerRptRiesgoElemento(lstReporte);
            //            objRptRiesgoElemento.ShowDialog();
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
            string _fileName = "ListadoRiesgos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvRiesgo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvRiesgo_DoubleClick(object sender, EventArgs e)
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
            mLista = new RiesgoBL().ListaTodosActivo(0);
            gcRiesgo.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcRiesgo.DataSource = mLista.Where(obj =>
                                                   obj.DescRiesgo.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvRiesgo.RowCount > 0)
            {
                RiesgoBE objRiesgo = new RiesgoBE();
                objRiesgo.IdRiesgo = int.Parse(gvRiesgo.GetFocusedRowCellValue("IdRiesgo").ToString());
                objRiesgo.DescRiesgo = gvRiesgo.GetFocusedRowCellValue("DescRiesgo").ToString();
                objRiesgo.FlagEstado = Convert.ToBoolean(gvRiesgo.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManRiesgoEdit objManRiesgoEdit = new frmManRiesgoEdit();
                objManRiesgoEdit.pOperacion = frmManRiesgoEdit.Operacion.Modificar;
                objManRiesgoEdit.IdRiesgo = objRiesgo.IdRiesgo;
                objManRiesgoEdit.pRiesgoBE = objRiesgo;
                objManRiesgoEdit.StartPosition = FormStartPosition.CenterParent;
                objManRiesgoEdit.ShowDialog();

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

            if (gvRiesgo.GetFocusedRowCellValue("IdRiesgo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Riesgo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}