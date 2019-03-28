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

namespace SSOMA.Presentacion.Modulos.Capacitacion.Registros
{
    public partial class frmRegCapacitacionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CapacitacionBE> lstCapacitacion;
        public List<CCapacitacionDetalle> mListaCapacitacionDetalleOrigen = new List<CCapacitacionDetalle>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdCapacitacion = 0;

        public int IdCapacitacion
        {
            get { return _IdCapacitacion; }
            set { _IdCapacitacion = value; }
        }

        int intParticipantes = 0;
        
        #endregion

        #region "Eventos"

        public frmRegCapacitacionEdit()
        {
            InitializeComponent();
        }

        private void frmRegCapacitacionEdit_Load(object sender, EventArgs e)
        {
            deFecha.DateTime = DateTime.Now;
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            teHoraInicio.EditValue = DateTime.Now.ToLongTimeString();
            teHoraFin.EditValue = DateTime.Now.ToLongTimeString();
            BSUtils.LoaderLook(cboProveedor, new EmpresaBL().ListaCombo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboTipo, new TipoCapacitacionBL().ListaCombo(Parametros.intEmpresaId), "DescTipoCapacitacion", "IdTipoCapacitacion", true);
            BSUtils.LoaderLook(cboClasificacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblClasificacionCapacitacion), "DescTablaElemento", "IdTablaElemento", true);
            cboClasificacion.EditValue = Parametros.intCCSeguridadIndustrial;
            BSUtils.LoaderLook(cboTema, new TemaBL().ListaCombo(Parametros.intEmpresaId, Parametros.intTEMAPresencial, Parametros.intPeriodo), "DescTema", "IdTema", true);
            BSUtils.LoaderLook(cboLugar, new LugarBL().ListaCombo(Parametros.intEmpresaId), "DescLugar", "IdLugar", true);
            BSUtils.LoaderLook(cboExpositor, new ExpositorBL().ListaCombo(Parametros.intEmpresaId), "DescExpositor", "IdExpositor", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Capacitación - Nuevo";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Capacitación - Modificar";

                CapacitacionBE objE_Capacitacion = null;
                objE_Capacitacion = new CapacitacionBL().Selecciona(IdCapacitacion);
                if (objE_Capacitacion != null)
                {
                    IdCapacitacion = objE_Capacitacion.IdCapacitacion;
                    txtNumero.Text = objE_Capacitacion.Numero;
                    cboEmpresa.EditValue = objE_Capacitacion.IdEmpresa;
                    cboUnidadMinera.EditValue = objE_Capacitacion.IdUnidadMinera;
                    cboProveedor.EditValue = objE_Capacitacion.IdProveedor;
                    deFecha.EditValue = objE_Capacitacion.Fecha;
                    teHoraInicio.EditValue = objE_Capacitacion.FechaIni;
                    teHoraFin.EditValue = objE_Capacitacion.FechaFin;
                    txtNumeroParticpantes.EditValue = objE_Capacitacion.Participantes;
                    cboTipo.EditValue = objE_Capacitacion.IdTipoCapacitacion;
                    cboClasificacion.EditValue = objE_Capacitacion.IdClasificacionCapacitacion;
                    cboTema.EditValue = objE_Capacitacion.IdTema;
                    cboLugar.EditValue = objE_Capacitacion.IdLugar;
                    cboExpositor.EditValue = objE_Capacitacion.IdExpositor;

                }
                
            }

