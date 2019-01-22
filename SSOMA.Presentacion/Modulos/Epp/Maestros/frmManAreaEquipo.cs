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

namespace SSOMA.Presentacion.Modulos.Epp.Maestros
{
    public partial class frmManAreaEquipo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<AreaEquipoBE> mLista = new List<AreaEquipoBE>();

        int intIdEmpresa = 0;
        int intIdUnidadMinera = 0;
        int intIdArea = 0;

        #endregion

        #region "Eventos"

        public frmManAreaEquipo()
        {
            InitializeComponent();
        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargaTreeview();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                if (intIdEmpresa == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar la empresa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (intIdUnidadMinera == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar la sede", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (intIdArea == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar el area", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmManAreaEquipoEdit objManAreaEquipo = new frmManAreaEquipoEdit();
                objManAreaEquipo.lstAreaEquipo = mLista;
                objManAreaEquipo.pOperacion = frmManAreaEquipoEdit.Operacion.Nuevo;
                objManAreaEquipo.IdEmpresa = intIdEmpresa;
                objManAreaEquipo.IdUnidadMinera = intIdUnidadMinera;
                objManAreaEquipo.IdArea = intIdArea;
                objManAreaEquipo.IdAreaEquipo = 0;
                objManAreaEquipo.StartPosition = FormStartPosition.CenterParent;
                objManAreaEquipo.ShowDialog();
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
                        AreaEquipoBE objE_AreaEquipo = new AreaEquipoBE();
                        objE_AreaEquipo.IdAreaEquipo = int.Parse(gvAreaEquipo.GetFocusedRowCellValue("IdAreaEquipo").ToString());
                        objE_AreaEquipo.Usuario = Parametros.strUsuarioLogin;
                        objE_AreaEquipo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_AreaEquipo.IdEmpresa = Parametros.intEmpresaId;

                        AreaEquipoBL objBL_Area = new AreaEquipoBL();
                        objBL_Area.Elimina(objE_AreaEquipo);
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

            //    List<ReporteAreaEquipoBE> lstReporte = null;
            //    lstReporte = new ReporteAreaEquipoBL().Listado(Parametros.intEmpresaId, Parametros.intUnidadMineraId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptAreaEquipo = new RptVistaReportes();
            //            objRptAreaEquipo.VerRptAreaEquipo(lstReporte);
            //            objRptAreaEquipo.ShowDialog();
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
                gvAreaEquipo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvAreaEquipo_DoubleClick(object sender, EventArgs e)
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
                    intIdEmpresa = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    break;
                case "UMM":
                    intIdUnidadMinera = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaTreeviewAreas(e.Node);
                    break;
                case "ARE":
                    intIdArea = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Cargar();
                    break;
            }
        }

        #endregion

        #region "Metodos"

        private void CargaTreeview()
        {
            tvwDatos.Nodes.Clear();

            List<EmpresaBE> lstEmpresa = null;
            lstEmpresa = new EmpresaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTECorporativo);
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

        private void Cargar()
        {
            mLista = new AreaEquipoBL().ListaTodosActivo(intIdEmpresa, intIdUnidadMinera, intIdArea);
            gcAreaEquipo.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcAreaEquipo.DataSource = mLista.Where(obj =>
                                                   obj.DescEquipo.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvAreaEquipo.RowCount > 0)
            {
                AreaEquipoBE objSSOMA = new AreaEquipoBE();
                objSSOMA.IdEmpresa = int.Parse(gvAreaEquipo.GetFocusedRowCellValue("IdEmpresa").ToString());
                objSSOMA.IdUnidadMinera = int.Parse(gvAreaEquipo.GetFocusedRowCellValue("IdUnidadMinera").ToString());
                objSSOMA.IdArea = int.Parse(gvAreaEquipo.GetFocusedRowCellValue("IdArea").ToString());
                objSSOMA.IdAreaEquipo = int.Parse(gvAreaEquipo.GetFocusedRowCellValue("IdAreaEquipo").ToString());

                frmManAreaEquipoEdit objManAreaEquipoEdit = new frmManAreaEquipoEdit();
                objManAreaEquipoEdit.pOperacion = frmManAreaEquipoEdit.Operacion.Modificar;

                objManAreaEquipoEdit.IdEmpresa = objSSOMA.IdEmpresa;
                objManAreaEquipoEdit.IdUnidadMinera = objSSOMA.IdUnidadMinera;
                objManAreaEquipoEdit.IdArea = objSSOMA.IdArea;
                objManAreaEquipoEdit.IdAreaEquipo = objSSOMA.IdAreaEquipo;
                objManAreaEquipoEdit.pAreaEquipoBE = objSSOMA;
                objManAreaEquipoEdit.StartPosition = FormStartPosition.CenterParent;
                objManAreaEquipoEdit.ShowDialog();

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

            if (gvAreaEquipo.GetFocusedRowCellValue("IdAreaEquipo").ToString() == "")
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