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

namespace SSOMA.Presentacion.Modulos.Capacitacion.Maestros
{
    public partial class frmManExpositorEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ExpositorBE> lstExpositor;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ExpositorBE pExpositorBE { get; set; }

        int _IdExpositor = 0;

        public int IdExpositor
        {
            get { return _IdExpositor; }
            set { _IdExpositor = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManExpositorEdit()
        {
            InitializeComponent();
        }

        private void frmManExpositorEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Expositor - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Expositor - Modificar";
                txtEmpresa.Text = pExpositorBE.DescEmpresa.Trim();
                txtDescripcion.Text = pExpositorBE.DescExpositor.Trim();
                txtCargo.Text = pExpositorBE.Cargo.Trim();
            }

            txtEmpresa.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ExpositorBL objBL_Expositor = new ExpositorBL();
                    ExpositorBE objExpositor = new ExpositorBE();
                    objExpositor.IdExpositor = IdExpositor;
                    objExpositor.DescEmpresa = txtEmpresa.Text;
                    objExpositor.DescExpositor = txtDescripcion.Text;
                    objExpositor.Cargo = txtCargo.Text;
                    objExpositor.FlagEstado = true;
                    objExpositor.Usuario = Parametros.strUsuarioLogin;
                    objExpositor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objExpositor.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Expositor.Inserta(objExpositor);
                    else
                        objBL_Expositor.Actualiza(objExpositor);

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

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
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
            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstExpositor.Where(oB => oB.DescExpositor.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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