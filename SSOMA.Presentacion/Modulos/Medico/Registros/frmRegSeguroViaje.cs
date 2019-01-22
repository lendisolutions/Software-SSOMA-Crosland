using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using System.Reflection;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SSOMA.Presentacion.Utils;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;

namespace SSOMA.Presentacion.Modulos.Medico.Registros
{
    public partial class frmRegSeguroViaje : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SeguroViajeBE> mLista = new List<SeguroViajeBE>();

        #endregion

        #region "Eventos"

        public frmRegSeguroViaje()
        {
            InitializeComponent();
        }

        private void frmRegSeguroViaje_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            deFechaDesde.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            deFechaHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegSeguroViajeEdit objManSeguroViaje = new frmRegSeguroViajeEdit();
                objManSeguroViaje.pOperacion = frmRegSeguroViajeEdit.Operacion.Nuevo;
                objManSeguroViaje.IdSeguroViaje = 0;
                objManSeguroViaje.StartPosition = FormStartPosition.CenterParent;
                objManSeguroViaje.ShowDialog();
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
                if (XtraMessageBox.Show("Esta seguro de anular la SeguroViaje de EPS?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int intIdSeguroViaje = int.Parse(gvSeguroViaje.GetFocusedRowCellValue("IdSeguroViaje").ToString());
                    int intIdSituacion = int.Parse(gvSeguroViaje.GetFocusedRowCellValue("IdSituacion").ToString());

                    if (intIdSituacion == Parametros.intSVJGenerada)
                    {
                        SeguroViajeBL objBL_SeguroViaje = new SeguroViajeBL();
                        objBL_SeguroViaje.ActualizaSituacion(intIdSeguroViaje, Parametros.intSVJSAnulada);
                        XtraMessageBox.Show("La Seguro de viaje se anuló correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede anular un seguro de viaje diferente al Estado Generada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            try
            {
                Cursor = Cursors.WaitCursor;

                ExportarFormatoExcel("");


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
            string _fileName = "ListadoSeguroViajes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvSeguroViaje.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvSeguroViaje_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtPeriodo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarNumero(Convert.ToInt32(txtPeriodo.Text));
            }
        }

        private void gvSeguroViaje_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "DescSituacion")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["DescSituacion"]);
                        if (Situacion == "GENERADA")
                        {
                            e.Appearance.ForeColor = Color.Blue;
                        }
                        if (Situacion == "ATENDIDA")
                        {
                            e.Appearance.ForeColor = Color.Green;
                        }
                        if (Situacion == "ANULADA")
                        {
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

        private void atenderAfiliacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de atender el seguro de viaje?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int intIdSeguroViaje = int.Parse(gvSeguroViaje.GetFocusedRowCellValue("IdSeguroViaje").ToString());
                    int intIdSituacion = int.Parse(gvSeguroViaje.GetFocusedRowCellValue("IdSituacion").ToString());

                    if (intIdSituacion == Parametros.intSVJGenerada)
                    {
                        SeguroViajeBL objBL_SeguroViaje = new SeguroViajeBL();
                        objBL_SeguroViaje.ActualizaSituacion(intIdSeguroViaje, Parametros.intSVJSAtendida);
                        XtraMessageBox.Show("La Seguro de viaje se atendió correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede atender un seguro de viaje diferente al Estado Generada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            if (Parametros.intPerfilId == 1)
                mLista = new SeguroViajeBL().ListaFecha(0, 0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            else
                mLista = new SeguroViajeBL().ListaFecha(Parametros.intEmpresaId, Parametros.intPersonaId, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

            gcSeguroViaje.DataSource = mLista;
        }

        private void CargarNumero(int Numero)
        {
            mLista = new SeguroViajeBL().ListaNumero(Numero);
            gcSeguroViaje.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvSeguroViaje.RowCount > 0)
            {
                SeguroViajeBE objSeguroViaje = new SeguroViajeBE();
                objSeguroViaje.IdSeguroViaje = int.Parse(gvSeguroViaje.GetFocusedRowCellValue("IdSeguroViaje").ToString());

                int intIdSituacion = int.Parse(gvSeguroViaje.GetFocusedRowCellValue("IdSituacion").ToString());
                if (intIdSituacion == Parametros.intSVJGenerada)
                {
                    frmRegSeguroViajeEdit objManSeguroViajeEdit = new frmRegSeguroViajeEdit();
                    objManSeguroViajeEdit.pOperacion = frmRegSeguroViajeEdit.Operacion.Modificar;
                    objManSeguroViajeEdit.IdSeguroViaje = objSeguroViaje.IdSeguroViaje;
                    objManSeguroViajeEdit.StartPosition = FormStartPosition.CenterParent;
                    objManSeguroViajeEdit.btnGrabar.Enabled = true;
                    objManSeguroViajeEdit.ShowDialog();
                }

                if (intIdSituacion == Parametros.intSVJSAtendida || intIdSituacion == Parametros.intSVJSAnulada)
                {
                    frmRegSeguroViajeEdit objManSeguroViajeEdit = new frmRegSeguroViajeEdit();
                    objManSeguroViajeEdit.pOperacion = frmRegSeguroViajeEdit.Operacion.Modificar;
                    objManSeguroViajeEdit.IdSeguroViaje = objSeguroViaje.IdSeguroViaje;
                    objManSeguroViajeEdit.StartPosition = FormStartPosition.CenterParent;
                    objManSeguroViajeEdit.btnGrabar.Enabled = false;
                    objManSeguroViajeEdit.ShowDialog();
                }



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

            if (gvSeguroViaje.GetFocusedRowCellValue("IdSeguroViaje").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una SeguroViaje", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        void ExportarFormatoExcel(string filename)
        {
            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Seguro de Viaje.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            string strNumero = "";

            try
            {
                
                if (gvSeguroViaje.RowCount > 0)
                {
                    int intIdSeguroViaje = int.Parse(gvSeguroViaje.GetFocusedRowCellValue("IdSeguroViaje").ToString());

                    SeguroViajeBE objE_SeguroViaje = null;
                    objE_SeguroViaje = new SeguroViajeBL().Selecciona(intIdSeguroViaje);
                    if (objE_SeguroViaje != null)
                    {
                        xlHoja.Cells[3,"H"] = objE_SeguroViaje.Numero;
                        strNumero = objE_SeguroViaje.Numero;
                        xlHoja.Cells[8,"D"] = objE_SeguroViaje.FechaSalida;
                        xlHoja.Cells[8,"H"] = objE_SeguroViaje.FechaLlegada;
                        xlHoja.Cells[11,"C"] = objE_SeguroViaje.Dias;
                        xlHoja.Cells[13,"C"] = objE_SeguroViaje.Pais;
                        xlHoja.Cells[13,"H"] = objE_SeguroViaje.FechaNacimiento;
                        xlHoja.Cells[16,"C"] = objE_SeguroViaje.Pasaporte;
                        xlHoja.Cells[16, "H"] = objE_SeguroViaje.Dni;

                        String[] strSolicitante = objE_SeguroViaje.Solicitante.Split(' ');
                        string strPrimerNombre = "";
                        string strSegundoNombre = "";
                        string strApellidoPaterno = "";
                        string strApellidoMaterno = "";

                        int intContardor = 0;
                        foreach (string item in strSolicitante)
                        {
                            intContardor++;
                        }

                        if (intContardor > 3)
                        {
                            strPrimerNombre = strSolicitante[2].ToString();
                            strSegundoNombre = strSolicitante[3].ToString();
                            strApellidoMaterno = strSolicitante[1].ToString();
                            strApellidoPaterno = strSolicitante[0].ToString();
                        }
                        else
                        {
                            strPrimerNombre = strSolicitante[2].ToString();
                            strApellidoMaterno = strSolicitante[1].ToString();
                            strApellidoPaterno = strSolicitante[0].ToString();
                        }

                        xlHoja.Cells[18,"C"] = strApellidoPaterno;
                        xlHoja.Cells[18,"F"] = strApellidoMaterno;
                        xlHoja.Cells[20,"C"] = strPrimerNombre;
                        xlHoja.Cells[20,"F"] = strSegundoNombre;
                        xlHoja.Cells[22,"C"] = objE_SeguroViaje.Direccion;
                        xlHoja.Cells[24,"C"] = objE_SeguroViaje.Distrito;
                        xlHoja.Cells[26,"C"] = objE_SeguroViaje.Telefono;
                        xlHoja.Cells[28,"C"] = objE_SeguroViaje.Email + " / " + objE_SeguroViaje.EmailPersonal;
                        xlHoja.Cells[32,"C"] = objE_SeguroViaje.Contacto;
                        xlHoja.Cells[34,"C"] = objE_SeguroViaje.TelefonoContacto1;
                        xlHoja.Cells[36,"C"] = objE_SeguroViaje.TelefonoContacto2;
                        xlHoja.Cells[42,"B"] = objE_SeguroViaje.EmpresaBoleta;
                        xlHoja.Cells[46,"C"] = objE_SeguroViaje.EmpresaFactura;
                        xlHoja.Cells[48,"C"] = objE_SeguroViaje.Ruc;
                        xlHoja.Cells[56,"C"] = objE_SeguroViaje.Solicitante;
                        xlHoja.Cells[57,"C"] = objE_SeguroViaje.Cargo;
                        xlHoja.Cells[60,"C"] = objE_SeguroViaje.RazonSocial;
                        xlHoja.Cells[61,"C"] = objE_SeguroViaje.Autoriza;
                        xlHoja.Cells[60, "H"] = objE_SeguroViaje.Oiseco;
                    }


                }

                string strMensaje = "";
                xlLibro.SaveAs("D:\\Seguro de Viaje " + strNumero + ".xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                strMensaje = "El Seguro de viaje se exportó correctamente \n Se generó el archivo D:\\Seguro de viaje " + strNumero + ".xlsx";

                xlLibro.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cursor.Current = Cursors.Default;

                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        #endregion

       
    }
}