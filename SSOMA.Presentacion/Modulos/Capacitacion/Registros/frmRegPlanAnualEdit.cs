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
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion.Modulos.Otros;
using SSOMA.BusinessLogic;
using SSOMA.BusinessEntity;

namespace SSOMA.Presentacion.Modulos.Capacitacion.Registros
{
    public partial class frmRegPlanAnualEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PlanAnualBE> lstPlanAnual;

        public List<CPlanAnualDetalle> mListaPlanAnualDetalleOrigen = new List<CPlanAnualDetalle>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public int intIdEmpresa { get; set; }
        public int intIdUnidadMinera { get; set; }

        int _IdPlanAnual = 0;

        public int IdPlanAnual
        {
            get { return _IdPlanAnual; }
            set { _IdPlanAnual = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmRegPlanAnualEdit()
        {
            InitializeComponent();
        }

        private void frmRegPlanAnualEdit_Load(object sender, EventArgs e)
        {
           
            BSUtils.LoaderLook(cboTema, new TemaBL().ListaCombo(Parametros.intEmpresaId, Parametros.intTEMAPresencial, Parametros.intPeriodo), "DescTema", "IdTema", true);
            BSUtils.LoaderLook(cboTipo, new TipoCapacitacionBL().ListaCombo(Parametros.intEmpresaId), "DescTipoCapacitacion", "IdTipoCapacitacion", true);
            BSUtils.LoaderLook(cboClase, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblClaseCapacitacion), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblProgramaAnualCapacitacion), "DescTablaElemento", "IdTablaElemento", true);
            cboSituacion.EditValue = Parametros.intSCPendiente;

            txtPeriodo.EditValue = DateTime.Now.Year;
           
            BSUtils.LoaderLook(cboLugar, new LugarBL().ListaCombo(Parametros.intEmpresaId), "DescLugar", "IdLugar", true);
            BSUtils.LoaderLook(cboResponsableCapacitacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblResponsableCapacitacion), "DescTablaElemento", "IdTablaElemento", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "PlanAnual - Nuevo";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "PlanAnual - Modificar";

                PlanAnualBE objE_PlanAnual = null;
                objE_PlanAnual = new PlanAnualBL().Selecciona(IdPlanAnual);

                IdPlanAnual = objE_PlanAnual.IdPlanAnual;
                intIdEmpresa = objE_PlanAnual.IdEmpresa;
                intIdUnidadMinera = objE_PlanAnual.IdUnidadMinera;
                cboTema.EditValue = objE_PlanAnual.IdTema;
                cboTipo.EditValue = objE_PlanAnual.IdTipoCapacitacion;
                cboClase.EditValue = objE_PlanAnual.IdClaseCapacitacion;
                txtPeriodo.EditValue = objE_PlanAnual.Periodo;
                cboLugar.EditValue = objE_PlanAnual.IdLugar;
                cboResponsableCapacitacion.EditValue = objE_PlanAnual.IdResponsableCapacitacion;
                txtDuracion.EditValue = objE_PlanAnual.Duracion;
                txtCosto.EditValue = objE_PlanAnual.Costo;
            }

            cboTema.Select();

            CargaPlanAnualDetalle();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PlanAnualBE objPlanAnual = new PlanAnualBE();
                    PlanAnualBL objBL_PlanAnual = new PlanAnualBL();

                    objPlanAnual.IdPlanAnual = IdPlanAnual;
                    objPlanAnual.IdUnidadMinera = intIdUnidadMinera;
                    objPlanAnual.IdTema = Convert.ToInt32(cboTema.EditValue);
                    objPlanAnual.IdTipoCapacitacion = Convert.ToInt32(cboTipo.EditValue);
                    objPlanAnual.IdClaseCapacitacion = Convert.ToInt32(cboClase.EditValue);
                    objPlanAnual.Periodo = Convert.ToInt32(txtPeriodo.EditValue);
                    objPlanAnual.IdLugar = Convert.ToInt32(cboLugar.EditValue);
                    objPlanAnual.IdResponsableCapacitacion = Convert.ToInt32(cboResponsableCapacitacion.EditValue);
                    objPlanAnual.Duracion = Convert.ToInt32(txtDuracion.EditValue);
                    objPlanAnual.FechaCumplimiento = (DateTime?)null;
                    objPlanAnual.Costo = Convert.ToDecimal(txtCosto.EditValue);
                    objPlanAnual.IdSituacion = Convert.ToInt32(cboSituacion.EditValue);
                    objPlanAnual.FlagEstado = true;
                    objPlanAnual.Usuario = Parametros.strUsuarioLogin;
                    objPlanAnual.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPlanAnual.IdEmpresa = intIdEmpresa;

                    //Plan Anual Detalle
                    List<PlanAnualDetalleBE> lstPlanAnualDetalle = new List<PlanAnualDetalleBE>();

