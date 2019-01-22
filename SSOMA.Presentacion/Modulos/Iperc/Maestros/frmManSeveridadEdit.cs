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
    public partial class frmManSeveridadEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<SeveridadBE> lstSeveridad;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public SeveridadBE pSeveridadBE { get; set; }

        int _IdSeveridad = 0;

        public int IdSeveridad
        {
            get { return _IdSeveridad; }
            set { _IdSeveridad = value; }
        }

        #endregion

        #region "Eventos"

        public frmManSeveridadEdit()
        {
            InitializeComponent();
        }

        private void frmManSeveridadEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Severidad - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Tipo de Peligro - Modificar";
                SeveridadBE objE_Severidad = null;
                objE_Severidad = new SeveridadBL().Selecciona(IdSeveridad);
                if (objE_Severidad != null)
                {
                    IdSeveridad = objE_Severidad.IdSeveridad;
                    txtValorSeveridad.EditValue = objE_Severidad.ValorSeveridad;
                    txtDescSeveridad.Text = objE_Severidad.DescSeveridad;
                    
                }

            }

            txtDescSeveridad.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    SeveridadBL objBL_Severidad = new SeveridadBL();
                    SeveridadBE objSeveridad = new SeveridadBE();
                    objSeveridad.IdSeveridad = IdSeveridad;
                    objSeveridad.ValorSeveridad = Convert.ToInt32(txtValorSeveridad.EditValue);
                    objSeveridad.DescSeveridad = txtDescSeveridad.Text;
                    objSeveridad.FlagEstado = true;
                    objSeveridad.Usuario = Parametros.strUsuarioLogin;
                    objSeveridad.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objSeveridad.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Severidad.Inserta(objSeveridad);
                    else
                        objBL_Severidad.Actualiza(objSeveridad);

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
            if (txtDescSeveridad.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción del Indice de la Severidad.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstSeveridad.Where(oB => oB.ValorSeveridad == Convert.ToInt32(txtValorSeveridad.EditValue)).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Valor de la Severidad ya existe.\n";
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