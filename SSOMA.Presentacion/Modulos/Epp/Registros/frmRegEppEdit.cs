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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion.Modulos.Epp.Rpt;
using SSOMA.BusinessLogic;
using SSOMA.BusinessEntity;
using SSOMA.Presentacion.Modulos.Otros;

namespace SSOMA.Presentacion.Modulos.Epp.Registros
{
    public partial class frmRegEppEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CEppDetalle> mListaEppDetalleOrigen = new List<CEppDetalle>();

        int _IdEpp = 0;

        public int IdEpp
        {
            get { return _IdEpp; }
            set { _IdEpp = value; }
        }

        private int intIdEmpresa = 0;
        private int intIdUnidadMinera = 0;
        private int intIdArea = 0;

        private int intIdSolicitudEpp = 0;

        private int intIdPersona = 0;
        private int intIdEmpresaResponsable = 0;
        private int intIdUnidadMineraResponsable = 0;
        private int intIdAreaResponsable = 0;
        private int intIdSectorResponsable = 0;
        private string strEmail = "";

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;
        public bool bNuevo = true;

        private GridColumn gcColumnCantidad;
        private GridColumn gcColumnTotal;
        
        #endregion

        #region "Eventos"

        public frmRegEppEdit()
        {
            InitializeComponent();
            gcFechaVencimiento.Caption = "Fecha\nVencimiento";
            gcTipoEntrega.Caption = "Tipo\nEntrega";
        }

