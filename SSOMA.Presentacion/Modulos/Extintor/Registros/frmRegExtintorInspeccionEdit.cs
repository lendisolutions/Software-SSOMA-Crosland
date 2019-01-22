using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion.Modulos.Otros;

namespace SSOMA.Presentacion.Modulos.Extintor.Registros
{
    public partial class frmRegExtintorInspeccionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ExtintorInspeccionBE> lstExtintorInspeccion;
        public List<CExtintorInspeccionDetalle> mListaExtintorInspeccionDetalleOrigen = new List<CExtintorInspeccionDetalle>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdExtintorInspeccion = 0;

        public int IdExtintorInspeccion
        {
            get { return _IdExtintorInspeccion; }
            set { _IdExtintorInspeccion = value; }
        }

        #endregion

        

        #region "Eventos"

        public frmRegExtintorInspeccionEdit()
        {
            InitializeComponent();
            gcCodigoEquipo.Caption = "Código\nEquipo";
            gcTipoAgente.Caption = "Tipo\nAgente";
            gcFechaVencimiento.Caption = "Fecha\nVencimiento";
            gcFechaPrueba.Caption = "Fecha Vencimiento\nPrueba Hidrostatica";


        }

        private void frmRegExtintorInspeccionEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0, Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboTipo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoInspeccionExtintor), "DescTablaElemento", "IdTablaElemento", true);
            cboTipo.EditValue = Parametros.intTIEPlaneada;
            deFechaInspeccion.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Inspección Extintor - Nuevo";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Inspección Extintor - Modificar";

                ExtintorInspeccionBE objE_ExtintorInspeccion = null;
                objE_ExtintorInspeccion = new ExtintorInspeccionBL().Selecciona(IdExtintorInspeccion);

                IdExtintorInspeccion = objE_ExtintorInspeccion.IdExtintorInspeccion;
                cboEmpresa.EditValue = objE_ExtintorInspeccion.IdEmpresa;
                cboUnidadMinera.EditValue = objE_ExtintorInspeccion.IdUnidadMinera;
                cboTipo.EditValue = objE_ExtintorInspeccion.IdTipoInspeccion;
                txtInspeccionadoPor.Text = objE_ExtintorInspeccion.InspeccionadoPor;
                txtCargo.Text = objE_ExtintorInspeccion.Cargo;
                txtObservacion.Text = objE_ExtintorInspeccion.Observacion;
            }

            CargaExtintorInspeccionDetalle();
            cboEmpresa.Select();
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
            }
        }

        private void btnBuscarInspeccionado_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = false;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    txtInspeccionadoPor.Text = frm.pPersonaBE.ApeNom;
                    txtCargo.Text = frm.pPersonaBE.Cargo;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListarExtintores_Click(object sender, EventArgs e)
        {
            try
            {
                if (pOperacion == Operacion.Modificar)
                {
                    XtraMessageBox.Show("No válido cuando se esta modificando una Inspección de Extintores", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<ExtintorBE> lstTmpExtintor = null;
                lstTmpExtintor = new ExtintorBL().ListaInspeccionDetalle(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboUnidadMinera.EditValue));

                foreach (ExtintorBE item in lstTmpExtintor)
                {
                    CExtintorInspeccionDetalle objE_ExtintorInspeccionDetalle = new CExtintorInspeccionDetalle();
                    objE_ExtintorInspeccionDetalle.IdEmpresa = item.IdEmpresa;
                    objE_ExtintorInspeccionDetalle.IdExtintorInspeccionDetalle = item.IdExtintorInspeccionDetalle;
                    objE_ExtintorInspeccionDetalle.IdExtintorInspeccion = item.IdExtintorInspeccion;
                    objE_ExtintorInspeccionDetalle.IdExtintor = item.IdExtintor;
                    objE_ExtintorInspeccionDetalle.Codigo = item.Codigo;
                    objE_ExtintorInspeccionDetalle.Serie = item.Serie;
                    objE_ExtintorInspeccionDetalle.Abreviatura = item.Abreviatura;
                    objE_ExtintorInspeccionDetalle.Capacidad = item.Capacidad;
                    objE_ExtintorInspeccionDetalle.Ubicacion = item.Ubicacion;
                    objE_ExtintorInspeccionDetalle.Marca = item.Marca;
                    objE_ExtintorInspeccionDetalle.Uno = item.Uno;
                    objE_ExtintorInspeccionDetalle.Dos = item.Dos;
                    objE_ExtintorInspeccionDetalle.Tres = item.Tres;
                    objE_ExtintorInspeccionDetalle.Cuatro = item.Cuatro;
                    objE_ExtintorInspeccionDetalle.Cinco = item.Cinco;
                    objE_ExtintorInspeccionDetalle.Seis = item.Seis;
                    objE_ExtintorInspeccionDetalle.Siete = item.Siete;
                    objE_ExtintorInspeccionDetalle.Ocho = item.Ocho;
                    objE_ExtintorInspeccionDetalle.Nueve = item.Nueve;
                    objE_ExtintorInspeccionDetalle.Diez = item.Diez;
                    objE_ExtintorInspeccionDetalle.Once = item.Once;
                    objE_ExtintorInspeccionDetalle.Doce = item.Doce;
                    objE_ExtintorInspeccionDetalle.Trece = item.Trece;
                    objE_ExtintorInspeccionDetalle.Catorce = item.Catorce;
                    objE_ExtintorInspeccionDetalle.Quince = item.Quince;
                    objE_ExtintorInspeccionDetalle.Diecisies = item.Diecisies;
                    objE_ExtintorInspeccionDetalle.Diecisiete = item.Diecisiete;
                    objE_ExtintorInspeccionDetalle.FechaVencimiento = item.FechaVencimiento;
                    objE_ExtintorInspeccionDetalle.RecargadoPor = item.RecargadoPor;
                    objE_ExtintorInspeccionDetalle.Observacion = item.Observacion;
                    objE_ExtintorInspeccionDetalle.FechaVencimientoPruebaHidrostatica = item.FechaVencimientoPruebaHidrostatica;
                    objE_ExtintorInspeccionDetalle.TipoOper = item.TipoOper;
                    mListaExtintorInspeccionDetalleOrigen.Add(objE_ExtintorInspeccionDetalle);
                }

                bsListado.DataSource = mListaExtintorInspeccionDetalleOrigen;
                gcExtintorInspeccionDetalle.DataSource = bsListado;
                gcExtintorInspeccionDetalle.RefreshDataSource();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcCheck_CheckedChanged(object sender, EventArgs e)
        {
            string strAnomalia = "";
            
            CheckEdit edit = sender as CheckEdit;

            int index = gvExtintorInspeccionDetalle.FocusedRowHandle;

            if (gvExtintorInspeccionDetalle.FocusedColumn.FieldName == "Uno")
            {
                string strObservacion = gvExtintorInspeccionDetalle.GetFocusedRowCellValue("Observacion").ToString();

                AnomaliaBE objE_Anomalia = null;
                objE_Anomalia = new AnomaliaBL().Selecciona(0, 1);
                if (objE_Anomalia != null)
                {
                    strAnomalia = objE_Anomalia.DescAnomalia;
                }
                if (edit.Checked)
                {
                    strObservacion = strObservacion + strAnomalia + ",";
                    
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Uno", true);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
                else
                {
                    strObservacion = strObservacion.Replace(strAnomalia + ",", "");
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Uno", false);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
            }

            if (gvExtintorInspeccionDetalle.FocusedColumn.FieldName == "Dos")
            {
                string strObservacion = gvExtintorInspeccionDetalle.GetFocusedRowCellValue("Observacion").ToString();

                AnomaliaBE objE_Anomalia = null;
                objE_Anomalia = new AnomaliaBL().Selecciona(0, 2);
                if (objE_Anomalia != null)
                {
                    strAnomalia = objE_Anomalia.DescAnomalia;
                }
                if (edit.Checked)
                {
                    strObservacion = strObservacion + strAnomalia + ",";

                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Dos", true);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
                else
                {
                    strObservacion = strObservacion.Replace(strAnomalia + ",", "");
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Dos", false);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
            }

            if (gvExtintorInspeccionDetalle.FocusedColumn.FieldName == "Tres")
            {
                string strObservacion = gvExtintorInspeccionDetalle.GetFocusedRowCellValue("Observacion").ToString();

                AnomaliaBE objE_Anomalia = null;
                objE_Anomalia = new AnomaliaBL().Selecciona(0, 3);
                if (objE_Anomalia != null)
                {
                    strAnomalia = objE_Anomalia.DescAnomalia;
                }
                if (edit.Checked)
                {
                    strObservacion = strObservacion + strAnomalia + ",";

                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Tres", true);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
                else
                {
                    strObservacion = strObservacion.Replace(strAnomalia + ",", "");
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Tres", false);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
            }

            if (gvExtintorInspeccionDetalle.FocusedColumn.FieldName == "Cuatro")
            {
                string strObservacion = gvExtintorInspeccionDetalle.GetFocusedRowCellValue("Observacion").ToString();

                AnomaliaBE objE_Anomalia = null;
                objE_Anomalia = new AnomaliaBL().Selecciona(0, 4);
                if (objE_Anomalia != null)
                {
                    strAnomalia = objE_Anomalia.DescAnomalia;
                }
                if (edit.Checked)
                {
                    strObservacion = strObservacion + strAnomalia + ",";

                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Cuatro", true);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
                else
                {
                    strObservacion = strObservacion.Replace(strAnomalia + ",", "");
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Cuatro", false);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
            }

            if (gvExtintorInspeccionDetalle.FocusedColumn.FieldName == "Cinco")
            {
                string strObservacion = gvExtintorInspeccionDetalle.GetFocusedRowCellValue("Observacion").ToString();

                AnomaliaBE objE_Anomalia = null;
                objE_Anomalia = new AnomaliaBL().Selecciona(0, 5);
                if (objE_Anomalia != null)
                {
                    strAnomalia = objE_Anomalia.DescAnomalia;
                }
                if (edit.Checked)
                {
                    strObservacion = strObservacion + strAnomalia + ",";

                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Cinco", true);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
                else
                {
                    strObservacion = strObservacion.Replace(strAnomalia + ",", "");
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Cinco", false);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
            }

            if (gvExtintorInspeccionDetalle.FocusedColumn.FieldName == "Seis")
            {
                string strObservacion = gvExtintorInspeccionDetalle.GetFocusedRowCellValue("Observacion").ToString();

                AnomaliaBE objE_Anomalia = null;
                objE_Anomalia = new AnomaliaBL().Selecciona(0, 6);
                if (objE_Anomalia != null)
                {
                    strAnomalia = objE_Anomalia.DescAnomalia;
                }
                if (edit.Checked)
                {
                    strObservacion = strObservacion + strAnomalia + ",";

                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Seis", true);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
                else
                {
                    strObservacion = strObservacion.Replace(strAnomalia + ",", "");
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Seis", false);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
            }

            if (gvExtintorInspeccionDetalle.FocusedColumn.FieldName == "Siete")
            {
                string strObservacion = gvExtintorInspeccionDetalle.GetFocusedRowCellValue("Observacion").ToString();

                AnomaliaBE objE_Anomalia = null;
                objE_Anomalia = new AnomaliaBL().Selecciona(0, 7);
                if (objE_Anomalia != null)
                {
                    strAnomalia = objE_Anomalia.DescAnomalia;
                }
                if (edit.Checked)
                {
                    strObservacion = strObservacion + strAnomalia + ",";

                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Siete", true);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
                else
                {
                    strObservacion = strObservacion.Replace(strAnomalia + ",", "");
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Siete", false);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
            }

            if (gvExtintorInspeccionDetalle.FocusedColumn.FieldName == "Ocho")
            {
                string strObservacion = gvExtintorInspeccionDetalle.GetFocusedRowCellValue("Observacion").ToString();

                AnomaliaBE objE_Anomalia = null;
                objE_Anomalia = new AnomaliaBL().Selecciona(0, 8);
                if (objE_Anomalia != null)
                {
                    strAnomalia = objE_Anomalia.DescAnomalia;
                }
                if (edit.Checked)
                {
                    strObservacion = strObservacion + strAnomalia + ",";

                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Ocho", true);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
                else
                {
                    strObservacion = strObservacion.Replace(strAnomalia + ",", "");
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Ocho", false);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
            }

            if (gvExtintorInspeccionDetalle.FocusedColumn.FieldName == "Nueve")
            {
                string strObservacion = gvExtintorInspeccionDetalle.GetFocusedRowCellValue("Observacion").ToString();

                AnomaliaBE objE_Anomalia = null;
                objE_Anomalia = new AnomaliaBL().Selecciona(0, 9);
                if (objE_Anomalia != null)
                {
                    strAnomalia = objE_Anomalia.DescAnomalia;
                }
                if (edit.Checked)
                {
                    strObservacion = strObservacion + strAnomalia + ",";

                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Nueve", true);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
                else
                {
                    strObservacion = strObservacion.Replace(strAnomalia + ",", "");
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Nueve", false);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
            }

            if (gvExtintorInspeccionDetalle.FocusedColumn.FieldName == "Diez")
            {
                string strObservacion = gvExtintorInspeccionDetalle.GetFocusedRowCellValue("Observacion").ToString();

                AnomaliaBE objE_Anomalia = null;
                objE_Anomalia = new AnomaliaBL().Selecciona(0, 10);
                if (objE_Anomalia != null)
                {
                    strAnomalia = objE_Anomalia.DescAnomalia;
                }
                if (edit.Checked)
                {
                    strObservacion = strObservacion + strAnomalia + ",";

                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Diez", true);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
                else
                {
                    strObservacion = strObservacion.Replace(strAnomalia + ",", "");
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Diez", false);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
            }

            if (gvExtintorInspeccionDetalle.FocusedColumn.FieldName == "Once")
            {
                string strObservacion = gvExtintorInspeccionDetalle.GetFocusedRowCellValue("Observacion").ToString();

                AnomaliaBE objE_Anomalia = null;
                objE_Anomalia = new AnomaliaBL().Selecciona(0, 11);
                if (objE_Anomalia != null)
                {
                    strAnomalia = objE_Anomalia.DescAnomalia;
                }
                if (edit.Checked)
                {
                    strObservacion = strObservacion + strAnomalia + ",";

                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Once", true);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
                else
                {
                    strObservacion = strObservacion.Replace(strAnomalia + ",", "");
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Once", false);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
            }

            if (gvExtintorInspeccionDetalle.FocusedColumn.FieldName == "Doce")
            {
                string strObservacion = gvExtintorInspeccionDetalle.GetFocusedRowCellValue("Observacion").ToString();

                AnomaliaBE objE_Anomalia = null;
                objE_Anomalia = new AnomaliaBL().Selecciona(0, 12);
                if (objE_Anomalia != null)
                {
                    strAnomalia = objE_Anomalia.DescAnomalia;
                }
                if (edit.Checked)
                {
                    strObservacion = strObservacion + strAnomalia + ",";

                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Doce", true);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
                else
                {
                    strObservacion = strObservacion.Replace(strAnomalia + ",", "");
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Doce", false);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
            }

            if (gvExtintorInspeccionDetalle.FocusedColumn.FieldName == "Trece")
            {
                string strObservacion = gvExtintorInspeccionDetalle.GetFocusedRowCellValue("Observacion").ToString();

                AnomaliaBE objE_Anomalia = null;
                objE_Anomalia = new AnomaliaBL().Selecciona(0, 13);
                if (objE_Anomalia != null)
                {
                    strAnomalia = objE_Anomalia.DescAnomalia;
                }
                if (edit.Checked)
                {
                    strObservacion = strObservacion + strAnomalia + ",";

                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Trece", true);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
                else
                {
                    strObservacion = strObservacion.Replace(strAnomalia + ",", "");
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Trece", false);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
            }

            if (gvExtintorInspeccionDetalle.FocusedColumn.FieldName == "Catorce")
            {
                string strObservacion = gvExtintorInspeccionDetalle.GetFocusedRowCellValue("Observacion").ToString();

                AnomaliaBE objE_Anomalia = null;
                objE_Anomalia = new AnomaliaBL().Selecciona(0, 14);
                if (objE_Anomalia != null)
                {
                    strAnomalia = objE_Anomalia.DescAnomalia;
                }
                if (edit.Checked)
                {
                    strObservacion = strObservacion + strAnomalia + ",";

                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Catorce", true);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
                else
                {
                    strObservacion = strObservacion.Replace(strAnomalia + ",", "");
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Catorce", false);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
            }

            if (gvExtintorInspeccionDetalle.FocusedColumn.FieldName == "Quince")
            {
                string strObservacion = gvExtintorInspeccionDetalle.GetFocusedRowCellValue("Observacion").ToString();

                AnomaliaBE objE_Anomalia = null;
                objE_Anomalia = new AnomaliaBL().Selecciona(0, 15);
                if (objE_Anomalia != null)
                {
                    strAnomalia = objE_Anomalia.DescAnomalia;
                }
                if (edit.Checked)
                {
                    strObservacion = strObservacion + strAnomalia + ",";

                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Quince", true);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
                else
                {
                    strObservacion = strObservacion.Replace(strAnomalia + ",", "");
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Quince", false);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
            }

            if (gvExtintorInspeccionDetalle.FocusedColumn.FieldName == "Diecisies")
            {
                string strObservacion = gvExtintorInspeccionDetalle.GetFocusedRowCellValue("Observacion").ToString();

                AnomaliaBE objE_Anomalia = null;
                objE_Anomalia = new AnomaliaBL().Selecciona(0, 16);
                if (objE_Anomalia != null)
                {
                    strAnomalia = objE_Anomalia.DescAnomalia;
                }
                if (edit.Checked)
                {
                    strObservacion = strObservacion + strAnomalia + ",";

                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Diecisies", true);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
                else
                {
                    strObservacion = strObservacion.Replace(strAnomalia + ",", "");
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Diecisies", false);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
            }

            if (gvExtintorInspeccionDetalle.FocusedColumn.FieldName == "Diecisiete")
            {
                string strObservacion = gvExtintorInspeccionDetalle.GetFocusedRowCellValue("Observacion").ToString();

                AnomaliaBE objE_Anomalia = null;
                objE_Anomalia = new AnomaliaBL().Selecciona(0, 17);
                if (objE_Anomalia != null)
                {
                    strAnomalia = objE_Anomalia.DescAnomalia;
                }
                if (edit.Checked)
                {
                    strObservacion = strObservacion + strAnomalia + ",";

                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Diecisiete", true);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
                }
                else
                {
                    strObservacion = strObservacion.Replace(strAnomalia + ",", "");
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Diecisiete", false);
                    gvExtintorInspeccionDetalle.SetRowCellValue(index, "Observacion", strObservacion);
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
                    ExtintorInspeccionBE objExtintorInspeccion = new ExtintorInspeccionBE();
                    ExtintorInspeccionBL objBL_ExtintorInspeccion = new ExtintorInspeccionBL();

                    objExtintorInspeccion.IdExtintorInspeccion = IdExtintorInspeccion;
                    objExtintorInspeccion.IdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
                    objExtintorInspeccion.IdTipoInspeccion = Convert.ToInt32(cboTipo.EditValue);
                    objExtintorInspeccion.FechaInspeccion = Convert.ToDateTime(deFechaInspeccion.DateTime.ToShortDateString());
                    objExtintorInspeccion.InspeccionadoPor = txtInspeccionadoPor.Text;
                    objExtintorInspeccion.Cargo = txtCargo.Text;
                    objExtintorInspeccion.Observacion = txtObservacion.Text;
                    objExtintorInspeccion.FlagEstado = true;
                    objExtintorInspeccion.Usuario = Parametros.strUsuarioLogin;
                    objExtintorInspeccion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objExtintorInspeccion.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                    //ExtintorInspeccion DETALLE
                    List<ExtintorInspeccionDetalleBE> lstExtintorInspeccionDetalle = new List<ExtintorInspeccionDetalleBE>();

                    foreach (var item in mListaExtintorInspeccionDetalleOrigen)
                    {
                        ExtintorInspeccionDetalleBE objE_ExtintorInspeccionDetalle = new ExtintorInspeccionDetalleBE();
                        objE_ExtintorInspeccionDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objE_ExtintorInspeccionDetalle.IdExtintorInspeccion = IdExtintorInspeccion;
                        objE_ExtintorInspeccionDetalle.IdExtintorInspeccionDetalle = item.IdExtintorInspeccionDetalle;
                        objE_ExtintorInspeccionDetalle.IdExtintor = item.IdExtintor;
                        objE_ExtintorInspeccionDetalle.Codigo = item.Codigo;
                        objE_ExtintorInspeccionDetalle.Serie = item.Serie;
                        objE_ExtintorInspeccionDetalle.Abreviatura = item.Abreviatura;
                        objE_ExtintorInspeccionDetalle.Capacidad = item.Capacidad;
                        objE_ExtintorInspeccionDetalle.Ubicacion = item.Ubicacion;
                        objE_ExtintorInspeccionDetalle.Marca = item.Marca;
                        objE_ExtintorInspeccionDetalle.Uno = item.Uno;
                        objE_ExtintorInspeccionDetalle.Dos = item.Dos;
                        objE_ExtintorInspeccionDetalle.Tres = item.Tres;
                        objE_ExtintorInspeccionDetalle.Cuatro = item.Cuatro;
                        objE_ExtintorInspeccionDetalle.Cinco = item.Cinco;
                        objE_ExtintorInspeccionDetalle.Seis = item.Seis;
                        objE_ExtintorInspeccionDetalle.Siete = item.Siete;
                        objE_ExtintorInspeccionDetalle.Ocho = item.Ocho;
                        objE_ExtintorInspeccionDetalle.Nueve = item.Nueve;
                        objE_ExtintorInspeccionDetalle.Diez = item.Diez;
                        objE_ExtintorInspeccionDetalle.Once = item.Once;
                        objE_ExtintorInspeccionDetalle.Doce = item.Doce;
                        objE_ExtintorInspeccionDetalle.Trece = item.Trece;
                        objE_ExtintorInspeccionDetalle.Catorce = item.Catorce;
                        objE_ExtintorInspeccionDetalle.Quince = item.Quince;
                        objE_ExtintorInspeccionDetalle.Diecisies = item.Diecisies;
                        objE_ExtintorInspeccionDetalle.Diecisiete = item.Diecisiete;
                        objE_ExtintorInspeccionDetalle.FechaVencimiento = item.FechaVencimiento;
                        objE_ExtintorInspeccionDetalle.RecargadoPor = item.RecargadoPor;
                        objE_ExtintorInspeccionDetalle.Observacion = item.Observacion;
                        objE_ExtintorInspeccionDetalle.FechaVencimientoPruebaHidrostatica = item.FechaVencimientoPruebaHidrostatica;
                        objE_ExtintorInspeccionDetalle.FlagEstado = true;
                        objE_ExtintorInspeccionDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_ExtintorInspeccionDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ExtintorInspeccionDetalle.TipoOper = item.TipoOper;
                        lstExtintorInspeccionDetalle.Add(objE_ExtintorInspeccionDetalle);
                    }


                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_ExtintorInspeccion.Inserta(objExtintorInspeccion, lstExtintorInspeccionDetalle);
                        XtraMessageBox.Show("Se creó el registro del ExtintorInspeccion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        objBL_ExtintorInspeccion.Actualiza(objExtintorInspeccion, lstExtintorInspeccionDetalle);
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

            if (txtInspeccionadoPor.Text == "")
            {
                strMensaje = strMensaje + "- Debe seleccionar al Inspector.\n";
                flag = true;
            }

            if (mListaExtintorInspeccionDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- La inspección de extintores no puede estar vacia.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CargaExtintorInspeccionDetalle()
        {
            List<ExtintorInspeccionDetalleBE> lstTmpExtintorInspeccionDetalle = null;
            lstTmpExtintorInspeccionDetalle = new ExtintorInspeccionDetalleBL().ListaTodosActivo(IdExtintorInspeccion);

            foreach (ExtintorInspeccionDetalleBE item in lstTmpExtintorInspeccionDetalle)
            {
                CExtintorInspeccionDetalle objE_ExtintorInspeccionDetalle = new CExtintorInspeccionDetalle();
                objE_ExtintorInspeccionDetalle.IdEmpresa = item.IdEmpresa;
                objE_ExtintorInspeccionDetalle.IdExtintorInspeccionDetalle = item.IdExtintorInspeccionDetalle;
                objE_ExtintorInspeccionDetalle.IdExtintorInspeccion = item.IdExtintorInspeccion;
                objE_ExtintorInspeccionDetalle.IdExtintor = item.IdExtintor;
                objE_ExtintorInspeccionDetalle.Codigo = item.Codigo;
                objE_ExtintorInspeccionDetalle.Serie = item.Serie;
                objE_ExtintorInspeccionDetalle.Abreviatura = item.Abreviatura;
                objE_ExtintorInspeccionDetalle.Capacidad = item.Capacidad;
                objE_ExtintorInspeccionDetalle.Ubicacion = item.Ubicacion;
                objE_ExtintorInspeccionDetalle.Marca = item.Marca;
                objE_ExtintorInspeccionDetalle.Uno = item.Uno;
                objE_ExtintorInspeccionDetalle.Dos = item.Dos;
                objE_ExtintorInspeccionDetalle.Tres = item.Tres;
                objE_ExtintorInspeccionDetalle.Cuatro = item.Cuatro;
                objE_ExtintorInspeccionDetalle.Cinco = item.Cinco;
                objE_ExtintorInspeccionDetalle.Seis = item.Seis;
                objE_ExtintorInspeccionDetalle.Siete = item.Siete;
                objE_ExtintorInspeccionDetalle.Ocho = item.Ocho;
                objE_ExtintorInspeccionDetalle.Nueve = item.Nueve;
                objE_ExtintorInspeccionDetalle.Diez = item.Diez;
                objE_ExtintorInspeccionDetalle.Once = item.Once;
                objE_ExtintorInspeccionDetalle.Doce = item.Doce;
                objE_ExtintorInspeccionDetalle.Trece = item.Trece;
                objE_ExtintorInspeccionDetalle.Catorce = item.Catorce;
                objE_ExtintorInspeccionDetalle.Quince = item.Quince;
                objE_ExtintorInspeccionDetalle.Diecisies = item.Diecisies;
                objE_ExtintorInspeccionDetalle.Diecisiete = item.Diecisiete;
                objE_ExtintorInspeccionDetalle.FechaVencimiento = item.FechaVencimiento;
                objE_ExtintorInspeccionDetalle.RecargadoPor = item.RecargadoPor;
                objE_ExtintorInspeccionDetalle.Observacion = item.Observacion;
                objE_ExtintorInspeccionDetalle.FechaVencimientoPruebaHidrostatica = item.FechaVencimientoPruebaHidrostatica;
                objE_ExtintorInspeccionDetalle.TipoOper = item.TipoOper;
                mListaExtintorInspeccionDetalleOrigen.Add(objE_ExtintorInspeccionDetalle);
            }

            bsListado.DataSource = mListaExtintorInspeccionDetalleOrigen;
            gcExtintorInspeccionDetalle.DataSource = bsListado;
            gcExtintorInspeccionDetalle.RefreshDataSource();
        }





        #endregion

        
    }

    public class CExtintorInspeccionDetalle
    {
        public Int32 IdEmpresa { get; set; }
        public Int32 IdExtintorInspeccionDetalle { get; set; }
        public Int32 IdExtintorInspeccion { get; set; }
        public Int32 IdExtintor { get; set; }
        public string Codigo { get; set; }
        public string Serie { get; set; }
        public string Abreviatura { get; set; }
        public string Capacidad { get; set; }
        public string Ubicacion { get; set; }
        public string Marca { get; set; }
        public Boolean Uno { get; set; }
        public Boolean Dos { get; set; }
        public Boolean Tres { get; set; }
        public Boolean Cuatro { get; set; }
        public Boolean Cinco { get; set; }
        public Boolean Seis { get; set; }
        public Boolean Siete { get; set; }
        public Boolean Ocho { get; set; }
        public Boolean Nueve { get; set; }
        public Boolean Diez { get; set; }
        public Boolean Once { get; set; }
        public Boolean Doce { get; set; }
        public Boolean Trece { get; set; }
        public Boolean Catorce { get; set; }
        public Boolean Quince { get; set; }
        public Boolean Diecisies { get; set; }
        public Boolean Diecisiete { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string RecargadoPor { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaVencimientoPruebaHidrostatica { get; set; }
        public Int32 TipoOper { get; set; }

        public CExtintorInspeccionDetalle()
        {

        }
    }
}