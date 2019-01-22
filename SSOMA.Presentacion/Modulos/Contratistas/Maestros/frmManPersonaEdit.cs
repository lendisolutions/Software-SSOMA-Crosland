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
using System.Diagnostics;
using SSOMA.Presentacion.Modulos.Otros;

namespace SSOMA.Presentacion.Modulos.Contratistas.Maestros
{
    public partial class frmManPersonaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PersonaBE> lstPersona;
        public List<CPersonaArchivo> mListaPersonaArchivoOrigen = new List<CPersonaArchivo>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public PersonaBE pPersonaBE { get; set; }

        int _IdEmpresa = 0;

        public int IdEmpresa
        {
            get { return _IdEmpresa; }
            set { _IdEmpresa = value; }
        }

        int _IdPersona = 0;

        public int IdPersona
        {
            get { return _IdPersona; }
            set { _IdPersona = value; }
        }

        #endregion

        #region "Eventos"

        public frmManPersonaEdit()
        {
            InitializeComponent();
        }

        private void frmManPersonaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;

            BSUtils.LoaderLook(cboEmpresaContratista, new EmpresaBL().ListaCombo(Parametros.intTEContratista), "RazonSocial", "IdEmpresa", true);

            BSUtils.LoaderLook(cboEstadoCivil, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblEstadoCivil), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboTipoContrato, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoContrato), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionPersona), "DescTablaElemento", "IdTablaElemento", true);

            deFechaNacimiento.EditValue = DateTime.Now;
            deFechaIngreso.EditValue = DateTime.Now;

            deFechaSctrIni.EditValue = DateTime.Now;
            deFechaSctrFin.EditValue = DateTime.Now;

            txtEdad.EditValue = 0;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Persona - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Persona - Modificar";
                PersonaBE objE_Persona = null;
                objE_Persona = new PersonaBL().Selecciona(0,0,0,IdPersona);
                if (objE_Persona != null)
                {
                    cboEmpresa.EditValue = objE_Persona.IdEmpresa;
                    cboEmpresaContratista.EditValue = objE_Persona.IdContratista;
                    cboUnidadMinera.EditValue = objE_Persona.IdUnidadMinera;
                    cboArea.EditValue = objE_Persona.IdArea;
                    txtDni.Text = objE_Persona.Dni.Trim();
                    txtApeNom.Text = objE_Persona.ApeNom.Trim();
                    deFechaNacimiento.EditValue = objE_Persona.FechaNacimiento;
                    txtEdad.EditValue = objE_Persona.Edad;
                    deFechaIngreso.EditValue = objE_Persona.FechaIngreso;
                    deFechaCese.EditValue = objE_Persona.FechaCese;
                    txtCargo.Text = objE_Persona.Cargo.Trim();
                    txtSexo.Text = objE_Persona.Sexo;
                    cboTipoContrato.EditValue = objE_Persona.IdTipoContrato;
                    cboEstadoCivil.EditValue = objE_Persona.IdEstadoCivil;
                    txtEmail.Text = objE_Persona.Email;
                    chkFlagCapacitacion.Checked = (objE_Persona.FlagCapacitacion) ? true : false;
                    txtSctr.Text = objE_Persona.Sctr;
                    deFechaSctrIni.DateTime = objE_Persona.FechaSctrIni;
                    deFechaSctrFin.DateTime = objE_Persona.FechaSctrFin;
                    txtObservacion.Text = objE_Persona.Observacion;
                    cboSituacion.EditValue = objE_Persona.IdSituacion;
                }

            }

            txtDni.Select();

            CargaPersonaArchivo();
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
            }
        }

        private void cboUnidadMinera_EditValueChanged(object sender, EventArgs e)
        {
            if (cboUnidadMinera.EditValue != null)
            {
                BSUtils.LoaderLook(cboArea, new AreaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboUnidadMinera.EditValue)), "DescArea", "IdArea", true);
            }
        }

        private void nuevoPersonaArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fStreamArchivo = File.OpenRead(Path.Combine(Directory.GetCurrentDirectory(), "Vacio.pdf"));
                byte[] Archivo = new byte[fStreamArchivo.Length];
                fStreamArchivo.Read(Archivo, 0, (int)fStreamArchivo.Length);
                fStreamArchivo.Close();


                gvPersonaArchivo.AddNewRow();
                gvPersonaArchivo.SetRowCellValue(gvPersonaArchivo.FocusedRowHandle, "IdEmpresa", IdEmpresa);
                gvPersonaArchivo.SetRowCellValue(gvPersonaArchivo.FocusedRowHandle, "IdPersonaArchivo", 0);
                gvPersonaArchivo.SetRowCellValue(gvPersonaArchivo.FocusedRowHandle, "IdPersona", 0);
                gvPersonaArchivo.SetRowCellValue(gvPersonaArchivo.FocusedRowHandle, "Archivo", Archivo);
                gvPersonaArchivo.SetRowCellValue(gvPersonaArchivo.FocusedRowHandle, "NombreArchivo", "");
                gvPersonaArchivo.SetRowCellValue(gvPersonaArchivo.FocusedRowHandle, "Extension", "");
                gvPersonaArchivo.SetRowCellValue(gvPersonaArchivo.FocusedRowHandle, "Descripcion", "");
                gvPersonaArchivo.SetRowCellValue(gvPersonaArchivo.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvPersonaArchivo.FocusedColumn = gvPersonaArchivo.Columns["NombreArchivo"];
                gvPersonaArchivo.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarPersonaArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdPersonaArchivo = 0;
                if (gvPersonaArchivo.GetFocusedRowCellValue("IdPersonaArchivo") != null)
                    IdPersonaArchivo = int.Parse(gvPersonaArchivo.GetFocusedRowCellValue("IdPersonaArchivo").ToString());
                PersonaArchivoBE objBE_PersonaArchivo = new PersonaArchivoBE();
                objBE_PersonaArchivo.IdPersonaArchivo = IdPersonaArchivo;
                objBE_PersonaArchivo.IdEmpresa = Parametros.intEmpresaId;
                objBE_PersonaArchivo.Usuario = Parametros.strUsuarioLogin;
                objBE_PersonaArchivo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                PersonaArchivoBL objBL_PersonaArchivo = new PersonaArchivoBL();
                objBL_PersonaArchivo.Elimina(objBE_PersonaArchivo);
                gvPersonaArchivo.DeleteRow(gvPersonaArchivo.FocusedRowHandle);
                gvPersonaArchivo.RefreshData();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtArchivo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    OpenFileDialog dlg = new OpenFileDialog();
                    //dlg.DefaultExt = ".pdf"; // Default file extension
                    dlg.Filter = "Todos los archivos (*.*)|*.*"; // Filter files by extension 

                    // Show open file dialog box
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        string strRuta = "";
                        string strNombreArchivo = "";
                        string strExtension = "";

                        strRuta = dlg.FileName;
                        strNombreArchivo = Path.GetFileName(dlg.FileName);
                        strExtension = Path.GetExtension(dlg.FileName);

                        FileStream fStreamArchivo = File.OpenRead(strRuta);
                        byte[] Archivo = new byte[fStreamArchivo.Length];
                        fStreamArchivo.Read(Archivo, 0, (int)fStreamArchivo.Length);
                        fStreamArchivo.Close();

                        gvPersonaArchivo.SetRowCellValue(gvPersonaArchivo.FocusedRowHandle, "Archivo", Archivo);
                        gvPersonaArchivo.SetRowCellValue(gvPersonaArchivo.FocusedRowHandle, "NombreArchivo", strNombreArchivo);
                        gvPersonaArchivo.SetRowCellValue(gvPersonaArchivo.FocusedRowHandle, "Extension", strExtension);

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtArchivo_DoubleClick(object sender, EventArgs e)
        {
            if (gvPersonaArchivo.RowCount > 0)
            {
                string sFilePath = "";
                string strExtension = "";
                byte[] Buffer;

                Buffer = (byte[])gvPersonaArchivo.GetFocusedRowCellValue("Archivo");
                strExtension = (string)gvPersonaArchivo.GetFocusedRowCellValue("Extension");

                sFilePath = Path.GetTempFileName();

                if (strExtension == ".pdf")
                {
                    File.Move(sFilePath, Path.ChangeExtension(sFilePath, ".pdf"));
                    sFilePath = Path.ChangeExtension(sFilePath, ".pdf");
                }

                if (strExtension == ".docx")
                {
                    File.Move(sFilePath, Path.ChangeExtension(sFilePath, ".docx"));
                    sFilePath = Path.ChangeExtension(sFilePath, ".docx");
                }

                if (strExtension == ".xlsx")
                {
                    File.Move(sFilePath, Path.ChangeExtension(sFilePath, ".xlsx"));
                    sFilePath = Path.ChangeExtension(sFilePath, ".xlsx");
                }

                if (strExtension == ".pptx")
                {
                    File.Move(sFilePath, Path.ChangeExtension(sFilePath, ".pptx"));
                    sFilePath = Path.ChangeExtension(sFilePath, ".pptx");
                }

                File.WriteAllBytes(sFilePath, Buffer);

                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = sFilePath;
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
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PersonaBL objBL_Persona = new PersonaBL();
                    PersonaBE objPersona = new PersonaBE();

                    objPersona.IdPersona = IdPersona;
                    objPersona.IdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
                    objPersona.IdArea = Convert.ToInt32(cboArea.EditValue);
                    objPersona.IdContratista = Convert.ToInt32(cboEmpresaContratista.EditValue);
                    objPersona.Dni = txtDni.Text;
                    objPersona.ApeNom = txtApeNom.Text;
                    objPersona.FechaNacimiento = Convert.ToDateTime(deFechaNacimiento.DateTime.ToShortDateString());
                    objPersona.Edad = Convert.ToInt32(txtEdad.EditValue);
                    objPersona.FechaIngreso = Convert.ToDateTime(deFechaIngreso.DateTime.ToShortDateString());
                    objPersona.FechaCese = deFechaCese.DateTime.Year == 1 ? (DateTime?)null : Convert.ToDateTime(deFechaCese.DateTime.ToShortDateString());
                    objPersona.Cargo = txtCargo.Text;
                    objPersona.Sexo = txtSexo.Text;
                    objPersona.IdTipoContrato = Convert.ToInt32(cboTipoContrato.EditValue);
                    objPersona.IdEstadoCivil = Convert.ToInt32(cboEstadoCivil.EditValue);
                    objPersona.Email = txtEmail.Text;
                    objPersona.FlagCapacitacion = (chkFlagCapacitacion.Checked) ? true : false;
                    objPersona.Sctr = txtSctr.Text;
                    objPersona.FechaSctrIni = Convert.ToDateTime(deFechaSctrIni.DateTime.ToShortDateString());
                    objPersona.FechaSctrFin = Convert.ToDateTime(deFechaSctrFin.DateTime.ToShortDateString());
                    objPersona.Observacion = txtObservacion.Text;
                    objPersona.IdSituacion = Convert.ToInt32(cboSituacion.EditValue);
                    objPersona.FlagEstado = true;
                    objPersona.Usuario = Parametros.strUsuarioLogin;
                    objPersona.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPersona.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                    List<PersonaArchivoBE> lstPersonaArchivo = new List<PersonaArchivoBE>();

                    foreach (var item in mListaPersonaArchivoOrigen)
                    {
                        PersonaArchivoBE objE_PersonaArchivo = new PersonaArchivoBE();
                        objE_PersonaArchivo.IdEmpresa = item.IdEmpresa;
                        objE_PersonaArchivo.IdPersonaArchivo = item.IdPersonaArchivo;
                        objE_PersonaArchivo.IdPersona = item.IdPersona;
                        objE_PersonaArchivo.Archivo = item.Archivo;
                        objE_PersonaArchivo.NombreArchivo = item.NombreArchivo;
                        objE_PersonaArchivo.Extension = item.Extension;
                        objE_PersonaArchivo.Descripcion = item.Descripcion;
                        objE_PersonaArchivo.TipoOper = item.TipoOper;
                        objE_PersonaArchivo.FlagEstado = true;
                        objE_PersonaArchivo.Usuario = Parametros.strUsuarioLogin;
                        objE_PersonaArchivo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_PersonaArchivo.TipoOper = item.TipoOper;
                        lstPersonaArchivo.Add(objE_PersonaArchivo);
                    }

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Persona.Inserta(objPersona, lstPersonaArchivo);
                    else
                        objBL_Persona.Actualiza(objPersona, lstPersonaArchivo);

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

        private void CargaPersonaArchivo()
        {
            List<PersonaArchivoBE> lstTmpPersonaArchivo = null;
            lstTmpPersonaArchivo = new PersonaArchivoBL().ListaTodosActivo(IdPersona);

            foreach (PersonaArchivoBE item in lstTmpPersonaArchivo)
            {
                CPersonaArchivo objE_PersonaArchivo = new CPersonaArchivo();
                objE_PersonaArchivo.IdPersona = item.IdPersona;
                objE_PersonaArchivo.IdPersonaArchivo = item.IdPersonaArchivo;
                objE_PersonaArchivo.IdPersona = item.IdPersona;
                objE_PersonaArchivo.Archivo = item.Archivo;
                objE_PersonaArchivo.NombreArchivo = item.NombreArchivo;
                objE_PersonaArchivo.Extension = item.Extension;
                objE_PersonaArchivo.Descripcion = item.Descripcion;
                objE_PersonaArchivo.TipoOper = item.TipoOper;
                mListaPersonaArchivoOrigen.Add(objE_PersonaArchivo);
            }

            bsListadoPersonaArchivo.DataSource = mListaPersonaArchivoOrigen;
            gcPersonaArchivo.DataSource = bsListadoPersonaArchivo;
            gcPersonaArchivo.RefreshDataSource();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";
            if (txtApeNom.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            //calcular edad;
            int intEdad = 0;
            intEdad = DateTime.Today.AddTicks(deFechaNacimiento.DateTime.Ticks).Year - 1;
            txtEdad.EditValue = intEdad;

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstPersona.Where(oB => oB.ApeNom.ToUpper() == txtApeNom.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- Los Apellidos y Nombres ya existe.\n";
                    flag = true;
                }

                var BuscarDni = lstPersona.Where(oB => oB.Dni.ToUpper() == txtDni.Text.ToUpper()).ToList();
                if (BuscarDni.Count > 0)
                {
                    strMensaje = strMensaje + "- El DNI ya existe.\n";
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

        public class CPersonaArchivo
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdPersonaArchivo { get; set; }
            public Int32 IdPersona { get; set; }
            public byte[] Archivo { get; set; }
            public string NombreArchivo { get; set; }
            public string Extension { get; set; }
            public string Descripcion { get; set; }
            public Int32 TipoOper { get; set; }

            public CPersonaArchivo()
            {

            }
        }

        
    }
}