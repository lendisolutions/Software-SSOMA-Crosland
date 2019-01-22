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
    public partial class frmConEPPVencer : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EppBE> mLista = new List<EppBE>();
        
        #endregion

        #region "Eventos"

        public frmConEPPVencer()
        {
            InitializeComponent();
            gcFechaEntrega.Caption = "Fecha\nEntrega";
            gcEmpresaInvolucrada.Caption = "Empresa\nResponsable";
            gcUnidadMineraResponsable.Caption = "Sede\nResponsable";
            gcAreaInvolucrada.Caption = "Area\nReponsable";
            gcFechaVencimiento.Caption = "Fecha\nVencimiento";
            gcTipoEntrega.Caption = "Tipo\nEntrega";
        }

        private void frmConEPPVencer_Load(object sender, EventArgs e)
        {
            List<string> lstDias = new List<string>();
            lstDias.Add("5");
            lstDias.Add("10");
            lstDias.Add("15");
            lstDias.Add("20");
            lstDias.Add("25");
            lstDias.Add("30");
            lstDias.Add("35");
            lstDias.Add("40");
            lstDias.Add("45");
            cboDias.Properties.DataSource = lstDias;
            cboDias.ItemIndex = 0;
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

        
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtResponsable_EditValueChanged(object sender, EventArgs e)
        {
            if (mLista.Count > 0)
            {
                CargarBusqueda();
            }
        }

        #endregion

      
        #region "Metodos"

        private void Cargar()
        {
            mLista = new EppBL().ListaPorVencer(Parametros.intEmpresaId,0,0, Convert.ToInt32(cboDias.EditValue));
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