                    foreach (var item in mListaPlanAnualDetalleOrigen)
                    {
                       
                            PlanAnualDetalleBE objE_PlanAnualDetalle = new PlanAnualDetalleBE();
                            objE_PlanAnualDetalle.IdEmpresa = Parametros.intEmpresaId;
                            objE_PlanAnualDetalle.IdPlanAnual = IdPlanAnual;
                            objE_PlanAnualDetalle.IdPlanAnualDetalle = item.IdPlanAnualDetalle;
                            objE_PlanAnualDetalle.DescMes = item.DescMes;
                            objE_PlanAnualDetalle.Semana = item.Semana;
                            objE_PlanAnualDetalle.FlagEstado = true;
                            objE_PlanAnualDetalle.Usuario = Parametros.strUsuarioLogin;
                            objE_PlanAnualDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_PlanAnualDetalle.TipoOper = item.TipoOper;
                            lstPlanAnualDetalle.Add(objE_PlanAnualDetalle);
                       

                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_PlanAnual.Inserta(objPlanAnual, lstPlanAnualDetalle);
                        XtraMessageBox.Show("Se creó el registro del programa anual de capacitación ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        objBL_PlanAnual.Actualiza(objPlanAnual, lstPlanAnualDetalle);
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

        private void cboTema_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboTipo.Focus();
            }
        }

        private void cboTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboClase.Focus();
            }
        }

        private void cboClase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtPeriodo.Focus();
            }
        }

        private void txtPeriodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboLugar.Focus();
            }
        }

        

        private void cboLugar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboResponsableCapacitacion.Focus();
            }
        }

        private void cboResponsableCapacitacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtDuracion.Focus();
            }
        }

        private void deFechaCumplimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtCosto.Focus();
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnGrabar.Focus();
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               
                gvEppDetalle.AddNewRow();
                gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "IdPlanAnual", 0);
                gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "IdPlanAnualDetalle", 0);
                gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "DescMes", "");
                gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "Semana", 0);
                gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvEppDetalle.FocusedColumn = gvEppDetalle.Columns["DescMes"];
                gvEppDetalle.ShowEditor();

            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaPlanAnualDetalleOrigen.Count > 0)
                {
                    if (int.Parse(gvEppDetalle.GetFocusedRowCellValue("IdPlanAnualDetalle").ToString()) != 0)
                    {
                        int IdEppDetalle = 0;
                        if (gvEppDetalle.GetFocusedRowCellValue("IdPlanAnualDetalle") != null)
                            IdEppDetalle = int.Parse(gvEppDetalle.GetFocusedRowCellValue("IdPlanAnualDetalle").ToString());
                       
                        EppDetalleBE objBE_EppDetalle = new EppDetalleBE();
                        objBE_EppDetalle.IdEppDetalle = IdEppDetalle;
                        objBE_EppDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objBE_EppDetalle.Usuario = Parametros.strUsuarioLogin;
                        objBE_EppDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        EppDetalleBL objBL_EppDetalle = new EppDetalleBL();
                        objBL_EppDetalle.Elimina(objBE_EppDetalle);
                        gvEppDetalle.DeleteRow(gvEppDetalle.FocusedRowHandle);
                        gvEppDetalle.RefreshData();

                        
                    }
                    else
                    {
                        gvEppDetalle.DeleteRow(gvEppDetalle.FocusedRowHandle);
                        gvEppDetalle.RefreshData();
                    }
                }

                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtCodigo_Click(object sender, EventArgs e)
        {
            frmBuscaMes frm = new frmBuscaMes();
            frm.ShowDialog();
            if (frm.pMesBE != null)
            {
                int index = gvEppDetalle.FocusedRowHandle;

                gvEppDetalle.SetRowCellValue(index, "DescMes", frm.pMesBE.Descripcion);
                gvEppDetalle.SetRowCellValue(index, "Semana", 1);
            }
        }

        #endregion

        #region "Metodos"

        private void CargaPlanAnualDetalle()
        {
            mListaPlanAnualDetalleOrigen = new List<CPlanAnualDetalle>();
            List<PlanAnualDetalleBE> lstTmpPlanAnualDetalle = null;
            lstTmpPlanAnualDetalle = new PlanAnualDetalleBL().ListaTodosActivo(IdPlanAnual);

            foreach (PlanAnualDetalleBE item in lstTmpPlanAnualDetalle)
            {
                CPlanAnualDetalle objE_PlanAnualDetalle = new CPlanAnualDetalle();
                objE_PlanAnualDetalle.IdEmpresa = item.IdEmpresa;
                objE_PlanAnualDetalle.IdPlanAnual = item.IdPlanAnual;
                objE_PlanAnualDetalle.IdPlanAnualDetalle = item.IdPlanAnualDetalle;
                objE_PlanAnualDetalle.DescMes = item.DescMes;
                objE_PlanAnualDetalle.Semana = item.Semana;
                objE_PlanAnualDetalle.TipoOper = item.TipoOper;
                mListaPlanAnualDetalleOrigen.Add(objE_PlanAnualDetalle);
            }

            bsListado.DataSource = mListaPlanAnualDetalleOrigen;
            gcPlanAnualDetalle.DataSource = bsListado;
            gcPlanAnualDetalle.RefreshDataSource();


        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (cboTema.Text == "")
            {
                strMensaje = strMensaje + "- Debe seleccionar el tema del programa anual de capacitación.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        #endregion

        public class CPlanAnualDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdPlanAnual { get; set; }
            public Int32 IdPlanAnualDetalle { get; set; }
            public String DescMes { get; set; }
            public Int32 Semana { get; set; }
            public Int32 TipoOper { get; set; }

            public CPlanAnualDetalle()
            {

            }

        }

        
    }
}