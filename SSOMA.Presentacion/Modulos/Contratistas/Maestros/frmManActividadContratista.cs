using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion.Utils;

namespace SSOMA.Presentacion.Modulos.Contratistas.Maestros
{
    public partial class frmManActividadContratista : DevExpress.XtraEditors.XtraForm
    {
        #region "Atributos"

        private List<ActividadContratistaBE> mLista = new List<ActividadContratistaBE>();

        int IdEmpresa = 0;


        #endregion

        #region "Eventos"

        public frmManActividadContratista()
        {
            InitializeComponent();
            gcFechaIniSctr.Caption = "Fecha Ini \n SCTR";
            gcFechaFinSctr.Caption = "Fecha Fin \n SCTR";
        }

        private void frmManActividadContratista_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargaTreeview();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                if (IdEmpresa == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar la empresa contratista", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmManActividadContratistaEdit objManActividadContratista = new frmManActividadContratistaEdit();
                objManActividadContratista.lstActividadContratista = mLista;
                objManActividadContratista.pOperacion = frmManActividadContratistaEdit.Operacion.Nuevo;
                objManActividadContratista.IdEmpresa = IdEmpresa;
                objManActividadContratista.IdActividadContratista = 0;
                objManActividadContratista.StartPosition = FormStartPosition.CenterParent;
                objManActividadContratista.ShowDialog();
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
                        ActividadContratistaBE objE_ActividadContratista = new ActividadContratistaBE();
                        objE_ActividadContratista.IdActividadContratista = int.Parse(gvActividadContratista.GetFocusedRowCellValue("IdActividadContratista").ToString());
                        objE_ActividadContratista.Usuario = Parametros.strUsuarioLogin;
                        objE_ActividadContratista.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ActividadContratista.IdEmpresa = Parametros.intEmpresaId;

                        ActividadContratistaBL objBL_Area = new ActividadContratistaBL();
                        objBL_Area.Elimina(objE_ActividadContratista);
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

            //    List<ReporteActividadContratistaBE> lstReporte = null;
            //    lstReporte = new ReporteActividadContratistaBL().Listado(Parametros.intEmpresaId, Parametros.intUnidadMineraId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptActividadContratista = new RptVistaReportes();
            //            objRptActividadContratista.VerRptActividadContratista(lstReporte);
            //            objRptActividadContratista.ShowDialog();
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
            string _fileName = "ListadoSSOMAs";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvActividadContratista.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvActividadContratista_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "EMP":
                    IdEmpresa = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Cargar();
                    break;
            }
        }

        private void gvActividadContratista_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "DescSituacion")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["DescSituacion"]);
                        if (Situacion == "VIGENTE")
                        {
                            e.Appearance.ForeColor = Color.Blue;
                        }
                        if (Situacion == "VENCIDO")
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

        #endregion

        #region "Metodos"

        private void CargaTreeview()
        {
            tvwDatos.Nodes.Clear();

            TreeNode nuevoNodo = new TreeNode();
            nuevoNodo.Text = "EMPRESA CONTRATISTA";
            nuevoNodo.ImageIndex = 0;
            nuevoNodo.SelectedImageIndex = 0;
            tvwDatos.Nodes.Add(nuevoNodo);

            List<EmpresaBE> lstEmpresa = null;
            lstEmpresa = new EmpresaBL().ListaTodosActivo(0, Parametros.intTEContratista);
            foreach (var item in lstEmpresa)
            {

                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 1;
                nuevoNodoChild.SelectedImageIndex = 1;
                nuevoNodoChild.Text = item.RazonSocial;
                nuevoNodoChild.Tag = "EMP" + item.IdEmpresa.ToString();
                nuevoNodo.Nodes.Add(nuevoNodoChild);

            }

            tvwDatos.ExpandAll();
        }



        private void Cargar()
        {
            mLista = new ActividadContratistaBL().ListaTodosActivo(IdEmpresa);
            gcActividadContratista.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcActividadContratista.DataSource = mLista.Where(obj =>
                                                   obj.DescActvidad.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvActividadContratista.RowCount > 0)
            {
                ActividadContratistaBE objSSOMA = new ActividadContratistaBE();
                objSSOMA.IdEmpresa = int.Parse(gvActividadContratista.GetFocusedRowCellValue("IdEmpresa").ToString());
                objSSOMA.IdActividadContratista = int.Parse(gvActividadContratista.GetFocusedRowCellValue("IdActividadContratista").ToString());

                frmManActividadContratistaEdit objManActividadContratistaEdit = new frmManActividadContratistaEdit();
                objManActividadContratistaEdit.pOperacion = frmManActividadContratistaEdit.Operacion.Modificar;

                objManActividadContratistaEdit.IdEmpresa = objSSOMA.IdEmpresa;
                objManActividadContratistaEdit.IdActividadContratista = objSSOMA.IdActividadContratista;
                objManActividadContratistaEdit.pActividadContratistaBE = objSSOMA;
                objManActividadContratistaEdit.StartPosition = FormStartPosition.CenterParent;
                objManActividadContratistaEdit.ShowDialog();

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

            if (gvActividadContratista.GetFocusedRowCellValue("IdActividadContratista").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Area", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}