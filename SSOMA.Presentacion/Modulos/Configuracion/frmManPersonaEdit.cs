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
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Utils;

namespace SSOMA.Presentacion.Modulos.Configuracion
{
    public partial class frmManPersonaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PersonaBE> lstPersona;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public PersonaBE pPersonaBE { get; set; }

        int _IdEmpresa = 0;

        public int IdEmpresa
        {
            get { return _IdEmpresa; }
            set { _IdEmpresa = value; }
        }

        int _IdUnidadMinera = 0;

        public int IdUnidadMinera
        {
            get { return _IdUnidadMinera; }
            set { _IdUnidadMinera = value; }
        }

        int _IdArea = 0;

        public int IdArea
        {
            get { return _IdArea; }
            set { _IdArea = value; }
        }

        int _IdPersona = 0;

        public int IdPersona
        {
            get { return _IdPersona; }
            set { _IdPersona = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManPersonaEdit()
        {
            InitializeComponent();
        }

        private void frmManPersonaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = IdEmpresa;
            BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
            cboUnidadMinera.EditValue = IdUnidadMinera;
            BSUtils.LoaderLook(cboArea, new AreaBL().ListaTodosActivo(IdEmpresa, IdUnidadMinera), "DescArea", "IdArea", true);
            cboArea.EditValue = IdArea;

            BSUtils.LoaderLook(cboEstadoCivil, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblEstadoCivil), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboTipoContrato, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoContrato), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionPersona), "DescTablaElemento", "IdTablaElemento", true);

            deFechaNacimiento.EditValue = DateTime.Now;
            deFechaIngreso.EditValue = DateTime.Now;

            txtEdad.EditValue = 0;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Persona - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Persona - Modificar";
                PersonaBE objE_Persona = null;
                objE_Persona = new PersonaBL().Selecciona(IdEmpresa, IdUnidadMinera, IdArea, IdPersona);
                if (objE_Persona != null)
                {
                    cboEmpresa.EditValue = objE_Persona.IdEmpresa;
                    cboUnidadMinera.EditValue = objE_Persona.IdUnidadMinera;
                    cboArea.EditValue = objE_Persona.IdArea;
                    txtDni.Text = objE_Persona.Dni.Trim();
                    txtApeNom.Text = objE_Persona.ApeNom.Trim();
                    deFechaNacimiento.EditValue = objE_Persona.FechaNacimiento;
                    txtEdad.EditValue = objE_Persona.Edad;
                    deFechaIngreso.EditValue = objE_Persona.FechaIngreso;
                    deFechaCese.EditValue = objE_Persona.FechaCese;
                    txtCargo.Text = objE_Persona.Cargo.Trim();
                    txtSexo.Text = objE_Persona.Sexo;
                    cboTipoContrato.EditValue = objE_Persona.IdTipoContrato;
                    cboEstadoCivil.EditValue = objE_Persona.IdEstadoCivil;
                    txtEmail.Text = objE_Persona.Email;
                    cboSituacion.EditValue = objE_Persona.IdSituacion;
                }

            }

            txtDni.Select();
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
                cboUnidadMinera.EditValue = IdUnidadMinera;
            }
        }

        private void cboUnidadMinera_EditValueChanged(object sender, EventArgs e)
        {
            if (cboUnidadMinera.EditValue != null)
            {
                BSUtils.LoaderLook(cboArea, new AreaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboUnidadMinera.EditValue)), "DescArea", "IdArea", true);
                cboArea.EditValue = IdArea;
            }
        }

        
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PersonaBL objBL_Persona = new PersonaBL();
                    PersonaBE objPersona= new PersonaBE();

                    objPersona.IdPersona = IdPersona;
                    objPersona.IdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
                    objPersona.IdArea = Convert.ToInt32(cboArea.EditValue);
                    objPersona.IdContratista = (Int32?)null;
                    objPersona.Dni = txtDni.Text;
                    objPersona.ApeNom = txtApeNom.Text;
                    objPersona.FechaNacimiento = Convert.ToDateTime(deFechaNacimiento.DateTime.ToShortDateString());
                    objPersona.Edad = Convert.ToInt32(txtEdad.EditValue);
                    objPersona.FechaIngreso = Convert.ToDateTime(deFechaIngreso.DateTime.ToShortDateString());
                    objPersona.FechaCese = deFechaCese.DateTime.Year == 1 ? (DateTime?)null : Convert.ToDateTime(deFechaCese.DateTime.ToShortDateString());
                    objPersona.Cargo = txtCargo.Text;
                    objPersona.Sexo = txtSexo.Text;
                    objPersona.IdTipoContrato = Convert.ToInt32(cboTipoContrato.EditValue);
                    objPersona.IdEstadoCivil = Convert.ToInt32(cboEstadoCivil.EditValue);
                    objPersona.Email = txtEmail.Text;
                    objPersona.FlagCapacitacion = false;
                    objPersona.Sctr = "";
                    objPersona.FechaSctrIni = DateTime.Now;
                    objPersona.FechaSctrFin = DateTime.Now;
                    objPersona.Observacion = "";
                    objPersona.IdSituacion = Convert.ToInt32(cboSituacion.EditValue);
                    objPersona.FlagEstado = true;
                    objPersona.Usuario = Parametros.strUsuarioLogin;
                    objPersona.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPersona.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                    List<PersonaArchivoBE> lstPersonaArchivo = new List<PersonaArchivoBE>();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Persona.Inserta(objPersona, lstPersonaArchivo);
                    else
                        objBL_Persona.Actualiza(objPersona, lstPersonaArchivo);

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
                cboArea.Focus();
            }
        }

        private void cboArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtDni.Focus();
            }
        }


        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtApeNom.Focus();
            }
        }

        private void txtApeNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                deFechaNacimiento.Focus();
            }
        }

        private void deFechaNacimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtEdad.Focus();
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                deFechaIngreso.Focus();
            }
        }

        private void deFechaIngreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtCargo.Focus();
            }
        }

        private void txtCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtSexo.Focus();
            }
        }

        private void txtSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboEstadoCivil.Focus();
            }
        }

        private void cboEstadoCivil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboTipoContrato.Focus();
            }
        }

        private void cboTipoContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
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
            if (txtApeNom.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            //calcular edad;
            int intEdad = 0;
            intEdad = DateTime.Today.AddTicks(-deFechaNacimiento.DateTime.Ticks).Year - 1;
            txtEdad.EditValue = intEdad;

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstPersona.Where(oB => oB.ApeNom.ToUpper() == txtApeNom.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- Los Apellidos y Nombres ya existe.\n";
                    flag = true;
                }

                var BuscarDni = lstPersona.Where(oB => oB.Dni.ToUpper() == txtDni.Text.ToUpper()).ToList();
                if (BuscarDni.Count > 0)
                {
                    strMensaje = strMensaje + "- El DNI ya existe.\n";
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