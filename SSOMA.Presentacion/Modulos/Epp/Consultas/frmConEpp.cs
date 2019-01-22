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

namespace SSOMA.Presentacion.Modulos.Epp.Consultas
{
    public partial class frmConEpp : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EppBE> mLista = new List<EppBE>();
        private List<EppDetalleBE> mListaDetalle = new List<EppDetalleBE>();

        int intIdEmpresaResponsable = 0;
        int intIdUnidadMineraResponsable = 0;
        int intIdAreaResponsable = 0;
        int intIdPersonaResponsable = 0;
        int IdEpp = 0;

        private GridColumn gcColumnCantidad;
        private GridColumn gcColumnTotal;
        
        #endregion

        #region "Eventos"

        public frmConEpp()
        {
            InitializeComponent();
        }

        private void frmConEpp_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now.AddDays(-30);
            deFechaHasta.EditValue = DateTime.Now;
            CargaTreeview();

            gvEppDetalle.OptionsView.ShowFooter = true;
            gvEppDetalle.Layout += new EventHandler(gvEppDetalle_Layout);

            AttachSummaryEPP();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoEpps";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvEpp.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xlsx");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xlsx");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "EMP":
                    intIdEmpresaResponsable = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    break;
                case "UMM":
                    intIdUnidadMineraResponsable = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaTreeviewAreas(e.Node);
                    break;
                case "ARE":
                    intIdAreaResponsable = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaTreeviewPersonal(e.Node);
                    break;
                case "PER":
                    intIdPersonaResponsable = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaEpp();
                    break;

            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (intIdPersonaResponsable == 0)
                {
                    XtraMessageBox.Show("Debe Seleccionar una persona responsable", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CargaEppFecha();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvEpp_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gvEpp.CollapseAllDetails();
        }

        private void gvEpp_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            e.IsEmpty = false;
        }

        private void gvEpp_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            IdEpp = Int32.Parse(gvEpp.GetFocusedRowCellValue("IdEpp").ToString());
            mListaDetalle = new EppDetalleBL().ListaTodosActivo(IdEpp);
            mLista.First(x => x.IdEpp == IdEpp).EppDetalle = mListaDetalle.Count > 0 ? mListaDetalle : null;

            AttachSummaryEPP();
        }

        private void gvEpp_MasterRowGetLevelDefaultView(object sender, MasterRowGetLevelDefaultViewEventArgs e)
        {
            e.DefaultView = gvEppDetalle;
        }

        private void txtPeriodo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (intIdPersonaResponsable == 0)
                {
                    XtraMessageBox.Show("Debe Seleccionar una persona responsable", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (e.KeyCode == Keys.Enter)
                {
                    CargarNumero(Convert.ToInt32(txtPeriodo.Text));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvEppDetalle_Layout(object sender, EventArgs e)
        {
            AttachSummaryEPP();
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
            lstArea = new AreaBL().ListaTodosActivo(intIdEmpresaResponsable, intIdUnidadMineraResponsable);
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
            lstPersona = new PersonaBL().ListaTodosActivo(intIdEmpresaResponsable, intIdUnidadMineraResponsable, intIdAreaResponsable);
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

        private void CargaEpp()
        {
            mLista = new EppBL().ListaResponsable(intIdEmpresaResponsable, intIdUnidadMineraResponsable, intIdAreaResponsable, intIdPersonaResponsable);
            gcEpp.DataSource = mLista;
        }

        private void CargarNumero(int Numero)
        {
            mLista = new EppBL().ListaNumero(Numero);
            gcEpp.DataSource = mLista;
        }

        private void CargaEppFecha()
        {
            mLista = new EppBL().ListaFechaResponsable(intIdEmpresaResponsable, intIdUnidadMineraResponsable, intIdAreaResponsable, intIdPersonaResponsable, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcEpp.DataSource = mLista;
        }

        private void AttachSummaryEPP()
        {
            GridColumn firstColumn = gvEppDetalle.VisibleColumns.Count == 0 ? null : gvEppDetalle.VisibleColumns[4];
            if (gcColumnCantidad == firstColumn) return;
            if (gcColumnCantidad != null)
            {
                gcColumnCantidad.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;
            }

            gcColumnCantidad = firstColumn;

            if (gcColumnCantidad != null)
            {
                gcColumnCantidad.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gcColumnCantidad.SummaryItem.DisplayFormat = "SUM={0:#,0.00}";
            }

            GridColumn SecondColumn = gvEppDetalle.VisibleColumns.Count == 0 ? null : gvEppDetalle.VisibleColumns[6];
            if (gcColumnTotal == SecondColumn) return;
            if (gcColumnTotal != null)
            {
                gcColumnTotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;
            }

            gcColumnTotal = SecondColumn;

            if (gcColumnTotal != null)
            {
                gcColumnTotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gcColumnTotal.SummaryItem.DisplayFormat = "SUM={0:#,0.00}";
            }
        }
        #endregion

        
        
    }
}