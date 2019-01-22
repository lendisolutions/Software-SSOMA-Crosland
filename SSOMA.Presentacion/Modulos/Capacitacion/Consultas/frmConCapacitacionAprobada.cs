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

namespace SSOMA.Presentacion.Modulos.Capacitacion.Consultas
{
    public partial class frmConCapacitacionAprobada : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CapacitacionBE> mLista = new List<CapacitacionBE>();

        #endregion

        #region "Eventos"

        public frmConCapacitacionAprobada()
        {
            InitializeComponent();
        }

        private void frmConCapacitacionAprobada_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = Parametros.intPeriodo;
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0,Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboTema, new TemaBL().ListaCombo(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue)), "DescTema", "IdTema", true);
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoCapacitacionsAprobadas";
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
            CargaCapacitacionAprobada();
        }

        #endregion

        #region "Metodos"

        private void CargaCapacitacionAprobada()
        {
            mLista = new CapacitacionBL().ListaAprobado(Convert.ToInt32(cboEmpresa.EditValue),Convert.ToInt32(cboTema.EditValue));
            gcCapacitacion.DataSource = mLista;

            
        }

        #endregion


    }
}