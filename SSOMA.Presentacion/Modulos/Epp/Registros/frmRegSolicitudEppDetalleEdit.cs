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
using SSOMA.Presentacion.Modulos.Otros;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Epp.Registros
{
    public partial class frmRegSolicitudEppDetalleEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public SolicitudEppDetalleBE oBE;

        public int intCorrelativo = 0;

        public int IdSolicitudEpp = 0;
        public int IdSolicitudEppDetalle = 0;

        public int IdEquipo = 0;


        public bool bNuevo = true;
        
        #endregion

        #region "Eventos"

        public frmRegSolicitudEppDetalleEdit()
        {
            InitializeComponent();
        }

        private void frmRegSolicitudEppDetalleEdit_Load(object sender, EventArgs e)
        {
            btnBuscarProducto.Focus();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaEquipo objBusEquipoPreVenta = new frmBuscaEquipo();
                objBusEquipoPreVenta.IdEmpresa = Parametros.intEmpresaId;
                objBusEquipoPreVenta.pFlagMultiSelect = false;
                objBusEquipoPreVenta.ShowDialog();
                if (objBusEquipoPreVenta.pEquipoBE != null)
                {
                    IdEquipo = objBusEquipoPreVenta.pEquipoBE.IdEquipo;
                    txtCodigo.Text = objBusEquipoPreVenta.pEquipoBE.Codigo;
                    txtDescEquipo.Text = objBusEquipoPreVenta.pEquipoBE.DescEquipo;
                    txtCantidad.EditValue = 1;
                   
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                if (IdEquipo == 0)
                {
                    XtraMessageBox.Show("Seleccionar un EPP", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnBuscarProducto.Focus();
                    return;
                }

                if (Convert.ToInt32(txtCantidad.EditValue) == 0)
                {
                    XtraMessageBox.Show("La cantidad no puede ser 0", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCantidad.SelectAll();
                    txtCantidad.Focus();
                    return;
                }

                oBE = new SolicitudEppDetalleBE();
                oBE.IdSolicitudEpp = IdSolicitudEpp;
                oBE.IdSolicitudEppDetalle = IdSolicitudEppDetalle;
                oBE.IdEquipo = IdEquipo;
                oBE.IdEmpresa = Parametros.intEmpresaId;
                oBE.Item = intCorrelativo;
                oBE.Codigo = txtCodigo.Text.Trim();
                oBE.DescEquipo = txtDescEquipo.Text.Trim();
                oBE.Cantidad = Convert.ToInt32(txtCantidad.Text);
              
                this.DialogResult = DialogResult.OK;

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