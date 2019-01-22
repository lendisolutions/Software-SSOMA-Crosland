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

namespace SSOMA.Presentacion.Modulos.Configuracion
{
    public partial class frmManOrdenInternaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<OrdenInternaBE> lstOrdenInterna;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public OrdenInternaBE pOrdenInternaBE { get; set; }

        int _IdOrdenInterna = 0;

        public int IdOrdenInterna
        {
            get { return _IdOrdenInterna; }
            set { _IdOrdenInterna = value; }
        }

        #endregion

        #region "Eventos"

        public frmManOrdenInternaEdit()
        {
            InitializeComponent();
        }

        private void frmManOrdenInternaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaCombo(Parametros.intEmpresaId, Parametros.intUnidadMineraId), "DescUnidadMinera", "IdUnidadMinera", true);
            BSUtils.LoaderLook(cboOrdenInterna, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblOrdenInterna), "DescTablaElemento", "IdTablaElemento", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "OrdenInterna - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "OrdenInterna - Modificar";
                OrdenInternaBE objE_OrdenInterna = null;
                objE_OrdenInterna = new OrdenInternaBL().Selecciona(Parametros.intEmpresaId, Parametros.intUnidadMineraId, IdOrdenInterna);
                if (objE_OrdenInterna != null)
                {
                    cboUnidadMinera.EditValue = objE_OrdenInterna.IdUnidadMinera;
                    cboOrdenInterna.Text = objE_OrdenInterna.DescOrdenInterna.Trim();
                }

            }

            cboOrdenInterna.Select();
        }

        #endregion

        #region "Metodos"

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    OrdenInternaBL objBL_OrdenInterna = new OrdenInternaBL();
                    OrdenInternaBE objOrdenInterna = new OrdenInternaBE();

                    objOrdenInterna.IdOrdenInterna = IdOrdenInterna;
                    objOrdenInterna.IdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
                    objOrdenInterna.DescOrdenInterna = cboOrdenInterna.Text;
                    objOrdenInterna.FlagEstado = true;
                    objOrdenInterna.Usuario = Parametros.strUsuarioLogin;
                    objOrdenInterna.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objOrdenInterna.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_OrdenInterna.Inserta(objOrdenInterna);
                    else
                        objBL_OrdenInterna.Actualiza(objOrdenInterna);

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

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";
            if (cboOrdenInterna.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstOrdenInterna.Where(oB => oB.DescOrdenInterna.ToUpper() == cboOrdenInterna.Text.ToUpper()).ToList();
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