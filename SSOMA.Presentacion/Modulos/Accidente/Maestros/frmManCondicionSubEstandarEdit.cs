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
    public partial class frmManCondicionSubEstandarEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CondicionSubEstandarBE> lstCondicionSubEstandar;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public CondicionSubEstandarBE pCondicionSubEstandarBE { get; set; }

        int _IdCondicionSubEstandar = 0;

        public int IdCondicionSubEstandar
        {
            get { return _IdCondicionSubEstandar; }
            set { _IdCondicionSubEstandar = value; }
        }

        #endregion

        #region "Eventos"

        public frmManCondicionSubEstandarEdit()
        {
            InitializeComponent();
        }

        private void frmManCondicionSubEstandarEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Condición Sub Estandar - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Condición Sub Estandar - Modificar";
                txtDescripcion.Text = pCondicionSubEstandarBE.DescCondicionSubEstandar.Trim();

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
                    CondicionSubEstandarBL objBL_CondicionSubEstandar = new CondicionSubEstandarBL();
                    CondicionSubEstandarBE objCondicionSubEstandar = new CondicionSubEstandarBE();
                    objCondicionSubEstandar.IdCondicionSubEstandar = IdCondicionSubEstandar;
                    objCondicionSubEstandar.DescCondicionSubEstandar = txtDescripcion.Text;
                    objCondicionSubEstandar.FlagEstado = true;
                    objCondicionSubEstandar.Usuario = Parametros.strUsuarioLogin;
                    objCondicionSubEstandar.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objCondicionSubEstandar.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_CondicionSubEstandar.Inserta(objCondicionSubEstandar);
                    else
                        objBL_CondicionSubEstandar.Actualiza(objCondicionSubEstandar);

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
                var Buscar = lstCondicionSubEstandar.Where(oB => oB.DescCondicionSubEstandar.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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