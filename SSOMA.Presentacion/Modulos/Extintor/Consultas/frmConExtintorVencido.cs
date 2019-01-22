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

namespace SSOMA.Presentacion.Modulos.Extintor.Consultas
{
    public partial class frmConExtintorVencido : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ExtintorBE> mLista = new List<ExtintorBE>();
        
        #endregion

        #region "Eventos"

        public frmConExtintorVencido()
        {
            InitializeComponent();
        }

        private void frmConExtintorVencido_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0, Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            Cargar();
        }

        private void txtResponsable_EditValueChanged(object sender, EventArgs e)
        {
            if (mLista.Count > 0)
            {
                CargarBusqueda();
            }
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoExtintors";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvExtintor.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvExtintor_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (e.Column.FieldName == "FechaVencimiento")
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
            mLista = new ExtintorBL().ListaVencido(Parametros.intEmpresaId, 0);
            gcExtintor.DataSource = mLista;
        }
        private void CargarBusqueda()
        {
            gcExtintor.DataSource = mLista.Where(obj =>
                                                   obj.Codigo.ToUpper().Contains(txtCodigo.Text.ToUpper())).ToList();
        }


        #endregion
        
    }
}