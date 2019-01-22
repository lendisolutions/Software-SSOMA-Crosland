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


namespace SSOMA.Presentacion.Modulos.Medico.Maestros
{
    public partial class frmManCategoriaDiagnosticoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CategoriaDiagnosticoBE> lstCategoriaDiagnostico;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public CategoriaDiagnosticoBE pCategoriaDiagnosticoBE { get; set; }

        int _IdCategoriaDiagnostico = 0;

        public int IdCategoriaDiagnostico
        {
            get { return _IdCategoriaDiagnostico; }
            set { _IdCategoriaDiagnostico = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManCategoriaDiagnosticoEdit()
        {
            InitializeComponent();
        }

        private void frmManServicioExintorEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "CategoriaDiagnostico - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "CategoriaDiagnostico - Modificar";
                txtDescripcion.Text = pCategoriaDiagnosticoBE.DescCategoriaDiagnostico.Trim();
                txtAbreviatura.Text = pCategoriaDiagnosticoBE.Abreviatura.Trim();

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
                    CategoriaDiagnosticoBL objBL_CategoriaDiagnostico = new CategoriaDiagnosticoBL();
                    CategoriaDiagnosticoBE objCategoriaDiagnostico = new CategoriaDiagnosticoBE();
                    objCategoriaDiagnostico.IdCategoriaDiagnostico = IdCategoriaDiagnostico;
                    objCategoriaDiagnostico.Abreviatura = txtAbreviatura.Text;
                    objCategoriaDiagnostico.DescCategoriaDiagnostico = txtDescripcion.Text;
                    objCategoriaDiagnostico.FlagEstado = true;
                    objCategoriaDiagnostico.Usuario = Parametros.strUsuarioLogin;
                    objCategoriaDiagnostico.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objCategoriaDiagnostico.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_CategoriaDiagnostico.Inserta(objCategoriaDiagnostico);
                    else
                        objBL_CategoriaDiagnostico.Actualiza(objCategoriaDiagnostico);

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
                var Buscar = lstCategoriaDiagnostico.Where(oB => oB.DescCategoriaDiagnostico.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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