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
    public partial class frmManEquipoProteccionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<EquipoProteccionBE> lstEquipoProteccion;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public EquipoProteccionBE pEquipoProteccionBE { get; set; }

        int _IdEquipoProteccion = 0;

        public int IdEquipoProteccion
        {
            get { return _IdEquipoProteccion; }
            set { _IdEquipoProteccion = value; }
        }

        #endregion

        #region "Eventos"

        public frmManEquipoProteccionEdit()
        {
            InitializeComponent();
        }

        private void frmManEquipoProteccionEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "EPPS - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "EPPS - Modificar";
                txtDescripcion.Text = pEquipoProteccionBE.DescEquipoProteccion.Trim();

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
                    EquipoProteccionBL objBL_EquipoProteccion = new EquipoProteccionBL();
                    EquipoProteccionBE objEquipoProteccion = new EquipoProteccionBE();
                    objEquipoProteccion.IdEquipoProteccion = IdEquipoProteccion;
                    objEquipoProteccion.DescEquipoProteccion = txtDescripcion.Text;
                    objEquipoProteccion.FlagEstado = true;
                    objEquipoProteccion.Usuario = Parametros.strUsuarioLogin;
                    objEquipoProteccion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objEquipoProteccion.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_EquipoProteccion.Inserta(objEquipoProteccion);
                    else
                        objBL_EquipoProteccion.Actualiza(objEquipoProteccion);

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
                var Buscar = lstEquipoProteccion.Where(oB => oB.DescEquipoProteccion.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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