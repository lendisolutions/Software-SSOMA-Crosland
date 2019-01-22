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
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Iperc.Maestros
{
    public partial class frmManSenalizacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SenalizacionBE> mLista = new List<SenalizacionBE>();

        #endregion

        #region "Eventos"

        public frmManSenalizacion()
        {
            InitializeComponent();
        }

        private void frmManSenalizacion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManSenalizacionEdit objManSenalizacion = new frmManSenalizacionEdit();
                objManSenalizacion.lstSenalizacion = mLista;
                objManSenalizacion.pOperacion = frmManSenalizacionEdit.Operacion.Nuevo;
                objManSenalizacion.IdSenalizacion = 0;
                objManSenalizacion.StartPosition = FormStartPosition.CenterParent;
                objManSenalizacion.ShowDialog();
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
                        SenalizacionBE objE_Senalizacion = new SenalizacionBE();
                        objE_Senalizacion.IdSenalizacion = int.Parse(gvSenalizacion.GetFocusedRowCellValue("IdSenalizacion").ToString());
                        objE_Senalizacion.Usuario = Parametros.strUsuarioLogin;
                        objE_Senalizacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Senalizacion.IdEmpresa = Parametros.intEmpresaId;

                        SenalizacionBL objBL_Senalizacion = new SenalizacionBL();
                        objBL_Senalizacion.Elimina(objE_Senalizacion);
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

            //    List<ReporteSenalizacionElementoBE> lstReporte = null;
            //    lstReporte = new ReporteSenalizacionElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptSenalizacionElemento = new RptVistaReportes();
            //            objRptSenalizacionElemento.VerRptSenalizacionElemento(lstReporte);
            //            objRptSenalizacionElemento.ShowDialog();
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
            string _fileName = "ListadoSenalizacions";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvSenalizacion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvSenalizacion_DoubleClick(object sender, EventArgs e)
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
            mLista = new SenalizacionBL().ListaTodosActivo(0);
            gcSenalizacion.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcSenalizacion.DataSource = mLista.Where(obj =>
                                                   obj.DescSenalizacion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvSenalizacion.RowCount > 0)
            {
                SenalizacionBE objSenalizacion = new SenalizacionBE();
                objSenalizacion.IdSenalizacion = int.Parse(gvSenalizacion.GetFocusedRowCellValue("IdSenalizacion").ToString());
                objSenalizacion.DescSenalizacion = gvSenalizacion.GetFocusedRowCellValue("DescSenalizacion").ToString();
                objSenalizacion.FlagEstado = Convert.ToBoolean(gvSenalizacion.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManSenalizacionEdit objManSenalizacionEdit = new frmManSenalizacionEdit();
                objManSenalizacionEdit.pOperacion = frmManSenalizacionEdit.Operacion.Modificar;
                objManSenalizacionEdit.IdSenalizacion = objSenalizacion.IdSenalizacion;
                objManSenalizacionEdit.pSenalizacionBE = objSenalizacion;
                objManSenalizacionEdit.StartPosition = FormStartPosition.CenterParent;
                objManSenalizacionEdit.ShowDialog();

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

            if (gvSenalizacion.GetFocusedRowCellValue("IdSenalizacion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Senalizacion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}