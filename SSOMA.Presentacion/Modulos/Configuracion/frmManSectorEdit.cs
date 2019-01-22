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
    public partial class frmManSectorEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<SectorBE> lstSector;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public SectorBE pSectorBE { get; set; }

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

        int _IdSector = 0;

        public int IdSector
        {
            get { return _IdSector; }
            set { _IdSector = value; }
        }

        #endregion

        #region "Eventos"

        public frmManSectorEdit()
        {
            InitializeComponent();
        }

        private void frmManSectorEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = IdEmpresa;
            BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
            cboUnidadMinera.EditValue = IdUnidadMinera;
            BSUtils.LoaderLook(cboArea, new AreaBL().ListaTodosActivo(IdEmpresa, IdUnidadMinera), "DescArea", "IdArea", true);
            cboArea.EditValue = IdArea;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Sector - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Sector - Modificar";
                SectorBE objE_Sector = null;
                objE_Sector = new SectorBL().Selecciona(IdSector);
                if (objE_Sector != null)
                {
                    cboEmpresa.EditValue = objE_Sector.IdEmpresa;
                    cboUnidadMinera.EditValue = objE_Sector.IdUnidadMinera;
                    cboArea.EditValue = objE_Sector.IdArea;
                    txtDescripcion.Text = objE_Sector.DescSector;
                }
            }

            txtDescripcion.Select();

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

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    SectorBL objBL_Sector = new SectorBL();
                    SectorBE objSector = new SectorBE();

                    objSector.IdSector = IdSector;
                    objSector.IdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
                    objSector.IdArea = Convert.ToInt32(cboArea.EditValue);
                    objSector.DescSector = txtDescripcion.Text;
                    objSector.FlagEstado = true;
                    objSector.Usuario = Parametros.strUsuarioLogin;
                    objSector.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objSector.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Sector.Inserta(objSector);
                    else
                        objBL_Sector.Actualiza(objSector);

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
                var Buscar = lstSector.Where(oB => oB.DescSector.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La Descripción ya existe.\n";
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