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

namespace SSOMA.Presentacion.Modulos.Documentario.Maestros
{
    public partial class frmManCarpeta : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CarpetaBE> mLista = new List<CarpetaBE>();

        #endregion

        #region "Eventos"

        public frmManCarpeta()
        {
            InitializeComponent();
        }

        private void frmManCarpeta_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManCarpetaEdit objManCarpeta = new frmManCarpetaEdit();
                objManCarpeta.lstCarpeta = mLista;
                objManCarpeta.pOperacion = frmManCarpetaEdit.Operacion.Nuevo;
                objManCarpeta.IdCarpeta = 0;
                objManCarpeta.StartPosition = FormStartPosition.CenterParent;
                objManCarpeta.ShowDialog();
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
                        CarpetaBE objE_Carpeta = new CarpetaBE();
                        objE_Carpeta.IdCarpeta = int.Parse(gvCarpeta.GetFocusedRowCellValue("IdCarpeta").ToString());
                        objE_Carpeta.Usuario = Parametros.strUsuarioLogin;
                        objE_Carpeta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Carpeta.IdEmpresa = Parametros.intEmpresaId;

                        CarpetaBL objBL_Carpeta = new CarpetaBL();
                        objBL_Carpeta.Elimina(objE_Carpeta);
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

            //    List<ReporteCarpetaElementoBE> lstReporte = null;
            //    lstReporte = new ReporteCarpetaElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptCarpetaElemento = new RptVistaReportes();
            //            objRptCarpetaElemento.VerRptCarpetaElemento(lstReporte);
            //            objRptCarpetaElemento.ShowDialog();
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
            string _fileName = "ListadoCarpetas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCarpeta.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCarpeta_DoubleClick(object sender, EventArgs e)
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
            mLista = new CarpetaBL().ListaTodosActivo(0);
            gcCarpeta.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcCarpeta.DataSource = mLista.Where(obj =>
                                                   obj.DescCarpeta.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvCarpeta.RowCount > 0)
            {
                CarpetaBE objCarpeta = new CarpetaBE();
                objCarpeta.IdCarpeta = int.Parse(gvCarpeta.GetFocusedRowCellValue("IdCarpeta").ToString());
                objCarpeta.DescCarpeta = gvCarpeta.GetFocusedRowCellValue("DescCarpeta").ToString();
                objCarpeta.FlagEstado = Convert.ToBoolean(gvCarpeta.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManCarpetaEdit objManCarpetaEdit = new frmManCarpetaEdit();
                objManCarpetaEdit.pOperacion = frmManCarpetaEdit.Operacion.Modificar;
                objManCarpetaEdit.IdCarpeta = objCarpeta.IdCarpeta;
                objManCarpetaEdit.pCarpetaBE = objCarpeta;
                objManCarpetaEdit.StartPosition = FormStartPosition.CenterParent;
                objManCarpetaEdit.ShowDialog();

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

            if (gvCarpeta.GetFocusedRowCellValue("IdCarpeta").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Carpeta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}