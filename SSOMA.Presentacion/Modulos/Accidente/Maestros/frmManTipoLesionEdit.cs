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
    public partial class frmManTipoLesionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TipoLesionBE> lstTipoLesion;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TipoLesionBE pTipoLesionBE { get; set; }

        int _IdTipoLesion = 0;

        public int IdTipoLesion
        {
            get { return _IdTipoLesion; }
            set { _IdTipoLesion = value; }
        }

        #endregion

        #region "Eventos"

        public frmManTipoLesionEdit()
        {
            InitializeComponent();
        }

        private void frmManTipoLesionEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Tipo de Lesión - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Tipo de Lesión - Modificar";
                txtDescripcion.Text = pTipoLesionBE.DescTipoLesion.Trim();

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
                    TipoLesionBL objBL_TipoLesion = new TipoLesionBL();
                    TipoLesionBE objTipoLesion = new TipoLesionBE();
                    objTipoLesion.IdTipoLesion = IdTipoLesion;
                    objTipoLesion.DescTipoLesion = txtDescripcion.Text;
                    objTipoLesion.FlagEstado = true;
                    objTipoLesion.Usuario = Parametros.strUsuarioLogin;
                    objTipoLesion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objTipoLesion.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_TipoLesion.Inserta(objTipoLesion);
                    else
                        objBL_TipoLesion.Actualiza(objTipoLesion);

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
                var Buscar = lstTipoLesion.Where(oB => oB.DescTipoLesion.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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