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
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion.Utils;
using Excel = Microsoft.Office.Interop.Excel;

namespace SSOMA.Presentacion.Modulos.Accidente.Registros
{
    public partial class frmRegAccidente : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<AccidenteBE> mLista = new List<AccidenteBE>();

        #endregion

        #region "Eventos"

        public frmRegAccidente()
        {
            InitializeComponent();
           
            gcFechaEntrega.Caption = "Fecha";
            gcEmpresaInvolucrada.Caption = "Empresa\nResponsable";
            gcAreaInvolucrada.Caption = "Area\nResponsable";
            gcSedeResponsable.Caption = "Sede\nResponsable";
            gcProbabilidad.Caption = "Probabilidad\nOcurrencia";
            gcPotencial.Caption = "Potencial\nDaño";
            gcGrado.Caption = "Grado\nAccidente";
        }

        private void frmRegAccidente_Load(object sender, EventArgs e)
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
                frmRegAccidenteEdit objManAccidente = new frmRegAccidenteEdit();
                objManAccidente.pOperacion = frmRegAccidenteEdit.Operacion.Nuevo;
                objManAccidente.IdAccidente = 0;
                objManAccidente.StartPosition = FormStartPosition.CenterParent;
                objManAccidente.ShowDialog();
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
                        AccidenteBE objE_Accidente = new AccidenteBE();
                        objE_Accidente.IdAccidente = int.Parse(gvAccidente.GetFocusedRowCellValue("IdAccidente").ToString());
                        objE_Accidente.Usuario = Parametros.strUsuarioLogin;
                        objE_Accidente.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Accidente.IdEmpresa = Parametros.intEmpresaId;

