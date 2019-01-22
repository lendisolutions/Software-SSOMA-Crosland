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
    public partial class frmManProbabilidadEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ProbabilidadBE> lstProbabilidad;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ProbabilidadBE pProbabilidadBE { get; set; }

        int _IdProbabilidad = 0;

        public int IdProbabilidad
        {
            get { return _IdProbabilidad; }
            set { _IdProbabilidad = value; }
        }

        #endregion

        #region "Eventos"

        public frmManProbabilidadEdit()
        {
            InitializeComponent();
        }

        private void frmManProbabilidadEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Probabilidad - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Probabilidad- Modificar";
                ProbabilidadBE objE_Probabilidad = null;
                objE_Probabilidad = new ProbabilidadBL().Selecciona(IdProbabilidad);
                if (objE_Probabilidad != null)
                {
                    IdProbabilidad = objE_Probabilidad.IdProbabilidad;
                    txtValorProbabilidad.EditValue = objE_Probabilidad.ValorProbabilidad;
                    txtIndicePersona.Text = objE_Probabilidad.IndicePersona;
                    txtIndiceProcedimiento.Text = objE_Probabilidad.IndiceProcedimiento;
                    txtIndiceCapacitacion.Text = objE_Probabilidad.IndiceCapacitacion;
                    txtIndiceFrecuencia.Text = objE_Probabilidad.IndiceFrecuencia;
                }

            }

            txtIndicePersona.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ProbabilidadBL objBL_Probabilidad = new ProbabilidadBL();
                    ProbabilidadBE objProbabilidad = new ProbabilidadBE();
                    objProbabilidad.IdProbabilidad = IdProbabilidad;
                    objProbabilidad.ValorProbabilidad = Convert.ToInt32(txtValorProbabilidad.EditValue);
                    objProbabilidad.IndicePersona = txtIndicePersona.Text;
                    objProbabilidad.IndiceProcedimiento = txtIndiceProcedimiento.Text;
                    objProbabilidad.IndiceCapacitacion = txtIndiceCapacitacion.Text;
                    objProbabilidad.IndiceFrecuencia = txtIndiceFrecuencia.Text;
                    objProbabilidad.FlagEstado = true;
                    objProbabilidad.Usuario = Parametros.strUsuarioLogin;
                    objProbabilidad.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objProbabilidad.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Probabilidad.Inserta(objProbabilidad);
                    else
                        objBL_Probabilidad.Actualiza(objProbabilidad);

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
            if (txtIndicePersona.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción del Indice de la Personas Expuestas.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstProbabilidad.Where(oB => oB.ValorProbabilidad == Convert.ToInt32(txtValorProbabilidad.EditValue)).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Valor de la Probabilidad ya existe.\n";
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