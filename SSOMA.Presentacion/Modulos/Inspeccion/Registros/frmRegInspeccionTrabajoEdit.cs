using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.IO;
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
using CrystalDecisions.Shared;
using SSOMA.BusinessLogic;
using SSOMA.BusinessEntity;
using SSOMA.Presentacion.Modulos.Otros;
using SSOMA.Presentacion.Modulos.Inspeccion.Rpt;


namespace SSOMA.Presentacion.Modulos.Inspeccion.Registros
{
    public partial class frmRegInspeccionTrabajoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<InspeccionTrabajoBE> lstInspeccionTrabajo;
        public List<CInspeccionTrabajoDetalle> mListaInspeccionTrabajoDetalleOrigen = new List<CInspeccionTrabajoDetalle>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdInspeccionTrabajo = 0;

        public int IdInspeccionTrabajo
        {
            get { return _IdInspeccionTrabajo; }
            set { _IdInspeccionTrabajo = value; }
        }

        int intIdInspeccionadoPor = 0;
        int intIdResponsableSector = 0;
        int intIdResponsableAdicional1 = 0;
        int intIdResponsableAdicional2 = 0;

        string strMailAreaResponsable = "";
        string strMailSectorResponsable = "";
        string strMailResponsableAdicional1 = "";
        string strMailResponsableAdicional2 = "";

        #endregion

        #region "Eventos"

        public frmRegInspeccionTrabajoEdit()
        {
            InitializeComponent();
            gcFechaEjecucion.Caption = "Fecha \n Ejecución";
        }

        private void frmRegInspeccionTrabajoEdit_Load(object sender, EventArgs e)
        {
            deFecha.DateTime = DateTime.Now;
            teHora.EditValue = DateTime.Now.ToLongTimeString();
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            BSUtils.LoaderLook(cboEmpresaContratista, new EmpresaBL().ListaCombo(Parametros.intTEContratista), "RazonSocial", "IdEmpresa", true);
            cboEmpresaContratista.EditValue = Parametros.intEmpresaContratistaNinguno;
            BSUtils.LoaderLook(cboTipoInspeccion, new TipoInspeccionBL().ListaTodosActivo(0), "DescTipoInspeccion", "IdTipoInspeccion", true);

            intIdInspeccionadoPor = Parametros.intPersonaId;
            txtInspeccionadoPor.Text = Parametros.strUsuarioNombres;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Inspección de Trabajo - Nuevo";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Inspección de Trabajo - Modificar";

                InspeccionTrabajoBE objE_InspeccionTrabajo = null;
                objE_InspeccionTrabajo = new InspeccionTrabajoBL().Selecciona(IdInspeccionTrabajo);

                IdInspeccionTrabajo = objE_InspeccionTrabajo.IdInspeccionTrabajo;
                txtNumero.Text = objE_InspeccionTrabajo.Numero;
                deFecha.EditValue = objE_InspeccionTrabajo.Fecha;
                teHora.EditValue = objE_InspeccionTrabajo.Hora;
                txtNumeroTrabajadores.EditValue = objE_InspeccionTrabajo.NumeroTrabajadores;
                cboTipoInspeccion.EditValue = objE_InspeccionTrabajo.IdTipoInspeccion;
                txtObjetivo.Text = objE_InspeccionTrabajo.Objetivo;
                cboEmpresa.EditValue = objE_InspeccionTrabajo.IdEmpresa;
                cboUnidadMinera.EditValue = objE_InspeccionTrabajo.IdUnidadMinera;
                cboAreaResponsable.EditValue = objE_InspeccionTrabajo.IdArea;
                cboSector.EditValue = objE_InspeccionTrabajo.IdSector;
                txtLugar.Text = objE_InspeccionTrabajo.Lugar;
                cboEmpresaContratista.EditValue = objE_InspeccionTrabajo.IdEmpresaContratista;
                intIdInspeccionadoPor = objE_InspeccionTrabajo.IdInspeccionadoPor;
                txtInspeccionadoPor.Text = objE_InspeccionTrabajo.InspeccionadoPor;
                strMailAreaResponsable = objE_InspeccionTrabajo.MailAreaResponsable;
                intIdResponsableSector = Convert.ToInt32(objE_InspeccionTrabajo.IdResponsableSector);
                txtResponsableSector.Text = objE_InspeccionTrabajo.ResponsableSector;
                strMailSectorResponsable = objE_InspeccionTrabajo.MailSectorResponsable;
                txtPersonaRegistro.Text = objE_InspeccionTrabajo.PersonaRegistro;
                txtPersonaCargo.Text = objE_InspeccionTrabajo.PersonaCargo;
            }

