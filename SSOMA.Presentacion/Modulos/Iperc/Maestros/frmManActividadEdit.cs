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
    public partial class frmManActividadEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ActividadBE> lstActividad;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ActividadBE pActividadBE { get; set; }

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

        int _IdActividad = 0;

        public int IdActividad
        {
            get { return _IdActividad; }
            set { _IdActividad = value; }
        }

        #endregion

        #region "Eventos"

        public frmManActividadEdit()
        {
            InitializeComponent();
        }

        private void frmManActividadEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = IdEmpresa;
            BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
            cboUnidadMinera.EditValue = IdUnidadMinera;
            BSUtils.LoaderLook(cboArea, new AreaBL().ListaTodosActivo(IdEmpresa, IdUnidadMinera), "DescArea", "IdArea", true);
            cboArea.EditValue = IdArea;
            BSUtils.LoaderLook(cboSector, new SectorBL().ListaTodosActivo(IdEmpresa, IdUnidadMinera, IdArea), "DescSector", "IdSector", true);
            cboSector.EditValue = IdSector;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Actividad - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Actividad - Modificar";
                ActividadBE objE_Actividad = null;
                objE_Actividad = new ActividadBL().Selecciona(IdActividad);
                if (objE_Actividad != null)
                {
                    IdActividad = objE_Actividad.IdActividad;
                    cboEmpresa.EditValue = objE_Actividad.IdEmpresa;
                    cboUnidadMinera.EditValue = objE_Actividad.IdUnidadMinera;
                    cboArea.EditValue = objE_Actividad.IdArea;
                    cboSector.EditValue = objE_Actividad.IdSector;
                    txtDescActividad.Text = objE_Actividad.DescActividad;
                }

            }

            txtDescActividad.Select();
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

        private void cboArea_EditValueChanged(object sender, EventArgs e)
        {
            if (cboArea.EditValue != null)
            {
                BSUtils.LoaderLook(cboSector, new SectorBL().ListaTodosActivo(IdEmpresa, IdUnidadMinera, IdArea), "DescSector", "IdSector", true);
                cboSector.EditValue = IdSector;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ActividadBL objBL_Actividad = new ActividadBL();
                    ActividadBE objActividad = new ActividadBE();

                    objActividad.IdActividad = IdActividad;
                    objActividad.IdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
                    objActividad.IdArea = Convert.ToInt32(cboArea.EditValue);
                    objActividad.IdSector = Convert.ToInt32(cboSector.EditValue);
                    objActividad.DescActividad = txtDescActividad.Text;
                    objActividad.FlagEstado = true;
                    objActividad.Usuario = Parametros.strUsuarioLogin;
                    objActividad.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objActividad.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Actividad.Inserta(objActividad);
                    else
                        objBL_Actividad.Actualiza(objActividad);

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
                var Buscar = lstActividad.Where(oB => oB.DescActividad == txtDescActividad.Text.Trim()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- Ya existe la actividad.\n";
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