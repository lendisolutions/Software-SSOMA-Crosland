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
    public partial class frmManPregunta : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private List<PreguntaBE> mLista = new List<PreguntaBE>();
        int IdCategoriaTema = 0;
        int IdTema = 0;
        int IdCuestionario = 0;

        #endregion

        #region "Eventos"

        public frmManPregunta()
        {
            InitializeComponent();
        }

        private void frmManPregunta_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
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

                if (IdTema == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar un tema.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (IdCuestionario == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar un cuestionario.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmManPreguntaEdit objManPregunta = new frmManPreguntaEdit();
                objManPregunta.lstPregunta = mLista;
                objManPregunta.pOperacion = frmManPreguntaEdit.Operacion.Nuevo;
                objManPregunta.IdTema = IdTema;
                objManPregunta.IdCuestionario = IdCuestionario;
                objManPregunta.IdPregunta = 0;
                objManPregunta.StartPosition = FormStartPosition.CenterParent;
                objManPregunta.ShowDialog();
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
                        PreguntaBE objE_Pregunta = new PreguntaBE();
                        objE_Pregunta.IdPregunta = int.Parse(gvPregunta.GetFocusedRowCellValue("IdPregunta").ToString());
                        objE_Pregunta.Usuario = Parametros.strUsuarioLogin;
                        objE_Pregunta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Pregunta.IdEmpresa = Parametros.intEmpresaId;

                        PreguntaBL objBL_Pregunta = new PreguntaBL();
                        objBL_Pregunta.Elimina(objE_Pregunta);
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
            try
            {
                Cursor = Cursors.WaitCursor;

                if (gvPregunta.RowCount > 0)
                {
                    List<ReportePreguntaBE> lstReporte = null;

                    lstReporte = new ReportePreguntaBL().Listado(IdCuestionario);

                    if (lstReporte != null)
                    {
                        RptVistaReportes objRptCapacitacion = new RptVistaReportes();
                        objRptCapacitacion.VerRptPregunta(lstReporte);
                        objRptCapacitacion.ShowDialog();

                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPreguntas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPregunta.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPregunta_DoubleClick(object sender, EventArgs e)
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
                    CargaTreeviewCuestionario(e.Node);
                    break;
                case "CUE":
                    IdCuestionario = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Cargar();
                    break;
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

        void CargaTreeviewCuestionario(TreeNode nodo)
        {
            nodo.Nodes.Clear();

            List<CuestionarioBE> lstCuestionario = null;
            lstCuestionario = new CuestionarioBL().ListaTodosActivo(Parametros.intEmpresaId, IdTema);
            foreach (var item in lstCuestionario)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 3;
                nuevoNodoChild.SelectedImageIndex = 3;
                nuevoNodoChild.Text = item.DescCuestionario;
                nuevoNodoChild.Tag = "CUE" + item.IdCuestionario.ToString();
                nodo.Nodes.Add(nuevoNodoChild);
            }
        }

        private void Cargar()
        {
            mLista = new PreguntaBL().ListaTodosActivo(Parametros.intEmpresaId, IdTema, IdCuestionario);
            gcPregunta.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcPregunta.DataSource = mLista.Where(obj =>
                                                   obj.DescPregunta.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvPregunta.RowCount > 0)
            {
                PreguntaBE objPregunta = new PreguntaBE();
                objPregunta.IdTema = int.Parse(gvPregunta.GetFocusedRowCellValue("IdTema").ToString());
                objPregunta.IdCuestionario = int.Parse(gvPregunta.GetFocusedRowCellValue("IdCuestionario").ToString());
                objPregunta.IdPregunta = int.Parse(gvPregunta.GetFocusedRowCellValue("IdPregunta").ToString());

                frmManPreguntaEdit objManPreguntaEdit = new frmManPreguntaEdit();
                objManPreguntaEdit.pOperacion = frmManPreguntaEdit.Operacion.Modificar;
                objManPreguntaEdit.IdTema = objPregunta.IdTema;
                objManPreguntaEdit.IdCuestionario = objPregunta.IdCuestionario;
                objManPreguntaEdit.IdPregunta = objPregunta.IdPregunta;
                objManPreguntaEdit.pPreguntaBE = objPregunta;
                objManPreguntaEdit.StartPosition = FormStartPosition.CenterParent;
                objManPreguntaEdit.ShowDialog();

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

            if (gvPregunta.GetFocusedRowCellValue("IdPregunta").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Pregunta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}