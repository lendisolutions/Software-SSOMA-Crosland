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
    public partial class frmManActividadContratistaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Atributos"

        public List<ActividadContratistaBE> lstActividadContratista;
        public List<CActividadContratistaDetalle> mListaActividadContratistaDetalleOrigen = new List<CActividadContratistaDetalle>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ActividadContratistaBE pActividadContratistaBE { get; set; }

        int _IdEmpresa = 0;

        public int IdEmpresa
        {
            get { return _IdEmpresa; }
            set { _IdEmpresa = value; }
        }

        int _IdActividadContratista = 0;

        public int IdActividadContratista
        {
            get { return _IdActividadContratista; }
            set { _IdActividadContratista = value; }
        }

        #endregion

        #region "Eventos"

        public frmManActividadContratistaEdit()
        {
            InitializeComponent();
        }

        private void frmManActividadContratistaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresaContratista, new EmpresaBL().ListaCombo(Parametros.intTEContratista), "RazonSocial", "IdEmpresa", true);
            cboEmpresaContratista.EditValue = IdEmpresa;

            deFechaSctrIni.EditValue = DateTime.Now;
            deFechaSctrFin.EditValue = DateTime.Now;

            deFechaIni.EditValue = DateTime.Now;
            deFechaFin.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Actividad Contratista - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Actividad Contratista - Modificar";
                ActividadContratistaBE objE_ActividadContratista = null;
                objE_ActividadContratista = new ActividadContratistaBL().Selecciona(IdActividadContratista);
                if (objE_ActividadContratista != null)
                {
                    cboEmpresaContratista.EditValue = objE_ActividadContratista.IdEmpresa;
                    txtDescActividad.Text = objE_ActividadContratista.DescActvidad;
                    deFechaIni.DateTime = objE_ActividadContratista.FechaIni;
                    deFechaFin.DateTime = objE_ActividadContratista.FechaFin;
                    txtResponsableContratista.Text = objE_ActividadContratista.ResponsableContratista;
                    txtEmailContratista.Text = objE_ActividadContratista.EmailContratista;
                    txtResponsableEmpresa.Text = objE_ActividadContratista.ResponsableEmpresa;
                    txtEmailEmpresa.Text = objE_ActividadContratista.EmailEmpresa;
                    deFechaSctrIni.DateTime = objE_ActividadContratista.FechaSctrIni;
                    deFechaSctrFin.DateTime = objE_ActividadContratista.FechaSctrFin;
                    txtObservacion.Text = objE_ActividadContratista.Observacion;
                    
                }

            }

            txtDescActividad.Select();
            CargaActividadContratistaDetalle();

        }

        private void btnBucarResponsable_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = true;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    txtResponsableEmpresa.Text = frm.pPersonaBE.ApeNom; ;
                    txtEmailEmpresa.Text = frm.pPersonaBE.Email;
                }

                deFechaSctrIni.Focus();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoActividadContratistaDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fStreamArchivo = File.OpenRead(Path.Combine(Directory.GetCurrentDirectory(), "Vacio.pdf"));
                byte[] Archivo = new byte[fStreamArchivo.Length];
                fStreamArchivo.Read(Archivo, 0, (int)fStreamArchivo.Length);
                fStreamArchivo.Close();


                gvActividadContratistaDetalle.AddNewRow();
                gvActividadContratistaDetalle.SetRowCellValue(gvActividadContratistaDetalle.FocusedRowHandle, "IdEmpresa", IdEmpresa);
                gvActividadContratistaDetalle.SetRowCellValue(gvActividadContratistaDetalle.FocusedRowHandle, "IdActividadContratistaDetalle", 0);
                gvActividadContratistaDetalle.SetRowCellValue(gvActividadContratistaDetalle.FocusedRowHandle, "IdActividadContratista", 0);
                gvActividadContratistaDetalle.SetRowCellValue(gvActividadContratistaDetalle.FocusedRowHandle, "Archivo", Archivo);
                gvActividadContratistaDetalle.SetRowCellValue(gvActividadContratistaDetalle.FocusedRowHandle, "NombreArchivo", "");
                gvActividadContratistaDetalle.SetRowCellValue(gvActividadContratistaDetalle.FocusedRowHandle, "Extension", "");
                gvActividadContratistaDetalle.SetRowCellValue(gvActividadContratistaDetalle.FocusedRowHandle, "Descripcion", "");
                gvActividadContratistaDetalle.SetRowCellValue(gvActividadContratistaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvActividadContratistaDetalle.FocusedColumn = gvActividadContratistaDetalle.Columns["NombreArchivo"];
                gvActividadContratistaDetalle.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarActividadContratistaDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdActividadContratistaDetalle = 0;
                if (gvActividadContratistaDetalle.GetFocusedRowCellValue("IdActividadContratistaDetalle") != null)
                    IdActividadContratistaDetalle = int.Parse(gvActividadContratistaDetalle.GetFocusedRowCellValue("IdActividadContratistaDetalle").ToString());
                ActividadContratistaDetalleBE objBE_ActividadContratistaDetalle = new ActividadContratistaDetalleBE();
                objBE_ActividadContratistaDetalle.IdActividadContratistaDetalle = IdActividadContratistaDetalle;
                objBE_ActividadContratistaDetalle.IdEmpresa = Parametros.intEmpresaId;
                objBE_ActividadContratistaDetalle.Usuario = Parametros.strUsuarioLogin;
                objBE_ActividadContratistaDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                ActividadContratistaDetalleBL objBL_ActividadContratistaDetalle = new ActividadContratistaDetalleBL();
                objBL_ActividadContratistaDetalle.Elimina(objBE_ActividadContratistaDetalle);
                gvActividadContratistaDetalle.DeleteRow(gvActividadContratistaDetalle.FocusedRowHandle);
                gvActividadContratistaDetalle.RefreshData();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarActividadContratistaDetalleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                int IdActividadContratistaDetalle = 0;
                if (gvActividadContratistaDetalle.GetFocusedRowCellValue("IdActividadContratistaDetalle") != null)
                    IdActividadContratistaDetalle = int.Parse(gvActividadContratistaDetalle.GetFocusedRowCellValue("IdActividadContratistaDetalle").ToString());
                ActividadContratistaDetalleBE objBE_ActividadContratistaDetalle = new ActividadContratistaDetalleBE();
                objBE_ActividadContratistaDetalle.IdActividadContratistaDetalle = IdActividadContratistaDetalle;
                objBE_ActividadContratistaDetalle.IdEmpresa = Parametros.intEmpresaId;
                objBE_ActividadContratistaDetalle.Usuario = Parametros.strUsuarioLogin;
                objBE_ActividadContratistaDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                ActividadContratistaDetalleBL objBL_ActividadContratistaDetalle = new ActividadContratistaDetalleBL();
                objBL_ActividadContratistaDetalle.Elimina(objBE_ActividadContratistaDetalle);
                gvActividadContratistaDetalle.DeleteRow(gvActividadContratistaDetalle.FocusedRowHandle);
                gvActividadContratistaDetalle.RefreshData();

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

                        gvActividadContratistaDetalle.SetRowCellValue(gvActividadContratistaDetalle.FocusedRowHandle, "Archivo", Archivo);
                        gvActividadContratistaDetalle.SetRowCellValue(gvActividadContratistaDetalle.FocusedRowHandle, "NombreArchivo", strNombreArchivo);
                        gvActividadContratistaDetalle.SetRowCellValue(gvActividadContratistaDetalle.FocusedRowHandle, "Extension", strExtension);

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
            if (gvActividadContratistaDetalle.RowCount > 0)
            {
                string sFilePath = "";
                string strExtension = "";
                byte[] Buffer;

                Buffer = (byte[])gvActividadContratistaDetalle.GetFocusedRowCellValue("Archivo");
                strExtension = (string)gvActividadContratistaDetalle.GetFocusedRowCellValue("Extension");

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
                    ActividadContratistaBL objBL_ActividadContratista = new ActividadContratistaBL();
                    ActividadContratistaBE objActividadContratista = new ActividadContratistaBE();

                    objActividadContratista.IdEmpresa = IdEmpresa;
                    objActividadContratista.IdActividadContratista = IdActividadContratista;
                    objActividadContratista.DescActvidad = txtDescActividad.Text;
                    objActividadContratista.FechaIni = Convert.ToDateTime(deFechaIni.DateTime.ToShortDateString());
                    objActividadContratista.FechaFin = Convert.ToDateTime(deFechaFin.DateTime.ToShortDateString());
                    objActividadContratista.ResponsableContratista = txtResponsableContratista.Text;
                    objActividadContratista.EmailContratista = txtEmailContratista.Text;
                    objActividadContratista.ResponsableEmpresa = txtResponsableEmpresa.Text;
                    objActividadContratista.EmailEmpresa = txtEmailEmpresa.Text;
                    objActividadContratista.FechaSctrIni = Convert.ToDateTime(deFechaSctrIni.DateTime.ToShortDateString());
                    objActividadContratista.FechaSctrFin = Convert.ToDateTime(deFechaSctrFin.DateTime.ToShortDateString());
                    objActividadContratista.Observacion = txtObservacion.Text;
                    objActividadContratista.FlagEstado = true;
                    objActividadContratista.Usuario = Parametros.strUsuarioLogin;
                    objActividadContratista.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                   

                    List<ActividadContratistaDetalleBE> lstActividadContratistaDetalle = new List<ActividadContratistaDetalleBE>();

                    foreach (var item in mListaActividadContratistaDetalleOrigen)
                    {
                        ActividadContratistaDetalleBE objE_ActividadContratistaDetalle = new ActividadContratistaDetalleBE();
                        objE_ActividadContratistaDetalle.IdEmpresa = item.IdEmpresa;
                        objE_ActividadContratistaDetalle.IdActividadContratistaDetalle = item.IdActividadContratistaDetalle;
                        objE_ActividadContratistaDetalle.IdActividadContratista = item.IdActividadContratista;
                        objE_ActividadContratistaDetalle.Archivo = item.Archivo;
                        objE_ActividadContratistaDetalle.NombreArchivo = item.NombreArchivo;
                        objE_ActividadContratistaDetalle.Extension = item.Extension;
                        objE_ActividadContratistaDetalle.Descripcion = item.Descripcion;
                        objE_ActividadContratistaDetalle.TipoOper = item.TipoOper;
                        objE_ActividadContratistaDetalle.FlagEstado = true;
                        objE_ActividadContratistaDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_ActividadContratistaDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ActividadContratistaDetalle.TipoOper = item.TipoOper;
                        lstActividadContratistaDetalle.Add(objE_ActividadContratistaDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                        objBL_ActividadContratista.Inserta(objActividadContratista, lstActividadContratistaDetalle);
                    else
                        objBL_ActividadContratista.Actualiza(objActividadContratista, lstActividadContratistaDetalle);

                    
                    string strMailTO = "";
                    strMailTO = txtEmailEmpresa.Text.Trim() + ";" + txtEmailContratista.Text;

                    BSUtils.EmailSend(strMailTO,txtDescActividad.Text, txtObservacion.Text, "", "", "", "");

                    Application.DoEvents();

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

        private void cboEmpresaContratista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtDescActividad.Focus();
            }
        }

        private void txtDescActividad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                deFechaIni.Focus();
            }
        }

        private void deFechaIni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                deFechaFin.Focus();
            }
        }

        private void deFechaFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtResponsableContratista.Focus();
            }
        }

        private void txtResponsableContratista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtEmailContratista.Focus();
            }
        }

        private void txtEmailContratista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtResponsableEmpresa.Focus();
            }
        }

        private void txtResponsableEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtEmailEmpresa.Focus();
            }
        }

        private void txtEmailEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                deFechaSctrIni.Focus();
            }
        }

        private void deFechaSctrIni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtObservacion.Focus();
            }
        }

        private void txtObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnGrabar.Focus();
            }
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtDescActividad.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción de la Actividad del Contratista.\n";
                flag = true;
            }

            if (txtResponsableContratista.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el responsable del contratista.\n";
                flag = true;
            }

            if (txtEmailContratista.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el email del contratista.\n";
                flag = true;
            }

            
            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstActividadContratista.Where(oB => oB.DescActvidad.ToUpper() == txtDescActividad.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La Actividad ya existe ya existe.\n";
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

        private void CargaActividadContratistaDetalle()
        {
            List<ActividadContratistaDetalleBE> lstTmpActividadContratistaDetalle = null;
            lstTmpActividadContratistaDetalle = new ActividadContratistaDetalleBL().ListaTodosActivo(IdActividadContratista);

            foreach (ActividadContratistaDetalleBE item in lstTmpActividadContratistaDetalle)
            {
                CActividadContratistaDetalle objE_ActividadContratistaDetalle = new CActividadContratistaDetalle();
                objE_ActividadContratistaDetalle.IdEmpresa = item.IdEmpresa;
                objE_ActividadContratistaDetalle.IdActividadContratistaDetalle = item.IdActividadContratistaDetalle;
                objE_ActividadContratistaDetalle.IdActividadContratista = item.IdActividadContratista;
                objE_ActividadContratistaDetalle.Archivo = item.Archivo;
                objE_ActividadContratistaDetalle.NombreArchivo = item.NombreArchivo;
                objE_ActividadContratistaDetalle.Extension = item.Extension;
                objE_ActividadContratistaDetalle.Descripcion = item.Descripcion;
                objE_ActividadContratistaDetalle.TipoOper = item.TipoOper;
                mListaActividadContratistaDetalleOrigen.Add(objE_ActividadContratistaDetalle);
            }

            bsListadoActividadContratistaDetalle.DataSource = mListaActividadContratistaDetalleOrigen;
            gcActividadContratistaDetalle.DataSource = bsListadoActividadContratistaDetalle;
            gcActividadContratistaDetalle.RefreshDataSource();
        }


        #endregion

        public class CActividadContratistaDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdActividadContratista { get; set; }
            public Int32 IdActividadContratistaDetalle { get; set; }
            public byte[] Archivo { get; set; }
            public string NombreArchivo { get; set; }
            public string Extension { get; set; }
            public string Descripcion { get; set; }
            public Int32 TipoOper { get; set; }

            public CActividadContratistaDetalle()
            {

            }
        }

        
    }
}