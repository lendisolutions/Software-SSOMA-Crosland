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
    public partial class frmManTemaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TemaBE> lstTema;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TemaBE pTemaBE { get; set; }

        int _IdTema = 0;

        public int IdTema
        {
            get { return _IdTema; }
            set { _IdTema = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManTemaEdit()
        {
            InitializeComponent();
        }

        private void frmManTemaEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Tema - Nuevo";
                txtPeriodo.EditValue = Parametros.intPeriodo;
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Tema - Modificar";
                txtPeriodo.EditValue = pTemaBE.Periodo;
                txtDescripcion.Text = pTemaBE.DescTema.Trim();

            }

            txtPeriodo.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    TemaBL objBL_Tema = new TemaBL();
                    TemaBE objTema = new TemaBE();
                    objTema.IdTema = IdTema;
                    objTema.Periodo = Convert.ToInt32(txtPeriodo.EditValue);
                    objTema.DescTema = txtDescripcion.Text;
                    objTema.FlagEstado = true;
                    objTema.Usuario = Parametros.strUsuarioLogin;
                    objTema.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objTema.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Tema.Inserta(objTema);
                    else
                        objBL_Tema.Actualiza(objTema);

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
                var Buscar = lstTema.Where(oB => oB.DescTema.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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