using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using DevExpress.XtraEditors;
using SSOMA.Presentacion.Modulos.Otros;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace SSOMA.Presentacion.Modulos.Accidente.Reportes
{
    public partial class frmRepAccidenteEstadisticaGeneral : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"

        public frmRepAccidenteEstadisticaGeneral()
        {
            InitializeComponent();
        }

        private void frmRepAccidenteEstadisticaGeneral_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            txtPeriodo.EditValue = Parametros.intPeriodo;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarFormatoExcel("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        void ExportarFormatoExcel(string filename)
        {
            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel._Worksheet xlSegundaHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Estadistica de Accidentes.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                EmpresaBE objE_Empresa = null;
                objE_Empresa = new EmpresaBL().Selecciona(Parametros.intEmpresaId);

                PictureBox picImg = new PictureBox();
                picImg.Image = new FuncionBase().Bytes2Image((byte[])objE_Empresa.Logo);
                string strRuta = Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg");

                picImg.Image.Save(strRuta, System.Drawing.Imaging.ImageFormat.Jpeg);

                xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 40, 65, 45, 35);

                xlHoja.Cells[8,4] = cboEmpresa.Text;
                xlHoja.Cells[8,15] = txtPeriodo.Text;

                //INCIDENTE MENSUAL
                int intMesI = 1;
                for (int i = 12; i < 24; i++)
                {
                    xlHoja.Cells[i, "B"] = new AccidenteBL().SeleccionaTipoNumeroMensual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIIncidente, Convert.ToInt32(txtPeriodo.EditValue), intMesI);
                    
                    string strSedeI = "";
                    List<AccidenteBE> lstIncidenteSede = null;
                    lstIncidenteSede = new AccidenteBL().ListaUnidadMineraMensual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIIncidente, Convert.ToInt32(txtPeriodo.EditValue), intMesI);

                    if (lstIncidenteSede.Count > 0)
                    {
                        foreach (var item in lstIncidenteSede)
                        {
                            strSedeI = strSedeI + item.UnidadMineraResponsable + ",";
                        }

                        xlHoja.Cells[i, "C"] = strSedeI.Substring(0, strSedeI.Length - 1);
                    }

                    string strSectorI = "";
                    List<AccidenteBE> lstIncidenteSector = null;
                    lstIncidenteSector = new AccidenteBL().ListaSectorMensual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIIncidente, Convert.ToInt32(txtPeriodo.EditValue), intMesI);

                    if (lstIncidenteSector.Count > 0)
                    {
                        foreach (var item in lstIncidenteSector)
                        {
                            strSectorI = strSectorI + item.SectorResponsable + ",";
                        }

                        xlHoja.Cells[i, "D"] = strSectorI.Substring(0, strSectorI.Length - 1);
                    }

                    intMesI++;
                }

                //INCIDENTE PELIGROSO
                int intMesP = 1;
                for (int i = 12; i < 24; i++)
                {
                    xlHoja.Cells[i, "E"] = new AccidenteBL().SeleccionaTipoNumeroMensual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIIncidentePeligroso, Convert.ToInt32(txtPeriodo.EditValue), intMesP);

                    string strSedeI = "";
                    List<AccidenteBE> lstIncidenteSede = null;
                    lstIncidenteSede = new AccidenteBL().ListaUnidadMineraMensual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIIncidentePeligroso, Convert.ToInt32(txtPeriodo.EditValue), intMesP);

                    if (lstIncidenteSede.Count > 0)
                    {
                        foreach (var item in lstIncidenteSede)
                        {
                            strSedeI = strSedeI + item.UnidadMineraResponsable + ",";
                        }

                        xlHoja.Cells[i, "F"] = strSedeI.Substring(0, strSedeI.Length - 1);
                    }

                    string strSectorI = "";
                    List<AccidenteBE> lstIncidenteSector = null;
                    lstIncidenteSector = new AccidenteBL().ListaSectorMensual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIIncidentePeligroso, Convert.ToInt32(txtPeriodo.EditValue), intMesP);

                    if (lstIncidenteSector.Count > 0)
                    {
                        foreach (var item in lstIncidenteSector)
                        {
                            strSectorI = strSectorI + item.SectorResponsable + ",";
                        }

                        xlHoja.Cells[i, "G"] = strSectorI.Substring(0, strSectorI.Length - 1);
                    }

                    intMesP++;
                }

                //ACCIDENTE
                int intMesA = 1;
                for (int i = 12; i < 24; i++)
                {
                    xlHoja.Cells[i, "I"] = new AccidenteBL().SeleccionaTipoNumeroMensual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIAccidente, Convert.ToInt32(txtPeriodo.EditValue), intMesA);

                    string strSedeI = "";
                    List<AccidenteBE> lstIncidenteSede = null;
                    lstIncidenteSede = new AccidenteBL().ListaUnidadMineraMensual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIAccidente, Convert.ToInt32(txtPeriodo.EditValue), intMesA);

                    if (lstIncidenteSede.Count > 0)
                    {
                        foreach (var item in lstIncidenteSede)
                        {
                            strSedeI = strSedeI + item.UnidadMineraResponsable + ",";
                        }

                        xlHoja.Cells[i, "J"] = strSedeI.Substring(0, strSedeI.Length - 1);
                    }

                    string strSectorI = "";
                    List<AccidenteBE> lstIncidenteSector = null;
                    lstIncidenteSector = new AccidenteBL().ListaSectorMensual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIAccidente, Convert.ToInt32(txtPeriodo.EditValue), intMesA);

                    if (lstIncidenteSector.Count > 0)
                    {
                        foreach (var item in lstIncidenteSector)
                        {
                            strSectorI = strSectorI + item.SectorResponsable + ",";
                        }

                        xlHoja.Cells[i, "K"] = strSectorI.Substring(0, strSectorI.Length - 1);
                    }

                    intMesA++;
                }

                //ACCIDENTE HORAS TRABAJADAS
                int intMesHoras = 1;
                for (int i = 12; i < 24; i++)
                {
                    xlHoja.Cells[i, "H"] = new HoraTrabajadaBL().SeleccionaHora(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(txtPeriodo.EditValue), intMesHoras);
                    intMesHoras++;
                }

                //ACCIDENTE DIAS PERDIDOS
                int intMesDiaPerdido = 1;
                for (int i = 12; i < 24; i++)
                {
                    xlHoja.Cells[i, "L"] = new AccidenteBL().SeleccionaDiasPerdidosMensual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIAccidente, Convert.ToInt32(txtPeriodo.EditValue), intMesDiaPerdido);
                    intMesDiaPerdido++;
                }

                //SEGUNDA HOJA
                xlSegundaHoja = (Excel._Worksheet)xlHojas[2];

                xlSegundaHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 60, 65, 45, 35);

                int PeriodoActual = 0;
                int PeriodoAnterior = 0;
                int PeriodoTrasAnterior = 0;

                PeriodoActual = Int32.Parse(txtPeriodo.Text);
                PeriodoAnterior = PeriodoActual - 1;
                PeriodoTrasAnterior = PeriodoActual -2;

                xlSegundaHoja.Cells[8, 3] = cboEmpresa.Text;

                xlSegundaHoja.Cells[12, 1] = PeriodoTrasAnterior;
                xlSegundaHoja.Cells[13, 1] = PeriodoAnterior;
                xlSegundaHoja.Cells[14, 1] = txtPeriodo.Text;

                //INCIDENTE ANUAL
                xlSegundaHoja.Cells[12, "B"] = new AccidenteBL().SeleccionaTipoNumeroAnual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIIncidente, PeriodoTrasAnterior);

                //INCIDENTE PELIGROSO ANUAL
                xlSegundaHoja.Cells[12, "C"] = new AccidenteBL().SeleccionaTipoNumeroAnual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIIncidentePeligroso, PeriodoTrasAnterior);

                //ACCIDENTE ANUAL
                xlSegundaHoja.Cells[12, "E"] = new AccidenteBL().SeleccionaTipoNumeroAnual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIAccidente, PeriodoTrasAnterior);

                //ACCIDENTE HORAS TRABAJADAS ANUAL
                xlSegundaHoja.Cells[12, "D"] = new HoraTrabajadaBL().SeleccionaHora(Convert.ToInt32(cboEmpresa.EditValue), PeriodoTrasAnterior, 0);

                //ACCIDENTE DIAS PERDIDOS
                xlSegundaHoja.Cells[12, "F"] = new AccidenteBL().SeleccionaDiasPerdidosAnual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIAccidente, PeriodoTrasAnterior);


                //INCIDENTE ANUAL
                xlSegundaHoja.Cells[13, "B"] = new AccidenteBL().SeleccionaTipoNumeroAnual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIIncidente, PeriodoAnterior);

                //INCIDENTE PELIGROSO ANUAL
                xlSegundaHoja.Cells[13, "C"] = new AccidenteBL().SeleccionaTipoNumeroAnual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIIncidentePeligroso, PeriodoAnterior);

                //ACCIDENTE ANUAL
                xlSegundaHoja.Cells[13, "E"] = new AccidenteBL().SeleccionaTipoNumeroAnual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIAccidente, PeriodoAnterior);

                //ACCIDENTE HORAS TRABAJADAS ANUAL
                xlSegundaHoja.Cells[13, "D"] = new HoraTrabajadaBL().SeleccionaHora(Convert.ToInt32(cboEmpresa.EditValue), PeriodoAnterior, 0);

                //ACCIDENTE DIAS PERDIDOS
                xlSegundaHoja.Cells[13, "F"] = new AccidenteBL().SeleccionaDiasPerdidosAnual(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTIAccidente, PeriodoAnterior);


                string strMensaje = "";
                xlLibro.SaveAs("D:\\Estadistica de Accidentes", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                strMensaje = "El registro de estadisticas de seguridad y salud en el trabajo \n Se generó el archivo D:\\Estadistica de Accidentes";


               
                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;

                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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