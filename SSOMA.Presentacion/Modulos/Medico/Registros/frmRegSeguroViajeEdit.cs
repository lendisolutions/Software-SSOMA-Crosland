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
using System.Reflection;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace SSOMA.Presentacion.Modulos.Medico.Registros
{
    public partial class frmRegSeguroViajeEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        int _IdSeguroViaje = 0;

        public int IdSeguroViaje
        {
            get { return _IdSeguroViaje; }
            set { _IdSeguroViaje = value; }
        }

        private int intIdSolicitante = 0;
        private int intIdEmpresa = 0;

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

        public frmRegSeguroViajeEdit()
        {
            InitializeComponent();
        }

        private void frmRegSeguroViajeEdit_Load(object sender, EventArgs e)
        {
            deFechaSalida.EditValue = DateTime.Now;
            deFechaLlegada.EditValue = DateTime.Now.AddDays(1);

            txtContacto.Text = Parametros.strContactoSeguroViaje;
            txtTelefonoContacto1.Text = Parametros.strContactoTelefono;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Registro de Afiliación de Seguro de Viaje - Nuevo ";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Registro de Afiliación de Seguro de Viaje - Modificar ";
                SeguroViajeBE objE_SeguroViaje = null;
                objE_SeguroViaje = new SeguroViajeBL().Selecciona(IdSeguroViaje);
                if (objE_SeguroViaje != null)
                {
                    IdSeguroViaje = objE_SeguroViaje.IdSeguroViaje;
                    txtNumero.Text = objE_SeguroViaje.Numero;
                    deFechaSalida.EditValue = objE_SeguroViaje.FechaSalida;
                    deFechaLlegada.EditValue = objE_SeguroViaje.FechaLlegada;
                    txtDias.EditValue = objE_SeguroViaje.Dias;
                    txtPais.Text = objE_SeguroViaje.Pais;
                    intIdSolicitante = objE_SeguroViaje.IdPersona;
                    txtSolicitante.Text = objE_SeguroViaje.Solicitante;
                    intIdEmpresa = objE_SeguroViaje.IdEmpresa;
                    txtEmpresa.Text = objE_SeguroViaje.RazonSocial;
                    txtCargo.Text = objE_SeguroViaje.Cargo;
                    deFechaNacimiento.EditValue = objE_SeguroViaje.FechaNacimiento;
                    txtPasaporte.Text = objE_SeguroViaje.Pasaporte;
                    txtDni.Text = objE_SeguroViaje.Dni;
                    txtDireccion.Text = objE_SeguroViaje.Direccion;
                    txtDistrito.Text = objE_SeguroViaje.Distrito;
                    txtTelefono.Text = objE_SeguroViaje.Telefono;
                    txtEmailTrabajo.Text = objE_SeguroViaje.Email;
                    txtEmailPersonal.Text = objE_SeguroViaje.EmailPersonal;
                    txtContacto.Text = objE_SeguroViaje.Contacto;
                    txtTelefonoContacto1.Text = objE_SeguroViaje.TelefonoContacto1;
                    txtTelefonoContacto2.Text = objE_SeguroViaje.TelefonoContacto2;
                    txtEmpresaBoleta.Text = objE_SeguroViaje.EmpresaBoleta;
                    txtEmpresaFactura.Text = objE_SeguroViaje.EmpresaFactura;
                    txtRuc.Text = objE_SeguroViaje.Ruc;
                    txtAutoriza.Text = objE_SeguroViaje.Autoriza;
                    txtOICECO.Text = objE_SeguroViaje.Oiseco;
                }
            }

            deFechaSalida.Select();
        }

        private void deFechaLlegada_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int intDias = 0;

                DateTime FechaIni = deFechaSalida.DateTime;
                DateTime FechaFin = deFechaLlegada.DateTime;

                intDias = CalculateDays(FechaIni, FechaFin);

                if (intDias >= 0)
                {
                    txtDias.EditValue = intDias + 1;
                }
                else
                {
                    XtraMessageBox.Show("La fecha de llegada no puede ser menor a la fecha de Salida del viaje.\n Por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    deFechaLlegada.Select();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtCargo.Text = frm.pPersonaBE.Cargo;
                    txtDni.Text = frm.pPersonaBE.Dni;
                    deFechaNacimiento.EditValue = frm.pPersonaBE.FechaNacimiento;
                    txtEmailTrabajo.Text = frm.pPersonaBE.Email;
                    txtEmpresaFactura.Text = frm.pPersonaBE.RazonSocial;
                    txtRuc.Text = frm.pPersonaBE.Ruc;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscaAutoriza_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = false;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    txtAutoriza.Text = frm.pPersonaBE.ApeNom;
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
                    SeguroViajeBE objSeguroViaje = new SeguroViajeBE();
                    SeguroViajeBL objBL_SeguroViaje = new SeguroViajeBL();

                    objSeguroViaje.IdSeguroViaje = IdSeguroViaje;
                    objSeguroViaje.IdEmpresa = intIdEmpresa;
                    objSeguroViaje.Numero = txtNumero.Text;
                    objSeguroViaje.FechaSalida = Convert.ToDateTime(deFechaSalida.DateTime.ToShortDateString());
                    objSeguroViaje.FechaLlegada = Convert.ToDateTime(deFechaLlegada.DateTime.ToShortDateString());
                    objSeguroViaje.Dias = Convert.ToInt32(txtDias.EditValue);
                    objSeguroViaje.Pais = txtPais.Text;
                    objSeguroViaje.IdPersona = intIdSolicitante;
                    objSeguroViaje.Dni = txtDni.Text;
                    objSeguroViaje.Pasaporte = txtPasaporte.Text;
                    objSeguroViaje.Solicitante = txtSolicitante.Text;
                    objSeguroViaje.FechaNacimiento = Convert.ToDateTime(deFechaNacimiento.DateTime.ToShortDateString());
                    objSeguroViaje.Direccion = txtDireccion.Text;
                    objSeguroViaje.Distrito = txtDistrito.Text;
                    objSeguroViaje.Telefono = txtTelefono.Text;
                    objSeguroViaje.Email = txtEmailTrabajo.Text;
                    objSeguroViaje.EmailPersonal = txtEmailPersonal.Text;
                    objSeguroViaje.Cargo = txtCargo.Text;
                    objSeguroViaje.Contacto = txtContacto.Text;
                    objSeguroViaje.TelefonoContacto1 = txtTelefonoContacto1.Text;
                    objSeguroViaje.TelefonoContacto2 = txtTelefonoContacto2.Text;
                    objSeguroViaje.EmpresaBoleta = txtEmpresaBoleta.Text;
                    objSeguroViaje.EmpresaFactura = txtEmpresaFactura.Text;
                    objSeguroViaje.Ruc = txtRuc.Text;
                    objSeguroViaje.Autoriza = txtAutoriza.Text;
                    objSeguroViaje.Oiseco = txtOICECO.Text;
                    objSeguroViaje.IdSituacion = Parametros.intSVJGenerada;
                    objSeguroViaje.FlagEstado = true;
                    objSeguroViaje.Usuario = Parametros.strUsuarioLogin;
                    objSeguroViaje.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                    {
                        int intNumero = 0;
                        string strNumero = "";
                        intNumero = objBL_SeguroViaje.Inserta(objSeguroViaje);
                        strNumero = FuncionBase.AgregarCaracter(intNumero.ToString(), "0", 7);
                        txtNumero.Text = strNumero;

                        //ActualizaNumero
                        SeguroViajeBL objBSeguroViaje = new SeguroViajeBL();
                        objBSeguroViaje.ActualizaNumero(intNumero, txtNumero.Text);

                        //LLENAMOS EL FORMATO EXCEL DE SEGURO DE VIAJE
                        ExportarFormatoExcel("", intNumero);

                        StringBuilder strMensaje = new StringBuilder();
                        strMensaje.Append("*****************************************************************************\n\n");
                        strMensaje.Append("Se Generó el N° de Solicitud de Afiliación de Seguro de Viaje : " + strNumero + "\n\n");
                        strMensaje.Append("Solicitante : " + txtSolicitante.Text + "\n");
                        strMensaje.Append("Empresa : " + txtEmpresa.Text + "\n\n");
                        strMensaje.Append("Emitido Por el Area de Bienestar Seguridad y Salud en el Trabajo" + "\n\n");
                        strMensaje.Append("*****************************************************************************\n\n");

                        BSUtils.EmailSend("zmonteverde@crosland.com.pe", "Solicitud de Afiliación de Seguro de Viaje", strMensaje.ToString(), "D:\\Seguro de Viaje " + strNumero + ".xlsx", "", "", "");

                        XtraMessageBox.Show("Se creó la solicitud de afiliación del seguro de viaje N° : " + txtNumero.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        objBL_SeguroViaje.Actualiza(objSeguroViaje);
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

            if (txtPais.Text == "")
            {
                strMensaje = strMensaje + "- Debe ingresar el pais.\n";
                flag = true;
            }

            if (txtPasaporte.Text == "")
            {
                strMensaje = strMensaje + "- Debe ingresar el pasaporte.\n";
                flag = true;
            }

            if (txtDireccion.Text == "")
            {
                strMensaje = strMensaje + "- Debe ingresar la dirección.\n";
                flag = true;
            }

            if (txtDistrito.Text == "")
            {
                strMensaje = strMensaje + "- Debe ingresar el distrito.\n";
                flag = true;
            }

            if (txtTelefono.Text == "")
            {
                strMensaje = strMensaje + "- Debe ingresar el teléfono.\n";
                flag = true;
            }

            if (txtEmailPersonal.Text == "")
            {
                strMensaje = strMensaje + "- Debe ingresar el email personal.\n";
                flag = true;
            }

            if (txtAutoriza.Text == "")
            {
                strMensaje = strMensaje + "- Debe seleccionar la persona quien autoriza.\n";
                flag = true;
            }

            if (txtOICECO.Text == "")
            {
                strMensaje = strMensaje + "- Debe ingresar el centro de costos.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private int CalculateDays(DateTime oldDate, DateTime newDate)
        {
            // Diferencia de fechas
            TimeSpan ts = newDate - oldDate;

            // Diferencia de días
            return ts.Days;
        }

        void ExportarFormatoExcel(string filename, int IdSeguroViaje)
        {
            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Seguro de Viaje.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            string strNumero = "";

            Cursor.Current = Cursors.WaitCursor;
            
            try
            {
                SeguroViajeBE objE_SeguroViaje = null;
                objE_SeguroViaje = new SeguroViajeBL().Selecciona(IdSeguroViaje);
                if (objE_SeguroViaje != null)
                {
                    xlHoja.Cells[3, "H"] = objE_SeguroViaje.Numero;
                    strNumero = objE_SeguroViaje.Numero;
                    xlHoja.Cells[8, "D"] = objE_SeguroViaje.FechaSalida;
                    xlHoja.Cells[8, "H"] = objE_SeguroViaje.FechaLlegada;
                    xlHoja.Cells[11, "C"] = objE_SeguroViaje.Dias;
                    xlHoja.Cells[13, "C"] = objE_SeguroViaje.Pais;
                    xlHoja.Cells[13, "H"] = objE_SeguroViaje.FechaNacimiento;
                    xlHoja.Cells[16, "C"] = objE_SeguroViaje.Pasaporte;
                    xlHoja.Cells[16, "H"] = objE_SeguroViaje.Dni;

                    String[] strSolicitante = objE_SeguroViaje.Solicitante.Split(' ');
                    string strPrimerNombre = "";
                    string strSegundoNombre = "";
                    string strApellidoPaterno = "";
                    string strApellidoMaterno = "";

                    strPrimerNombre = strSolicitante[3].ToString();
                    strSegundoNombre = strSolicitante[2].ToString();
                    strApellidoPaterno = strSolicitante[1].ToString();
                    strApellidoMaterno = strSolicitante[0].ToString();

                    xlHoja.Cells[18, "C"] = strApellidoPaterno;
                    xlHoja.Cells[18, "F"] = strApellidoMaterno;
                    xlHoja.Cells[20, "C"] = strPrimerNombre;
                    xlHoja.Cells[20, "F"] = strSegundoNombre;
                    xlHoja.Cells[22, "C"] = objE_SeguroViaje.Direccion;
                    xlHoja.Cells[24, "C"] = objE_SeguroViaje.Distrito;
                    xlHoja.Cells[26, "C"] = objE_SeguroViaje.Telefono;
                    xlHoja.Cells[28, "C"] = objE_SeguroViaje.Email + " / " + objE_SeguroViaje.EmailPersonal;
                    xlHoja.Cells[32, "C"] = objE_SeguroViaje.Contacto;
                    xlHoja.Cells[34, "C"] = objE_SeguroViaje.TelefonoContacto1;
                    xlHoja.Cells[36, "C"] = objE_SeguroViaje.TelefonoContacto2;
                    xlHoja.Cells[42, "B"] = objE_SeguroViaje.EmpresaBoleta;
                    xlHoja.Cells[46, "C"] = objE_SeguroViaje.EmpresaFactura;
                    xlHoja.Cells[48, "C"] = objE_SeguroViaje.Ruc;
                    xlHoja.Cells[56, "C"] = objE_SeguroViaje.Solicitante;
                    xlHoja.Cells[57, "C"] = objE_SeguroViaje.Cargo;
                    xlHoja.Cells[60, "C"] = objE_SeguroViaje.RazonSocial;
                    xlHoja.Cells[61, "C"] = objE_SeguroViaje.Autoriza;
                    xlHoja.Cells[60, "H"] = objE_SeguroViaje.Oiseco;
                }

                
                xlLibro.SaveAs("D:\\Seguro de Viaje " + strNumero + ".xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;

                
            }
            catch (Exception ex)
            {
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        #endregion


    }
}