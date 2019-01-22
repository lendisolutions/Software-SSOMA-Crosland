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

namespace SSOMA.Presentacion.Modulos.Capacitacion.Reportes
{
    public partial class frmRepCapacitacionExpositor : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"

        public frmRepCapacitacionExpositor()
        {
            InitializeComponent();
        }

        private void frmRepCapacitacionExpositor_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboExpositor, new ExpositorBL().ListaCombo(0), "DescExpositor", "IdExpositor", true);

            deFechaDesde.EditValue = new DateTime(Parametros.intPeriodo, 1, 1);
            deFechaHasta.EditValue = DateTime.Now;

            deFechaDesde.Focus();
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteCapacitacionBE> lstReporte = null;
                lstReporte = new ReporteCapacitacionBL().ListadoExpositorFecha(Convert.ToInt32(cboExpositor.EditValue), Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptDocumentoVenta = new RptVistaReportes();
                        objRptDocumentoVenta.VerRptCapacitacionExpositor(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                        objRptDocumentoVenta.ShowDialog();
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