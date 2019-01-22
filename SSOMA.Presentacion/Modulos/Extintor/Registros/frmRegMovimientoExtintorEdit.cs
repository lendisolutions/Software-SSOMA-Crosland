using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion.Modulos.Otros;


namespace SSOMA.Presentacion.Modulos.Extintor.Registros
{
    public partial class frmRegMovimientoExtintorEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<MovimientoExtintorBE> lstMovimientoExtintor;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdMovimientoExtintor = 0;

        public int IdMovimientoExtintor
        {
            get { return _IdMovimientoExtintor; }
            set { _IdMovimientoExtintor = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmRegMovimientoExtintorEdit()
        {
            InitializeComponent();
        }

        private void frmRegMovimientoExtintorEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboExtintor, new ExtintorBL().ListaCombo(Parametros.intEmpresaId,0), "DescExtintor", "IdExtintor", true);
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0, Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            deFecha.DateTime = DateTime.Now;
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Movimiento Extintor - Nuevo";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Movimiento Extintor - Modificar";

                MovimientoExtintorBE objE_MovimientoExtintor = null;
                objE_MovimientoExtintor = new MovimientoExtintorBL().Selecciona(IdMovimientoExtintor);

                IdMovimientoExtintor = objE_MovimientoExtintor.IdMovimientoExtintor;
                cboExtintor.EditValue = objE_MovimientoExtintor.IdExtintor;
                cboEmpresa.EditValue = objE_MovimientoExtintor.IdEmpresa;
                cboUnidadMinera.EditValue = objE_MovimientoExtintor.IdUnidadMinera;
                cboArea.EditValue = objE_MovimientoExtintor.IdArea;
                deFecha.EditValue = objE_MovimientoExtintor.Fecha;
                txtUbicacion.Text = objE_MovimientoExtintor.Ubicacion;
                txtHechoPor.Text = objE_MovimientoExtintor.HechoPor;
                txtAutorizadoPor.Text = objE_MovimientoExtintor.AutorizadoPor;
                txtObservacion.Text = objE_MovimientoExtintor.Observacion;
            }

            cboExtintor.Select();
            
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
            }
            
        }

        private void cboUnidadMinera_EditValueChanged(object sender, EventArgs e)
        {
            if (cboUnidadMinera.EditValue != null)
            {
                BSUtils.LoaderLook(cboArea, new AreaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboUnidadMinera.EditValue)), "DescArea", "IdArea", true);
            }
        }

        private void btnBucarHechoPor_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
               
                frm.pFlagTodoPersonal = false;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    txtHechoPor.Text = frm.pPersonaBE.ApeNom;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarAutorizadoPor_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = false;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    txtAutorizadoPor.Text = frm.pPersonaBE.ApeNom;
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
                    MovimientoExtintorBE objMovimientoExtintor = new MovimientoExtintorBE();
                    MovimientoExtintorBL objBL_MovimientoExtintor = new MovimientoExtintorBL();

                    objMovimientoExtintor.IdMovimientoExtintor = IdMovimientoExtintor;
                    objMovimientoExtintor.IdExtintor = Convert.ToInt32(cboExtintor.EditValue);
                    objMovimientoExtintor.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objMovimientoExtintor.IdUnidadMinera = Parametros.intUnidadMineraId;
                    objMovimientoExtintor.IdArea = Convert.ToInt32(cboArea.EditValue);
                    objMovimientoExtintor.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objMovimientoExtintor.Ubicacion = txtUbicacion.Text;
                    objMovimientoExtintor.HechoPor = txtHechoPor.Text;
                    objMovimientoExtintor.AutorizadoPor = txtAutorizadoPor.Text;
                    objMovimientoExtintor.Observacion = txtObservacion.Text;
                    objMovimientoExtintor.FlagEstado = true;
                    objMovimientoExtintor.Usuario = Parametros.strUsuarioLogin;
                    objMovimientoExtintor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    
                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_MovimientoExtintor.Inserta(objMovimientoExtintor);
                        XtraMessageBox.Show("Se creó el registro del MovimientoExtintor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        objBL_MovimientoExtintor.Actualiza(objMovimientoExtintor);
                    }
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

            if (txtUbicacion.Text == "")
            {
                strMensaje = strMensaje + "- Debe ingresar la ubicación del extintor.\n";
                flag = true;
            }

            if (txtHechoPor.Text == "")
            {
                strMensaje = strMensaje + "- Debe ingresar quien realizó el movimiento del extintor.\n";
                flag = true;
            }

            if (txtAutorizadoPor.Text == "")
            {
                strMensaje = strMensaje + "- Debe ingresar quien autorizó el movimiento del extintor.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }


        #endregion

        private void txtHechoPor_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}