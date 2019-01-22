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
    public partial class frmManAreaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<AreaBE> lstArea;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public AreaBE pAreaBE { get; set; }

        
        int _IdArea = 0;

        public int IdArea
        {
            get { return _IdArea; }
            set { _IdArea = value; }
        }

        #endregion

        #region "Eventos"

        public frmManAreaEdit()
        {
            InitializeComponent();
        }

        private void frmManAreaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaCombo(Parametros.intEmpresaId, Parametros.intUnidadMineraId), "DescUnidadMinera", "IdUnidadMinera", true);
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Area - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Area - Modificar";
                AreaBE objE_Area = null;
                objE_Area = new AreaBL().Selecciona(Parametros.intEmpresaId, Parametros.intUnidadMineraId,  IdArea);
                if (objE_Area != null)
                {
                    cboUnidadMinera.EditValue = objE_Area.IdUnidadMinera;
                    txtDescripcion.Text = objE_Area.DescArea.Trim();
                }

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
                    AreaBL objBL_Area = new AreaBL();
                    AreaBE objArea = new AreaBE();

                    objArea.IdArea = IdArea;
                    objArea.IdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
                    objArea.DescArea = txtDescripcion.Text;
                    objArea.FlagEstado = true;
                    objArea.Usuario = Parametros.strUsuarioLogin;
                    objArea.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objArea.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Area.Inserta(objArea);
                    else
                        objBL_Area.Actualiza(objArea);

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

        private void cboUnidadMinera_KeyPress(object sender, KeyPressEventArgs e)
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
            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstArea.Where(oB => oB.DescArea.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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
