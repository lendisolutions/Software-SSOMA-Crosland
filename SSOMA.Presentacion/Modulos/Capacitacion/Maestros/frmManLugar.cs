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

namespace SSOMA.Presentacion.Modulos.Capacitacion.Maestros
{
    public partial class frmManLugar : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<LugarBE> mLista = new List<LugarBE>();
        
        #endregion

        #region "Eventos"

        public frmManLugar()
        {
            InitializeComponent();
        }

        private void frmManLugar_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManLugarEdit objManLugar = new frmManLugarEdit();
                objManLugar.lstLugar = mLista;
                objManLugar.pOperacion = frmManLugarEdit.Operacion.Nuevo;
                objManLugar.IdLugar = 0;
                objManLugar.StartPosition = FormStartPosition.CenterParent;
                objManLugar.ShowDialog();
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
                        LugarBE objE_Lugar = new LugarBE();
                        objE_Lugar.IdLugar = int.Parse(gvLugar.GetFocusedRowCellValue("IdLugar").ToString());
                        objE_Lugar.Usuario = Parametros.strUsuarioLogin;
                        objE_Lugar.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Lugar.IdEmpresa = Parametros.intEmpresaId;

                        LugarBL objBL_Lugar = new LugarBL();
                        objBL_Lugar.Elimina(objE_Lugar);
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

            //    List<ReporteLugarElementoBE> lstReporte = null;
            //    lstReporte = new ReporteLugarElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptLugarElemento = new RptVistaReportes();
            //            objRptLugarElemento.VerRptLugarElemento(lstReporte);
            //            objRptLugarElemento.ShowDialog();
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
            string _fileName = "ListadoLugars";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvLugar.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvLugar_DoubleClick(object sender, EventArgs e)
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
            mLista = new LugarBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcLugar.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcLugar.DataSource = mLista.Where(obj =>
                                                   obj.DescLugar.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvLugar.RowCount > 0)
            {
                LugarBE objLugar = new LugarBE();
                objLugar.IdLugar = int.Parse(gvLugar.GetFocusedRowCellValue("IdLugar").ToString());
                objLugar.DescLugar = gvLugar.GetFocusedRowCellValue("DescLugar").ToString();
                objLugar.FlagEstado = Convert.ToBoolean(gvLugar.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManLugarEdit objManLugarEdit = new frmManLugarEdit();
                objManLugarEdit.pOperacion = frmManLugarEdit.Operacion.Modificar;
                objManLugarEdit.IdLugar = objLugar.IdLugar;
                objManLugarEdit.pLugarBE = objLugar;
                objManLugarEdit.StartPosition = FormStartPosition.CenterParent;
                objManLugarEdit.ShowDialog();

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

            if (gvLugar.GetFocusedRowCellValue("IdLugar").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Lugar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
        
    }
}