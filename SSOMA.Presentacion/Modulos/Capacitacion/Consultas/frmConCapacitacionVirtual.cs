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
using DevExpress.XtraGrid.Columns;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion.Utils;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Capacitacion.Consultas
{
    public partial class frmConCapacitacionVirtual : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ResumenPersonaBE> mLista = new List<ResumenPersonaBE>();
        int intIdPersona = 0;

        #endregion

        #region "Eventos"

        public frmConCapacitacionVirtual()
        {
            InitializeComponent();
        }

        private void frmConCapacitacionVirtual_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = Parametros.intPeriodo;
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0, Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboTema, new TemaBL().ListaCombo(0, Parametros.intTEMAVirtual, Convert.ToInt32(txtPeriodo.EditValue)), "DescTema", "IdTema", true);
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoResumenPersonasAprobadas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvResumenPersona.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargaResumenPersonaAprobada();
        }

        private void gvResumenPersona_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "Situacion")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Situacion"]);
                        if (Situacion == "APROBADO")
                        {
                            e.Appearance.ForeColor = Color.Blue;
                        }
                        if (Situacion == "DESAPROBADO")
                        {
                            e.Appearance.ForeColor = Color.Red;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (mLista.Count > 0)
                {
                    intIdPersona = int.Parse(gvResumenPersona.GetFocusedRowCellValue("IdPersona").ToString());
                    List<ReporteRespuestaPersonaBE> lstReporte = null;

                    lstReporte = new ReporteRespuestaPersonaBL().Listado(Convert.ToInt32(cboTema.EditValue), intIdPersona);

                    if (lstReporte != null)
                    {
                        RptVistaReportes objRptCapacitacion = new RptVistaReportes();
                        objRptCapacitacion.VerRptRespuestaPersona(lstReporte);
                        objRptCapacitacion.ShowDialog();

                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        private void CargaResumenPersonaAprobada()
        {
            mLista = new ResumenPersonaBL().ListaCursoVirtual(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboTema.EditValue));
            gcResumenPersona.DataSource = mLista;


        }



        #endregion

        
    }
}