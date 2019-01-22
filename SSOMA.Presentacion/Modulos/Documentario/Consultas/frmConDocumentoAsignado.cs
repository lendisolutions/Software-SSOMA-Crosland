using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Funciones;
using Excel = Microsoft.Office.Interop.Excel;

namespace SSOMA.Presentacion.Modulos.Documentario.Consultas
{
    public partial class frmConDocumentoAsignado : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"

        public frmConDocumentoAsignado()
        {
            InitializeComponent();
        }

        private void frmConDocumentoAsignado_Load(object sender, EventArgs e)
        {
            CargaTreeview();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            ExportarPlanillaExcel("");
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        private void CargaTreeview()
        {
            tvwDatos.Nodes.Clear();

            List<DocumentoPersonaBE> lstDocumentoPersonaCarpeta = null;
            lstDocumentoPersonaCarpeta = new DocumentoPersonaBL().ListaCarpeta(0, Parametros.intPersonaId);
            foreach (var item in lstDocumentoPersonaCarpeta)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = item.DescCarpeta;
                nuevoNodo.ImageIndex = 1;
                nuevoNodo.SelectedImageIndex = 1;
                nuevoNodo.Tag = "EMP" + item.IdCarpeta.ToString();
                tvwDatos.Nodes.Add(nuevoNodo);

                List<DocumentoPersonaBE> lstDocumentoPersonaCarpetaArchivo = null;
                lstDocumentoPersonaCarpetaArchivo = new DocumentoPersonaBL().ListaCarpetaArchivo(0, Parametros.intPersonaId,item.IdCarpeta);
                foreach (var itemunidad in lstDocumentoPersonaCarpetaArchivo)
                {
                    TreeNode nuevoNodoChild = new TreeNode();
                    nuevoNodoChild.ImageIndex = 2;
                    nuevoNodoChild.SelectedImageIndex = 2;
                    nuevoNodoChild.Text = itemunidad.NombreArchivo;
                    nuevoNodoChild.Tag = "UMM" + itemunidad.IdDocumento.ToString();
                    nuevoNodo.Nodes.Add(nuevoNodoChild);
                }
            }

            tvwDatos.ExpandAll();
        }

