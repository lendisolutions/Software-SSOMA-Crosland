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

namespace SSOMA.Presentacion.Modulos.Capacitacion.Maestros
{
    public partial class frmManCategoriaTemaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CategoriaTemaBE> lstCategoriaTema;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public CategoriaTemaBE pCategoriaTemaBE { get; set; }

        int _IdCategoriaTema = 0;

        public int IdCategoriaTema
        {
            get { return _IdCategoriaTema; }
            set { _IdCategoriaTema = value; }
        }

        #endregion

        #region "Eventos"

        public frmManCategoriaTemaEdit()
        {
            InitializeComponent();
        }

        private void frmManCategoriaTemaEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Categoría Tema - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Categoría Tema - Modificar";
                txtDescripcion.Text = pCategoriaTemaBE.DescCategoriaTema.Trim();

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
                    CategoriaTemaBL objBL_CategoriaTema = new CategoriaTemaBL();
                    CategoriaTemaBE objCategoriaTema = new CategoriaTemaBE();
                    objCategoriaTema.IdCategoriaTema = IdCategoriaTema;
                    objCategoriaTema.DescCategoriaTema = txtDescripcion.Text;
                    objCategoriaTema.FlagEstado = true;
                    objCategoriaTema.Usuario = Parametros.strUsuarioLogin;
                    objCategoriaTema.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objCategoriaTema.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_CategoriaTema.Inserta(objCategoriaTema);
                    else
                        objBL_CategoriaTema.Actualiza(objCategoriaTema);

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
                var Buscar = lstCategoriaTema.Where(oB => oB.DescCategoriaTema.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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