            CargaCapacitacionDetalle();
            deFecha.Select();
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
                cboProveedor.EditValue = cboEmpresa.EditValue;
            }
        }

        private void cboUnidadMinera_EditValueChanged(object sender, EventArgs e)
        {
            if (cboUnidadMinera.EditValue != null)
            {
                BSUtils.LoaderLook(cboTema, new PlanAnualBL().ListaTema(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboUnidadMinera.EditValue), deFecha.DateTime.Year), "DescTema", "IdTema", true);
            }
        }
        private void gcTxtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string strDni = "";
                    strDni = (sender as TextEdit).Text;
                    PersonaBE objE_Persona = null;
                    objE_Persona = new PersonaBL().SeleccionaNumeroDocumento(0,strDni);
                    if (objE_Persona != null)
                    {
                        int index = gvCapacitacionDetalle.FocusedRowHandle;
                        gvCapacitacionDetalle.SetRowCellValue(index, "IdPersona", objE_Persona.IdPersona);
                        gvCapacitacionDetalle.SetRowCellValue(index, "Codigo", objE_Persona.Dni);
                        gvCapacitacionDetalle.SetRowCellValue(index, "ApeNom", objE_Persona.ApeNom);
                        gvCapacitacionDetalle.SetRowCellValue(index, "DescArea", objE_Persona.DescArea);
                        gvCapacitacionDetalle.SetRowCellValue(index, "Nota", 0);

                        int i = 0;
                        if (mListaCapacitacionDetalleOrigen.Count > 0)
                            i = mListaCapacitacionDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));

                        gvCapacitacionDetalle.AddNewRow();
                        gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                        gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "IdCapacitacion", 0);
                        gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "IdCapacitacionDetalle", 0);
                        gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "Item", Convert.ToInt32(i) + 1);
                        gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "IdPersona", 0);
                        gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "Codigo", "");
                        gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "ApeNom", "");
                        gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "DescArea", "");
                        gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "Nota", 0);
                        gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                        gcCapacitacionDetalle.Select();
                        gvCapacitacionDetalle.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle;
                        gvCapacitacionDetalle.FocusedColumn = gvCapacitacionDetalle.VisibleColumns[0];
                        gvCapacitacionDetalle.ShowEditor();
                    }
                    else
                    {
                        XtraMessageBox.Show("Registro no encontrado. \n Por Favor Verique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (e.KeyCode == Keys.F1)
                {
                    frmBusPersona frm = new frmBusPersona();
                    frm.pFlagTodoPersonal = false;
                    frm.pFlagMultiSelect = false;
                    frm.ShowDialog();
                    if (frm.pPersonaBE != null)
                    {
                        int index = gvCapacitacionDetalle.FocusedRowHandle;

                        var Buscar = mListaCapacitacionDetalleOrigen.Where(oB => oB.IdPersona == frm.pPersonaBE.IdPersona).ToList();
                        if (Buscar.Count > 0)
                        {
                            XtraMessageBox.Show("No se puede repetir el trabajador \n Por Favor Verique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        gvCapacitacionDetalle.SetRowCellValue(index, "IdPersona", frm.pPersonaBE.IdPersona);
                        gvCapacitacionDetalle.SetRowCellValue(index, "Codigo", frm.pPersonaBE.Dni);
                        gvCapacitacionDetalle.SetRowCellValue(index, "ApeNom", frm.pPersonaBE.ApeNom);
                        gvCapacitacionDetalle.SetRowCellValue(index, "DescArea", frm.pPersonaBE.DescArea);
                        gvCapacitacionDetalle.SetRowCellValue(index, "Nota", 0);
                    }
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
                int i = 0;
                if (mListaCapacitacionDetalleOrigen.Count > 0)
                    i = mListaCapacitacionDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));

                gvCapacitacionDetalle.AddNewRow();
                gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "IdCapacitacion", 0);
                gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "IdCapacitacionDetalle", 0);
                gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "Item", Convert.ToInt32(i) + 1);
                gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "IdPersona", 0);
                gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "Codigo", "");
                gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "ApeNom", "");
                gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "DescArea", "");
                gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "Nota", 0);
                gvCapacitacionDetalle.SetRowCellValue(gvCapacitacionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvCapacitacionDetalle.FocusedColumn = gvCapacitacionDetalle.Columns["Codigo"];
                gvCapacitacionDetalle.ShowEditor();
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
                if (mListaCapacitacionDetalleOrigen.Count > 0)
                {
                    int IdCapacitacionDetalle = 0;
                    if (gvCapacitacionDetalle.GetFocusedRowCellValue("IdCapacitacionDetalle") != null)
                        IdCapacitacionDetalle = int.Parse(gvCapacitacionDetalle.GetFocusedRowCellValue("IdCapacitacionDetalle").ToString());
                    CapacitacionDetalleBE objBE_CapacitacionDetalle = new CapacitacionDetalleBE();
                    objBE_CapacitacionDetalle.IdCapacitacionDetalle = IdCapacitacionDetalle;
                    objBE_CapacitacionDetalle.IdEmpresa = Parametros.intEmpresaId;
                    objBE_CapacitacionDetalle.Usuario = Parametros.strUsuarioLogin;
                    objBE_CapacitacionDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    CapatacitacionDetalleBL objBL_CapacitacionDetalle = new CapatacitacionDetalleBL();
                    objBL_CapacitacionDetalle.Elimina(objBE_CapacitacionDetalle);
                    gvCapacitacionDetalle.DeleteRow(gvCapacitacionDetalle.FocusedRowHandle);
                    gvCapacitacionDetalle.RefreshData();

                    txtNumeroParticpantes.EditValue = Convert.ToInt32(txtNumeroParticpantes.EditValue) - 1;
                }
                

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               
                List<PersonaBE> lstPersona = null;
                lstPersona = new PersonaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboUnidadMinera.EditValue),0);

                int intItem = 1;
                mListaCapacitacionDetalleOrigen.Clear();

                foreach (PersonaBE item in lstPersona)
                {
                    CCapacitacionDetalle objE_CapacitacionDetalle = new CCapacitacionDetalle();
                    objE_CapacitacionDetalle.IdEmpresa = item.IdEmpresa;
                    objE_CapacitacionDetalle.IdCapacitacion = 0;
                    objE_CapacitacionDetalle.IdCapacitacionDetalle = 0;
                    objE_CapacitacionDetalle.Item = intItem;
                    objE_CapacitacionDetalle.IdPersona = item.IdPersona;
                    objE_CapacitacionDetalle.Codigo = item.Dni;
                    objE_CapacitacionDetalle.ApeNom = item.ApeNom;
                    objE_CapacitacionDetalle.DescArea = item.DescArea;
                    objE_CapacitacionDetalle.Nota = 0;
                    objE_CapacitacionDetalle.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                    mListaCapacitacionDetalleOrigen.Add(objE_CapacitacionDetalle);

                    intItem++;
                }

                bsListado.DataSource = mListaCapacitacionDetalleOrigen;
                gcCapacitacionDetalle.DataSource = bsListado;
                gcCapacitacionDetalle.RefreshDataSource();
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroCapacitacion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    CapacitacionBE objE_Capacitacion = null;
                    objE_Capacitacion = new CapacitacionBL().SeleccionaNumero(Convert.ToInt32(txtNumeroCapacitacion.Text));
                    if (objE_Capacitacion != null)
                    {
                        IdCapacitacion = objE_Capacitacion.IdCapacitacion;
                        cboEmpresa.EditValue = objE_Capacitacion.IdEmpresa;
                        cboUnidadMinera.EditValue = objE_Capacitacion.IdUnidadMinera;
                        cboProveedor.EditValue = objE_Capacitacion.IdProveedor;
                        deFecha.EditValue = objE_Capacitacion.Fecha;
                        txtNumeroParticpantes.EditValue = objE_Capacitacion.Participantes;
                        cboTipo.EditValue = objE_Capacitacion.IdTipoCapacitacion;
                        cboClasificacion.EditValue = objE_Capacitacion.IdClasificacionCapacitacion;
                        cboTema.EditValue = objE_Capacitacion.IdTema;
                        cboLugar.EditValue = objE_Capacitacion.IdLugar;
                        cboExpositor.EditValue = objE_Capacitacion.IdExpositor;

                        List<CapacitacionDetalleBE> lstTmpCapacitacionDetalle = null;
                        lstTmpCapacitacionDetalle = new CapatacitacionDetalleBL().ListaTodosActivo(Convert.ToInt32(IdCapacitacion));

                        mListaCapacitacionDetalleOrigen.Clear();

                        int intItem = 1;
                        mListaCapacitacionDetalleOrigen.Clear();

                        foreach (CapacitacionDetalleBE item in lstTmpCapacitacionDetalle)
                        {
                            CCapacitacionDetalle objE_CapacitacionDetalle = new CCapacitacionDetalle();
                            objE_CapacitacionDetalle.IdEmpresa = item.IdEmpresa;
                            objE_CapacitacionDetalle.IdCapacitacion = 0;
                            objE_CapacitacionDetalle.IdCapacitacionDetalle = 0;
                            objE_CapacitacionDetalle.Item = intItem;
                            objE_CapacitacionDetalle.IdPersona = item.IdPersona;
                            objE_CapacitacionDetalle.Codigo = item.Codigo;
                            objE_CapacitacionDetalle.ApeNom = item.ApeNom;
                            objE_CapacitacionDetalle.DescArea = item.DescArea;
                            objE_CapacitacionDetalle.Nota = item.Nota;
                            objE_CapacitacionDetalle.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                            mListaCapacitacionDetalleOrigen.Add(objE_CapacitacionDetalle);

                            intItem++;
                        }

                        bsListado.DataSource = mListaCapacitacionDetalleOrigen;
                        gcCapacitacionDetalle.DataSource = bsListado;
                        gcCapacitacionDetalle.RefreshDataSource();


                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvCapacitacionDetalle_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Add)
            {
                intParticipantes = intParticipantes + 1;
                txtNumeroParticpantes.EditValue = intParticipantes; 
            }
            else if (e.Action == CollectionChangeAction.Remove)
            {
                intParticipantes = intParticipantes - 1;
                txtNumeroParticpantes.EditValue = intParticipantes;
            }
            else if (e.Action == CollectionChangeAction.Refresh)
            {
                
            }
        }

        #endregion

        #region "Metodos"

        private void CargaCapacitacionDetalle()
        {
            List<CapacitacionDetalleBE> lstTmpCapacitacionDetalle = null;
            lstTmpCapacitacionDetalle = new CapatacitacionDetalleBL().ListaTodosActivo(IdCapacitacion);

            foreach (CapacitacionDetalleBE item in lstTmpCapacitacionDetalle)
            {
                CCapacitacionDetalle objE_CapacitacionDetalle = new CCapacitacionDetalle();
                objE_CapacitacionDetalle.IdEmpresa = item.IdEmpresa;
                objE_CapacitacionDetalle.IdCapacitacion = item.IdCapacitacion;
                objE_CapacitacionDetalle.IdCapacitacionDetalle = item.IdCapacitacionDetalle;
                objE_CapacitacionDetalle.Item = item.Item;
                objE_CapacitacionDetalle.IdPersona = item.IdPersona;
                objE_CapacitacionDetalle.Codigo = item.Codigo;
                objE_CapacitacionDetalle.ApeNom = item.ApeNom;
                objE_CapacitacionDetalle.DescArea = item.DescArea;
                objE_CapacitacionDetalle.Nota = item.Nota;
                objE_CapacitacionDetalle.TipoOper = item.TipoOper;
                mListaCapacitacionDetalleOrigen.Add(objE_CapacitacionDetalle);
            }

            bsListado.DataSource = mListaCapacitacionDetalleOrigen;
            gcCapacitacionDetalle.DataSource = bsListado;
            gcCapacitacionDetalle.RefreshDataSource();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (cboLugar.Text == "")
            {
                strMensaje = strMensaje + "- Debe ingresar el lugar especifico.\n";
                flag = true;
            }

            if (gvCapacitacionDetalle.DataRowCount == 0)
            {
                strMensaje = strMensaje + "- Debe ingresar los participantes.\n";
                flag = true;

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
                    CapacitacionBE objCapacitacion = new CapacitacionBE();
                    CapacitacionBL objBL_Capacitacion = new CapacitacionBL();

                    objCapacitacion.IdCapacitacion = IdCapacitacion;
                    objCapacitacion.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objCapacitacion.IdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
                    objCapacitacion.IdProveedor = Convert.ToInt32(cboProveedor.EditValue);
                    objCapacitacion.Numero = txtNumero.Text;
                    objCapacitacion.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objCapacitacion.FechaIni = Convert.ToDateTime(teHoraInicio.EditValue);
                    objCapacitacion.FechaFin = Convert.ToDateTime(teHoraFin.EditValue);
                    objCapacitacion.Participantes = Convert.ToInt32(txtNumeroParticpantes.EditValue);
                    objCapacitacion.IdLugar = Convert.ToInt32(cboLugar.EditValue);
                    objCapacitacion.IdTipoCapacitacion = Convert.ToInt32(cboTipo.EditValue);
                    objCapacitacion.IdClasificacionCapacitacion = Convert.ToInt32(cboClasificacion.EditValue);
                    objCapacitacion.IdTema = Convert.ToInt32(cboTema.EditValue);
                    objCapacitacion.IdExpositor = Convert.ToInt32(cboExpositor.EditValue);
                    objCapacitacion.FlagEstado = true;
                    objCapacitacion.Usuario = Parametros.strUsuarioLogin;
                    objCapacitacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                   

                    //CAPACITACION DETALLE
                    List<CapacitacionDetalleBE> lstCapacitacionDetalle = new List<CapacitacionDetalleBE>();

                    

                    if (pOperacion == Operacion.Nuevo)
                    {
                        int[] rows = gvCapacitacionDetalle.GetSelectedRows();

                        for (int i = 0; i < rows.Length; i++)
                        {
                            CapacitacionDetalleBE objE_CapacitacionDetalle = new CapacitacionDetalleBE();
                            objE_CapacitacionDetalle.IdEmpresa = Parametros.intEmpresaId;
                            objE_CapacitacionDetalle.IdCapacitacion = IdCapacitacion;
                            objE_CapacitacionDetalle.IdCapacitacionDetalle = 0;
                            objE_CapacitacionDetalle.Item = int.Parse(gvCapacitacionDetalle.GetRowCellValue(rows[i], gvCapacitacionDetalle.Columns.ColumnByFieldName("Item")).ToString());
                            objE_CapacitacionDetalle.IdPersona = int.Parse(gvCapacitacionDetalle.GetRowCellValue(rows[i], gvCapacitacionDetalle.Columns.ColumnByFieldName("IdPersona")).ToString());
                            objE_CapacitacionDetalle.Codigo = gvCapacitacionDetalle.GetRowCellValue(rows[i], gvCapacitacionDetalle.Columns.ColumnByFieldName("Codigo")).ToString();
                            objE_CapacitacionDetalle.ApeNom = gvCapacitacionDetalle.GetRowCellValue(rows[i], gvCapacitacionDetalle.Columns.ColumnByFieldName("ApeNom")).ToString();
                            objE_CapacitacionDetalle.DescArea = gvCapacitacionDetalle.GetRowCellValue(rows[i], gvCapacitacionDetalle.Columns.ColumnByFieldName("DescArea")).ToString();
                            objE_CapacitacionDetalle.Nota = int.Parse(gvCapacitacionDetalle.GetRowCellValue(rows[i], gvCapacitacionDetalle.Columns.ColumnByFieldName("Nota")).ToString());
                            objE_CapacitacionDetalle.FlagEstado = true;
                            objE_CapacitacionDetalle.Usuario = Parametros.strUsuarioLogin;
                            objE_CapacitacionDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_CapacitacionDetalle.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                            lstCapacitacionDetalle.Add(objE_CapacitacionDetalle);
                        }


                        int intNumero = 0;
                        string strNumero = "";
                        intNumero = objBL_Capacitacion.Inserta(objCapacitacion, lstCapacitacionDetalle);
                        strNumero = FuncionBase.AgregarCaracter(intNumero.ToString(), "0", 7);
                        txtNumero.Text = strNumero;

                        //ActualizaNumero
                        CapacitacionBL objBCapacitacion = new CapacitacionBL();
                        objBCapacitacion.ActualizaNumero(intNumero, txtNumero.Text);

                        XtraMessageBox.Show("Se creó el registro de capacitación N° : " + txtNumero.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        foreach (var item in mListaCapacitacionDetalleOrigen)
                        {
                            CapacitacionDetalleBE objE_CapacitacionDetalle = new CapacitacionDetalleBE();
                            objE_CapacitacionDetalle.IdEmpresa = Parametros.intEmpresaId;
                            objE_CapacitacionDetalle.IdCapacitacion = IdCapacitacion;
                            objE_CapacitacionDetalle.IdCapacitacionDetalle = item.IdCapacitacionDetalle;
                            objE_CapacitacionDetalle.Item = item.Item;
                            objE_CapacitacionDetalle.IdPersona = item.IdPersona;
                            objE_CapacitacionDetalle.Codigo = item.Codigo;
                            objE_CapacitacionDetalle.ApeNom = item.ApeNom;
                            objE_CapacitacionDetalle.DescArea = item.DescArea;
                            objE_CapacitacionDetalle.Nota = item.Nota;
                            objE_CapacitacionDetalle.FlagEstado = true;
                            objE_CapacitacionDetalle.Usuario = Parametros.strUsuarioLogin;
                            objE_CapacitacionDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_CapacitacionDetalle.TipoOper = item.TipoOper;
                            lstCapacitacionDetalle.Add(objE_CapacitacionDetalle);
                        }

                        objBL_Capacitacion.Actualiza(objCapacitacion, lstCapacitacionDetalle);
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
        public class CCapacitacionDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdCapacitacion { get; set; }
            public Int32 IdCapacitacionDetalle { get; set; }
            public Int32 Item { get; set; }
            public Int32 IdPersona { get; set; }
            public string Codigo { get; set; }
            public string ApeNom { get; set; }
            public string DescArea { get; set; }
            public Int32 Nota { get; set; }
            public Int32 TipoOper { get; set; }

            public CCapacitacionDetalle()
            {

            }
        }

        
    }
}