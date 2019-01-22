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
    public partial class frmManServicioExtintorEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ServicioExtintorBE> lstServicioExtintor;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ServicioExtintorBE pServicioExtintorBE { get; set; }

        int _IdServicioExtintor = 0;

        public int IdServicioExtintor
        {
            get { return _IdServicioExtintor; }
            set { _IdServicioExtintor = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManServicioExtintorEdit()
        {
            InitializeComponent();
        }

        private void frmManServicioExintorEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "ServicioExtintor - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "ServicioExtintor - Modificar";
                txtDescripcion.Text = pServicioExtintorBE.DescServicioExtintor.Trim();

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
                    ServicioExtintorBL objBL_ServicioExtintor = new ServicioExtintorBL();
                    ServicioExtintorBE objServicioExtintor = new ServicioExtintorBE();
                    objServicioExtintor.IdServicioExtintor = IdServicioExtintor;
                    objServicioExtintor.DescServicioExtintor = txtDescripcion.Text;
                    objServicioExtintor.FlagEstado = true;
                    objServicioExtintor.Usuario = Parametros.strUsuarioLogin;
                    objServicioExtintor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objServicioExtintor.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_ServicioExtintor.Inserta(objServicioExtintor);
                    else
                        objBL_ServicioExtintor.Actualiza(objServicioExtintor);

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
                var Buscar = lstServicioExtintor.Where(oB => oB.DescServicioExtintor.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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