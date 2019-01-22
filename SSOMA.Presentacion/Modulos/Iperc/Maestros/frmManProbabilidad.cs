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
    public partial class frmManProbabilidad : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ProbabilidadBE> mLista = new List<ProbabilidadBE>();

        #endregion

        #region "Eventos"

        public frmManProbabilidad()
        {
            InitializeComponent();
            gcIndicePersona.Caption = "Indice de Personas \n Expuestas";
            gcIndiceProcedimiento.Caption = "Indice de Procedimientos \n de Trabajo";
            gcIndiceCapacitacion.Caption = "Indice de Capacitación \n y Entrenamiento";
            gcIndiceFrecuencia.Caption = "Indice de Frecuencia \n de Exposición";
        }

        private void frmManProbabilidad_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManProbabilidadEdit objManProbabilidad = new frmManProbabilidadEdit();
                objManProbabilidad.lstProbabilidad = mLista;
                objManProbabilidad.pOperacion = frmManProbabilidadEdit.Operacion.Nuevo;
                objManProbabilidad.IdProbabilidad = 0;
                objManProbabilidad.StartPosition = FormStartPosition.CenterParent;
                objManProbabilidad.ShowDialog();
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
                        ProbabilidadBE objE_Probabilidad = new ProbabilidadBE();
                        objE_Probabilidad.IdProbabilidad = int.Parse(gvProbabilidad.GetFocusedRowCellValue("IdProbabilidad").ToString());
                        objE_Probabilidad.Usuario = Parametros.strUsuarioLogin;
                        objE_Probabilidad.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Probabilidad.IdEmpresa = Parametros.intEmpresaId;

                        ProbabilidadBL objBL_Probabilidad = new ProbabilidadBL();
                        objBL_Probabilidad.Elimina(objE_Probabilidad);
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

            //    List<ReporteProbabilidadElementoBE> lstReporte = null;
            //    lstReporte = new ReporteProbabilidadElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptProbabilidadElemento = new RptVistaReportes();
            //            objRptProbabilidadElemento.VerRptProbabilidadElemento(lstReporte);
            //            objRptProbabilidadElemento.ShowDialog();
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
            string _fileName = "ListadoProbabilidads";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvProbabilidad.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvProbabilidad_DoubleClick(object sender, EventArgs e)
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

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ProbabilidadBL().ListaTodosActivo(0);
            gcProbabilidad.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcProbabilidad.DataSource = mLista.Where(obj =>
                                                   obj.IndicePersona.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvProbabilidad.RowCount > 0)
            {
                ProbabilidadBE objProbabilidad = new ProbabilidadBE();
                objProbabilidad.IdProbabilidad = int.Parse(gvProbabilidad.GetFocusedRowCellValue("IdProbabilidad").ToString());

                frmManProbabilidadEdit objManProbabilidadEdit = new frmManProbabilidadEdit();
                objManProbabilidadEdit.pOperacion = frmManProbabilidadEdit.Operacion.Modificar;
                objManProbabilidadEdit.IdProbabilidad = objProbabilidad.IdProbabilidad;
                objManProbabilidadEdit.pProbabilidadBE = objProbabilidad;
                objManProbabilidadEdit.StartPosition = FormStartPosition.CenterParent;
                objManProbabilidadEdit.ShowDialog();

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

            if (gvProbabilidad.GetFocusedRowCellValue("IdProbabilidad").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Probabilidad", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}