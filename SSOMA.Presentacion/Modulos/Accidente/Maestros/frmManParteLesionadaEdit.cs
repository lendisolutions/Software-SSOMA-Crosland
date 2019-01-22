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
    public partial class frmManParteLesionadaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ParteLesionadaBE> lstParteLesionada;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ParteLesionadaBE pParteLesionadaBE { get; set; }

        int _IdParteLesionada = 0;

        public int IdParteLesionada
        {
            get { return _IdParteLesionada; }
            set { _IdParteLesionada = value; }
        }

        #endregion

        #region "Eventos"

        public frmManParteLesionadaEdit()
        {
            InitializeComponent();
        }

        private void frmManParteLesionadaEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Parte Lesionada - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Parte Lesionada - Modificar";
                txtDescripcion.Text = pParteLesionadaBE.DescParteLesionada.Trim();

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
                    ParteLesionadaBL objBL_ParteLesionada = new ParteLesionadaBL();
                    ParteLesionadaBE objParteLesionada = new ParteLesionadaBE();
                    objParteLesionada.IdParteLesionada = IdParteLesionada;
                    objParteLesionada.DescParteLesionada = txtDescripcion.Text;
                    objParteLesionada.FlagEstado = true;
                    objParteLesionada.Usuario = Parametros.strUsuarioLogin;
                    objParteLesionada.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objParteLesionada.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_ParteLesionada.Inserta(objParteLesionada);
                    else
                        objBL_ParteLesionada.Actualiza(objParteLesionada);

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
                var Buscar = lstParteLesionada.Where(oB => oB.DescParteLesionada.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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