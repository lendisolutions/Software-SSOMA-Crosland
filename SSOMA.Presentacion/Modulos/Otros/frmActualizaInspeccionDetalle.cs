using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Modulos.Inspeccion.Rpt;

namespace SSOMA.Presentacion.Modulos.Otros
{
    public partial class frmActualizaInspeccionDetalle : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public int IdInspeccionTrabajoDetalle { get; set; }
        public string Numero { get; set; }
        public int Item { get; set; }
        public string strMailTO { get; set; }
        
        #endregion

        #region "Eventos"

        public frmActualizaInspeccionDetalle()
        {
            InitializeComponent();
        }

        private void frmActualizaInspeccionDetalle_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionDetalleInspeccionTrabajo), "DescTablaElemento", "IdTablaElemento", true);
            cboSituacion.EditValue = Parametros.intDITEjecutado;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                InspeccionTrabajoDetalleBL objBL_AccionCorrectiva = new InspeccionTrabajoDetalleBL();
                objBL_AccionCorrectiva.ActualizaSituacion(IdInspeccionTrabajoDetalle, Convert.ToInt32(cboSituacion.EditValue));

                XtraMessageBox.Show("La Actualización de la situación de la acción correctiva se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                StringBuilder strMensaje = new StringBuilder();
                strMensaje.Append("*****************************************************************************\n\n");
                strMensaje.Append("La Condición Insegura N°: " + Numero + " del Item : " + Item.ToString() + "  se regulizaró correctamente." + "\n\n");
                strMensaje.Append("Emitido Por el Area de Seguridad y Salud en el Trabajo" + "\n\n");
                strMensaje.Append("*****************************************************************************\n\n");

                //ELIMINAMOS LOR ARCHIVOS CREADOS
                foreach (var item in Directory.GetFiles(@"D:\", "*.pdf"))
                {
                    File.SetAttributes(item, FileAttributes.Normal);
                    File.Delete(item);
                }

                //GENERAR EL REPORTE EN PDF
                List<ReporteInspeccionTrabajoBE> lstReporteInspeccion = null;
                lstReporteInspeccion = new ReporteInspeccionTrabajoBL().Listado(Convert.ToInt32(Numero));
                rptInspeccionTrabajo objReporte = new rptInspeccionTrabajo();
                objReporte.SetDataSource(lstReporteInspeccion);
                objReporte.ExportToDisk(ExportFormatType.PortableDocFormat, @"D:\" + Numero + ".pdf");

                if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intDITEjecutado)
                {
                    BSUtils.EmailSend(strMailTO, "Inspección Interna de Trabajo", strMensaje.ToString(), @"D:\" + Numero + ".pdf","", "", "");
                }

                this.Close();

            }
            catch (Exception ex)
            {
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