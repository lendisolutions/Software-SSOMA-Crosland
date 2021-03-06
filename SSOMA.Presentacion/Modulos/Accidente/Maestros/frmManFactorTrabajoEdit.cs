﻿using System;
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

namespace SSOMA.Presentacion.Modulos.Accidente.Maestros
{
    public partial class frmManFactorTrabajoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<FactorTrabajoBE> lstFactorTrabajo;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public FactorTrabajoBE pFactorTrabajoBE { get; set; }

        int _IdFactorTrabajo = 0;

        public int IdFactorTrabajo
        {
            get { return _IdFactorTrabajo; }
            set { _IdFactorTrabajo = value; }
        }

        #endregion

        #region "Eventos"

        public frmManFactorTrabajoEdit()
        {
            InitializeComponent();
        }

        private void frmManFactorTrabajoEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Factor Trabajo - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Factor Trabajo - Modificar";
                txtDescripcion.Text = pFactorTrabajoBE.DescFactorTrabajo.Trim();

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
                    FactorTrabajoBL objBL_FactorTrabajo = new FactorTrabajoBL();
                    FactorTrabajoBE objFactorTrabajo = new FactorTrabajoBE();
                    objFactorTrabajo.IdFactorTrabajo = IdFactorTrabajo;
                    objFactorTrabajo.DescFactorTrabajo = txtDescripcion.Text;
                    objFactorTrabajo.FlagEstado = true;
                    objFactorTrabajo.Usuario = Parametros.strUsuarioLogin;
                    objFactorTrabajo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objFactorTrabajo.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_FactorTrabajo.Inserta(objFactorTrabajo);
                    else
                        objBL_FactorTrabajo.Actualiza(objFactorTrabajo);

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
                var Buscar = lstFactorTrabajo.Where(oB => oB.DescFactorTrabajo.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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