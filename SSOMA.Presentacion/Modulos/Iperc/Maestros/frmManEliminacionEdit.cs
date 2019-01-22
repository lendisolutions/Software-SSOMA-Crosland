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
    public partial class frmManEliminacionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<EliminacionBE> lstEliminacion;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public EliminacionBE pEliminacionBE { get; set; }

        int _IdEliminacion = 0;

        public int IdEliminacion
        {
            get { return _IdEliminacion; }
            set { _IdEliminacion = value; }
        }

        #endregion

        #region "Eventos"

        public frmManEliminacionEdit()
        {
            InitializeComponent();
        }

        private void frmManEliminacionEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Eliminación - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Eliminación - Modificar";
                txtDescripcion.Text = pEliminacionBE.DescEliminacion.Trim();

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
                    EliminacionBL objBL_Eliminacion = new EliminacionBL();
                    EliminacionBE objEliminacion = new EliminacionBE();
                    objEliminacion.IdEliminacion = IdEliminacion;
                    objEliminacion.DescEliminacion = txtDescripcion.Text;
                    objEliminacion.FlagEstado = true;
                    objEliminacion.Usuario = Parametros.strUsuarioLogin;
                    objEliminacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objEliminacion.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Eliminacion.Inserta(objEliminacion);
                    else
                        objBL_Eliminacion.Actualiza(objEliminacion);

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
                var Buscar = lstEliminacion.Where(oB => oB.DescEliminacion.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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