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
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Funciones;
using SSOMA.BusinessLogic;
using SSOMA.BusinessEntity;
using System.Diagnostics;

namespace SSOMA.Presentacion.Modulos.Contratistas.Maestros
{
    public partial class frmManContratistaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<EmpresaBE> lstEmpresa;
        public List<CEmpresaArchivo> mListaEmpresaArchivoOrigen = new List<CEmpresaArchivo>();
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdEmpresa = 0;

        public int IdEmpresa
        {
            get { return _IdEmpresa; }
            set { _IdEmpresa = value; }
        }

        #endregion

        #region "Eventos"

        public frmManContratistaEdit()
        {
            InitializeComponent();
        }

        private void frmManContratistaEdit_Load(object sender, EventArgs e)
        {
            txtNumeroTrabajadores.EditValue = 0;

            BSUtils.LoaderLook(cboTipoEmpresa, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoEmpresa), "DescTablaElemento", "IdTablaElemento", true);
            cboTipoEmpresa.EditValue = Parametros.intTEContratista;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Empresa - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Empresa - Modificar";

                EmpresaBE objE_Empresa = new EmpresaBE();

                objE_Empresa = new EmpresaBL().Selecciona(IdEmpresa);

                IdEmpresa = objE_Empresa.IdEmpresa;
                txtRuc.Text = objE_Empresa.Ruc;
                txtRazonSocial.Text = objE_Empresa.RazonSocial;
                txtDireccion.Text = objE_Empresa.Direccion;
                txtTelefono.Text = objE_Empresa.Telefono;
                txtDireccion.EditValue = objE_Empresa.Direccion;
                txtTelefono.EditValue = objE_Empresa.Telefono;
                txtActividadEconomica.Text = objE_Empresa.ActividadEconomica;
                txtNumeroTrabajadores.EditValue = objE_Empresa.NumeroTrabajadores;
                cboTipoEmpresa.EditValue = objE_Empresa.IdTipoEmpresa;
                if (objE_Empresa.Logo != null)
                {
                    this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Empresa.Logo);
                }
                else
                { this.picImage.Image = SSOMA.Presentacion.Properties.Resources.noImage; }
            }

            txtRuc.Select();

            CargaEmpresaArchivo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Jpg File|*.Jpg|Jpeg File|*.Jpeg|Png File|*.Png |Gif File|*.Gif|All|*.*";
            openFile.ShowDialog();

            if (openFile.FileName.Length != 0)
            {
                this.picImage.Image = new FuncionBase().ScaleImage(Image.FromFile(openFile.FileName), 640, 500);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.picImage.Image = SSOMA.Presentacion.Properties.Resources.noImage;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    EmpresaBL objBL_Empresa = new EmpresaBL();
                    EmpresaBE objE_Empresa = new EmpresaBE();

                    objE_Empresa.IdEmpresa = IdEmpresa;
                    objE_Empresa.Ruc = txtRuc.Text;
                    objE_Empresa.RazonSocial = txtRazonSocial.Text;
                    objE_Empresa.Direccion = txtDireccion.Text;
                    objE_Empresa.Telefono = txtTelefono.Text;
                    objE_Empresa.ActividadEconomica = txtActividadEconomica.Text;
                    objE_Empresa.NumeroTrabajadores = Convert.ToInt32(txtNumeroTrabajadores.EditValue);
                    objE_Empresa.IdTipoEmpresa = Convert.ToInt32(cboTipoEmpresa.EditValue);
                    objE_Empresa.Logo = new FuncionBase().Image2Bytes(this.picImage.Image);
                    objE_Empresa.FlagEstado = true;
                    objE_Empresa.Usuario = Parametros.strUsuarioLogin;
                    objE_Empresa.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    List<EmpresaArchivoBE> lstEmpresaArchivo = new List<EmpresaArchivoBE>();

                    foreach (var item in mListaEmpresaArchivoOrigen)
                    {
                        EmpresaArchivoBE objE_EmpresaArchivo = new EmpresaArchivoBE();
                        objE_EmpresaArchivo.IdEmpresa = item.IdEmpresa;
                        objE_EmpresaArchivo.IdEmpresaArchivo = item.IdEmpresaArchivo;
                        objE_EmpresaArchivo.Archivo = item.Archivo;
                        objE_EmpresaArchivo.NombreArchivo = item.NombreArchivo;
                        objE_EmpresaArchivo.Extension = item.Extension;
                        objE_EmpresaArchivo.Descripcion = item.Descripcion;
                        objE_EmpresaArchivo.TipoOper = item.TipoOper;
                        objE_EmpresaArchivo.FlagEstado = true;
                        objE_EmpresaArchivo.Usuario = Parametros.strUsuarioLogin;
                        objE_EmpresaArchivo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_EmpresaArchivo.TipoOper = item.TipoOper;
                        lstEmpresaArchivo.Add(objE_EmpresaArchivo);
                    }

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Empresa.Inserta(objE_Empresa, lstEmpresaArchivo);
                    else
                        objBL_Empresa.Actualiza(objE_Empresa, lstEmpresaArchivo);

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

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtRazonSocial.Focus();
            }
        }

        private void txtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtDireccion.Focus();
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtActividadEconomica.Focus();
            }
        }

        private void txtActividadEconomica_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtNumeroTrabajadores.Focus();
            }
        }

        private void txtNumeroTrabajadores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboTipoEmpresa.Focus();
            }
        }

        private void cboTipoEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnGrabar.Focus();
            }
        }

        private void nuevoEmpresaArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fStreamArchivo = File.OpenRead(Path.Combine(Directory.GetCurrentDirectory(), "Vacio.pdf"));
                byte[] Archivo = new byte[fStreamArchivo.Length];
                fStreamArchivo.Read(Archivo, 0, (int)fStreamArchivo.Length);
                fStreamArchivo.Close();

                
                gvEmpresaArchivo.AddNewRow();
                gvEmpresaArchivo.SetRowCellValue(gvEmpresaArchivo.FocusedRowHandle, "IdEmpresa", IdEmpresa);
                gvEmpresaArchivo.SetRowCellValue(gvEmpresaArchivo.FocusedRowHandle, "IdEmpresaArchivo", 0);
                gvEmpresaArchivo.SetRowCellValue(gvEmpresaArchivo.FocusedRowHandle, "Archivo", Archivo);
                gvEmpresaArchivo.SetRowCellValue(gvEmpresaArchivo.FocusedRowHandle, "NombreArchivo", "");
                gvEmpresaArchivo.SetRowCellValue(gvEmpresaArchivo.FocusedRowHandle, "Extension", "");
                gvEmpresaArchivo.SetRowCellValue(gvEmpresaArchivo.FocusedRowHandle, "Descripcion", "");
                gvEmpresaArchivo.SetRowCellValue(gvEmpresaArchivo.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvEmpresaArchivo.FocusedColumn = gvEmpresaArchivo.Columns["NombreArchivo"];
                gvEmpresaArchivo.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarEmpresaArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdEmpresaArchivo = 0;
                if (gvEmpresaArchivo.GetFocusedRowCellValue("IdEmpresaArchivo") != null)
                    IdEmpresaArchivo = int.Parse(gvEmpresaArchivo.GetFocusedRowCellValue("IdEmpresaArchivo").ToString());
                EmpresaArchivoBE objBE_EmpresaArchivo = new EmpresaArchivoBE();
                objBE_EmpresaArchivo.IdEmpresaArchivo = IdEmpresaArchivo;
                objBE_EmpresaArchivo.IdEmpresa = Parametros.intEmpresaId;
                objBE_EmpresaArchivo.Usuario = Parametros.strUsuarioLogin;
                objBE_EmpresaArchivo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                EmpresaArchivoBL objBL_EmpresaArchivo = new EmpresaArchivoBL();
                objBL_EmpresaArchivo.Elimina(objBE_EmpresaArchivo);
                gvEmpresaArchivo.DeleteRow(gvEmpresaArchivo.FocusedRowHandle);
                gvEmpresaArchivo.RefreshData();

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

                        gvEmpresaArchivo.SetRowCellValue(gvEmpresaArchivo.FocusedRowHandle, "Archivo", Archivo);
                        gvEmpresaArchivo.SetRowCellValue(gvEmpresaArchivo.FocusedRowHandle, "NombreArchivo", strNombreArchivo);
                        gvEmpresaArchivo.SetRowCellValue(gvEmpresaArchivo.FocusedRowHandle, "Extension", strExtension);

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
            if (gvEmpresaArchivo.RowCount > 0)
            {
                string sFilePath = "";
                string strExtension = "";
                byte[] Buffer;

                Buffer = (byte[])gvEmpresaArchivo.GetFocusedRowCellValue("Archivo");
                strExtension = (string)gvEmpresaArchivo.GetFocusedRowCellValue("Extension");

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

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtRuc.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el RUC.\n";
                flag = true;
            }

            if (txtRazonSocial.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la razón social.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstEmpresa.Where(oB => oB.Ruc.ToUpper() == txtRuc.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Ruc ya existe.\n";
                    flag = true;
                }

                var BuscarRazonSocial = lstEmpresa.Where(oB => oB.RazonSocial.ToUpper() == txtRazonSocial.Text.ToUpper()).ToList();
                if (BuscarRazonSocial.Count > 0)
                {
                    strMensaje = strMensaje + "- La Razón social ya existe.\n";
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

        private void CargaEmpresaArchivo()
        {
            List<EmpresaArchivoBE> lstTmpEmpresaArchivo = null;
            lstTmpEmpresaArchivo = new EmpresaArchivoBL().ListaTodosActivo(IdEmpresa);

            foreach (EmpresaArchivoBE item in lstTmpEmpresaArchivo)
            {
                CEmpresaArchivo objE_EmpresaArchivo = new CEmpresaArchivo();
                objE_EmpresaArchivo.IdEmpresa = item.IdEmpresa;
                objE_EmpresaArchivo.IdEmpresaArchivo = item.IdEmpresaArchivo;
                objE_EmpresaArchivo.Archivo = item.Archivo;
                objE_EmpresaArchivo.NombreArchivo = item.NombreArchivo;
                objE_EmpresaArchivo.Extension = item.Extension;
                objE_EmpresaArchivo.Descripcion = item.Descripcion;
                objE_EmpresaArchivo.TipoOper = item.TipoOper;
                mListaEmpresaArchivoOrigen.Add(objE_EmpresaArchivo);
            }

            bsListadoEmpresaArchivo.DataSource = mListaEmpresaArchivoOrigen;
            gcEmpresaArchivo.DataSource = bsListadoEmpresaArchivo;
            gcEmpresaArchivo.RefreshDataSource();
        }

        #endregion

        public class CEmpresaArchivo
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdEmpresaArchivo { get; set; }
            public byte[] Archivo { get; set; }
            public string NombreArchivo { get; set; }
            public string Extension { get; set; }
            public string Descripcion { get; set; }
            public Int32 TipoOper { get; set; }

            public CEmpresaArchivo()
            {

            }
        }

        
    }
}