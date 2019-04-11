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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using SSOMA.Presentacion.Modulos.Capacitacion.Rpt;
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
                btnGrabar_Click(sender, e);
                
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                string strSituacion = "";

                timer1.Enabled = false;
                if (XtraMessageBox.Show("¿Estas de seguro de grabar la evaluación? \n Ha verificado las respuestas correctamente.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;

                    int NotaFinal = 0;

                    List<RespuestaBE> lstRespuestaCorrecta = null;
                    lstRespuestaCorrecta = new RespuestaBL().ListaCuestionario(intIdCuestionario);

                    List<RespuestaPersonaBE> lstRespuestaPersona = new List<RespuestaPersonaBE>();

                    //VALIDACION

                    var lstPreguntas = from p in mListaPregunta
                                     group p by p.IdPregunta into grupo
                                     select grupo;

                    foreach (var itempregunta in lstPreguntas)
                    {
                        int contador = 0;
                        foreach (var itempreguntatemporal in mListaPregunta)
                        {
                            if (itempregunta.Key == itempreguntatemporal.IdPregunta && itempreguntatemporal.FlagCorrecto)
                            {
                                contador++;
                            }
                        }

                        if (contador == 2)
                        {
                            XtraMessageBox.Show("No puede haber mas de una respuesta por pregunta.\nPor favor vuelva a verificar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cursor = Cursors.Default;
                            return;

                        }

                    }

                    //RESPUESTAS CORRECTAS
                    foreach (var item in mListaPregunta)
                    {
                        if (item.FlagCorrecto == true)
                        {
                            foreach (var itemrespuesta in lstRespuestaCorrecta)
                            {
                                if (item.IdTema == itemrespuesta.IdTema && item.IdCuestionario == itemrespuesta.IdCuestionario && item.IdPregunta == itemrespuesta.IdPregunta && item.IdRespuesta == itemrespuesta.IdRespuesta && item.FlagCorrecto == itemrespuesta.FlagCorrecto)
                                {
                                    NotaFinal = NotaFinal + itemrespuesta.Puntaje;

                                    RespuestaPersonaBE objE_RespuestaPersona = new RespuestaPersonaBE();
                                    objE_RespuestaPersona.IdRespuestaPersona = 0;
                                    objE_RespuestaPersona.IdTema = item.IdTema;
                                    objE_RespuestaPersona.IdCuestionario = item.IdCuestionario;
                                    objE_RespuestaPersona.IdPregunta = item.IdPregunta;
                                    objE_RespuestaPersona.IdRespuesta = item.IdRespuesta;
                                    objE_RespuestaPersona.IdPersona = Parametros.intPersonaId;
                                    objE_RespuestaPersona.FlagRespuesta = item.FlagCorrecto;
                                    objE_RespuestaPersona.DescSituacion = "RESPUESTA CORRECTA";
                                    objE_RespuestaPersona.Puntaje = itemrespuesta.Puntaje;
                                    objE_RespuestaPersona.FlagEstado = true;
                                    objE_RespuestaPersona.Usuario = Parametros.strUsuarioLogin;
                                    objE_RespuestaPersona.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    objE_RespuestaPersona.IdEmpresa = Parametros.intEmpresaId;
                                    lstRespuestaPersona.Add(objE_RespuestaPersona);
                                    
                                }
                                
                            }
                        }
                    }

                    //RESPUESTAS INCORRECTAS
                    foreach (var item in mListaPregunta)
                    {
                        if (item.FlagCorrecto == true)
                        {
                            foreach (var itemrespuesta in lstRespuestaCorrecta)
                            {
                                if (item.IdTema == itemrespuesta.IdTema && item.IdCuestionario == itemrespuesta.IdCuestionario && item.IdPregunta == itemrespuesta.IdPregunta && item.IdRespuesta == itemrespuesta.IdRespuesta && item.FlagCorrecto != itemrespuesta.FlagCorrecto)
                                {
                                    RespuestaPersonaBE objE_RespuestaPersona = new RespuestaPersonaBE();
                                    objE_RespuestaPersona.IdRespuestaPersona = 0;
                                    objE_RespuestaPersona.IdTema = item.IdTema;
                                    objE_RespuestaPersona.IdCuestionario = item.IdCuestionario;
                                    objE_RespuestaPersona.IdPregunta = item.IdPregunta;
                                    objE_RespuestaPersona.IdRespuesta = item.IdRespuesta;
                                    objE_RespuestaPersona.IdPersona = Parametros.intPersonaId;
                                    objE_RespuestaPersona.FlagRespuesta = item.FlagCorrecto;
                                    objE_RespuestaPersona.DescSituacion = "RESPUESTA INCORRECTA";
                                    objE_RespuestaPersona.Puntaje =0;
                                    objE_RespuestaPersona.FlagEstado = true;
                                    objE_RespuestaPersona.Usuario = Parametros.strUsuarioLogin;
                                    objE_RespuestaPersona.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    objE_RespuestaPersona.IdEmpresa = Parametros.intEmpresaId;
                                    lstRespuestaPersona.Add(objE_RespuestaPersona);
                                    break;
                                }

                            }
                        }
                    }


                    if (NotaFinal >= intNotaAprobatoria)
                    {
                        StringBuilder strMensajeAprobatorio = new StringBuilder();
                        strMensajeAprobatorio.Append("*****************************************************************************\n\n");
                        strMensajeAprobatorio.Append("Felicitaciones ha Aprobado la evaluación.\n\n");
                        strMensajeAprobatorio.Append("Nota Aprobatoria : " + NotaFinal + "\n\n");
                        strMensajeAprobatorio.Append("Condición: Aprobado" + "\n\n");
                        strMensajeAprobatorio.Append("*****************************************************************************\n\n");
                        strSituacion = "APROBADO";
                        XtraMessageBox.Show(strMensajeAprobatorio.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int intCuentaDesaprobado = 0;
                        intCuentaDesaprobado = new ResumenPersonaBL().CuentaDesaprobado(0, Parametros.intPersonaId, intIdTema);
                        if (intCuentaDesaprobado == 0)
                        {
                            StringBuilder strMensajeDesaprobatorio = new StringBuilder();
                            strMensajeDesaprobatorio.Append("*****************************************************************************\n\n");
                            strMensajeDesaprobatorio.Append("Lo Sentimos ha desaprobado la evaluación.\n\n");
                            strMensajeDesaprobatorio.Append("Nota Desaprobatoria : " + NotaFinal + "\n\n");
                            strMensajeDesaprobatorio.Append("Condición: Desaprobado" + "\n\n");
                            strMensajeDesaprobatorio.Append("UD. TIENE UN INTENTO MAS PARA VOLVER A REALIZAR EL EXAMEN" + "\n\n");
                            strMensajeDesaprobatorio.Append("Comunicarse con el responsable del area." + "\n\n");
                            strMensajeDesaprobatorio.Append("*****************************************************************************\n\n");
                            strSituacion = "DESAPROBADO";
                            XtraMessageBox.Show(strMensajeDesaprobatorio.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        if (intCuentaDesaprobado == 1)
                        {
                            strSituacion = "DESAPROBADO";
                            XtraMessageBox.Show("Ud. Tiene dos intentos desaprobados del curso virtual\n Comuníquese con el correo: jvillanueva@crosland.com.pe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                        
                    }

                    Cursor = Cursors.Default;

                    ResumenPersonaBE objResumenPersona = new ResumenPersonaBE();
                    ResumenPersonaBL objBL_ResumenPersona = new ResumenPersonaBL();

                    objResumenPersona.IdResumenPersona = 0;
                    objResumenPersona.IdEmpresa = Parametros.intEmpresaId;
                    objResumenPersona.IdTema = intIdTema;
                    objResumenPersona.IdPersona = Parametros.intPersonaId;
                    objResumenPersona.NotaFinal = NotaFinal;
                    objResumenPersona.Situacion = strSituacion;
                    objResumenPersona.FlagEstado = true;
                    objResumenPersona.Usuario = Parametros.strUsuarioLogin;
                    objResumenPersona.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    objBL_ResumenPersona.Inserta(objResumenPersona, lstRespuestaPersona);

                    if (strSituacion == "APROBADO")
                    {
                        StringBuilder strMensaje = new StringBuilder();
                        strMensaje.Append("*****************************************************************************\n\n");
                        strMensaje.Append("Razón Social : " + Parametros.strEmpresaNombre + "\n\n");
                        strMensaje.Append("Area         : " + Parametros.strAreaNombre + "\n\n");
                        strMensaje.Append("Tema         : " + strDescTema + "\n\n");
                        strMensaje.Append("Participante : " + Parametros.strUsuarioNombres + "\n\n");
                        strMensaje.Append("Cargo        : " + Parametros.strCargoNombre + "\n\n");
                        strMensaje.Append("Fecha y Hora : " + DateTime.Now.ToString() + "\n\n");
                        strMensaje.Append("Nota Final   : " + NotaFinal.ToString() + "\n\n");
                        strMensaje.Append("Situación    : " + strSituacion + "\n\n");
                        strMensaje.Append("Emitido Por el Area de Seguridad y Salud en el Trabajo" + "\n\n");
                        strMensaje.Append("*****************************************************************************\n\n");

                        BSUtils.EmailSend("ssoma@crosland.com.pe", "Registro de Evaluación de Capacitaciones Virtuales", strMensaje.ToString(), "", "", "", "");

                        Application.DoEvents();

                        XtraMessageBox.Show("La evaluación se registró correctamente. \n Puede ir a la opción del certificado para la emisión del documento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnGrabar.Enabled = false;
                    }
                    else
                    {
                        btnGrabar.Enabled = false;
                        this.Close();
                    }

                    
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
                lstCuestionario = new CuestionarioBL().ListaTodosActivo(0, intIdTema);
                if (lstCuestionario.Count > 0)
                {
                    intIdCuestionario = lstCuestionario[0].IdCuestionario;
                    intNotaAprobatoria = lstCuestionario[0].NotaAprobatoria;
                    intDuracion = lstCuestionario[0].Duracion;

                    if (XtraMessageBox.Show("Dispone de " + intDuracion + " minutos para resolver la evaluación? \n Tenga en cuenta que se activará un cronómetro y no podrá cancelar.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        mListaPregunta = new PreguntaBL().ListaEvaluacion(0, intIdTema, intIdCuestionario);
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

            if (e.Page.Name.ToString() == "xtraTabPage3")
            {
                List<ResumenPersonaBE> lstResumenPersona = null;
                lstResumenPersona = new ResumenPersonaBL().ListaTodosActivo(0, intIdTema, Parametros.intPersonaId);
                if (lstResumenPersona.Count == 0)
                {
                    XtraMessageBox.Show("No tiene ningún resutado de evaluación. \n Realice su evaluación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    xtraTabControl1.SelectedTabPage = xtraTabPage2;
                    return;
                }

                if (lstResumenPersona.Count > 0)
                {
                    if (lstResumenPersona[0].Situacion == "DESAPROBADO")
                    {
                        XtraMessageBox.Show("Ud. se encuentra desaprobado en la evaluación no se emitirá ningún certificado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        xtraTabControl1.SelectedTabPage = xtraTabPage1;
                        return;
                    }
                    else
                    {
                        List<ReporteResumenPersonaBE> lstReporte = null;
                        lstReporte = new ReporteResumenPersonaBL().Listado(0, intIdTema, Parametros.intPersonaId);
                        if (lstReporte.Count > 0)
                        {
                            rptCertificado1 objReporte = new rptCertificado1();
                            objReporte.SetDataSource(lstReporte);
                            this.crystalReportViewer1.ReportSource = objReporte;
                            this.crystalReportViewer1.Zoom(75);
                        }

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
                if (item.Extension == ".pptx" || item.Extension == ".ppsx")
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