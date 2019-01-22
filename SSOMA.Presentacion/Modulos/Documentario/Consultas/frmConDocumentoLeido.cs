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
    public partial class frmConDocumentoLeido : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<DocumentoPersonaBE> mLista = new List<DocumentoPersonaBE>();

        int intIdEmpresaResponsable = 0;
        int intIdUnidadMineraResponsable = 0;
        int intIdAreaResponsable = 0;
        int intIdPersonaResponsable = 0;
        int IdDocumentoPersona = 0;

        string strTrabajador = "";

        #endregion

        #region "Eventos"

        public frmConDocumentoLeido()
        {
            InitializeComponent();
        }

        private void frmConDocumentoLeido_Load(object sender, EventArgs e)
        {
            CargaTreeview();
        }

        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "EMP":
                    intIdEmpresaResponsable = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    break;
                case "UMM":
                    intIdUnidadMineraResponsable = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaTreeviewAreas(e.Node);
                    break;
                case "ARE":
                    intIdAreaResponsable = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaTreeviewPersonal(e.Node);
                    break;
                case "PER":
                    intIdPersonaResponsable = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    strTrabajador = e.Node.Text;
                    Cargar();
                    break;

            }
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {

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

            List<EmpresaBE> lstEmpresa = null;
            lstEmpresa = new EmpresaBL().ListaTodosActivo(0, Parametros.intTECorporativo);
            foreach (var item in lstEmpresa)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = item.RazonSocial;
                nuevoNodo.ImageIndex = 0;
                nuevoNodo.SelectedImageIndex = 0;
                nuevoNodo.Tag = "EMP" + item.IdEmpresa.ToString();
                tvwDatos.Nodes.Add(nuevoNodo);

                List<UnidadMineraBE> lstUnidadMinera = null;
                lstUnidadMinera = new UnidadMineraBL().ListaTodosActivo(item.IdEmpresa);
                foreach (var itemunidad in lstUnidadMinera)
                {
                    TreeNode nuevoNodoChild = new TreeNode();
                    nuevoNodoChild.ImageIndex = 1;
                    nuevoNodoChild.SelectedImageIndex = 1;
                    nuevoNodoChild.Text = itemunidad.DescUnidadMinera;
                    nuevoNodoChild.Tag = "UMM" + itemunidad.IdUnidadMinera.ToString();
                    nuevoNodo.Nodes.Add(nuevoNodoChild);
                }
            }

            tvwDatos.ExpandAll();
        }

        void CargaTreeviewAreas(TreeNode nodo)
        {
            nodo.Nodes.Clear();

            List<AreaBE> lstArea = null;
            lstArea = new AreaBL().ListaTodosActivo(intIdEmpresaResponsable, intIdUnidadMineraResponsable);
            foreach (var item in lstArea)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 2;
                nuevoNodoChild.SelectedImageIndex = 2;
                nuevoNodoChild.Text = item.DescArea;
                nuevoNodoChild.Tag = "ARE" + item.IdArea.ToString();
                nodo.Nodes.Add(nuevoNodoChild);
            }
        }

        void CargaTreeviewPersonal(TreeNode nodo)
        {
            nodo.Nodes.Clear();

            List<PersonaBE> lstPersona = null;
            lstPersona = new PersonaBL().ListaTodosActivo(intIdEmpresaResponsable, intIdUnidadMineraResponsable, intIdAreaResponsable);
            foreach (var item in lstPersona)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 4;
                nuevoNodoChild.SelectedImageIndex = 4;
                nuevoNodoChild.Text = item.ApeNom;
                nuevoNodoChild.Tag = "PER" + item.IdPersona.ToString();
                nodo.Nodes.Add(nuevoNodoChild);
            }
        }



        private void Cargar()
        {
            mLista = new DocumentoPersonaBL().ListaTodosActivo(0, intIdPersonaResponsable, 0);
            gcDocumentoPersona.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcDocumentoPersona.DataSource = mLista.Where(obj =>
                                                   obj.NombreArchivo.ToUpper().Contains(txtArchivo.Text.ToUpper())).ToList();
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

                if (mLista.Count == 0) return;
                

                foreach (var item in mLista)
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