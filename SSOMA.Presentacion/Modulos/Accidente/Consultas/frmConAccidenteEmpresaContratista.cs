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
using SSOMA.Presentacion.Utils;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Accidente.Consultas
{
    public partial class frmConAccidenteEmpresaContratista : DevExpress.XtraEditors.XtraForm
    {
        #region "Atributos"

        private List<AccidenteBE> mLista = new List<AccidenteBE>();

        private GridColumn gcColumnTotal;

        #endregion

        #region "Eventos"

        public frmConAccidenteEmpresaContratista()
        {
            InitializeComponent();
            gcFechaEntrega.Caption = "Fecha";
            gcEmpresaInvolucrada.Caption = "Empresa\nResponsable";
            gcAreaInvolucrada.Caption = "Area\nResponsable";
            gcSedeResponsable.Caption = "Sede\nResponsable";
            gcProbabilidad.Caption = "Probabilidad\nOcurrencia";
            gcGrado.Caption = "Grado\nAccidente";
            gcCostoEstimado.Caption = "Costo\nEstimado S/.";
        }

        private void frmConAccidenteEmpresaContratista_Load(object sender, EventArgs e)
        {
            gvAccidente.OptionsView.ShowFooter = true;
            gvAccidente.Layout += new EventHandler(gvAccidente_Layout);

            BSUtils.LoaderLook(cboEmpresaContratista, new EmpresaBL().ListaCombo(Parametros.intTEContratista), "RazonSocial", "IdEmpresa", true);
            cboEmpresaContratista.EditValue = Parametros.intEmpresaContratistaNinguno;
            deFechaDesde.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            deFechaHasta.EditValue = DateTime.Now;
            Cargar();

            AttachSummaryCosto();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "Listado de Accidentes de Empresa Contratista";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvAccidente.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
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
            Cargar();
        }

        private void gvAccidente_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (e.Column.FieldName == "DescProbabilidadOcurrencia")
                {
                    string Tipo = View.GetRowCellDisplayText(e.RowHandle, View.Columns["DescProbabilidadOcurrencia"]);
                    if (Tipo == "BAJA")
                    {
                        e.Appearance.BackColor = Color.Blue;
                        e.Appearance.ForeColor = Color.White;
                    }
                    if (Tipo == "ALTA")
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                    if (Tipo == "MEDIA")
                    {
                        e.Appearance.BackColor = Color.FromArgb(0, 255, 0);
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void gvAccidente_Layout(object sender, EventArgs e)
        {
            AttachSummaryCosto();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new AccidenteBL().ListaEmpresaContratista(Convert.ToInt32(cboEmpresaContratista.EditValue), Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcAccidente.DataSource = mLista;
        }

        private void AttachSummaryCosto()
        {
            GridColumn SecondColumn = gvAccidente.VisibleColumns.Count == 0 ? null : gvAccidente.VisibleColumns[11];
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