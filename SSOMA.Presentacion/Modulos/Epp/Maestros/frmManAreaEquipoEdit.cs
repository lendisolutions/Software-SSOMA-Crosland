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

namespace SSOMA.Presentacion.Modulos.Epp.Maestros
{
    public partial class frmManAreaEquipoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<AreaEquipoBE> lstAreaEquipo;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public AreaEquipoBE pAreaEquipoBE { get; set; }

        int _IdEmpresa = 0;

        public int IdEmpresa
        {
            get { return _IdEmpresa; }
            set { _IdEmpresa = value; }
        }

        int _IdUnidadMinera = 0;

        public int IdUnidadMinera
        {
            get { return _IdUnidadMinera; }
            set { _IdUnidadMinera = value; }
        }

        int _IdArea = 0;

        public int IdArea
        {
            get { return _IdArea; }
            set { _IdArea = value; }
        }

        int _IdAreaEquipo = 0;

        public int IdAreaEquipo
        {
            get { return _IdAreaEquipo; }
            set { _IdAreaEquipo = value; }
        }

        int intIdEquipo = 0;

        #endregion

        #region "Eventos"

        public frmManAreaEquipoEdit()
        {
            InitializeComponent();
        }

        private void frmManAreaEquipoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = IdEmpresa;
            BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
            cboUnidadMinera.EditValue = IdUnidadMinera;
            BSUtils.LoaderLook(cboArea, new AreaBL().ListaTodosActivo(IdEmpresa, IdUnidadMinera), "DescArea", "IdArea", true);
            cboArea.EditValue = IdArea;

            txtDias.EditValue = 0;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "AreaEquipo - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "AreaEquipo - Modificar";
                AreaEquipoBE objE_AreaEquipo = null;
                objE_AreaEquipo = new AreaEquipoBL().Selecciona(IdAreaEquipo);
                if (objE_AreaEquipo != null)
                {
                    IdAreaEquipo = objE_AreaEquipo.IdAreaEquipo;
                    cboEmpresa.EditValue = objE_AreaEquipo.IdEmpresa;
                    cboUnidadMinera.EditValue = objE_AreaEquipo.IdUnidadMinera;
                    cboArea.EditValue = objE_AreaEquipo.IdArea;
                    intIdEquipo = objE_AreaEquipo.IdEquipo;
                    txtCodigo.Text = objE_AreaEquipo.Codigo;
                    txtDescEquipo.Text = objE_AreaEquipo.DescEquipo;
                    txtDias.EditValue = objE_AreaEquipo.Dias;
                }

            }

            txtCodigo.Select();
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
                cboUnidadMinera.EditValue = IdUnidadMinera;
            }
        }

        private void cboUnidadMinera_EditValueChanged(object sender, EventArgs e)
        {
            if (cboUnidadMinera.EditValue != null)
            {
                BSUtils.LoaderLook(cboArea, new AreaBL().ListaTodosActivo(IdEmpresa, IdUnidadMinera), "DescArea", "IdArea", true);
                cboArea.EditValue = IdArea;
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaEquipo objBusEquipoPreVenta = new frmBuscaEquipo();
                objBusEquipoPreVenta.IdEmpresa = Parametros.intEmpresaId;
                objBusEquipoPreVenta.pFlagMultiSelect = false;
                objBusEquipoPreVenta.ShowDialog();
                if (objBusEquipoPreVenta.pEquipoBE != null)
                {
                    intIdEquipo = objBusEquipoPreVenta.pEquipoBE.IdEquipo;
                    txtCodigo.Text = objBusEquipoPreVenta.pEquipoBE.Codigo;
                    txtDescEquipo.Text = objBusEquipoPreVenta.pEquipoBE.DescEquipo;

                    txtDias.SelectAll();
                    txtDias.Focus();
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    AreaEquipoBL objBL_AreaEquipo = new AreaEquipoBL();
                    AreaEquipoBE objAreaEquipo = new AreaEquipoBE();

                    objAreaEquipo.IdAreaEquipo = IdAreaEquipo;
                    objAreaEquipo.IdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
                    objAreaEquipo.IdArea = Convert.ToInt32(cboArea.EditValue);
                    objAreaEquipo.IdEquipo = intIdEquipo;
                    objAreaEquipo.Codigo = txtCodigo.Text;
                    objAreaEquipo.DescEquipo = txtDescEquipo.Text;
                    objAreaEquipo.Dias = Convert.ToInt32(txtDias.EditValue);
                    objAreaEquipo.FlagEstado = true;
                    objAreaEquipo.Usuario = Parametros.strUsuarioLogin;
                    objAreaEquipo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objAreaEquipo.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                    if (pOperacion == Operacion.Nuevo)
                        objBL_AreaEquipo.Inserta(objAreaEquipo);
                    else
                        objBL_AreaEquipo.Actualiza(objAreaEquipo);

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

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnGrabar.Focus();
            }
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";
            
            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstAreaEquipo.Where(oB => oB.IdEmpresa == Convert.ToInt32(cboEmpresa.EditValue) && oB.IdUnidadMinera == Convert.ToInt32(cboUnidadMinera.EditValue) && oB.IdArea == Convert.ToInt32(cboArea.EditValue) && oB.IdEquipo == intIdEquipo).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- No se puede asignar un mismo equipo de protección personal.\n";
                    flag = true;
                }

                if (intIdEquipo == 0)
                {
                    strMensaje = strMensaje + "- Debe seleccionar un equipo de protección AreaEquipol.\n";
                    flag = true;
                }

                if (Convert.ToInt32(txtDias.EditValue) == 0)
                {
                    strMensaje = strMensaje + "- Los dias vencimiento no puede ser 0.\n";
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