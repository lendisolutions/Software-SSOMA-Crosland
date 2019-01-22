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
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Extintor.Registros
{
    public partial class frmRegExtintor : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ExtintorBE> mLista = new List<ExtintorBE>();
        
        #endregion

        #region "Eventos"

        public frmRegExtintor()
        {
            InitializeComponent();
            gcFechaIngreso.Caption = "Fecha\nIngreso";
            gcFechaVencimiento.Caption = "Fecha\nVencimiento";
            gcFechaVencimientoPruebaHidrostatica.Caption = "Fecha Vencimiento\nPrueba Hidrostatica";
        }

        private void frmRegExtintor_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();

            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            deFechaDesde.EditValue = new DateTime(2000,1,1);
            deFechaHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
            }
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegExtintorEdit objManExtintor = new frmRegExtintorEdit();
                objManExtintor.lstExtintor = mLista;
                objManExtintor.pOperacion = frmRegExtintorEdit.Operacion.Nuevo;
                objManExtintor.IdExtintor = 0;
                objManExtintor.StartPosition = FormStartPosition.CenterParent;
                objManExtintor.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        ExtintorBE objE_Extintor = new ExtintorBE();
                        objE_Extintor.IdExtintor = int.Parse(gvExtintor.GetFocusedRowCellValue("IdExtintor").ToString());
                        objE_Extintor.Usuario = Parametros.strUsuarioLogin;
                        objE_Extintor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Extintor.IdEmpresa = Parametros.intEmpresaId;

                        ExtintorBL objBL_Extintor = new ExtintorBL();
                        objBL_Extintor.Elimina(objE_Extintor);
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
            try
            {
                Cursor = Cursors.WaitCursor;

                //if (gvExtintor.RowCount > 0)
                //{
                //    int IdExtintor = 0;
                //    IdExtintor = int.Parse(gvExtintor.GetFocusedRowCellValue("IdExtintor").ToString());
                //    List<ReporteExtintorBE> lstReporte = null;

                //    lstReporte = new ReporteExtintorBL().Listado(IdExtintor);

                //    if (lstReporte != null)
                //    {
                //        RptVistaReportes objRptAccUsu = new RptVistaReportes();
                //        objRptAccUsu.VerRptExtintor(lstReporte);
                //        objRptAccUsu.ShowDialog();

                //    }
                //    else
                //        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoExtintors";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvExtintor.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvExtintor_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarNumero(txtCodigo.Text);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ExtintorBL().ListaFecha(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboUnidadMinera.EditValue), Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcExtintor.DataSource = mLista;
        }

        private void CargarNumero(string Numero)
        {
            mLista = new ExtintorBL().ListaCodigo(Numero);
            gcExtintor.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvExtintor.RowCount > 0)
            {
                ExtintorBE objExtintor = new ExtintorBE();
                objExtintor.IdExtintor = int.Parse(gvExtintor.GetFocusedRowCellValue("IdExtintor").ToString());

                frmRegExtintorEdit objManExtintorEdit = new frmRegExtintorEdit();
                objManExtintorEdit.pOperacion = frmRegExtintorEdit.Operacion.Modificar;
                objManExtintorEdit.IdExtintor = objExtintor.IdExtintor;
                objManExtintorEdit.StartPosition = FormStartPosition.CenterParent;
                objManExtintorEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvExtintor.GetFocusedRowCellValue("IdExtintor").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Extintor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }


        #endregion

        
    }
}