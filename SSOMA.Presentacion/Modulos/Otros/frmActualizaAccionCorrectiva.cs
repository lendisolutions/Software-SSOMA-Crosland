using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Utils;

namespace SSOMA.Presentacion.Modulos.Otros
{
    public partial class frmActualizaAccionCorrectiva : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public int IdAccidenteAccionCorrectiva { get; set; }
        public int IdTipo { get; set; }
        public string strTipo { get; set; }
        public string Numero { get; set; }
        public int Item { get; set; }
        public string strMailTO { get; set; }
        public string strAccionCorrectiva { get; set; }

        #endregion

        #region "Eventos"

        public frmActualizaAccionCorrectiva()
        {
            InitializeComponent();
        }

        private void frmActualizaAccionCorrectiva_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionAccionCorrectiva), "DescTablaElemento", "IdTablaElemento", true);
            cboSituacion.EditValue = Parametros.intACCEjecutado;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                AccidenteAccionCorrectivaBL objBL_AccionCorrectiva = new AccidenteAccionCorrectivaBL();
                objBL_AccionCorrectiva.ActualizaSituacion(IdAccidenteAccionCorrectiva, Convert.ToInt32(cboSituacion.EditValue));

                XtraMessageBox.Show("La Actualización de la situación de la acción correctiva se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

               

                if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intACCEjecutado)
                {
                    StringBuilder strMensaje = new StringBuilder();
                    strMensaje.Append("*****************************************************************************\n\n");
                    strMensaje.Append("La Acción Correctiva del Registro del  " + strTipo + " N°: " + Numero + " " + "se regulizaró correctamente." + "\n\n");
                    strMensaje.Append(strAccionCorrectiva + "\n\n");
                    strMensaje.Append("Emitido Por el Area de Seguridad y Salud en el Trabajo" + "\n\n");
                    strMensaje.Append("*****************************************************************************\n\n");

                    //GENERAR EL REPORTE EN EXCEL
                    BSUtils.ExportarFormatoExcel("", Convert.ToInt32(Numero), IdTipo, false);
                    BSUtils.EmailSend(strMailTO, strTipo + " DE TRABAJO", strMensaje.ToString(), @"D:\" + strTipo + " " + Numero + ".xlsx","", "", "");
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