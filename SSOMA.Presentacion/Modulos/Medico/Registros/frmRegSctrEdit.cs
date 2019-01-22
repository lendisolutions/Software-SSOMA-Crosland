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
    public partial class frmRegSctrEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SctrBE> mLista = new List<SctrBE>();

        int _IdSctr = 0;

        public int IdSctr
        {
            get { return _IdSctr; }
            set { _IdSctr = value; }
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

        public frmRegSctrEdit()
        {
            InitializeComponent();
        }

        private void frmRegSctrEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
           
            BSUtils.LoaderLook(cboMes, CargarMes(), "Descripcion", "Id", false);
            BSUtils.LoaderLook(cboTipoDocumento, CargarTipoDocumento(), "Descripcion", "Id", true);
            BSUtils.LoaderLook(cboNacionalidad, CargarNacionalidad(), "Descripcion", "Id", true);

            cboMes.EditValue = DateTime.Now.Month;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Registro de Afiliación de SCTR - Nuevo ";

            }

            deFecha.Select();
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
                    txtSexo.Text = frm.pPersonaBE.Sexo;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdcionar_Click(object sender, EventArgs e)
        {
            try
            {
                var Buscar = mLista.Where(oB => oB.IdPersona == intIdSolicitante).ToList();
                if (Buscar.Count > 0)
                {
                    XtraMessageBox.Show("El Solicitante ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (intIdSolicitante == 0)
                {
                    XtraMessageBox.Show("Seleccione al solicitante", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SctrBE objE_SCTR = new SctrBE();
                objE_SCTR.IdEmpresa = intIdEmpresa;
                objE_SCTR.RazonSocial = txtEmpresa.Text;
                objE_SCTR.Numero = "";
                objE_SCTR.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objE_SCTR.Mes = Convert.ToInt32(cboMes.EditValue);
                objE_SCTR.DescMes = cboMes.Text;
                objE_SCTR.TipoDocumento = cboTipoDocumento.Text;
                objE_SCTR.IdPersona = intIdSolicitante;
                objE_SCTR.Solicitante = txtSolicitante.Text;
                objE_SCTR.NumeroDocumento = txtDni.Text;
                objE_SCTR.Cargo = txtCargo.Text;
                objE_SCTR.Sexo = txtSexo.Text;
                objE_SCTR.FechaNacimiento = Convert.ToDateTime(deFechaNacimiento.DateTime.ToShortDateString());
                objE_SCTR.Nacionalidad = cboNacionalidad.Text;

                mLista.Add(objE_SCTR);

                gcSctr.DataSource = mLista;
                gcSctr.RefreshDataSource();

                //LIMPIAR CAJAS DE TEXTO
                intIdSolicitante = 0;
                intIdEmpresa = 0;
                txtEmpresa.Text = "";
                txtSolicitante.Text = "";
                txtDni.Text = "";
                txtCargo.Text = "";
                deFechaNacimiento.EditValue = null;
                txtSexo.Text = "";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    gvSctr.DeleteRow(gvSctr.FocusedRowHandle);
                    gvSctr.RefreshData();
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
                    foreach (var item in mLista)
                    {
                        SctrBE objSctr = new SctrBE();
                        SctrBL objBL_Sctr = new SctrBL();

                        objSctr.IdSctr = IdSctr;
                        objSctr.IdEmpresa = item.IdEmpresa;
                        objSctr.Numero = "";
                        objSctr.Fecha = item.Fecha;
                        objSctr.Mes = item.Mes;
                        objSctr.TipoDocumento = item.TipoDocumento;
                        objSctr.IdPersona = item.IdPersona;
                        objSctr.NumeroDocumento = item.NumeroDocumento;
                        objSctr.Solicitante = item.Solicitante;
                        objSctr.Cargo = item.Cargo;
                        objSctr.FechaNacimiento = item.FechaNacimiento;
                        objSctr.Nacionalidad = item.Nacionalidad;
                        objSctr.IdSituacion = Parametros.intSCTRGenerada;
                        objSctr.FlagEstado = true;
                        objSctr.Usuario = Parametros.strUsuarioLogin;
                        objSctr.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        if (pOperacion == Operacion.Nuevo)
                        {
                            int intNumero = 0;
                            string strNumero = "";
                            intNumero = objBL_Sctr.Inserta(objSctr);
                            strNumero = FuncionBase.AgregarCaracter(intNumero.ToString(), "0", 7);
                            

                            //ActualizaNumero
                            SctrBL objBSctr = new SctrBL();
                            objBSctr.ActualizaNumero(intNumero, strNumero);

                            

                        }
                        else
                        {
                            objBL_Sctr.Actualiza(objSctr);
                        }
                    }

                    //LLENAMOS EL FORMATO EXCEL DE SCTR
                    ExportarFormatoExcel("");

                    StringBuilder strMensaje = new StringBuilder();
                    strMensaje.Append("*****************************************************************************\n\n");
                    strMensaje.Append("Se Generó el N° de Solicitud de Afiliación SCTR" + "\n\n");
                    strMensaje.Append("Emitido Por el Area de Bienestar Seguridad y Salud en el Trabajo" + "\n\n");
                    strMensaje.Append("*****************************************************************************\n\n");

                    BSUtils.EmailSend("zmonteverde@crosland.com.pe", "Solicitud de Afiliación de SCTR", strMensaje.ToString(), "D:\\Plantilla SCTR.xlsx", "", "", "");

                    XtraMessageBox.Show("Se creó la solicitud de afiliación del seguro SCTR", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


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

            
            if (mLista.Count == 0)
            {
                strMensaje = strMensaje + "- Debe agregar solicitante a la lista.\n";
                flag = true;
            }
            
            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private DataTable CargarMes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "ENERO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "FEBRERO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["Descripcion"] = "MARZO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 4;
            dr["Descripcion"] = "ABRIL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 5;
            dr["Descripcion"] = "MAYO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 6;
            dr["Descripcion"] = "JUNIO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 7;
            dr["Descripcion"] = "JULIO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 8;
            dr["Descripcion"] = "AGOSTO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 9;
            dr["Descripcion"] = "SEPTIEMBRE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 10;
            dr["Descripcion"] = "OCTUBRE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 11;
            dr["Descripcion"] = "NOVIEMBRE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 12;
            dr["Descripcion"] = "DICIEMBRE";
            dt.Rows.Add(dr);

            return dt;
        }

        private DataTable CargarTipoDocumento()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "DNI";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "CARNET EXTRANJERIA";
            dt.Rows.Add(dr);
           
            return dt;
        }

        private DataTable CargarNacionalidad()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "PERUANA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "EXTRANJERA";
            dt.Rows.Add(dr);

            return dt;
        }

        void ExportarFormatoExcel(string filename)
        {
            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Plantilla SCTR.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            int intRow = 2;

            try
            {
                if (mLista.Count > 0)
                {
                    foreach (var item in mLista)
                    {
                        xlHoja.Cells[intRow, 1] = item.RazonSocial;
                        xlHoja.Cells[intRow, 2] = item.DescMes;
                        xlHoja.Cells[intRow, 3] = item.TipoDocumento;
                        xlHoja.Cells[intRow, 4] = item.NumeroDocumento;

                        String[] strSolicitante = item.Solicitante.Split(' ');
                        string strPrimerNombre = "";
                        string strSegundoNombre = "";
                        string strApellidoPaterno = "";
                        string strApellidoMaterno = "";

                        strPrimerNombre = strSolicitante[3].ToString();
                        strSegundoNombre = strSolicitante[2].ToString();
                        strApellidoPaterno = strSolicitante[1].ToString();
                        strApellidoMaterno = strSolicitante[0].ToString();

                        xlHoja.Cells[intRow, 5] = strApellidoMaterno;
                        xlHoja.Cells[intRow, 6] = strApellidoPaterno;
                        xlHoja.Cells[intRow, 7] = strPrimerNombre;
                        xlHoja.Cells[intRow, 8] = strSegundoNombre;
                        xlHoja.Cells[intRow, 9] = item.Sexo;
                        xlHoja.Cells[intRow, 10] = item.FechaNacimiento;
                        xlHoja.Cells[intRow, 11] = item.Nacionalidad;
                        xlHoja.Cells[intRow, 12] = "3";
                        xlHoja.Cells[intRow, 13] = item.Cargo;

                        intRow = intRow + 1;
                    }
                }

                xlLibro.SaveAs("D:\\Plantilla SCTR.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
               
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