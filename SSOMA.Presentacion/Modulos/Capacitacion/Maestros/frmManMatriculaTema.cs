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
    public partial class frmManMatriculaTema : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TemaPersonaBE> mLista = new List<TemaPersonaBE>();
        int IdCategoriaTema = 0;
        int IdTema = 0;

        #endregion

        #region "Eventos"


        public frmManMatriculaTema()
        {
            InitializeComponent();
        }

        private void frmManMatriculaTema_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargaTreeview();
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

        private void gvTemaPersona_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = (GridView)sender;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.Assign(view.GetViewInfo().PaintAppearance.GetAppearance("FocusedRow"));
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                TemaPersonaBL objBL_TemaPersona = new TemaPersonaBL();


                objBL_TemaPersona.Actualiza(mLista, IdTema, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
                XtraMessageBox.Show("La asignación de los documentos se actualizó correctamente. ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cargar();

                Cursor = Cursors.Default;


            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkSelecciona_CheckedChanged(object sender, EventArgs e)
        {
            if (gvTemaPersona.RowCount > 0)
            {
                if (chkSelecciona.Checked)
                {
                    for (int i = 0; i < gvTemaPersona.RowCount; i++)
                        gvTemaPersona.SetRowCellValue(i, "FlagMatricula", true);
                }
                else
                {
                    for (int i = 0; i < gvTemaPersona.RowCount; i++)
                        gvTemaPersona.SetRowCellValue(i, "FlagMatricula", false);
                }
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

        void CargaTreeviewTemas(TreeNode nodo)
        {
            nodo.Nodes.Clear();

            List<TemaBE> lstTema = null;
            lstTema = new TemaBL().ListaTodosActivo(Parametros.intEmpresaId, IdCategoriaTema, Parametros.intPeriodo);
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
            mLista = new TemaPersonaBL().ListaTodosActivo(Parametros.intEmpresaId, IdTema,0);
            gcTemaPersona.DataSource = mLista;

            

        }

        private void CargarBusqueda()
        {
            gcTemaPersona.DataSource = mLista.Where(obj =>
                                                   obj.ApeNom.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }




        #endregion

        
    }
}