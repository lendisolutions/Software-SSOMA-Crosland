using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class frmRepAccidenteTipoAccidente : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"

        public frmRepAccidenteTipoAccidente()
        {
            InitializeComponent();
        }

        private void frmRepAccidenteTipoAccidente_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTipo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoInvestigacion), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            BSUtils.LoaderLook(cboTipoAccidente, new TipoAccidenteBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTipoAccidente", "IdTipoAccidente", true);
            deFechaDesde.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            deFechaHasta.EditValue = DateTime.Now;
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteAccidenteBE> lstReporte = null;
                lstReporte = new ReporteAccidenteBL().ListadoTipoAccidente(Convert.ToInt32(cboTipo.EditValue), Convert.ToInt32(cboEmpresa.EditValue), 0, 0, Convert.ToInt32(cboTipoAccidente.EditValue), Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptAccidente = new RptVistaReportes();
                        objRptAccidente.VerRptAccidenteTipoAccidente(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
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