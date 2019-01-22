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
    public partial class frmManTipoPeligroEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TipoPeligroBE> lstTipoPeligro;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TipoPeligroBE pTipoPeligroBE { get; set; }

        int _IdTipoPeligro = 0;

        public int IdTipoPeligro
        {
            get { return _IdTipoPeligro; }
            set { _IdTipoPeligro = value; }
        }

        #endregion

        #region "Eventos"

        public frmManTipoPeligroEdit()
        {
            InitializeComponent();
        }

        private void frmManTipoPeligroEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Tipo de Peligro - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Tipo de Peligro - Modificar";
                txtDescripcion.Text = pTipoPeligroBE.DescTipoPeligro.Trim();

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
                    TipoPeligroBL objBL_TipoPeligro = new TipoPeligroBL();
                    TipoPeligroBE objTipoPeligro = new TipoPeligroBE();
                    objTipoPeligro.IdTipoPeligro = IdTipoPeligro;
                    objTipoPeligro.DescTipoPeligro = txtDescripcion.Text;
                    objTipoPeligro.FlagEstado = true;
                    objTipoPeligro.Usuario = Parametros.strUsuarioLogin;
                    objTipoPeligro.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objTipoPeligro.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_TipoPeligro.Inserta(objTipoPeligro);
                    else
                        objBL_TipoPeligro.Actualiza(objTipoPeligro);

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
                var Buscar = lstTipoPeligro.Where(oB => oB.DescTipoPeligro.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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