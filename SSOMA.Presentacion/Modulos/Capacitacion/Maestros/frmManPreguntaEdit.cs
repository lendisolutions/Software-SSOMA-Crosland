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
using System.Diagnostics;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Modulos.Otros;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Capacitacion.Maestros
{
    public partial class frmManPreguntaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PreguntaBE> lstPregunta;
        public List<CRespuesta> mListaRespuestaOrigen = new List<CRespuesta>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public PreguntaBE pPreguntaBE { get; set; }

        

        int _IdTema = 0;

        public int IdTema
        {
            get { return _IdTema; }
            set { _IdTema = value; }
        }

        int _IdCuestionario = 0;

        public int IdCuestionario
        {
            get { return _IdCuestionario; }
            set { _IdCuestionario = value; }
        }

        int _IdPregunta = 0;

        public int IdPregunta
        {
            get { return _IdPregunta; }
            set { _IdPregunta = value; }
        }

        #endregion

        #region "Eventos"

        public frmManPreguntaEdit()
        {
            InitializeComponent();
        }

        private void frmManPreguntaEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Pregunta del Cuestionario - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Pregunta del cuestionario - Modificar";
                PreguntaBE objE_Pregunta = null;
                objE_Pregunta = new PreguntaBL().Selecciona(0,IdPregunta);
                if (objE_Pregunta != null)
                {
                    txtDescPregunta.Text = objE_Pregunta.DescPregunta;
                    txtPuntaje.EditValue = objE_Pregunta.Puntaje;
                }

            }

            txtDescPregunta.Select();
            CargaRespuesta();
        }

        private void nuevoRespuestaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvRespuesta.AddNewRow();
                gvRespuesta.SetRowCellValue(gvRespuesta.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                gvRespuesta.SetRowCellValue(gvRespuesta.FocusedRowHandle, "IdRespuesta", 0);
                gvRespuesta.SetRowCellValue(gvRespuesta.FocusedRowHandle, "IdTema", IdTema);
                gvRespuesta.SetRowCellValue(gvRespuesta.FocusedRowHandle, "IdCuestionario", IdCuestionario);
                gvRespuesta.SetRowCellValue(gvRespuesta.FocusedRowHandle, "IdPregunta", IdPregunta);
                gvRespuesta.SetRowCellValue(gvRespuesta.FocusedRowHandle, "DescRespuesta", "");
                gvRespuesta.SetRowCellValue(gvRespuesta.FocusedRowHandle, "FlagCorrecto", false);
                gvRespuesta.SetRowCellValue(gvRespuesta.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvRespuesta.FocusedColumn = gvRespuesta.Columns["DescRespuesta"];
                gvRespuesta.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarRespuestaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdRespuesta = 0;
                if (gvRespuesta.GetFocusedRowCellValue("IdRespuesta") != null)
                    IdRespuesta = int.Parse(gvRespuesta.GetFocusedRowCellValue("IdRespuesta").ToString());
                RespuestaBE objBE_Respuesta = new RespuestaBE();
                objBE_Respuesta.IdRespuesta = IdRespuesta;
                objBE_Respuesta.IdEmpresa = Parametros.intEmpresaId;
                objBE_Respuesta.Usuario = Parametros.strUsuarioLogin;
                objBE_Respuesta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                RespuestaBL objBL_Respuesta = new RespuestaBL();
                objBL_Respuesta.Elimina(objBE_Respuesta);
                gvRespuesta.DeleteRow(gvRespuesta.FocusedRowHandle);
                gvRespuesta.RefreshData();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        private void CargaRespuesta()
        {
            List<RespuestaBE> lstTmpRespuesta = null;
            lstTmpRespuesta = new RespuestaBL().ListaTodosActivo(IdPregunta);

            foreach (RespuestaBE item in lstTmpRespuesta)
            {
                CRespuesta objE_Respuesta = new CRespuesta();
                objE_Respuesta.IdEmpresa = item.IdEmpresa;
                objE_Respuesta.IdTema = item.IdTema;
                objE_Respuesta.IdCuestionario = item.IdCuestionario;
                objE_Respuesta.IdPregunta = item.IdPregunta;
                objE_Respuesta.IdRespuesta = item.IdRespuesta;
                objE_Respuesta.DescRespuesta = item.DescRespuesta;
                objE_Respuesta.FlagCorrecto = item.FlagCorrecto;
                objE_Respuesta.TipoOper = item.TipoOper;
                mListaRespuestaOrigen.Add(objE_Respuesta);
            }

            bsListadoRespuesta.DataSource = mListaRespuestaOrigen;
            gcRespuesta.DataSource = bsListadoRespuesta;
            gcRespuesta.RefreshDataSource();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";
            if (txtDescPregunta.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstPregunta.Where(oB => oB.DescPregunta.ToUpper() == txtDescPregunta.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La descripción ya existe.\n";
                    flag = true;
                }
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PreguntaBL objBL_Pregunta = new PreguntaBL();
                    PreguntaBE objPregunta = new PreguntaBE();

                    objPregunta.IdEmpresa = Parametros.intEmpresaId;
                    objPregunta.IdTema = IdTema;
                    objPregunta.IdCuestionario = IdCuestionario;
                    objPregunta.IdPregunta = IdPregunta;
                    objPregunta.DescPregunta = txtDescPregunta.Text;
                    objPregunta.Puntaje = Convert.ToInt32(txtPuntaje.EditValue);
                    objPregunta.FlagEstado = true;
                    objPregunta.Usuario = Parametros.strUsuarioLogin;
                    objPregunta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();


                    List<RespuestaBE> lstRespuesta = new List<RespuestaBE>();

                    foreach (var item in mListaRespuestaOrigen)
                    {
                        RespuestaBE objE_Respuesta = new RespuestaBE();
                        objE_Respuesta.IdEmpresa = item.IdEmpresa;
                        objE_Respuesta.IdRespuesta = item.IdRespuesta;
                        objE_Respuesta.IdTema = item.IdTema;
                        objE_Respuesta.IdCuestionario = item.IdCuestionario;
                        objE_Respuesta.IdPregunta = item.IdPregunta;
                        objE_Respuesta.DescRespuesta = item.DescRespuesta;
                        objE_Respuesta.FlagCorrecto = item.FlagCorrecto;
                        objE_Respuesta.TipoOper = item.TipoOper;
                        objE_Respuesta.FlagEstado = true;
                        objE_Respuesta.Usuario = Parametros.strUsuarioLogin;
                        objE_Respuesta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Respuesta.TipoOper = item.TipoOper;
                        lstRespuesta.Add(objE_Respuesta);
                    }

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Pregunta.Inserta(objPregunta, lstRespuesta);
                    else
                        objBL_Pregunta.Actualiza(objPregunta, lstRespuesta);

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

        public class CRespuesta
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdTema { get; set; }
            public Int32 IdCuestionario { get; set; }
            public Int32 IdPregunta { get; set; }
            public Int32 IdRespuesta { get; set; }
            public string DescRespuesta { get; set; }
            public Boolean FlagCorrecto { get; set; }
            public Int32 TipoOper { get; set; }

            public CRespuesta()
            {

            }
        }

        
    }
}