        private void tvwDatos_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int intIdDocumento = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                DocumentoBE objSSOMA = null;
                objSSOMA = new DocumentoBL().Selecciona(intIdDocumento);
                if (objSSOMA != null)
                {
                    string sFilePath = "";
                    byte[] Buffer;

                    Buffer = objSSOMA.Archivo;

                    sFilePath = Path.GetTempFileName();
                    File.Move(sFilePath, Path.ChangeExtension(sFilePath, ".pdf"));
                    sFilePath = Path.ChangeExtension(sFilePath, ".pdf");
                    File.WriteAllBytes(sFilePath, Buffer);

                    ProcessStartInfo start = new ProcessStartInfo();
                    // Enter in the command line arguments, everything you would enter after the executable name itself

                    List<DocumentoPersonaBE> lstDocumentoPersona = null;
                    lstDocumentoPersona = new DocumentoPersonaBL().ListaTodosActivo(0, Parametros.intPersonaId, intIdDocumento);
                    if (lstDocumentoPersona.Count > 0)
                    {
                        if (lstDocumentoPersona[0].FlagImpresion)
                            start.Arguments = sFilePath + " 1";
                        else
                            start.Arguments = sFilePath + " 0";
                    }
                    
                    // Enter the executable to run, including the complete path
                    start.FileName = Path.Combine(Directory.GetCurrentDirectory(), "Pdf\\PdfiumViewer.Demo.exe");
                    // Do you want to show a console window?
                    start.WindowStyle = ProcessWindowStyle.Hidden;
                    start.CreateNoWindow = true;
                    int exitCode;

                    // Run the external process & wait for it to finish
                    using (Process proc = Process.Start(start))
                    {
                        proc.WaitForExit();

                        // Retrieve the app's exit code
                        exitCode = proc.ExitCode;
                    }

                    //ACTUALIZA LA LECTURA DE LOS DOCUMENTOS POR PERSONA
                    DocumentoPersonaBL objBL_DocumentoPersona = new DocumentoPersonaBL();
                    objBL_DocumentoPersona.ActualizaLectura(Parametros.intPersonaId, intIdDocumento);

                }

                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ExportarPlanillaExcel(string filename)
        {
            //if (filename.Trim() == "")
            //    return;

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Listado Maestro Documentos.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int Row = 6;
                int Secuencia = 1;

                List<DocumentoBE> lstDocumento = new List<DocumentoBE>();

                List<DocumentoPersonaBE> lstDocumentoPersona = null;
                lstDocumentoPersona = new DocumentoPersonaBL().ListaTodosActivo(0, Parametros.intPersonaId,0);

                foreach (var item in lstDocumentoPersona)
                {
                    DocumentoBE objE_Documento = new DocumentoBE();
                    objE_Documento = new DocumentoBL().Selecciona(item.IdDocumento);
                    if (objE_Documento != null)
                    {
                        lstDocumento.Add(objE_Documento);
                    }
                }

               

                if (lstDocumento.Count > 0)
                {
                    foreach (var item in lstDocumento)
                    {
                        xlHoja.Cells[Row, 1] = item.DescCarpeta;
                        xlHoja.Cells[Row, 2] = item.Codigo;
                        xlHoja.Cells[Row, 3] = item.NombreArchivo;
                        xlHoja.Cells[Row, 6] = item.Revision;
                        xlHoja.Cells[Row, 7] = item.FechaAprobacion;
                        if (item.FlagContabilidad)
                        {
                            xlHoja.Cells[Row, 8] = "X";
                        }
                        if (item.FlagSistemas)
                        {
                            xlHoja.Cells[Row, 8] = "X";
                        }
                        if (item.FlagLegal)
                        {
                            xlHoja.Cells[Row, 10] = "X";
                        }
                        if (item.FlagTesoreria)
                        {
                            xlHoja.Cells[Row, 11] = "X";
                        }
                        if (item.FlagAtraccion)
                        {
                            xlHoja.Cells[Row, 12] = "X";
                        }
                        if (item.FlagAdministracion)
                        {
                            xlHoja.Cells[Row, 13] = "X";
                        }
                        if (item.FlagComercial)
                        {
                            xlHoja.Cells[Row, 14] = "X";
                        }
                        if (item.FlagDesarrolloNegocio)
                        {
                            xlHoja.Cells[Row, 15] = "X";
                        }
                        if (item.FlagControlGestion)
                        {
                            xlHoja.Cells[Row, 16] = "X";
                        }
                        if (item.FlagAlmacen)
                        {
                            xlHoja.Cells[Row, 17] = "X";
                        }
                        if (item.FlagDespacho)
                        {
                            xlHoja.Cells[Row, 18] = "X";
                        }
                        if (item.FlagGerenciaGeneral)
                        {
                            xlHoja.Cells[Row, 19] = "X";
                        }
                        if (item.FlagMarketing)
                        {
                            xlHoja.Cells[Row, 20] = "X";
                        }
                        if (item.FlagOperacion)
                        {
                            xlHoja.Cells[Row, 21] = "X";
                        }
                        if (item.FlagProyecto)
                        {
                            xlHoja.Cells[Row, 22] = "X";
                        }
                        if (item.FlagServicioGeneral)
                        {
                            xlHoja.Cells[Row, 23] = "X";
                        }
                        if (item.FlagPlaneamiento)
                        {
                            xlHoja.Cells[Row, 24] = "X";
                        }
                        if (item.FlagCompensacion)
                        {
                            xlHoja.Cells[Row, 25] = "X";
                        }
                        if (item.FlagBienestar)
                        {
                            xlHoja.Cells[Row, 26] = "X";
                        }
                        if (item.FlagAlquiler)
                        {
                            xlHoja.Cells[Row, 27] = "X";
                        }


                        Row = Row + 1;
                        Secuencia = Secuencia + 1;


                    }

                }

                xlLibro.SaveAs("D:\\Listado Maestro Documentos.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show("La Lista Maestra de Documentos se exportó correctamente \n Se generó el archivo D:\\Listado Maestro Documentos.xlsx", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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