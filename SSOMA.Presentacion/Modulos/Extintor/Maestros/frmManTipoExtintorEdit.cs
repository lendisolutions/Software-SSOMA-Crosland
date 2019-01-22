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

namespace SSOMA.Presentacion.Modulos.Extintor.Maestros
{
    public partial class frmManTipoExtintorEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TipoExtintorBE> lstTipoExtintor;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TipoExtintorBE pTipoExtintorBE { get; set; }

        int _IdTipoExtintor = 0;

        public int IdTipoExtintor
        {
            get { return _IdTipoExtintor; }
            set { _IdTipoExtintor = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManTipoExtintorEdit()
        {
            InitializeComponent();
        }

        private void frmManTipoExtintorEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Clasificacion Inspección - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Clasificacion Inspección - Modificar";
                txtAbreviatura.Text = pTipoExtintorBE.Abreviatura.Trim();
                txtDescripcion.Text = pTipoExtintorBE.DescTipoExtintor.Trim();

            }

            txtAbreviatura.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    TipoExtintorBL objBL_TipoExtintor = new TipoExtintorBL();
                    TipoExtintorBE objTipoExtintor = new TipoExtintorBE();
                    objTipoExtintor.IdTipoExtintor = IdTipoExtintor;
                    objTipoExtintor.Abreviatura = txtAbreviatura.Text;
                    objTipoExtintor.DescTipoExtintor = txtDescripcion.Text;
                    objTipoExtintor.FlagEstado = true;
                    objTipoExtintor.Usuario = Parametros.strUsuarioLogin;
                    objTipoExtintor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objTipoExtintor.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_TipoExtintor.Inserta(objTipoExtintor);
                    else
                        objBL_TipoExtintor.Actualiza(objTipoExtintor);

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

        private void txtAbreviatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtDescripcion.Focus();
            }
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

            if (txtAbreviatura.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la Abreviatura.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstTipoExtintor.Where(oB => oB.DescTipoExtintor.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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