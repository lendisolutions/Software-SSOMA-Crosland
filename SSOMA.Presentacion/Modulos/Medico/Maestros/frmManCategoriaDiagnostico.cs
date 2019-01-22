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
    public partial class frmManCategoriaDiagnostico : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CategoriaDiagnosticoBE> mLista = new List<CategoriaDiagnosticoBE>();
        
        #endregion

        #region "Eventos"

        public frmManCategoriaDiagnostico()
        {
            InitializeComponent();
        }

        private void frmManCategoriaDiagnostico_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManCategoriaDiagnosticoEdit objManCategoriaDiagnostico = new frmManCategoriaDiagnosticoEdit();
                objManCategoriaDiagnostico.lstCategoriaDiagnostico = mLista;
                objManCategoriaDiagnostico.pOperacion = frmManCategoriaDiagnosticoEdit.Operacion.Nuevo;
                objManCategoriaDiagnostico.IdCategoriaDiagnostico = 0;
                objManCategoriaDiagnostico.StartPosition = FormStartPosition.CenterParent;
                objManCategoriaDiagnostico.ShowDialog();
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
                        CategoriaDiagnosticoBE objE_CategoriaDiagnostico = new CategoriaDiagnosticoBE();
                        objE_CategoriaDiagnostico.IdCategoriaDiagnostico = int.Parse(gvCategoriaDiagnostico.GetFocusedRowCellValue("IdCategoriaDiagnostico").ToString());
                        objE_CategoriaDiagnostico.Usuario = Parametros.strUsuarioLogin;
                        objE_CategoriaDiagnostico.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_CategoriaDiagnostico.IdEmpresa = Parametros.intEmpresaId;

                        CategoriaDiagnosticoBL objBL_CategoriaDiagnostico = new CategoriaDiagnosticoBL();
                        objBL_CategoriaDiagnostico.Elimina(objE_CategoriaDiagnostico);
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

            //    List<ReporteCategoriaDiagnosticoElementoBE> lstReporte = null;
            //    lstReporte = new ReporteCategoriaDiagnosticoElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptCategoriaDiagnosticoElemento = new RptVistaReportes();
            //            objRptCategoriaDiagnosticoElemento.VerRptCategoriaDiagnosticoElemento(lstReporte);
            //            objRptCategoriaDiagnosticoElemento.ShowDialog();
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
            string _fileName = "ListadoCategoriaDiagnosticos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCategoriaDiagnostico.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCategoriaDiagnostico_DoubleClick(object sender, EventArgs e)
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
            mLista = new CategoriaDiagnosticoBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcCategoriaDiagnostico.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcCategoriaDiagnostico.DataSource = mLista.Where(obj =>
                                                   obj.DescCategoriaDiagnostico.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvCategoriaDiagnostico.RowCount > 0)
            {
                CategoriaDiagnosticoBE objCategoriaDiagnostico = new CategoriaDiagnosticoBE();
                objCategoriaDiagnostico.IdCategoriaDiagnostico = int.Parse(gvCategoriaDiagnostico.GetFocusedRowCellValue("IdCategoriaDiagnostico").ToString());
                objCategoriaDiagnostico.Abreviatura = gvCategoriaDiagnostico.GetFocusedRowCellValue("Abreviatura").ToString();
                objCategoriaDiagnostico.DescCategoriaDiagnostico = gvCategoriaDiagnostico.GetFocusedRowCellValue("DescCategoriaDiagnostico").ToString();
                objCategoriaDiagnostico.FlagEstado = Convert.ToBoolean(gvCategoriaDiagnostico.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManCategoriaDiagnosticoEdit objManCategoriaDiagnosticoEdit = new frmManCategoriaDiagnosticoEdit();
                objManCategoriaDiagnosticoEdit.pOperacion = frmManCategoriaDiagnosticoEdit.Operacion.Modificar;
                objManCategoriaDiagnosticoEdit.IdCategoriaDiagnostico = objCategoriaDiagnostico.IdCategoriaDiagnostico;
                objManCategoriaDiagnosticoEdit.pCategoriaDiagnosticoBE = objCategoriaDiagnostico;
                objManCategoriaDiagnosticoEdit.StartPosition = FormStartPosition.CenterParent;
                objManCategoriaDiagnosticoEdit.ShowDialog();

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

            if (gvCategoriaDiagnostico.GetFocusedRowCellValue("IdCategoriaDiagnostico").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una CategoriaDiagnostico", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}