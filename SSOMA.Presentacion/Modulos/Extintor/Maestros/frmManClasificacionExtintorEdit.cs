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

namespace SSOMA.Presentacion.Modulos.Extintor.Maestros
{
    public partial class frmManClasificacionExtintorEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ClasificacionExtintorBE> lstClasificacionExtintor;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ClasificacionExtintorBE pClasificacionExtintorBE { get; set; }

        int _IdClasificacionExtintor = 0;

        public int IdClasificacionExtintor
        {
            get { return _IdClasificacionExtintor; }
            set { _IdClasificacionExtintor = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManClasificacionExtintorEdit()
        {
            InitializeComponent();
        }

        private void frmManClasificacionExtintorEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Clasificacion Inspección - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Clasificacion Inspección - Modificar";
                txtAbreviatura.Text = pClasificacionExtintorBE.Abreviatura.Trim();
                txtDescripcion.Text = pClasificacionExtintorBE.DescClasificacionExtintor.Trim();

            }

            txtAbreviatura.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ClasificacionExtintorBL objBL_ClasificacionExtintor = new ClasificacionExtintorBL();
                    ClasificacionExtintorBE objClasificacionExtintor = new ClasificacionExtintorBE();
                    objClasificacionExtintor.IdClasificacionExtintor = IdClasificacionExtintor;
                    objClasificacionExtintor.Abreviatura = txtAbreviatura.Text;
                    objClasificacionExtintor.DescClasificacionExtintor = txtDescripcion.Text;
                    objClasificacionExtintor.FlagEstado = true;
                    objClasificacionExtintor.Usuario = Parametros.strUsuarioLogin;
                    objClasificacionExtintor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objClasificacionExtintor.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_ClasificacionExtintor.Inserta(objClasificacionExtintor);
                    else
                        objBL_ClasificacionExtintor.Actualiza(objClasificacionExtintor);

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

        private void txtAbreviatura_KeyPress(object sender, KeyPressEventArgs e)
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

            if (txtAbreviatura.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la Abreviatura.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstClasificacionExtintor.Where(oB => oB.DescClasificacionExtintor.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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