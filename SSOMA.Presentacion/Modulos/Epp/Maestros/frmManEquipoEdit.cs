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

namespace SSOMA.Presentacion.Modulos.Epp.Maestros
{
    public partial class frmManEquipoEdit : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        public List<EquipoBE> lstEquipo;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public EquipoBE pEquipoBE { get; set; }

        int _IdEquipo = 0;

        public int IdEquipo
        {
            get { return _IdEquipo; }
            set { _IdEquipo = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManEquipoEdit()
        {
            InitializeComponent();
        }

        private void frmManEquipoEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "EPP - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "EPP - Modificar";
                EquipoBE objE_Equipo = null;
                objE_Equipo = new EquipoBL().Selecciona(Parametros.intEmpresaId, IdEquipo);
                if (objE_Equipo != null)
                {
                    
                    txtCodigo.Text = objE_Equipo.Codigo;
                    txtDescripcion.Text = objE_Equipo.DescEquipo;
                    txtPrecioUnitario.EditValue = objE_Equipo.Precio;
                }

            }

            txtCodigo.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    EquipoBL objBL_Equipo = new EquipoBL();
                    EquipoBE objEquipo = new EquipoBE();

                    objEquipo.IdEquipo = IdEquipo;
                    objEquipo.Codigo = txtCodigo.Text;
                    objEquipo.DescEquipo = txtDescripcion.Text;
                    objEquipo.Precio = Convert.ToDecimal(txtPrecioUnitario.EditValue);
                    objEquipo.FlagEstado = true;
                    objEquipo.Usuario = Parametros.strUsuarioLogin;
                    objEquipo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objEquipo.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Equipo.Inserta(objEquipo);
                    else
                        objBL_Equipo.Actualiza(objEquipo);

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

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
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
                txtPrecioUnitario.Focus();
            }
        }
        

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
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
                var Buscar = lstEquipo.Where(oB => oB.DescEquipo.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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