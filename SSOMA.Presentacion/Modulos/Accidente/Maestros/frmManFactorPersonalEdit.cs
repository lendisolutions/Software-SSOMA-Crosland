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

namespace SSOMA.Presentacion.Modulos.Accidente.Maestros
{
    public partial class frmManFactorPersonalEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<FactorPersonalBE> lstFactorPersonal;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public FactorPersonalBE pFactorPersonalBE { get; set; }

        int _IdFactorPersonal = 0;

        public int IdFactorPersonal
        {
            get { return _IdFactorPersonal; }
            set { _IdFactorPersonal = value; }
        }

        #endregion

        #region "Eventos"

        public frmManFactorPersonalEdit()
        {
            InitializeComponent();
        }

        private void frmManFactorPersonalEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Factor Personal - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Factor Personal - Modificar";
                txtDescripcion.Text = pFactorPersonalBE.DescFactorPersonal.Trim();

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
                    FactorPersonalBL objBL_FactorPersonal = new FactorPersonalBL();
                    FactorPersonalBE objFactorPersonal = new FactorPersonalBE();
                    objFactorPersonal.IdFactorPersonal = IdFactorPersonal;
                    objFactorPersonal.DescFactorPersonal = txtDescripcion.Text;
                    objFactorPersonal.FlagEstado = true;
                    objFactorPersonal.Usuario = Parametros.strUsuarioLogin;
                    objFactorPersonal.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objFactorPersonal.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_FactorPersonal.Inserta(objFactorPersonal);
                    else
                        objBL_FactorPersonal.Actualiza(objFactorPersonal);

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
                var Buscar = lstFactorPersonal.Where(oB => oB.DescFactorPersonal.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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