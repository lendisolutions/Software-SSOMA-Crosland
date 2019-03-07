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
        public List<PreguntaBE> mListaPregunta = new List<PreguntaBE>();

        public int intIdTema { get; set; }
        public string  strDescTema { get; set; }
        public string strParticipante { get; set; }

        int intIdCuestionario = 0;
        int intNotaAprobatoria = 0;
        int intDuracion = 0;

        int h = 0, m = 0, s = 0;

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            s = s + 1;
            if (s == 60)
            {
                s = 0;
                m = m + 1;
                if (m == 60)
                {
                    m = 0;
                    h++;
                    if (h == 24) h = 0;
                }
            }

            ls.Text = Convert.ToString(s);
            lm.Text = Convert.ToString(m);
            lh.Text = Convert.ToString(h);
            if (s < 10) ls.Text = "0" + ls.Text;
            if (m < 10) lm.Text = "0" + lm.Text;
            if (h < 10) lh.Text = "0" + lh.Text;

            if (h == intDuracion)
            {
                timer1.Enabled = false;
                XtraMessageBox.Show("El tiempo de la evaluación a terminado. se procederá a emitir la calificación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGrabar.Enabled = false;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                if (XtraMessageBox.Show("¿Estas de seguro de grabar la evaluación? \n Has verificado las respuestas correctamente.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

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
                if (gvTemaDetallePersona.RowCount > 0)
                {
                    for (int i = 0; i < gvTemaDetallePersona.DataRowCount; i++)
                    {
                        if (gvTemaDetallePersona.GetRowCellValue(i, "DescSituacion").ToString() == "NO VISTO")
                        {
                            XtraMessageBox.Show("Para pasar al examén final es necesario abrir y revisar todos los archivos del contenido del curso.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            xtraTabControl1.SelectedTabPage = xtraTabPage1;
                            return;
                        }
                    }
                }

                //VERIFICAMOS EL CUESTIONARIO
                List<CuestionarioBE> lstCuestionario = null;
                lstCuestionario = new CuestionarioBL().ListaTodosActivo(Parametros.intEmpresaId, intIdTema);
                if (lstCuestionario.Count>0)
                {
                    intIdCuestionario = lstCuestionario[0].IdCuestionario;
                    intNotaAprobatoria = lstCuestionario[0].NotaAprobatoria;
                    intDuracion = lstCuestionario[0].Duracion;

                    if (XtraMessageBox.Show("Dispone de " + intDuracion + " minutos para resolver la evaluación? \n Tenga en cuenta que se activará un cronómetro y no podrá cancelar.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        mListaPregunta = new PreguntaBL().ListaEvaluacion(Parametros.intEmpresaId, intIdTema, intIdCuestionario);
                        bsListadoPregunta.DataSource = mListaPregunta;
                        gcPregunta.DataSource = bsListadoPregunta;
                        gcPregunta.RefreshDataSource();
                        gvPregunta.ExpandAllGroups();

                        h = 0;
                        m = 0;
                        s = 0;

                        lh.Text = "00";
                        lm.Text = "00";
                        ls.Text = "00";

                        timer1.Enabled = true;
                        btnGrabar.Enabled = true;
                    }
                    else
                    {
                        xtraTabControl1.SelectedTabPage = xtraTabPage1;
                    }
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