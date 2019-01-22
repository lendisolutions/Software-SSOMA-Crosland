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
    public partial class frmRepAccidenteResponsable : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        int intIdEmpresaResponsable = 0;
        int intIdUnidadMineraResponsable = 0;
        int intIdAreaResponsable = 0;
        int intIdPersonaResponsable = 0;

        #endregion

        #region "Eventos"

        public frmRepAccidenteResponsable()
        {
            InitializeComponent();
        }

        private void frmRepAccidenteResponsable_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTipo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoInvestigacion), "DescTablaElemento", "IdTablaElemento", true);
            deFechaDesde.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            deFechaHasta.EditValue = DateTime.Now;

            deFechaDesde.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = false;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    intIdEmpresaResponsable = frm.pPersonaBE.IdEmpresa;
                    intIdUnidadMineraResponsable = frm.pPersonaBE.IdUnidadMinera;
                    intIdAreaResponsable = frm.pPersonaBE.IdArea;
                    intIdPersonaResponsable = frm.pPersonaBE.IdPersona;
                    txtResponsable.Text = frm.pPersonaBE.ApeNom;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (intIdPersonaResponsable == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar una persona", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnBuscar.Select();
                    Cursor = Cursors.Default;
                    return;
                }

                List<ReporteAccidenteBE> lstReporte = null;
                lstReporte = new ReporteAccidenteBL().ListadoResponsable(Convert.ToInt32(cboTipo.EditValue), intIdEmpresaResponsable, intIdUnidadMineraResponsable, intIdAreaResponsable, intIdPersonaResponsable, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptDocumentoVenta = new RptVistaReportes();
                        objRptDocumentoVenta.VerRptAccidenteResponsable(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
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