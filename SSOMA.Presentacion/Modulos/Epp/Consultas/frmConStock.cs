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
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Modulos.Epp.Maestros;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Epp.Consultas
{
    public partial class frmConStock : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        List<KardexBE> mLista = new List<KardexBE>();

        #endregion

        #region "Eventos"

        public frmConStock()
        {
            InitializeComponent();
        }

        private void frmConStock_Load(object sender, EventArgs e)
        {
            deHasta.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
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
                BSUtils.LoaderLook(cboOrdenInterna, new OrdenInternaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboUnidadMinera.EditValue)), "DescOrdenInterna", "IdOrdenInterna", true);
            }
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListaInventarioAlmacen";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvInventario.ExportToXlsx(f.SelectedPath + @"\" + _fileName + ".xlsx");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xlsx");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void verMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvInventario.RowCount > 0)
            {
                frmConInventarioDetalle objConInventarioDetalle = new frmConInventarioDetalle();
                objConInventarioDetalle.IdEmpresa = int.Parse(gvInventario.GetFocusedRowCellValue("IdEmpresa").ToString());
                objConInventarioDetalle.IdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
                objConInventarioDetalle.DescOrdenInterna = cboOrdenInterna.Text;
                objConInventarioDetalle.IdEquipo = int.Parse(gvInventario.GetFocusedRowCellValue("IdEquipo").ToString());
                objConInventarioDetalle.Codigo = gvInventario.GetFocusedRowCellValue("Codigo").ToString();
                objConInventarioDetalle.DescEquipo = gvInventario.GetFocusedRowCellValue("DescEquipo").ToString();
                objConInventarioDetalle.FechaDesde = Convert.ToDateTime("01/01/2010");
                objConInventarioDetalle.FechaHasta = deHasta.DateTime;
                objConInventarioDetalle.StartPosition = FormStartPosition.CenterParent;
                objConInventarioDetalle.ShowDialog();

                Cargar();
            }
        }

        private void toolstpIngresar_Click(object sender, EventArgs e)
        {
            
                frmManKardex objManKardex = new frmManKardex();
                objManKardex.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                objManKardex.IdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
                objManKardex.DescOrdenInterna = cboOrdenInterna.Text;
                objManKardex.StartPosition = FormStartPosition.CenterParent;
                objManKardex.ShowDialog();

                Cargar();
            
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            Cursor = Cursors.WaitCursor;
            mLista = new KardexBL().ListaInventario(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboUnidadMinera.EditValue), cboOrdenInterna.Text, 0, deHasta.DateTime);
            gcInventario.DataSource = mLista;
            Cursor = Cursors.Default;
        }

        #endregion

        
    }
}