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

namespace SSOMA.Presentacion.Modulos.Inspeccion.Maestros
{
    public partial class frmManTipoInspeccionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TipoInspeccionBE> lstTipoInspeccion;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TipoInspeccionBE pTipoInspeccionBE { get; set; }

        int _IdTipoInspeccion = 0;

        public int IdTipoInspeccion
        {
            get { return _IdTipoInspeccion; }
            set { _IdTipoInspeccion = value; }
        }


        #endregion

        #region "Eventos"

        public frmManTipoInspeccionEdit()
        {
            InitializeComponent();
        }

        private void frmManTipoInspeccionEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Inspección de Trabajo - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Inspección de Trabajo - Modificar";
                txtDescripcion.Text = pTipoInspeccionBE.DescTipoInspeccion.Trim();

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
                    TipoInspeccionBL objBL_TipoInspeccion = new TipoInspeccionBL();
                    TipoInspeccionBE objTipoInspeccion = new TipoInspeccionBE();
                    objTipoInspeccion.IdTipoInspeccion = IdTipoInspeccion;
                    objTipoInspeccion.DescTipoInspeccion = txtDescripcion.Text;
                    objTipoInspeccion.FlagEstado = true;
                    objTipoInspeccion.Usuario = Parametros.strUsuarioLogin;
                    objTipoInspeccion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objTipoInspeccion.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_TipoInspeccion.Inserta(objTipoInspeccion);
                    else
                        objBL_TipoInspeccion.Actualiza(objTipoInspeccion);

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
                var Buscar = lstTipoInspeccion.Where(oB => oB.DescTipoInspeccion.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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