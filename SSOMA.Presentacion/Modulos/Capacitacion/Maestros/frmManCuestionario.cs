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

namespace SSOMA.Presentacion.Modulos.Capacitacion.Maestros
{
    public partial class frmManCuestionario : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CuestionarioBE> mLista = new List<CuestionarioBE>();
        int IdCategoriaTema = 0;
        int IdTema = 0;

        #endregion

        #region "Eventos"

        public frmManCuestionario()
        {
            InitializeComponent();
        }

        private void frmManCuestionario_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargaTreeview();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                if (IdTema == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar el tema.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmManCuestionarioEdit objManCuestionario = new frmManCuestionarioEdit();
                objManCuestionario.lstCuestionario = mLista;
                objManCuestionario.pOperacion = frmManCuestionarioEdit.Operacion.Nuevo;
                objManCuestionario.IdTema = IdTema;
                objManCuestionario.IdCuestionario = 0;
                objManCuestionario.StartPosition = FormStartPosition.CenterParent;
                objManCuestionario.ShowDialog();
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
                if (XtraMessageBox.Show("Esta seguro de anular el Cuestionario?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int intIdCuestionario = int.Parse(gvCuestionario.GetFocusedRowCellValue("IdCuestionario").ToString());
                    int intIdSituacion = int.Parse(gvCuestionario.GetFocusedRowCellValue("IdSituacion").ToString());

                    if (intIdSituacion == Parametros.intCUESTIONARIOActivo)
                    {
                        CuestionarioBL objBL_Cuestionario = new CuestionarioBL();
                        objBL_Cuestionario.ActualizaSituacion(intIdCuestionario, Parametros.intCUESTIONARIOInactivo);
                        XtraMessageBox.Show("El Cuestionario se anuló correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede anular un Cuestionario diferente al Estado Activo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            //    List<ReporteCuestionarioElementoBE> lstReporte = null;
            //    lstReporte = new ReporteCuestionarioElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptCuestionarioElemento = new RptVistaReportes();
            //            objRptCuestionarioElemento.VerRptCuestionarioElemento(lstReporte);
            //            objRptCuestionarioElemento.ShowDialog();
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
            string _fileName = "ListadoCuestionarios";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCuestionario.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCuestionario_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "CAT":
                    IdCategoriaTema = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaTreeviewTemas(e.Node);
                    break;
                case "TEM":
                    IdTema = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Cargar();
                    break;
            }
        }

        private void gvCuestionario_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "DescSituacion")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["DescSituacion"]);
                        if (Situacion == "ACTIVO")
                        {
                            e.Appearance.ForeColor = Color.Blue;
                        }
                        if (Situacion == "INACTIVO")
                        {
                            e.Appearance.ForeColor = Color.Red;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void CargaTreeview()
        {
            tvwDatos.Nodes.Clear();

            TreeNode nuevoNodo = new TreeNode();
            nuevoNodo.Text = "CATEGORIAS";
            nuevoNodo.ImageIndex = 0;
            nuevoNodo.SelectedImageIndex = 0;
            tvwDatos.Nodes.Add(nuevoNodo);

            List<CategoriaTemaBE> lstCategoriaTema = null;
            lstCategoriaTema = new CategoriaTemaBL().ListaTodosActivo(Parametros.intEmpresaId);
            foreach (var item in lstCategoriaTema)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 1;
                nuevoNodoChild.SelectedImageIndex = 1;
                nuevoNodoChild.Text = item.DescCategoriaTema;
                nuevoNodoChild.Tag = "CAT" + item.IdCategoriaTema.ToString();
                nuevoNodo.Nodes.Add(nuevoNodoChild);

            }

            tvwDatos.ExpandAll();
        }

        void CargaTreeviewTemas(TreeNode nodo)
        {
            nodo.Nodes.Clear();

            List<TemaBE> lstTema = null;
            lstTema = new TemaBL().ListaTodosActivo(Parametros.intEmpresaId, IdCategoriaTema, Parametros.intTEMAVirtual, Parametros.intPeriodo);
            foreach (var item in lstTema)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 2;
                nuevoNodoChild.SelectedImageIndex = 2;
                nuevoNodoChild.Text = item.DescTema;
                nuevoNodoChild.Tag = "TEM" + item.IdTema.ToString();
                nodo.Nodes.Add(nuevoNodoChild);
            }
        }

        private void Cargar()
        {
            mLista = new CuestionarioBL().ListaTodosActivo(Parametros.intEmpresaId, IdTema);
            gcCuestionario.DataSource = mLista;



        }

        private void CargarBusqueda()
        {
            gcCuestionario.DataSource = mLista.Where(obj =>
                                                   obj.DescCuestionario.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvCuestionario.RowCount > 0)
            {
                CuestionarioBE objCuestionario = new CuestionarioBE();
                objCuestionario.IdTema = IdTema;
                objCuestionario.IdCuestionario = int.Parse(gvCuestionario.GetFocusedRowCellValue("IdCuestionario").ToString());

                frmManCuestionarioEdit objManCuestionarioEdit = new frmManCuestionarioEdit();
                objManCuestionarioEdit.pOperacion = frmManCuestionarioEdit.Operacion.Modificar;

                objManCuestionarioEdit.IdCuestionario = objCuestionario.IdCuestionario;
                objManCuestionarioEdit.IdTema = objCuestionario.IdTema;
                objManCuestionarioEdit.pCuestionarioBE = objCuestionario;
                objManCuestionarioEdit.StartPosition = FormStartPosition.CenterParent;
                objManCuestionarioEdit.ShowDialog();

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

            if (gvCuestionario.GetFocusedRowCellValue("IdCuestionario").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un cuestionario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion


    }
}