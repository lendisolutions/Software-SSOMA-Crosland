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
    public partial class frmManEquipoProteccion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EquipoProteccionBE> mLista = new List<EquipoProteccionBE>();

        #endregion

        #region "Eventos"

        public frmManEquipoProteccion()
        {
            InitializeComponent();
        }

        private void frmManEquipoProteccion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManEquipoProteccionEdit objManEquipoProteccion = new frmManEquipoProteccionEdit();
                objManEquipoProteccion.lstEquipoProteccion = mLista;
                objManEquipoProteccion.pOperacion = frmManEquipoProteccionEdit.Operacion.Nuevo;
                objManEquipoProteccion.IdEquipoProteccion = 0;
                objManEquipoProteccion.StartPosition = FormStartPosition.CenterParent;
                objManEquipoProteccion.ShowDialog();
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
                        EquipoProteccionBE objE_EquipoProteccion = new EquipoProteccionBE();
                        objE_EquipoProteccion.IdEquipoProteccion = int.Parse(gvEquipoProteccion.GetFocusedRowCellValue("IdEquipoProteccion").ToString());
                        objE_EquipoProteccion.Usuario = Parametros.strUsuarioLogin;
                        objE_EquipoProteccion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_EquipoProteccion.IdEmpresa = Parametros.intEmpresaId;

                        EquipoProteccionBL objBL_EquipoProteccion = new EquipoProteccionBL();
                        objBL_EquipoProteccion.Elimina(objE_EquipoProteccion);
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

            //    List<ReporteEquipoProteccionElementoBE> lstReporte = null;
            //    lstReporte = new ReporteEquipoProteccionElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptEquipoProteccionElemento = new RptVistaReportes();
            //            objRptEquipoProteccionElemento.VerRptEquipoProteccionElemento(lstReporte);
            //            objRptEquipoProteccionElemento.ShowDialog();
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
            string _fileName = "ListadoEquipoProteccions";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvEquipoProteccion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvEquipoProteccion_DoubleClick(object sender, EventArgs e)
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
            mLista = new EquipoProteccionBL().ListaTodosActivo(0);
            gcEquipoProteccion.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcEquipoProteccion.DataSource = mLista.Where(obj =>
                                                   obj.DescEquipoProteccion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvEquipoProteccion.RowCount > 0)
            {
                EquipoProteccionBE objEquipoProteccion = new EquipoProteccionBE();
                objEquipoProteccion.IdEquipoProteccion = int.Parse(gvEquipoProteccion.GetFocusedRowCellValue("IdEquipoProteccion").ToString());
                objEquipoProteccion.DescEquipoProteccion = gvEquipoProteccion.GetFocusedRowCellValue("DescEquipoProteccion").ToString();
                objEquipoProteccion.FlagEstado = Convert.ToBoolean(gvEquipoProteccion.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManEquipoProteccionEdit objManEquipoProteccionEdit = new frmManEquipoProteccionEdit();
                objManEquipoProteccionEdit.pOperacion = frmManEquipoProteccionEdit.Operacion.Modificar;
                objManEquipoProteccionEdit.IdEquipoProteccion = objEquipoProteccion.IdEquipoProteccion;
                objManEquipoProteccionEdit.pEquipoProteccionBE = objEquipoProteccion;
                objManEquipoProteccionEdit.StartPosition = FormStartPosition.CenterParent;
                objManEquipoProteccionEdit.ShowDialog();

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

            if (gvEquipoProteccion.GetFocusedRowCellValue("IdEquipoProteccion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una EquipoProteccion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}