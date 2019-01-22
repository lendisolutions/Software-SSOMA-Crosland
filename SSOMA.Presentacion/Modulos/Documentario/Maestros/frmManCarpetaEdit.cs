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


namespace SSOMA.Presentacion.Modulos.Documentario.Maestros
{
    public partial class frmManCarpetaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CarpetaBE> lstCarpeta;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public CarpetaBE pCarpetaBE { get; set; }

        int _IdCarpeta = 0;

        public int IdCarpeta
        {
            get { return _IdCarpeta; }
            set { _IdCarpeta = value; }
        }

        #endregion

        #region "Eventos"

        public frmManCarpetaEdit()
        {
            InitializeComponent();
        }

        private void frmManCarpetaEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Señalización - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Señalización - Modificar";
                txtDescripcion.Text = pCarpetaBE.DescCarpeta.Trim();

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
                    CarpetaBL objBL_Carpeta = new CarpetaBL();
                    CarpetaBE objCarpeta = new CarpetaBE();
                    objCarpeta.IdCarpeta = IdCarpeta;
                    objCarpeta.DescCarpeta = txtDescripcion.Text;
                    objCarpeta.FlagEstado = true;
                    objCarpeta.Usuario = Parametros.strUsuarioLogin;
                    objCarpeta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objCarpeta.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Carpeta.Inserta(objCarpeta);
                    else
                        objBL_Carpeta.Actualiza(objCarpeta);

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
                var Buscar = lstCarpeta.Where(oB => oB.DescCarpeta.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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