        private void frmRegEppEdit_Load(object sender, EventArgs e)
        {
            gvEppDetalle.OptionsView.ShowFooter = true;
            gvEppDetalle.Layout += new EventHandler(gvEppDetalle_Layout);

            deFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboOrdenInterna, new OrdenInternaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intUnidadMineraId), "DescOrdenInterna", "IdOrdenInterna", true);


            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Registro de Epp - Nuevo ";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Registro de Epp - Modificar ";
                EppBE objE_Epp = null;
                objE_Epp = new EppBL().Selecciona(IdEpp);
                if (objE_Epp != null)
                {
                    IdEpp = objE_Epp.IdEpp;
                    intIdEmpresa = objE_Epp.IdEmpresa;
                    intIdUnidadMinera = objE_Epp.IdUnidadMinera;
                    intIdArea = objE_Epp.IdArea;
                    intIdSolicitudEpp = objE_Epp.IdSolicitudEpp;
                    txtNumeroSolicitud.Text = objE_Epp.NumeroSolicitud;
                    txtNumero.Text = objE_Epp.Numero;
                    intIdPersona = objE_Epp.IdPersona;
                    txtResponsable.Text = objE_Epp.Responsable;
                    txtCargo.Text = objE_Epp.Cargo;
                    intIdEmpresaResponsable = objE_Epp.IdEmpresaResponsable;
                    txtEmpresaResponsable.Text = objE_Epp.EmpresaResponsable;
                    intIdUnidadMineraResponsable = objE_Epp.IdUnidadMineraResponsable;
                    txtUnidadMineraResponsable.Text = objE_Epp.UnidadMineraResponsable;
                    intIdAreaResponsable = objE_Epp.IdAreaResponsable;
                    txtAreaResponsable.Text = objE_Epp.AreaResponsable;
                    intIdSectorResponsable = objE_Epp.IdSectorResponsable;
                    txtSectorResponsable.Text = objE_Epp.SectorResponsable;
                    txtDescNegocio.Text = objE_Epp.DescNegocio;
                    deFecha.EditValue = objE_Epp.Fecha;
                    cboOrdenInterna.Text = objE_Epp.DescOrdenInterna;
                    txtObservacion.Text = objE_Epp.Observacion;
                }
            }

            CargaEppDetalle();
            AttachSummaryEPP();

            txtNumeroSolicitud.Select();
        }

        private void txtNumeroSolicitud_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SolicitudEppBE objE_SolicitudEpp = null;
                    objE_SolicitudEpp = new SolicitudEppBL().SeleccionaNumero(Convert.ToInt32(txtNumeroSolicitud.EditValue));
                    if (objE_SolicitudEpp != null)
                    {
                        if (objE_SolicitudEpp.IdSituacion == Parametros.intSLCPendiente)
                        {
                            intIdSolicitudEpp = objE_SolicitudEpp.IdSolicitudEpp;
                            txtNumeroSolicitud.Text = objE_SolicitudEpp.Numero;
                            intIdPersona = objE_SolicitudEpp.IdPersona;
                            txtResponsable.Text = objE_SolicitudEpp.Responsable;
                            intIdEmpresaResponsable = objE_SolicitudEpp.IdEmpresaResponsable;
                            txtEmpresaResponsable.Text = objE_SolicitudEpp.EmpresaResponsable;
                            intIdUnidadMineraResponsable = objE_SolicitudEpp.IdUnidadMineraResponsable;
                            txtUnidadMineraResponsable.Text = objE_SolicitudEpp.UnidadMineraResponsable;
                            intIdAreaResponsable = objE_SolicitudEpp.IdAreaResponsable;
                            txtAreaResponsable.Text = objE_SolicitudEpp.AreaResponsable;
                            intIdSectorResponsable = objE_SolicitudEpp.IdSectorResponsable;
                            txtSectorResponsable.Text = objE_SolicitudEpp.SectorResponsable;
                            txtCargo.Text = objE_SolicitudEpp.Cargo;
                            txtDescNegocio.Text = objE_SolicitudEpp.DescNegocio;

                            PersonaBE objE_Persona = null;
                            objE_Persona = new PersonaBL().Selecciona(0, 0, 0, objE_SolicitudEpp.IdJefe);

                            if (objE_Persona != null)
                            {
                                strEmail = objE_Persona.Email;
                            }

                            //LLENAMOS EL DETALLE

                            List<SolicitudEppDetalleBE> lstSolicitudDetalle = null;
                            lstSolicitudDetalle = new SolicitudEppDetalleBL().ListaTodosActivo(intIdSolicitudEpp);

                            mListaEppDetalleOrigen = new List<CEppDetalle>();


                            foreach (SolicitudEppDetalleBE item in lstSolicitudDetalle)
                            {
                                CEppDetalle objE_EppDetalle = new CEppDetalle();
                                objE_EppDetalle.IdEmpresa = intIdEmpresa;
                                objE_EppDetalle.IdEpp = 0;
                                objE_EppDetalle.IdEppDetalle = 0;
                                objE_EppDetalle.Item = item.Item;
                                objE_EppDetalle.IdEquipo = item.IdEquipo;
                                objE_EppDetalle.Codigo = item.Codigo;
                                objE_EppDetalle.DescEquipo = item.DescEquipo;

                                //Obtenemos la fecha de vencimiento
                                AreaEquipoBE objE_AreaEquipo = null;
                                objE_AreaEquipo = new AreaEquipoBL().SeleccionaEquipo(intIdEmpresaResponsable, intIdUnidadMineraResponsable, intIdAreaResponsable, 0);
                                if (objE_AreaEquipo == null)
                                {
                                    string strMensaje = "El Equipo de Protecciòn Personal, no esta asigando:\n";
                                    strMensaje = strMensaje + "Empresa : " + objE_SolicitudEpp.EmpresaResponsable + "\n";
                                    strMensaje = strMensaje + "Sede : " + objE_SolicitudEpp.UnidadMineraResponsable + "\n";
                                    strMensaje = strMensaje + "Area : " + objE_SolicitudEpp.AreaResponsable + "\n";
                                    strMensaje = strMensaje + "EPP : " + item.DescEquipo + "\n";

                                    XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                else
                                {
                                    objE_EppDetalle.FechaVencimiento = deFecha.DateTime.AddDays(objE_AreaEquipo.Dias);
                                }

                                
                                objE_EppDetalle.Cantidad = item.Cantidad;

                                EquipoBE objE_Equipo = null;
                                objE_Equipo = new EquipoBL().Selecciona(Parametros.intEmpresaId, item.IdEquipo);
                                if (objE_Equipo != null)
                                {
                                    objE_EppDetalle.Precio = objE_Equipo.Precio;
                                    objE_EppDetalle.Total = item.Cantidad * objE_Equipo.Precio;
                                }

                                
                                objE_EppDetalle.IdTipoEntrega = Parametros.intTENuevo;
                                objE_EppDetalle.DescTipoEntrega = "NUEVO";
                                objE_EppDetalle.IdKardex = 0;
                                objE_EppDetalle.TipoOper = 4;
                                mListaEppDetalleOrigen.Add(objE_EppDetalle);
                            }

                            bsListado.DataSource = mListaEppDetalleOrigen;
                            gcEppDetalle.DataSource = bsListado;
                            gcEppDetalle.RefreshDataSource();
                        }
                        else
                        {
                            XtraMessageBox.Show("La Solicitud ya fue atendida o anulada. \nPor Favor Verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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
                    txtResponsable.Text = frm.pPersonaBE.ApeNom;
                    intIdEmpresaResponsable = frm.pPersonaBE.IdEmpresa;
                    txtEmpresaResponsable.Text = frm.pPersonaBE.RazonSocial;
                    intIdUnidadMineraResponsable = frm.pPersonaBE.IdUnidadMinera;
                    txtUnidadMineraResponsable.Text = frm.pPersonaBE.DescUnidadMinera;
                    intIdAreaResponsable = frm.pPersonaBE.IdArea;
                    txtAreaResponsable.Text = frm.pPersonaBE.DescArea;
                    txtCargo.Text = frm.pPersonaBE.Cargo;
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
                if (intIdSolicitudEpp == 0)
                {
                    XtraMessageBox.Show("Debe Seleccionar una Solicitud.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (intIdPersona == 0)
                {
                    XtraMessageBox.Show("Debe Seleccionar un Responsable.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmRegEppDetalleEdit movDetalle = new frmRegEppDetalleEdit();
                int i = 0;
                if (mListaEppDetalleOrigen.Count > 0)
                    i = mListaEppDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
                movDetalle.intCorrelativo = Convert.ToInt32(i) + 1;
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaEppDetalleOrigen.Count == 0)
                        {
                            gvEppDetalle.AddNewRow();
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "IdEmpresa", intIdEmpresa);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "IdEpp", movDetalle.oBE.IdEpp);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "IdEppDetalle", movDetalle.oBE.IdEppDetalle);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "IdEquipo", movDetalle.oBE.IdEquipo);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "Codigo", movDetalle.oBE.Codigo);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "DescEquipo", movDetalle.oBE.DescEquipo);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "FechaVencimiento", movDetalle.oBE.FechaVencimiento);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "Total", movDetalle.oBE.Total);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "IdTipoEntrega", movDetalle.oBE.IdTipoEntrega);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "DescTipoEntrega", movDetalle.oBE.DescTipoEntrega);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "IdKardex", 0);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvEppDetalle.UpdateCurrentRow();

                            bNuevo = movDetalle.bNuevo;

                            AttachSummaryEPP();

                            btnNuevo.Focus();

                            return;

                        }

                        if (mListaEppDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaEppDetalleOrigen.Where(oB => oB.IdEquipo == movDetalle.oBE.IdEquipo).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvEppDetalle.AddNewRow();
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "IdEmpresa", intIdEmpresa);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "IdEpp", movDetalle.oBE.IdEpp);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "IdEppDetalle", movDetalle.oBE.IdEppDetalle);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "IdEquipo", movDetalle.oBE.IdEquipo);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "Codigo", movDetalle.oBE.Codigo);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "DescEquipo", movDetalle.oBE.DescEquipo);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "FechaVencimiento", movDetalle.oBE.FechaVencimiento);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "Total", movDetalle.oBE.Total);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "IdTipoEntrega", movDetalle.oBE.IdTipoEntrega);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "DescTipoEntrega", movDetalle.oBE.DescTipoEntrega);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "IdKardex", 0);
                            gvEppDetalle.SetRowCellValue(gvEppDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvEppDetalle.UpdateCurrentRow();

                            bNuevo = movDetalle.bNuevo;

                            AttachSummaryEPP();

                            btnNuevo.Focus();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarprecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mListaEppDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmRegEppDetalleEdit movDetalle = new frmRegEppDetalleEdit();

                movDetalle.IdEpp = Convert.ToInt32(gvEppDetalle.GetFocusedRowCellValue("IdEpp"));
                movDetalle.IdEppDetalle = Convert.ToInt32(gvEppDetalle.GetFocusedRowCellValue("IdEppDetalle"));
                movDetalle.intCorrelativo = Convert.ToInt32(gvEppDetalle.GetFocusedRowCellValue("Item"));
                movDetalle.IdEquipo = Convert.ToInt32(gvEppDetalle.GetFocusedRowCellValue("IdEquipo"));
                movDetalle.txtCodigo.Text = gvEppDetalle.GetFocusedRowCellValue("Codigo").ToString();
                movDetalle.txtDescEquipo.Text = gvEppDetalle.GetFocusedRowCellValue("DescEquipo").ToString();
                movDetalle.deFechaVencimiento.EditValue = gvEppDetalle.GetFocusedRowCellValue("FechaVencimiento").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvEppDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecio.EditValue = Convert.ToDecimal(gvEppDetalle.GetFocusedRowCellValue("Precio"));
                movDetalle.txtTotal.EditValue = Convert.ToDecimal(gvEppDetalle.GetFocusedRowCellValue("Total"));
                movDetalle.cboTipoEntrega.EditValue = Convert.ToInt32(gvEppDetalle.GetFocusedRowCellValue("IdTipoEntrega"));

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvEppDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvEppDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvEppDetalle.SetRowCellValue(xposition, "IdEpp", movDetalle.oBE.IdEpp);
                        gvEppDetalle.SetRowCellValue(xposition, "IdEppDetalle", movDetalle.oBE.IdEppDetalle);
                        gvEppDetalle.SetRowCellValue(xposition, "Item", movDetalle.oBE.Item);
                        gvEppDetalle.SetRowCellValue(xposition, "IdEquipo", movDetalle.oBE.IdEquipo);
                        gvEppDetalle.SetRowCellValue(xposition, "Codigo", movDetalle.oBE.Codigo);
                        gvEppDetalle.SetRowCellValue(xposition, "DescEquipo", movDetalle.oBE.DescEquipo);
                        gvEppDetalle.SetRowCellValue(xposition, "FechaVencimiento", movDetalle.oBE.FechaVencimiento);
                        gvEppDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        gvEppDetalle.SetRowCellValue(xposition, "Precio", movDetalle.oBE.Precio);
                        gvEppDetalle.SetRowCellValue(xposition, "Total", movDetalle.oBE.Total);
                        gvEppDetalle.SetRowCellValue(xposition, "IdTipoEntrega", movDetalle.oBE.IdTipoEntrega);
                        gvEppDetalle.SetRowCellValue(xposition, "DescTipoEntrega", movDetalle.oBE.DescTipoEntrega);

                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvEppDetalle.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvEppDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvEppDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvEppDetalle.UpdateCurrentRow();

                        bNuevo = movDetalle.bNuevo;

                        AttachSummaryEPP();

                        btnNuevo.Focus();
                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaEppDetalleOrigen.Count > 0)
                {
                    if (int.Parse(gvEppDetalle.GetFocusedRowCellValue("IdEquipo").ToString()) != 0)
                    {
                        int IdEppDetalle = 0;
                        if (gvEppDetalle.GetFocusedRowCellValue("IdEppDetalle") != null)
                            IdEppDetalle = int.Parse(gvEppDetalle.GetFocusedRowCellValue("IdEppDetalle").ToString());
                        int Item = 0;
                        if (gvEppDetalle.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvEppDetalle.GetFocusedRowCellValue("Item").ToString());
                        EppDetalleBE objBE_EppDetalle = new EppDetalleBE();
                        objBE_EppDetalle.IdEppDetalle = IdEppDetalle;
                        objBE_EppDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objBE_EppDetalle.Usuario = Parametros.strUsuarioLogin;
                        objBE_EppDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        EppDetalleBL objBL_EppDetalle = new EppDetalleBL();
                        objBL_EppDetalle.Elimina(objBE_EppDetalle);
                        gvEppDetalle.DeleteRow(gvEppDetalle.FocusedRowHandle);
                        gvEppDetalle.RefreshData();

                        //RegeneraItem
                        int i = 0;
                        int cuenta = 0;
                        foreach (var item in mListaEppDetalleOrigen)
                        {
                            item.Item = Convert.ToInt32(cuenta + 1);
                            cuenta++;
                            i++;
                        }
                    }
                    else
                    {
                        gvEppDetalle.DeleteRow(gvEppDetalle.FocusedRowHandle);
                        gvEppDetalle.RefreshData();
                    }
                }

                AttachSummaryEPP();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.nuevoToolStripMenuItem_Click(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.modificarprecioToolStripMenuItem_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarToolStripMenuItem_Click(sender, e);
        }

        private void gvEppDetalle_Layout(object sender, EventArgs e)
        {
            AttachSummaryEPP();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    EppBE objEpp = new EppBE();
                    EppBL objBL_Epp = new EppBL();

                    StringBuilder strMensaje = new StringBuilder();

                    objEpp.IdEpp = IdEpp;
                    objEpp.IdEmpresa = Parametros.intEmpresaId;
                    objEpp.IdUnidadMinera = Parametros.intUnidadMineraId;
                    objEpp.Numero = txtNumero.Text;
                    objEpp.IdSolicitudEpp = intIdSolicitudEpp;
                    objEpp.IdPersona = intIdPersona;
                    objEpp.IdEmpresaResponsable = intIdEmpresaResponsable;
                    objEpp.IdUnidadMineraResponsable = intIdUnidadMineraResponsable;
                    objEpp.IdAreaResponsable = intIdAreaResponsable;
                    objEpp.IdSectorResponsable = intIdSectorResponsable;
                    objEpp.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objEpp.DescOrdenInterna = cboOrdenInterna.Text;
                    objEpp.Observacion = txtObservacion.Text;
                    objEpp.FlagEstado = true;
                    objEpp.Usuario = Parametros.strUsuarioLogin;
                    objEpp.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    
                   
                    //Epp FOTO
                    List<EppDetalleBE> lstEppDetalle = new List<EppDetalleBE>();

                    foreach (var item in mListaEppDetalleOrigen)
                    {
                        EppDetalleBE objE_EppDetalle = new EppDetalleBE();
                        objE_EppDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objE_EppDetalle.IdEpp = IdEpp;
                        objE_EppDetalle.IdEppDetalle = item.IdEppDetalle;
                        objE_EppDetalle.Item = item.Item;
                        objE_EppDetalle.IdEquipo = item.IdEquipo;
                        objE_EppDetalle.Codigo = item.Codigo;
                        objE_EppDetalle.DescEquipo = item.DescEquipo;
                        objE_EppDetalle.FechaVencimiento = item.FechaVencimiento;
                        objE_EppDetalle.Cantidad = item.Cantidad;
                        objE_EppDetalle.Precio = item.Precio;
                        objE_EppDetalle.Total = item.Total;
                        objE_EppDetalle.IdTipoEntrega = item.IdTipoEntrega;
                        objE_EppDetalle.IdKardex = item.IdKardex;
                        objE_EppDetalle.FlagEstado = true;
                        objE_EppDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_EppDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_EppDetalle.TipoOper = item.TipoOper;
                        lstEppDetalle.Add(objE_EppDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        int intNumero = 0;
                        string strNumero = "";
                        intNumero = objBL_Epp.Inserta(objEpp, lstEppDetalle);
                        strNumero = FuncionBase.AgregarCaracter(intNumero.ToString(), "0", 7);
                        txtNumero.Text = strNumero;

                        //ACTUALIZA NUMERO
                        EppBL objBEpp = new EppBL();
                        objBEpp.ActualizaNumero(intNumero, txtNumero.Text);

                       

                        decimal decTotal = 0;

                        strMensaje.Append("**************************** REGISTRO DE ENTREGA DE EPP ***************************************\n\n");
                        strMensaje.Append("Se Generó el N° REGISTRO DE ENTREGA DE EPP : " + txtNumero.Text + "\n\n");
                        strMensaje.Append("Responsable : " + txtResponsable.Text + "\n\n");
                        foreach (var item in mListaEppDetalleOrigen)
                        {
                            strMensaje.Append("Código : " + item.Codigo.ToString() + "\n");
                            strMensaje.Append("EPP : " + item.DescEquipo.ToString() + "\n");
                            strMensaje.Append("Cantidad : " + item.Cantidad.ToString() + "\n\n");
                            decTotal = decTotal + item.Precio;
                        }

                        strMensaje.Append("Costo Total S/.: " + decTotal.ToString() + "\n\n");
                        strMensaje.Append("**********************************************************************************************\n\n");

                        
                        //GENERAR EL REPORTE EN PDF
                        List<ReporteEppBE> lstReporte = null;
                        lstReporte = new ReporteEppBL().Listado(intNumero);
                        rptEpp objReporte = new rptEpp();
                            
                        objReporte.SetDataSource(lstReporte);
                        objReporte.SetParameterValue("Coordinador", Parametros.strUsuarioNombres);
                        objReporte.SetParameterValue("EmpresaResponsable", "CROSLAND LOGISTICA S.A.C.");
                        objReporte.ExportToDisk(ExportFormatType.PortableDocFormat, @"D:\" + strNumero + ".pdf");
                        BSUtils.EmailSend(strEmail, "Registro de entrega de Epp", strMensaje.ToString(), @"D:\" + strNumero + ".pdf", "", "", "");
                       


                        XtraMessageBox.Show("Se creó el Registro de Epp N° : " + txtNumero.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        objBL_Epp.Actualiza(objEpp, lstEppDetalle);
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

            if (intIdSolicitudEpp == 0)
            {
                strMensaje = strMensaje + "- Debe Seleccionar una solicitud.\n";
                flag = true;
            }

            if (intIdPersona == 0)
            {
                strMensaje = strMensaje + "- Debe Seleccionar el Responsable.\n";
                flag = true;
            }

            if (gvEppDetalle.DataRowCount == 0)
            {
                strMensaje = strMensaje + "- Debe Seleccionar un Epp.\n";
                flag = true;
                   
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CargaEppDetalle()
        {
            mListaEppDetalleOrigen = new List<CEppDetalle>();
            List<EppDetalleBE> lstTmpEppDetalle = null;
            lstTmpEppDetalle = new EppDetalleBL().ListaTodosActivo(IdEpp);

            foreach (EppDetalleBE item in lstTmpEppDetalle)
            {
                CEppDetalle objE_EppDetalle = new CEppDetalle();
                objE_EppDetalle.IdEmpresa = item.IdEmpresa;
                objE_EppDetalle.IdEpp = item.IdEpp;
                objE_EppDetalle.IdEppDetalle = item.IdEppDetalle;
                objE_EppDetalle.Item = item.Item;
                objE_EppDetalle.IdEquipo = item.IdEquipo;
                objE_EppDetalle.Codigo = item.Codigo;
                objE_EppDetalle.DescEquipo = item.DescEquipo;
                objE_EppDetalle.FechaVencimiento = item.FechaVencimiento;
                objE_EppDetalle.Cantidad = item.Cantidad;
                objE_EppDetalle.Precio = item.Precio;
                objE_EppDetalle.Total = item.Total;
                objE_EppDetalle.IdTipoEntrega = item.IdTipoEntrega;
                objE_EppDetalle.DescTipoEntrega = item.DescTipoEntrega;
                objE_EppDetalle.IdKardex = item.IdKardex;
                objE_EppDetalle.TipoOper = item.TipoOper;
                mListaEppDetalleOrigen.Add(objE_EppDetalle);
            }

            bsListado.DataSource = mListaEppDetalleOrigen;
            gcEppDetalle.DataSource = bsListado;
            gcEppDetalle.RefreshDataSource();

           
        }

        private void AttachSummaryEPP()
        {
            GridColumn firstColumn = gvEppDetalle.VisibleColumns.Count == 0 ? null : gvEppDetalle.VisibleColumns[4];
            if (gcColumnCantidad == firstColumn) return;
            if (gcColumnCantidad != null)
            {
                gcColumnCantidad.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;
            }

            gcColumnCantidad = firstColumn;

            if (gcColumnCantidad != null)
            {
                gcColumnCantidad.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gcColumnCantidad.SummaryItem.DisplayFormat = "SUM={0:#,0.00}";
            }

            GridColumn SecondColumn = gvEppDetalle.VisibleColumns.Count == 0 ? null : gvEppDetalle.VisibleColumns[6];
            if (gcColumnTotal == SecondColumn) return;
            if (gcColumnTotal != null)
            {
                gcColumnTotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;
            }

            gcColumnTotal = SecondColumn;

            if (gcColumnTotal != null)
            {
                gcColumnTotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gcColumnTotal.SummaryItem.DisplayFormat = "SUM={0:#,0.00}";
            }
        }

        #endregion

        public class CEppDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdEpp { get; set; }
            public Int32 IdEppDetalle { get; set; }
            public Int32 Item { get; set; }
            public Int32 IdEquipo { get; set; }
            public String Codigo { get; set; }
            public String DescEquipo { get; set; }
            public DateTime FechaVencimiento { get; set; }
            public Int32 Cantidad { get; set; }
            public Decimal Precio { get; set; }
            public Decimal Total { get; set; }
            public Int32 IdTipoEntrega { get; set; }
            public String DescTipoEntrega { get; set; }
            public Int32 IdKardex { get; set; }
            public Int32 TipoOper { get; set; }
            
            public CEppDetalle()
            {

            }
        
        }

       




    }
}