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

namespace SSOMA.Presentacion.Modulos.Extintor.Maestros
{
    public partial class frmManAnomalia : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<AnomaliaBE> mLista = new List<AnomaliaBE>();
        
        #endregion

        #region "Eventos"

        public frmManAnomalia()
        {
            InitializeComponent();
        }

        private void frmManAnomalia_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManAnomaliaEdit objManAnomalia = new frmManAnomaliaEdit();
                objManAnomalia.lstAnomalia = mLista;
                objManAnomalia.pOperacion = frmManAnomaliaEdit.Operacion.Nuevo;
                objManAnomalia.IdAnomalia = 0;
                objManAnomalia.StartPosition = FormStartPosition.CenterParent;
                objManAnomalia.ShowDialog();
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
                        AnomaliaBE objE_Anomalia = new AnomaliaBE();
                        objE_Anomalia.IdAnomalia = int.Parse(gvAnomalia.GetFocusedRowCellValue("IdAnomalia").ToString());
                        objE_Anomalia.Usuario = Parametros.strUsuarioLogin;
                        objE_Anomalia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Anomalia.IdEmpresa = Parametros.intEmpresaId;

                        AnomaliaBL objBL_Anomalia = new AnomaliaBL();
                        objBL_Anomalia.Elimina(objE_Anomalia);
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

            //    List<ReporteAnomaliaElementoBE> lstReporte = null;
            //    lstReporte = new ReporteAnomaliaElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptAnomaliaElemento = new RptVistaReportes();
            //            objRptAnomaliaElemento.VerRptAnomaliaElemento(lstReporte);
            //            objRptAnomaliaElemento.ShowDialog();
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
            string _fileName = "ListadoAnomalias";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvAnomalia.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvAnomalia_DoubleClick(object sender, EventArgs e)
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
            mLista = new AnomaliaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcAnomalia.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcAnomalia.DataSource = mLista.Where(obj =>
                                                   obj.DescAnomalia.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvAnomalia.RowCount > 0)
            {
                AnomaliaBE objAnomalia = new AnomaliaBE();
                objAnomalia.IdAnomalia = int.Parse(gvAnomalia.GetFocusedRowCellValue("IdAnomalia").ToString());
                objAnomalia.DescAnomalia = gvAnomalia.GetFocusedRowCellValue("DescAnomalia").ToString();
                objAnomalia.FlagEstado = Convert.ToBoolean(gvAnomalia.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManAnomaliaEdit objManAnomaliaEdit = new frmManAnomaliaEdit();
                objManAnomaliaEdit.pOperacion = frmManAnomaliaEdit.Operacion.Modificar;
                objManAnomaliaEdit.IdAnomalia = objAnomalia.IdAnomalia;
                objManAnomaliaEdit.pAnomaliaBE = objAnomalia;
                objManAnomaliaEdit.StartPosition = FormStartPosition.CenterParent;
                objManAnomaliaEdit.ShowDialog();

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

            if (gvAnomalia.GetFocusedRowCellValue("IdAnomalia").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Anomalia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}