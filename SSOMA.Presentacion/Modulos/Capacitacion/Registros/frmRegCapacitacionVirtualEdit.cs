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

        public List<CTemaDetalle> mListaTemaDetalleOrigen = new List<CTemaDetalle>();

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

            CargaTemaDetalle();
        }

        private void gvTemaDetalle_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gvTemaDetalle.RowCount > 0)
                {
                    string strNombreArchivo = (string)gvTemaDetalle.GetFocusedRowCellValue("NombreArchivo");
                    byte[] Buffer = (byte[])gvTemaDetalle.GetFocusedRowCellValue("Archivo");

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
                CTemaDetalle objE_TemaDetalle = new CTemaDetalle();
                objE_TemaDetalle.IdEmpresa = item.IdEmpresa;
                objE_TemaDetalle.IdTemaDetalle = item.IdTemaDetalle;
                objE_TemaDetalle.IdTema = item.IdTema;
                if (item.Extension == ".xlsx")
                    objE_TemaDetalle.Image = new FuncionBase().Image2Bytes(SSOMA.Presentacion.Properties.Resources.MSExcel_48x48);
                if (item.Extension == ".pptx")
                    objE_TemaDetalle.Image = new FuncionBase().Image2Bytes(SSOMA.Presentacion.Properties.Resources.MSPowerPoint_48x48);
                if (item.Extension == ".docx")
                    objE_TemaDetalle.Image = new FuncionBase().Image2Bytes(SSOMA.Presentacion.Properties.Resources.MSWord_48x48);
                if (item.Extension == ".pdf")
                    objE_TemaDetalle.Image = new FuncionBase().Image2Bytes(SSOMA.Presentacion.Properties.Resources.Pdf_48x48);
                if (item.Extension == ".mp4")
                    objE_TemaDetalle.Image = new FuncionBase().Image2Bytes(SSOMA.Presentacion.Properties.Resources.Video_48x48);
                objE_TemaDetalle.Archivo = item.Archivo;
                objE_TemaDetalle.NombreArchivo = item.NombreArchivo;
                objE_TemaDetalle.Extension = item.Extension;
                objE_TemaDetalle.Descripcion = item.Descripcion;
                mListaTemaDetalleOrigen.Add(objE_TemaDetalle);
            }

            bsListadoTemaDetalle.DataSource = mListaTemaDetalleOrigen;
            gcTemaDetalle.DataSource = bsListadoTemaDetalle;
            gcTemaDetalle.RefreshDataSource();
        }


        #endregion

        public class CTemaDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdTema { get; set; }
            public Int32 IdTemaDetalle { get; set; }
            public byte[] Image { get; set; }
            public byte[] Archivo { get; set; }
            public string NombreArchivo { get; set; }
            public string Extension { get; set; }
            public string Descripcion { get; set; }

            public CTemaDetalle()
            {

            }
        }

        
    }
}