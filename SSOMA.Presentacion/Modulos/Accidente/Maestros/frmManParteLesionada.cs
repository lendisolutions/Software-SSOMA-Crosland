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
    public partial class frmManParteLesionada : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ParteLesionadaBE> mLista = new List<ParteLesionadaBE>();

        #endregion

        #region "Eventos"

        public frmManParteLesionada()
        {
            InitializeComponent();
        }

        private void frmManParteLesionada_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManParteLesionadaEdit objManParteLesionada = new frmManParteLesionadaEdit();
                objManParteLesionada.lstParteLesionada = mLista;
                objManParteLesionada.pOperacion = frmManParteLesionadaEdit.Operacion.Nuevo;
                objManParteLesionada.IdParteLesionada = 0;
                objManParteLesionada.StartPosition = FormStartPosition.CenterParent;
                objManParteLesionada.ShowDialog();
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
                        ParteLesionadaBE objE_ParteLesionada = new ParteLesionadaBE();
                        objE_ParteLesionada.IdParteLesionada = int.Parse(gvParteLesionada.GetFocusedRowCellValue("IdParteLesionada").ToString());
                        objE_ParteLesionada.Usuario = Parametros.strUsuarioLogin;
                        objE_ParteLesionada.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ParteLesionada.IdEmpresa = Parametros.intEmpresaId;

                        ParteLesionadaBL objBL_ParteLesionada = new ParteLesionadaBL();
                        objBL_ParteLesionada.Elimina(objE_ParteLesionada);
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

            //    List<ReporteParteLesionadaElementoBE> lstReporte = null;
            //    lstReporte = new ReporteParteLesionadaElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptParteLesionadaElemento = new RptVistaReportes();
            //            objRptParteLesionadaElemento.VerRptParteLesionadaElemento(lstReporte);
            //            objRptParteLesionadaElemento.ShowDialog();
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
            string _fileName = "ListadoParteLesionadas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvParteLesionada.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvParteLesionada_DoubleClick(object sender, EventArgs e)
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
            mLista = new ParteLesionadaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcParteLesionada.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcParteLesionada.DataSource = mLista.Where(obj =>
                                                   obj.DescParteLesionada.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvParteLesionada.RowCount > 0)
            {
                ParteLesionadaBE objParteLesionada = new ParteLesionadaBE();
                objParteLesionada.IdParteLesionada = int.Parse(gvParteLesionada.GetFocusedRowCellValue("IdParteLesionada").ToString());
                objParteLesionada.DescParteLesionada = gvParteLesionada.GetFocusedRowCellValue("DescParteLesionada").ToString();
                objParteLesionada.FlagEstado = Convert.ToBoolean(gvParteLesionada.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManParteLesionadaEdit objManParteLesionadaEdit = new frmManParteLesionadaEdit();
                objManParteLesionadaEdit.pOperacion = frmManParteLesionadaEdit.Operacion.Modificar;
                objManParteLesionadaEdit.IdParteLesionada = objParteLesionada.IdParteLesionada;
                objManParteLesionadaEdit.pParteLesionadaBE = objParteLesionada;
                objManParteLesionadaEdit.StartPosition = FormStartPosition.CenterParent;
                objManParteLesionadaEdit.ShowDialog();

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

            if (gvParteLesionada.GetFocusedRowCellValue("IdParteLesionada").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una ParteLesionada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}