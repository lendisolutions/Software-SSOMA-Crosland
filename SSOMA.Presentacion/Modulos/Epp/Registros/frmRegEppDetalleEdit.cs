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
    public partial class frmRegEppDetalleEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public EppDetalleBE oBE;

        public int intCorrelativo = 0;

        public int IdEpp = 0;
        public int IdEppDetalle = 0;

        public int IdEquipo = 0;


        public bool bNuevo = true;
        
        #endregion

        #region "Eventos"

        public frmRegEppDetalleEdit()
        {
            InitializeComponent();
        }

        private void frmRegEppDetalleEdit_Load(object sender, EventArgs e)
        {
            deFechaVencimiento.EditValue = DateTime.Now.AddDays(90);
            BSUtils.LoaderLook(cboTipoEntrega, new TipoEntregaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTipoEntrega", "IdTipoEntrega", true);
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
                    txtPrecio.EditValue = objBusEquipoPreVenta.pEquipoBE.Precio;
                    txtTotal.EditValue = Convert.ToDecimal(txtPrecio.Text) * Convert.ToDecimal(txtCantidad.Text);

                    deFechaVencimiento.SelectAll();
                    deFechaVencimiento.Focus();
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCantidad_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCantidad.EditValue) > 0)
            {
                txtTotal.EditValue = Convert.ToDecimal(txtPrecio.Text) * Convert.ToDecimal(txtCantidad.Text);
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

                oBE = new EppDetalleBE();
                oBE.IdEquipo = IdEquipo;
                oBE.Item = intCorrelativo;
                oBE.Codigo = txtCodigo.Text.Trim();
                oBE.DescEquipo = txtDescEquipo.Text.Trim();
                oBE.FechaVencimiento = Convert.ToDateTime(deFechaVencimiento.DateTime.ToShortDateString());
                oBE.Cantidad = Convert.ToInt32(txtCantidad.Text);
                oBE.Precio = Convert.ToDecimal(txtPrecio.Text);
                oBE.Total = Convert.ToDecimal(txtTotal.Text);
                oBE.IdTipoEntrega = Convert.ToInt32(cboTipoEntrega.EditValue);
                oBE.DescTipoEntrega = cboTipoEntrega.Text;

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