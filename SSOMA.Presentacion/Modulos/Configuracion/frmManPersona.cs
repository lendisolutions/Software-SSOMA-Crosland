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

namespace SSOMA.Presentacion.Modulos.Configuracion
{
    public partial class frmManPersona : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PersonaBE> mLista = new List<PersonaBE>();

        int IdEmpresa = 0;
        int IdUnidadMinera = 0;
        int IdArea = 0;

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
                if (IdEmpresa==0)
                {
                    XtraMessageBox.Show("Debe seleccionar la empresa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (IdUnidadMinera == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar la sede", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (IdArea == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar el area", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmManPersonaEdit objManPersona = new frmManPersonaEdit();
                objManPersona.lstPersona = mLista;
                objManPersona.pOperacion = frmManPersonaEdit.Operacion.Nuevo;
                objManPersona.IdEmpresa = IdEmpresa;
                objManPersona.IdUnidadMinera = IdUnidadMinera;
                objManPersona.IdArea = IdArea;
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
                    break;
                case "UMM":
                    IdUnidadMinera = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaTreeviewAreas(e.Node);
                    break;
                case "ARE":
                    IdArea = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
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

        private void btnImportar_Click(object sender, EventArgs e)
        {
            strFleExcel = "";
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xls;*.xlsx";
            if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                strFleExcel = objOpenFileDialog.FileName;
                ImportarExcel();
            }
        }

        #endregion

        #region "Metodos"

        private void CargaTreeview()
        {
            tvwDatos.Nodes.Clear();

            List<EmpresaBE> lstEmpresa = null;
            lstEmpresa = new EmpresaBL().ListaTodosActivo(Parametros.intEmpresaId,Parametros.intTECorporativo);
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
            lstArea = new AreaBL().ListaTodosActivo(IdEmpresa, IdUnidadMinera);
            foreach (var item in lstArea)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 3;
                nuevoNodoChild.SelectedImageIndex = 3;
                nuevoNodoChild.Text = item.DescArea;
                nuevoNodoChild.Tag = "ARE" + item.IdArea.ToString();
                nodo.Nodes.Add(nuevoNodoChild);
            }
        }

        private void Cargar()
        {
            mLista = new PersonaBL().ListaTodosActivo(IdEmpresa, IdUnidadMinera,IdArea);
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
                objManPersonaEdit.IdUnidadMinera = objSSOMA.IdUnidadMinera;
                objManPersonaEdit.IdArea = objSSOMA.IdArea;
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

        private void ImportarExcel()
        {
            if (strFleExcel == "")
            {
                return;
            }

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            xlLibro = xlApp.Workbooks.Open(strFleExcel, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];
            int Secuencia = 2;
            int _row = 2;
            int _totRow = 2;

            try
            {

                //Contador de Registros
                while (FuncionBase.IsNumeric((string)xlHoja.get_Range("A" + _totRow, Missing.Value).Text.ToString().Trim()))
                {
                    if (FuncionBase.IsNumeric((string)xlHoja.get_Range("A" + _totRow, Missing.Value).Text.ToString().Trim()))
                        _totRow++;
                }
                _totRow = _totRow - _row + 1;
                prgPlanilla.Minimum = 1;
                prgPlanilla.Maximum = _totRow;
                Application.DoEvents();
                prgPlanilla.Value = 1;
                Application.DoEvents();

                List<PersonaBE> lstPersona = new List<PersonaBE>();

                while (FuncionBase.IsNumeric((string)xlHoja.get_Range("A" + _row, Missing.Value).Text.ToString().Trim()))
                {
                    //Declaracion de variables

             
                    if (xlHoja.get_Range("T" + _row, Missing.Value).Text.ToString().Trim() == "ACTIVO")
                    {
                        int intIdPersona = 0;
                        string strRuc = "";
                        int intIdEmpresa = 0;
                        string strDescNegocio = "";
                        int intIdNegocio = 0;
                        string strDescUnidadMinera = "";
                        int intIdUnidadMinera = 0;
                        string strDescArea = "";
                        int intIdArea = 0;
                        string strDni = "";
                        string strApeNom = "";
                        DateTime FechaNacimiento = new DateTime(2010, 1, 1);
                        string strEdad = "";
                        DateTime FechaIngreso = new DateTime(2000, 1, 1);
                        DateTime? FechaCese = null;
                        string strCargo = "";
                        string strSexo = "";
                        string strDescTipoContrato = "";
                        int intIdTipoContrato = 0;
                        string strDescEstadoCivil = "";
                        int intIdEstadoCivil = 0;
                        string strEmail = "";
                        int intIdSituacion = 0;

                        strRuc = (string)xlHoja.get_Range("D" + _row, Missing.Value).Text.ToString().Trim();
                        EmpresaBE objE_Empresa = null;
                        objE_Empresa = new EmpresaBL().SeleccionaRuc(strRuc);
                        if (objE_Empresa != null)
                        {
                            intIdEmpresa = objE_Empresa.IdEmpresa;

                            strDescNegocio = (string)xlHoja.get_Range("E" + _row, Missing.Value).Text.ToString().Trim();
                            NegocioBE objE_Negocio = null;
                            objE_Negocio = new NegocioBL().SeleccionaDescripcion(intIdEmpresa, strDescNegocio);
                            if (objE_Negocio != null)
                            {
                                intIdNegocio = objE_Negocio.IdNegocio;
                            }
                            else
                            {
                                intIdNegocio = Parametros.intPeriodo;
                            }

                            strDescUnidadMinera = (string)xlHoja.get_Range("F" + _row, Missing.Value).Text.ToString().Trim();

                            if ((string)xlHoja.get_Range("F" + _row, Missing.Value).Text.ToString().Trim() == "OFICINA SAN ISIDRO")
                            {
                                strDescUnidadMinera = "SAN ISIDRO";
                            }

                            if ((string)xlHoja.get_Range("F" + _row, Missing.Value).Text.ToString().Trim() == "Oficina Lima")
                            {
                                strDescUnidadMinera = "SAN ISIDRO";
                            }

                            if ((string)xlHoja.get_Range("F" + _row, Missing.Value).Text.ToString().Trim() == "Oficina Callao")
                            {
                                strDescUnidadMinera = "CALLAO";
                            }

                            if ((string)xlHoja.get_Range("F" + _row, Missing.Value).Text.ToString().Trim() == "DEPOSITO ANCON")
                            {
                                strDescUnidadMinera = "ANCON";
                            }

                            if ((string)xlHoja.get_Range("F" + _row, Missing.Value).Text.ToString().Trim() == "Oficina Cusco")
                            {
                                strDescUnidadMinera = "CUZCO";
                            }

                            if ((string)xlHoja.get_Range("F" + _row, Missing.Value).Text.ToString().Trim() == "Oficina Ollantaytambo")
                            {
                                strDescUnidadMinera = "OLLANTAYTAMBO";
                            }

                            if ((string)xlHoja.get_Range("F" + _row, Missing.Value).Text.ToString().Trim() == "Oficina Machu Picchu")
                            {
                                strDescUnidadMinera = "MACHU PICCHU";
                            }

                            if ((string)xlHoja.get_Range("F" + _row, Missing.Value).Text.ToString().Trim() == "Oficina Aeropuerto LAP")
                            {
                                strDescUnidadMinera = "AEROPUERTO LAP";
                            }

                            UnidadMineraBE objE_UnidadMinera = null;
                            objE_UnidadMinera = new UnidadMineraBL().SeleccionaDescripcion(intIdEmpresa, strDescUnidadMinera);
                            if (objE_UnidadMinera != null)
                            {
                                intIdUnidadMinera = objE_UnidadMinera.IdUnidadMinera;
                            }
                            else
                            {
                                XtraMessageBox.Show("N° Secuencia : " + Secuencia.ToString() + "\n Unidad Minera: " + strDescUnidadMinera, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                xlLibro.Close(false, Missing.Value, Missing.Value);
                                xlApp.Quit();
                                this.Dispose();
                                this.Close();
                            }

                            strDescArea = (string)xlHoja.get_Range("G" + _row, Missing.Value).Text.ToString().Trim();

                            if ((string)xlHoja.get_Range("G" + _row, Missing.Value).Text.ToString().Trim() == "")
                            {
                                strDescArea = "NINGUNO";
                            }

                            AreaBE objE_Area = null;
                            objE_Area = new AreaBL().SeleccionaDescripcion(intIdEmpresa, intIdUnidadMinera, strDescArea);
                            if (objE_Area != null)
                            {
                                intIdArea = objE_Area.IdArea;
                            }
                            else
                            {
                                XtraMessageBox.Show("N° Secuencia : " + Secuencia.ToString() + "\n Area: " + strDescArea, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                xlLibro.Close(false, Missing.Value, Missing.Value);
                                xlApp.Quit();
                                this.Dispose();
                                this.Close();
                            }

                            strDni = (string)xlHoja.get_Range("C" + _row, Missing.Value).Text.ToString().Trim();
                            strApeNom = (string)xlHoja.get_Range("I" + _row, Missing.Value).Text.ToString().Trim() + " " + xlHoja.get_Range("J" + _row, Missing.Value).Text.ToString().Trim() + " " + xlHoja.get_Range("H" + _row, Missing.Value).Text.ToString().Trim();
                            FechaNacimiento = Convert.ToDateTime(xlHoja.get_Range("K" + _row, Missing.Value).Text.ToString().Trim());
                            strEdad = (string)xlHoja.get_Range("L" + _row, Missing.Value).Text.ToString().Trim();
                            FechaIngreso = Convert.ToDateTime(xlHoja.get_Range("M" + _row, Missing.Value).Text.ToString().Trim());

                            if (xlHoja.get_Range("N" + _row, Missing.Value).Text.ToString().Trim() == "")
                                FechaCese = (DateTime?)null;
                            else
                                FechaCese = Convert.ToDateTime(xlHoja.get_Range("N" + _row, Missing.Value).Text.ToString().Trim());

                            strCargo = (string)xlHoja.get_Range("O" + _row, Missing.Value).Text.ToString().Trim();

                            if (xlHoja.get_Range("P" + _row, Missing.Value).Text.ToString().Trim() == "F")
                                strSexo = "FEMENINO";
                            else
                                strSexo = "MASCULINO";

                            strDescTipoContrato = (string)xlHoja.get_Range("Q" + _row, Missing.Value).Text.ToString().Trim();
                            TablaElementoBE objE_TablaElemento = null;
                            objE_TablaElemento = new TablaElementoBL().SeleccionaDescripcion(Parametros.intTblTipoContrato, strDescTipoContrato);
                            if (objE_TablaElemento != null)
                            {
                                intIdTipoContrato = objE_TablaElemento.IdTablaElemento;
                            }
                            else
                            {
                                XtraMessageBox.Show("N° Secuencia : " + Secuencia.ToString() + "\n Tipo de Contrato: " + strDescTipoContrato, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                xlLibro.Close(false, Missing.Value, Missing.Value);
                                xlApp.Quit();
                                this.Dispose();
                                this.Close();
                            }

                            strDescEstadoCivil = (string)xlHoja.get_Range("R" + _row, Missing.Value).Text.ToString().Trim();
                            TablaElementoBE objE_TablaElementoCivil = null;
                            objE_TablaElementoCivil = new TablaElementoBL().SeleccionaDescripcion(Parametros.intTblEstadoCivil, strDescEstadoCivil);
                            if (objE_TablaElementoCivil != null)
                            {
                                intIdEstadoCivil = objE_TablaElementoCivil.IdTablaElemento;
                            }
                            else
                            {
                                XtraMessageBox.Show("N° Secuencia : " + Secuencia.ToString() + "\n Estado Civil: " + strDescEstadoCivil, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                xlLibro.Close(false, Missing.Value, Missing.Value);
                                xlApp.Quit();
                                this.Dispose();
                                this.Close();
                            }

                            strEmail = (string)xlHoja.get_Range("S" + _row, Missing.Value).Text.ToString().Trim();

                            if (xlHoja.get_Range("T" + _row, Missing.Value).Text.ToString().Trim() == "ACTIVO")
                                intIdSituacion = Parametros.intSPActivo;
                            else
                                intIdSituacion = Parametros.intSPCesado;


                            PersonaBE objE_Persona = new PersonaBE();
                            objE_Persona.IdPersona = intIdPersona;
                            objE_Persona.IdEmpresa = intIdEmpresa;
                            objE_Persona.IdNegocio = intIdNegocio;
                            objE_Persona.IdUnidadMinera = intIdUnidadMinera;
                            objE_Persona.IdArea = intIdArea;
                            objE_Persona.Dni = strDni;
                            objE_Persona.ApeNom = strApeNom;
                            objE_Persona.FechaNacimiento = FechaNacimiento;
                            objE_Persona.Edad = Convert.ToInt32(strEdad);
                            objE_Persona.FechaIngreso = FechaIngreso;
                            objE_Persona.FechaCese = FechaCese;
                            objE_Persona.Cargo = strCargo;
                            objE_Persona.Sexo = strSexo;
                            objE_Persona.IdTipoContrato = intIdTipoContrato;
                            objE_Persona.IdEstadoCivil = intIdEstadoCivil;
                            objE_Persona.Email = strEmail;
                            objE_Persona.IdSituacion = intIdSituacion;
                            objE_Persona.FlagEstado = true;
                            objE_Persona.Usuario = Parametros.strUsuarioLogin;
                            objE_Persona.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                            lstPersona.Add(objE_Persona);

                        }

                    }

                    prgPlanilla.Value = prgPlanilla.Value + 1;
                    Application.DoEvents();
                    _row++;
                    Secuencia++;
                }

                PersonaBL objBL_Persona = new PersonaBL();
                objBL_Persona.InsertaMasivo(lstPersona);
                XtraMessageBox.Show("Los Datos de las Personas se guardaron conrrectamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                this.Close();
            }
            catch (Exception ex)
            {

                xlApp.Quit();
                XtraMessageBox.Show(ex.Message + "\n N° Secuencia : " + Secuencia.ToString(), ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


        #endregion


    }
}