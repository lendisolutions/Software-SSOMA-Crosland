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
    public partial class frmRepCapacitacionInasistencia : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"

        public frmRepCapacitacionInasistencia()
        {
            InitializeComponent();
        }

        private void frmRepCapacitacionInasistencia_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            BSUtils.LoaderLook(cboTipo, new TipoCapacitacionBL().ListaCombo(0), "DescTipoCapacitacion", "IdTipoCapacitacion", true);
            BSUtils.LoaderLook(cboClasificacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblClasificacionCapacitacion), "DescTablaElemento", "IdTablaElemento", true);
            txtPeriodo.EditValue = DateTime.Now.Year;
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteCapacitacionBE> lstReporte = null;
                lstReporte = new ReporteCapacitacionBL().ListadoInasistencia(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboTipo.EditValue), Convert.ToInt32(cboClasificacion.EditValue));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptDocumentoVenta = new RptVistaReportes();
                        objRptDocumentoVenta.VerRptCapacitacionInasistencia(lstReporte, cboTipo.Text.Trim(), cboClasificacion.Text.Trim());
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