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
    public partial class frmManTipoCapacitacionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TipoCapacitacionBE> lstTipoCapacitacion;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TipoCapacitacionBE pTipoCapacitacionBE { get; set; }

        int _IdTipoCapacitacion = 0;

        public int IdTipoCapacitacion
        {
            get { return _IdTipoCapacitacion; }
            set { _IdTipoCapacitacion = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManTipoCapacitacionEdit()
        {
            InitializeComponent();
        }

        private void frmManTipoCapacitacionEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Tipo de Capacitacion - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Tipo de Capacitacion - Modificar";
                txtDescripcion.Text = pTipoCapacitacionBE.DescTipoCapacitacion.Trim();

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
                    TipoCapacitacionBL objBL_TipoCapacitacion = new TipoCapacitacionBL();
                    TipoCapacitacionBE objTipoCapacitacion = new TipoCapacitacionBE();
                    objTipoCapacitacion.IdTipoCapacitacion = IdTipoCapacitacion;
                    objTipoCapacitacion.DescTipoCapacitacion = txtDescripcion.Text;
                    objTipoCapacitacion.FlagEstado = true;
                    objTipoCapacitacion.Usuario = Parametros.strUsuarioLogin;
                    objTipoCapacitacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objTipoCapacitacion.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_TipoCapacitacion.Inserta(objTipoCapacitacion);
                    else
                        objBL_TipoCapacitacion.Actualiza(objTipoCapacitacion);

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
                var Buscar = lstTipoCapacitacion.Where(oB => oB.DescTipoCapacitacion.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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