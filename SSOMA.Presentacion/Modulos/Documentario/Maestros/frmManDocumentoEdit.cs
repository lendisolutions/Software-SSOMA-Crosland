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
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Modulos.Otros;

namespace SSOMA.Presentacion.Modulos.Documentario.Maestros
{
    public partial class frmManDocumentoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<DocumentoBE> lstDocumento;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public DocumentoBE pDocumentoBE { get; set; }

        byte[] byteArchivo;

        int _IdCarpeta = 0;

        public int IdCarpeta
        {
            get { return _IdCarpeta; }
            set { _IdCarpeta = value; }
        }

        int _IdDocumento = 0;

        public int IdDocumento
        {
            get { return _IdDocumento; }
            set { _IdDocumento = value; }
        }

        string strRuta;

        #endregion

        #region "Eventos"

        public frmManDocumentoEdit()
        {
            InitializeComponent();
        }

        private void frmManDocumentoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboCarpeta, new CarpetaBL().ListaTodosActivo(0), "DescCarpeta", "IdCarpeta", true);
            cboCarpeta.EditValue = IdCarpeta;
            deFechaAprobacion.DateTime = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Documento - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Documento - Modificar";
                DocumentoBE objE_Documento = null;
                objE_Documento = new DocumentoBL().Selecciona(IdDocumento);
                if (objE_Documento != null)
                {
                    IdDocumento = objE_Documento.IdDocumento;
                    cboCarpeta.EditValue = objE_Documento.IdCarpeta;

                    strRuta = objE_Documento.Ruta;
                    txtCodigo.Text = objE_Documento.Codigo;
                    byteArchivo = objE_Documento.Archivo;
                    txtNombreArchivo.Text = objE_Documento.NombreArchivo;
                    txtRevision.Text = objE_Documento.Revision;
                    deFechaAprobacion.EditValue = objE_Documento.FechaAprobacion;
                    chkFlagContabilidad.Checked = objE_Documento.FlagContabilidad;
                    chkFlagSistemas.Checked = objE_Documento.FlagSistemas;
                    chkFlagLegal.Checked = objE_Documento.FlagContabilidad;
                    chkFlagTesoreria.Checked = objE_Documento.FlagTesoreria;
                    chkFlagAtraccion.Checked = objE_Documento.FlagAtraccion;
                    chkFlagAdministracion.Checked = objE_Documento.FlagAdministracion;
                    chkFlagComercial.Checked = objE_Documento.FlagComercial;
                    chkFlagDesarrolloNegocio.Checked = objE_Documento.FlagDesarrolloNegocio;
                    chkFlagControlGestion.Checked = objE_Documento.FlagControlGestion;
                    chkFlagAlmacen.Checked = objE_Documento.FlagAlmacen;
                    chkFlagDespacho.Checked = objE_Documento.FlagDespacho;
                    chkFlagGerenciaGeneral.Checked = objE_Documento.FlagGerenciaGeneral;
                    chkFlagMarketing.Checked = objE_Documento.FlagMarketing;
                    chkFlagOperacion.Checked = objE_Documento.FlagOperacion;
                    chkFlagProyecto.Checked = objE_Documento.FlagProyecto;
                    chkFlagServicioGeneral.Checked = objE_Documento.FlagServicioGeneral;
                    chkFlagPlaneamiento.Checked = objE_Documento.FlagPlaneamiento;
                    chkFlagCompensacion.Checked = objE_Documento.FlagCompensacion;
                    chkFlagBienestar.Checked = objE_Documento.FlagBienestar;
                    chkFlagAlquileres.Checked = objE_Documento.FlagAlquiler;
                    
                }

            }

            btnBucarPdf.Select();
        }

        private void btnBucarPdf_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".pdf"; // Default file extension
            dlg.Filter = "Text documents (.pdf)|*.pdf"; // Filter files by extension 

            // Show open file dialog box
            if (dlg.ShowDialog() == DialogResult.OK )
            {
                strRuta = dlg.FileName;
                txtNombreArchivo.Text = Path.GetFileName(dlg.FileName);

                txtRevision.Select();
            }

           
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    DocumentoBL objBL_Documento = new DocumentoBL();
                    DocumentoBE objDocumento = new DocumentoBE();

                    objDocumento.IdDocumento = IdDocumento;
                    objDocumento.IdCarpeta = Convert.ToInt32(cboCarpeta.EditValue);
                   
                    objDocumento.Ruta = strRuta;
                    objDocumento.Codigo = txtCodigo.Text;
                    objDocumento.NombreArchivo = txtNombreArchivo.Text;
                    objDocumento.Revision = txtRevision.Text;
                    objDocumento.FechaAprobacion = Convert.ToDateTime(deFechaAprobacion.DateTime.ToShortDateString());
                    objDocumento.FlagContabilidad = (chkFlagContabilidad.Checked) ? true : false;
                    objDocumento.FlagSistemas = (chkFlagSistemas.Checked) ? true : false;
                    objDocumento.FlagLegal = (chkFlagLegal.Checked) ? true : false;
                    objDocumento.FlagTesoreria = (chkFlagTesoreria.Checked) ? true : false;
                    objDocumento.FlagAtraccion = (chkFlagAtraccion.Checked) ? true : false;
                    objDocumento.FlagAdministracion = (chkFlagAdministracion.Checked) ? true : false;
                    objDocumento.FlagComercial = (chkFlagComercial.Checked) ? true : false;
                    objDocumento.FlagDesarrolloNegocio = (chkFlagDesarrolloNegocio.Checked) ? true : false;
                    objDocumento.FlagControlGestion = (chkFlagControlGestion.Checked) ? true : false;
                    objDocumento.FlagAlmacen = (chkFlagAlmacen.Checked) ? true : false;
                    objDocumento.FlagDespacho = (chkFlagDespacho.Checked) ? true : false;
                    objDocumento.FlagGerenciaGeneral = (chkFlagGerenciaGeneral.Checked) ? true : false;
                    objDocumento.FlagMarketing = (chkFlagMarketing.Checked) ? true : false;
                    objDocumento.FlagOperacion = (chkFlagOperacion.Checked) ? true : false;
                    objDocumento.FlagProyecto = (chkFlagProyecto.Checked) ? true : false;
                    objDocumento.FlagServicioGeneral = (chkFlagServicioGeneral.Checked) ? true : false;
                    objDocumento.FlagPlaneamiento = (chkFlagPlaneamiento.Checked) ? true : false;
                    objDocumento.FlagCompensacion = (chkFlagCompensacion.Checked) ? true : false;
                    objDocumento.FlagBienestar = (chkFlagBienestar.Checked) ? true : false;
                    objDocumento.FlagAlquiler = (chkFlagAlquileres.Checked) ? true : false;
                    objDocumento.FlagDesarrolloOrganizacional = false;
                    objDocumento.FlagEstado = true;
                    objDocumento.Usuario = Parametros.strUsuarioLogin;
                    objDocumento.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumento.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                    {
                        FileStream fStream = File.OpenRead(strRuta);
                        byte[] contents = new byte[fStream.Length];
                        fStream.Read(contents, 0, (int)fStream.Length);
                        fStream.Close();

                        objDocumento.Archivo = contents;

                        objBL_Documento.Inserta(objDocumento);
                    }
                    else
                    {
                        objDocumento.Archivo = byteArchivo;
                        objBL_Documento.Actualiza(objDocumento);
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

            if (txtNombreArchivo.Text == "")
            {
                strMensaje = strMensaje + "- Debe Seleccionar el archivo.\n";
                flag = true;
            }

            if (strRuta == "")
            {
                strMensaje = strMensaje + "- Debe Seleccionar la ruta del archivo.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstDocumento.Where(oB => oB.NombreArchivo == txtNombreArchivo.Text.Trim()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- Ya existe el documento Documento.\n";
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


        #endregion

        
    }
}