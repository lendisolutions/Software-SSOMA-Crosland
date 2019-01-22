using System;
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
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion.Modulos.Otros;

namespace SSOMA.Presentacion.Modulos.Extintor.Registros
{
    public partial class frmRegExtintorEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ExtintorBE> lstExtintor;
        public List<CExtintorDetalle> mListaExtintorDetalleOrigen = new List<CExtintorDetalle>();
       

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdExtintor = 0;

        public int IdExtintor
        {
            get { return _IdExtintor; }
            set { _IdExtintor = value; }
        }

        #endregion

        #region "Eventos"

        public frmRegExtintorEdit()
        {
            InitializeComponent();
        }

        private void frmRegExtintorEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0, Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboClasificacion, new ClasificacionExtintorBL().ListaCombo(Parametros.intEmpresaId), "Abreviatura", "IdClasificacionExtintor", true);
            BSUtils.LoaderLook(cboTipo, new TipoExtintorBL().ListaCombo(Parametros.intEmpresaId), "Abreviatura", "IdTipoExtintor", true);
            BSUtils.LoaderLook(cboProveedor, new ProveedorBL().ListaCombo(Parametros.intEmpresaId), "RazonSocial", "IdProveedor", true);
            deFechaIngreso.DateTime = DateTime.Now;
            deFechaVencimiento.DateTime = DateTime.Now;
            deFechaVencimientoPruebaHidrostatica.DateTime = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Extintor - Nuevo";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Extintor - Modificar";

                ExtintorBE objE_Extintor = null;
                objE_Extintor = new ExtintorBL().Selecciona(IdExtintor);

                IdExtintor = objE_Extintor.IdExtintor;
                cboEmpresa.EditValue = objE_Extintor.IdEmpresa;
                cboUnidadMinera.EditValue = objE_Extintor.IdUnidadMinera;
                txtCodigo.Text = objE_Extintor.Codigo;
                txtSerie.Text = objE_Extintor.Serie;
                cboClasificacion.EditValue = objE_Extintor.IdClasificacionExtintor;
                cboTipo.EditValue = objE_Extintor.IdTipoExtintor;
                cboProveedor.EditValue = objE_Extintor.IdProveedor;
                txtMarca.Text = objE_Extintor.Marca;
                txtCapacidad.Text = objE_Extintor.Capacidad;
                deFechaIngreso.EditValue = objE_Extintor.FechaIngreso;
                deFechaVencimiento.EditValue = objE_Extintor.FechaVencimiento;
                deFechaVencimientoPruebaHidrostatica.EditValue = objE_Extintor.FechaVencimientoPruebaHidrostatica;
                txtUbicacion.Text = objE_Extintor.Ubicacion;
                txtObservacion.Text = objE_Extintor.Observacion;
            }

            CargaExtintorDetalle();
            txtCodigo.Select();
            
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
            }
        }

        private void gcTxtServicio_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBuscaServicioExtintor objBusca = new frmBuscaServicioExtintor();
                    objBusca.ShowDialog();
                    if (objBusca._Be != null)
                    {
                        int index = gvExtintorDetalle.FocusedRowHandle;
                        gvExtintorDetalle.SetRowCellValue(index, "IdServicioExtintor", objBusca._Be.IdServicioExtintor);
                        gvExtintorDetalle.SetRowCellValue(index, "DescServicioExtintor", objBusca._Be.DescServicioExtintor);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                
                gvExtintorDetalle.AddNewRow();
                gvExtintorDetalle.SetRowCellValue(gvExtintorDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                gvExtintorDetalle.SetRowCellValue(gvExtintorDetalle.FocusedRowHandle, "IdExtintor", 0);
                gvExtintorDetalle.SetRowCellValue(gvExtintorDetalle.FocusedRowHandle, "IdExtintorDetalle", 0);
                gvExtintorDetalle.SetRowCellValue(gvExtintorDetalle.FocusedRowHandle, "Fecha", DateTime.Now);
                gvExtintorDetalle.SetRowCellValue(gvExtintorDetalle.FocusedRowHandle, "IdServcioExtintor", 0);
                gvExtintorDetalle.SetRowCellValue(gvExtintorDetalle.FocusedRowHandle, "DescServicioExtintor", "");
                gvExtintorDetalle.SetRowCellValue(gvExtintorDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvExtintorDetalle.FocusedColumn = gvExtintorDetalle.Columns["Fecha"];
                gvExtintorDetalle.ShowEditor();
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
                int IdExtintorDetalle = 0;
                if (gvExtintorDetalle.GetFocusedRowCellValue("IdExtintorDetalle") != null)
                    IdExtintorDetalle = int.Parse(gvExtintorDetalle.GetFocusedRowCellValue("IdExtintorDetalle").ToString());
                ExtintorDetalleBE objBE_ExtintorDetalle = new ExtintorDetalleBE();
                objBE_ExtintorDetalle.IdExtintorDetalle = IdExtintorDetalle;
                objBE_ExtintorDetalle.IdEmpresa = Parametros.intEmpresaId;
                objBE_ExtintorDetalle.Usuario = Parametros.strUsuarioLogin;
                objBE_ExtintorDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                ExtintorDetalleBL objBL_ExtintorDetalle = new ExtintorDetalleBL();
                objBL_ExtintorDetalle.Elimina(objBE_ExtintorDetalle);
                gvExtintorDetalle.DeleteRow(gvExtintorDetalle.FocusedRowHandle);
                gvExtintorDetalle.RefreshData();

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
                    ExtintorBE objExtintor = new ExtintorBE();
                    ExtintorBL objBL_Extintor = new ExtintorBL();

                    objExtintor.IdExtintor = IdExtintor;
                    objExtintor.IdUnidadMinera = Convert.ToInt32(cboUnidadMinera.EditValue);
                    objExtintor.Codigo = txtCodigo.Text;
                    objExtintor.Serie = txtSerie.Text;
                    objExtintor.IdClasificacionExtintor = Convert.ToInt32(cboClasificacion.EditValue);
                    objExtintor.IdTipoExtintor = Convert.ToInt32(cboTipo.EditValue);
                    objExtintor.IdProveedor = Convert.ToInt32(cboProveedor.EditValue);
                    objExtintor.Marca = txtMarca.Text;
                    objExtintor.Capacidad = txtCapacidad.Text;
                    objExtintor.FechaIngreso = Convert.ToDateTime(deFechaIngreso.DateTime.ToShortDateString());
                    objExtintor.FechaVencimiento = Convert.ToDateTime(deFechaVencimiento.DateTime.ToShortDateString());
                    objExtintor.FechaVencimientoPruebaHidrostatica = Convert.ToDateTime(deFechaVencimientoPruebaHidrostatica.DateTime.ToShortDateString());
                    objExtintor.Ubicacion = txtUbicacion.Text;
                    objExtintor.Observacion = txtObservacion.Text;
                    objExtintor.FlagEstado = true;
                    objExtintor.Usuario = Parametros.strUsuarioLogin;
                    objExtintor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objExtintor.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                    //EXTINTOR DETALLE
                    List<ExtintorDetalleBE> lstExtintorDetalle = new List<ExtintorDetalleBE>();

                    foreach (var item in mListaExtintorDetalleOrigen)
                    {
                        ExtintorDetalleBE objE_ExtintorDetalle = new ExtintorDetalleBE();
                        objE_ExtintorDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objE_ExtintorDetalle.IdExtintor = IdExtintor;
                        objE_ExtintorDetalle.IdExtintorDetalle = item.IdExtintorDetalle;
                        objE_ExtintorDetalle.Fecha = item.Fecha;
                        objE_ExtintorDetalle.IdServicioExtintor = item.IdServicioExtintor;
                        objE_ExtintorDetalle.DescServicioExtintor = item.DescServicioExtintor;
                        objE_ExtintorDetalle.FlagEstado = true;
                        objE_ExtintorDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_ExtintorDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ExtintorDetalle.TipoOper = item.TipoOper;
                        lstExtintorDetalle.Add(objE_ExtintorDetalle);
                    }

                    
                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_Extintor.Inserta(objExtintor, lstExtintorDetalle);
                        XtraMessageBox.Show("Se creó el registro del Extintor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        objBL_Extintor.Actualiza(objExtintor, lstExtintorDetalle);
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

        private void CargaExtintorDetalle()
        {
            List<ExtintorDetalleBE> lstTmpExtintorDetalle = null;
            lstTmpExtintorDetalle = new ExtintorDetalleBL().ListaTodosActivo(IdExtintor);

            foreach (ExtintorDetalleBE item in lstTmpExtintorDetalle)
            {
                CExtintorDetalle objE_ExtintorDetalle = new CExtintorDetalle();
                objE_ExtintorDetalle.IdEmpresa = item.IdEmpresa;
                objE_ExtintorDetalle.IdExtintor = item.IdExtintor;
                objE_ExtintorDetalle.IdExtintorDetalle = item.IdExtintorDetalle;
                objE_ExtintorDetalle.Fecha = item.Fecha;
                objE_ExtintorDetalle.IdServicioExtintor = item.IdServicioExtintor;
                objE_ExtintorDetalle.DescServicioExtintor = item.DescServicioExtintor;
                objE_ExtintorDetalle.TipoOper = item.TipoOper;
                mListaExtintorDetalleOrigen.Add(objE_ExtintorDetalle);
            }

            bsListado.DataSource = mListaExtintorDetalleOrigen;
            gcExtintorDetalle.DataSource = bsListado;
            gcExtintorDetalle.RefreshDataSource();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtCodigo.Text == "")
            {
                strMensaje = strMensaje + "- Debe ingresar código del extintor.\n";
                flag = true;
            }

            if (txtMarca.Text == "")
            {
                strMensaje = strMensaje + "- Debe ingresar la marca del extintor.\n";
                flag = true;
            }

            if (txtCapacidad.Text == "")
            {
                strMensaje = strMensaje + "- Debe ingresar la capacidad del extintor.\n";
                flag = true;
            }

            
            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstExtintor.Where(oB => oB.IdEmpresa == Convert.ToInt32(cboEmpresa.EditValue) && oB.IdUnidadMinera == Convert.ToInt32(cboUnidadMinera.EditValue) && oB.Codigo.ToUpper() == txtCodigo.Text.ToUpper() ).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Código ya existe.\n";
                    flag = true;
                }
            }

            if (gvExtintorDetalle.DataRowCount > 0)
            {
                for (int i = 0; i < gvExtintorDetalle.DataRowCount; i++)
                {

                    if (gvExtintorDetalle.GetRowCellValue(i, "IdServicioExtintor").ToString() == "")
                    {
                        strMensaje = strMensaje + "- Debe seleccionar un servicio.\n";
                        flag = true;
                    }
                }
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }
        #endregion

        public class CExtintorDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdExtintor { get; set; }
            public Int32 IdExtintorDetalle { get; set; }
            public DateTime Fecha { get; set; }
            public Int32 IdServicioExtintor { get; set; }
            public string DescServicioExtintor { get; set; }
            public Int32 TipoOper { get; set; }

            public CExtintorDetalle()
            {

            }
        }

        
    }
}