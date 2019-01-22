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
    public partial class frmConEPPVencido : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EppBE> mLista = new List<EppBE>();
        
        #endregion

        #region "Eventos"

        public frmConEPPVencido()
        {
            InitializeComponent();
            gcFechaEntrega.Caption = "Fecha\nEntrega";
            gcEmpresaInvolucrada.Caption = "Empresa\nResponsable";
            gcUnidadMineraResponsable.Caption = "Sede\nResponsable";
            gcAreaInvolucrada.Caption = "Area\nReponsable";
            gcFechaVencimiento.Caption = "Fecha\nVencimiento";
            gcTipoEntrega.Caption = "Tipo\nEntrega";
        }

        private void frmConEPPVencido_Load(object sender, EventArgs e)
        {
            Cargar();
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

        private void txtResponsable_EditValueChanged(object sender, EventArgs e)
        {
            if (mLista.Count > 0)
            {
                CargarBusqueda();
            }
        }

        private void gvEpp_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
            mLista = new EppBL().ListaVencido(Parametros.intEmpresaId,0,0);
            gcEpp.DataSource = mLista;
        }
        private void CargarBusqueda()
        {
            gcEpp.DataSource = mLista.Where(obj =>
                                                   obj.Responsable.ToUpper().Contains(txtResponsable.Text.ToUpper())).ToList();
        }

        #endregion
        
    }
}