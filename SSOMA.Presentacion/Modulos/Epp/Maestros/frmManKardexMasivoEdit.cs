using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SSOMA.Presentacion.Modulos.Otros;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Utils;

namespace SSOMA.Presentacion.Modulos.Epp.Maestros
{
    public partial class frmManKardexMasivoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CEquipo> mListaEquipoOrigen = new List<CEquipo>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public KardexBE pKardexBE { get; set; }

        public int IdKardex { get; set; }
        public int IdEmpresa { get; set; }
        public int IdUnidadMinera { get; set; }
        public String DescOrdenInterna { get; set; }

        int IdEquipo = 0;

        #endregion

        #region "Eventos"

        public frmManKardexMasivoEdit()
        {
            InitializeComponent();
        }

        private void frmManKardexMasivoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = IdEmpresa;

            deFecha.DateTime = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Kardex - Nuevo";
                txtOrdenInterna.Text = DescOrdenInterna;
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Kardex - Modificar";
                KardexBE objE_Kardex = null;
                objE_Kardex = new KardexBL().Selecciona(IdKardex);
                if (objE_Kardex != null)
                {
                    cboEmpresa.EditValue = objE_Kardex.IdEmpresa;
                    cboUnidadMinera.EditValue = objE_Kardex.IdUnidadMinera;
                    deFecha.EditValue = objE_Kardex.FechaMovimiento;
                    txtNumeroDocumento.Text = objE_Kardex.NumeroDocumento;
                    IdEquipo = objE_Kardex.IdEquipo;
                    txtObservacion.Text = objE_Kardex.Observacion;
                }

            }

            CargaEquipo();

            deFecha.Select();
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
                cboUnidadMinera.EditValue = IdUnidadMinera;
            }
        }

        

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                gvEquipo.AddNewRow();
                gvEquipo.SetRowCellValue(gvEquipo.FocusedRowHandle, "IdEquipo", 0);
                gvEquipo.SetRowCellValue(gvEquipo.FocusedRowHandle, "Codigo", "");
                gvEquipo.SetRowCellValue(gvEquipo.FocusedRowHandle, "DescEquipo", "");
                gvEquipo.SetRowCellValue(gvEquipo.FocusedRowHandle, "Cantidad", 0);

                gvEquipo.FocusedColumn = gvEquipo.Columns["Codigo"];
                gvEquipo.ShowEditor();

            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                gvEquipo.DeleteRow(gvEquipo.FocusedRowHandle);
                gvEquipo.RefreshData();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void gcTxtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBuscaEquipo objBusEquipoPreVenta = new frmBuscaEquipo();
                    objBusEquipoPreVenta.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objBusEquipoPreVenta.pFlagMultiSelect = false;
                    objBusEquipoPreVenta.ShowDialog();
                    if (objBusEquipoPreVenta.pEquipoBE != null)
                    {
                        int index = gvEquipo.FocusedRowHandle;

                        gvEquipo.SetRowCellValue(index, "IdEquipo", objBusEquipoPreVenta.pEquipoBE.IdEquipo);
                        gvEquipo.SetRowCellValue(index, "Codigo", objBusEquipoPreVenta.pEquipoBE.Codigo);
                        gvEquipo.SetRowCellValue(index, "DescEquipo", objBusEquipoPreVenta.pEquipoBE.DescEquipo);
                        gvEquipo.SetRowCellValue(index, "Cantidad", 1);
                    }
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
                    foreach (CEquipo item in mListaEquipoOrigen)
                    {
                        KardexBL objBL_Kardex = new KardexBL();
                        KardexBE objKardex = new KardexBE();
                        objKardex.IdKardex = IdKardex;
                        objKardex.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                        objKardex.IdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
                        objKardex.DescOrdenInterna = txtOrdenInterna.Text;
                        objKardex.IdEquipo = item.IdEquipo;
                        objKardex.Periodo = deFecha.DateTime.Year;
                        objKardex.FechaMovimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objKardex.Cantidad = item.Cantidad;
                        objKardex.NumeroDocumento = txtNumeroDocumento.Text;
                        objKardex.TipoMovimiento = "I";
                        objKardex.Observacion = txtObservacion.Text;
                        objKardex.FlagEstado = true;
                        objKardex.Usuario = Parametros.strUsuarioLogin;
                        objKardex.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        if (pOperacion == Operacion.Nuevo)
                            objBL_Kardex.Inserta(objKardex);
                        else
                            objBL_Kardex.Actualiza(objKardex);

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

        private void CargaEquipo()
        {
            List<EquipoBE> lstTmpEquipo = null;
            lstTmpEquipo = new EquipoBL().ListaTodosActivo(-1);

            foreach (EquipoBE item in lstTmpEquipo)
            {
                CEquipo objE_Equipo = new CEquipo();
                objE_Equipo.IdEquipo = item.IdEquipo;
                objE_Equipo.Codigo = item.Codigo;
                objE_Equipo.DescEquipo = item.DescEquipo;
                objE_Equipo.Cantidad = 0;

                mListaEquipoOrigen.Add(objE_Equipo);
            }

            bsListado.DataSource = mListaEquipoOrigen;
            gcEquipo.DataSource = bsListado;
            gcEquipo.RefreshDataSource();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtNumeroDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el número de documento.\n";
                flag = true;
            }

            if (txtNumeroDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el número de documento.\n";
                flag = true;
            }

            if (gvEquipo.RowCount== 0)
            {
                strMensaje = strMensaje + "- Seleccione el EPP's.\n";
                flag = true;
            }

            if (txtObservacion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la observación.\n";
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

        public class CEquipo
        {
            public Int32 IdEquipo { get; set; }
            public String Codigo { get; set; }
            public String DescEquipo { get; set; }
            public Decimal Cantidad { get; set; }
            

            public CEquipo()
            {

            }
        }


    }
}