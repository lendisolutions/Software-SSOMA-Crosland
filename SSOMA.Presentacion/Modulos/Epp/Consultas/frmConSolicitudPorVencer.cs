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
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Epp.Consultas
{
    public partial class frmConSolicitudPorVencer : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SolicitudEppBE> mLista = new List<SolicitudEppBE>();
        
        #endregion

        #region "Eventos"

        public frmConSolicitudPorVencer()
        {
            InitializeComponent();
            gcFechaSolicitud.Caption = "Fecha\nSolicitud";
            gcEmpresaResponsable.Caption = "Empresa\nResponsable";
            gcUnidadMineraResponsable.Caption = "Sede\nResponsable";
            gcAreaResponsable.Caption = "Area\nReponsable";
            gcSectorResponsable.Caption = "Sector\nReponsable";
            gcDias.Caption = "Días\nPor Vencer";
        }

        private void frmConSolicitudPorVencer_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "Listado de Solicitud Por Vencer";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvSolicitudEpp.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xlsx");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xlsx");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtJefe_EditValueChanged(object sender, EventArgs e)
        {
            if (mLista.Count > 0)
            {
                CargarBusquedaJefe();
            }
        }

        private void txtResponsable_EditValueChanged(object sender, EventArgs e)
        {
            if (mLista.Count > 0)
            {
                CargarBusquedaResponsable();
            }
        }

        private void gvSolicitudEpp_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "Situacion")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Situacion"]);
                        if (Situacion == "ATENDIDO")
                        {
                            e.Appearance.ForeColor = Color.Blue;
                        }
                        if (Situacion == "PENDIENTE")
                        {
                            e.Appearance.ForeColor = Color.Red;
                        }
                        if (Situacion == "ANULADO")
                        {
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

        private void Cargar()
        {
            mLista = new SolicitudEppBL().ListaPorVencer(Parametros.intEmpresaId, 0, 0);
            gcSolicitudEpp.DataSource = mLista;
        }

        private void CargarBusquedaJefe()
        {
            gcSolicitudEpp.DataSource = mLista.Where(obj =>
                                                   obj.Jefe.ToUpper().Contains(txtJefe.Text.ToUpper())).ToList();
        }

        private void CargarBusquedaResponsable()
        {
            gcSolicitudEpp.DataSource = mLista.Where(obj =>
                                                   obj.Responsable.ToUpper().Contains(txtResponsable.Text.ToUpper())).ToList();
        }

        #endregion

        

        
    }
}