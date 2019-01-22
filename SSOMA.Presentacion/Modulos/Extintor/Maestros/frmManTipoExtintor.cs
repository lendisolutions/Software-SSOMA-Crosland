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

namespace SSOMA.Presentacion.Modulos.Extintor.Maestros
{
    public partial class frmManTipoExtintor : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TipoExtintorBE> mLista = new List<TipoExtintorBE>();
        
        #endregion

        #region "Eventos"

        public frmManTipoExtintor()
        {
            InitializeComponent();
        }

        private void frmManTipoExtintor_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTipoExtintorEdit objManTipoExtintor = new frmManTipoExtintorEdit();
                objManTipoExtintor.lstTipoExtintor = mLista;
                objManTipoExtintor.pOperacion = frmManTipoExtintorEdit.Operacion.Nuevo;
                objManTipoExtintor.IdTipoExtintor = 0;
                objManTipoExtintor.StartPosition = FormStartPosition.CenterParent;
                objManTipoExtintor.ShowDialog();
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
                        TipoExtintorBE objE_TipoExtintor = new TipoExtintorBE();
                        objE_TipoExtintor.IdTipoExtintor = int.Parse(gvTipoExtintor.GetFocusedRowCellValue("IdTipoExtintor").ToString());
                        objE_TipoExtintor.Usuario = Parametros.strUsuarioLogin;
                        objE_TipoExtintor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_TipoExtintor.IdEmpresa = Parametros.intEmpresaId;

                        TipoExtintorBL objBL_TipoExtintor = new TipoExtintorBL();
                        objBL_TipoExtintor.Elimina(objE_TipoExtintor);
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

            //    List<ReporteTipoExtintorElementoBE> lstReporte = null;
            //    lstReporte = new ReporteTipoExtintorElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptTipoExtintorElemento = new RptVistaReportes();
            //            objRptTipoExtintorElemento.VerRptTipoExtintorElemento(lstReporte);
            //            objRptTipoExtintorElemento.ShowDialog();
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
            string _fileName = "ListadoTipoExtintors";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTipoExtintor.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTipoExtintor_DoubleClick(object sender, EventArgs e)
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
            mLista = new TipoExtintorBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcTipoExtintor.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTipoExtintor.DataSource = mLista.Where(obj =>
                                                   obj.DescTipoExtintor.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTipoExtintor.RowCount > 0)
            {
                TipoExtintorBE objTipoExtintor = new TipoExtintorBE();
                objTipoExtintor.IdTipoExtintor = int.Parse(gvTipoExtintor.GetFocusedRowCellValue("IdTipoExtintor").ToString());
                objTipoExtintor.Abreviatura = gvTipoExtintor.GetFocusedRowCellValue("Abreviatura").ToString();
                objTipoExtintor.DescTipoExtintor = gvTipoExtintor.GetFocusedRowCellValue("DescTipoExtintor").ToString();
                objTipoExtintor.FlagEstado = Convert.ToBoolean(gvTipoExtintor.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManTipoExtintorEdit objManTipoExtintorEdit = new frmManTipoExtintorEdit();
                objManTipoExtintorEdit.pOperacion = frmManTipoExtintorEdit.Operacion.Modificar;
                objManTipoExtintorEdit.IdTipoExtintor = objTipoExtintor.IdTipoExtintor;
                objManTipoExtintorEdit.pTipoExtintorBE = objTipoExtintor;
                objManTipoExtintorEdit.StartPosition = FormStartPosition.CenterParent;
                objManTipoExtintorEdit.ShowDialog();

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

            if (gvTipoExtintor.GetFocusedRowCellValue("IdTipoExtintor").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una TipoExtintor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
        
    }
}