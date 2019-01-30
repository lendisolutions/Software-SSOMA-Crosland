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
using System.Diagnostics;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Modulos.Otros;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Capacitacion.Maestros
{
    public partial class frmManCuestionarioEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CuestionarioBE> lstCuestionario;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public CuestionarioBE pCuestionarioBE { get; set; }

        int _IdTema = 0;

        public int IdTema
        {
            get { return _IdTema; }
            set { _IdTema = value; }
        }

        int _IdCuestionario = 0;

        public int IdCuestionario
        {
            get { return _IdCuestionario; }
            set { _IdCuestionario = value; }
        }

        public int IdSituacion { get; set; }

        #endregion

        #region "Eventos"

        public frmManCuestionarioEdit()
        {
            InitializeComponent();
        }

        private void frmManCuestionarioEdit_Load(object sender, EventArgs e)
        {
            deFechaIni.EditValue = DateTime.Now;
            deFechaFin.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Cuestionario - Nuevo";
                IdSituacion = Parametros.intCUESTIONARIOActivo;
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Cuestionario - Modificar";
                CuestionarioBE  objE_Cuestionario = null;
                objE_Cuestionario = new CuestionarioBL().Selecciona(Parametros.intEmpresaId, IdCuestionario);
                if (objE_Cuestionario != null)
                {
                    
                    txtDescripcion.Text = objE_Cuestionario.DescCuestionario;
                    deFechaIni.DateTime = objE_Cuestionario.FechaIni;
                    deFechaFin.DateTime = objE_Cuestionario.FechaFin;
                    txtNotaMaxima.EditValue = objE_Cuestionario.NotaMaxima;
                    txtNotaAprobatoria.EditValue = objE_Cuestionario.NotaAprobatoria;
                    txtDuracion.EditValue = objE_Cuestionario.Duracion;
                    IdSituacion = objE_Cuestionario.IdSituacion;
                }

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
                    CuestionarioBL objBL_Cuestionario = new CuestionarioBL();
                    CuestionarioBE objCuestionario = new CuestionarioBE();

                    objCuestionario.IdEmpresa = Parametros.intEmpresaId;
                    objCuestionario.IdCuestionario = IdCuestionario;
                    objCuestionario.IdTema = IdTema;
                    objCuestionario.DescCuestionario = txtDescripcion.Text;
                    objCuestionario.FechaIni = Convert.ToDateTime(deFechaIni.DateTime.ToShortDateString());
                    objCuestionario.FechaFin = Convert.ToDateTime(deFechaFin.DateTime.ToShortDateString());
                    objCuestionario.NotaMaxima = Convert.ToInt32(txtNotaMaxima.EditValue);
                    objCuestionario.NotaAprobatoria = Convert.ToInt32(txtNotaAprobatoria.EditValue);
                    objCuestionario.Duracion = Convert.ToInt32(txtDuracion.EditValue);
                    objCuestionario.IdSituacion = IdSituacion;
                    objCuestionario.FlagEstado = true;
                    objCuestionario.Usuario = Parametros.strUsuarioLogin;
                    objCuestionario.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Cuestionario.Inserta(objCuestionario);
                    else
                        objBL_Cuestionario.Actualiza(objCuestionario);

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
                var Buscar = lstCuestionario.Where(oB => oB.DescCuestionario.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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