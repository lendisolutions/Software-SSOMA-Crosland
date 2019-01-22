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
using SSOMA.Presentacion.Utils;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;


namespace SSOMA.Presentacion.Modulos.Configuracion
{
    public partial class frmManUnidadMineraEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<UnidadMineraBE> lstUnidadMinera;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public UnidadMineraBE pUnidadMineraBE { get; set; }

        int _IdUnidadMinera = 0;

        public int IdUnidadMinera
        {
            get { return _IdUnidadMinera; }
            set { _IdUnidadMinera = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManUnidadMineraEdit()
        {
            InitializeComponent();
        }

        private void frmManUnidadMineraEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Sede - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Sede - Modificar";
                cboEmpresa.EditValue = pUnidadMineraBE.IdEmpresa;
                txtDescripcion.Text = pUnidadMineraBE.DescUnidadMinera.Trim();

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
                    UnidadMineraBL objBL_UnidadMinera = new UnidadMineraBL();
                    UnidadMineraBE objUnidadMinera = new UnidadMineraBE();
                    objUnidadMinera.IdUnidadMinera = IdUnidadMinera;
                    objUnidadMinera.DescUnidadMinera = txtDescripcion.Text;
                    objUnidadMinera.FlagEstado = true;
                    objUnidadMinera.Usuario = Parametros.strUsuarioLogin;
                    objUnidadMinera.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objUnidadMinera.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                    if (pOperacion == Operacion.Nuevo)
                        objBL_UnidadMinera.Inserta(objUnidadMinera);
                    else
                        objBL_UnidadMinera.Actualiza(objUnidadMinera);

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
                var Buscar = lstUnidadMinera.Where(oB => oB.DescUnidadMinera.ToUpper() == txtDescripcion.Text.ToUpper() && oB.IdEmpresa == Convert.ToInt32(cboEmpresa.EditValue)).ToList();
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
