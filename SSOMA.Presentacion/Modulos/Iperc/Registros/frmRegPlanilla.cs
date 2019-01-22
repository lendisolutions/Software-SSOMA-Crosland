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
using SSOMA.Presentacion.Modulos.Otros;

namespace SSOMA.Presentacion.Modulos.Iperc.Registros
{
    public partial class frmRegPlanilla : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CPlanilla> mLista = new List<CPlanilla>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int intIdEmpresa = 0;
        int intIdUnidadMinera = 0;
        int intIdArea = 0;
        int intIdSector = 0;
        int intIdActividad = 0;
        int intIdPeligro = 0;

        #endregion

        #region "Eventos"

        public frmRegPlanilla()
        {
            InitializeComponent();
            gcIndicePersona.Caption = "Indice de Personas \n Expuestas";
            gcIndiceProcedimiento.Caption = "Indice de Procedimientos \n de Trabajo";
            gcIndiceCapacitacion.Caption = "Indice de Capacitacion y \n Entranamiento";
            gcIndiceFrecuencia.Caption = "Indice de Frecuencia \n de Exposición";
            gcSeveridad.Caption = "Consecuencia \n (Severidad)";
            gcValoracionRiesgo.Caption = "Valoración \n del Riesgo";
            gcCalificacionRiesgo.Caption = "Calificación \n del Riesgo";
            gcTratamiento.Caption = "Tratamiento, Control o Aislamiento \n de los Peligros y Riesgos";
            gcControlAdministrativo.Caption = "Señalización, Advertencia y/o \n Controles Administrativo";
            gcIndicePersonaRR.Caption = "Indice de Personas \n Expuestas";
            gcIndiceProcedimientoRR.Caption = "Indice de Procedimientos \n de Trabajo";
            gcIndiceCapacitacionRR.Caption = "Indice de Capacitacion y \n Entranamiento";
            gcIndiceFrecuenciaRR.Caption = "Indice de Frecuencia \n de Exposición";
            gcSeveridadRR.Caption = "Consecuencia \n (Severidad)";
            gcValoracionRiesgoRR.Caption = "Valoración \n del Riesgo";
            gcCalificacionRiesgoRR.Caption = "Calificación \n del Riesgo";
        }

        private void frmRegPlanilla_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargaTreeview();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                pOperacion = Operacion.Nuevo;

                if (intIdEmpresa == 0)
                {
                    XtraMessageBox.Show("Debe especificar, una empresa.", this.Text);
                    return;
                }

                if (intIdUnidadMinera == 0)
                {
                    XtraMessageBox.Show("Debe especificar, una sede.", this.Text);
                    return;
                }

                if (intIdArea == 0)
                {
                    XtraMessageBox.Show("Debe especificar, una area.", this.Text);
                    return;
                }

                if (intIdSector == 0)
                {
                    XtraMessageBox.Show("Debe especificar, una sector.", this.Text);
                    return;
                }

