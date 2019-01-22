using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Configuration;
using System.Collections.Specialized;
using DevExpress.XtraEditors;
using SSOMA.Presentacion.Criptografia;
using SSOMA.Presentacion.Utils;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Inicio
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
            }
        }

        private void cboEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboUnidadMinera.Focus();
            }
        }

        private void cboUnidadMinera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtUsuario.Focus();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtContraseña.Focus();
            }
        }

        private void txtContraseña_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnIngresar_Click(sender,e);
            }
        }

        

        #endregion

        #region "Metodos"

        private void CargarControles()
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            txtUsuario.Text = ConfigurationManager.AppSettings.Get("Usuario");
            txtContraseña.Text = ConfigurationManager.AppSettings.Get("Clave");

            if (txtContraseña.Text.Trim().Length > 0)
            {
                txtContraseña.Focus();
            }
            else
                txtUsuario.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cboEmpresa.Text))
                {
                    XtraMessageBox.Show("Seleccione la empresa", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboEmpresa.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(cboUnidadMinera.Text))
                {
                    XtraMessageBox.Show("Seleccione la unidad minera", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboEmpresa.Focus();
                    return;
                }

                if (txtUsuario.Text.Trim().Length == 0)
                {
                    XtraMessageBox.Show("Ingrese el usuario.", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUsuario.Focus();
                    return;
                }

                if (txtContraseña.Text.Trim().Length == 0)
                {
                    XtraMessageBox.Show("Ingrese la contraseña.", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtContraseña.Focus();
                    return;
                }

                

                Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                objCrypto.Key = Parametros.Key;
                objCrypto.IV = Parametros.IV;

                string _password = objCrypto.CifrarCadena(txtContraseña.Text.ToString());
                UsuarioBE objE_Usuario = new UsuarioBL().LogOnUser(txtUsuario.Text.ToString().Trim(), _password);
                if (objE_Usuario != null)
                {
                    List<UsuarioUnidadMineraBE> lstUsuarioUnidadMinera = null;
                    lstUsuarioUnidadMinera = new UsuarioUnidadMineraBL().ListaEmpresaUnidadUusuario(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboUnidadMinera.EditValue), objE_Usuario.IdUser);
                    if (lstUsuarioUnidadMinera.Count == 0)
                    {
                        XtraMessageBox.Show("El usuario no tiene permiso para ver la unidad seleccionada", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboUnidadMinera.Focus();
                        return;
                    }

                    Parametros.intPerfilId = objE_Usuario.IdPerfil;
                    Parametros.strNomPerfil = objE_Usuario.DescPerfil;
                    Parametros.intEmpresaId = int.Parse(cboEmpresa.EditValue.ToString());
                    Parametros.intUnidadMineraId = int.Parse(cboUnidadMinera.EditValue.ToString());
                    Parametros.strEmpresaNombre = cboEmpresa.Text;
                    Parametros.strUnidadNombre = cboUnidadMinera.Text;
                    Parametros.intUsuarioId = objE_Usuario.IdUser;
                    Parametros.strUsuarioLogin = objE_Usuario.Usuario;
                    Parametros.strUsuarioNombres = objE_Usuario.Descripcion;

                    //GUARDAR EN EL APP.Config
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["Usuario"].Value = txtUsuario.Text.Trim();
                    config.AppSettings.Settings["Clave"].Value = txtContraseña.Text.Trim();
                    config.Save(ConfigurationSaveMode.Modified);

                    //Obtenemos el area del usuario logueado

                    PersonaBE objE_Persona = null;
                    objE_Persona = new PersonaBL().SeleccionaDescripcion(0, 0, 0, objE_Usuario.Descripcion);
                    if (objE_Persona != null)
                    {
                        Parametros.intPersonaId = objE_Persona.IdPersona;
                        Parametros.intAreaId = objE_Persona.IdArea;
                    }

                    //Obtenemos todos los permisos del usuario logueado
                    Parametros.pListaPermisoAcceso = new AccesoUsuarioBL().SeleccionaPermisoAcceso(objE_Usuario.Usuario, objE_Usuario.IdPerfil).ToList();

                    //SERVICIO WEB DE ACTUALIZACIÓN DE PERSONAL DE LA EMPRESA
                    //ServiceReference.InformacionClient servicio = new ServiceReference.InformacionClient();
                    //var data = servicio.ObtenerTrabajadores().ToList();


                    this.DialogResult = DialogResult.Yes;
                }
                else
                {
                    XtraMessageBox.Show("Usuario / Clave incorrecta.", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        #endregion

        
    }
}