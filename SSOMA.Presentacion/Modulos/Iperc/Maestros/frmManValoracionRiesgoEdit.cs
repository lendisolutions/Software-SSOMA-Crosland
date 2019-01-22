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
    public partial class frmManValoracionRiesgoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ValoracionRiesgoBE> lstValoracionRiesgo;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ValoracionRiesgoBE pValoracionRiesgoBE { get; set; }

        int _IdValoracionRiesgo = 0;

        public int IdValoracionRiesgo
        {
            get { return _IdValoracionRiesgo; }
            set { _IdValoracionRiesgo = value; }
        }


        #endregion

        #region "Eventos"

        public frmManValoracionRiesgoEdit()
        {
            InitializeComponent();
        }

        private void frmManValoracionRiesgoEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Valoracion del Riesgo - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Valoración del Riesgo - Modificar";
                ValoracionRiesgoBE objE_ValoracionRiesgo = null;
                objE_ValoracionRiesgo = new ValoracionRiesgoBL().Selecciona(IdValoracionRiesgo);
                if (objE_ValoracionRiesgo != null)
                {
                    IdValoracionRiesgo = objE_ValoracionRiesgo.IdValoracionRiesgo;
                    txtValoracion.EditValue = objE_ValoracionRiesgo.Valoracion;
                    txtClasificacion.Text = objE_ValoracionRiesgo.Clasificacion;
                    txtDescValoracionRiesgo.Text = objE_ValoracionRiesgo.DescValoracionRiesgo;
                    txtCalificacion.Text = objE_ValoracionRiesgo.Calificacion;
                    
                }

            }

            txtValoracion.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ValoracionRiesgoBL objBL_ValoracionRiesgo = new ValoracionRiesgoBL();
                    ValoracionRiesgoBE objValoracionRiesgo = new ValoracionRiesgoBE();
                    objValoracionRiesgo.IdValoracionRiesgo = IdValoracionRiesgo;
                    objValoracionRiesgo.Valoracion = txtValoracion.Text;
                    objValoracionRiesgo.Clasificacion = txtClasificacion.Text;
                    objValoracionRiesgo.DescValoracionRiesgo = txtDescValoracionRiesgo.Text;
                    objValoracionRiesgo.Calificacion = txtCalificacion.Text;
                    objValoracionRiesgo.FlagEstado = true;
                    objValoracionRiesgo.Usuario = Parametros.strUsuarioLogin;
                    objValoracionRiesgo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objValoracionRiesgo.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_ValoracionRiesgo.Inserta(objValoracionRiesgo);
                    else
                        objBL_ValoracionRiesgo.Actualiza(objValoracionRiesgo);

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
            if (txtDescValoracionRiesgo.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción de la valoración del riesgo.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstValoracionRiesgo.Where(oB => oB.Valoracion == txtValoracion.Text).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La valoración ya existe.\n";
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