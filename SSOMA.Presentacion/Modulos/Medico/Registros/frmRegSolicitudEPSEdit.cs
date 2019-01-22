using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Funciones;
using CrystalDecisions.CrystalReports.Engine;
using SSOMA.BusinessLogic;
using SSOMA.BusinessEntity;
using SSOMA.Presentacion.Modulos.Otros;

namespace SSOMA.Presentacion.Modulos.Medico.Registros
{
    public partial class frmRegSolicitudEPSEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        int _IdSolicitud = 0;

        public int IdSolicitud
        {
            get { return _IdSolicitud; }
            set { _IdSolicitud = value; }
        }

        private int intIdSolicitante = 0;
        private int intIdEmpresa = 0;
        private int intIdUnidadMinera = 0;
        private int intIdArea = 0;

        private string strEmailSolicitante = "";
        private string strFechaIngreso = "";

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;

        #endregion

        #region "Eventos"

        public frmRegSolicitudEPSEdit()
        {
            InitializeComponent();
        }

        private void frmRegSolicitudEPSEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Registro Solicitud de Información de EPS - Nuevo ";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Registro Solicitud de Información de EPS - Modificar ";
                SolicitudBE objE_Solicitud = null;
                objE_Solicitud = new SolicitudBL().Selecciona(IdSolicitud);
                if (objE_Solicitud != null)
                {
                    IdSolicitud = objE_Solicitud.IdSolicitud;
                    deFecha.EditValue = objE_Solicitud.Fecha;
                    txtNumero.Text = objE_Solicitud.Numero;
                    intIdSolicitante = objE_Solicitud.IdPersona;
                    txtSolicitante.Text = objE_Solicitud.Solicitante;
                    intIdEmpresa = objE_Solicitud.IdEmpresa;
                    intIdUnidadMinera = objE_Solicitud.IdUnidadMinera;
                    intIdArea = objE_Solicitud.IdArea;
                    txtEmpresa.Text = objE_Solicitud.RazonSocial;
                    txtUnidadMinera.Text = objE_Solicitud.DescUnidadMinera;
                    txtArea.Text = objE_Solicitud.DescArea;
                    txtCargo.Text = objE_Solicitud.Cargo;

                }
            }
        }

        private void btnBuscarSolicitante_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = false;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    intIdSolicitante = frm.pPersonaBE.IdPersona;
                    txtSolicitante.Text = frm.pPersonaBE.ApeNom;
                    
                    intIdEmpresa = frm.pPersonaBE.IdEmpresa;
                    txtEmpresa.Text = frm.pPersonaBE.RazonSocial;
                    intIdUnidadMinera = frm.pPersonaBE.IdUnidadMinera;
                    txtUnidadMinera.Text = frm.pPersonaBE.DescUnidadMinera;
                    intIdArea = frm.pPersonaBE.IdArea;
                    txtArea.Text = frm.pPersonaBE.DescArea;
                    txtCargo.Text = frm.pPersonaBE.Cargo;
                    strEmailSolicitante = frm.pPersonaBE.Email;
                    strFechaIngreso = frm.pPersonaBE.FechaIngreso.ToString().Substring(0,10);
                    
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
                    SolicitudBE objSolicitud = new SolicitudBE();
                    SolicitudBL objBL_Solicitud = new SolicitudBL();

                    objSolicitud.IdSolicitud = IdSolicitud;
                    objSolicitud.IdEmpresa = intIdEmpresa;
                    objSolicitud.IdUnidadMinera = intIdUnidadMinera;
                    objSolicitud.IdArea = intIdArea;
                    objSolicitud.Numero = txtNumero.Text;
                    objSolicitud.IdPersona = intIdSolicitante;
                    objSolicitud.Solicitante = txtSolicitante.Text;
                    objSolicitud.Cargo = txtCargo.Text;
                    objSolicitud.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objSolicitud.IdSituacion = Parametros.intSCEPSGenerada;
                    objSolicitud.FlagEstado = true;
                    objSolicitud.Usuario = Parametros.strUsuarioLogin;
                    objSolicitud.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    
                    if (pOperacion == Operacion.Nuevo)
                    {
                        int intNumero = 0;
                        string strNumero = "";
                        intNumero = objBL_Solicitud.Inserta(objSolicitud);
                        strNumero = FuncionBase.AgregarCaracter(intNumero.ToString(), "0", 7);
                        txtNumero.Text = strNumero;

                        //ActualizaNumero
                        SolicitudBL objBSolicitud = new SolicitudBL();
                        objBSolicitud.ActualizaNumero(intNumero, txtNumero.Text);

                        StringBuilder strMensaje = new StringBuilder();
                        strMensaje.Append("********************************************************************************************************************************************************************************************\n\n");
                        strMensaje.Append("Se Generó el N° de Solicitud de Información de EPS : " + strNumero + "\n\n");
                        strMensaje.Append("Se adjunta información acerca de la EPS (Plan de Salud y Boletín Informativo) así como los formatos para afiliación, los mismos que deberán ser llenados y firmados por el solicitante. Presentar al Área de Bienestar Seguridad y Salud en el Trabajo" + "\n");
                        strMensaje.Append("hasta el 24 del presente, para que la vigencia inicie el primer día del mes siguiente (si los documentos se presentan luego del día 24, la vigencia demorará un mes más)." + "\n\n");
                        strMensaje.Append("Adjuntar:" + "\n");
                        strMensaje.Append("1. Partida de Matrimonio en caso de ser casado." + "\n");
                        strMensaje.Append("2. Unión de Hecho en caso de ser conviviente" + "\n");
                        strMensaje.Append("3. DNI escaneados de los titulares y dependientes a incorporar en el Seguro." + "\n");
                        strMensaje.Append("4. Constancia de afiliación en EPS anterior (para mantener preexistencias)." + "\n\n");
                        strMensaje.Append("Bienestar realizará la gestión del Seguro." + "\n\n");
                        strMensaje.Append("Cualquier información adicional al 989059808 o al anexo 2267. (Zarella Monteverde)" + "\n\n");
                        strMensaje.Append("*******************************************************************************************************************************************************************************************\n\n");

                        string strArchivo1 = Path.Combine(Directory.GetCurrentDirectory(), "Formato de afiliación EPS 1.jpg");
                        string strArchivo2 = Path.Combine(Directory.GetCurrentDirectory(), "Formato de afiliación EPS 2.jpg");
                        string strArchivo3 = Path.Combine(Directory.GetCurrentDirectory(), "Plan de Salud EPS.pdf");
                        string strArchivo4 = Path.Combine(Directory.GetCurrentDirectory(), "Boletin Informativo EPS.pdf");

                        BSUtils.EmailSend(strEmailSolicitante, "Solicitud de Información de EPS", strMensaje.ToString(), strArchivo1, strArchivo2, strArchivo3, strArchivo4);

                        Application.DoEvents();

                        StringBuilder strMensajeDestino = new StringBuilder();
                        strMensajeDestino.Append("*****************************************************************************\n\n");
                        strMensajeDestino.Append("Se Generó el N° de Solicitud de Información de EPS : " + strNumero + "\n\n");
                        strMensajeDestino.Append("Fecha de Solicitud : " +  deFecha.DateTime.ToString().Substring(0,10) + "\n\n");
                        strMensajeDestino.Append("Solictante : " + txtSolicitante.Text + "\n\n");
                        strMensajeDestino.Append("Cargo : " + txtCargo.Text + "\n\n");
                        strMensajeDestino.Append("Fecha de Ingreso : " + strFechaIngreso + "\n\n");
                        strMensajeDestino.Append("Empresa : " + txtEmpresa.Text + "\n\n");
                        strMensajeDestino.Append("Sede : " + txtUnidadMinera.Text + "\n\n");
                        strMensajeDestino.Append("Area : " + txtArea.Text + "\n\n");
                        strMensajeDestino.Append("Emitido Por el Area de Bienestar Seguridad y Salud en el Trabajo" + "\n\n");
                        strMensajeDestino.Append("*****************************************************************************\n\n");

                        BSUtils.EmailSend("zmonteverde@crosland.com.pe", "Solicitud de Información de EPS", strMensajeDestino.ToString(), "", "", "","");

                        XtraMessageBox.Show("Se creó la Solicitud de Información de EPS N° : " + txtNumero.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        objBL_Solicitud.Actualiza(objSolicitud);
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

            if (intIdSolicitante == 0)
            {
                strMensaje = strMensaje + "- Debe selecciona al solicitante de información de EPS.\n";
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


    }
}