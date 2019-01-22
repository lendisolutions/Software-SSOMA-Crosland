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

namespace SSOMA.Presentacion.Modulos.Capacitacion.Consultas
{
    public partial class frmConCapacitacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CapacitacionBE> mLista = new List<CapacitacionBE>();

        int intIdEmpresa = 0;
        int intIdUnidadMinera = 0;
        int intIdArea = 0;
        int intIdPersona = 0;

        private GridColumn gcColumnTotal;

        #endregion

        #region "Eventos"

        public frmConCapacitacion()
        {
            InitializeComponent();
        }

        private void frmConCapacitacion_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = new DateTime(2016, 1, 1);
            deFechaHasta.EditValue = DateTime.Now;
            CargaTreeview();

            gvCapacitacion.OptionsView.ShowFooter = true;
            gvCapacitacion.Layout += new EventHandler(gvCapacitacion_Layout);

            AttachSummaryHoras();
        }

        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "EMP":
                    intIdEmpresa = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    break;
                case "UMM":
                    intIdUnidadMinera = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaTreeviewAreas(e.Node);
                    break;
                case "ARE":
                    intIdArea = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaTreeviewPersonal(e.Node);
                    break;
                case "PER":
                    intIdPersona = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaCapacitacionFecha();
                    break;

            }
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoCapacitacions";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCapacitacion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (intIdPersona == 0)
                {
                    XtraMessageBox.Show("Debe Seleccionar una persona responsable", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CargaCapacitacionFecha();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvCapacitacion_Layout(object sender, EventArgs e)
        {
            AttachSummaryHoras();
        }
        #endregion

        #region "Metodos"

        private void CargaTreeview()
        {
            tvwDatos.Nodes.Clear();

            List<EmpresaBE> lstEmpresa = null;
            lstEmpresa = new EmpresaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTECorporativo);
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
            lstArea = new AreaBL().ListaTodosActivo(intIdEmpresa, intIdUnidadMinera);
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

        void CargaTreeviewPersonal(TreeNode nodo)
        {
            nodo.Nodes.Clear();

            List<PersonaBE> lstPersona = null;
            lstPersona = new PersonaBL().ListaTodosActivo(intIdEmpresa, intIdUnidadMinera, intIdArea);
            foreach (var item in lstPersona)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 4;
                nuevoNodoChild.SelectedImageIndex = 4;
                nuevoNodoChild.Text = item.ApeNom;
                nuevoNodoChild.Tag = "PER" + item.IdPersona.ToString();
                nodo.Nodes.Add(nuevoNodoChild);
            }
        }

        private void CargaCapacitacionFecha()
        {
            mLista = new CapacitacionBL().ListaPersonaFecha(intIdPersona, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcCapacitacion.DataSource = mLista;

            AttachSummaryHoras();
        }

        private void AttachSummaryHoras()
        {
            GridColumn firstColumn = gvCapacitacion.VisibleColumns.Count == 0 ? null : gvCapacitacion.VisibleColumns[7];
            if (gcColumnTotal == firstColumn) return;
            if (gcColumnTotal != null)
            {
                gcColumnTotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;
            }

            gcColumnTotal = firstColumn;

            if (gcColumnTotal != null)
            {
                gcColumnTotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gcColumnTotal.SummaryItem.DisplayFormat = "SUM={0:#,0.00}";
            }
        }

        #endregion

    }
}