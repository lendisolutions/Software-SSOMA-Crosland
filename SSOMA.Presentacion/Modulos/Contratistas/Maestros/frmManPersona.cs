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
    public partial class frmManPersona : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PersonaBE> mLista = new List<PersonaBE>();

        int IdEmpresa = 0;

        string strFleExcel = "";

        #endregion

        #region "Eventos"

        public frmManPersona()
        {
            InitializeComponent();
        }

        private void frmManPersona_Load(object sender, EventArgs e)
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

                frmManPersonaEdit objManPersona = new frmManPersonaEdit();
                objManPersona.lstPersona = mLista;
                objManPersona.pOperacion = frmManPersonaEdit.Operacion.Nuevo;
                objManPersona.IdEmpresa = IdEmpresa;
                objManPersona.IdPersona = 0;
                objManPersona.StartPosition = FormStartPosition.CenterParent;
                objManPersona.ShowDialog();
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
                        PersonaBE objE_Persona = new PersonaBE();
                        objE_Persona.IdPersona = int.Parse(gvPersona.GetFocusedRowCellValue("IdPersona").ToString());
                        objE_Persona.Usuario = Parametros.strUsuarioLogin;
                        objE_Persona.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Persona.IdEmpresa = Parametros.intEmpresaId;

                        PersonaBL objBL_Area = new PersonaBL();
                        objBL_Area.Elimina(objE_Persona);
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

            //    List<ReportePersonaBE> lstReporte = null;
            //    lstReporte = new ReportePersonaBL().Listado(Parametros.intEmpresaId, Parametros.intUnidadMineraId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptPersona = new RptVistaReportes();
            //            objRptPersona.VerRptPersona(lstReporte);
            //            objRptPersona.ShowDialog();
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
                gvPersona.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPersona_DoubleClick(object sender, EventArgs e)
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

        private void gvPersona_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "DescSituacion")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["DescSituacion"]);
                        if (Situacion == "ACTIVO")
                        {
                            e.Appearance.ForeColor = Color.Blue;
                        }
                        if (Situacion == "CESADO")
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
            mLista = new PersonaBL().ListaContratista(IdEmpresa);
            gcPersona.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcPersona.DataSource = mLista.Where(obj =>
                                                   obj.ApeNom.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvPersona.RowCount > 0)
            {
                PersonaBE objSSOMA = new PersonaBE();
                objSSOMA.IdEmpresa = int.Parse(gvPersona.GetFocusedRowCellValue("IdEmpresa").ToString());
                objSSOMA.IdUnidadMinera = int.Parse(gvPersona.GetFocusedRowCellValue("IdUnidadMinera").ToString());
                objSSOMA.IdArea = int.Parse(gvPersona.GetFocusedRowCellValue("IdArea").ToString());
                objSSOMA.IdPersona = int.Parse(gvPersona.GetFocusedRowCellValue("IdPersona").ToString());

                frmManPersonaEdit objManPersonaEdit = new frmManPersonaEdit();
                objManPersonaEdit.pOperacion = frmManPersonaEdit.Operacion.Modificar;

                objManPersonaEdit.IdEmpresa = objSSOMA.IdEmpresa;
                objManPersonaEdit.IdPersona = objSSOMA.IdPersona;
                objManPersonaEdit.pPersonaBE = objSSOMA;
                objManPersonaEdit.StartPosition = FormStartPosition.CenterParent;
                objManPersonaEdit.ShowDialog();

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

            if (gvPersona.GetFocusedRowCellValue("IdPersona").ToString() == "")
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