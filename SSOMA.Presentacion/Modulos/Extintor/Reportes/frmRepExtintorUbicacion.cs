using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SSOMA.Presentacion;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Modulos.Otros;
using SSOMA.Presentacion.Utils;

namespace SSOMA.Presentacion.Modulos.Extintor.Reportes
{
    public partial class frmRepExtintorUbicacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        
        #endregion

        #region "Eventos"

        public frmRepExtintorUbicacion()
        {
            InitializeComponent();
        }

        private void frmRepExtintorUbicacion_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
           
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
            }
        }

        
        private void btnInforme_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteExtintorBE> lstReporte = null;
                lstReporte = new ReporteExtintorBL().ListaUbicacion(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboUnidadMinera.EditValue));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptDocumentoVenta = new RptVistaReportes();
                        objRptDocumentoVenta.VerRptExtintorUbicacion(lstReporte);
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