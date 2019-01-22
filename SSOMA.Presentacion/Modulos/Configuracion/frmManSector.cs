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
using System.Reflection;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion.Utils;

namespace SSOMA.Presentacion.Modulos.Configuracion
{
    public partial class frmManSector : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SectorBE> mLista = new List<SectorBE>();

        int IdEmpresa = 0;
        int IdUnidadMinera = 0;
        int IdArea = 0;

        #endregion

        #region "Eventos"

        public frmManSector()
        {
            InitializeComponent();
        }

        private void frmManSede_Load(object sender, EventArgs e)
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
                    XtraMessageBox.Show("Debe seleccionar la empresa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (IdUnidadMinera == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar la sede", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (IdArea == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar el area", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmManSectorEdit objManSector = new frmManSectorEdit();
                objManSector.lstSector = mLista;
                objManSector.pOperacion = frmManSectorEdit.Operacion.Nuevo;
                objManSector.IdEmpresa = IdEmpresa;
                objManSector.IdUnidadMinera = IdUnidadMinera;
                objManSector.IdArea = IdArea;
                objManSector.IdSector = 0;
                objManSector.StartPosition = FormStartPosition.CenterParent;
                objManSector.ShowDialog();
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
                        SectorBE objE_Sector = new SectorBE();
                        objE_Sector.IdSector = int.Parse(gvSector.GetFocusedRowCellValue("IdSector").ToString());
                        objE_Sector.Usuario = Parametros.strUsuarioLogin;
                        objE_Sector.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Sector.IdEmpresa = Parametros.intEmpresaId;

                        SectorBL objBL_Area = new SectorBL();
                        objBL_Area.Elimina(objE_Sector);
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

            //    List<ReporteSectorBE> lstReporte = null;
            //    lstReporte = new ReporteSectorBL().Listado(Parametros.intEmpresaId, Parametros.intUnidadMineraId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptSector = new RptVistaReportes();
            //            objRptSector.VerRptSector(lstReporte);
            //            objRptSector.ShowDialog();
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
                gvSector.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvSector_DoubleClick(object sender, EventArgs e)
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
                    break;
                case "UMM":
                    IdUnidadMinera = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaTreeviewAreas(e.Node);
                    break;
                case "ARE":
                    IdArea = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
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
            lstArea = new AreaBL().ListaTodosActivo(IdEmpresa, IdUnidadMinera);
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
            mLista = new SectorBL().ListaTodosActivo(IdEmpresa, IdUnidadMinera, IdArea);
            gcSector.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcSector.DataSource = mLista.Where(obj =>
                                                   obj.DescSector.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvSector.RowCount > 0)
            {
                SectorBE objSSOMA = new SectorBE();
                objSSOMA.IdEmpresa = int.Parse(gvSector.GetFocusedRowCellValue("IdEmpresa").ToString());
                objSSOMA.IdUnidadMinera = int.Parse(gvSector.GetFocusedRowCellValue("IdUnidadMinera").ToString());
                objSSOMA.IdArea = int.Parse(gvSector.GetFocusedRowCellValue("IdArea").ToString());
                objSSOMA.IdSector = int.Parse(gvSector.GetFocusedRowCellValue("IdSector").ToString());

                frmManSectorEdit objManSectorEdit = new frmManSectorEdit();
                objManSectorEdit.pOperacion = frmManSectorEdit.Operacion.Modificar;

                objManSectorEdit.IdEmpresa = objSSOMA.IdEmpresa;
                objManSectorEdit.IdUnidadMinera = objSSOMA.IdUnidadMinera;
                objManSectorEdit.IdArea = objSSOMA.IdArea;
                objManSectorEdit.IdSector = objSSOMA.IdSector;
                objManSectorEdit.pSectorBE = objSSOMA;
                objManSectorEdit.StartPosition = FormStartPosition.CenterParent;
                objManSectorEdit.ShowDialog();

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

            if (gvSector.GetFocusedRowCellValue("IdSector").ToString() == "")
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