using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SSOMA.Presentacion.Utils;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Otros
{
    public partial class frmSeleccionaEmpresa : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public int intIdEmpresa { get; set; }
        public int intIdUnidadMinera { get; set; }

        #endregion

        #region "Eventos"

        public frmSeleccionaEmpresa()
        {
            InitializeComponent();
        }

        private void frmSeleccionaEmpresa_Load(object sender, EventArgs e)
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            intIdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
            intIdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
            this.DialogResult = DialogResult.Yes;
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