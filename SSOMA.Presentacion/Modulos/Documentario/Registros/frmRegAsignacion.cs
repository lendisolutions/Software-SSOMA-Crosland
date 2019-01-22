using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Funciones;
using Excel = Microsoft.Office.Interop.Excel;

namespace SSOMA.Presentacion.Modulos.Documentario.Registros
{
    public partial class frmRegAsignacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<DocumentoPersonaBE> mLista = new List<DocumentoPersonaBE>();

        int intIdEmpresaResponsable = 0;
        int intIdUnidadMineraResponsable = 0;
        int intIdAreaResponsable = 0;
        int intIdPersonaResponsable = 0;
        int IdDocumentoPersona = 0;

        string strTrabajador = "";

        #endregion

        #region "Eventos"

        public frmRegAsignacion()
        {
            InitializeComponent();
        }

        private void frmRegAsignacion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargaTreeview();
        }

        private void tlbMenu_NewClick()
        {
            //try
            //{
            //    if (intIdPersonaResponsable == 0)
            //    {
            //        XtraMessageBox.Show("Debe seleccionar a un trabajador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    frmRegAsignacionEdit objManAsignacion = new frmRegAsignacionEdit();
            //    objManAsignacion.pOperacion = frmRegAsignacionEdit.Operacion.Nuevo;
            //    objManAsignacion.IdDocumentoPersona = 0;
            //    objManAsignacion.IdPersona = intIdPersonaResponsable;
            //    objManAsignacion.Trabajador = strTrabajador;
            //    objManAsignacion.StartPosition = FormStartPosition.CenterParent;
            //    objManAsignacion.ShowDialog();
            //    Cargar();
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_EditClick()
        {
            //InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;
            //    if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        if (!ValidarIngreso())
            //        {
            //            DocumentoPersonaBE objE_DocumentoPersona = new DocumentoPersonaBE();
            //            objE_DocumentoPersona.IdDocumentoPersona = int.Parse(gvDocumentoPersona.GetFocusedRowCellValue("IdDocumentoPersona").ToString());
                      
            //            objE_DocumentoPersona.Usuario = Parametros.strUsuarioLogin;
            //            objE_DocumentoPersona.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            //            objE_DocumentoPersona.IdEmpresa = Parametros.intEmpresaId;

            //            DocumentoPersonaBL objBL_DocumentoPersona = new DocumentoPersonaBL();
            //            objBL_DocumentoPersona.Elimina(objE_DocumentoPersona);
            //            XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            Cargar();
            //        }
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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

                //if (gvDocumentoPersona.RowCount > 0)
                //{
                //    int IdDocumentoPersona = 0;
                //    IdDocumentoPersona = int.Parse(gvDocumentoPersona.GetFocusedRowCellValue("IdDocumentoPersona").ToString());
                //    List<ReporteDocumentoPersonaBE> lstReporte = null;

                //    lstReporte = new ReporteDocumentoPersonaBL().Listado(IdDocumentoPersona);

                //    if (lstReporte != null)
                //    {
                //        RptVistaReportes objRptAccUsu = new RptVistaReportes();
                //        objRptAccUsu.VerRptDocumentoPersona(lstReporte, Parametros.strUsuarioNombres);
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
            string _fileName = "ListadoDocumentoPersonas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDocumentoPersona.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvDocumentoPersona_DoubleClick(object sender, EventArgs e)
        {
            //GridView view = (GridView)sender;
            //Point pt = view.GridControl.PointToClient(Control.MousePosition);
            //FilaDoubleClick(view, pt);
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
                    intIdEmpresaResponsable = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    break;
                case "UMM":
                    intIdUnidadMineraResponsable = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaTreeviewAreas(e.Node);
                    break;
                case "ARE":
                    intIdAreaResponsable = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaTreeviewPersonal(e.Node);
                    break;
                case "PER":
                    intIdPersonaResponsable = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    strTrabajador = e.Node.Text;
                    Cargar();
                    break;

            }
        }

        private void gvDocumentoPersona_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = (GridView)sender;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.Assign(view.GetViewInfo().PaintAppearance.GetAppearance("FocusedRow"));
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                
                DocumentoPersonaBL objBL_DocumentoPersona = new DocumentoPersonaBL();

                    
                objBL_DocumentoPersona.Actualiza(mLista, intIdPersonaResponsable, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
                XtraMessageBox.Show("La asignación de los documentos se actualizó correctamente. ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cargar();

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
            lstArea = new AreaBL().ListaTodosActivo(intIdEmpresaResponsable, intIdUnidadMineraResponsable);
            foreach (var item in lstArea)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 2;
                nuevoNodoChild.SelectedImageIndex = 2;
                nuevoNodoChild.Text = item.DescArea;
                nuevoNodoChild.Tag = "ARE" + item.IdArea.ToString();
                nodo.Nodes.Add(nuevoNodoChild);
            }
        }

        void CargaTreeviewPersonal(TreeNode nodo)
        {
            nodo.Nodes.Clear();

            List<PersonaBE> lstPersona = null;
            lstPersona = new PersonaBL().ListaTodosActivo(intIdEmpresaResponsable, intIdUnidadMineraResponsable, intIdAreaResponsable);
            foreach (var item in lstPersona)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 4;
                nuevoNodoChild.SelectedImageIndex = 4;
                nuevoNodoChild.Text = item.ApeNom;
                nuevoNodoChild.Tag = "PER" + item.IdPersona.ToString();
                nodo.Nodes.Add(nuevoNodoChild);
            }
        }

        private void Cargar()
        {
            mLista = new DocumentoPersonaBL().ListaTodosActivo(0, intIdPersonaResponsable, 0);
            gcDocumentoPersona.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcDocumentoPersona.DataSource = mLista.Where(obj =>
                                                   obj.NombreArchivo.ToUpper().Contains(txtArchivo.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvDocumentoPersona.RowCount > 0)
            {
                DocumentoPersonaBE objDocumentoPersona = new DocumentoPersonaBE();
                objDocumentoPersona.IdDocumentoPersona = int.Parse(gvDocumentoPersona.GetFocusedRowCellValue("IdDocumentoPersona").ToString());

                frmRegAsignacionEdit objManAsignacionEdit = new frmRegAsignacionEdit();
                objManAsignacionEdit.pOperacion = frmRegAsignacionEdit.Operacion.Modificar;
                objManAsignacionEdit.IdDocumentoPersona = objDocumentoPersona.IdDocumentoPersona;
                objManAsignacionEdit.IdPersona = intIdPersonaResponsable;
                objManAsignacionEdit.Trabajador = strTrabajador;
                objManAsignacionEdit.StartPosition = FormStartPosition.CenterParent;
                objManAsignacionEdit.ShowDialog();

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

            if (gvDocumentoPersona.GetFocusedRowCellValue("IdDocumentoPersona").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una DocumentoPersona", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        

        #endregion


    }
}