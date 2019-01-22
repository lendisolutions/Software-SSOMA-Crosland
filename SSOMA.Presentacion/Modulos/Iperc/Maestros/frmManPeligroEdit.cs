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
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Modulos.Otros;

namespace SSOMA.Presentacion.Modulos.Iperc.Maestros
{
    public partial class frmManPeligroEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PeligroBE> lstPeligro;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public PeligroBE pPeligroBE { get; set; }

       

        int _IdTipoPeligro = 0;

        public int IdTipoPeligro
        {
            get { return _IdTipoPeligro; }
            set { _IdTipoPeligro = value; }
        }

        int _IdPeligro = 0;

        public int IdPeligro
        {
            get { return _IdPeligro; }
            set { _IdPeligro = value; }
        }

        #endregion

        #region "Eventos"

        public frmManPeligroEdit()
        {
            InitializeComponent();
        }

        private void frmManPeligroEdit_Load(object sender, EventArgs e)
        {
           
            BSUtils.LoaderLook(cboTipoPeligro, new TipoPeligroBL().ListaTodosActivo(0), "DescTipoPeligro", "IdTipoPeligro", true);
            cboTipoPeligro.EditValue = IdTipoPeligro;
           

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Peligro - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Peligro - Modificar";
                PeligroBE objE_Peligro = null;
                objE_Peligro = new PeligroBL().Selecciona(IdPeligro);
                if (objE_Peligro != null)
                {
                    IdPeligro = objE_Peligro.IdPeligro;
                    cboTipoPeligro.EditValue = objE_Peligro.IdTipoPeligro;
                    txtDescPeligro.Text = objE_Peligro.DescPeligro;
                }

            }

            txtDescPeligro.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PeligroBL objBL_Peligro = new PeligroBL();
                    PeligroBE objPeligro = new PeligroBE();

                    objPeligro.IdPeligro = IdPeligro;
                    objPeligro.IdTipoPeligro = Convert.ToInt32(cboTipoPeligro.EditValue);
                    objPeligro.DescPeligro = txtDescPeligro.Text;
                    objPeligro.FlagEstado = true;
                    objPeligro.Usuario = Parametros.strUsuarioLogin;
                    objPeligro.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPeligro.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Peligro.Inserta(objPeligro);
                    else
                        objBL_Peligro.Actualiza(objPeligro);

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

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstPeligro.Where(oB => oB.DescPeligro == txtDescPeligro.Text.Trim()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- Ya existe la Peligro.\n";
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