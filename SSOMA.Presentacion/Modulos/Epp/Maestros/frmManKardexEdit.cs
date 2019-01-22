using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SSOMA.Presentacion.Modulos.Otros;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Utils;

namespace SSOMA.Presentacion.Modulos.Epp.Maestros
{
    public partial class frmManKardexEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public KardexBE pKardexBE { get; set; }

        public int IdKardex { get; set; }
        public int IdEmpresa { get; set; }
        public int IdUnidadMinera { get; set; }
        public String DescOrdenInterna { get; set; }

        int IdEquipo = 0;

        #endregion

        #region "Eventos"

        public frmManKardexEdit()
        {
            InitializeComponent();
        }

        private void frmManKardexEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue =IdEmpresa;

            deFecha.DateTime = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Kardex - Nuevo";
                txtOrdenInterna.Text = DescOrdenInterna;
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Kardex - Modificar";
                KardexBE objE_Kardex = null;
                objE_Kardex = new KardexBL().Selecciona(IdKardex);
                if (objE_Kardex != null)
                {
                    cboEmpresa.EditValue = objE_Kardex.IdEmpresa;
                    cboUnidadMinera.EditValue = objE_Kardex.IdUnidadMinera;
                    txtOrdenInterna.Text = objE_Kardex.DescOrdenInterna;
                    deFecha.EditValue = objE_Kardex.FechaMovimiento;
                    txtNumeroDocumento.Text = objE_Kardex.NumeroDocumento;
                    IdEquipo = objE_Kardex.IdEquipo;
                    txtCodigo.Text = objE_Kardex.Codigo;
                    txtDescEquipo.Text = objE_Kardex.DescEquipo;
                    txtCantidad.EditValue = objE_Kardex.Cantidad;
                    txtObservacion.Text = objE_Kardex.Observacion;
                }

            }

            deFecha.Select();
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
                cboUnidadMinera.EditValue = IdUnidadMinera;
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaEquipo objBusEquipoPreVenta = new frmBuscaEquipo();
                objBusEquipoPreVenta.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                objBusEquipoPreVenta.pFlagMultiSelect = false;
                objBusEquipoPreVenta.ShowDialog();
                if (objBusEquipoPreVenta.pEquipoBE != null)
                {
                    IdEquipo = objBusEquipoPreVenta.pEquipoBE.IdEquipo;
                    txtCodigo.Text = objBusEquipoPreVenta.pEquipoBE.Codigo;
                    txtDescEquipo.Text = objBusEquipoPreVenta.pEquipoBE.DescEquipo;
                    txtCantidad.EditValue = 1;

                }

                txtObservacion.Focus();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    KardexBL objBL_Kardex = new KardexBL();

                    KardexBE objKardex = new KardexBE();
                    objKardex.IdKardex = IdKardex;
                    objKardex.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objKardex.IdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
                    objKardex.DescOrdenInterna = txtOrdenInterna.Text;
                    objKardex.IdEquipo = IdEquipo;
                    objKardex.Periodo = deFecha.DateTime.Year;
                    objKardex.FechaMovimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objKardex.Cantidad = Convert.ToDecimal(txtCantidad.EditValue);
                    objKardex.NumeroDocumento = txtNumeroDocumento.Text;
                    objKardex.TipoMovimiento = "I";
                    objKardex.Observacion = txtObservacion.Text;
                    objKardex.FlagEstado = true;
                    objKardex.Usuario = Parametros.strUsuarioLogin;
                    objKardex.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Kardex.Inserta(objKardex);
                    else
                        objBL_Kardex.Actualiza(objKardex);

                    this.Close();
                }
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

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtNumeroDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el número de documento.\n";
                flag = true;
            }

            if (txtNumeroDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el número de documento.\n";
                flag = true;
            }

            if (IdEquipo == 0)
            {
                strMensaje = strMensaje + "- Seleccione el EPP's.\n";
                flag = true;
            }

            if (txtObservacion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la observación.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        #endregion


    }
}