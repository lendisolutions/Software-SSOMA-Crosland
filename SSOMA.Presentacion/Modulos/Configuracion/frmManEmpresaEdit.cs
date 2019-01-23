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
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Funciones;
using SSOMA.BusinessLogic;
using SSOMA.BusinessEntity;

namespace SSOMA.Presentacion.Modulos.Configuracion
{
    public partial class frmManEmpresaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

       
        public List<EmpresaBE> lstEmpresa;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdEmpresa = 0;

        public int IdEmpresa
        {
            get { return _IdEmpresa; }
            set { _IdEmpresa = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManEmpresaEdit()
        {
            InitializeComponent();
        }

        private void frmManEmpresaEdit_Load(object sender, EventArgs e)
        {
            txtNumeroTrabajadores.EditValue = 0;

            BSUtils.LoaderLook(cboTipoEmpresa, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoEmpresa), "DescTablaElemento", "IdTablaElemento", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Empresa - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Empresa - Modificar";

                EmpresaBE objE_Empresa = new EmpresaBE();

                objE_Empresa = new EmpresaBL().Selecciona(IdEmpresa);

                IdEmpresa = objE_Empresa.IdEmpresa;
                txtRuc.Text = objE_Empresa.Ruc;
                txtRazonSocial.Text = objE_Empresa.RazonSocial;
                txtDireccion.Text = objE_Empresa.Direccion;
                txtTelefono.Text = objE_Empresa.Telefono;
                txtDireccion.EditValue = objE_Empresa.Direccion;
                txtTelefono.EditValue = objE_Empresa.Telefono;
                txtActividadEconomica.Text = objE_Empresa.ActividadEconomica;
                txtNumeroTrabajadores.EditValue = objE_Empresa.NumeroTrabajadores;
                cboTipoEmpresa.EditValue = objE_Empresa.IdTipoEmpresa;
                if (objE_Empresa.Logo != null)
                {
                    this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Empresa.Logo);
                }
                else
                { this.picImage.Image = SSOMA.Presentacion.Properties.Resources.noImage; }
            }

            txtRuc.Select();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Jpg File|*.Jpg|Jpeg File|*.Jpeg|Png File|*.Png |Gif File|*.Gif|All|*.*";
            openFile.ShowDialog();

            if (openFile.FileName.Length != 0)
            {
                this.picImage.Image = new FuncionBase().ScaleImage(Image.FromFile(openFile.FileName), 640, 500);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.picImage.Image = SSOMA.Presentacion.Properties.Resources.noImage;
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    EmpresaBL objBL_Empresa = new EmpresaBL();
                    EmpresaBE objE_Empresa = new EmpresaBE();

                    objE_Empresa.IdEmpresa = IdEmpresa;
                    objE_Empresa.Ruc = txtRuc.Text;
                    objE_Empresa.RazonSocial = txtRazonSocial.Text;
                    objE_Empresa.Direccion = txtDireccion.Text;
                    objE_Empresa.Telefono = txtTelefono.Text;
                    objE_Empresa.ActividadEconomica = txtActividadEconomica.Text;
                    objE_Empresa.NumeroTrabajadores = Convert.ToInt32(txtNumeroTrabajadores.EditValue);
                    objE_Empresa.IdTipoEmpresa = Convert.ToInt32(cboTipoEmpresa.EditValue);
                    objE_Empresa.Logo = new FuncionBase().Image2Bytes(this.picImage.Image);
                    objE_Empresa.FlagEstado = true;
                    objE_Empresa.Usuario = Parametros.strUsuarioLogin;
                    objE_Empresa.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    List<EmpresaArchivoBE> lstEmpresaArchivo = new List<EmpresaArchivoBE>();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Empresa.Inserta(objE_Empresa, lstEmpresaArchivo);
                    else
                        objBL_Empresa.Actualiza(objE_Empresa, lstEmpresaArchivo);

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

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtRazonSocial.Focus();
            }
        }

        private void txtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtDireccion.Focus();
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtActividadEconomica.Focus();
            }
        }

        private void txtActividadEconomica_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtNumeroTrabajadores.Focus();
            }
        }

        private void txtNumeroTrabajadores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboTipoEmpresa.Focus();
            }
        }

        private void cboTipoEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnGrabar.Focus();
            }
        }


        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtRuc.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el RUC.\n";
                flag = true;
            }

            if (txtRazonSocial.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la razón social.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstEmpresa.Where(oB => oB.Ruc.ToUpper() == txtRuc.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Ruc ya existe.\n";
                    flag = true;
                }

                var BuscarRazonSocial = lstEmpresa.Where(oB => oB.RazonSocial.ToUpper() == txtRazonSocial.Text.ToUpper()).ToList();
                if (BuscarRazonSocial.Count > 0)
                {
                    strMensaje = strMensaje + "- La Razón social ya existe.\n";
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