            CargaInspeccionTrabajoDetalle();
            deFecha.Select();
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
                BSUtils.LoaderLook(cboAreaResponsable, new AreaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboUnidadMinera.EditValue)), "DescArea", "IdArea", true);
            }
            
        }

        private void cboAreaResponsable_EditValueChanged(object sender, EventArgs e)
        {
            if (cboAreaResponsable.EditValue != null)
            {
                BSUtils.LoaderLook(cboSector, new SectorBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboUnidadMinera.EditValue), Convert.ToInt32(cboAreaResponsable.EditValue)), "DescSector", "IdSector", true);
            }
        }

        private void btnBuscarInspeccionado_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = true;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    intIdInspeccionadoPor = frm.pPersonaBE.IdPersona;
                    txtInspeccionadoPor.Text = frm.pPersonaBE.ApeNom;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnBuscarResponsableSector_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = true;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    intIdResponsableSector = frm.pPersonaBE.IdPersona;
                    txtResponsableSector.Text = frm.pPersonaBE.ApeNom;
                    strMailSectorResponsable = frm.pPersonaBE.Email;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscaResponsableAdicional1_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = true;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    intIdResponsableAdicional1 = frm.pPersonaBE.IdPersona;
                    txtResponsableAdicional1.Text = frm.pPersonaBE.ApeNom;
                    strMailResponsableAdicional1 = frm.pPersonaBE.Email;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscaResponsableAdicional2_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = true;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    intIdResponsableAdicional2 = frm.pPersonaBE.IdPersona;
                    txtResponsableAdicional2.Text = frm.pPersonaBE.ApeNom;
                    strMailResponsableAdicional2 = frm.pPersonaBE.Email;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarRegistradoPor_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = true;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    txtPersonaRegistro.Text = frm.pPersonaBE.ApeNom;
                    txtPersonaCargo.Text = frm.pPersonaBE.Cargo;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                picImage.Image = SSOMA.Presentacion.Properties.Resources.noImage;

                int i = 0;
                if (mListaInspeccionTrabajoDetalleOrigen.Count > 0)
                    i = mListaInspeccionTrabajoDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));

                gvInspeccionTrabajoDetalle.AddNewRow();
                gvInspeccionTrabajoDetalle.SetRowCellValue(gvInspeccionTrabajoDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                gvInspeccionTrabajoDetalle.SetRowCellValue(gvInspeccionTrabajoDetalle.FocusedRowHandle, "IdInspeccionTrabajo", 0);
                gvInspeccionTrabajoDetalle.SetRowCellValue(gvInspeccionTrabajoDetalle.FocusedRowHandle, "IdInspeccionTrabajoDetalle", 0);
                gvInspeccionTrabajoDetalle.SetRowCellValue(gvInspeccionTrabajoDetalle.FocusedRowHandle, "Item", Convert.ToInt32(i) + 1);
                gvInspeccionTrabajoDetalle.SetRowCellValue(gvInspeccionTrabajoDetalle.FocusedRowHandle, "Foto", new FuncionBase().Image2Bytes(this.picImage.Image));
                gvInspeccionTrabajoDetalle.SetRowCellValue(gvInspeccionTrabajoDetalle.FocusedRowHandle, "CondicionSubEstandar", "");
                gvInspeccionTrabajoDetalle.SetRowCellValue(gvInspeccionTrabajoDetalle.FocusedRowHandle, "AccionCorrectiva", "");
                gvInspeccionTrabajoDetalle.SetRowCellValue(gvInspeccionTrabajoDetalle.FocusedRowHandle, "IdResponsable", 0);
                gvInspeccionTrabajoDetalle.SetRowCellValue(gvInspeccionTrabajoDetalle.FocusedRowHandle, "Responsable", "");
                gvInspeccionTrabajoDetalle.SetRowCellValue(gvInspeccionTrabajoDetalle.FocusedRowHandle, "FechaEjecucion", deFecha.DateTime.AddDays(15).ToShortDateString());
                gvInspeccionTrabajoDetalle.SetRowCellValue(gvInspeccionTrabajoDetalle.FocusedRowHandle, "FotoCumplimiento", new FuncionBase().Image2Bytes(this.picImage.Image));
                gvInspeccionTrabajoDetalle.SetRowCellValue(gvInspeccionTrabajoDetalle.FocusedRowHandle, "Observacion", "");
                gvInspeccionTrabajoDetalle.SetRowCellValue(gvInspeccionTrabajoDetalle.FocusedRowHandle, "IdSituacion", Parametros.intDITPendiente);
                gvInspeccionTrabajoDetalle.SetRowCellValue(gvInspeccionTrabajoDetalle.FocusedRowHandle, "DescSituacion", "PENDIENTE");
                gvInspeccionTrabajoDetalle.SetRowCellValue(gvInspeccionTrabajoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvInspeccionTrabajoDetalle.FocusedColumn = gvInspeccionTrabajoDetalle.Columns["Lugar"];
                gvInspeccionTrabajoDetalle.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdInspeccionTrabajoDetalle = 0;
                if (gvInspeccionTrabajoDetalle.GetFocusedRowCellValue("IdInspeccionTrabajoDetalle") != null)
                    IdInspeccionTrabajoDetalle = int.Parse(gvInspeccionTrabajoDetalle.GetFocusedRowCellValue("IdInspeccionTrabajoDetalle").ToString());
                InspeccionTrabajoDetalleBE objBE_InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleBE();
                objBE_InspeccionTrabajoDetalle.IdInspeccionTrabajoDetalle = IdInspeccionTrabajoDetalle;
                objBE_InspeccionTrabajoDetalle.IdEmpresa = Parametros.intEmpresaId;
                objBE_InspeccionTrabajoDetalle.Usuario = Parametros.strUsuarioLogin;
                objBE_InspeccionTrabajoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                InspeccionTrabajoDetalleBL objBL_InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleBL();
                objBL_InspeccionTrabajoDetalle.Elimina(objBE_InspeccionTrabajoDetalle);
                gvInspeccionTrabajoDetalle.DeleteRow(gvInspeccionTrabajoDetalle.FocusedRowHandle);
                gvInspeccionTrabajoDetalle.RefreshData();

                picImage.Image = SSOMA.Presentacion.Properties.Resources.noImage;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvInspeccionTrabajoDetalle.RowCount > 0)
                {
                    string strMailTO = "";
                    strMailTO = strMailSectorResponsable;

                    int intIdResponsable = int.Parse(gvInspeccionTrabajoDetalle.GetFocusedRowCellValue("IdResponsable").ToString());
                    
                    PersonaBE objE_Persona = new PersonaBE();
                    objE_Persona = new PersonaBL().Selecciona(0, 0, 0, intIdResponsable);
                    if (objE_Persona != null)
                    {
                        strMailTO = strMailTO + ";" + objE_Persona.Email;
                    }
                    
                    int intInspeccionTrabajoDetalle = int.Parse(gvInspeccionTrabajoDetalle.GetFocusedRowCellValue("IdInspeccionTrabajoDetalle").ToString());
                    int intItem = int.Parse(gvInspeccionTrabajoDetalle.GetFocusedRowCellValue("Item").ToString());
                    
                    frmActualizaInspeccionDetalle objInspeccionDetalle = new frmActualizaInspeccionDetalle();
                    objInspeccionDetalle.IdInspeccionTrabajoDetalle = intInspeccionTrabajoDetalle;
                    objInspeccionDetalle.Item = intItem;
                    objInspeccionDetalle.Numero = txtNumero.Text;
                    objInspeccionDetalle.strMailTO = strMailTO;
                    objInspeccionDetalle.StartPosition = FormStartPosition.CenterScreen;
                    objInspeccionDetalle.ShowDialog();
                    CargaInspeccionTrabajoDetalle();


                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtResponsable_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBusPersona frm = new frmBusPersona();
                    frm.pFlagTodoPersonal = true;
                    frm.pFlagMultiSelect = false;
                    frm.ShowDialog();
                    if (frm.pPersonaBE != null)
                    {
                        int index = gvInspeccionTrabajoDetalle.FocusedRowHandle;
                        gvInspeccionTrabajoDetalle.SetRowCellValue(index, "IdResponsable", frm.pPersonaBE.IdPersona);
                        gvInspeccionTrabajoDetalle.SetRowCellValue(index, "Responsable", frm.pPersonaBE.ApeNom);

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvInspeccionTrabajoDetalle_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvInspeccionTrabajoDetalle_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "DescSituacion")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["DescSituacion"]);
                        if (Situacion == "PENDIENTE")
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "PROCESO")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "EJECUTADO")
                        {
                            e.Appearance.BackColor = Color.Green;
                            e.Appearance.ForeColor = Color.Black;
                        }

                    }
                }
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
                    InspeccionTrabajoBE objInspeccionTrabajo = new InspeccionTrabajoBE();
                    InspeccionTrabajoBL objBL_InspeccionTrabajo = new InspeccionTrabajoBL();

                    objInspeccionTrabajo.IdInspeccionTrabajo = IdInspeccionTrabajo;
                    objInspeccionTrabajo.IdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
                    objInspeccionTrabajo.IdArea = Convert.ToInt32(cboAreaResponsable.EditValue);
                    objInspeccionTrabajo.IdSector = Convert.ToInt32(cboSector.EditValue);
                    objInspeccionTrabajo.IdTipoInspeccion = Convert.ToInt32(cboTipoInspeccion.EditValue);
                    objInspeccionTrabajo.Numero = txtNumero.Text;
                    objInspeccionTrabajo.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objInspeccionTrabajo.Hora = Convert.ToDateTime(teHora.EditValue);
                    objInspeccionTrabajo.Objetivo = txtObjetivo.Text;
                    objInspeccionTrabajo.Lugar = txtLugar.Text;
                    objInspeccionTrabajo.IdEmpresaContratista = Convert.ToInt32(cboEmpresaContratista.EditValue);
                    objInspeccionTrabajo.IdInspeccionadoPor = intIdInspeccionadoPor;
                    objInspeccionTrabajo.IdResponsableArea = (int?)null;
                    objInspeccionTrabajo.IdResponsableSector = intIdResponsableSector == 0 ? (int?)null : intIdResponsableSector;
                    objInspeccionTrabajo.NumeroTrabajadores = Convert.ToInt32(txtNumeroTrabajadores.Text);
                    objInspeccionTrabajo.PersonaRegistro = txtPersonaRegistro.Text;
                    objInspeccionTrabajo.PersonaCargo = txtPersonaCargo.Text;
                    objInspeccionTrabajo.FlagEstado = true;
                    objInspeccionTrabajo.Usuario = Parametros.strUsuarioLogin;
                    objInspeccionTrabajo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objInspeccionTrabajo.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                    //INSPECCION TRABAJO DETALLE
                    List<InspeccionTrabajoDetalleBE> lstInspeccionTrabajoDetalle = new List<InspeccionTrabajoDetalleBE>();

                    foreach (var item in mListaInspeccionTrabajoDetalleOrigen)
                    {
                        InspeccionTrabajoDetalleBE objE_InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleBE();
                        objE_InspeccionTrabajoDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objE_InspeccionTrabajoDetalle.IdInspeccionTrabajo = IdInspeccionTrabajo;
                        objE_InspeccionTrabajoDetalle.IdInspeccionTrabajoDetalle = item.IdInspeccionTrabajoDetalle;
                        objE_InspeccionTrabajoDetalle.Item = item.Item;
                        objE_InspeccionTrabajoDetalle.Foto = item.Foto;
                        objE_InspeccionTrabajoDetalle.CondicionSubEstandar = item.CondicionSubEstandar;
                        objE_InspeccionTrabajoDetalle.AccionCorrectiva = item.AccionCorrectiva;
                        objE_InspeccionTrabajoDetalle.IdResponsable = item.IdResponsable;
                        objE_InspeccionTrabajoDetalle.FechaEjecucion = (item.FechaEjecucion.ToString().Length == 0) ? null : item.FechaEjecucion;
                        objE_InspeccionTrabajoDetalle.FotoCumplimiento = item.FotoCumplimiento;
                        objE_InspeccionTrabajoDetalle.Observacion = item.Observacion;
                        objE_InspeccionTrabajoDetalle.IdSituacion = item.IdSituacion;
                        objE_InspeccionTrabajoDetalle.FlagEstado = true;
                        objE_InspeccionTrabajoDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_InspeccionTrabajoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_InspeccionTrabajoDetalle.TipoOper = item.TipoOper;
                        lstInspeccionTrabajoDetalle.Add(objE_InspeccionTrabajoDetalle);
                    }

                    
                    if (pOperacion == Operacion.Nuevo)
                    {
                        int intNumero = 0;
                        string strNumero = "";
                        intNumero = objBL_InspeccionTrabajo.Inserta(objInspeccionTrabajo, lstInspeccionTrabajoDetalle);
                        strNumero = FuncionBase.AgregarCaracter(intNumero.ToString(), "0", 7);
                        txtNumero.Text = strNumero;

                        //ACTUALIZAR NUMERO
                        InspeccionTrabajoBL objBInspeccionTrabajo = new InspeccionTrabajoBL();
                        objBInspeccionTrabajo.ActualizaNumero(intNumero, txtNumero.Text);

                        //ELIMINAMOS LOR ARCHIVOS CREADOS
                        foreach (var item in Directory.GetFiles(@"D:\", "*.pdf"))
                        {
                            File.SetAttributes(item, FileAttributes.Normal);
                            File.Delete(item);
                        }

                        //GENERAR EL REPORTE EN PDF
                        List<ReporteInspeccionTrabajoBE> lstReporteInspeccion = null;
                        lstReporteInspeccion = new ReporteInspeccionTrabajoBL().Listado(intNumero);
                        rptInspeccionTrabajo objReporte = new rptInspeccionTrabajo();
                        objReporte.SetDataSource(lstReporteInspeccion);
                        objReporte.ExportToDisk(ExportFormatType.PortableDocFormat,  @"D:\" + strNumero + ".pdf");

                        StringBuilder strMensaje = new StringBuilder();
                        strMensaje.Append("*****************************************************************************\n\n");
                        strMensaje.Append("Se Generó la N° Condición Insegura : " + strNumero + "\n\n");
                        strMensaje.Append("Regularizar de acuerdo a las fechas descritas en el archivo adjunto" + "\n\n");
                        strMensaje.Append("Emitido Por el Area de Seguridad y Salud en el Trabajo" + "\n\n");
                        strMensaje.Append("*****************************************************************************\n\n");

                        string strMailTO = "";
                        strMailTO = strMailSectorResponsable;

                        if (intIdResponsableAdicional1 > 0)
                        {
                            strMailTO = strMailTO + ";" + strMailResponsableAdicional1;
                        }

                        if (intIdResponsableAdicional2 > 0)
                        {
                            strMailTO = strMailTO + ";" + strMailResponsableAdicional2;
                        }

                        foreach (var item in mListaInspeccionTrabajoDetalleOrigen)
                        {
                            PersonaBE objE_Persona = new PersonaBE();
                            objE_Persona = new PersonaBL().Selecciona(0, 0, 0,item.IdResponsable);
                            if (objE_Persona != null)
                            {
                                strMailTO = strMailTO + ";" + objE_Persona.Email;
                            }
                        }

                        if (Convert.ToInt32(cboEmpresaContratista.EditValue) != Parametros.intEmpresaContratistaNinguno)
                        {
                            ActividadContratistaBE objE_ActividadContratista = new ActividadContratistaBE();
                            objE_ActividadContratista = new ActividadContratistaBL().SeleccionaEmpresa(Convert.ToInt32(cboEmpresaContratista.EditValue));
                            if (objE_ActividadContratista != null)
                            {
                                strMailTO = strMailTO + ";" + objE_ActividadContratista.EmailContratista;
                            }
                        }

                        BSUtils.EmailSend(strMailTO, "Inspección Interna de Trabajo", strMensaje.ToString(), @"D:\" + strNumero + ".pdf","", "", "");

                        Application.DoEvents();

                        XtraMessageBox.Show("Se creó el registro de Inspeccion N° : " + txtNumero.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        objBL_InspeccionTrabajo.Actualiza(objInspeccionTrabajo, lstInspeccionTrabajoDetalle);
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

            if (txtNumeroTrabajadores.Text == "")
            {
                strMensaje = strMensaje + "- Debe ingresar el numero de trabajadores.\n";
                flag = true;
            }

            if (intIdInspeccionadoPor == 0)
            {
                strMensaje = strMensaje + "- Debe seleccionar a un inspector.\n";
                flag = true;
            }

           
            if (txtPersonaRegistro.Text == "")
            {
                strMensaje = strMensaje + "- Debe selecionar a la persona quien registra la inspección.\n";
                flag = true;
            }

            if (gvInspeccionTrabajoDetalle.DataRowCount > 0)
            {
                for (int i = 0; i < gvInspeccionTrabajoDetalle.DataRowCount; i++)
                {

                    if (int.Parse(gvInspeccionTrabajoDetalle.GetRowCellValue(i, "IdResponsable").ToString()) == 0)
                    {
                        strMensaje = strMensaje + "- Debe seleccionar un responsable.\n";
                        flag = true;
                    }
                }
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();

                if (gvInspeccionTrabajoDetalle.RowCount > 0)
                {
                    OpenFileDialog openFile = new OpenFileDialog();
                    openFile.Filter = "Jpg File|*.Jpg|Jpeg File|*.Jpeg|Png File|*.Png |Gif File|*.Gif|All|*.*";
                    openFile.ShowDialog();

                    if (openFile.FileName.Length != 0)
                    {
                        this.picImage.Image = new FuncionBase().ScaleImage(Image.FromFile(openFile.FileName), 640, 500);
                    }

                    if (colCaption == "Foto")
                    {
                        gvInspeccionTrabajoDetalle.SetRowCellValue(gvInspeccionTrabajoDetalle.FocusedRowHandle, "Foto", new FuncionBase().Image2Bytes(this.picImage.Image));
                    }

                    if (colCaption == "Foto Cumplimiento")
                    {
                        gvInspeccionTrabajoDetalle.SetRowCellValue(gvInspeccionTrabajoDetalle.FocusedRowHandle, "FotoCumplimiento", new FuncionBase().Image2Bytes(this.picImage.Image));
                    }

                }
            }
        }

        private void CargaInspeccionTrabajoDetalle()
        {
            List<InspeccionTrabajoDetalleBE> lstTmpInspeccionTrabajoDetalle = null;
            lstTmpInspeccionTrabajoDetalle = new InspeccionTrabajoDetalleBL().ListaTodosActivo(IdInspeccionTrabajo);

            mListaInspeccionTrabajoDetalleOrigen.Clear();

            foreach (InspeccionTrabajoDetalleBE item in lstTmpInspeccionTrabajoDetalle)
            {
                CInspeccionTrabajoDetalle objE_InspeccionTrabajoDetalle = new CInspeccionTrabajoDetalle();
                objE_InspeccionTrabajoDetalle.IdEmpresa = item.IdEmpresa;
                objE_InspeccionTrabajoDetalle.IdInspeccionTrabajo = item.IdInspeccionTrabajo;
                objE_InspeccionTrabajoDetalle.IdInspeccionTrabajoDetalle = item.IdInspeccionTrabajoDetalle;
                objE_InspeccionTrabajoDetalle.Item = item.Item;
                objE_InspeccionTrabajoDetalle.Foto = item.Foto;
                objE_InspeccionTrabajoDetalle.CondicionSubEstandar = item.CondicionSubEstandar;
                objE_InspeccionTrabajoDetalle.AccionCorrectiva = item.AccionCorrectiva;
                objE_InspeccionTrabajoDetalle.IdResponsable= item.IdResponsable;
                objE_InspeccionTrabajoDetalle.Responsable = item.Responsable;
                objE_InspeccionTrabajoDetalle.FechaEjecucion = item.FechaEjecucion;
                objE_InspeccionTrabajoDetalle.FotoCumplimiento = item.FotoCumplimiento;
                objE_InspeccionTrabajoDetalle.Observacion = item.Observacion;
                objE_InspeccionTrabajoDetalle.IdSituacion = item.IdSituacion;
                objE_InspeccionTrabajoDetalle.DescSituacion = item.DescSituacion;
                objE_InspeccionTrabajoDetalle.TipoOper = item.TipoOper;
                mListaInspeccionTrabajoDetalleOrigen.Add(objE_InspeccionTrabajoDetalle);
            }

            bsListado.DataSource = mListaInspeccionTrabajoDetalleOrigen;
            gcInspeccionTrabajoDetalle.DataSource = bsListado;
            gcInspeccionTrabajoDetalle.RefreshDataSource();
        }

        
        #endregion

        public class CInspeccionTrabajoDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdInspeccionTrabajo { get; set; }
            public Int32 IdInspeccionTrabajoDetalle { get; set; }
            public Int32 Item { get; set; }
            public byte[] Foto { get; set; }
            public string CondicionSubEstandar { get; set; }
            public string AccionCorrectiva { get; set; }
            public Int32 IdResponsable { get; set; }
            public string Responsable { get; set; }
            public DateTime? FechaEjecucion { get; set; }
            public byte[] FotoCumplimiento { get; set; }
            public string Observacion { get; set; }
            public Int32 IdSituacion { get; set; }
            public string DescSituacion { get; set; }
            public Int32 TipoOper { get; set; }

            public CInspeccionTrabajoDetalle()
            {

            }
        }

        
    }
}