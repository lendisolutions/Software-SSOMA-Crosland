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

namespace SSOMA.Presentacion.Modulos.Configuracion
{
    public partial class frmManNegocioEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<NegocioBE> lstNegocio;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public NegocioBE pNegocioBE { get; set; }

        int _IdNegocio = 0;

        public int IdNegocio
        {
            get { return _IdNegocio; }
            set { _IdNegocio = value; }
        }


        #endregion

        #region "Eventos"

        public frmManNegocioEdit()
        {
            InitializeComponent();
        }

        private void frmManNegocioEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Negocio - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Negocio - Modificar";
                txtDescripcion.Text = pNegocioBE.DescNegocio.Trim();

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
                    NegocioBL objBL_Negocio = new NegocioBL();
                    NegocioBE objNegocio = new NegocioBE();
                    objNegocio.IdNegocio = IdNegocio;
                    objNegocio.DescNegocio = txtDescripcion.Text;
                    objNegocio.FlagEstado = true;
                    objNegocio.Usuario = Parametros.strUsuarioLogin;
                    objNegocio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objNegocio.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Negocio.Inserta(objNegocio);
                    else
                        objBL_Negocio.Actualiza(objNegocio);

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
                var Buscar = lstNegocio.Where(oB => oB.DescNegocio.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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