﻿using System;
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
    public partial class frmManSustitucion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SustitucionBE> mLista = new List<SustitucionBE>();

        #endregion

        #region "Eventos"

        public frmManSustitucion()
        {
            InitializeComponent();
        }

        private void frmManSustitucion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManSustitucionEdit objManSustitucion = new frmManSustitucionEdit();
                objManSustitucion.lstSustitucion = mLista;
                objManSustitucion.pOperacion = frmManSustitucionEdit.Operacion.Nuevo;
                objManSustitucion.IdSustitucion = 0;
                objManSustitucion.StartPosition = FormStartPosition.CenterParent;
                objManSustitucion.ShowDialog();
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
                        SustitucionBE objE_Sustitucion = new SustitucionBE();
                        objE_Sustitucion.IdSustitucion = int.Parse(gvSustitucion.GetFocusedRowCellValue("IdSustitucion").ToString());
                        objE_Sustitucion.Usuario = Parametros.strUsuarioLogin;
                        objE_Sustitucion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Sustitucion.IdEmpresa = Parametros.intEmpresaId;

                        SustitucionBL objBL_Sustitucion = new SustitucionBL();
                        objBL_Sustitucion.Elimina(objE_Sustitucion);
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

            //    List<ReporteSustitucionElementoBE> lstReporte = null;
            //    lstReporte = new ReporteSustitucionElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptSustitucionElemento = new RptVistaReportes();
            //            objRptSustitucionElemento.VerRptSustitucionElemento(lstReporte);
            //            objRptSustitucionElemento.ShowDialog();
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
            string _fileName = "ListadoSustitucions";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvSustitucion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvSustitucion_DoubleClick(object sender, EventArgs e)
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
            mLista = new SustitucionBL().ListaTodosActivo(0);
            gcSustitucion.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcSustitucion.DataSource = mLista.Where(obj =>
                                                   obj.DescSustitucion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvSustitucion.RowCount > 0)
            {
                SustitucionBE objSustitucion = new SustitucionBE();
                objSustitucion.IdSustitucion = int.Parse(gvSustitucion.GetFocusedRowCellValue("IdSustitucion").ToString());
                objSustitucion.DescSustitucion = gvSustitucion.GetFocusedRowCellValue("DescSustitucion").ToString();
                objSustitucion.FlagEstado = Convert.ToBoolean(gvSustitucion.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManSustitucionEdit objManSustitucionEdit = new frmManSustitucionEdit();
                objManSustitucionEdit.pOperacion = frmManSustitucionEdit.Operacion.Modificar;
                objManSustitucionEdit.IdSustitucion = objSustitucion.IdSustitucion;
                objManSustitucionEdit.pSustitucionBE = objSustitucion;
                objManSustitucionEdit.StartPosition = FormStartPosition.CenterParent;
                objManSustitucionEdit.ShowDialog();

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

            if (gvSustitucion.GetFocusedRowCellValue("IdSustitucion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Sustitucion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}