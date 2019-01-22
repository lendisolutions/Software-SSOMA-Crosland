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
    public partial class frmManLugarEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<LugarBE> lstLugar;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public LugarBE pLugarBE { get; set; }

        int _IdLugar = 0;

        public int IdLugar
        {
            get { return _IdLugar; }
            set { _IdLugar = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManLugarEdit()
        {
            InitializeComponent();
        }

        private void frmManLugarEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Lugar - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Lugar - Modificar";
                txtDescripcion.Text = pLugarBE.DescLugar.Trim();

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
                    LugarBL objBL_Lugar = new LugarBL();
                    LugarBE objLugar = new LugarBE();
                    objLugar.IdLugar = IdLugar;
                    objLugar.DescLugar = txtDescripcion.Text;
                    objLugar.FlagEstado = true;
                    objLugar.Usuario = Parametros.strUsuarioLogin;
                    objLugar.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objLugar.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Lugar.Inserta(objLugar);
                    else
                        objBL_Lugar.Actualiza(objLugar);

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
                var Buscar = lstLugar.Where(oB => oB.DescLugar.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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