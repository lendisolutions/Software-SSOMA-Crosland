﻿using System;
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
    public partial class frmRepInspeccionTrabajoSituacionAnualSede : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"

        public frmRepInspeccionTrabajoSituacionAnualSede()
        {
            InitializeComponent();
        }

        private void frmRepInspeccionTrabajoSituacionAnualSede_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteInspeccionTrabajoBE> lstReporte = null;
                lstReporte = new ReporteInspeccionTrabajoBL().ListadoSituacionAnualSede(Convert.ToInt32(cboEmpresa.EditValue));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptInspeccionTrabajo = new RptVistaReportes();
                        objRptInspeccionTrabajo.VerRptInspeccionTrabajoSituacionAnualSede(lstReporte);
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