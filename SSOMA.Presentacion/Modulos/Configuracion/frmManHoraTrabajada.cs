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
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion.Utils;

namespace SSOMA.Presentacion.Modulos.Configuracion
{
    public partial class frmManHoraTrabajada : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<HoraTrabajadaBE> mLista = new List<HoraTrabajadaBE>();
        string strFleExcel = "";
        
        #endregion

        #region "Eventos"

        public frmManHoraTrabajada()
        {
            InitializeComponent();
        }

        private void frmManHoraTrabajada_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = DateTime.Now.Year;
           

            Cargar();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnImportarHoras_Click(object sender, EventArgs e)
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

        private void Cargar()
        {
            mLista = new HoraTrabajadaBL().ListaTodosActivo(Convert.ToInt32(txtPeriodo.EditValue));
            gcHoraTrabajada.DataSource = mLista;
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
           
            try
            {
                Cursor = Cursors.WaitCursor;

                List<HoraTrabajadaBE> lstHorasTrabajadas = new List<HoraTrabajadaBE>();

                //CROSLAND LOGISTICA S.A.C.
                int MesCL = 1;
                for (int i = 5; i < 17; i++)
                {
                    if (xlHoja.get_Range("H" + i, Missing.Value).Text.ToString().Trim() != "")
                    {
                        HoraTrabajadaBE objHoraTrabajadaCL = new HoraTrabajadaBE();
                        objHoraTrabajadaCL.IdEmpresa = 1;
                        objHoraTrabajadaCL.Periodo = Convert.ToInt32(xlHoja.get_Range("B1").Text.ToString().Trim());
                        objHoraTrabajadaCL.Mes = MesCL;
                        decimal decHoraTrabajada = 0;
                        decHoraTrabajada = Convert.ToDecimal(xlHoja.get_Range("H" + i, Missing.Value).Text.ToString().Trim());
                        objHoraTrabajadaCL.Hora = Convert.ToInt32(decHoraTrabajada);
                        objHoraTrabajadaCL.FlagEstado = true;
                        lstHorasTrabajadas.Add(objHoraTrabajadaCL);
                        MesCL++;
                    }
                    else
                    {
                        break;
                    }

                }

                //CROSLAND FINANZAS S.A.C
                int MesCF = 1;
                for (int i = 5; i < 17; i++)
                {
                    if (xlHoja.get_Range("I" + i, Missing.Value).Text.ToString().Trim() != "")
                    {
                        HoraTrabajadaBE objHoraTrabajadaCL = new HoraTrabajadaBE();
                        objHoraTrabajadaCL.IdEmpresa = 2;
                        objHoraTrabajadaCL.Periodo = Convert.ToInt32(xlHoja.get_Range("B1").Text.ToString().Trim());
                        objHoraTrabajadaCL.Mes = MesCF;
                        decimal decHoraTrabajada = 0;
                        decHoraTrabajada = Convert.ToDecimal(xlHoja.get_Range("I" + i, Missing.Value).Text.ToString().Trim());
                        objHoraTrabajadaCL.Hora = Convert.ToInt32(decHoraTrabajada);
                        objHoraTrabajadaCL.FlagEstado = true;
                        lstHorasTrabajadas.Add(objHoraTrabajadaCL);
                        MesCF++;
                    }
                    else
                    {
                        break;
                    }

                }


                //CROSLAND REPUESTOS S.A.C.
                int MesCR = 1;
                for (int i = 5; i < 17; i++)
                {
                    if (xlHoja.get_Range("F" + i, Missing.Value).Text.ToString().Trim() != "")
                    {
                        HoraTrabajadaBE objHoraTrabajadaCL = new HoraTrabajadaBE();
                        objHoraTrabajadaCL.IdEmpresa = 3;
                        objHoraTrabajadaCL.Periodo = Convert.ToInt32(xlHoja.get_Range("B1").Text.ToString().Trim());
                        objHoraTrabajadaCL.Mes = MesCR;
                        decimal decHoraTrabajada = 0;
                        decHoraTrabajada = Convert.ToDecimal(xlHoja.get_Range("F" + i, Missing.Value).Text.ToString().Trim());
                        objHoraTrabajadaCL.Hora = Convert.ToInt32(decHoraTrabajada);
                        objHoraTrabajadaCL.FlagEstado = true;
                        lstHorasTrabajadas.Add(objHoraTrabajadaCL);
                        MesCR++;
                    }
                    else
                    {
                        break;
                    }

                }


                //CROSLAND AUTOMOTRIZ S.A.C.
                int MesCA = 1;
                for (int i = 5; i < 17; i++)
                {
                    if (xlHoja.get_Range("C" + i, Missing.Value).Text.ToString().Trim() != "")
                    {
                        HoraTrabajadaBE objHoraTrabajadaCL = new HoraTrabajadaBE();
                        objHoraTrabajadaCL.IdEmpresa = 4;
                        objHoraTrabajadaCL.Periodo = Convert.ToInt32(xlHoja.get_Range("B1").Text.ToString().Trim());
                        objHoraTrabajadaCL.Mes = MesCA;
                        decimal decHoraTrabajada = 0;
                        decHoraTrabajada = Convert.ToDecimal(xlHoja.get_Range("C" + i, Missing.Value).Text.ToString().Trim());
                        objHoraTrabajadaCL.Hora = Convert.ToInt32(decHoraTrabajada);
                        objHoraTrabajadaCL.FlagEstado = true;
                        lstHorasTrabajadas.Add(objHoraTrabajadaCL);
                        MesCA++;
                    }
                    else
                    {
                        break;
                    }

                }

                //CROSLAND TECNICA S.A.C.
                int MesCT = 1;
                for (int i = 5; i < 17; i++)
                {
                    if (xlHoja.get_Range("B" + i, Missing.Value).Text.ToString().Trim() != "")
                    {
                        HoraTrabajadaBE objHoraTrabajadaCL = new HoraTrabajadaBE();
                        objHoraTrabajadaCL.IdEmpresa = 5;
                        objHoraTrabajadaCL.Periodo = Convert.ToInt32(xlHoja.get_Range("B1").Text.ToString().Trim());
                        objHoraTrabajadaCL.Mes = MesCT;
                        decimal decHoraTrabajada = 0;
                        decHoraTrabajada = Convert.ToDecimal(xlHoja.get_Range("B" + i, Missing.Value).Text.ToString().Trim());
                        objHoraTrabajadaCL.Hora = Convert.ToInt32(decHoraTrabajada);
                        objHoraTrabajadaCL.FlagEstado = true;
                        lstHorasTrabajadas.Add(objHoraTrabajadaCL);
                        MesCT++;
                    }
                    else
                    {
                        break;
                    }

                }

                HoraTrabajadaBL objBL_Planilla = new HoraTrabajadaBL();
                objBL_Planilla.Inserta(lstHorasTrabajadas);
                XtraMessageBox.Show("Los Datos de las Horas Trabajadas se guardaron conrrectamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();

                Cargar();

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                xlApp.Quit();
                XtraMessageBox.Show(ex.Message + "\n N° Secuencia : " , ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        #endregion

       

        
        

        
        
    }
}