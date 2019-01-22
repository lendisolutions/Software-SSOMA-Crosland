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


namespace SSOMA.Presentacion.Modulos.Medico.Consultas
{
    public partial class frmConDescansoMedicoVencido : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<DescansoMedicoBE> mLista = new List<DescansoMedicoBE>();

        #endregion

        #region "Eventos"

        public frmConDescansoMedicoVencido()
        {
            InitializeComponent();
        }

        private void frmConDescansoMedicoVencido_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoDescansoMedicos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDescansoMedico.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtResponsable_EditValueChanged(object sender, EventArgs e)
        {
            if (mLista.Count > 0)
            {
                CargarBusqueda();
            }
        }

        private void gvDescansoMedico_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (e.Column.FieldName == "FechaFin")
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new DescansoMedicoBL().ListaVencido(0, 0, 0);
            gcDescansoMedico.DataSource = mLista;
        }
        private void CargarBusqueda()
        {
            gcDescansoMedico.DataSource = mLista.Where(obj =>
                                                   obj.ApeNom.ToUpper().Contains(txtResponsable.Text.ToUpper())).ToList();
        }

        #endregion

    }
}