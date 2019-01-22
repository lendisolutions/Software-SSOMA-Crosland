using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
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

namespace SSOMA.Presentacion.Modulos.Documentario.Registros
{
    public partial class frmRegAsignacionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CDocumentoPersona> mListaDocumentoPersonaOrigen = new List<CDocumentoPersona>();

        int _IdDocumentoPersona = 0;

        public int IdDocumentoPersona
        {
            get { return _IdDocumentoPersona; }
            set { _IdDocumentoPersona = value; }
        }

        int _IdPersona = 0;

        public int IdPersona
        {
            get { return _IdPersona; }
            set { _IdPersona = value; }
        }

        string _Trabajador = "";

        public string Trabajador
        {
            get { return _Trabajador; }
            set { _Trabajador = value; }
        }

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

        public frmRegAsignacionEdit()
        {
            InitializeComponent();
        }

        private void frmRegAsignacionEdit_Load(object sender, EventArgs e)
        {
            txtDescTrabajador.Text = Trabajador;
            BSUtils.LoaderLook(cboDocumento, new DocumentoBL().ListaCombo(), "NombreArchivo", "IdDocumento", true);
            CargaDocumentoPersona();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                string strCodigo = "";
                string strNombreArchivo = "";
                string strRevision = "";

                var Buscar = mListaDocumentoPersonaOrigen.Where(oB => oB.IdDocumento == Convert.ToInt32(cboDocumento.EditValue)).ToList();
                if (Buscar.Count > 0)
                {
                    XtraMessageBox.Show("No se puede repetir el documento \n Por Favor Verique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    DocumentoBE objE_Documento = null;
                    objE_Documento = new DocumentoBL().Selecciona(Convert.ToInt32(cboDocumento.EditValue));
                    if (objE_Documento != null)
                    {
                        strCodigo = objE_Documento.Codigo;
                        strNombreArchivo = objE_Documento.NombreArchivo;
                        strRevision = objE_Documento.Revision;
                    }
                }

                gvDocumentoPersona.AddNewRow();
                gvDocumentoPersona.SetRowCellValue(gvDocumentoPersona.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                gvDocumentoPersona.SetRowCellValue(gvDocumentoPersona.FocusedRowHandle, "IdDocumentoPersona", 0);
                gvDocumentoPersona.SetRowCellValue(gvDocumentoPersona.FocusedRowHandle, "IdPersona", IdPersona);
                gvDocumentoPersona.SetRowCellValue(gvDocumentoPersona.FocusedRowHandle, "IdDocumento", Convert.ToInt32(cboDocumento.EditValue));
                gvDocumentoPersona.SetRowCellValue(gvDocumentoPersona.FocusedRowHandle, "Codigo", strCodigo);
                gvDocumentoPersona.SetRowCellValue(gvDocumentoPersona.FocusedRowHandle, "NombreArchivo", strNombreArchivo);
                gvDocumentoPersona.SetRowCellValue(gvDocumentoPersona.FocusedRowHandle, "Revision", strRevision);
                gvDocumentoPersona.SetRowCellValue(gvDocumentoPersona.FocusedRowHandle, "FlagImpresion",0);
                gvDocumentoPersona.SetRowCellValue(gvDocumentoPersona.FocusedRowHandle, "Lectura", 0);
                gvDocumentoPersona.SetRowCellValue(gvDocumentoPersona.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                
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
                    DocumentoPersonaBL objBL_DocumentoPersona = new DocumentoPersonaBL();

                    //DOCUMENTO PERSONA
                    List<DocumentoPersonaBE> lstDocumentoPersona = new List<DocumentoPersonaBE>();

                    foreach (var item in mListaDocumentoPersonaOrigen)
                    {
                        DocumentoPersonaBE objE_DocumentoPersona = new DocumentoPersonaBE();
                        objE_DocumentoPersona.IdEmpresa = Parametros.intEmpresaId;
                        objE_DocumentoPersona.IdDocumentoPersona = item.IdDocumentoPersona;
                        objE_DocumentoPersona.IdPersona = item.IdPersona;
                        objE_DocumentoPersona.IdDocumento = item.IdDocumento;
                        objE_DocumentoPersona.FlagImpresion = item.FlagImpresion;
                        objE_DocumentoPersona.Lectura = item.Lectura;
                        objE_DocumentoPersona.FlagEstado = true;
                        objE_DocumentoPersona.Usuario = Parametros.strUsuarioLogin;
                        objE_DocumentoPersona.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_DocumentoPersona.TipoOper = item.TipoOper;
                        lstDocumentoPersona.Add(objE_DocumentoPersona);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {

                        objBL_DocumentoPersona.Inserta(lstDocumentoPersona);
                        XtraMessageBox.Show("La asignación de documento se actualizó correctamente. ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        //objBL_DocumentoPersona.Actualiza(lstDocumentoPersona);
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

            if (IdPersona == 0)
            {
                strMensaje = strMensaje + "- Debe Seleccionar un trabajador.\n";
                flag = true;
            }

            

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }
        private void CargaDocumentoPersona()
        {
            mListaDocumentoPersonaOrigen = new List<CDocumentoPersona>();
            List<DocumentoPersonaBE> lstTmpDocumentoPersona = null;
            lstTmpDocumentoPersona = new DocumentoPersonaBL().ListaTodosActivo(0,IdPersona,0);

            foreach (DocumentoPersonaBE item in lstTmpDocumentoPersona)
            {
                CDocumentoPersona objE_DocumentoPersona = new CDocumentoPersona();
                objE_DocumentoPersona.IdDocumentoPersona = item.IdDocumentoPersona;
                objE_DocumentoPersona.IdEmpresa = item.IdEmpresa;
                objE_DocumentoPersona.IdPersona = item.IdPersona;
                objE_DocumentoPersona.IdDocumento = item.IdDocumento;
                objE_DocumentoPersona.Codigo = item.Codigo;
                objE_DocumentoPersona.NombreArchivo = item.NombreArchivo;
                objE_DocumentoPersona.Revision = item.Revision;
                objE_DocumentoPersona.FlagImpresion = item.FlagImpresion;
                objE_DocumentoPersona.Lectura = item.Lectura;
                objE_DocumentoPersona.TipoOper = item.TipoOper;
                mListaDocumentoPersonaOrigen.Add(objE_DocumentoPersona);
            }

            bsListado.DataSource = mListaDocumentoPersonaOrigen;
            gcDocumentoPersona.DataSource = bsListado;
            gcDocumentoPersona.RefreshDataSource();


        }

        #endregion

        public class CDocumentoPersona
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdDocumentoPersona { get; set; }
            public Int32 IdPersona { get; set; }
            public Int32 IdDocumento { get; set; }
            public String Codigo { get; set; }
            public String NombreArchivo { get; set; }
            public String Revision { get; set; }
            public Boolean FlagImpresion { get; set; }
            public Int32 Lectura { get; set; }
            public Int32 TipoOper { get; set; }

            public CDocumentoPersona()
            {

            }

        }

        
    }
}