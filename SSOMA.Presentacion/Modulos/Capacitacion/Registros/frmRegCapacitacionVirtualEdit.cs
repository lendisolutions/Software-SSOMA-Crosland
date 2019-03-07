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
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Modulos.Otros;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;


namespace SSOMA.Presentacion.Modulos.Capacitacion.Registros
{
    public partial class frmRegCapacitacionVirtualEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TemaDetallePersonaBE> mListaTemaDetallePersona = new List<TemaDetallePersonaBE>();

        public int intIdTema { get; set; }
        public string  strDescTema { get; set; }
        public string strParticipante { get; set; }

        #endregion

        #region "Eventos"

        public frmRegCapacitacionVirtualEdit()
        {
            InitializeComponent();
        }

        private void frmRegCapacitacionVirtualEdit_Load(object sender, EventArgs e)
        {
            txtDescripcion.Text = strDescTema;
            txtParticipante.Text = strParticipante;

            mListaTemaDetallePersona = new TemaDetallePersonaBL().ListaTodosActivo(intIdTema, Parametros.intPersonaId);

            if (mListaTemaDetallePersona.Count > 0)
            {
                bsListadoTemaDetalle.DataSource = mListaTemaDetallePersona;
                gcTemaDetallePersona.DataSource = bsListadoTemaDetalle;
                gcTemaDetallePersona.RefreshDataSource();
            }
            else
            {
                CargaTemaDetalle();
            }
            
        }

        private void gvTemaDetalle_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gvTemaDetallePersona.RowCount > 0)
                {
                    int intIdTemaDetallePersona = (int)gvTemaDetallePersona.GetFocusedRowCellValue("IdTemaDetallePersona");
                    string strNombreArchivo = (string)gvTemaDetallePersona.GetFocusedRowCellValue("NombreArchivo");
                    byte[] Buffer = (byte[])gvTemaDetallePersona.GetFocusedRowCellValue("Archivo");

                    TemaDetallePersonaBE objE_TemaDetallePersona = new TemaDetallePersonaBE();
                    TemaDetallePersonaBL objBL_TemaDetallePersona = new TemaDetallePersonaBL();

                    objE_TemaDetallePersona.IdTemaDetallePersona = intIdTemaDetallePersona;
                    objE_TemaDetallePersona.DescSituacion = "VISTO";
                    objE_TemaDetallePersona.ImageSituacion = new FuncionBase().Image2Bytes(SSOMA.Presentacion.Properties.Resources.Visto);

                    objBL_TemaDetallePersona.ActualizaSituacion(objE_TemaDetallePersona);

                    string strPath = AppDomain.CurrentDomain.BaseDirectory;
                    string strFolder = strPath + "temp\\";
                    string strFullFilePath = strFolder + strNombreArchivo;

                    if (!Directory.Exists(strFolder))
                        Directory.CreateDirectory(strFolder);

                    //ELIMINAMOS LOR ARCHIVOS CREADOS
                    foreach (var item in Directory.GetFiles(strFolder, "*.*"))
                    {
                        File.SetAttributes(item, FileAttributes.Normal);
                        File.Delete(item);
                    }

                    File.WriteAllBytes(strFullFilePath, Buffer);

                    Process.Start(strFullFilePath);

                    mListaTemaDetallePersona = new TemaDetallePersonaBL().ListaTodosActivo(intIdTema, Parametros.intPersonaId);
                    bsListadoTemaDetalle.DataSource = mListaTemaDetallePersona;
                    gcTemaDetallePersona.DataSource = bsListadoTemaDetalle;
                    gcTemaDetallePersona.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Name.ToString() == "xtraTabPage2")
            {
                if (XtraMessageBox.Show("Esta seguro de desarrollar el Examén Final \n Para esto ha tenido que leer el contenido del cursso.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                }
                else
                {
                    xtraTabControl1.SelectedTabPage = xtraTabPage1;
                }
            }
        }

        #endregion

        #region "Metodos"

        private void CargaTemaDetalle()
        {
            List<TemaDetalleBE> lstTmpTemaDetalle = null;
            lstTmpTemaDetalle = new TemaDetalleBL().ListaTodosActivo(intIdTema);

            foreach (TemaDetalleBE item in lstTmpTemaDetalle)
            {
                TemaDetallePersonaBE objE_TemaDetallePersona = new TemaDetallePersonaBE();
                TemaDetallePersonaBL objBL_TemaDetallePersona = new TemaDetallePersonaBL();

                objE_TemaDetallePersona.IdEmpresa = item.IdEmpresa;
                objE_TemaDetallePersona.IdTemaDetallePersona = 0;
                objE_TemaDetallePersona.IdTema = item.IdTema;
                objE_TemaDetallePersona.IdPersona = Parametros.intPersonaId;
                if (item.Extension == ".xlsx")
                    objE_TemaDetallePersona.Image = new FuncionBase().Image2Bytes(SSOMA.Presentacion.Properties.Resources.MSExcel_48x48);
                if (item.Extension == ".pptx")
                    objE_TemaDetallePersona.Image = new FuncionBase().Image2Bytes(SSOMA.Presentacion.Properties.Resources.MSPowerPoint_48x48);
                if (item.Extension == ".docx")
                    objE_TemaDetallePersona.Image = new FuncionBase().Image2Bytes(SSOMA.Presentacion.Properties.Resources.MSWord_48x48);
                if (item.Extension == ".pdf")
                    objE_TemaDetallePersona.Image = new FuncionBase().Image2Bytes(SSOMA.Presentacion.Properties.Resources.Pdf_48x48);
                if (item.Extension == ".mp4")
                    objE_TemaDetallePersona.Image = new FuncionBase().Image2Bytes(SSOMA.Presentacion.Properties.Resources.Video_48x48);
                objE_TemaDetallePersona.Archivo = item.Archivo;
                objE_TemaDetallePersona.NombreArchivo = item.NombreArchivo;
                objE_TemaDetallePersona.Extension = item.Extension;
                objE_TemaDetallePersona.Descripcion = item.Descripcion;
                objE_TemaDetallePersona.DescSituacion = "NO VISTO";
                objE_TemaDetallePersona.ImageSituacion = new FuncionBase().Image2Bytes(SSOMA.Presentacion.Properties.Resources.NoVisto);
                objE_TemaDetallePersona.FlagEstado = true;

                objBL_TemaDetallePersona.Inserta(objE_TemaDetallePersona);
            }

            mListaTemaDetallePersona = new TemaDetallePersonaBL().ListaTodosActivo(intIdTema, Parametros.intPersonaId);

            bsListadoTemaDetalle.DataSource = mListaTemaDetallePersona;
            gcTemaDetallePersona.DataSource = bsListadoTemaDetalle;
            gcTemaDetallePersona.RefreshDataSource();
        }


        #endregion

        

        
    }
}