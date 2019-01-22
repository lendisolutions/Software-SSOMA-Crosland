using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion.Utils;

namespace SSOMA.Presentacion.Modulos.Iperc.Maestros
{
    public partial class frmManPeligro : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PeligroBE> mLista = new List<PeligroBE>();

        int intIdEmpresa = 0;
        int intIdTipoPeligro = 0;

        #endregion

        #region "Eventos"

        public frmManPeligro()
        {
            InitializeComponent();
        }

        private void frmManPeligro_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargaTreeview();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
               
                if (intIdTipoPeligro == 0)
                {
                    XtraMessageBox.Show("Debe el tipo de peligro.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

               
                frmManPeligroEdit objManPeligro = new frmManPeligroEdit();
                objManPeligro.lstPeligro = mLista;
                objManPeligro.pOperacion = frmManPeligroEdit.Operacion.Nuevo;
                objManPeligro.IdTipoPeligro = intIdTipoPeligro;
                objManPeligro.IdPeligro = 0;
                objManPeligro.StartPosition = FormStartPosition.CenterParent;
                objManPeligro.ShowDialog();
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
                        PeligroBE objE_Peligro = new PeligroBE();
                        objE_Peligro.IdPeligro = int.Parse(gvPeligro.GetFocusedRowCellValue("IdPeligro").ToString());
                        objE_Peligro.Usuario = Parametros.strUsuarioLogin;
                        objE_Peligro.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Peligro.IdEmpresa = Parametros.intEmpresaId;

                        PeligroBL objBL_Area = new PeligroBL();
                        objBL_Area.Elimina(objE_Peligro);
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

            //    List<ReportePeligroBE> lstReporte = null;
            //    lstReporte = new ReportePeligroBL().Listado(Parametros.intEmpresaId, Parametros.intTipoPeligroId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptPeligro = new RptVistaReportes();
            //            objRptPeligro.VerRptPeligro(lstReporte);
            //            objRptPeligro.ShowDialog();
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
            string _fileName = "Listado de Peligroes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPeligro.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPeligro_DoubleClick(object sender, EventArgs e)
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

        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "EMP":
                    intIdTipoPeligro = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Cargar();
                    break;
                
            }
        }

        #endregion

        #region "Metodos"

        private void CargaTreeview()
        {
            tvwDatos.Nodes.Clear();

            TreeNode nuevoNodo = new TreeNode();
            nuevoNodo.Text = "TIPO DE PELIGRO";
            nuevoNodo.ImageIndex = 0;
            nuevoNodo.SelectedImageIndex = 0;
            tvwDatos.Nodes.Add(nuevoNodo);

            List<TipoPeligroBE> lstTipoPeligro = null;
            lstTipoPeligro = new TipoPeligroBL().ListaCombo(0);
            foreach (var item in lstTipoPeligro)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 1;
                nuevoNodoChild.SelectedImageIndex = 1;
                nuevoNodoChild.Text = item.DescTipoPeligro;
                nuevoNodoChild.Tag = "EMP" + item.IdTipoPeligro.ToString();
                nuevoNodo.Nodes.Add(nuevoNodoChild);
            }

            tvwDatos.ExpandAll();
        }


        private void Cargar()
        {
            mLista = new PeligroBL().ListaTodosActivo(intIdEmpresa, intIdTipoPeligro);
            gcPeligro.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcPeligro.DataSource = mLista.Where(obj =>
                                                   obj.DescPeligro.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvPeligro.RowCount > 0)
            {
                PeligroBE objSSOMA = new PeligroBE();
                objSSOMA.IdEmpresa = int.Parse(gvPeligro.GetFocusedRowCellValue("IdEmpresa").ToString());
                objSSOMA.IdTipoPeligro = int.Parse(gvPeligro.GetFocusedRowCellValue("IdTipoPeligro").ToString());
                objSSOMA.IdPeligro = int.Parse(gvPeligro.GetFocusedRowCellValue("IdPeligro").ToString());


                frmManPeligroEdit objManPeligroEdit = new frmManPeligroEdit();
                objManPeligroEdit.pOperacion = frmManPeligroEdit.Operacion.Modificar;
                objManPeligroEdit.IdTipoPeligro = objSSOMA.IdTipoPeligro;
                objManPeligroEdit.IdPeligro = objSSOMA.IdPeligro;
                objManPeligroEdit.pPeligroBE = objSSOMA;
                objManPeligroEdit.StartPosition = FormStartPosition.CenterParent;
                objManPeligroEdit.ShowDialog();

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

            if (gvPeligro.GetFocusedRowCellValue("IdPeligro").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Area", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}