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
    public partial class frmManFuenteLesionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<FuenteLesionBE> lstFuenteLesion;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public FuenteLesionBE pFuenteLesionBE { get; set; }

        int _IdFuenteLesion = 0;

        public int IdFuenteLesion
        {
            get { return _IdFuenteLesion; }
            set { _IdFuenteLesion = value; }
        }

        #endregion

        #region "Eventos"

        public frmManFuenteLesionEdit()
        {
            InitializeComponent();
        }

        private void frmManFuenteLesionEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Fuente de Lesión - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Fuente de Lesión - Modificar";
                txtDescripcion.Text = pFuenteLesionBE.DescFuenteLesion.Trim();

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
                    FuenteLesionBL objBL_FuenteLesion = new FuenteLesionBL();
                    FuenteLesionBE objFuenteLesion = new FuenteLesionBE();
                    objFuenteLesion.IdFuenteLesion = IdFuenteLesion;
                    objFuenteLesion.DescFuenteLesion = txtDescripcion.Text;
                    objFuenteLesion.FlagEstado = true;
                    objFuenteLesion.Usuario = Parametros.strUsuarioLogin;
                    objFuenteLesion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objFuenteLesion.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_FuenteLesion.Inserta(objFuenteLesion);
                    else
                        objBL_FuenteLesion.Actualiza(objFuenteLesion);

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
                var Buscar = lstFuenteLesion.Where(oB => oB.DescFuenteLesion.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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