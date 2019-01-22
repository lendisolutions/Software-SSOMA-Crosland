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
    public partial class frmManActoSubEstandarEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ActoSubEstandarBE> lstActoSubEstandar;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ActoSubEstandarBE pActoSubEstandarBE { get; set; }

        int _IdActoSubEstandar = 0;

        public int IdActoSubEstandar
        {
            get { return _IdActoSubEstandar; }
            set { _IdActoSubEstandar = value; }
        }

        #endregion

        #region "Eventos"

        public frmManActoSubEstandarEdit()
        {
            InitializeComponent();
        }

        private void frmManActoSubEstandarEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Acto Sub Estandar - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Acto Sub Estandar - Modificar";
                txtDescripcion.Text = pActoSubEstandarBE.DescActoSubEstandar.Trim();

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
                    ActoSubEstandarBL objBL_ActoSubEstandar = new ActoSubEstandarBL();
                    ActoSubEstandarBE objActoSubEstandar = new ActoSubEstandarBE();
                    objActoSubEstandar.IdActoSubEstandar = IdActoSubEstandar;
                    objActoSubEstandar.DescActoSubEstandar = txtDescripcion.Text;
                    objActoSubEstandar.FlagEstado = true;
                    objActoSubEstandar.Usuario = Parametros.strUsuarioLogin;
                    objActoSubEstandar.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objActoSubEstandar.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_ActoSubEstandar.Inserta(objActoSubEstandar);
                    else
                        objBL_ActoSubEstandar.Actualiza(objActoSubEstandar);

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
                var Buscar = lstActoSubEstandar.Where(oB => oB.DescActoSubEstandar.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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