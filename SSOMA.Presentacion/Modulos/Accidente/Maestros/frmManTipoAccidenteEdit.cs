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
    public partial class frmManTipoAccidenteEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TipoAccidenteBE> lstTipoAccidente;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TipoAccidenteBE pTipoAccidenteBE { get; set; }

        int _IdTipoAccidente = 0;

        public int IdTipoAccidente
        {
            get { return _IdTipoAccidente; }
            set { _IdTipoAccidente = value; }
        }

        #endregion

        #region "Eventos"

        public frmManTipoAccidenteEdit()
        {
            InitializeComponent();
        }

        private void frmManTipoAccidenteEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Tipo de Accidente - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Tipo de Accidente - Modificar";
                txtDescripcion.Text = pTipoAccidenteBE.DescTipoAccidente.Trim();

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
                    TipoAccidenteBL objBL_TipoAccidente = new TipoAccidenteBL();
                    TipoAccidenteBE objTipoAccidente = new TipoAccidenteBE();
                    objTipoAccidente.IdTipoAccidente = IdTipoAccidente;
                    objTipoAccidente.DescTipoAccidente = txtDescripcion.Text;
                    objTipoAccidente.FlagEstado = true;
                    objTipoAccidente.Usuario = Parametros.strUsuarioLogin;
                    objTipoAccidente.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objTipoAccidente.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_TipoAccidente.Inserta(objTipoAccidente);
                    else
                        objBL_TipoAccidente.Actualiza(objTipoAccidente);

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
                var Buscar = lstTipoAccidente.Where(oB => oB.DescTipoAccidente.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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