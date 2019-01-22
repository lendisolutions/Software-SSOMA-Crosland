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
using System.Text.RegularExpressions;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Utils;


namespace SSOMA.Presentacion.Modulos.Extintor.Maestros
{
    public partial class frmManProveedorEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ProveedorBE> lstProveedor;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ProveedorBE pProveedorBE { get; set; }

        int _IdProveedor = 0;

        public int IdProveedor
        {
            get { return _IdProveedor; }
            set { _IdProveedor = value; }
        }

        
        string Texto = string.Empty;
        
        #endregion

        #region "Eventos"

        public frmManProveedorEdit()
        {
            InitializeComponent();
        }

        

        private void frmManProveedorEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboDocumento, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoDocumentoProveedor), "Abreviatura", "IdTablaElemento", true);
            cboDocumento.EditValue = Parametros.intPROVRuc;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Proveedor - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Proveedor - Modificar";
                ProveedorBE objE_Proveedor = null;
                objE_Proveedor = new ProveedorBL().Selecciona(Parametros.intEmpresaId, IdProveedor);
                if (objE_Proveedor != null)
                {
                    cboDocumento.EditValue = objE_Proveedor.IdTipoDocumento;
                    txtNumeroDocumento.Text = objE_Proveedor.NumeroDocumento;
                    txtDescripcion.Text = objE_Proveedor.RazonSocial;
                    txtDireccion.Text = objE_Proveedor.Direccion;
                    txtContacto.Text = objE_Proveedor.Contacto;
                    txtTelefono.Text = objE_Proveedor.Telefono;
                    txtCelular.Text = objE_Proveedor.Celular;
                    txtEmail.Text = objE_Proveedor.Email;
                }

            }

            txtNumeroDocumento.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ProveedorBL objBL_Proveedor = new ProveedorBL();
                    ProveedorBE objProveedor = new ProveedorBE();

                    objProveedor.IdProveedor = IdProveedor;
                    objProveedor.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objProveedor.NumeroDocumento = txtNumeroDocumento.Text;
                    objProveedor.RazonSocial = txtDescripcion.Text;
                    objProveedor.Direccion = txtDireccion.Text;
                    objProveedor.Contacto = txtContacto.Text;
                    objProveedor.Telefono = txtTelefono.Text;
                    objProveedor.Celular = txtCelular.Text;
                    objProveedor.Email = txtEmail.Text;
                    objProveedor.FlagEstado = true;
                    objProveedor.Usuario = Parametros.strUsuarioLogin;
                    objProveedor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objProveedor.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Proveedor.Inserta(objProveedor);
                    else
                        objBL_Proveedor.Actualiza(objProveedor);

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
                strMensaje = strMensaje + "- El número de documento.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstProveedor.Where(oB => oB.RazonSocial.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La descripción ya existe.\n";
                    flag = true;
                }
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