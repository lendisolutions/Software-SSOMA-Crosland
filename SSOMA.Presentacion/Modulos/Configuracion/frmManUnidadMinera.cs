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
    public partial class frmManUnidadMinera : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<UnidadMineraBE> mLista = new List<UnidadMineraBE>();
        
        #endregion

        #region "Eventos"

        public frmManUnidadMinera()
        {
            InitializeComponent();
        }

        private void frmManUnidadMinera_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManUnidadMineraEdit objManUnidadMinera = new frmManUnidadMineraEdit();
                objManUnidadMinera.lstUnidadMinera = mLista;
                objManUnidadMinera.pOperacion = frmManUnidadMineraEdit.Operacion.Nuevo;
                objManUnidadMinera.IdUnidadMinera = 0;
                objManUnidadMinera.StartPosition = FormStartPosition.CenterParent;
                objManUnidadMinera.ShowDialog();
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
                        UnidadMineraBE objE_UnidadMinera = new UnidadMineraBE();
                        objE_UnidadMinera.IdUnidadMinera = int.Parse(gvUnidadMinera.GetFocusedRowCellValue("IdUnidadMinera").ToString());
                        objE_UnidadMinera.Usuario = Parametros.strUsuarioLogin;
                        objE_UnidadMinera.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_UnidadMinera.IdEmpresa = Parametros.intEmpresaId;

                        UnidadMineraBL objBL_UnidadMinera = new UnidadMineraBL();
                        objBL_UnidadMinera.Elimina(objE_UnidadMinera);
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

            //    List<ReporteUnidadMineraElementoBE> lstReporte = null;
            //    lstReporte = new ReporteUnidadMineraElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptUnidadMineraElemento = new RptVistaReportes();
            //            objRptUnidadMineraElemento.VerRptUnidadMineraElemento(lstReporte);
            //            objRptUnidadMineraElemento.ShowDialog();
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
            string _fileName = "ListadoUnidadMineras";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvUnidadMinera.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvUnidadMinera_DoubleClick(object sender, EventArgs e)
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
            mLista = new UnidadMineraBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcUnidadMinera.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcUnidadMinera.DataSource = mLista.Where(obj =>
                                                   obj.DescUnidadMinera.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvUnidadMinera.RowCount > 0)
            {
                UnidadMineraBE objUnidadMinera = new UnidadMineraBE();
                objUnidadMinera.IdEmpresa = int.Parse(gvUnidadMinera.GetFocusedRowCellValue("IdEmpresa").ToString());
                objUnidadMinera.IdUnidadMinera = int.Parse(gvUnidadMinera.GetFocusedRowCellValue("IdUnidadMinera").ToString());
                objUnidadMinera.DescUnidadMinera = gvUnidadMinera.GetFocusedRowCellValue("DescUnidadMinera").ToString();
                objUnidadMinera.FlagEstado = Convert.ToBoolean(gvUnidadMinera.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManUnidadMineraEdit objManUnidadMineraEdit = new frmManUnidadMineraEdit();
                objManUnidadMineraEdit.pOperacion = frmManUnidadMineraEdit.Operacion.Modificar;
                objManUnidadMineraEdit.IdUnidadMinera = objUnidadMinera.IdUnidadMinera;
                objManUnidadMineraEdit.pUnidadMineraBE = objUnidadMinera;
                objManUnidadMineraEdit.StartPosition = FormStartPosition.CenterParent;
                objManUnidadMineraEdit.ShowDialog();

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

            if (gvUnidadMinera.GetFocusedRowCellValue("IdUnidadMinera").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una UnidadMinera", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}
