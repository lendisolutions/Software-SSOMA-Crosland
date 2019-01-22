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
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Iperc.Maestros
{
    public partial class frmManValoracionRiesgo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ValoracionRiesgoBE> mLista = new List<ValoracionRiesgoBE>();

        #endregion

        #region "Eventos"

        public frmManValoracionRiesgo()
        {
            InitializeComponent();
        }

        private void frmManValoracionRiesgo_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManValoracionRiesgoEdit objManValoracionRiesgo = new frmManValoracionRiesgoEdit();
                objManValoracionRiesgo.lstValoracionRiesgo = mLista;
                objManValoracionRiesgo.pOperacion = frmManValoracionRiesgoEdit.Operacion.Nuevo;
                objManValoracionRiesgo.IdValoracionRiesgo = 0;
                objManValoracionRiesgo.StartPosition = FormStartPosition.CenterParent;
                objManValoracionRiesgo.ShowDialog();
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
                        ValoracionRiesgoBE objE_ValoracionRiesgo = new ValoracionRiesgoBE();
                        objE_ValoracionRiesgo.IdValoracionRiesgo = int.Parse(gvValoracionRiesgo.GetFocusedRowCellValue("IdValoracionRiesgo").ToString());
                        objE_ValoracionRiesgo.Usuario = Parametros.strUsuarioLogin;
                        objE_ValoracionRiesgo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ValoracionRiesgo.IdEmpresa = Parametros.intEmpresaId;

                        ValoracionRiesgoBL objBL_ValoracionRiesgo = new ValoracionRiesgoBL();
                        objBL_ValoracionRiesgo.Elimina(objE_ValoracionRiesgo);
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

            //    List<ReporteValoracionRiesgoElementoBE> lstReporte = null;
            //    lstReporte = new ReporteValoracionRiesgoElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptValoracionRiesgoElemento = new RptVistaReportes();
            //            objRptValoracionRiesgoElemento.VerRptValoracionRiesgoElemento(lstReporte);
            //            objRptValoracionRiesgoElemento.ShowDialog();
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
            string _fileName = "ListadoValoracionRiesgos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvValoracionRiesgo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvValoracionRiesgo_DoubleClick(object sender, EventArgs e)
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

        private void gvValoracionRiesgo_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "Clasificacion")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Clasificacion"]);
                        if (Situacion == "INACEPTABLE")
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "ALTO RIESGO")
                        {
                            e.Appearance.BackColor = Color.FromArgb(255, 192, 0);
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

        private void Cargar()
        {
            mLista = new ValoracionRiesgoBL().ListaTodosActivo(0);
            gcValoracionRiesgo.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcValoracionRiesgo.DataSource = mLista.Where(obj =>
                                                   obj.Valoracion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvValoracionRiesgo.RowCount > 0)
            {
                ValoracionRiesgoBE objValoracionRiesgo = new ValoracionRiesgoBE();
                objValoracionRiesgo.IdValoracionRiesgo = int.Parse(gvValoracionRiesgo.GetFocusedRowCellValue("IdValoracionRiesgo").ToString());

                frmManValoracionRiesgoEdit objManValoracionRiesgoEdit = new frmManValoracionRiesgoEdit();
                objManValoracionRiesgoEdit.pOperacion = frmManValoracionRiesgoEdit.Operacion.Modificar;
                objManValoracionRiesgoEdit.IdValoracionRiesgo = objValoracionRiesgo.IdValoracionRiesgo;
                objManValoracionRiesgoEdit.pValoracionRiesgoBE = objValoracionRiesgo;
                objManValoracionRiesgoEdit.StartPosition = FormStartPosition.CenterParent;
                objManValoracionRiesgoEdit.ShowDialog();

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

            if (gvValoracionRiesgo.GetFocusedRowCellValue("IdValoracionRiesgo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una ValoracionRiesgo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }


        #endregion

       
    }
}