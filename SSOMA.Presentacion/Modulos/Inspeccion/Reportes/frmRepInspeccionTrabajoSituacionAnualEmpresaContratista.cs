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

namespace SSOMA.Presentacion.Modulos.Inspeccion.Reportes
{
    public partial class frmRepInspeccionTrabajoSituacionAnualEmpresaContratista : DevExpress.XtraEditors.XtraForm
    {
        #region "Atributos"

        #endregion

        #region "Eventos"

        public frmRepInspeccionTrabajoSituacionAnualEmpresaContratista()
        {
            InitializeComponent();
        }

        private void frmRepInspeccionTrabajoSituacionAnualEmpresaContratista_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresaContratista, new EmpresaBL().ListaTodosActivo(0, Parametros.intTEContratista), "RazonSocial", "IdEmpresa", true);

        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteInspeccionTrabajoBE> lstReporte = null;
                lstReporte = new ReporteInspeccionTrabajoBL().ListadoSituacionAnualEmpresaContratista(Convert.ToInt32(cboEmpresaContratista.EditValue));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptInspeccionTrabajo = new RptVistaReportes();
                        objRptInspeccionTrabajo.VerRptInspeccionTrabajoSituacionAnualEmpresaContratista(lstReporte);
                        objRptInspeccionTrabajo.ShowDialog();
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