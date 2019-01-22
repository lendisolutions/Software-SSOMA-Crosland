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
    public partial class frmManContingencia : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ContingenciaBE> mLista = new List<ContingenciaBE>();
        
        #endregion

        #region "Eventos"

        public frmManContingencia()
        {
            InitializeComponent();
        }

        private void frmManContingencia_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManContingenciaEdit objManContingencia = new frmManContingenciaEdit();
                objManContingencia.lstContingencia = mLista;
                objManContingencia.pOperacion = frmManContingenciaEdit.Operacion.Nuevo;
                objManContingencia.IdContingencia = 0;
                objManContingencia.StartPosition = FormStartPosition.CenterParent;
                objManContingencia.ShowDialog();
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
                        ContingenciaBE objE_Contingencia = new ContingenciaBE();
                        objE_Contingencia.IdContingencia = int.Parse(gvContingencia.GetFocusedRowCellValue("IdContingencia").ToString());
                        objE_Contingencia.Usuario = Parametros.strUsuarioLogin;
                        objE_Contingencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Contingencia.IdEmpresa = Parametros.intEmpresaId;

                        ContingenciaBL objBL_Contingencia = new ContingenciaBL();
                        objBL_Contingencia.Elimina(objE_Contingencia);
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

            //    List<ReporteContingenciaElementoBE> lstReporte = null;
            //    lstReporte = new ReporteContingenciaElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptContingenciaElemento = new RptVistaReportes();
            //            objRptContingenciaElemento.VerRptContingenciaElemento(lstReporte);
            //            objRptContingenciaElemento.ShowDialog();
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
            string _fileName = "ListadoContingencias";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvContingencia.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvContingencia_DoubleClick(object sender, EventArgs e)
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
            mLista = new ContingenciaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcContingencia.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcContingencia.DataSource = mLista.Where(obj =>
                                                   obj.DescContingencia.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvContingencia.RowCount > 0)
            {
                ContingenciaBE objContingencia = new ContingenciaBE();
                objContingencia.IdContingencia = int.Parse(gvContingencia.GetFocusedRowCellValue("IdContingencia").ToString());
                objContingencia.DescContingencia = gvContingencia.GetFocusedRowCellValue("DescContingencia").ToString();
                objContingencia.FlagEstado = Convert.ToBoolean(gvContingencia.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManContingenciaEdit objManContingenciaEdit = new frmManContingenciaEdit();
                objManContingenciaEdit.pOperacion = frmManContingenciaEdit.Operacion.Modificar;
                objManContingenciaEdit.IdContingencia = objContingencia.IdContingencia;
                objManContingenciaEdit.pContingenciaBE = objContingencia;
                objManContingenciaEdit.StartPosition = FormStartPosition.CenterParent;
                objManContingenciaEdit.ShowDialog();

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

            if (gvContingencia.GetFocusedRowCellValue("IdContingencia").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Contingencia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}