                        AccidenteBL objBL_Accidente = new AccidenteBL();
                        objBL_Accidente.Elimina(objE_Accidente);
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
            try
            {
                Cursor = Cursors.WaitCursor;

                if (gvAccidente.RowCount > 0)
                {
                    int intIdAccidente =  int.Parse(gvAccidente.GetFocusedRowCellValue("IdAccidente").ToString());
                    int intIdTipo = int.Parse(gvAccidente.GetFocusedRowCellValue("IdTipo").ToString());

                    BSUtils.ExportarFormatoExcel("", intIdAccidente, intIdTipo, true);
                }

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
            //string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            //string _fileName = "ListadoAccidentes";
            //FolderBrowserDialog f = new FolderBrowserDialog();
            //f.ShowDialog(this);
            //if (f.SelectedPath != "")
            //{
            //    Cursor = Cursors.AppStarting;
            //    gvAccidente.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
            //    string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
            //    XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    Cursor = Cursors.Default;
            //}

            ExportarFormatoExcel("");
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvAccidente_DoubleClick(object sender, EventArgs e)
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

        private void gvAccidente_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (e.Column.FieldName == "DescProbabilidadOcurrencia")
                {
                    string Tipo = View.GetRowCellDisplayText(e.RowHandle, View.Columns["DescProbabilidadOcurrencia"]);
                    if (Tipo == "BAJA")
                    {
                        e.Appearance.BackColor = Color.Blue;
                        e.Appearance.ForeColor = Color.White;
                    }
                    if (Tipo == "ALTA")
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                    if (Tipo == "MEDIA")
                    {
                        e.Appearance.BackColor = Color.FromArgb(0, 255, 0);
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void enviarFotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int intIdAccidente = int.Parse(gvAccidente.GetFocusedRowCellValue("IdAccidente").ToString());
                string strNumero = gvAccidente.GetFocusedRowCellValue("Numero").ToString();
                int intIdTipo = int.Parse(gvAccidente.GetFocusedRowCellValue("IdTipo").ToString());
                string strTipo = gvAccidente.GetFocusedRowCellValue("DescTipo").ToString();
                int intIdDanio = int.Parse(gvAccidente.GetFocusedRowCellValue("IdDanio").ToString());
                string strResponsable = gvAccidente.GetFocusedRowCellValue("Responsable").ToString();
                string strTipoMaterial = gvAccidente.GetFocusedRowCellValue("TipoMaterial").ToString();
                string strEmpresaResponsable = gvAccidente.GetFocusedRowCellValue("EmpresaResponsable").ToString();
                string strUnidadMineraResponsable = gvAccidente.GetFocusedRowCellValue("UnidadMineraResponsable").ToString();

                if (gvAccidente.RowCount > 0)
                {
                    //GENERAR EL REPORTE EN EXCEL
                    BSUtils.ExportarFormatoExcel("", intIdAccidente, intIdTipo, true);

                    StringBuilder strMensaje = new StringBuilder();
                    strMensaje.Append("***********************************************************************************************************************\n\n");
                    if (intIdDanio == Parametros.intDACTrabajador)
                    {
                        strMensaje.Append("Se Generó el Registro de " + strTipo + " de Trabajo N°: " + strNumero + "  " + strResponsable + "\n\n");
                        strMensaje.Append("Razón Social : " + strEmpresaResponsable + "\n\n");
                        strMensaje.Append("Sede         : " + strUnidadMineraResponsable + "\n\n");
                        strMensaje.Append("Tipo         : " + strTipo + "\n\n");
                        strMensaje.Append("Regularizar las acciones correctivas y/o preventivas de acuerdo a las fechas descritas en el archivo adjunto" + "\n\n");
                    }
                    else
                    {
                        strMensaje.Append("Se Generó el Registro de " + strTipo + " de Trabajo N°: " + strNumero + "  " + strTipoMaterial + "\n\n");
                        strMensaje.Append("Razón Social : " + strEmpresaResponsable + "\n\n");
                        strMensaje.Append("Sede         : " + strUnidadMineraResponsable + "\n\n");
                        strMensaje.Append("Tipo         : " + strTipo + "\n\n");
                        strMensaje.Append("Regularizar las acciones correctivas y/o preventivas de acuerdo a las fechas descritas en el archivo adjunto" + "\n\n");
                    }


                    string strMailTO = "";

                    string strMailJefeDirecto = gvAccidente.GetFocusedRowCellValue("CorreoJefeDirecto").ToString();
                    string strMailResponsableArea = gvAccidente.GetFocusedRowCellValue("CorreoResponsableArea").ToString();
                    string strMailInvestigado = gvAccidente.GetFocusedRowCellValue("CorreoInvestigadoPor").ToString();
                    string strMailRevisado = gvAccidente.GetFocusedRowCellValue("CorreoRevisadoPor").ToString();



                    if (intIdDanio == Parametros.intDACTrabajador)
                        strMailTO = strMailInvestigado + ";" + strMailRevisado + ";" + strMailJefeDirecto;
                    else
                        strMailTO = strMailInvestigado + ";" + strMailRevisado + ";" + strMailResponsableArea;

                    List<AccidenteAccionCorrectivaBE> mListaAccidenteAccionCorrectiva = null;
                    mListaAccidenteAccionCorrectiva = new AccidenteAccionCorrectivaBL().ListaTodosActivo(intIdAccidente);

                    if (mListaAccidenteAccionCorrectiva.Count > 0)
                    {
                        foreach (var item in mListaAccidenteAccionCorrectiva)
                        {
                            PersonaBE objE_Persona = new PersonaBE();
                            objE_Persona = new PersonaBL().Selecciona(0, 0, 0, item.IdResponsable);
                            if (objE_Persona != null)
                            {
                                strMailTO = strMailTO + ";" + objE_Persona.Email;
                                strMensaje.Append(item.DescAccionCorrectiva.Trim() + "  " + item.Responsable + "  " + item.FechaCumplimiento.ToString().Substring(0, 10) + "\n");
                            }
                        }
                    }

                    
                    strMensaje.Append(" " + "\n");
                    strMensaje.Append("Emitido Por el Area de Seguridad y Salud en el Trabajo" + "\n\n");
                    strMensaje.Append("***********************************************************************************************************************\n\n");


                    BSUtils.EmailSend(strMailTO, strTipo + " DE TRABAJO", strMensaje.ToString(), @"D:\" + strTipo + " " + strNumero + ".xlsx","", "", "");

                    XtraMessageBox.Show("El Correo se envio correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            mLista = new AccidenteBL().ListaFecha(Parametros.intEmpresaId, 0, 0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcAccidente.DataSource = mLista;
        }

        private void CargarNumero(int Numero)
        {
            mLista = new AccidenteBL().ListaNumero(Numero);
            gcAccidente.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvAccidente.RowCount > 0)
            {
                AccidenteBE objAccidente = new AccidenteBE();
                objAccidente.IdAccidente = int.Parse(gvAccidente.GetFocusedRowCellValue("IdAccidente").ToString());

                frmRegAccidenteEdit objManAccidenteEdit = new frmRegAccidenteEdit();
                objManAccidenteEdit.pOperacion = frmRegAccidenteEdit.Operacion.Modificar;
                objManAccidenteEdit.IdAccidente = objAccidente.IdAccidente;
                objManAccidenteEdit.StartPosition = FormStartPosition.CenterParent;
                objManAccidenteEdit.ShowDialog();

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

            if (gvAccidente.GetFocusedRowCellValue("IdAccidente").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Accidente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            filename = Path.Combine(Directory.GetCurrentDirectory(), "Seguimiento de Accidentes.xlsx");
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int intItem = 1;
                int intRow = 5;

                List<AccidenteBE> lstAccidente = null;
                lstAccidente = new AccidenteBL().ListaSeguimiento(Parametros.intEmpresaId, 0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                if (lstAccidente.Count > 0)
                {
                    PictureBox picImg = new PictureBox();
                    picImg.Image = new FuncionBase().Bytes2Image((byte[])lstAccidente[0].Logo);
                    string strRuta = Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg");

                    picImg.Image.Save(strRuta, System.Drawing.Imaging.ImageFormat.Jpeg);

                    xlHoja.Shapes.AddPicture(Path.Combine(Directory.GetCurrentDirectory(), "Logo.jpg"), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 40, 15, 65, 45);

                    foreach (var item in lstAccidente)
                    {
                        xlHoja.Cells[intRow, "A"] = intItem.ToString();
                        xlHoja.Cells[intRow, "B"] = item.EmpresaResponsable;
                        xlHoja.Cells[intRow, "C"] = item.DescTipo;
                        xlHoja.Cells[intRow, "D"] = item.UnidadMineraResponsable;
                        xlHoja.Cells[intRow, "E"] = item.SectorResponsable;
                        xlHoja.Cells[intRow, "F"] = item.Descripcion;
                        xlHoja.Cells[intRow, "G"] = item.DescAccionCorrectiva;
                        xlHoja.Cells[intRow, "H"] = item.FechaCumplimiento;
                        xlHoja.Cells[intRow, "I"] = item.Responsable;
                        xlHoja.Cells[intRow, "J"] = item.DescSituacion;

                        intItem++;
                        intRow++;
                    }

                }

                string strMensaje = "";
                xlLibro.SaveAs("D:\\Seguimiento de Accidentes.xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                strMensaje = "El Seguimiento de los Accidentes se exportó correctamente \n Se generó el archivo D:\\Seguimiento de Accidentes.xlsx";

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