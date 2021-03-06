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


namespace SSOMA.Presentacion.Modulos.Iperc.Maestros
{
    public partial class frmManSenalizacionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<SenalizacionBE> lstSenalizacion;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public SenalizacionBE pSenalizacionBE { get; set; }

        int _IdSenalizacion = 0;

        public int IdSenalizacion
        {
            get { return _IdSenalizacion; }
            set { _IdSenalizacion = value; }
        }

        #endregion

        #region "Eventos"

        public frmManSenalizacionEdit()
        {
            InitializeComponent();
        }

        private void frmManSenalizacionEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Señalización - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Señalización - Modificar";
                txtDescripcion.Text = pSenalizacionBE.DescSenalizacion.Trim();

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
                    SenalizacionBL objBL_Senalizacion = new SenalizacionBL();
                    SenalizacionBE objSenalizacion = new SenalizacionBE();
                    objSenalizacion.IdSenalizacion = IdSenalizacion;
                    objSenalizacion.DescSenalizacion = txtDescripcion.Text;
                    objSenalizacion.FlagEstado = true;
                    objSenalizacion.Usuario = Parametros.strUsuarioLogin;
                    objSenalizacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objSenalizacion.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Senalizacion.Inserta(objSenalizacion);
                    else
                        objBL_Senalizacion.Actualiza(objSenalizacion);

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
                var Buscar = lstSenalizacion.Where(oB => oB.DescSenalizacion.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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