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
    public partial class frmManTemaVirtualEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TemaBE> lstTema;
        public List<CTemaDetalle> mListaTemaDetalleOrigen = new List<CTemaDetalle>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TemaBE pTemaBE { get; set; }

        int _IdCategoriaTema = 0;

        public int IdCategoriaTema
        {
            get { return _IdCategoriaTema; }
            set { _IdCategoriaTema = value; }
        }

        int _IdTema = 0;

        public int IdTema
        {
            get { return _IdTema; }
            set { _IdTema = value; }
        }

        public int IdSituacion { get; set; }

        #endregion

        #region "Eventos"

        public frmManTemaVirtualEdit()
        {
            InitializeComponent();
        }

        private void frmManTemaVirtualEdit_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = Parametros.intPeriodo;
            BSUtils.LoaderLook(cboCategoriaTema, new CategoriaTemaBL().ListaCombo(Parametros.intEmpresaId), "DescCategoriaTema", "IdCategoriaTema", true);
            cboCategoriaTema.EditValue = IdCategoriaTema;

            deFechaIni.EditValue = DateTime.Now;
            deFechaFin.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Tema Virtual - Nuevo";
                IdSituacion = Parametros.intTEMAActivo;
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Tema Virtual - Modificar";
                TemaBE objE_Tema = null;
                objE_Tema = new TemaBL().Selecciona(Parametros.intEmpresaId, IdTema);
                if (objE_Tema != null)
                {
                    cboCategoriaTema.EditValue = objE_Tema.IdCategoriaTema;
                    txtPeriodo.EditValue = objE_Tema.Periodo;
                    txtObjetivo.Text = objE_Tema.Objetivo;
                    txtDescripcion.Text = objE_Tema.DescTema;
                    deFechaIni.DateTime = objE_Tema.FechaIni;
                    deFechaFin.DateTime = objE_Tema.FechaFin;
                    if (objE_Tema.Logo != null)
                    {
                        this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Tema.Logo);
                    }
                    else
                    { this.picImage.Image = SSOMA.Presentacion.Properties.Resources.noImage; }

                    if (objE_Tema.Firma1 != null)
                    {
                        this.picFirma.Image = new FuncionBase().Bytes2Image((byte[])objE_Tema.Firma1);
                    }
                    else
                    { this.picFirma.Image = SSOMA.Presentacion.Properties.Resources.firma; }

                    IdSituacion = objE_Tema.IdSituacion;
                }

            }

            txtObjetivo.Select();
            CargaTemaDetalle();
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

        private void nuevoTemaDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fStreamArchivo = File.OpenRead(Path.Combine(Directory.GetCurrentDirectory(), "Vacio.pdf"));
                byte[] Archivo = new byte[fStreamArchivo.Length];
                fStreamArchivo.Read(Archivo, 0, (int)fStreamArchivo.Length);
                fStreamArchivo.Close();


                gvTemaDetalle.AddNewRow();
                gvTemaDetalle.SetRowCellValue(gvTemaDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                gvTemaDetalle.SetRowCellValue(gvTemaDetalle.FocusedRowHandle, "IdTemaDetalle", 0);
                gvTemaDetalle.SetRowCellValue(gvTemaDetalle.FocusedRowHandle, "IdTema", 0);
                gvTemaDetalle.SetRowCellValue(gvTemaDetalle.FocusedRowHandle, "Archivo", Archivo);
                gvTemaDetalle.SetRowCellValue(gvTemaDetalle.FocusedRowHandle, "NombreArchivo", "");
                gvTemaDetalle.SetRowCellValue(gvTemaDetalle.FocusedRowHandle, "Extension", "");
                gvTemaDetalle.SetRowCellValue(gvTemaDetalle.FocusedRowHandle, "Descripcion", "");
                gvTemaDetalle.SetRowCellValue(gvTemaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvTemaDetalle.FocusedColumn = gvTemaDetalle.Columns["NombreArchivo"];
                gvTemaDetalle.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarTemaDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdTemaDetalle = 0;
                if (gvTemaDetalle.GetFocusedRowCellValue("IdTemaDetalle") != null)
                    IdTemaDetalle = int.Parse(gvTemaDetalle.GetFocusedRowCellValue("IdTemaDetalle").ToString());
                TemaDetalleBE objBE_TemaDetalle = new TemaDetalleBE();
                objBE_TemaDetalle.IdTemaDetalle = IdTemaDetalle;
                objBE_TemaDetalle.IdEmpresa = Parametros.intEmpresaId;
                objBE_TemaDetalle.Usuario = Parametros.strUsuarioLogin;
                objBE_TemaDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                TemaDetalleBL objBL_TemaDetalle = new TemaDetalleBL();
                objBL_TemaDetalle.Elimina(objBE_TemaDetalle);
                gvTemaDetalle.DeleteRow(gvTemaDetalle.FocusedRowHandle);
                gvTemaDetalle.RefreshData();

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

                        gvTemaDetalle.SetRowCellValue(gvTemaDetalle.FocusedRowHandle, "Archivo", Archivo);
                        gvTemaDetalle.SetRowCellValue(gvTemaDetalle.FocusedRowHandle, "NombreArchivo", strNombreArchivo);
                        gvTemaDetalle.SetRowCellValue(gvTemaDetalle.FocusedRowHandle, "Extension", strExtension);

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

        private void btnAgregaFirma1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Jpg File|*.Jpg|Jpeg File|*.Jpeg|Png File|*.Png |Gif File|*.Gif|All|*.*";
            openFile.ShowDialog();

            if (openFile.FileName.Length != 0)
            {
                this.picFirma.Image = new FuncionBase().ScaleImage(Image.FromFile(openFile.FileName), 3100, 2184);
            }
        }

        private void btnEliminarFirma1_Click(object sender, EventArgs e)
        {
            this.picFirma.Image = SSOMA.Presentacion.Properties.Resources.firma;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    TemaBL objBL_Tema = new TemaBL();
                    TemaBE objTema = new TemaBE();

                    objTema.IdEmpresa = Parametros.intEmpresaId;
                    objTema.IdTema = IdTema;
                    objTema.Periodo = Convert.ToInt32(txtPeriodo.EditValue);
                    objTema.IdCategoriaTema = Convert.ToInt32(cboCategoriaTema.EditValue);
                    objTema.IdTipoTema = Parametros.intTEMAVirtual;
                    objTema.Objetivo = txtObjetivo.Text;
                    objTema.DescTema = txtDescripcion.Text;
                    objTema.FechaIni = Convert.ToDateTime(deFechaIni.DateTime.ToShortDateString());
                    objTema.FechaFin = Convert.ToDateTime(deFechaFin.DateTime.ToShortDateString());
                    objTema.Logo = new FuncionBase().Image2Bytes(this.picImage.Image);
                    objTema.Firma1 = new FuncionBase().Image2Bytes(this.picFirma.Image);
                    objTema.Firma2 = new FuncionBase().Image2Bytes(this.picFirma2.Image);
                    objTema.IdSituacion = IdSituacion;
                    objTema.FlagEstado = true;
                    objTema.Usuario = Parametros.strUsuarioLogin;
                    objTema.Maquina = WindowsIdentity.GetCurrent().Name.ToString();


                    List<TemaDetalleBE> lstTemaDetalle = new List<TemaDetalleBE>();

                    foreach (var item in mListaTemaDetalleOrigen)
                    {
                        TemaDetalleBE objE_TemaDetalle = new TemaDetalleBE();
                        objE_TemaDetalle.IdEmpresa = item.IdEmpresa;
                        objE_TemaDetalle.IdTemaDetalle = item.IdTemaDetalle;
                        objE_TemaDetalle.IdTema = item.IdTema;
                        objE_TemaDetalle.Archivo = item.Archivo;
                        objE_TemaDetalle.NombreArchivo = item.NombreArchivo;
                        objE_TemaDetalle.Extension = item.Extension;
                        objE_TemaDetalle.Descripcion = item.Descripcion;
                        objE_TemaDetalle.TipoOper = item.TipoOper;
                        objE_TemaDetalle.FlagEstado = true;
                        objE_TemaDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_TemaDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_TemaDetalle.TipoOper = item.TipoOper;
                        lstTemaDetalle.Add(objE_TemaDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Tema.Inserta(objTema, lstTemaDetalle);
                    else
                        objBL_Tema.Actualiza(objTema, lstTemaDetalle);

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

        private void CargaTemaDetalle()
        {
            List<TemaDetalleBE> lstTmpTemaDetalle = null;
            lstTmpTemaDetalle = new TemaDetalleBL().ListaTodosActivo(IdTema);

            foreach (TemaDetalleBE item in lstTmpTemaDetalle)
            {
                CTemaDetalle objE_TemaDetalle = new CTemaDetalle();
                objE_TemaDetalle.IdEmpresa = item.IdEmpresa;
                objE_TemaDetalle.IdTemaDetalle = item.IdTemaDetalle;
                objE_TemaDetalle.IdTema = item.IdTema;
                objE_TemaDetalle.Archivo = item.Archivo;
                objE_TemaDetalle.NombreArchivo = item.NombreArchivo;
                objE_TemaDetalle.Extension = item.Extension;
                objE_TemaDetalle.Descripcion = item.Descripcion;
                objE_TemaDetalle.TipoOper = item.TipoOper;
                mListaTemaDetalleOrigen.Add(objE_TemaDetalle);
            }

            bsListadoTemaDetalle.DataSource = mListaTemaDetalleOrigen;
            gcTemaDetalle.DataSource = bsListadoTemaDetalle;
            gcTemaDetalle.RefreshDataSource();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";
            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstTema.Where(oB => oB.DescTema.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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

        #endregion

        public class CTemaDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdTema { get; set; }
            public Int32 IdTemaDetalle { get; set; }
            public byte[] Archivo { get; set; }
            public string NombreArchivo { get; set; }
            public string Extension { get; set; }
            public string Descripcion { get; set; }
            public Int32 TipoOper { get; set; }

            public CTemaDetalle()
            {

            }
        }

        
    }
}