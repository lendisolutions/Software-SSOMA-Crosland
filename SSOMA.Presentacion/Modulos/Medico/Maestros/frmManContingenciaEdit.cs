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
    public partial class frmManContingenciaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ContingenciaBE> lstContingencia;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ContingenciaBE pContingenciaBE { get; set; }

        int _IdContingencia = 0;

        public int IdContingencia
        {
            get { return _IdContingencia; }
            set { _IdContingencia = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManContingenciaEdit()
        {
            InitializeComponent();
        }

        private void frmManServicioExintorEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Contingencia - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Contingencia - Modificar";
                txtDescripcion.Text = pContingenciaBE.DescContingencia.Trim();

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
                    ContingenciaBL objBL_Contingencia = new ContingenciaBL();
                    ContingenciaBE objContingencia = new ContingenciaBE();
                    objContingencia.IdContingencia = IdContingencia;
                    objContingencia.DescContingencia = txtDescripcion.Text;
                    objContingencia.FlagEstado = true;
                    objContingencia.Usuario = Parametros.strUsuarioLogin;
                    objContingencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objContingencia.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Contingencia.Inserta(objContingencia);
                    else
                        objBL_Contingencia.Actualiza(objContingencia);

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
                var Buscar = lstContingencia.Where(oB => oB.DescContingencia.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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