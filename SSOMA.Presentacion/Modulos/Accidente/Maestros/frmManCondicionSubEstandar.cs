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
    public partial class frmManCondicionSubEstandar : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CondicionSubEstandarBE> mLista = new List<CondicionSubEstandarBE>();

        #endregion

        #region "Eventos"

        public frmManCondicionSubEstandar()
        {
            InitializeComponent();
        }

        private void frmManCondicionSubEstandar_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManCondicionSubEstandarEdit objManCondicionSubEstandar = new frmManCondicionSubEstandarEdit();
                objManCondicionSubEstandar.lstCondicionSubEstandar = mLista;
                objManCondicionSubEstandar.pOperacion = frmManCondicionSubEstandarEdit.Operacion.Nuevo;
                objManCondicionSubEstandar.IdCondicionSubEstandar = 0;
                objManCondicionSubEstandar.StartPosition = FormStartPosition.CenterParent;
                objManCondicionSubEstandar.ShowDialog();
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
                        CondicionSubEstandarBE objE_CondicionSubEstandar = new CondicionSubEstandarBE();
                        objE_CondicionSubEstandar.IdCondicionSubEstandar = int.Parse(gvCondicionSubEstandar.GetFocusedRowCellValue("IdCondicionSubEstandar").ToString());
                        objE_CondicionSubEstandar.Usuario = Parametros.strUsuarioLogin;
                        objE_CondicionSubEstandar.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_CondicionSubEstandar.IdEmpresa = Parametros.intEmpresaId;

                        CondicionSubEstandarBL objBL_CondicionSubEstandar = new CondicionSubEstandarBL();
                        objBL_CondicionSubEstandar.Elimina(objE_CondicionSubEstandar);
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

            //    List<ReporteCondicionSubEstandarElementoBE> lstReporte = null;
            //    lstReporte = new ReporteCondicionSubEstandarElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptCondicionSubEstandarElemento = new RptVistaReportes();
            //            objRptCondicionSubEstandarElemento.VerRptCondicionSubEstandarElemento(lstReporte);
            //            objRptCondicionSubEstandarElemento.ShowDialog();
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
            string _msg = "Se genero el archivo excel de forma satisfCondicionria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoCondicionSubEstandars";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCondicionSubEstandar.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCondicionSubEstandar_DoubleClick(object sender, EventArgs e)
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
            mLista = new CondicionSubEstandarBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcCondicionSubEstandar.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcCondicionSubEstandar.DataSource = mLista.Where(obj =>
                                                   obj.DescCondicionSubEstandar.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvCondicionSubEstandar.RowCount > 0)
            {
                CondicionSubEstandarBE objCondicionSubEstandar = new CondicionSubEstandarBE();
                objCondicionSubEstandar.IdCondicionSubEstandar = int.Parse(gvCondicionSubEstandar.GetFocusedRowCellValue("IdCondicionSubEstandar").ToString());
                objCondicionSubEstandar.DescCondicionSubEstandar = gvCondicionSubEstandar.GetFocusedRowCellValue("DescCondicionSubEstandar").ToString();
                objCondicionSubEstandar.FlagEstado = Convert.ToBoolean(gvCondicionSubEstandar.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManCondicionSubEstandarEdit objManCondicionSubEstandarEdit = new frmManCondicionSubEstandarEdit();
                objManCondicionSubEstandarEdit.pOperacion = frmManCondicionSubEstandarEdit.Operacion.Modificar;
                objManCondicionSubEstandarEdit.IdCondicionSubEstandar = objCondicionSubEstandar.IdCondicionSubEstandar;
                objManCondicionSubEstandarEdit.pCondicionSubEstandarBE = objCondicionSubEstandar;
                objManCondicionSubEstandarEdit.StartPosition = FormStartPosition.CenterParent;
                objManCondicionSubEstandarEdit.ShowDialog();

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

            if (gvCondicionSubEstandar.GetFocusedRowCellValue("IdCondicionSubEstandar").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una CondicionSubEstandar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}