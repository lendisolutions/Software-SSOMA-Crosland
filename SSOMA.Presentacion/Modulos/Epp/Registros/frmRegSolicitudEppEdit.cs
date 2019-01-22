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

namespace SSOMA.Presentacion.Modulos.Epp.Registros
{
    public partial class frmRegSolicitudEppEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CSolicitudEppDetalle> mListaSolicitudEppDetalleOrigen = new List<CSolicitudEppDetalle>();

        int _IdSolicitudEpp = 0;

        public int IdSolicitudEpp
        {
            get { return _IdSolicitudEpp; }
            set { _IdSolicitudEpp = value; }
        }

        private int intIdJefe = 0;
        private int intIdEmpresa = 0;
        private int intIdUnidadMinera = 0;
        private int intIdArea = 0;

        private int intIdPersona = 0;
        private int intIdEmpresaResponsable = 0;
        private int intIdUnidadMineraResponsable = 0;
        private int intIdAreaResponsable = 0;
        private string strEmailJefe = "";
        private string strEmailResponsable = "";

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
        
        #endregion

        #region "Eventos"

        public frmRegSolicitudEppEdit()
        {
            InitializeComponent();
        }

        private void frmRegSolicitudEppEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;

            gvSolicitudEppDetalle.OptionsView.ShowFooter = true;
            gvSolicitudEppDetalle.Layout += new EventHandler(gvSolicitudEppDetalle_Layout);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Registro Solicitud de Epp - Nuevo ";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Registro Solicitud de Epp - Modificar ";
                SolicitudEppBE objE_SolicitudEpp = null;
                objE_SolicitudEpp = new SolicitudEppBL().Selecciona(IdSolicitudEpp);
                if (objE_SolicitudEpp != null)
                {
                    IdSolicitudEpp = objE_SolicitudEpp.IdSolicitudEpp;
                    deFecha.EditValue = objE_SolicitudEpp.Fecha;
                    txtNumero.Text = objE_SolicitudEpp.Numero;
                    intIdJefe = objE_SolicitudEpp.IdJefe;
                    txtJefe.Text = objE_SolicitudEpp.Jefe;
                    txtCargoSolicitante.Text = objE_SolicitudEpp.CargoJefe;
                    intIdEmpresa = objE_SolicitudEpp.IdEmpresa;
                    intIdUnidadMinera= objE_SolicitudEpp.IdUnidadMinera;
                    intIdArea= objE_SolicitudEpp.IdArea;
                    intIdPersona = objE_SolicitudEpp.IdPersona;
                    txtResponsable.Text = objE_SolicitudEpp.Responsable;
                    txtNegocio.Text = objE_SolicitudEpp.DescNegocio;
                    txtCargo.Text = objE_SolicitudEpp.Cargo;
                    intIdEmpresaResponsable = objE_SolicitudEpp.IdEmpresaResponsable;
                    txtEmpresaResponsable.Text = objE_SolicitudEpp.EmpresaResponsable;
                    intIdUnidadMineraResponsable = objE_SolicitudEpp.IdUnidadMineraResponsable;
                    txtUnidadMineraResponsable.Text = objE_SolicitudEpp.UnidadMineraResponsable;
                    intIdAreaResponsable = objE_SolicitudEpp.IdAreaResponsable;
                    txtAreaResponsable.Text = objE_SolicitudEpp.AreaResponsable;

                    BSUtils.LoaderLook(cboSector, new SectorBL().ListaTodosActivo(intIdEmpresaResponsable, intIdUnidadMineraResponsable, intIdAreaResponsable), "DescSector", "IdSector", true);
                    cboSector.EditValue = objE_SolicitudEpp.IdSectorResponsable;

                }
            }

            CargaEppDetalle();
            AttachSummaryEPP();
        }

        private void btnBucarJefe_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = false;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    intIdJefe = frm.pPersonaBE.IdPersona;
                    txtJefe.Text = frm.pPersonaBE.ApeNom;
                    txtCargoSolicitante.Text = frm.pPersonaBE.Cargo;
                    strEmailJefe = frm.pPersonaBE.Email;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtResponsable.Text = frm.pPersonaBE.ApeNom;
                    txtNegocio.Text = frm.pPersonaBE.DescNegocio;
                    intIdEmpresaResponsable = frm.pPersonaBE.IdEmpresa;
                    txtEmpresaResponsable.Text = frm.pPersonaBE.RazonSocial;
                    intIdUnidadMineraResponsable = frm.pPersonaBE.IdUnidadMinera;
                    txtUnidadMineraResponsable.Text = frm.pPersonaBE.DescUnidadMinera;
                    intIdAreaResponsable = frm.pPersonaBE.IdArea;
                    txtAreaResponsable.Text = frm.pPersonaBE.DescArea;
                    strEmailResponsable = frm.pPersonaBE.Email;

                    BSUtils.LoaderLook(cboSector, new SectorBL().ListaTodosActivo(intIdEmpresaResponsable, intIdUnidadMineraResponsable, intIdAreaResponsable), "DescSector", "IdSector", true);

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
                if (intIdJefe == 0)
                {
                    XtraMessageBox.Show("Debe Seleccionar un Jefe o Supervisor.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (intIdPersona == 0)
                {
                    XtraMessageBox.Show("Debe Seleccionar un Responsable.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frmRegSolicitudEppDetalleEdit movDetalle = new frmRegSolicitudEppDetalleEdit();
                int i = 0;
                if (mListaSolicitudEppDetalleOrigen.Count > 0)
                    i = mListaSolicitudEppDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
                movDetalle.intCorrelativo = Convert.ToInt32(i) + 1;
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaSolicitudEppDetalleOrigen.Count == 0)
                        {
                            gvSolicitudEppDetalle.AddNewRow();
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "IdSolicitudEpp", movDetalle.oBE.IdSolicitudEpp);
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "IdSolicitudEppDetalle", movDetalle.oBE.IdSolicitudEppDetalle);
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "IdEquipo", movDetalle.oBE.IdEquipo);
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "Codigo", movDetalle.oBE.Codigo);
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "DescEquipo", movDetalle.oBE.DescEquipo);
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvSolicitudEppDetalle.UpdateCurrentRow();

                            bNuevo = movDetalle.bNuevo;

                            AttachSummaryEPP();

                            btnNuevo.Focus();

                            return;

                        }

                        if (mListaSolicitudEppDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaSolicitudEppDetalleOrigen.Where(oB => oB.IdEquipo == movDetalle.oBE.IdEquipo).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvSolicitudEppDetalle.AddNewRow();
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "IdSolicitudEpp", movDetalle.oBE.IdSolicitudEpp);
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "IdSolicitudEppDetalle", movDetalle.oBE.IdSolicitudEppDetalle);
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "IdEquipo", movDetalle.oBE.IdEquipo);
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "Codigo", movDetalle.oBE.Codigo);
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "DescEquipo", movDetalle.oBE.DescEquipo);
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvSolicitudEppDetalle.SetRowCellValue(gvSolicitudEppDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvSolicitudEppDetalle.UpdateCurrentRow();

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
            if (mListaSolicitudEppDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmRegSolicitudEppDetalleEdit movDetalle = new frmRegSolicitudEppDetalleEdit();

                movDetalle.IdSolicitudEpp = Convert.ToInt32(gvSolicitudEppDetalle.GetFocusedRowCellValue("IdSolicitudEpp"));
                movDetalle.IdSolicitudEppDetalle = Convert.ToInt32(gvSolicitudEppDetalle.GetFocusedRowCellValue("IdSolicitudEppDetalle"));
                movDetalle.intCorrelativo = Convert.ToInt32(gvSolicitudEppDetalle.GetFocusedRowCellValue("Item"));
                movDetalle.IdEquipo = Convert.ToInt32(gvSolicitudEppDetalle.GetFocusedRowCellValue("IdEquipo"));
                movDetalle.txtCodigo.Text = gvSolicitudEppDetalle.GetFocusedRowCellValue("Codigo").ToString();
                movDetalle.txtDescEquipo.Text = gvSolicitudEppDetalle.GetFocusedRowCellValue("DescEquipo").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvSolicitudEppDetalle.GetFocusedRowCellValue("Cantidad"));

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvSolicitudEppDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvSolicitudEppDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvSolicitudEppDetalle.SetRowCellValue(xposition, "IdSolicitudEpp", movDetalle.oBE.IdSolicitudEpp);
                        gvSolicitudEppDetalle.SetRowCellValue(xposition, "IdSolicitudEppDetalle", movDetalle.oBE.IdSolicitudEppDetalle);
                        gvSolicitudEppDetalle.SetRowCellValue(xposition, "Item", movDetalle.oBE.Item);
                        gvSolicitudEppDetalle.SetRowCellValue(xposition, "IdEquipo", movDetalle.oBE.IdEquipo);
                        gvSolicitudEppDetalle.SetRowCellValue(xposition, "Codigo", movDetalle.oBE.Codigo);
                        gvSolicitudEppDetalle.SetRowCellValue(xposition, "DescEquipo", movDetalle.oBE.DescEquipo);
                        gvSolicitudEppDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                       
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvSolicitudEppDetalle.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvSolicitudEppDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvSolicitudEppDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvSolicitudEppDetalle.UpdateCurrentRow();

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
                if (mListaSolicitudEppDetalleOrigen.Count > 0)
                {
                    if (int.Parse(gvSolicitudEppDetalle.GetFocusedRowCellValue("IdEquipo").ToString()) != 0)
                    {
                        int IdSolicitudEppDetalle = 0;
                        if (gvSolicitudEppDetalle.GetFocusedRowCellValue("IdSolicitudEppDetalle") != null)
                            IdSolicitudEppDetalle = int.Parse(gvSolicitudEppDetalle.GetFocusedRowCellValue("IdSolicitudEppDetalle").ToString());
                        int Item = 0;
                        if (gvSolicitudEppDetalle.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvSolicitudEppDetalle.GetFocusedRowCellValue("Item").ToString());
                        SolicitudEppDetalleBE objBE_EppDetalle = new SolicitudEppDetalleBE();
                        objBE_EppDetalle.IdSolicitudEppDetalle = IdSolicitudEppDetalle;
                        objBE_EppDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objBE_EppDetalle.Usuario = Parametros.strUsuarioLogin;
                        objBE_EppDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        SolicitudEppDetalleBL objBL_EppDetalle = new SolicitudEppDetalleBL();
                        objBL_EppDetalle.Elimina(objBE_EppDetalle);
                        gvSolicitudEppDetalle.DeleteRow(gvSolicitudEppDetalle.FocusedRowHandle);
                        gvSolicitudEppDetalle.RefreshData();

                        //RegeneraItem
                        int i = 0;
                        int cuenta = 0;
                        foreach (var item in mListaSolicitudEppDetalleOrigen)
                        {
                            item.Item = Convert.ToInt32(cuenta + 1);
                            cuenta++;
                            i++;
                        }
                    }
                    else
                    {
                        gvSolicitudEppDetalle.DeleteRow(gvSolicitudEppDetalle.FocusedRowHandle);
                        gvSolicitudEppDetalle.RefreshData();
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

        private void gvSolicitudEppDetalle_Layout(object sender, EventArgs e)
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
                    SolicitudEppBE objSolicitudEpp = new SolicitudEppBE();
                    SolicitudEppBL objBL_SolicitudEpp = new SolicitudEppBL();

                    StringBuilder strMensaje = new StringBuilder();

                    

                    objSolicitudEpp.IdSolicitudEpp = IdSolicitudEpp;
                    objSolicitudEpp.IdUnidadMinera = Parametros.intUnidadMineraId;
                    objSolicitudEpp.IdArea = Parametros.intAreaId;
                    objSolicitudEpp.Numero = txtNumero.Text;
                    objSolicitudEpp.IdJefe = intIdJefe;
                    objSolicitudEpp.IdPersona = intIdPersona;
                    objSolicitudEpp.IdEmpresaResponsable = intIdEmpresaResponsable;
                    objSolicitudEpp.IdUnidadMineraResponsable = intIdUnidadMineraResponsable;
                    objSolicitudEpp.IdAreaResponsable = intIdAreaResponsable;
                    objSolicitudEpp.IdSectorResponsable = Convert.ToInt32(cboSector.EditValue);
                    objSolicitudEpp.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objSolicitudEpp.IdSituacion = Parametros.intSLCPendiente;
                    objSolicitudEpp.FlagEstado = true;
                    objSolicitudEpp.Usuario = Parametros.strUsuarioLogin;
                    objSolicitudEpp.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objSolicitudEpp.IdEmpresa = Parametros.intEmpresaId;
                    objSolicitudEpp.Jefe = txtJefe.Text.Trim();
                    objSolicitudEpp.Responsable = txtResponsable.Text.Trim();
                    objSolicitudEpp.DescUnidadMinera = txtUnidadMineraResponsable.Text;
                    objSolicitudEpp.Email = strEmailJefe;

                    //Solicitud Epp Detalle
                    List<SolicitudEppDetalleBE> lstSolicitudEppDetalle = new List<SolicitudEppDetalleBE>();

                    foreach (var item in mListaSolicitudEppDetalleOrigen)
                    {
                        SolicitudEppDetalleBE objE_SolicitudEppDetalle = new SolicitudEppDetalleBE();
                        objE_SolicitudEppDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objE_SolicitudEppDetalle.IdSolicitudEpp = IdSolicitudEpp;
                        objE_SolicitudEppDetalle.IdSolicitudEppDetalle = item.IdSolicitudEppDetalle;
                        objE_SolicitudEppDetalle.Item = item.Item;
                        objE_SolicitudEppDetalle.IdEquipo = item.IdEquipo;
                        objE_SolicitudEppDetalle.Codigo = item.Codigo;
                        objE_SolicitudEppDetalle.DescEquipo = item.DescEquipo;
                        objE_SolicitudEppDetalle.Cantidad = item.Cantidad;
                        objE_SolicitudEppDetalle.FlagEstado = true;
                        objE_SolicitudEppDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_SolicitudEppDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_SolicitudEppDetalle.TipoOper = item.TipoOper;
                        lstSolicitudEppDetalle.Add(objE_SolicitudEppDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        int intNumero = 0;
                        string strNumero = "";
                        intNumero = objBL_SolicitudEpp.Inserta(objSolicitudEpp, lstSolicitudEppDetalle);
                        strNumero = FuncionBase.AgregarCaracter(intNumero.ToString(), "0", 7);
                        txtNumero.Text = strNumero;

                        //ActualizaNumero
                        SolicitudEppBL objBSolicitudEpp = new SolicitudEppBL();
                        objBSolicitudEpp.ActualizaNumero(intNumero, txtNumero.Text);

                        strMensaje.Append("**************************** SOLICITUD DE EPP *********************************\n\n");
                        strMensaje.Append("Se Generó el N° de Solicitud de EPP : " + txtNumero.Text + "\n\n");
                        strMensaje.Append("Solicitante : " + objSolicitudEpp.Jefe + "\n\n");
                        strMensaje.Append("Responsable : " + objSolicitudEpp.Responsable + "\n\n");
                        strMensaje.Append("Sede : " + objSolicitudEpp.DescUnidadMinera + "\n\n");
                        
                        foreach (var item in mListaSolicitudEppDetalleOrigen)
                        {
                            strMensaje.Append("Código : " + item.Codigo.ToString() + "\n");
                            strMensaje.Append("EPP : " + item.DescEquipo.ToString() + "\n");
                            strMensaje.Append("Cantidad : " + item.Cantidad.ToString() + "\n\n");
                        }

                        strMensaje.Append("Responsable de Entrega de EPP: Jencarlo Villanueva Bruno Anexo 3052/3113  \n\n");
                        strMensaje.Append("********************************************************************************\n\n");

                        BSUtils.EmailSend(objSolicitudEpp.Email, "Solicitud de Epp", strMensaje.ToString(), "", "", "", "");

                        XtraMessageBox.Show("Se creó la Solicitud de Epp N° : " + txtNumero.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        objBL_SolicitudEpp.Actualiza(objSolicitudEpp, lstSolicitudEppDetalle);
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

            if (intIdJefe == 0)
            {
                strMensaje = strMensaje + "- Debe Seleccionar al Jefe o Supervisor.\n";
                flag = true;
            }

            if (intIdPersona == 0)
            {
                strMensaje = strMensaje + "- Debe Seleccionar el Responsable.\n";
                flag = true;
            }

            if (gvSolicitudEppDetalle.DataRowCount == 0)
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
            mListaSolicitudEppDetalleOrigen = new List<CSolicitudEppDetalle>();
            List<SolicitudEppDetalleBE> lstTmpSolicitudEppDetalle = null;
            lstTmpSolicitudEppDetalle = new SolicitudEppDetalleBL().ListaTodosActivo(IdSolicitudEpp);

            foreach (SolicitudEppDetalleBE item in lstTmpSolicitudEppDetalle)
            {
                CSolicitudEppDetalle objE_SolicitudEppDetalle = new CSolicitudEppDetalle();
                objE_SolicitudEppDetalle.IdEmpresa = item.IdEmpresa;
                objE_SolicitudEppDetalle.IdSolicitudEpp = item.IdSolicitudEpp;
                objE_SolicitudEppDetalle.IdSolicitudEppDetalle = item.IdSolicitudEppDetalle;
                objE_SolicitudEppDetalle.Item = item.Item;
                objE_SolicitudEppDetalle.IdEquipo = item.IdEquipo;
                objE_SolicitudEppDetalle.Codigo = item.Codigo;
                objE_SolicitudEppDetalle.DescEquipo = item.DescEquipo;
                objE_SolicitudEppDetalle.Cantidad = item.Cantidad;
                objE_SolicitudEppDetalle.TipoOper = item.TipoOper;
                mListaSolicitudEppDetalleOrigen.Add(objE_SolicitudEppDetalle);
            }

            bsListado.DataSource = mListaSolicitudEppDetalleOrigen;
            gcSolicitudEppDetalle.DataSource = bsListado;
            gcSolicitudEppDetalle.RefreshDataSource();


        }

        private void AttachSummaryEPP()
        {
            GridColumn firstColumn = gvSolicitudEppDetalle.VisibleColumns.Count == 0 ? null : gvSolicitudEppDetalle.VisibleColumns[3];
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

           
        }


        #endregion

        public class CSolicitudEppDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdSolicitudEpp { get; set; }
            public Int32 IdSolicitudEppDetalle { get; set; }
            public Int32 Item { get; set; }
            public Int32 IdEquipo { get; set; }
            public String Codigo { get; set; }
            public String DescEquipo { get; set; }
            public Int32 Cantidad { get; set; }
           
            public Int32 TipoOper { get; set; }

            public CSolicitudEppDetalle()
            {

            }
        }

        
        

        
    }
}