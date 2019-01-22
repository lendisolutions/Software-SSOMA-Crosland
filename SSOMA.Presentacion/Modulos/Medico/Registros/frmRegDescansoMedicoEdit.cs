using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Funciones;
using CrystalDecisions.CrystalReports.Engine;
using SSOMA.BusinessLogic;
using SSOMA.BusinessEntity;
using SSOMA.Presentacion.Modulos.Otros;

namespace SSOMA.Presentacion.Modulos.Medico.Registros
{
    public partial class frmRegDescansoMedicoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private int intIdPersona = 0;
        private int intIdEmpresa = 0;
        private int intIdUnidadMinera = 0;
        private int intIdArea = 0;

        int _IdDescansoMedico = 0;

        public int IdDescansoMedico
        {
            get { return _IdDescansoMedico; }
            set { _IdDescansoMedico = value; }
        }

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;

        #endregion

        #region "Eventos"

        public frmRegDescansoMedicoEdit()
        {
            InitializeComponent();
        }

        private void frmRegDescansoMedicoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTipoDescansoMedico, new TipoDescansoMedicoBL().ListaTodosActivo(0), "DescTipoDescansoMedico", "IdTipoDescansoMedico", true);

            deFechaIni.EditValue = DateTime.Now;
            deFechaFin.EditValue = DateTime.Now.AddDays(1);

            BSUtils.LoaderLook(cboMes, CargarMes(), "Descripcion", "Id", false);
            cboMes.EditValue = DateTime.Now.Month;

            BSUtils.LoaderLook(cboContingencia, new ContingenciaBL().ListaTodosActivo(0), "DescContingencia", "IdContingencia", true);
            BSUtils.LoaderLook(cboCategoriaDiagnostico, new CategoriaDiagnosticoBL().ListaTodosActivo(0), "Abreviatura", "IdCategoriaDiagnostico", true);
            BSUtils.LoaderLook(cboCondicionDescansoMedico, new CondicionDescansoMedicoBL().ListaTodosActivo(0), "DescCondicionDescansoMedico", "IdCondicionDescansoMedico", true);

           

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Registro Descanso Médico - Nuevo ";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Registro Descanso Médico - Modificar ";
                DescansoMedicoBE objE_DescansoMedico = null;
                objE_DescansoMedico = new DescansoMedicoBL().Selecciona(IdDescansoMedico);
                if (objE_DescansoMedico != null)
                {
                    IdDescansoMedico = objE_DescansoMedico.IdDescansoMedico;
                    txtNumero.Text = objE_DescansoMedico.Numero;
                    intIdPersona = objE_DescansoMedico.IdPersona;
                    txtTrabajador.Text = objE_DescansoMedico.ApeNom;
                    txtCargo.Text = objE_DescansoMedico.Cargo;
                    intIdEmpresa = objE_DescansoMedico.IdEmpresa;
                    txtEmpresa.Text = objE_DescansoMedico.RazonSocial;
                    intIdUnidadMinera = objE_DescansoMedico.IdUnidadMinera;
                    txtUnidadMinera.Text = objE_DescansoMedico.DescUnidadMinera;
                    intIdArea = objE_DescansoMedico.IdArea;
                    txtArea.Text = objE_DescansoMedico.DescArea;
                    cboTipoDescansoMedico.EditValue = objE_DescansoMedico.IdTipoDescansoMedico;
                    deFechaIni.EditValue = objE_DescansoMedico.FechaIni;
                    deFechaFin.EditValue = objE_DescansoMedico.FechaFin;
                    cboMes.EditValue = objE_DescansoMedico.Mes;
                    txtDias.EditValue = objE_DescansoMedico.Dias;
                    txtHoras.EditValue = objE_DescansoMedico.Horas;
                    txtSueldo.EditValue = objE_DescansoMedico.Sueldo;
                    txtKpi.EditValue = objE_DescansoMedico.Kpi;
                    cboContingencia.EditValue = objE_DescansoMedico.IdContingencia;
                    txtDiagnostica.Text = objE_DescansoMedico.Diagnostico;
                    txtCentroMedico.Text = objE_DescansoMedico.CentroMedico;
                    cboCategoriaDiagnostico.EditValue = objE_DescansoMedico.IdCategoriaDiagnostico;
                    cboCondicionDescansoMedico.EditValue = objE_DescansoMedico.IdCondicionDescansoMedico;
                }
            }
        }

        private void btnBuscarResponsable_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = false;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    intIdPersona = frm.pPersonaBE.IdPersona;
                    txtTrabajador.Text = frm.pPersonaBE.ApeNom;
                    txtCargo.Text = frm.pPersonaBE.Cargo;
                    intIdEmpresa = frm.pPersonaBE.IdEmpresa;
                    txtEmpresa.Text = frm.pPersonaBE.RazonSocial;
                    intIdUnidadMinera = frm.pPersonaBE.IdUnidadMinera;
                    txtUnidadMinera.Text = frm.pPersonaBE.DescUnidadMinera;
                    intIdArea = frm.pPersonaBE.IdArea;
                    txtArea.Text = frm.pPersonaBE.DescArea;
                    
                    
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deFechaIni_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                cboMes.EditValue = deFechaIni.DateTime.Month;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deFechaFin_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int intDias = 0;

                DateTime FechaIni = deFechaIni.DateTime;
                DateTime FechaFin = deFechaFin.DateTime;

                intDias = CalculateDays(FechaIni, FechaFin);

                if (intDias >= 0)
                {
                    txtDias.EditValue = intDias + 1;
                    txtHoras.EditValue = (intDias + 1) * 8;
                }
                else
                {
                    XtraMessageBox.Show("La fecha fin no puede ser menor a la fecha de inicio del descanso médico.\n Por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    deFechaFin.Select();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSueldo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtSueldo.EditValue) > 0)
                {
                    decimal decSueldo = 0;
                    decimal decKpi = 0;

                    decSueldo = Convert.ToDecimal(txtSueldo.EditValue);
                    decKpi = ((decSueldo / 30) / 8 ) * Convert.ToInt32(txtHoras.EditValue);
                    txtKpi.EditValue = decKpi;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    DescansoMedicoBE objDescansoMedico = new DescansoMedicoBE();
                    DescansoMedicoBL objBL_DescansoMedico = new DescansoMedicoBL();

                    objDescansoMedico.IdDescansoMedico = IdDescansoMedico;
                    objDescansoMedico.IdEmpresa = intIdEmpresa;
                    objDescansoMedico.IdUnidadMinera = intIdUnidadMinera;
                    objDescansoMedico.IdArea = intIdArea;
                    objDescansoMedico.Numero = txtNumero.Text;
                    objDescansoMedico.IdPersona = intIdPersona;
                    objDescansoMedico.IdTipoDescansoMedico = Convert.ToInt32(cboTipoDescansoMedico.EditValue);
                    objDescansoMedico.FechaIni = Convert.ToDateTime(deFechaIni.DateTime.ToShortDateString());
                    objDescansoMedico.FechaFin = Convert.ToDateTime(deFechaFin.DateTime.ToShortDateString());
                    objDescansoMedico.Mes = Convert.ToInt32(cboMes.EditValue);
                    objDescansoMedico.Dias = Convert.ToInt32(txtDias.EditValue);
                    objDescansoMedico.Horas = Convert.ToInt32(txtHoras.EditValue);
                    objDescansoMedico.Sueldo = Convert.ToDecimal(txtSueldo.EditValue);
                    objDescansoMedico.Kpi = Convert.ToDecimal(txtKpi.EditValue) ;
                    objDescansoMedico.IdContingencia = Convert.ToInt32(cboContingencia.EditValue);
                    objDescansoMedico.Diagnostico = txtDiagnostica.Text;
                    objDescansoMedico.CentroMedico = txtCentroMedico.Text;
                    objDescansoMedico.IdCategoriaDiagnostico = Convert.ToInt32(cboCategoriaDiagnostico.EditValue);
                    objDescansoMedico.IdCondicionDescansoMedico = Convert.ToInt32(cboCondicionDescansoMedico.EditValue);
                    objDescansoMedico.FlagEstado = true;objDescansoMedico.IdCategoriaDiagnostico = Convert.ToInt32(cboCategoriaDiagnostico.EditValue);
                    objDescansoMedico.Usuario = Parametros.strUsuarioLogin;
                    objDescansoMedico.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                   

                    if (pOperacion == Operacion.Nuevo)
                    {
                        int intNumero = 0;
                        string strNumero = "";
                        intNumero = objBL_DescansoMedico.Inserta(objDescansoMedico);
                        strNumero = FuncionBase.AgregarCaracter(intNumero.ToString(), "0", 7);
                        txtNumero.Text = strNumero;

                        //ActualizaNumero
                        DescansoMedicoBL objBDescansoMedico = new DescansoMedicoBL();
                        objBDescansoMedico.ActualizaNumero(intNumero, txtNumero.Text);

                        XtraMessageBox.Show("Se creó el Descanso Médico N° : " + txtNumero.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        objBL_DescansoMedico.Actualiza(objDescansoMedico);
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            
            if (intIdPersona == 0)
            {
                strMensaje = strMensaje + "- Debe Seleccionar el Trabajador.\n";
                flag = true;
            }


            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }
        private DataTable CargarMes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "ENERO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "FEBRERO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["Descripcion"] = "MARZO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 4;
            dr["Descripcion"] = "ABRIL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 5;
            dr["Descripcion"] = "MAYO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 6;
            dr["Descripcion"] = "JUNIO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 7;
            dr["Descripcion"] = "JULIO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 8;
            dr["Descripcion"] = "AGOSTO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 9;
            dr["Descripcion"] = "SEPTIEMBRE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 10;
            dr["Descripcion"] = "OCTUBRE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 11;
            dr["Descripcion"] = "NOVIEMBRE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 12;
            dr["Descripcion"] = "DICIEMBRE";
            dt.Rows.Add(dr);

            return dt;
        }

        private int CalculateDays(DateTime oldDate, DateTime newDate)
        {
            // Diferencia de fechas
            TimeSpan ts = newDate - oldDate;

            // Diferencia de días
            return ts.Days;
        }




        #endregion

        
    }
}