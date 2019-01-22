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


namespace SSOMA.Presentacion.Modulos.Medico.Maestros
{
    public partial class frmManTipoDescansoMedicoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TipoDescansoMedicoBE> lstTipoDescansoMedico;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TipoDescansoMedicoBE pTipoDescansoMedicoBE { get; set; }

        int _IdTipoDescansoMedico = 0;

        public int IdTipoDescansoMedico
        {
            get { return _IdTipoDescansoMedico; }
            set { _IdTipoDescansoMedico = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManTipoDescansoMedicoEdit()
        {
            InitializeComponent();
        }

        private void frmManTipoDescansoMedicoEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Tipo de Descanso Médico - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Tipo de Descanso Médico - Modificar";
                txtDescripcion.Text = pTipoDescansoMedicoBE.DescTipoDescansoMedico.Trim();

            }

            txtDescripcion.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    TipoDescansoMedicoBL objBL_TipoDescansoMedico = new TipoDescansoMedicoBL();
                    TipoDescansoMedicoBE objTipoDescansoMedico = new TipoDescansoMedicoBE();
                    objTipoDescansoMedico.IdTipoDescansoMedico = IdTipoDescansoMedico;
                    objTipoDescansoMedico.DescTipoDescansoMedico = txtDescripcion.Text;
                    objTipoDescansoMedico.FlagEstado = true;
                    objTipoDescansoMedico.Usuario = Parametros.strUsuarioLogin;
                    objTipoDescansoMedico.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objTipoDescansoMedico.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_TipoDescansoMedico.Inserta(objTipoDescansoMedico);
                    else
                        objBL_TipoDescansoMedico.Actualiza(objTipoDescansoMedico);

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
                var Buscar = lstTipoDescansoMedico.Where(oB => oB.DescTipoDescansoMedico.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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