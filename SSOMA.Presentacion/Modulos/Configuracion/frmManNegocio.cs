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

namespace SSOMA.Presentacion.Modulos.Configuracion
{
    public partial class frmManNegocio : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<NegocioBE> mLista = new List<NegocioBE>();


        #endregion

        #region "Eventos"

        public frmManNegocio()
        {
            InitializeComponent();
        }

        private void frmManNegocio_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManNegocioEdit objManNegocio = new frmManNegocioEdit();
                objManNegocio.lstNegocio = mLista;
                objManNegocio.pOperacion = frmManNegocioEdit.Operacion.Nuevo;
                objManNegocio.IdNegocio = 0;
                objManNegocio.StartPosition = FormStartPosition.CenterParent;
                objManNegocio.ShowDialog();
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
                        NegocioBE objE_Negocio = new NegocioBE();
                        objE_Negocio.IdNegocio = int.Parse(gvNegocio.GetFocusedRowCellValue("IdNegocio").ToString());
                        objE_Negocio.Usuario = Parametros.strUsuarioLogin;
                        objE_Negocio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Negocio.IdEmpresa = Parametros.intEmpresaId;

                        NegocioBL objBL_Negocio = new NegocioBL();
                        objBL_Negocio.Elimina(objE_Negocio);
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

            //    List<ReporteNegocioElementoBE> lstReporte = null;
            //    lstReporte = new ReporteNegocioElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptNegocioElemento = new RptVistaReportes();
            //            objRptNegocioElemento.VerRptNegocioElemento(lstReporte);
            //            objRptNegocioElemento.ShowDialog();
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
            string _fileName = "ListadoNegocios";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvNegocio.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvNegocio_DoubleClick(object sender, EventArgs e)
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
            mLista = new NegocioBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcNegocio.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcNegocio.DataSource = mLista.Where(obj =>
                                                   obj.DescNegocio.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvNegocio.RowCount > 0)
            {
                NegocioBE objNegocio = new NegocioBE();
                objNegocio.IdNegocio = int.Parse(gvNegocio.GetFocusedRowCellValue("IdNegocio").ToString());
                objNegocio.DescNegocio = gvNegocio.GetFocusedRowCellValue("DescNegocio").ToString();
                objNegocio.FlagEstado = Convert.ToBoolean(gvNegocio.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManNegocioEdit objManNegocioEdit = new frmManNegocioEdit();
                objManNegocioEdit.pOperacion = frmManNegocioEdit.Operacion.Modificar;
                objManNegocioEdit.IdNegocio = objNegocio.IdNegocio;
                objManNegocioEdit.pNegocioBE = objNegocio;
                objManNegocioEdit.StartPosition = FormStartPosition.CenterParent;
                objManNegocioEdit.ShowDialog();

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

            if (gvNegocio.GetFocusedRowCellValue("IdNegocio").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Negocio", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}