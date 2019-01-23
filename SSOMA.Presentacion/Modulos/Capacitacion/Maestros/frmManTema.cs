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
    public partial class frmManTema : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TemaBE> mLista = new List<TemaBE>();

        int IdCategoriaTema = 0;

        #endregion

        #region "Eventos"

        public frmManTema()
        {
            InitializeComponent();
        }

        private void frmManTema_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            txtPeriodo.EditValue = Parametros.intPeriodo;
            CargaTreeview();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                if (IdCategoriaTema == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar la categoría.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmManTemaEdit objManTema = new frmManTemaEdit();
                objManTema.lstTema = mLista;
                objManTema.pOperacion = frmManTemaEdit.Operacion.Nuevo;
                objManTema.IdCategoriaTema = IdCategoriaTema;
                objManTema.IdTema = 0;
                objManTema.StartPosition = FormStartPosition.CenterParent;
                objManTema.ShowDialog();
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
                if (XtraMessageBox.Show("Esta seguro de anular el Tema?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int intIdTema = int.Parse(gvTema.GetFocusedRowCellValue("IdTema").ToString());
                    int intIdSituacion = int.Parse(gvTema.GetFocusedRowCellValue("IdSituacion").ToString());

                    if (intIdSituacion == Parametros.intTEMAActivo)
                    {
                        TemaBL objBL_Tema = new TemaBL();
                        objBL_Tema.ActualizaSituacion(intIdTema, Parametros.intTEMAInactivo);
                        XtraMessageBox.Show("El Tema se anuló correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede anular un Tema diferente al Estado Activo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            //    List<ReporteTemaElementoBE> lstReporte = null;
            //    lstReporte = new ReporteTemaElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptTemaElemento = new RptVistaReportes();
            //            objRptTemaElemento.VerRptTemaElemento(lstReporte);
            //            objRptTemaElemento.ShowDialog();
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
            string _fileName = "ListadoTemas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTema.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTema_DoubleClick(object sender, EventArgs e)
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
            Cargar();
        }

        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "CAT":
                    IdCategoriaTema = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Cargar();
                    break;
            }
        }

        private void gvTema_RowCellStyle(object sender, RowCellStyleEventArgs e)
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

        private void Cargar()
        {
            mLista = new TemaBL().ListaTodosActivo(Parametros.intEmpresaId, IdCategoriaTema, Convert.ToInt32(txtPeriodo.EditValue));
            gcTema.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTema.DataSource = mLista.Where(obj =>
                                                   obj.DescTema.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTema.RowCount > 0)
            {
                TemaBE objTema = new TemaBE();
                objTema.IdCategoriaTema = IdCategoriaTema;
                objTema.IdTema = int.Parse(gvTema.GetFocusedRowCellValue("IdTema").ToString());

                frmManTemaEdit objManTemaEdit = new frmManTemaEdit();
                objManTemaEdit.pOperacion = frmManTemaEdit.Operacion.Modificar;

                objManTemaEdit.IdCategoriaTema = objTema.IdCategoriaTema;
                objManTemaEdit.IdTema = objTema.IdTema;
                objManTemaEdit.pTemaBE = objTema;
                objManTemaEdit.StartPosition = FormStartPosition.CenterParent;
                objManTemaEdit.ShowDialog();

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

            if (gvTema.GetFocusedRowCellValue("IdTema").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Tema", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }


        #endregion

        
    }
}