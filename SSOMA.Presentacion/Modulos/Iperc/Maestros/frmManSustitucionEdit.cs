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


namespace SSOMA.Presentacion.Modulos.Iperc.Maestros
{
    public partial class frmManSustitucionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<SustitucionBE> lstSustitucion;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public SustitucionBE pSustitucionBE { get; set; }

        int _IdSustitucion = 0;

        public int IdSustitucion
        {
            get { return _IdSustitucion; }
            set { _IdSustitucion = value; }
        }

        #endregion

        #region "Eventos"

        public frmManSustitucionEdit()
        {
            InitializeComponent();
        }

        private void frmManSustitucionEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Sustitución - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Sustitución - Modificar";
                txtDescripcion.Text = pSustitucionBE.DescSustitucion.Trim();

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
                    SustitucionBL objBL_Sustitucion = new SustitucionBL();
                    SustitucionBE objSustitucion = new SustitucionBE();
                    objSustitucion.IdSustitucion = IdSustitucion;
                    objSustitucion.DescSustitucion = txtDescripcion.Text;
                    objSustitucion.FlagEstado = true;
                    objSustitucion.Usuario = Parametros.strUsuarioLogin;
                    objSustitucion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objSustitucion.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Sustitucion.Inserta(objSustitucion);
                    else
                        objBL_Sustitucion.Actualiza(objSustitucion);

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
                var Buscar = lstSustitucion.Where(oB => oB.DescSustitucion.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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