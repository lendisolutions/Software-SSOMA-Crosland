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
    public partial class frmManTratamiento : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TratamientoBE> mLista = new List<TratamientoBE>();

        #endregion

        #region "Eventos"

        public frmManTratamiento()
        {
            InitializeComponent();
        }

        private void frmManTratamiento_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTratamientoEdit objManTratamiento = new frmManTratamientoEdit();
                objManTratamiento.lstTratamiento = mLista;
                objManTratamiento.pOperacion = frmManTratamientoEdit.Operacion.Nuevo;
                objManTratamiento.IdTratamiento = 0;
                objManTratamiento.StartPosition = FormStartPosition.CenterParent;
                objManTratamiento.ShowDialog();
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
                        TratamientoBE objE_Tratamiento = new TratamientoBE();
                        objE_Tratamiento.IdTratamiento = int.Parse(gvTratamiento.GetFocusedRowCellValue("IdTratamiento").ToString());
                        objE_Tratamiento.Usuario = Parametros.strUsuarioLogin;
                        objE_Tratamiento.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Tratamiento.IdEmpresa = Parametros.intEmpresaId;

                        TratamientoBL objBL_Tratamiento = new TratamientoBL();
                        objBL_Tratamiento.Elimina(objE_Tratamiento);
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

            //    List<ReporteTratamientoElementoBE> lstReporte = null;
            //    lstReporte = new ReporteTratamientoElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptTratamientoElemento = new RptVistaReportes();
            //            objRptTratamientoElemento.VerRptTratamientoElemento(lstReporte);
            //            objRptTratamientoElemento.ShowDialog();
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
            string _fileName = "ListadoTratamientos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTratamiento.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTratamiento_DoubleClick(object sender, EventArgs e)
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
            mLista = new TratamientoBL().ListaTodosActivo(0);
            gcTratamiento.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTratamiento.DataSource = mLista.Where(obj =>
                                                   obj.DescTratamiento.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTratamiento.RowCount > 0)
            {
                TratamientoBE objTratamiento = new TratamientoBE();
                objTratamiento.IdTratamiento = int.Parse(gvTratamiento.GetFocusedRowCellValue("IdTratamiento").ToString());
                objTratamiento.DescTratamiento = gvTratamiento.GetFocusedRowCellValue("DescTratamiento").ToString();
                objTratamiento.FlagEstado = Convert.ToBoolean(gvTratamiento.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManTratamientoEdit objManTratamientoEdit = new frmManTratamientoEdit();
                objManTratamientoEdit.pOperacion = frmManTratamientoEdit.Operacion.Modificar;
                objManTratamientoEdit.IdTratamiento = objTratamiento.IdTratamiento;
                objManTratamientoEdit.pTratamientoBE = objTratamiento;
                objManTratamientoEdit.StartPosition = FormStartPosition.CenterParent;
                objManTratamientoEdit.ShowDialog();

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

            if (gvTratamiento.GetFocusedRowCellValue("IdTratamiento").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Tratamiento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}