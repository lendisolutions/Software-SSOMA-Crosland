using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using DevExpress.XtraBars;
using SSOMA.Presentacion.Modulos.Epp.Rpt;
using SSOMA.Presentacion.Modulos.Capacitacion.Rpt;
using SSOMA.Presentacion.Modulos.Accidente.Rpt;
using SSOMA.Presentacion.Modulos.Inspeccion.Rpt;
using SSOMA.Presentacion.Modulos.Extintor.Rpt;
using SSOMA.Presentacion.Modulos.Documentario.Rpt;
using SSOMA.Presentacion.Modulos.Medico.Rpt;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion
{
    public partial class RptVistaReportes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region "Propiedades"
        
        #endregion

        #region Eventos

        public RptVistaReportes()
        {
            InitializeComponent();
        }

        private void RptVistaReportes_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region Metodos

        public void VerRptEquipo(List<ReporteEquipoBE> lstReporte)
        {
            rptEquipo objReporte = new rptEquipo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSolicitudEppPorVencer(List<ReporteSolicitudEppBE> lstReporte)
        {
            rptSolicitudEppPorVencer objReporte = new rptSolicitudEppPorVencer();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSolicitudEppVencida(List<ReporteSolicitudEppBE> lstReporte)
        {
            rptSolicitudEppVencida objReporte = new rptSolicitudEppVencida();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEpp(List<ReporteEppBE> lstReporte, string Coordinador, string EmpresaResponsable)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pCoordinador = new ParameterField();
            pCoordinador.ParameterFieldName = "Coordinador";
            ParameterDiscreteValue ValueCoordinador = new ParameterDiscreteValue();
            ValueCoordinador.Value = Coordinador;
            pCoordinador.CurrentValues.Add(ValueCoordinador);
            paramFields.Add(pCoordinador);

            ParameterField pEmpresaResponsable = new ParameterField();
            pEmpresaResponsable.ParameterFieldName = "EmpresaResponsable";
            ParameterDiscreteValue ValueEmpresaResponsable = new ParameterDiscreteValue();
            ValueEmpresaResponsable.Value = EmpresaResponsable;
            pEmpresaResponsable.CurrentValues.Add(ValueEmpresaResponsable);
            paramFields.Add(pEmpresaResponsable);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptEpp objReporte = new rptEpp();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppPersonaConsumo(List<ReporteEppBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptEppPersonaConsumo objReporte = new rptEppPersonaConsumo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppPersona(List<ReporteEppBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptEppPersona objReporte = new rptEppPersona();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppTipoEntregaa(List<ReporteEppBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptEppTipoEntrega objReporte = new rptEppTipoEntrega();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppEmpresaResponsable(List<ReporteEppBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptEppEmpresaResponsable objReporte = new rptEppEmpresaResponsable();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppUnidadMineraResponsable(List<ReporteEppBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptEppUnidadMineraResponsable objReporte = new rptEppUnidadMineraResponsable();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppAreaResponsable(List<ReporteEppBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptEppAreaResponsable objReporte = new rptEppAreaResponsable();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppEquipo(List<ReporteEppBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptEppEquipo objReporte = new rptEppEquipo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppRegistroEntregaEmpresa(List<ReporteEppBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptEppRegistroEntregaEmpresa objReporte = new rptEppRegistroEntregaEmpresa();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppRegistroEntregaSede(List<ReporteEppBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptEppRegistroEntregaSede objReporte = new rptEppRegistroEntregaSede();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppConsumoAnualEmpresa(List<ReporteEppBE> lstReporte)
        {
            rptEppConsumoAnualEmpresa objReporte = new rptEppConsumoAnualEmpresa();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppConsumoAnualUnidadMinera(List<ReporteEppBE> lstReporte)
        {
            rptEppConsumoAnualUnidadMinera objReporte = new rptEppConsumoAnualUnidadMinera();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppConsumoAnualNegocio(List<ReporteEppBE> lstReporte)
        {
            rptEppConsumoAnualNegocio objReporte = new rptEppConsumoAnualNegocio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppConsumoAnualArea(List<ReporteEppBE> lstReporte)
        {
            rptEppConsumoAnualArea objReporte = new rptEppConsumoAnualArea();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppConsumoAnualSector(List<ReporteEppBE> lstReporte)
        {
            rptEppConsumoAnualSector objReporte = new rptEppConsumoAnualSector();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppConsumoMensualEmpresa(List<ReporteEppBE> lstReporte)
        {
            rptEppConsumoMensualEmpresa objReporte = new rptEppConsumoMensualEmpresa();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppConsumoMensualUnidadMinera(List<ReporteEppBE> lstReporte)
        {
            rptEppConsumoMensualUnidadMinera objReporte = new rptEppConsumoMensualUnidadMinera();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppConsumoMensualNegocio(List<ReporteEppBE> lstReporte)
        {
            rptEppConsumoMensualNegocio objReporte = new rptEppConsumoMensualNegocio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppConsumoMensualArea(List<ReporteEppBE> lstReporte)
        {
            rptEppConsumoMensualArea objReporte = new rptEppConsumoMensualArea();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppConsumoMensualSector(List<ReporteEppBE> lstReporte)
        {
            rptEppConsumoMensualSector objReporte = new rptEppConsumoMensualSector();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEppConsumoResumen(List<ReporteEppBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptEppConsumoResumen objReporte = new rptEppConsumoResumen();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPlanAnual(List<ReportePlanAnualBE> lstReporte)
        {
            rptPlanAnual objReporte = new rptPlanAnual();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacion(List<ReporteCapacitacionBE> lstReporte)
        {
            rptCapacitacion objReporte = new rptCapacitacion();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionPersona(List<ReporteCapacitacionBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptCapacitacionPersona objReporte = new rptCapacitacionPersona();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionProveedor(List<ReporteCapacitacionBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptCapacitacionProveedor objReporte = new rptCapacitacionProveedor();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionExpositor(List<ReporteCapacitacionBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptCapacitacionExpositor objReporte = new rptCapacitacionExpositor();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionTema(List<ReporteCapacitacionBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptCapacitacionTema objReporte = new rptCapacitacionTema();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionTipo(List<ReporteCapacitacionBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptCapacitacionTipo objReporte = new rptCapacitacionTipo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionClasificacion(List<ReporteCapacitacionBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptCapacitacionClasificacion objReporte = new rptCapacitacionClasificacion();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionAprobada(List<ReporteCapacitacionBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptCapacitacionAprobada objReporte = new rptCapacitacionAprobada();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionDesaprobada(List<ReporteCapacitacionBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptCapacitacionDesaprobada objReporte = new rptCapacitacionDesaprobada();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionHorasAnualEmpresa(List<ReporteCapacitacionBE> lstReporte)
        {
            rptCapacitacionHorasAnualEmpresa objReporte = new rptCapacitacionHorasAnualEmpresa();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionHorasAnualUnidadMinera(List<ReporteCapacitacionBE> lstReporte)
        {
            rptCapacitacionHorasAnualUnidadMinera objReporte = new rptCapacitacionHorasAnualUnidadMinera();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionHorasAnualNegocio(List<ReporteCapacitacionBE> lstReporte)
        {
            rptCapacitacionHorasAnualNegocio objReporte = new rptCapacitacionHorasAnualNegocio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionHorasAnualArea(List<ReporteCapacitacionBE> lstReporte)
        {
            rptCapacitacionHorasAnualArea objReporte = new rptCapacitacionHorasAnualArea();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionHorasAnualTipo(List<ReporteCapacitacionBE> lstReporte)
        {
            rptCapacitacionHorasAnualTipo objReporte = new rptCapacitacionHorasAnualTipo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionHorasAnualClasificacion(List<ReporteCapacitacionBE> lstReporte)
        {
            rptCapacitacionHorasAnualClasificacion objReporte = new rptCapacitacionHorasAnualClasificacion();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionHorasMensualEmpresa(List<ReporteCapacitacionBE> lstReporte)
        {
            rptCapacitacionHorasMensualEmpresa objReporte = new rptCapacitacionHorasMensualEmpresa();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionHorasMensualUnidadMinera(List<ReporteCapacitacionBE> lstReporte)
        {
            rptCapacitacionHorasMensualUnidadMinera objReporte = new rptCapacitacionHorasMensualUnidadMinera();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionHorasMensualNegocio(List<ReporteCapacitacionBE> lstReporte)
        {
            rptCapacitacionHorasMensualNegocio objReporte = new rptCapacitacionHorasMensualNegocio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionHorasMensualArea(List<ReporteCapacitacionBE> lstReporte)
        {
            rptCapacitacionHorasMensualArea objReporte = new rptCapacitacionHorasMensualArea();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionHorasMensualTipo(List<ReporteCapacitacionBE> lstReporte)
        {
            rptCapacitacionHorasMensualTipo objReporte = new rptCapacitacionHorasMensualTipo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionHorasMensualClasificacion(List<ReporteCapacitacionBE> lstReporte)
        {
            rptCapacitacionHorasMensualClasificacion objReporte = new rptCapacitacionHorasMensualClasificacion();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCapacitacionInasistencia(List<ReporteCapacitacionBE> lstReporte, string Tipo, string Clasificacion)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pTipo = new ParameterField();
            pTipo.ParameterFieldName = "Tipo";
            ParameterDiscreteValue ValueTipo = new ParameterDiscreteValue();
            ValueTipo.Value = Tipo;
            pTipo.CurrentValues.Add(ValueTipo);
            paramFields.Add(pTipo);

            ParameterField pClasificacion = new ParameterField();
            pClasificacion.ParameterFieldName = "Clasificacion";
            ParameterDiscreteValue ValueClasificacion = new ParameterDiscreteValue();
            ValueClasificacion.Value = Clasificacion;
            pClasificacion.CurrentValues.Add(ValueClasificacion);
            paramFields.Add(pClasificacion);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptCapacitacionInasistencia objReporte = new rptCapacitacionInasistencia();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteEmpresaResponsable(List<ReporteAccidenteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptAccidenteEmpresaResponsable objReporte = new rptAccidenteEmpresaResponsable();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteEmpresaContratista(List<ReporteAccidenteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptAccidenteEmpresaContratista objReporte = new rptAccidenteEmpresaContratista();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteUnidadMineraResponsable(List<ReporteAccidenteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptAccidenteUnidadMineraResponsable objReporte = new rptAccidenteUnidadMineraResponsable();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteAreaResponsable(List<ReporteAccidenteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptAccidenteAreaResponsable objReporte = new rptAccidenteAreaResponsable();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteResponsable(List<ReporteAccidenteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptAccidenteResponsable objReporte = new rptAccidenteResponsable();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidentePotencialDanio(List<ReporteAccidenteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptAccidentePotencialDanio objReporte = new rptAccidentePotencialDanio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteTipoAccidente(List<ReporteAccidenteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptAccidenteTipoAccidente objReporte = new rptAccidenteTipoAccidente();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteParteLesionada(List<ReporteAccidenteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptAccidenteParteLesionada objReporte = new rptAccidenteParteLesionada();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteTipoLesion(List<ReporteAccidenteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptAccidenteTipoLesion objReporte = new rptAccidenteTipoLesion();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteFuenteLesion(List<ReporteAccidenteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptAccidenteFuenteLesion objReporte = new rptAccidenteFuenteLesion();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteActoSubEstandar(List<ReporteAccidenteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptAccidenteActoSubEstandar objReporte = new rptAccidenteActoSubEstandar();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteCondicionSubEstandar(List<ReporteAccidenteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptAccidenteCondicionSubEstandar objReporte = new rptAccidenteCondicionSubEstandar();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteFactorPersonal(List<ReporteAccidenteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptAccidenteFactorPersonal objReporte = new rptAccidenteFactorPersonal();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteFactorTrabajo(List<ReporteAccidenteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptAccidenteFactorTrabajo objReporte = new rptAccidenteFactorTrabajo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteAccionCorrectiva(List<ReporteAccidenteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptAccidenteAccionCorrectiva objReporte = new rptAccidenteAccionCorrectiva();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteCostoAnualNegocio(List<ReporteAccidenteBE> lstReporte)
        {
            rptAccidenteCostoAnualNegocio objReporte = new rptAccidenteCostoAnualNegocio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteCostoAnualEmpresa(List<ReporteAccidenteBE> lstReporte)
        {
            rptAccidenteCostoAnualEmpresa objReporte = new rptAccidenteCostoAnualEmpresa();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteCostoAnualUnidadMinera(List<ReporteAccidenteBE> lstReporte)
        {
            rptAccidenteCostoAnualUnidadMinera objReporte = new rptAccidenteCostoAnualUnidadMinera();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteCantidadAnualNegocio(List<ReporteAccidenteBE> lstReporte)
        {
            rptAccidenteCantidadAnualNegocio objReporte = new rptAccidenteCantidadAnualNegocio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteCantidadAnualEmpresa(List<ReporteAccidenteBE> lstReporte)
        {
            rptAccidenteCantidadAnualEmpresa objReporte = new rptAccidenteCantidadAnualEmpresa();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteCantidadAnualUnidadMinera(List<ReporteAccidenteBE> lstReporte)
        {
            rptAccidenteCantidadAnualUnidadMinera objReporte = new rptAccidenteCantidadAnualUnidadMinera();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteCostoMensualNegocio(List<ReporteAccidenteBE> lstReporte)
        {
            rptAccidenteCostoMensualNegocio objReporte = new rptAccidenteCostoMensualNegocio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteCostoMensualEmpresa(List<ReporteAccidenteBE> lstReporte)
        {
            rptAccidenteCostoMensualEmpresa objReporte = new rptAccidenteCostoMensualEmpresa();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteCostoMensualUnidadMinera(List<ReporteAccidenteBE> lstReporte)
        {
            rptAccidenteCostoMensualUnidadMinera objReporte = new rptAccidenteCostoMensualUnidadMinera();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteCantidadMensualNegocio(List<ReporteAccidenteBE> lstReporte)
        {
            rptAccidenteCantidadMensualNegocio objReporte = new rptAccidenteCantidadMensualNegocio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteCantidadMensualEmpresa(List<ReporteAccidenteBE> lstReporte)
        {
            rptAccidenteCantidadMensualEmpresa objReporte = new rptAccidenteCantidadMensualEmpresa();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteCantidadMensualUnidadMinera(List<ReporteAccidenteBE> lstReporte)
        {
            rptAccidenteCantidadMensualUnidadMinera objReporte = new rptAccidenteCantidadMensualUnidadMinera();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInspeccionTrabajo(List<ReporteInspeccionTrabajoBE> lstReporte)
        {
            rptInspeccionTrabajo objReporte = new rptInspeccionTrabajo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInspeccionTrabajoSituacion(List<ReporteInspeccionTrabajoBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptInspeccionTrabajoSituacion objReporte = new rptInspeccionTrabajoSituacion();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInspeccionTrabajoSituacionSede(List<ReporteInspeccionTrabajoBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptInspeccionTrabajoSituacionSede objReporte = new rptInspeccionTrabajoSituacionSede();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInspeccionTrabajoTipoFecha(List<ReporteInspeccionTrabajoBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptInspeccionTrabajoTipoFecha objReporte = new rptInspeccionTrabajoTipoFecha();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInspeccionTrabajoSituacionAnualEmpresa(List<ReporteInspeccionTrabajoBE> lstReporte)
        {
            rptInspeccionTrabajoSituacionAnualEmpresa objReporte = new rptInspeccionTrabajoSituacionAnualEmpresa();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInspeccionTrabajoSituacionMensualEmpresa(List<ReporteInspeccionTrabajoBE> lstReporte)
        {
            rptInspeccionTrabajoSituacionMensualEmpresa objReporte = new rptInspeccionTrabajoSituacionMensualEmpresa();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInspeccionTrabajoSituacionAnualSede(List<ReporteInspeccionTrabajoBE> lstReporte)
        {
            rptInspeccionTrabajoSituacionAnualSede objReporte = new rptInspeccionTrabajoSituacionAnualSede();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInspeccionTrabajoSituacionMensualSede(List<ReporteInspeccionTrabajoBE> lstReporte)
        {
            rptInspeccionTrabajoSituacionMensualSede objReporte = new rptInspeccionTrabajoSituacionMensualSede();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInspeccionTrabajoConsolidado(List<ReporteInspeccionTrabajoBE> lstReporte)
        {
            rptInspeccionTrabajoConsolidado objReporte = new rptInspeccionTrabajoConsolidado();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInspeccionTrabajoSituacionAnualEmpresaContratista(List<ReporteInspeccionTrabajoBE> lstReporte)
        {
            rptInspeccionTrabajoSituacionAnualEmpresaContratista objReporte = new rptInspeccionTrabajoSituacionAnualEmpresaContratista();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInspeccionTrabajoTipoFechaEmpresaContratista(List<ReporteInspeccionTrabajoBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptInspeccionTrabajoTipoFechaEmpresaContratista objReporte = new rptInspeccionTrabajoTipoFechaEmpresaContratista();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInspeccionTrabajoSituacionEmpresaContratista(List<ReporteInspeccionTrabajoBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptInspeccionTrabajoSituacionEmpresaContratista objReporte = new rptInspeccionTrabajoSituacionEmpresaContratista();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptExtintorVencido(List<ReporteExtintorBE> lstReporte)
        {
            rptExtintorVencido objReporte = new rptExtintorVencido();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptExtintorUbicacion(List<ReporteExtintorBE> lstReporte)
        {
            rptExtintorUbicacion objReporte = new rptExtintorUbicacion();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }
        public void VerRptExtintorServicio(List<ReporteExtintorServicioBE> lstReporte)
        {
            rptExtintorServicio objReporte = new rptExtintorServicio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptDocumento(List<ReporteDocumentoBE> lstReporte)
        {
            rptDocumento objReporte = new rptDocumento();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptDocumentoPersona(List<ReporteDocumentoPersonaBE> lstReporte)
        {
            rptDocumentoPersona objReporte = new rptDocumentoPersona();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSolicitudFecha(List<ReporteSolicitudBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptSolicitudFecha objReporte = new rptSolicitudFecha();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSeguroViajeFecha(List<ReporteSeguroViajeBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptSeguroViajeFecha objReporte = new rptSeguroViajeFecha();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSeguroSctrFecha(List<ReporteSeguroSctrBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptSeguroSctrFecha objReporte = new rptSeguroSctrFecha();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteCostoAnualEmpresaContratista(List<ReporteAccidenteBE> lstReporte)
        {
            rptAccidenteCostoAnualEmpresaContratista objReporte = new rptAccidenteCostoAnualEmpresaContratista();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAccidenteCantidadAnualEmpresaContratista(List<ReporteAccidenteBE> lstReporte)
        {
            rptAccidenteCantidadAnualEmpresaContratista objReporte = new rptAccidenteCantidadAnualEmpresaContratista();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        #endregion
    }
}