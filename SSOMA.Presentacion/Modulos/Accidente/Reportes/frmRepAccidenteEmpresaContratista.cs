using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SSOMA.Presentacion.Modulos.Otros;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Accidente.Reportes
{
    public partial class frmRepAccidenteEmpresaContratista : DevExpress.XtraEditors.XtraForm
    {
        #region "Atributos"

        #endregion

        #region "Eventos"

        public frmRepAccidenteEmpresaContratista()
        {
            InitializeComponent();
        }

        private void frmRepAccidenteEmpresaContratista_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTipo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoInvestigacion), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboEmpresaContratista, new EmpresaBL().ListaCombo(Parametros.intTEContratista), "RazonSocial", "IdEmpresa", true);
            cboEmpresaContratista.EditValue = Parametros.intEmpresaContratistaNinguno;
            deFechaDesde.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            deFechaHasta.EditValue = DateTime.Now;
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteAccidenteBE> lstReporte = null;
                lstReporte = new ReporteAccidenteBL().ListadoEmpresaContratista(Convert.ToInt32(cboTipo.EditValue), Convert.ToInt32(cboEmpresaContratista.EditValue), Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptAccidente = new RptVistaReportes();
                        objRptAccidente.VerRptAccidenteEmpresaContratista(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                        objRptAccidente.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        #endregion


    }
}