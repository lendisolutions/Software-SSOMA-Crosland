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
using DevExpress.XtraGrid.Columns;
using SSOMA.Presentacion.Funciones;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Extintor.Consultas
{
    public partial class frmConMovimientoExtintor : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ExtintorBE> mLista = new List<ExtintorBE>();

        int IdEmpresa = 0;
        int IdUnidadMinera = 0;
        int IdArea = 0;
       
        
        #endregion

        #region "Eventos"

        public frmConMovimientoExtintor()
        {
            InitializeComponent();
        }

        private void frmConMovimientoExtintor_Load(object sender, EventArgs e)
        {
            CargaTreeview();
        }

        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "EMP":
                    IdEmpresa = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    break;
                case "UMM":
                    IdUnidadMinera = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Carga();
                    break;
                
                   
               

            }
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoMovimientoExtintors";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMovimientoExtintor.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigo_EditValueChanged(object sender, EventArgs e)
        {
            if (mLista.Count > 0)
            {
                CargarBusqueda();
            }
        }

        #endregion

        #region "Metodos"

        private void CargaTreeview()
        {
            tvwDatos.Nodes.Clear();

            List<EmpresaBE> lstEmpresa = null;
            lstEmpresa = new EmpresaBL().ListaTodosActivo(0, Parametros.intTECorporativo);
            foreach (var item in lstEmpresa)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = item.RazonSocial;
                nuevoNodo.ImageIndex = 0;
                nuevoNodo.SelectedImageIndex = 0;
                nuevoNodo.Tag = "EMP" + item.IdEmpresa.ToString();
                tvwDatos.Nodes.Add(nuevoNodo);

                List<UnidadMineraBE> lstUnidadMinera = null;
                lstUnidadMinera = new UnidadMineraBL().ListaTodosActivo(item.IdEmpresa);
                foreach (var itemunidad in lstUnidadMinera)
                {
                    TreeNode nuevoNodoChild = new TreeNode();
                    nuevoNodoChild.ImageIndex = 1;
                    nuevoNodoChild.SelectedImageIndex = 1;
                    nuevoNodoChild.Text = itemunidad.DescUnidadMinera;
                    nuevoNodoChild.Tag = "UMM" + itemunidad.IdUnidadMinera.ToString();
                    nuevoNodo.Nodes.Add(nuevoNodoChild);
                }
            }

            tvwDatos.ExpandAll();
        }

        void CargaTreeviewAreas(TreeNode nodo)
        {
            nodo.Nodes.Clear();

            List<AreaBE> lstArea = null;
            lstArea = new AreaBL().ListaTodosActivo(IdEmpresa, IdUnidadMinera);
            foreach (var item in lstArea)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 2;
                nuevoNodoChild.SelectedImageIndex = 2;
                nuevoNodoChild.Text = item.DescArea;
                nuevoNodoChild.Tag = "ARE" + item.IdArea.ToString();
                nodo.Nodes.Add(nuevoNodoChild);
            }
        }

        private void Carga()
        {
            mLista = new ExtintorBL().ListaTodosActivo(IdEmpresa, IdUnidadMinera);
            gcMovimientoExtintor.DataSource = mLista;

           
        }

        private void CargarBusqueda()
        {
            gcMovimientoExtintor.DataSource = mLista.Where(obj =>
                                                   obj.Codigo.ToUpper().Contains(txtCodigo.Text.ToUpper())).ToList();
        }

        #endregion

        
        
    }
}