                gvPlanilla.AddNewRow();
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "IdEmpresa", intIdEmpresa);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "IdPlanilla", 0);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "IdUnidadMinera", intIdUnidadMinera);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "IdArea", intIdArea);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "IdSector", intIdSector);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "IdActividad", 0);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "DescActividad", "");
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "FlagRutinaria", false);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "FlagNoRutinaria", false);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "FlagEmergencia", false);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "FlagPropio", false);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "FlagTercero", false);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "IdPeligro", 0);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "DescPeligro", "");
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "DetallePeligro", "");
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "TipoPeligro", "");
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "DescRiesgo", "");
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "IndicePersona", 0);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "IndiceProcedimiento", 0);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "IndiceCapacitacion", 0);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "IndiceFrecuencia", 0);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "Severidad", 1);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "ValoracionRiesgo", 0);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "CalificacionRiesgo", "");
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "Significativo", "");
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "Eliminacion", "");
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "Situacion", "");
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "Tratamiento", "");
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "ControlAdministrativo", "");
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "EquipoProteccion", "");
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "Responsable", "");
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "IndicePersonaRR", 0);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "IndiceProcedimientoRR", 0);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "IndiceCapacitacionRR", 0);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "IndiceFrecuenciaRR", 0);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "SeveridadRR", 1);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "ValoracionRiesgoRR", 0);
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "CalificacionRiesgoRR", "");
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "SignificativoRR", "");
                gvPlanilla.SetRowCellValue(gvPlanilla.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvPlanilla.FocusedColumn = gvPlanilla.Columns["DescActividad"];
                gvPlanilla.ShowEditor();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_EditClick()
        {

        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarEliminacion())
                    {
                        PlanillaBE objE_Planilla = new PlanillaBE();
                        objE_Planilla.IdPlanilla = int.Parse(gvPlanilla.GetFocusedRowCellValue("IdPlanilla").ToString());
                        objE_Planilla.Usuario = Parametros.strUsuarioLogin;
                        objE_Planilla.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Planilla.IdEmpresa = Parametros.intEmpresaId;

                        PlanillaBL objBL_Area = new PlanillaBL();
                        objBL_Area.Elimina(objE_Planilla);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
                        Cargar();
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    List<ReporteAreaElementoBE> lstReporte = null;
            //    lstReporte = new ReporteAreaElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRpPlanillaElemento = new RptVistaReportes();
            //            objRpPlanillaElemento.VerRpPlanillaElemento(lstReporte);
            //            objRpPlanillaElemento.ShowDialog();
            //        }
            //        else
            //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPlanilla";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPlanilla.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "EMP":
                    intIdEmpresa = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    break;
                case "UMM":
                    intIdUnidadMinera = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaTreeviewAreas(e.Node);
                    break;
                case "ARE":
                    intIdArea = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaTreeviewSectores(e.Node);
                    break;
                case "SEC":
                    intIdSector = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Cargar();
                    break;
            }
        }

        private void btnGrabarPlanilla_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    //Registro Planilla
                    List<PlanillaBE> lstPlanilla = new List<PlanillaBE>();

                    PlanillaBL objBL_Planilla = new PlanillaBL();
                    PlanillaBE objPlanilla = new PlanillaBE();

                    foreach (var item in mLista)
                    {
                        PlanillaBE objE_PlanillaDetalle = new PlanillaBE();
                        objE_PlanillaDetalle.IdPlanilla = item.IdPlanilla;
                        objE_PlanillaDetalle.IdEmpresa = item.IdEmpresa;
                        objE_PlanillaDetalle.IdUnidadMinera = item.IdUnidadMinera;
                        objE_PlanillaDetalle.IdArea = item.IdArea;
                        objE_PlanillaDetalle.IdSector = item.IdSector;
                        objE_PlanillaDetalle.IdActividad = item.IdActividad;
                        objE_PlanillaDetalle.FlagRutinaria = item.FlagRutinaria;
                        objE_PlanillaDetalle.FlagNoRutinaria = item.FlagNoRutinaria;
                        objE_PlanillaDetalle.FlagEmergencia = item.FlagEmergencia;
                        objE_PlanillaDetalle.FlagPropio = item.FlagPropio;
                        objE_PlanillaDetalle.FlagTercero = item.FlagTercero;
                        objE_PlanillaDetalle.IdPeligro = item.IdPeligro;
                        objE_PlanillaDetalle.DetallePeligro = item.DetallePeligro;
                        objE_PlanillaDetalle.TipoPeligro = item.TipoPeligro;
                        objE_PlanillaDetalle.DescRiesgo = item.DescRiesgo;
                        objE_PlanillaDetalle.IndicePersona = item.IndicePersona;
                        objE_PlanillaDetalle.IndiceProcedimiento = item.IndiceProcedimiento;
                        objE_PlanillaDetalle.IndiceCapacitacion = item.IndiceCapacitacion;
                        objE_PlanillaDetalle.IndiceFrecuencia = item.IndiceFrecuencia;
                        objE_PlanillaDetalle.Severidad = item.Severidad;
                        objE_PlanillaDetalle.ValoracionRiesgo = item.ValoracionRiesgo;
                        objE_PlanillaDetalle.CalificacionRiesgo = item.CalificacionRiesgo;
                        objE_PlanillaDetalle.Significativo = item.Significativo;
                        objE_PlanillaDetalle.Eliminacion = item.Eliminacion;
                        objE_PlanillaDetalle.Situacion = item.Situacion;
                        objE_PlanillaDetalle.Tratamiento = item.Tratamiento;
                        objE_PlanillaDetalle.ControlAdministrativo = item.ControlAdministrativo;
                        objE_PlanillaDetalle.EquipoProteccion = item.EquipoProteccion;
                        objE_PlanillaDetalle.Responsable = item.Responsable;
                        objE_PlanillaDetalle.IndicePersonaRR = item.IndicePersonaRR;
                        objE_PlanillaDetalle.IndiceProcedimientoRR = item.IndiceProcedimientoRR;
                        objE_PlanillaDetalle.IndiceCapacitacionRR = item.IndiceCapacitacionRR;
                        objE_PlanillaDetalle.IndiceFrecuenciaRR = item.IndiceFrecuenciaRR;
                        objE_PlanillaDetalle.SeveridadRR = item.SeveridadRR;
                        objE_PlanillaDetalle.ValoracionRiesgoRR = item.ValoracionRiesgoRR;
                        objE_PlanillaDetalle.CalificacionRiesgoRR = item.CalificacionRiesgoRR;
                        objE_PlanillaDetalle.SignificativoRR = item.SignificativoRR;
                        objE_PlanillaDetalle.FlagEstado = true;
                        objE_PlanillaDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_PlanillaDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_PlanillaDetalle.TipoOper = item.TipoOper;
                        lstPlanilla.Add(objE_PlanillaDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_Planilla.Inserta(lstPlanilla);
                    }
                    else
                    {
                        objBL_Planilla.Actualiza(lstPlanilla);
                    }

                    //Actualiza la grilla
                    
                    Cargar();

                    Cursor = Cursors.Default;
                }
            }

            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtActividad_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBuscaActividad objBusca = new frmBuscaActividad();
                    objBusca.intIdEmpresa = intIdEmpresa;
                    objBusca.intIdUnidadMinera = intIdUnidadMinera;
                    objBusca.intIdArea = intIdArea;
                    objBusca.intIdSector = intIdSector;
                    objBusca.ShowDialog();
                    if (objBusca.pActividadBE != null)
                    {
                        int index = gvPlanilla.FocusedRowHandle;
                        gvPlanilla.SetRowCellValue(index, "IdActividad", objBusca.pActividadBE.IdActividad);
                        gvPlanilla.SetRowCellValue(index, "DescActividad", objBusca.pActividadBE.DescActividad);

                    }

                    gvPlanilla.FocusedColumn = gvPlanilla.Columns["Peligro"];
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtDescPeligro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmBuscaPeligro objBusca = new frmBuscaPeligro();
                objBusca.ShowDialog();
                if (objBusca.pPeligroBE != null)
                {
                    int index = gvPlanilla.FocusedRowHandle;
                    gvPlanilla.SetRowCellValue(index, "IdPeligro", objBusca.pPeligroBE.IdPeligro);
                    gvPlanilla.SetRowCellValue(index, "DescPeligro", objBusca.pPeligroBE.DescPeligro);
                    gvPlanilla.SetRowCellValue(index, "TipoPeligro", objBusca.pPeligroBE.DescTipoPeligro);

                }

                gvPlanilla.FocusedColumn = gvPlanilla.Columns["DetallePeligro"];
            }
        }

        private void gcTxtRiesgo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmBuscaRiesgo objBusca = new frmBuscaRiesgo();
                objBusca.ShowDialog();
                if (objBusca.strRiesgo != "")
                {
                    int index = gvPlanilla.FocusedRowHandle;
                    gvPlanilla.SetRowCellValue(index, "DescRiesgo", objBusca.strRiesgo);
                    
                }

                gvPlanilla.FocusedColumn = gvPlanilla.Columns["IndicePersona"];
            }
        }

        private void gcTxtIndicePersona_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBuscaProbabilidad objBusca = new frmBuscaProbabilidad();
                    objBusca.ShowDialog();
                    if (objBusca.pProbabilidadBE != null)
                    {
                        int index = gvPlanilla.FocusedRowHandle;
                        gvPlanilla.SetRowCellValue(index, "IndicePersona", objBusca.pProbabilidadBE.ValorProbabilidad);

                    }

                    gvPlanilla.FocusedColumn = gvPlanilla.Columns["IndiceProcedimiento"];
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtIndiceProcedimiento_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBuscaProbabilidad objBusca = new frmBuscaProbabilidad();
                    objBusca.ShowDialog();
                    if (objBusca.pProbabilidadBE != null)
                    {
                        int index = gvPlanilla.FocusedRowHandle;
                        gvPlanilla.SetRowCellValue(index, "IndiceProcedimiento", objBusca.pProbabilidadBE.ValorProbabilidad);

                    }

                    gvPlanilla.FocusedColumn = gvPlanilla.Columns["IndiceCapacitacion"];
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtIndiceCapacitacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmBuscaProbabilidad objBusca = new frmBuscaProbabilidad();
                objBusca.ShowDialog();
                if (objBusca.pProbabilidadBE != null)
                {
                    int index = gvPlanilla.FocusedRowHandle;
                    gvPlanilla.SetRowCellValue(index, "IndiceCapacitacion", objBusca.pProbabilidadBE.ValorProbabilidad);

                }

                gvPlanilla.FocusedColumn = gvPlanilla.Columns["IndiceFrecuencia"];
            }
        }

        private void gcTxtIndiceFrecuencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmBuscaProbabilidad objBusca = new frmBuscaProbabilidad();
                objBusca.ShowDialog();
                if (objBusca.pProbabilidadBE != null)
                {
                    int index = gvPlanilla.FocusedRowHandle;
                    gvPlanilla.SetRowCellValue(index, "IndiceFrecuencia", objBusca.pProbabilidadBE.ValorProbabilidad);

                }

                gvPlanilla.FocusedColumn = gvPlanilla.Columns["Severidad"];
            }
        }

        private void gcTxtSeveridad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmBuscaSeveridad objBusca = new frmBuscaSeveridad();
                objBusca.ShowDialog();
                if (objBusca.pSeveridadBE != null)
                {
                    int index = gvPlanilla.FocusedRowHandle;
                    gvPlanilla.SetRowCellValue(index, "Severidad", objBusca.pSeveridadBE.ValorSeveridad);

                }

                gvPlanilla.FocusedColumn = gvPlanilla.Columns["Eliminacion"];
            }
        }

        private void gcTxtIndicePersonaRR_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBuscaProbabilidad objBusca = new frmBuscaProbabilidad();
                    objBusca.ShowDialog();
                    if (objBusca.pProbabilidadBE != null)
                    {
                        int index = gvPlanilla.FocusedRowHandle;
                        gvPlanilla.SetRowCellValue(index, "IndicePersonaRR", objBusca.pProbabilidadBE.ValorProbabilidad);

                    }

                    gvPlanilla.FocusedColumn = gvPlanilla.Columns["IndiceProcedimientoRR"];
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtIndiceProcedimientoRR_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBuscaProbabilidad objBusca = new frmBuscaProbabilidad();
                    objBusca.ShowDialog();
                    if (objBusca.pProbabilidadBE != null)
                    {
                        int index = gvPlanilla.FocusedRowHandle;
                        gvPlanilla.SetRowCellValue(index, "IndiceProcedimientoRR", objBusca.pProbabilidadBE.ValorProbabilidad);

                    }

                    gvPlanilla.FocusedColumn = gvPlanilla.Columns["IndiceCapacitacionRR"];
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtIndiceCapacitacionRR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmBuscaProbabilidad objBusca = new frmBuscaProbabilidad();
                objBusca.ShowDialog();
                if (objBusca.pProbabilidadBE != null)
                {
                    int index = gvPlanilla.FocusedRowHandle;
                    gvPlanilla.SetRowCellValue(index, "IndiceCapacitacionRR", objBusca.pProbabilidadBE.ValorProbabilidad);

                }

                gvPlanilla.FocusedColumn = gvPlanilla.Columns["IndiceFrecuenciaRR"];
            }
        }

        private void gcTxtIndiceFrecuenciaRR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmBuscaProbabilidad objBusca = new frmBuscaProbabilidad();
                objBusca.ShowDialog();
                if (objBusca.pProbabilidadBE != null)
                {
                    int index = gvPlanilla.FocusedRowHandle;
                    gvPlanilla.SetRowCellValue(index, "IndiceFrecuenciaRR", objBusca.pProbabilidadBE.ValorProbabilidad);

                }

                gvPlanilla.FocusedColumn = gvPlanilla.Columns["SeveridadRR"];
            }
        }

        private void gcTxtSeveridadRR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmBuscaSeveridad objBusca = new frmBuscaSeveridad();
                objBusca.ShowDialog();
                if (objBusca.pSeveridadBE != null)
                {
                    int index = gvPlanilla.FocusedRowHandle;
                    gvPlanilla.SetRowCellValue(index, "SeveridadRR", objBusca.pSeveridadBE.ValorSeveridad);

                }

                
            }
        }

        private void gcTxtResponsable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmBusPersona objBusca = new frmBusPersona();
                objBusca.pFlagTodoPersonal = false;
                objBusca.ShowDialog();
                if (objBusca.pPersonaBE != null)
                {
                    int index = gvPlanilla.FocusedRowHandle;
                    gvPlanilla.SetRowCellValue(index, "Responsable", objBusca.pPersonaBE.Cargo);

                }


            }
        }

        private void gcTxtEliminacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmBuscaEliminacion objBusca = new frmBuscaEliminacion();
                objBusca.ShowDialog();
                if (objBusca.strEliminacion != "")
                {
                    int index = gvPlanilla.FocusedRowHandle;
                    gvPlanilla.SetRowCellValue(index, "Eliminacion", objBusca.strEliminacion);

                }

                gvPlanilla.FocusedColumn = gvPlanilla.Columns["Situacion"];
            }
        }

        private void gcTxtSituacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmBuscaSustitucion objBusca = new frmBuscaSustitucion();
                objBusca.ShowDialog();
                if (objBusca.strSustitucion != "")
                {
                    int index = gvPlanilla.FocusedRowHandle;
                    gvPlanilla.SetRowCellValue(index, "Situacion", objBusca.strSustitucion);

                }

                gvPlanilla.FocusedColumn = gvPlanilla.Columns["Tratamiento"];
            }
        }

        private void gcTxtTratamiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmBuscaTratamiento objBusca = new frmBuscaTratamiento();
                objBusca.ShowDialog();
                if (objBusca.strTratamiento != "")
                {
                    int index = gvPlanilla.FocusedRowHandle;
                    gvPlanilla.SetRowCellValue(index, "Tratamiento", objBusca.strTratamiento);

                }

                gvPlanilla.FocusedColumn = gvPlanilla.Columns["ControlAdministrativo"];
            }
        }

        private void gcTxtControlAdministrativo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmBuscaSenalizacion objBusca = new frmBuscaSenalizacion();
                objBusca.ShowDialog();
                if (objBusca.strSenalizacion != "")
                {
                    int index = gvPlanilla.FocusedRowHandle;
                    gvPlanilla.SetRowCellValue(index, "ControlAdministrativo", objBusca.strSenalizacion);

                }

                gvPlanilla.FocusedColumn = gvPlanilla.Columns["EquipoProteccion"];
            }
        }

        private void gcTxtEquipoProteccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmBuscaEquipoProteccion objBusca = new frmBuscaEquipoProteccion();
                objBusca.ShowDialog();
                if (objBusca.strEquipoProteccion != "")
                {
                    int index = gvPlanilla.FocusedRowHandle;
                    gvPlanilla.SetRowCellValue(index, "EquipoProteccion", objBusca.strEquipoProteccion);

                }

                gvPlanilla.FocusedColumn = gvPlanilla.Columns["Responsable"];
            }
        }

        private void gvPlanilla_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int intIndicePersona = 0;
            int intIndiceProcedimiento = 0;
            int intIndiceCapacitacion = 0;
            int intIndiceFrecuencia = 0;
            int intSeveridad = 1;
            int intValoracionRiesgo = 0;
            string strCalificacionRiesgo = "";
            string strSignificativo = "";

            //------------------------------------
            int intIndicePersonaRR = 0;
            int intIndiceProcedimientoRR = 0;
            int intIndiceCapacitacionRR = 0;
            int intIndiceFrecuenciaRR = 0;
            int intSeveridadRR = 1;
            int intValoracionRiesgoRR = 0;
            string strCalificacionRiesgoRR = "";
            string strSignificativoRR = "";


            if (e.Column.FieldName == "IndicePersona")
            {
                if (int.Parse(e.Value.ToString()) > 0)
                {
                    intIndicePersona = int.Parse(e.Value.ToString());
                    intIndiceProcedimiento = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceProcedimiento"]).ToString());
                    intIndiceCapacitacion = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceCapacitacion"]).ToString());
                    intIndiceFrecuencia = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceFrecuencia"]).ToString());
                    intSeveridad = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["Severidad"]).ToString());
                    intValoracionRiesgo = (intIndicePersona + intIndiceProcedimiento + intIndiceCapacitacion + intIndiceFrecuencia) * intSeveridad;
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["ValoracionRiesgo"], intValoracionRiesgo);

                    if (intValoracionRiesgo == 4)
                    {
                        strCalificacionRiesgo = "TRIVIAL";
                    }

                    if (intValoracionRiesgo >= 5 && intValoracionRiesgo <= 16)
                    {
                        strCalificacionRiesgo = "TOLERABLE";
                    }

                    if (intValoracionRiesgo >= 17 && intValoracionRiesgo <= 36)
                    {
                        strCalificacionRiesgo = "MODERADO";
                    }

                    if (intValoracionRiesgo >= 37 && intValoracionRiesgo <= 60)
                    {
                        strCalificacionRiesgo = "ALTO RIESGO";
                    }

                    if (intValoracionRiesgo > 60)
                    {
                        strCalificacionRiesgo = "INACEPTABLE";
                    }

                    if (intValoracionRiesgo <= 37)
                    {
                        strSignificativo = "NO SIGNIFICATIVO";
                    }
                    else
                    {
                        strSignificativo = "SIGNIFICATIVO";
                    }

                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["CalificacionRiesgo"], strCalificacionRiesgo);
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["Significativo"], strSignificativo);
                }
            }

            if (e.Column.FieldName == "IndiceProcedimiento")
            {
                if (int.Parse(e.Value.ToString()) > 0)
                {
                    intIndicePersona = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndicePersona"]).ToString());
                    intIndiceProcedimiento = int.Parse(e.Value.ToString());
                    intIndiceCapacitacion = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceCapacitacion"]).ToString());
                    intIndiceFrecuencia = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceFrecuencia"]).ToString());
                    intSeveridad = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["Severidad"]).ToString());
                    intValoracionRiesgo = (intIndicePersona + intIndiceProcedimiento + intIndiceCapacitacion + intIndiceFrecuencia) * intSeveridad;
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["ValoracionRiesgo"], intValoracionRiesgo);

                    if (intValoracionRiesgo == 4)
                    {
                        strCalificacionRiesgo = "TRIVIAL";
                    }

                    if (intValoracionRiesgo >= 5 && intValoracionRiesgo <= 16)
                    {
                        strCalificacionRiesgo = "TOLERABLE";
                    }

                    if (intValoracionRiesgo >= 17 && intValoracionRiesgo <= 36)
                    {
                        strCalificacionRiesgo = "MODERADO";
                    }

                    if (intValoracionRiesgo >= 37 && intValoracionRiesgo <= 60)
                    {
                        strCalificacionRiesgo = "ALTO RIESGO";
                    }

                    if (intValoracionRiesgo > 60)
                    {
                        strCalificacionRiesgo = "INACEPTABLE";
                    }

                    if (intValoracionRiesgo < 36)
                    {
                        strSignificativo = "NO SIGNIFICATIVO";
                    }
                    else
                    {
                        strSignificativo = "SIGNIFICATIVO";
                    }

                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["CalificacionRiesgo"], strCalificacionRiesgo);
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["Significativo"], strSignificativo);
                }
            }

            if (e.Column.FieldName == "IndiceCapacitacion")
            {
                if (int.Parse(e.Value.ToString()) > 0)
                {
                    intIndicePersona = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndicePersona"]).ToString());
                    intIndiceProcedimiento = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceProcedimiento"]).ToString());
                    intIndiceCapacitacion = int.Parse(e.Value.ToString());
                    intIndiceFrecuencia = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceFrecuencia"]).ToString());
                    intSeveridad = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["Severidad"]).ToString());
                    intValoracionRiesgo = (intIndicePersona + intIndiceProcedimiento + intIndiceCapacitacion + intIndiceFrecuencia) * intSeveridad;
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["ValoracionRiesgo"], intValoracionRiesgo);

                    if (intValoracionRiesgo == 4)
                    {
                        strCalificacionRiesgo = "TRIVIAL";
                    }

                    if (intValoracionRiesgo >= 5 && intValoracionRiesgo <= 16)
                    {
                        strCalificacionRiesgo = "TOLERABLE";
                    }

                    if (intValoracionRiesgo >= 17 && intValoracionRiesgo <= 36)
                    {
                        strCalificacionRiesgo = "MODERADO";
                    }

                    if (intValoracionRiesgo >= 37 && intValoracionRiesgo <= 60)
                    {
                        strCalificacionRiesgo = "ALTO RIESGO";
                    }

                    if (intValoracionRiesgo > 60)
                    {
                        strCalificacionRiesgo = "INACEPTABLE";
                    }

                    if (intValoracionRiesgo < 36)
                    {
                        strSignificativo = "NO SIGNIFICATIVO";
                    }
                    else
                    {
                        strSignificativo = "SIGNIFICATIVO";
                    }

                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["CalificacionRiesgo"], strCalificacionRiesgo);
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["Significativo"], strSignificativo);
                }
            }

            if (e.Column.FieldName == "IndiceFrecuencia")
            {
                if (int.Parse(e.Value.ToString()) > 0)
                {
                    intIndicePersona = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndicePersona"]).ToString());
                    intIndiceProcedimiento = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceProcedimiento"]).ToString());
                    intIndiceCapacitacion = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceCapacitacion"]).ToString());
                    intIndiceFrecuencia = int.Parse(e.Value.ToString());
                    intSeveridad = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["Severidad"]).ToString());
                    intValoracionRiesgo = (intIndicePersona + intIndiceProcedimiento + intIndiceCapacitacion + intIndiceFrecuencia) * intSeveridad;
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["ValoracionRiesgo"], intValoracionRiesgo);

                    if (intValoracionRiesgo == 4)
                    {
                        strCalificacionRiesgo = "TRIVIAL";
                    }

                    if (intValoracionRiesgo >= 5 && intValoracionRiesgo <= 16)
                    {
                        strCalificacionRiesgo = "TOLERABLE";
                    }

                    if (intValoracionRiesgo >= 17 && intValoracionRiesgo <= 36)
                    {
                        strCalificacionRiesgo = "MODERADO";
                    }

                    if (intValoracionRiesgo >= 37 && intValoracionRiesgo <= 60)
                    {
                        strCalificacionRiesgo = "ALTO RIESGO";
                    }

                    if (intValoracionRiesgo > 60)
                    {
                        strCalificacionRiesgo = "INACEPTABLE";
                    }

                    if (intValoracionRiesgo < 36)
                    {
                        strSignificativo = "NO SIGNIFICATIVO";
                    }
                    else
                    {
                        strSignificativo = "SIGNIFICATIVO";
                    }

                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["CalificacionRiesgo"], strCalificacionRiesgo);
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["Significativo"], strSignificativo);
                }
            }

            if (e.Column.FieldName == "Severidad")
            {
                if (int.Parse(e.Value.ToString()) > 0)
                {
                    intIndicePersona = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndicePersona"]).ToString());
                    intIndiceProcedimiento = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceProcedimiento"]).ToString());
                    intIndiceCapacitacion = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceCapacitacion"]).ToString());
                    intIndiceFrecuencia = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceFrecuencia"]).ToString());
                    intSeveridad = int.Parse(e.Value.ToString());
                    intValoracionRiesgo = (intIndicePersona + intIndiceProcedimiento + intIndiceCapacitacion + intIndiceFrecuencia) * intSeveridad;
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["ValoracionRiesgo"], intValoracionRiesgo);

                    if (intValoracionRiesgo == 4)
                    {
                        strCalificacionRiesgo = "TRIVIAL";
                    }

                    if (intValoracionRiesgo >= 5 && intValoracionRiesgo <= 16)
                    {
                        strCalificacionRiesgo = "TOLERABLE";
                    }

                    if (intValoracionRiesgo >= 17 && intValoracionRiesgo <= 36)
                    {
                        strCalificacionRiesgo = "MODERADO";
                    }

                    if (intValoracionRiesgo >= 37 && intValoracionRiesgo <= 60)
                    {
                        strCalificacionRiesgo = "ALTO RIESGO";
                    }

                    if (intValoracionRiesgo > 60)
                    {
                        strCalificacionRiesgo = "INACEPTABLE";
                    }

                    if (intValoracionRiesgo < 36)
                    {
                        strSignificativo = "NO SIGNIFICATIVO";
                    }
                    else
                    {
                        strSignificativo = "SIGNIFICATIVO";
                    }

                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["CalificacionRiesgo"], strCalificacionRiesgo);
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["Significativo"], strSignificativo);
                }
            }

            //********************************************************RIESGO RESIDUAL*****************************************************************
            if (e.Column.FieldName == "IndicePersonaRR")
            {
                if (int.Parse(e.Value.ToString()) > 0)
                {
                    intIndicePersonaRR = int.Parse(e.Value.ToString());
                    intIndiceProcedimientoRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceProcedimientoRR"]).ToString());
                    intIndiceCapacitacionRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceCapacitacionRR"]).ToString());
                    intIndiceFrecuenciaRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceFrecuenciaRR"]).ToString());
                    intSeveridadRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["SeveridadRR"]).ToString());
                    intValoracionRiesgoRR = (intIndicePersonaRR + intIndiceProcedimientoRR + intIndiceCapacitacionRR + intIndiceFrecuenciaRR) * intSeveridadRR;
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["ValoracionRiesgoRR"], intValoracionRiesgoRR);

                    if (intValoracionRiesgoRR == 4)
                    {
                        strCalificacionRiesgoRR = "TRIVIAL";
                    }

                    if (intValoracionRiesgoRR >= 5 && intValoracionRiesgoRR <= 16)
                    {
                        strCalificacionRiesgoRR = "TOLERABLE";
                    }

                    if (intValoracionRiesgoRR >= 17 && intValoracionRiesgoRR <= 36)
                    {
                        strCalificacionRiesgoRR = "MODERADO";
                    }

                    if (intValoracionRiesgoRR >= 37 && intValoracionRiesgoRR <= 60)
                    {
                        strCalificacionRiesgoRR = "ALTO RIESGO";
                    }

                    if (intValoracionRiesgoRR > 60)
                    {
                        strCalificacionRiesgoRR = "INACEPTABLE";
                    }

                    if (intValoracionRiesgoRR < 36)
                    {
                        strSignificativoRR = "NO SignificativoRR";
                    }
                    else
                    {
                        strSignificativoRR = "SignificativoRR";
                    }

                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["CalificacionRiesgoRR"], strCalificacionRiesgoRR);
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["SignificativoRR"], strSignificativoRR);
                }
            }

            if (e.Column.FieldName == "IndiceProcedimientoRR")
            {
                if (int.Parse(e.Value.ToString()) > 0)
                {
                    intIndicePersonaRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndicePersonaRR"]).ToString());
                    intIndiceProcedimientoRR = int.Parse(e.Value.ToString());
                    intIndiceCapacitacionRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceCapacitacionRR"]).ToString());
                    intIndiceFrecuenciaRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceFrecuenciaRR"]).ToString());
                    intSeveridadRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["SeveridadRR"]).ToString());
                    intValoracionRiesgoRR = (intIndicePersonaRR + intIndiceProcedimientoRR + intIndiceCapacitacionRR + intIndiceFrecuenciaRR) * intSeveridadRR;
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["ValoracionRiesgoRR"], intValoracionRiesgoRR);

                    if (intValoracionRiesgoRR == 4)
                    {
                        strCalificacionRiesgoRR = "TRIVIAL";
                    }

                    if (intValoracionRiesgoRR >= 5 && intValoracionRiesgoRR <= 16)
                    {
                        strCalificacionRiesgoRR = "TOLERABLE";
                    }

                    if (intValoracionRiesgoRR >= 17 && intValoracionRiesgoRR <= 36)
                    {
                        strCalificacionRiesgoRR = "MODERADO";
                    }

                    if (intValoracionRiesgoRR >= 37 && intValoracionRiesgoRR <= 60)
                    {
                        strCalificacionRiesgoRR = "ALTO RIESGO";
                    }

                    if (intValoracionRiesgoRR > 60)
                    {
                        strCalificacionRiesgoRR = "INACEPTABLE";
                    }

                    if (intValoracionRiesgoRR < 36)
                    {
                        strSignificativoRR = "NO SignificativoRR";
                    }
                    else
                    {
                        strSignificativoRR = "SignificativoRR";
                    }

                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["CalificacionRiesgoRR"], strCalificacionRiesgoRR);
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["SignificativoRR"], strSignificativoRR);
                }
            }

            if (e.Column.FieldName == "IndiceCapacitacionRR")
            {
                if (int.Parse(e.Value.ToString()) > 0)
                {
                    intIndicePersonaRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndicePersonaRR"]).ToString());
                    intIndiceProcedimientoRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceProcedimientoRR"]).ToString());
                    intIndiceCapacitacionRR = int.Parse(e.Value.ToString());
                    intIndiceFrecuenciaRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceFrecuenciaRR"]).ToString());
                    intSeveridadRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["SeveridadRR"]).ToString());
                    intValoracionRiesgoRR = (intIndicePersonaRR + intIndiceProcedimientoRR + intIndiceCapacitacionRR + intIndiceFrecuenciaRR) * intSeveridadRR;
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["ValoracionRiesgoRR"], intValoracionRiesgoRR);

                    if (intValoracionRiesgoRR == 4)
                    {
                        strCalificacionRiesgoRR = "TRIVIAL";
                    }

                    if (intValoracionRiesgoRR >= 5 && intValoracionRiesgoRR <= 16)
                    {
                        strCalificacionRiesgoRR = "TOLERABLE";
                    }

                    if (intValoracionRiesgoRR >= 17 && intValoracionRiesgoRR <= 36)
                    {
                        strCalificacionRiesgoRR = "MODERADO";
                    }

                    if (intValoracionRiesgoRR >= 37 && intValoracionRiesgoRR <= 60)
                    {
                        strCalificacionRiesgoRR = "ALTO RIESGO";
                    }

                    if (intValoracionRiesgoRR > 60)
                    {
                        strCalificacionRiesgoRR = "INACEPTABLE";
                    }

                    if (intValoracionRiesgoRR < 36)
                    {
                        strSignificativoRR = "NO SignificativoRR";
                    }
                    else
                    {
                        strSignificativoRR = "SignificativoRR";
                    }

                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["CalificacionRiesgoRR"], strCalificacionRiesgoRR);
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["SignificativoRR"], strSignificativoRR);
                }
            }

            if (e.Column.FieldName == "IndiceFrecuenciaRR")
            {
                if (int.Parse(e.Value.ToString()) > 0)
                {
                    intIndicePersonaRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndicePersonaRR"]).ToString());
                    intIndiceProcedimientoRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceProcedimientoRR"]).ToString());
                    intIndiceCapacitacionRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceCapacitacionRR"]).ToString());
                    intIndiceFrecuenciaRR = int.Parse(e.Value.ToString());
                    intSeveridadRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["SeveridadRR"]).ToString());
                    intValoracionRiesgoRR = (intIndicePersonaRR + intIndiceProcedimientoRR + intIndiceCapacitacionRR + intIndiceFrecuenciaRR) * intSeveridadRR;
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["ValoracionRiesgoRR"], intValoracionRiesgoRR);

                    if (intValoracionRiesgoRR == 4)
                    {
                        strCalificacionRiesgoRR = "TRIVIAL";
                    }

                    if (intValoracionRiesgoRR >= 5 && intValoracionRiesgoRR <= 16)
                    {
                        strCalificacionRiesgoRR = "TOLERABLE";
                    }

                    if (intValoracionRiesgoRR >= 17 && intValoracionRiesgoRR <= 36)
                    {
                        strCalificacionRiesgoRR = "MODERADO";
                    }

                    if (intValoracionRiesgoRR >= 37 && intValoracionRiesgoRR <= 60)
                    {
                        strCalificacionRiesgoRR = "ALTO RIESGO";
                    }

                    if (intValoracionRiesgoRR > 60)
                    {
                        strCalificacionRiesgoRR = "INACEPTABLE";
                    }

                    if (intValoracionRiesgoRR < 36)
                    {
                        strSignificativoRR = "NO SignificativoRR";
                    }
                    else
                    {
                        strSignificativoRR = "SignificativoRR";
                    }

                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["CalificacionRiesgoRR"], strCalificacionRiesgoRR);
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["SignificativoRR"], strSignificativoRR);
                }
            }

            if (e.Column.FieldName == "SeveridadRR")
            {
                if (int.Parse(e.Value.ToString()) > 0)
                {
                    intIndicePersonaRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndicePersonaRR"]).ToString());
                    intIndiceProcedimientoRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceProcedimientoRR"]).ToString());
                    intIndiceCapacitacionRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceCapacitacionRR"]).ToString());
                    intIndiceFrecuenciaRR = int.Parse(gvPlanilla.GetRowCellValue(e.RowHandle, gvPlanilla.Columns["IndiceFrecuenciaRR"]).ToString());
                    intSeveridadRR = int.Parse(e.Value.ToString());
                    intValoracionRiesgoRR = (intIndicePersonaRR + intIndiceProcedimientoRR + intIndiceCapacitacionRR + intIndiceFrecuenciaRR) * intSeveridadRR;
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["ValoracionRiesgoRR"], intValoracionRiesgoRR);

                    if (intValoracionRiesgoRR == 4)
                    {
                        strCalificacionRiesgoRR = "TRIVIAL";
                    }

                    if (intValoracionRiesgoRR >= 5 && intValoracionRiesgoRR <= 16)
                    {
                        strCalificacionRiesgoRR = "TOLERABLE";
                    }

                    if (intValoracionRiesgoRR >= 17 && intValoracionRiesgoRR <= 36)
                    {
                        strCalificacionRiesgoRR = "MODERADO";
                    }

                    if (intValoracionRiesgoRR >= 37 && intValoracionRiesgoRR <= 60)
                    {
                        strCalificacionRiesgoRR = "ALTO RIESGO";
                    }

                    if (intValoracionRiesgoRR > 60)
                    {
                        strCalificacionRiesgoRR = "INACEPTABLE";
                    }

                    if (intValoracionRiesgoRR < 36)
                    {
                        strSignificativoRR = "NO SignificativoRR";
                    }
                    else
                    {
                        strSignificativoRR = "SignificativoRR";
                    }

                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["CalificacionRiesgoRR"], strCalificacionRiesgoRR);
                    gvPlanilla.SetRowCellValue(e.RowHandle, gvPlanilla.Columns["SignificativoRR"], strSignificativoRR);
                }
            }
        }

        private void gvPlanilla_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "CalificacionRiesgo")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["CalificacionRiesgo"]);
                        if (Situacion == "INACEPTABLE")
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "ALTO RIESGO")
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "MODERADO")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "TOLERABLE")
                        {
                            e.Appearance.BackColor = Color.Green;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "TRIVIAL")
                        {
                            e.Appearance.BackColor = Color.Green;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }

                    if (e.Column.FieldName == "CalificacionRiesgoRR")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["CalificacionRiesgoRR"]);
                        if (Situacion == "INACEPTABLE")
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "ALTO RIESGO")
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "MODERADO")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "TOLERABLE")
                        {
                            e.Appearance.BackColor = Color.Green;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "TRIVIAL")
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

        #endregion

        #region "Metodos"

        private void CargaTreeview()
        {
            tvwDatos.Nodes.Clear();

            List<EmpresaBE> lstEmpresa = null;
            lstEmpresa = new EmpresaBL().ListaTodosActivo(0, Parametros.intTECorporativo);
            foreach (var item in lstEmpresa)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = item.RazonSocial;
                nuevoNodo.ImageIndex = 0;
                nuevoNodo.SelectedImageIndex = 0;
                nuevoNodo.Tag = "EMP" + item.IdEmpresa.ToString();
                tvwDatos.Nodes.Add(nuevoNodo);

                List<UnidadMineraBE> lstUnidadMinera = null;
                lstUnidadMinera = new UnidadMineraBL().ListaTodosActivo(item.IdEmpresa);
                foreach (var itemunidad in lstUnidadMinera)
                {
                    TreeNode nuevoNodoChild = new TreeNode();
                    nuevoNodoChild.ImageIndex = 1;
                    nuevoNodoChild.SelectedImageIndex = 1;
                    nuevoNodoChild.Text = itemunidad.DescUnidadMinera;
                    nuevoNodoChild.Tag = "UMM" + itemunidad.IdUnidadMinera.ToString();
                    nuevoNodo.Nodes.Add(nuevoNodoChild);
                }
            }

            tvwDatos.ExpandAll();
        }

        void CargaTreeviewAreas(TreeNode nodo)
        {
            nodo.Nodes.Clear();

            List<AreaBE> lstArea = null;
            lstArea = new AreaBL().ListaTodosActivo(intIdEmpresa, intIdUnidadMinera);
            foreach (var item in lstArea)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 3;
                nuevoNodoChild.SelectedImageIndex = 3;
                nuevoNodoChild.Text = item.DescArea;
                nuevoNodoChild.Tag = "ARE" + item.IdArea.ToString();
                nodo.Nodes.Add(nuevoNodoChild);
            }
        }

        void CargaTreeviewSectores(TreeNode nodo)
        {
            nodo.Nodes.Clear();

            List<SectorBE> lstSector = null;
            lstSector = new SectorBL().ListaTodosActivo(intIdEmpresa, intIdUnidadMinera, intIdArea);
            foreach (var item in lstSector)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 4;
                nuevoNodoChild.SelectedImageIndex = 4;
                nuevoNodoChild.Text = item.DescSector;
                nuevoNodoChild.Tag = "SEC" + item.IdSector.ToString();
                nodo.Nodes.Add(nuevoNodoChild);
            }
        }

        private void Cargar()
        {
            List<PlanillaBE> lstTmpPlanilla = null;
            lstTmpPlanilla = new PlanillaBL().ListaTodosActivo(intIdEmpresa, intIdUnidadMinera, intIdArea, intIdSector, 0);

            mLista.Clear();

            foreach (PlanillaBE item in lstTmpPlanilla)
            {
                CPlanilla objE_Planilla = new CPlanilla();
                objE_Planilla.IdEmpresa = item.IdEmpresa;
                objE_Planilla.IdPlanilla = item.IdPlanilla;
                objE_Planilla.IdUnidadMinera = item.IdUnidadMinera;
                objE_Planilla.IdArea = item.IdArea;
                objE_Planilla.IdSector = item.IdSector;
                objE_Planilla.IdActividad = item.IdActividad;
                objE_Planilla.DescActividad = item.DescActividad;
                objE_Planilla.FlagRutinaria = item.FlagRutinaria;
                objE_Planilla.FlagNoRutinaria = item.FlagNoRutinaria;
                objE_Planilla.FlagEmergencia = item.FlagEmergencia;
                objE_Planilla.FlagPropio = item.FlagPropio;
                objE_Planilla.FlagTercero = item.FlagTercero;
                objE_Planilla.IdPeligro = item.IdPeligro;
                objE_Planilla.DescPeligro = item.DescPeligro;
                objE_Planilla.DetallePeligro = item.DetallePeligro;
                objE_Planilla.TipoPeligro = item.TipoPeligro;
                objE_Planilla.DescRiesgo = item.DescRiesgo;
                objE_Planilla.IndicePersona = item.IndicePersona;
                objE_Planilla.IndiceProcedimiento = item.IndiceProcedimiento;
                objE_Planilla.IndiceCapacitacion = item.IndiceCapacitacion;
                objE_Planilla.IndiceFrecuencia = item.IndiceFrecuencia;
                objE_Planilla.Severidad = item.Severidad;
                objE_Planilla.ValoracionRiesgo = item.ValoracionRiesgo;
                objE_Planilla.CalificacionRiesgo = item.CalificacionRiesgo;
                objE_Planilla.Significativo = item.Significativo;
                objE_Planilla.Eliminacion = item.Eliminacion;
                objE_Planilla.Situacion = item.Situacion;
                objE_Planilla.Tratamiento = item.Tratamiento;
                objE_Planilla.ControlAdministrativo = item.ControlAdministrativo;
                objE_Planilla.EquipoProteccion = item.EquipoProteccion;
                objE_Planilla.Responsable = item.Responsable;
                objE_Planilla.IndicePersonaRR = item.IndicePersonaRR;
                objE_Planilla.IndiceProcedimientoRR = item.IndiceProcedimientoRR;
                objE_Planilla.IndiceCapacitacionRR = item.IndiceCapacitacionRR;
                objE_Planilla.IndiceFrecuenciaRR = item.IndiceFrecuenciaRR;
                objE_Planilla.SeveridadRR = item.SeveridadRR;
                objE_Planilla.ValoracionRiesgoRR = item.ValoracionRiesgoRR;
                objE_Planilla.CalificacionRiesgoRR = item.CalificacionRiesgoRR;
                objE_Planilla.SignificativoRR = item.SignificativoRR;
                objE_Planilla.TipoOper = item.TipoOper;
                mLista.Add(objE_Planilla);
            }

            bsListado.DataSource = mLista;
            gcPlanilla.DataSource = bsListado;
            gcPlanilla.RefreshDataSource();

            pOperacion = Operacion.Consultar;
        }

        private bool ValidarEliminacion()
        {
            bool flag = false;

            if (gvPlanilla.GetFocusedRowCellValue("IdPlanilla").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Planilla", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (intIdEmpresa == 0)
            {
                strMensaje = strMensaje + "- Debe seleccionar una empresa.\n";
                flag = true;
            }

            if (intIdUnidadMinera == 0)
            {
                strMensaje = strMensaje + "- Debe seleccionar una sede.\n";
                flag = true;
            }

            if (intIdArea == 0)
            {
                strMensaje = strMensaje + "- Debe seleccionar una area.\n";
                flag = true;
            }

            if (intIdSector == 0)
            {
                strMensaje = strMensaje + "- Debe seleccionar un sector.\n";
                flag = true;
            }


            if (gvPlanilla.DataRowCount > 0)
            {
                for (int i = 0; i < gvPlanilla.DataRowCount; i++)
                {
                    if (int.Parse(gvPlanilla.GetRowCellValue(i, "IdActividad").ToString()) == 0)
                    {
                        strMensaje = strMensaje + "- Debe seleccionar una actividad.\n";
                        flag = true;
                    }

                    if (int.Parse(gvPlanilla.GetRowCellValue(i, "IdPeligro").ToString()) == 0)
                    {
                        strMensaje = strMensaje + "- Debe seleccionar un peligro.\n";
                        flag = true;
                    }

                    if (gvPlanilla.GetRowCellValue(i, "DetallePeligro").ToString() == "")
                    {
                        strMensaje = strMensaje + "- Debe ingresar el detalle del peligro.\n";
                        flag = true;
                    }

                    if (gvPlanilla.GetRowCellValue(i, "DescRiesgo").ToString() == "")
                    {
                        strMensaje = strMensaje + "- Debe ingresar el riesgo.\n";
                        flag = true;
                    }

                    if (int.Parse(gvPlanilla.GetRowCellValue(i, "IndicePersona").ToString()) == 0)
                    {
                        strMensaje = strMensaje + "- Debe seleccionar el indice de personas expuestas.\n";
                        flag = true;
                    }

                    if (int.Parse(gvPlanilla.GetRowCellValue(i, "IndiceProcedimiento").ToString()) == 0)
                    {
                        strMensaje = strMensaje + "- Debe seleccionar el indice de prodecimiento de trabajo.\n";
                        flag = true;
                    }

                    if (int.Parse(gvPlanilla.GetRowCellValue(i, "IndiceCapacitacion").ToString()) == 0)
                    {
                        strMensaje = strMensaje + "- Debe ingresar el indice de capacitación y entrenamiento.\n";
                        flag = true;
                    }

                    if (int.Parse(gvPlanilla.GetRowCellValue(i, "IndiceFrecuencia").ToString()) == 0)
                    {
                        strMensaje = strMensaje + "- Debe seleccionar el indice de frecuencia de exposición.\n";
                        flag = true;
                    }

                    if (int.Parse(gvPlanilla.GetRowCellValue(i, "Severidad").ToString()) == 0)
                    {
                        strMensaje = strMensaje + "- Debe seleccionar el indice de severidad.\n";
                        flag = true;
                    }

                    if (int.Parse(gvPlanilla.GetRowCellValue(i, "ValoracionRiesgo").ToString()) == 0)
                    {
                        strMensaje = strMensaje + "- La valoración del riesgo no puede ser 0.\n";
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

        #endregion

        public class CPlanilla
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdPlanilla { get; set; }
            public Int32 IdUnidadMinera { get; set; }
            public Int32 IdArea { get; set; }
            public Int32 IdSector { get; set; }
            public Int32 IdActividad { get; set; }
            public String DescActividad { get; set; }
            public Boolean FlagRutinaria { get; set; }
            public Boolean FlagNoRutinaria { get; set; }
            public Boolean FlagEmergencia { get; set; }
            public Boolean FlagPropio { get; set; }
            public Boolean FlagTercero { get; set; }
            public Int32 IdPeligro { get; set; }
            public String DescPeligro { get; set; }
            public String DetallePeligro { get; set; }
            public String TipoPeligro { get; set; }
            public String DescRiesgo { get; set; }
            public Int32 IndicePersona { get; set; }
            public Int32 IndiceProcedimiento { get; set; }
            public Int32 IndiceCapacitacion { get; set; }
            public Int32 IndiceFrecuencia { get; set; }
            public Int32 Severidad { get; set; }
            public Int32 ValoracionRiesgo { get; set; }
            public String CalificacionRiesgo { get; set; }
            public String Significativo { get; set; }
            public String Eliminacion { get; set; }
            public String Situacion { get; set; }
            public String Tratamiento { get; set; }
            public String ControlAdministrativo { get; set; }
            public String EquipoProteccion { get; set; }
            public String Responsable { get; set; }
            public Int32 IndicePersonaRR { get; set; }
            public Int32 IndiceProcedimientoRR { get; set; }
            public Int32 IndiceCapacitacionRR { get; set; }
            public Int32 IndiceFrecuenciaRR { get; set; }
            public Int32 SeveridadRR { get; set; }
            public Int32 ValoracionRiesgoRR { get; set; }
            public String CalificacionRiesgoRR { get; set; }
            public String SignificativoRR { get; set; }
            public Int32 TipoOper { get; set; }

            public CPlanilla()
            {

            }
        }

        
    }
}