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

namespace SSOMA.Presentacion.Modulos.Accidente.Registros
{
    public partial class frmRegAccidenteEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CAccidenteFoto> mListaAccidenteFotoOrigen = new List<CAccidenteFoto>();
        public List<CAccidenteActoSubEstandar> mListaAccidenteActoSubEstandarOrigen = new List<CAccidenteActoSubEstandar>();
        public List<CAccidenteCondicionSubEstandar> mListaAccidenteCondicionSubEstandarOrigen = new List<CAccidenteCondicionSubEstandar>();
        public List<CAccidenteFactorPersonal> mListaAccidenteFactorPersonalOrigen = new List<CAccidenteFactorPersonal>();
        public List<CAccidenteFactorTrabajo> mListaAccidenteFactorTrabajoOrigen = new List<CAccidenteFactorTrabajo>();
        public List<CAccidenteMedidaPrevencion> mListaAccidenteMedidaPrevencionOrigen = new List<CAccidenteMedidaPrevencion>();
        public List<CAccidenteAccionCorrectiva> mListaAccidenteAccionCorrectivaOrigen = new List<CAccidenteAccionCorrectiva>();
        public List<CAccidenteTestigo> mListaAccidenteTestigoOrigen = new List<CAccidenteTestigo>();
        public List<CAccidenteEntrevistado> mListaAccidenteEntrevistadoOrigen = new List<CAccidenteEntrevistado>();
        public List<CAccidenteDocumento> mListaAccidenteDocumentoOrigen = new List<CAccidenteDocumento>();

        int _IdAccidente = 0;

        public int IdAccidente
        {
            get { return _IdAccidente; }
            set { _IdAccidente = value; }
        }

        private int IdAccidenteCosto = 0;

        private int intIdResponsable = 0;
        private int intIdResponsableArea = 0;

        private int intIdJefeDirecto = 0;
        private int intIdTrabajoOrdenadoPor = 0;
        private int intIdInvestigadoPor = 0;
        private int intIdRevisadoPor = 0;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;

        string strMailJefeDirecto = "";
        string strMailResponsableArea = "";
        string strMailInvestigado = "";
        string strMailRevisado = "";

        #endregion

        #region "Eventos"

        public frmRegAccidenteEdit()
        {
            InitializeComponent();
        }

        private void frmRegAccidenteEdit_Load(object sender, EventArgs e)
        {
            deFecha.DateTime = DateTime.Now;
            teHora.EditValue = DateTime.Now.ToLongTimeString();
            deFechaInicio.DateTime = DateTime.Now;
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTECorporativo), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboEmpresaContratista, new EmpresaBL().ListaCombo(Parametros.intTEContratista), "RazonSocial", "IdEmpresa", true);
            cboEmpresaContratista.EditValue = Parametros.intEmpresaContratistaNinguno;
            BSUtils.LoaderLook(cboTipo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoInvestigacion), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboDanio, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblDañoAccidente), "DescTablaElemento", "IdTablaElemento", true);
            cboDanio.EditValue = Parametros.intDACTrabajador;
            BSUtils.LoaderLook(cboPotencialDanio, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblPotencialDaño), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboProbabilidad, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblProbablidadOcurrencia), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboGrado, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblGradoAccidente), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboTipoAccidente, new TipoAccidenteBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTipoAccidente", "IdTipoAccidente", true);
            BSUtils.LoaderLook(cboParteLesionada, new ParteLesionadaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescParteLesionada", "IdParteLesionada", true);
            BSUtils.LoaderLook(cboTipoLesion, new TipoLesionBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTipoLesion", "IdTipoLesion", true);
            BSUtils.LoaderLook(cboFuenteLesion, new FuenteLesionBL().ListaTodosActivo(Parametros.intEmpresaId), "DescFuenteLesion", "IdFuenteLesion", true);


            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Investigación de Incidente/Accidente - Nuevo ";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Investigación de Incidente/Accidente - Modificar ";

                AccidenteBE objE_Accidente = null;
                objE_Accidente = new AccidenteBL().Selecciona(IdAccidente);
                if (objE_Accidente != null)
                {
                    IdAccidente = objE_Accidente.IdAccidente;
                    cboTipo.EditValue = objE_Accidente.IdTipo;
                    cboDanio.EditValue = objE_Accidente.IdDanio;
                    txtNumero.Text = objE_Accidente.Numero;
                    cboEmpresa.EditValue = objE_Accidente.IdEmpresaResponsable;
                    cboUnidadMinera.EditValue = objE_Accidente.IdUnidadMineraResponsable;
                    cboAreaResponsable.EditValue = objE_Accidente.IdAreaResponsable;
                    cboSectorResponsable.EditValue = objE_Accidente.IdSectorResponsable;
                    intIdResponsable = objE_Accidente.IdPersona == -1 ? 0 : Convert.ToInt32(objE_Accidente.IdPersona);
                    txtResponsable.Text = objE_Accidente.Responsable;
                    cboEmpresaContratista.EditValue = objE_Accidente.IdEmpresaContratista;
                    txtEdad.EditValue = objE_Accidente.Edad;
                    txtTipoContrato.Text = objE_Accidente.DescTipoContrato;
                    txtAreaResponsable.Text = objE_Accidente.AreaResponsable;
                    txtCargo.Text = objE_Accidente.Cargo;
                    txtDni.Text = objE_Accidente.Dni;
                    intIdJefeDirecto = objE_Accidente.IdJefeDirecto == -1 ? 0 : Convert.ToInt32(objE_Accidente.IdJefeDirecto);
                    txtJefe.Text = objE_Accidente.JefeDirecto;
                    txtTiempoExperiencia.Text = objE_Accidente.TiempoExperiencia;
                    txtTipoMaterial.Text = objE_Accidente.TipoMaterial;
                    intIdResponsableArea = objE_Accidente.IdResponsableArea == 1 ? 0 : Convert.ToInt32(objE_Accidente.IdResponsableArea);
                    txtResponsableArea.Text = objE_Accidente.ResponsableArea;
                    deFecha.EditValue = objE_Accidente.Fecha;
                    teHora.EditValue = objE_Accidente.Hora;
                    deFechaInicio.EditValue = objE_Accidente.FechaInicio;
                    txtHoraTrabajada.EditValue = objE_Accidente.Hora;
                    txtLugar.Text = objE_Accidente.Lugar;
                    cboPotencialDanio.EditValue = objE_Accidente.IdPotencialDanio;
                    cboProbabilidad.EditValue = objE_Accidente.IdProbabilidadOcurrencia;
                    cboGrado.EditValue = objE_Accidente.IdGradoAccidente;
                    txtPorque.Text = objE_Accidente.Porque;
                    intIdTrabajoOrdenadoPor = objE_Accidente.IdTrabajoOrdenadoPor;
                    txtTrabajoOrdenadoPor.Text = objE_Accidente.TrabajoOrdenadoPor;
                    cboTipoAccidente.EditValue = objE_Accidente.IdTipoAccidente;
                    cboParteLesionada.EditValue = objE_Accidente.IdParteLesionada;
                    cboTipoLesion.EditValue = objE_Accidente.IdTipoLesion;
                    cboFuenteLesion.EditValue = objE_Accidente.IdFuenteLesion;
                    txtDiasPerdido.EditValue = objE_Accidente.DiasPerdido;
                    txtTrabajadoresAfectado.EditValue = objE_Accidente.TrabajadoresAfectado;
                    txtDescripcion.Text = objE_Accidente.Descripcion;
                    intIdInvestigadoPor = objE_Accidente.IdInvestigadoPor;
                    txtInvestigadoPor.Text = objE_Accidente.InvestigadoPor;
                    intIdRevisadoPor = objE_Accidente.IdRevisadoPor;
                    txtRevisadoPor.Text = objE_Accidente.RevisadoPor;
                }

                List<AccidenteCostoBE> lstAccidenteCosto = null;
                lstAccidenteCosto = new AccidenteCostoBL().ListaTodosActivo(IdAccidente);
                if (lstAccidenteCosto.Count > 0)
                {
                    IdAccidenteCosto = lstAccidenteCosto[0].IdAccidenteCosto;
                    txtDiasPerdidoHospital.Value = lstAccidenteCosto[0].DiasPerdido;
                    txtCostoDia.EditValue = lstAccidenteCosto[0].CostoDia;
                    txtTotalCostoDia.EditValue = lstAccidenteCosto[0].TotalCostoDia;
                    txtHorasExtra.Value = lstAccidenteCosto[0].HorasExtra;
                    txtCostoHorasExtra.EditValue = lstAccidenteCosto[0].CostoHorasExtra;
                    txtTotalCostoHorasExtra.EditValue = lstAccidenteCosto[0].TotalCostoHorasExtra;
                    txtCostoEnergia.EditValue = lstAccidenteCosto[0].CostoEnergia;
                    txtTiempoTrabajado.EditValue = lstAccidenteCosto[0].TiempoTrabajado;
                    txtSalario.EditValue = lstAccidenteCosto[0].Salario;
                    txtSubTotalReemplazo.EditValue = lstAccidenteCosto[0].SubTotalReemplazo;
                    txtReadaptacionTrabajo.EditValue = lstAccidenteCosto[0].ReadaptacionTrabajo;
                    txtReingresoAccidentado.EditValue = lstAccidenteCosto[0].ReingresoAccidentado;
                    txtParalizacionMaquina.EditValue = lstAccidenteCosto[0].ParalizacionMaquina;
                    txtManoObra.EditValue = lstAccidenteCosto[0].ManoObra;
                    txtRepuestos.EditValue = lstAccidenteCosto[0].Repuestos;
                    txtTiempoPerdidoTotal.EditValue = lstAccidenteCosto[0].TiempoPerdidoTotal;
                    txtNumeroTrabajadores.EditValue = lstAccidenteCosto[0].NumeroTrabajadores;
                    txtSalarioPromedio.EditValue = lstAccidenteCosto[0].SalarioPromedio;
                    txtSubTotalSalario.EditValue = lstAccidenteCosto[0].SubTotalSalario;
                    txtTiempoPerdidoSupervisor.EditValue = lstAccidenteCosto[0].TiempoPerdidoSupervisor;
                    txtCostoHoraSupervisor.EditValue = lstAccidenteCosto[0].CostoHoraSupervisor;
                    txtCostoTotalSupervisor.EditValue = lstAccidenteCosto[0].CostoTotalSupervisor;
                    txtCostoTotalAccidentado.EditValue = lstAccidenteCosto[0].CostoTotalAccidentado;
                    txtCostoAdministrativo.EditValue = lstAccidenteCosto[0].CostoAdministrativo;
                    txtCostoTraslado.EditValue = lstAccidenteCosto[0].CostoTraslado;
                    txtCostoEnfermo.EditValue = lstAccidenteCosto[0].CostoEnfermo;
                    txtCostoMaterial.EditValue = lstAccidenteCosto[0].CostoMaterial;
                    txtCostoParamedico.EditValue = lstAccidenteCosto[0].CostoParamedico;
                    txtCostoDiverso.EditValue = lstAccidenteCosto[0].CostoDiverso;
                    txtCostoTotal.EditValue = lstAccidenteCosto[0].CostoTotal;

                }
            }

            CargaAccidenteFoto();
            CargaAccidenteActoSubEstandar();
            CargaAccidenteCondicionSubEstandar();
            CargaAccidenteFactorPersonal();
            CargaAccidenteFactorTrabajo();
            CargaAccidenteMedidaPrevencion();
            CargaAccidenteAccionCorrectiva();
            CargaAccidenteTestigo();
            CargaAccidenteEntrevistado();
            CargaAccidenteDocumento();

        }

        private void cboDanio_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDanio.EditValue != null)
            {
                if (Convert.ToInt32(cboDanio.EditValue) == Parametros.intDACTrabajador)
                {
                    txtResponsable.Enabled = true;
                    btnBuscarResponsable.Enabled = true;
                    txtEdad.Enabled = true;
                    txtTipoContrato.Enabled = true;
                    txtAreaResponsable.Enabled = true;
                    txtCargo.Enabled = true;
                    txtDni.Enabled = true;
                    txtJefe.Enabled = true;
                    btnBuscaJefe.Enabled = true;
                    txtTiempoExperiencia.Enabled = true;
                    txtTipoMaterial.Enabled = false;
                    txtResponsableArea.Enabled = false;
                    btnBuscaResponsableArea.Enabled = false;
                }
                else
                {
                    txtResponsable.Enabled = false;
                    btnBuscarResponsable.Enabled = false;
                    txtEdad.Enabled = false;
                    txtTipoContrato.Enabled = false;
                    txtAreaResponsable.Enabled = false;
                    txtCargo.Enabled = false;
                    txtDni.Enabled = false;
                    txtJefe.Enabled = false;
                    btnBuscaJefe.Enabled = false;
                    txtTiempoExperiencia.Enabled = false;
                    txtTipoMaterial.Enabled = true;
                    txtResponsableArea.Enabled = true;
                    btnBuscaResponsableArea.Enabled = true;
                }
            }
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                BSUtils.LoaderLook(cboUnidadMinera, new UnidadMineraBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescUnidadMinera", "IdUnidadMinera", true);
            }
        }

        private void cboUnidadMinera_EditValueChanged(object sender, EventArgs e)
        {
            if (cboUnidadMinera.EditValue != null)
            {
                BSUtils.LoaderLook(cboAreaResponsable, new AreaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboUnidadMinera.EditValue)), "DescArea", "IdArea", true);
            }

        }

        private void cboAreaResponsable_EditValueChanged(object sender, EventArgs e)
        {
            if (cboAreaResponsable.EditValue != null)
            {
                BSUtils.LoaderLook(cboSectorResponsable, new SectorBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboUnidadMinera.EditValue), Convert.ToInt32(cboAreaResponsable.EditValue)), "DescSector", "IdSector", true);
            }
        }

        private void btnBuscarResponsable_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = true;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    intIdResponsable = frm.pPersonaBE.IdPersona;
                    txtResponsable.Text = frm.pPersonaBE.ApeNom;
                    txtAreaResponsable.Text = frm.pPersonaBE.DescArea;
                    txtDni.Text = frm.pPersonaBE.Dni;
                    txtCargo.Text = frm.pPersonaBE.Cargo;
                    txtEdad.EditValue = frm.pPersonaBE.Edad;
                    txtTipoContrato.Text = frm.pPersonaBE.DescTipoContrato;
                    deFechaIngreso.EditValue = frm.pPersonaBE.FechaIngreso;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnBuscaJefe_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = true;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    intIdJefeDirecto = frm.pPersonaBE.IdPersona;
                    txtJefe.Text = frm.pPersonaBE.ApeNom;
                    strMailJefeDirecto = frm.pPersonaBE.Email;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscaResponsableArea_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = true;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    intIdResponsableArea = frm.pPersonaBE.IdPersona;
                    txtResponsableArea.Text = frm.pPersonaBE.ApeNom;
                    strMailResponsableArea = frm.pPersonaBE.Email;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscaTrabajoOrdenado_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = true;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    intIdTrabajoOrdenadoPor = frm.pPersonaBE.IdPersona;
                    txtTrabajoOrdenadoPor.Text = frm.pPersonaBE.ApeNom;

                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscaInvestigado_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagMultiSelect = false;
                frm.pFlagTodoPersonal = true;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    intIdInvestigadoPor = frm.pPersonaBE.IdPersona;
                    txtInvestigadoPor.Text = frm.pPersonaBE.ApeNom;
                    strMailInvestigado = frm.pPersonaBE.Email;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscaRevisado_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPersona frm = new frmBusPersona();
                frm.pFlagTodoPersonal = true;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pPersonaBE != null)
                {
                    intIdRevisadoPor = frm.pPersonaBE.IdPersona;
                    txtRevisadoPor.Text = frm.pPersonaBE.ApeNom;
                    strMailRevisado = frm.pPersonaBE.Email;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deFecha_EditValueChanged(object sender, EventArgs e)
        {
            string strMensaje;
            if (deFechaIngreso.DateTime.Year > 1)
            {
                GetDateFormat(deFechaIngreso.DateTime, deFecha.DateTime, out strMensaje);
                txtTiempoExperiencia.Text = strMensaje;
            }
        }


        private void nuevoFotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                picImage.Image = SSOMA.Presentacion.Properties.Resources.noImage;

                gvAccidenteFoto.AddNewRow();
                gvAccidenteFoto.SetRowCellValue(gvAccidenteFoto.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                gvAccidenteFoto.SetRowCellValue(gvAccidenteFoto.FocusedRowHandle, "IdAccidente", 0);
                gvAccidenteFoto.SetRowCellValue(gvAccidenteFoto.FocusedRowHandle, "IdAccidenteFoto", 0);
                gvAccidenteFoto.SetRowCellValue(gvAccidenteFoto.FocusedRowHandle, "Foto", new FuncionBase().Image2Bytes(this.picImage.Image));
                gvAccidenteFoto.SetRowCellValue(gvAccidenteFoto.FocusedRowHandle, "DescripcionFoto", "");
                gvAccidenteFoto.SetRowCellValue(gvAccidenteFoto.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvAccidenteFoto.FocusedColumn = gvAccidenteFoto.Columns["Foto"];
                gvAccidenteFoto.ShowEditor();
            }


            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarfotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int IdAccidenteFoto = 0;
                    if (gvAccidenteFoto.GetFocusedRowCellValue("IdAccidenteFoto") != null)
                        IdAccidenteFoto = int.Parse(gvAccidenteFoto.GetFocusedRowCellValue("IdAccidenteFoto").ToString());
                    AccidenteFotoBE objBE_AccidenteFoto = new AccidenteFotoBE();
                    objBE_AccidenteFoto.IdAccidenteFoto = IdAccidenteFoto;
                    objBE_AccidenteFoto.IdEmpresa = Parametros.intEmpresaId;
                    objBE_AccidenteFoto.Usuario = Parametros.strUsuarioLogin;
                    objBE_AccidenteFoto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    AccidenteFotoBL objBL_AccidenteFoto = new AccidenteFotoBL();
                    objBL_AccidenteFoto.Elimina(objBE_AccidenteFoto);
                    gvAccidenteFoto.DeleteRow(gvAccidenteFoto.FocusedRowHandle);
                    gvAccidenteFoto.RefreshData();

                    picImage.Image = SSOMA.Presentacion.Properties.Resources.noImage;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvAccidenteFoto_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gvAccidenteFoto.RowCount > 0)
                {
                    OpenFileDialog openFile = new OpenFileDialog();
                    openFile.Filter = "Jpg File|*.Jpg|Jpeg File|*.Jpeg|Png File|*.Png |Gif File|*.Gif|All|*.*";
                    openFile.ShowDialog();

                    if (openFile.FileName.Length != 0)
                    {
                        this.picImage.Image = new FuncionBase().ScaleImage(Image.FromFile(openFile.FileName), 640, 500);
                    }

                    gvAccidenteFoto.SetRowCellValue(gvAccidenteFoto.FocusedRowHandle, "Foto", new FuncionBase().Image2Bytes(this.picImage.Image));

                    gvAccidenteFoto.FocusedColumn = gvAccidenteFoto.Columns["Descripcion"];
                    gvAccidenteFoto.ShowEditor();

                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtDescActoInseguro_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBuscaActoSubEstandar frm = new frmBuscaActoSubEstandar();
                    frm.pFlagMultiSelect = false;
                    frm.ShowDialog();
                    if (frm.pActoSubEstandarBE != null)
                    {
                        int index = gvAccidenteActoSubEstandar.FocusedRowHandle;

                        var Buscar = mListaAccidenteActoSubEstandarOrigen.Where(oB => oB.IdActoSubEstandar == frm.pActoSubEstandarBE.IdActoSubEstandar).ToList();
                        if (Buscar.Count > 0)
                        {
                            XtraMessageBox.Show("No se puede el registro \n Por Favor Verique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        gvAccidenteActoSubEstandar.SetRowCellValue(index, "IdActoSubEstandar", frm.pActoSubEstandarBE.IdActoSubEstandar);
                        gvAccidenteActoSubEstandar.SetRowCellValue(index, "DescActoSubEstandar", frm.pActoSubEstandarBE.DescActoSubEstandar);

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoActoSubEstandarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvAccidenteActoSubEstandar.AddNewRow();
                gvAccidenteActoSubEstandar.SetRowCellValue(gvAccidenteActoSubEstandar.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                gvAccidenteActoSubEstandar.SetRowCellValue(gvAccidenteActoSubEstandar.FocusedRowHandle, "IdAccidente", 0);
                gvAccidenteActoSubEstandar.SetRowCellValue(gvAccidenteActoSubEstandar.FocusedRowHandle, "IdAccidenteActoSubEstandar", 0);
                gvAccidenteActoSubEstandar.SetRowCellValue(gvAccidenteActoSubEstandar.FocusedRowHandle, "IdActoSubEstandar", 0);
                gvAccidenteActoSubEstandar.SetRowCellValue(gvAccidenteActoSubEstandar.FocusedRowHandle, "DescActoSubEstandar", "");
                gvAccidenteActoSubEstandar.SetRowCellValue(gvAccidenteActoSubEstandar.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvAccidenteActoSubEstandar.FocusedColumn = gvAccidenteActoSubEstandar.Columns["DescActoSubEstandar"];
                gvAccidenteActoSubEstandar.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarActoSubEstandarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int IdAccidenteActoSubEstandar = 0;
                    if (gvAccidenteActoSubEstandar.GetFocusedRowCellValue("IdAccidenteActoSubEstandar") != null)
                        IdAccidenteActoSubEstandar = int.Parse(gvAccidenteActoSubEstandar.GetFocusedRowCellValue("IdAccidenteActoSubEstandar").ToString());
                    AccidenteActoSubEstandarBE objBE_AccidenteActoSubEstandar = new AccidenteActoSubEstandarBE();
                    objBE_AccidenteActoSubEstandar.IdAccidenteActoSubEstandar = IdAccidenteActoSubEstandar;
                    objBE_AccidenteActoSubEstandar.IdEmpresa = Parametros.intEmpresaId;
                    objBE_AccidenteActoSubEstandar.Usuario = Parametros.strUsuarioLogin;
                    objBE_AccidenteActoSubEstandar.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    AccidenteActoSubEstandarBL objBL_AccidenteActoSubEstandar = new AccidenteActoSubEstandarBL();
                    objBL_AccidenteActoSubEstandar.Elimina(objBE_AccidenteActoSubEstandar);
                    gvAccidenteActoSubEstandar.DeleteRow(gvAccidenteActoSubEstandar.FocusedRowHandle);
                    gvAccidenteActoSubEstandar.RefreshData();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtCondicionSubEstandar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBuscaCondicionSubEstandar frm = new frmBuscaCondicionSubEstandar();
                    frm.pFlagMultiSelect = false;
                    frm.ShowDialog();
                    if (frm.pCondicionSubEstandarBE != null)
                    {
                        int index = gvAccidenteCondicionSubEstandar.FocusedRowHandle;

                        var Buscar = mListaAccidenteCondicionSubEstandarOrigen.Where(oB => oB.IdCondicionSubEstandar == frm.pCondicionSubEstandarBE.IdCondicionSubEstandar).ToList();
                        if (Buscar.Count > 0)
                        {
                            XtraMessageBox.Show("No se puede el registro \n Por Favor Verique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        gvAccidenteCondicionSubEstandar.SetRowCellValue(index, "IdCondicionSubEstandar", frm.pCondicionSubEstandarBE.IdCondicionSubEstandar);
                        gvAccidenteCondicionSubEstandar.SetRowCellValue(index, "DescCondicionSubEstandar", frm.pCondicionSubEstandarBE.DescCondicionSubEstandar);

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoCondicionSubEstandarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvAccidenteCondicionSubEstandar.AddNewRow();
                gvAccidenteCondicionSubEstandar.SetRowCellValue(gvAccidenteCondicionSubEstandar.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                gvAccidenteCondicionSubEstandar.SetRowCellValue(gvAccidenteCondicionSubEstandar.FocusedRowHandle, "IdAccidente", 0);
                gvAccidenteCondicionSubEstandar.SetRowCellValue(gvAccidenteCondicionSubEstandar.FocusedRowHandle, "IdAccidenteCondicionSubEstandar", 0);
                gvAccidenteCondicionSubEstandar.SetRowCellValue(gvAccidenteCondicionSubEstandar.FocusedRowHandle, "IdCondicionSubEstandar", 0);
                gvAccidenteCondicionSubEstandar.SetRowCellValue(gvAccidenteCondicionSubEstandar.FocusedRowHandle, "DescCondicionSubEstandar", "");
                gvAccidenteCondicionSubEstandar.SetRowCellValue(gvAccidenteCondicionSubEstandar.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvAccidenteCondicionSubEstandar.FocusedColumn = gvAccidenteCondicionSubEstandar.Columns["DescCondicionSubEstandar"];
                gvAccidenteCondicionSubEstandar.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarCondicionSubEstandarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int IdAccidenteCondicionSubEstandar = 0;
                    if (gvAccidenteCondicionSubEstandar.GetFocusedRowCellValue("IdAccidenteCondicionSubEstandar") != null)
                        IdAccidenteCondicionSubEstandar = int.Parse(gvAccidenteCondicionSubEstandar.GetFocusedRowCellValue("IdAccidenteCondicionSubEstandar").ToString());
                    AccidenteCondicionSubEstandarBE objBE_AccidenteCondicionSubEstandar = new AccidenteCondicionSubEstandarBE();
                    objBE_AccidenteCondicionSubEstandar.IdAccidenteCondicionSubEstandar = IdAccidenteCondicionSubEstandar;
                    objBE_AccidenteCondicionSubEstandar.IdEmpresa = Parametros.intEmpresaId;
                    objBE_AccidenteCondicionSubEstandar.Usuario = Parametros.strUsuarioLogin;
                    objBE_AccidenteCondicionSubEstandar.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    AccidenteCondicionSubEstandarBL objBL_AccidenteCondicionSubEstandar = new AccidenteCondicionSubEstandarBL();
                    objBL_AccidenteCondicionSubEstandar.Elimina(objBE_AccidenteCondicionSubEstandar);
                    gvAccidenteCondicionSubEstandar.DeleteRow(gvAccidenteCondicionSubEstandar.FocusedRowHandle);
                    gvAccidenteCondicionSubEstandar.RefreshData();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtFactorPersonal_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBuscaFactorPersonal frm = new frmBuscaFactorPersonal();
                    frm.pFlagMultiSelect = false;
                    frm.ShowDialog();
                    if (frm.pFactorPersonalBE != null)
                    {
                        int index = gvAccidenteFactorPersonal.FocusedRowHandle;

                        var Buscar = mListaAccidenteFactorPersonalOrigen.Where(oB => oB.IdFactorPersonal == frm.pFactorPersonalBE.IdFactorPersonal).ToList();
                        if (Buscar.Count > 0)
                        {
                            XtraMessageBox.Show("No se puede el registro \n Por Favor Verique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        gvAccidenteFactorPersonal.SetRowCellValue(index, "IdFactorPersonal", frm.pFactorPersonalBE.IdFactorPersonal);
                        gvAccidenteFactorPersonal.SetRowCellValue(index, "DescFactorPersonal", frm.pFactorPersonalBE.DescFactorPersonal);

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void nuevoFactorPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvAccidenteFactorPersonal.AddNewRow();
                gvAccidenteFactorPersonal.SetRowCellValue(gvAccidenteFactorPersonal.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                gvAccidenteFactorPersonal.SetRowCellValue(gvAccidenteFactorPersonal.FocusedRowHandle, "IdAccidente", 0);
                gvAccidenteFactorPersonal.SetRowCellValue(gvAccidenteFactorPersonal.FocusedRowHandle, "IdAccidenteFactorPersonal", 0);
                gvAccidenteFactorPersonal.SetRowCellValue(gvAccidenteFactorPersonal.FocusedRowHandle, "IdFactorPersonal", 0);
                gvAccidenteFactorPersonal.SetRowCellValue(gvAccidenteFactorPersonal.FocusedRowHandle, "DescFactorPersonal", "");
                gvAccidenteFactorPersonal.SetRowCellValue(gvAccidenteFactorPersonal.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvAccidenteFactorPersonal.FocusedColumn = gvAccidenteFactorPersonal.Columns["DescFactorPersonal"];
                gvAccidenteFactorPersonal.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarFactorPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int IdAccidenteFactorPersonal = 0;
                    if (gvAccidenteFactorPersonal.GetFocusedRowCellValue("IdAccidenteFactorPersonal") != null)
                        IdAccidenteFactorPersonal = int.Parse(gvAccidenteFactorPersonal.GetFocusedRowCellValue("IdAccidenteFactorPersonal").ToString());
                    AccidenteFactorPersonalBE objBE_AccidenteFactorPersonal = new AccidenteFactorPersonalBE();
                    objBE_AccidenteFactorPersonal.IdAccidenteFactorPersonal = IdAccidenteFactorPersonal;
                    objBE_AccidenteFactorPersonal.IdEmpresa = Parametros.intEmpresaId;
                    objBE_AccidenteFactorPersonal.Usuario = Parametros.strUsuarioLogin;
                    objBE_AccidenteFactorPersonal.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    AccidenteFactorPersonalBL objBL_AccidenteFactorPersonal = new AccidenteFactorPersonalBL();
                    objBL_AccidenteFactorPersonal.Elimina(objBE_AccidenteFactorPersonal);
                    gvAccidenteFactorPersonal.DeleteRow(gvAccidenteFactorPersonal.FocusedRowHandle);
                    gvAccidenteFactorPersonal.RefreshData();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtFactorTrabajo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBuscaFactorTrabajo frm = new frmBuscaFactorTrabajo();
                    frm.pFlagMultiSelect = false;
                    frm.ShowDialog();
                    if (frm.pFactorTrabajoBE != null)
                    {
                        int index = gvAccidenteFactorTrabajo.FocusedRowHandle;

                        var Buscar = mListaAccidenteFactorTrabajoOrigen.Where(oB => oB.IdFactorTrabajo == frm.pFactorTrabajoBE.IdFactorTrabajo).ToList();
                        if (Buscar.Count > 0)
                        {
                            XtraMessageBox.Show("No se puede el registro \n Por Favor Verique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        gvAccidenteFactorTrabajo.SetRowCellValue(index, "IdFactorTrabajo", frm.pFactorTrabajoBE.IdFactorTrabajo);
                        gvAccidenteFactorTrabajo.SetRowCellValue(index, "DescFactorTrabajo", frm.pFactorTrabajoBE.DescFactorTrabajo);

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoFactorTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvAccidenteFactorTrabajo.AddNewRow();
                gvAccidenteFactorTrabajo.SetRowCellValue(gvAccidenteFactorTrabajo.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                gvAccidenteFactorTrabajo.SetRowCellValue(gvAccidenteFactorTrabajo.FocusedRowHandle, "IdAccidente", 0);
                gvAccidenteFactorTrabajo.SetRowCellValue(gvAccidenteFactorTrabajo.FocusedRowHandle, "IdAccidenteFactorTrabajo", 0);
                gvAccidenteFactorTrabajo.SetRowCellValue(gvAccidenteFactorTrabajo.FocusedRowHandle, "IdFactorTrabajo", 0);
                gvAccidenteFactorTrabajo.SetRowCellValue(gvAccidenteFactorTrabajo.FocusedRowHandle, "DescFactorTrabajo", "");
                gvAccidenteFactorTrabajo.SetRowCellValue(gvAccidenteFactorTrabajo.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvAccidenteFactorTrabajo.FocusedColumn = gvAccidenteFactorTrabajo.Columns["DescFactorTrabajo"];
                gvAccidenteFactorTrabajo.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarFactorTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int IdAccidenteFactorTrabajo = 0;
                    if (gvAccidenteFactorTrabajo.GetFocusedRowCellValue("IdAccidenteFactorTrabajo") != null)
                        IdAccidenteFactorTrabajo = int.Parse(gvAccidenteFactorTrabajo.GetFocusedRowCellValue("IdAccidenteFactorTrabajo").ToString());
                    AccidenteFactorTrabajoBE objBE_AccidenteFactorTrabajo = new AccidenteFactorTrabajoBE();
                    objBE_AccidenteFactorTrabajo.IdAccidenteFactorTrabajo = IdAccidenteFactorTrabajo;
                    objBE_AccidenteFactorTrabajo.IdEmpresa = Parametros.intEmpresaId;
                    objBE_AccidenteFactorTrabajo.Usuario = Parametros.strUsuarioLogin;
                    objBE_AccidenteFactorTrabajo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    AccidenteFactorTrabajoBL objBL_AccidenteFactorTrabajo = new AccidenteFactorTrabajoBL();
                    objBL_AccidenteFactorTrabajo.Elimina(objBE_AccidenteFactorTrabajo);
                    gvAccidenteFactorTrabajo.DeleteRow(gvAccidenteFactorTrabajo.FocusedRowHandle);
                    gvAccidenteFactorTrabajo.RefreshData();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoMedidaPrevencionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvAccidenteMedidaPrevencion.AddNewRow();
                gvAccidenteMedidaPrevencion.SetRowCellValue(gvAccidenteMedidaPrevencion.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                gvAccidenteMedidaPrevencion.SetRowCellValue(gvAccidenteMedidaPrevencion.FocusedRowHandle, "IdAccidente", 0);
                gvAccidenteMedidaPrevencion.SetRowCellValue(gvAccidenteMedidaPrevencion.FocusedRowHandle, "IdAccidenteMedidaPrevencion", 0);
                gvAccidenteMedidaPrevencion.SetRowCellValue(gvAccidenteMedidaPrevencion.FocusedRowHandle, "DescMedidaPrevencion", "");
                gvAccidenteMedidaPrevencion.SetRowCellValue(gvAccidenteMedidaPrevencion.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvAccidenteMedidaPrevencion.FocusedColumn = gvAccidenteMedidaPrevencion.Columns["DescMedidaPrevencion"];
                gvAccidenteMedidaPrevencion.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarMedidaPrevencionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int IdAccidenteMedidaPrevencion = 0;
                    if (gvAccidenteMedidaPrevencion.GetFocusedRowCellValue("IdAccidenteMedidaPrevencion") != null)
                        IdAccidenteMedidaPrevencion = int.Parse(gvAccidenteMedidaPrevencion.GetFocusedRowCellValue("IdAccidenteMedidaPrevencion").ToString());
                    AccidenteMedidaPrevencionBE objBE_AccidenteMedidaPrevencion = new AccidenteMedidaPrevencionBE();
                    objBE_AccidenteMedidaPrevencion.IdAccidenteMedidaPrevencion = IdAccidenteMedidaPrevencion;
                    objBE_AccidenteMedidaPrevencion.IdEmpresa = Parametros.intEmpresaId;
                    objBE_AccidenteMedidaPrevencion.Usuario = Parametros.strUsuarioLogin;
                    objBE_AccidenteMedidaPrevencion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    AccidenteMedidaPrevencionBL objBL_AccidenteMedidaPrevencion = new AccidenteMedidaPrevencionBL();
                    objBL_AccidenteMedidaPrevencion.Elimina(objBE_AccidenteMedidaPrevencion);
                    gvAccidenteMedidaPrevencion.DeleteRow(gvAccidenteMedidaPrevencion.FocusedRowHandle);
                    gvAccidenteMedidaPrevencion.RefreshData();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtResponsableCumplimiento_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBusPersona frm = new frmBusPersona();
                    frm.pFlagTodoPersonal = true;
                    frm.pFlagMultiSelect = false;
                    frm.ShowDialog();
                    if (frm.pPersonaBE != null)
                    {
                        int index = gvAccidenteAccionCorrectiva.FocusedRowHandle;

                        //var Buscar = mListaAccidenteAccionCorrectivaOrigen.Where(oB => oB.IdResponsable == frm.pPersonaBE.IdPersona).ToList();
                        //if (Buscar.Count > 0)
                        //{
                        //    XtraMessageBox.Show("No se puede repetir el responsable del cumplimiento \n Por Favor Verique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}

                        gvAccidenteAccionCorrectiva.SetRowCellValue(index, "IdResponsable", frm.pPersonaBE.IdPersona);
                        gvAccidenteAccionCorrectiva.SetRowCellValue(index, "Responsable", frm.pPersonaBE.ApeNom);

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoAccionCorrectivaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvAccidenteAccionCorrectiva.AddNewRow();
                gvAccidenteAccionCorrectiva.SetRowCellValue(gvAccidenteAccionCorrectiva.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                gvAccidenteAccionCorrectiva.SetRowCellValue(gvAccidenteAccionCorrectiva.FocusedRowHandle, "IdAccidente", 0);
                gvAccidenteAccionCorrectiva.SetRowCellValue(gvAccidenteAccionCorrectiva.FocusedRowHandle, "IdAccidenteAccionCorrectiva", 0);
                gvAccidenteAccionCorrectiva.SetRowCellValue(gvAccidenteAccionCorrectiva.FocusedRowHandle, "DescAccionCorrectiva", "");
                gvAccidenteAccionCorrectiva.SetRowCellValue(gvAccidenteAccionCorrectiva.FocusedRowHandle, "IdResponsable", 0);
                gvAccidenteAccionCorrectiva.SetRowCellValue(gvAccidenteAccionCorrectiva.FocusedRowHandle, "Responsable", "");
                gvAccidenteAccionCorrectiva.SetRowCellValue(gvAccidenteAccionCorrectiva.FocusedRowHandle, "FechaCumplimiento", deFecha.DateTime.AddDays(15));
                gvAccidenteAccionCorrectiva.SetRowCellValue(gvAccidenteAccionCorrectiva.FocusedRowHandle, "IdSituacion", Parametros.intACCPendiente);
                gvAccidenteAccionCorrectiva.SetRowCellValue(gvAccidenteAccionCorrectiva.FocusedRowHandle, "DescSituacion", "PENDIENTE");
                gvAccidenteAccionCorrectiva.SetRowCellValue(gvAccidenteAccionCorrectiva.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvAccidenteAccionCorrectiva.FocusedColumn = gvAccidenteAccionCorrectiva.Columns["DescAccionCorrectiva"];
                gvAccidenteAccionCorrectiva.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarAccionCorrectivaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int IdAccidenteAccionCorrectiva = 0;
                    if (gvAccidenteAccionCorrectiva.GetFocusedRowCellValue("IdAccidenteAccionCorrectiva") != null)
                        IdAccidenteAccionCorrectiva = int.Parse(gvAccidenteAccionCorrectiva.GetFocusedRowCellValue("IdAccidenteAccionCorrectiva").ToString());
                    AccidenteAccionCorrectivaBE objBE_AccidenteAccionCorrectiva = new AccidenteAccionCorrectivaBE();
                    objBE_AccidenteAccionCorrectiva.IdAccidenteAccionCorrectiva = IdAccidenteAccionCorrectiva;
                    objBE_AccidenteAccionCorrectiva.IdEmpresa = Parametros.intEmpresaId;
                    objBE_AccidenteAccionCorrectiva.Usuario = Parametros.strUsuarioLogin;
                    objBE_AccidenteAccionCorrectiva.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    AccidenteAccionCorrectivaBL objBL_AccidenteAccionCorrectiva = new AccidenteAccionCorrectivaBL();
                    objBL_AccidenteAccionCorrectiva.Elimina(objBE_AccidenteAccionCorrectiva);
                    gvAccidenteAccionCorrectiva.DeleteRow(gvAccidenteAccionCorrectiva.FocusedRowHandle);
                    gvAccidenteAccionCorrectiva.RefreshData();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtTestigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBusPersona frm = new frmBusPersona();
                    frm.pFlagTodoPersonal = true;
                    frm.pFlagMultiSelect = false;
                    frm.ShowDialog();
                    if (frm.pPersonaBE != null)
                    {
                        int index = gvAccidenteTestigo.FocusedRowHandle;

                        var Buscar = mListaAccidenteTestigoOrigen.Where(oB => oB.IdTestigo == frm.pPersonaBE.IdPersona).ToList();
                        if (Buscar.Count > 0)
                        {
                            XtraMessageBox.Show("No se puede repetir el testigo \n Por Favor Verique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        gvAccidenteTestigo.SetRowCellValue(index, "IdTestigo", frm.pPersonaBE.IdPersona);
                        gvAccidenteTestigo.SetRowCellValue(index, "Testigo", frm.pPersonaBE.ApeNom);

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarAccionCorrectivaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvAccidenteAccionCorrectiva.RowCount > 0)
                {
                    string strMailTO = "";

                    int intIdResponsable = int.Parse(gvAccidenteAccionCorrectiva.GetFocusedRowCellValue("IdResponsable").ToString());
                    string strDescripcionAccionCorrectiva = gvAccidenteAccionCorrectiva.GetFocusedRowCellValue("DescAccionCorrectiva").ToString();
                    string strResponsable = gvAccidenteAccionCorrectiva.GetFocusedRowCellValue("Responsable").ToString();
                    string strFechaCumplimiento = gvAccidenteAccionCorrectiva.GetFocusedRowCellValue("FechaCumplimiento").ToString();

                    string strAccionCorrectiva = strDescripcionAccionCorrectiva + "  " + strResponsable + "  " + strFechaCumplimiento;

                    PersonaBE objE_Persona = new PersonaBE();
                    objE_Persona = new PersonaBL().Selecciona(0, 0, 0, intIdResponsable);
                    if (objE_Persona != null)
                    {
                        strMailTO = objE_Persona.Email;
                    }

                    int intIAccidentedAccionCorrectiva = int.Parse(gvAccidenteAccionCorrectiva.GetFocusedRowCellValue("IdAccidenteAccionCorrectiva").ToString());
                    frmActualizaAccionCorrectiva objAccionCorrectiva = new frmActualizaAccionCorrectiva();
                    objAccionCorrectiva.IdAccidenteAccionCorrectiva = intIAccidentedAccionCorrectiva;
                    objAccionCorrectiva.IdTipo = Convert.ToInt32(cboTipo.EditValue);
                    objAccionCorrectiva.strTipo = cboTipo.Text;
                    objAccionCorrectiva.Numero = txtNumero.Text;
                    objAccionCorrectiva.strMailTO = strMailTO;
                    objAccionCorrectiva.strAccionCorrectiva = strAccionCorrectiva;
                    objAccionCorrectiva.StartPosition = FormStartPosition.CenterScreen;
                    objAccionCorrectiva.ShowDialog();
                    CargaAccidenteAccionCorrectiva();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoTestigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvAccidenteTestigo.AddNewRow();
                gvAccidenteTestigo.SetRowCellValue(gvAccidenteTestigo.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                gvAccidenteTestigo.SetRowCellValue(gvAccidenteTestigo.FocusedRowHandle, "IdAccidente", 0);
                gvAccidenteTestigo.SetRowCellValue(gvAccidenteTestigo.FocusedRowHandle, "IdAccidenteTestigo", 0);
                gvAccidenteTestigo.SetRowCellValue(gvAccidenteTestigo.FocusedRowHandle, "IdTestigo", 0);
                gvAccidenteTestigo.SetRowCellValue(gvAccidenteTestigo.FocusedRowHandle, "Testigo", "");
                gvAccidenteTestigo.SetRowCellValue(gvAccidenteTestigo.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvAccidenteTestigo.FocusedColumn = gvAccidenteTestigo.Columns["Testigo"];
                gvAccidenteTestigo.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarTestigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int IdAccidenteTestigo = 0;
                    if (gvAccidenteTestigo.GetFocusedRowCellValue("IdAccidenteTestigo") != null)
                        IdAccidenteTestigo = int.Parse(gvAccidenteTestigo.GetFocusedRowCellValue("IdAccidenteTestigo").ToString());
                    AccidenteTestigoBE objBE_AccidenteTestigo = new AccidenteTestigoBE();
                    objBE_AccidenteTestigo.IdAccidenteTestigo = IdAccidenteTestigo;
                    objBE_AccidenteTestigo.IdEmpresa = Parametros.intEmpresaId;
                    objBE_AccidenteTestigo.Usuario = Parametros.strUsuarioLogin;
                    objBE_AccidenteTestigo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    AccidenteTestigoBL objBL_AccidenteTestigo = new AccidenteTestigoBL();
                    objBL_AccidenteTestigo.Elimina(objBE_AccidenteTestigo);
                    gvAccidenteTestigo.DeleteRow(gvAccidenteTestigo.FocusedRowHandle);
                    gvAccidenteTestigo.RefreshData();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtEntrevistado_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmBusPersona frm = new frmBusPersona();
                    frm.pFlagTodoPersonal = true;
                    frm.pFlagMultiSelect = false;
                    frm.ShowDialog();
                    if (frm.pPersonaBE != null)
                    {
                        int index = gvAccidenteEntrevistado.FocusedRowHandle;

                        var Buscar = mListaAccidenteEntrevistadoOrigen.Where(oB => oB.IdEntrevistado == frm.pPersonaBE.IdPersona).ToList();
                        if (Buscar.Count > 0)
                        {
                            XtraMessageBox.Show("No se puede repetir el Entrevistado \n Por Favor Verique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        gvAccidenteEntrevistado.SetRowCellValue(index, "IdEntrevistado", frm.pPersonaBE.IdPersona);
                        gvAccidenteEntrevistado.SetRowCellValue(index, "Entrevistado", frm.pPersonaBE.ApeNom);

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoEntrevistadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvAccidenteEntrevistado.AddNewRow();
                gvAccidenteEntrevistado.SetRowCellValue(gvAccidenteEntrevistado.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                gvAccidenteEntrevistado.SetRowCellValue(gvAccidenteEntrevistado.FocusedRowHandle, "IdAccidente", 0);
                gvAccidenteEntrevistado.SetRowCellValue(gvAccidenteEntrevistado.FocusedRowHandle, "IdAccidenteEntrevistado", 0);
                gvAccidenteEntrevistado.SetRowCellValue(gvAccidenteEntrevistado.FocusedRowHandle, "IdEntrevistado", 0);
                gvAccidenteEntrevistado.SetRowCellValue(gvAccidenteEntrevistado.FocusedRowHandle, "Entrevistado", "");
                gvAccidenteEntrevistado.SetRowCellValue(gvAccidenteEntrevistado.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvAccidenteEntrevistado.FocusedColumn = gvAccidenteEntrevistado.Columns["Entrevistado"];
                gvAccidenteEntrevistado.ShowEditor();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarEntrevistadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int IdAccidenteEntrevistado = 0;
                    if (gvAccidenteEntrevistado.GetFocusedRowCellValue("IdAccidenteEntrevistado") != null)
                        IdAccidenteEntrevistado = int.Parse(gvAccidenteEntrevistado.GetFocusedRowCellValue("IdAccidenteEntrevistado").ToString());
                    AccidenteEntrevistadoBE objBE_AccidenteEntrevistado = new AccidenteEntrevistadoBE();
                    objBE_AccidenteEntrevistado.IdAccidenteEntrevistado = IdAccidenteEntrevistado;
                    objBE_AccidenteEntrevistado.IdEmpresa = Parametros.intEmpresaId;
                    objBE_AccidenteEntrevistado.Usuario = Parametros.strUsuarioLogin;
                    objBE_AccidenteEntrevistado.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    AccidenteEntrevistadoBL objBL_AccidenteEntrevistado = new AccidenteEntrevistadoBL();
                    objBL_AccidenteEntrevistado.Elimina(objBE_AccidenteEntrevistado);
                    gvAccidenteEntrevistado.DeleteRow(gvAccidenteEntrevistado.FocusedRowHandle);
                    gvAccidenteEntrevistado.RefreshData();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                picImage.Image = SSOMA.Presentacion.Properties.Resources.noImage;

                gvAccidenteDocumento.AddNewRow();
                gvAccidenteDocumento.SetRowCellValue(gvAccidenteDocumento.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                gvAccidenteDocumento.SetRowCellValue(gvAccidenteDocumento.FocusedRowHandle, "IdAccidente", 0);
                gvAccidenteDocumento.SetRowCellValue(gvAccidenteDocumento.FocusedRowHandle, "IdAccidenteDocumento", 0);
                gvAccidenteDocumento.SetRowCellValue(gvAccidenteDocumento.FocusedRowHandle, "Foto", new FuncionBase().Image2Bytes(this.picImage.Image));
                gvAccidenteDocumento.SetRowCellValue(gvAccidenteDocumento.FocusedRowHandle, "DescripcionDocumento", "");
                gvAccidenteDocumento.SetRowCellValue(gvAccidenteDocumento.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                gvAccidenteDocumento.FocusedColumn = gvAccidenteDocumento.Columns["Foto"];
                gvAccidenteDocumento.ShowEditor();
            }


            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminaDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int IdAccidenteDocumento = 0;
                    if (gvAccidenteDocumento.GetFocusedRowCellValue("IdAccidenteDocumento") != null)
                        IdAccidenteDocumento = int.Parse(gvAccidenteDocumento.GetFocusedRowCellValue("IdAccidenteDocumento").ToString());
                    AccidenteDocumentoBE objBE_AccidenteDocumento = new AccidenteDocumentoBE();
                    objBE_AccidenteDocumento.IdAccidenteDocumento = IdAccidenteDocumento;
                    objBE_AccidenteDocumento.IdEmpresa = Parametros.intEmpresaId;
                    objBE_AccidenteDocumento.Usuario = Parametros.strUsuarioLogin;
                    objBE_AccidenteDocumento.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    AccidenteDocumentoBL objBL_AccidenteDocumento = new AccidenteDocumentoBL();
                    objBL_AccidenteDocumento.Elimina(objBE_AccidenteDocumento);
                    gvAccidenteDocumento.DeleteRow(gvAccidenteDocumento.FocusedRowHandle);
                    gvAccidenteDocumento.RefreshData();

                    picImage.Image = SSOMA.Presentacion.Properties.Resources.noImage;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvAccidenteDocumento_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gvAccidenteDocumento.RowCount > 0)
                {
                    OpenFileDialog openFile = new OpenFileDialog();
                    openFile.Filter = "Jpg File|*.Jpg|Jpeg File|*.Jpeg|Png File|*.Png |Gif File|*.Gif|All|*.*";
                    openFile.ShowDialog();

                    if (openFile.FileName.Length != 0)
                    {
                        this.picImage.Image = new FuncionBase().ScaleImage(Image.FromFile(openFile.FileName), 640, 500);
                    }

                    gvAccidenteDocumento.SetRowCellValue(gvAccidenteDocumento.FocusedRowHandle, "Foto", new FuncionBase().Image2Bytes(this.picImage.Image));

                    gvAccidenteDocumento.FocusedColumn = gvAccidenteDocumento.Columns["DescripcionDocumemento"];
                    gvAccidenteDocumento.ShowEditor();

                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvAccidenteAccionCorrectiva_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (e.Column.FieldName == "DescSituacion")
                    {
                        string Situacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["DescSituacion"]);
                        if (Situacion == "PENDIENTE")
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "PROCESO")
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                        if (Situacion == "EJECUTADO")
                        {
                            e.Appearance.BackColor = Color.Green;
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

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    AccidenteBE objAccidente = new AccidenteBE();
                    AccidenteBL objBL_Accidente = new AccidenteBL();

                    objAccidente.IdAccidente = IdAccidente;
                    objAccidente.IdTipo = Convert.ToInt32(cboTipo.EditValue);
                    objAccidente.IdDanio = Convert.ToInt32(cboDanio.EditValue);
                    objAccidente.Numero = txtNumero.Text;
                    objAccidente.IdEmpresaResponsable = Convert.ToInt32(cboEmpresa.EditValue);
                    objAccidente.IdUnidadMineraResponsable = Convert.ToInt32(cboUnidadMinera.EditValue);
                    objAccidente.IdAreaResponsable = Convert.ToInt32(cboAreaResponsable.EditValue);
                    objAccidente.IdSectorResponsable = Convert.ToInt32(cboSectorResponsable.EditValue);
                    objAccidente.IdPersona = intIdResponsable == 0 ? (int?)null : intIdResponsable;
                    objAccidente.IdJefeDirecto = intIdJefeDirecto == 0 ? (int?)null : intIdJefeDirecto;
                    objAccidente.IdEmpresaContratista = Convert.ToInt32(cboEmpresaContratista.EditValue);
                    objAccidente.TiempoExperiencia = txtTiempoExperiencia.Text;
                    objAccidente.TipoMaterial = txtTipoMaterial.Text;
                    objAccidente.IdResponsableArea = intIdResponsableArea == 0 || intIdResponsableArea == -1 ? (int?)null : intIdResponsableArea;
                    objAccidente.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objAccidente.Hora = Convert.ToDateTime(teHora.EditValue);
                    objAccidente.FechaInicio = Convert.ToDateTime(deFechaInicio.DateTime.ToShortDateString());
                    objAccidente.Lugar = txtLugar.Text;
                    objAccidente.HoraTrabajada = txtHoraTrabajada.Text;
                    objAccidente.IdPotencialDanio = Convert.ToInt32(cboPotencialDanio.EditValue);
                    objAccidente.IdProbabilidadOcurrencia = Convert.ToInt32(cboProbabilidad.EditValue);
                    objAccidente.IdGradoAccidente = Convert.ToInt32(cboGrado.EditValue);
                    objAccidente.Porque = txtTrabajoOrdenadoPor.Text;
                    objAccidente.IdTrabajoOrdenadoPor = intIdTrabajoOrdenadoPor;
                    objAccidente.IdTipoAccidente = Convert.ToInt32(cboTipoAccidente.EditValue);
                    objAccidente.IdParteLesionada = Convert.ToInt32(cboParteLesionada.EditValue);
                    objAccidente.IdTipoLesion = Convert.ToInt32(cboTipoLesion.EditValue);
                    objAccidente.IdFuenteLesion = Convert.ToInt32(cboFuenteLesion.EditValue);
                    objAccidente.DiasPerdido = Convert.ToInt32(txtDiasPerdido.EditValue);
                    objAccidente.TrabajadoresAfectado = Convert.ToInt32(txtTrabajadoresAfectado.EditValue);
                    objAccidente.Descripcion = txtDescripcion.Text;
                    objAccidente.IdInvestigadoPor = intIdInvestigadoPor;
                    objAccidente.IdRevisadoPor = intIdRevisadoPor;
                    objAccidente.FlagEstado = true;
                    objAccidente.Usuario = Parametros.strUsuarioLogin;
                    objAccidente.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objAccidente.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                    //COSTOS
                    AccidenteCostoBE objAccidenteCoto = new AccidenteCostoBE();
                    objAccidenteCoto.IdAccidente = IdAccidente;
                    objAccidenteCoto.IdAccidenteCosto = IdAccidenteCosto;
                    objAccidenteCoto.DiasPerdido = Convert.ToInt32(txtDiasPerdidoHospital.Value);
                    objAccidenteCoto.CostoDia = Convert.ToDecimal(txtCostoDia.EditValue);
                    objAccidenteCoto.TotalCostoDia = Convert.ToDecimal(txtTotalCostoDia.EditValue);
                    objAccidenteCoto.HorasExtra = Convert.ToInt32(txtHorasExtra.Value);
                    objAccidenteCoto.CostoHorasExtra = Convert.ToDecimal(txtCostoHorasExtra.EditValue);
                    objAccidenteCoto.TotalCostoHorasExtra = Convert.ToDecimal(txtTotalCostoHorasExtra.EditValue);
                    objAccidenteCoto.CostoEnergia = Convert.ToDecimal(txtCostoEnergia.EditValue);
                    objAccidenteCoto.TiempoTrabajado = Convert.ToInt32(txtTiempoTrabajado.Value);
                    objAccidenteCoto.Salario = Convert.ToDecimal(txtSalario.EditValue);
                    objAccidenteCoto.SubTotalReemplazo = Convert.ToDecimal(txtSubTotalReemplazo.EditValue);
                    objAccidenteCoto.ReadaptacionTrabajo = Convert.ToDecimal(txtReadaptacionTrabajo.EditValue);
                    objAccidenteCoto.ReingresoAccidentado = Convert.ToDecimal(txtReingresoAccidentado.EditValue);
                    objAccidenteCoto.ParalizacionMaquina = Convert.ToDecimal(txtParalizacionMaquina.EditValue);
                    objAccidenteCoto.ManoObra = Convert.ToDecimal(txtManoObra.EditValue);
                    objAccidenteCoto.Repuestos = Convert.ToDecimal(txtRepuestos.EditValue);
                    objAccidenteCoto.TiempoPerdidoTotal = Convert.ToDecimal(txtTiempoPerdidoTotal.EditValue);
                    objAccidenteCoto.NumeroTrabajadores = Convert.ToInt32(txtNumeroTrabajadores.EditValue);
                    objAccidenteCoto.SalarioPromedio = Convert.ToDecimal(txtSalarioPromedio.EditValue);
                    objAccidenteCoto.SubTotalSalario = Convert.ToDecimal(txtSubTotalSalario.EditValue);
                    objAccidenteCoto.TiempoPerdidoSupervisor = Convert.ToInt32(txtTiempoPerdidoSupervisor.EditValue);
                    objAccidenteCoto.CostoHoraSupervisor = Convert.ToDecimal(txtCostoHoraSupervisor.EditValue);
                    objAccidenteCoto.CostoTotalSupervisor = Convert.ToDecimal(txtCostoTotalSupervisor.EditValue);
                    objAccidenteCoto.CostoTotalAccidentado = Convert.ToDecimal(txtCostoTotalAccidentado.EditValue);
                    objAccidenteCoto.CostoAdministrativo = Convert.ToDecimal(txtCostoAdministrativo.EditValue);
                    objAccidenteCoto.CostoTraslado = Convert.ToDecimal(txtCostoTraslado.EditValue);
                    objAccidenteCoto.CostoEnfermo = Convert.ToDecimal(txtCostoEnfermo.EditValue);
                    objAccidenteCoto.CostoMaterial = Convert.ToDecimal(txtCostoMaterial.EditValue);
                    objAccidenteCoto.CostoParamedico = Convert.ToDecimal(txtCostoParamedico.EditValue);
                    objAccidenteCoto.CostoDiverso = Convert.ToDecimal(txtCostoDiverso.EditValue);
                    objAccidenteCoto.CostoTotal = Convert.ToDecimal(txtCostoTotal.EditValue);
                    objAccidenteCoto.FlagEstado = true;
                    objAccidenteCoto.Usuario = Parametros.strUsuarioLogin;
                    objAccidenteCoto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objAccidenteCoto.IdEmpresa = Parametros.intEmpresaId;

                    //FOTO
                    List<AccidenteFotoBE> lstAccidenteFoto = new List<AccidenteFotoBE>();

                    foreach (var item in mListaAccidenteFotoOrigen)
                    {
                        AccidenteFotoBE objE_AccidenteFoto = new AccidenteFotoBE();
                        objE_AccidenteFoto.IdEmpresa = Parametros.intEmpresaId;
                        objE_AccidenteFoto.IdAccidente = IdAccidente;
                        objE_AccidenteFoto.IdAccidenteFoto = item.IdAccidenteFoto;
                        objE_AccidenteFoto.Foto = item.Foto;
                        objE_AccidenteFoto.DescripcionFoto = item.DescripcionFoto;
                        objE_AccidenteFoto.FlagEstado = true;
                        objE_AccidenteFoto.Usuario = Parametros.strUsuarioLogin;
                        objE_AccidenteFoto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_AccidenteFoto.TipoOper = item.TipoOper;
                        lstAccidenteFoto.Add(objE_AccidenteFoto);
                    }

                    //ACTO SUB ESTANDAR
                    List<AccidenteActoSubEstandarBE> lstAccidenteActoSubEstandar = new List<AccidenteActoSubEstandarBE>();

                    foreach (var item in mListaAccidenteActoSubEstandarOrigen)
                    {
                        if (item.IdActoSubEstandar != 0)
                        {
                            AccidenteActoSubEstandarBE objE_AccidenteActoSubEstandar = new AccidenteActoSubEstandarBE();
                            objE_AccidenteActoSubEstandar.IdEmpresa = Parametros.intEmpresaId;
                            objE_AccidenteActoSubEstandar.IdAccidente = IdAccidente;
                            objE_AccidenteActoSubEstandar.IdAccidenteActoSubEstandar = item.IdAccidenteActoSubEstandar;
                            objE_AccidenteActoSubEstandar.IdActoSubEstandar = item.IdActoSubEstandar;
                            objE_AccidenteActoSubEstandar.DescActoSubEstandar = item.DescActoSubEstandar;
                            objE_AccidenteActoSubEstandar.FlagEstado = true;
                            objE_AccidenteActoSubEstandar.Usuario = Parametros.strUsuarioLogin;
                            objE_AccidenteActoSubEstandar.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_AccidenteActoSubEstandar.TipoOper = item.TipoOper;
                            lstAccidenteActoSubEstandar.Add(objE_AccidenteActoSubEstandar);
                        }

                    }

                    //CONDICION SUB ESTANDAR
                    List<AccidenteCondicionSubEstandarBE> lstAccidenteCondicionSubEstandar = new List<AccidenteCondicionSubEstandarBE>();

                    foreach (var item in mListaAccidenteCondicionSubEstandarOrigen)
                    {
                        if (item.IdCondicionSubEstandar != 0)
                        {
                            AccidenteCondicionSubEstandarBE objE_AccidenteCondicionSubEstandar = new AccidenteCondicionSubEstandarBE();
                            objE_AccidenteCondicionSubEstandar.IdEmpresa = Parametros.intEmpresaId;
                            objE_AccidenteCondicionSubEstandar.IdAccidente = IdAccidente;
                            objE_AccidenteCondicionSubEstandar.IdAccidenteCondicionSubEstandar = item.IdAccidenteCondicionSubEstandar;
                            objE_AccidenteCondicionSubEstandar.IdCondicionSubEstandar = item.IdCondicionSubEstandar;
                            objE_AccidenteCondicionSubEstandar.DescCondicionSubEstandar = item.DescCondicionSubEstandar;
                            objE_AccidenteCondicionSubEstandar.FlagEstado = true;
                            objE_AccidenteCondicionSubEstandar.Usuario = Parametros.strUsuarioLogin;
                            objE_AccidenteCondicionSubEstandar.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_AccidenteCondicionSubEstandar.TipoOper = item.TipoOper;
                            lstAccidenteCondicionSubEstandar.Add(objE_AccidenteCondicionSubEstandar);
                        }

                    }

                    //FACTOR PERSONAL
                    List<AccidenteFactorPersonalBE> lstAccidenteFactorPersonal = new List<AccidenteFactorPersonalBE>();

                    foreach (var item in mListaAccidenteFactorPersonalOrigen)
                    {
                        if (item.IdFactorPersonal != 0)
                        {
                            AccidenteFactorPersonalBE objE_AccidenteFactorPersonal = new AccidenteFactorPersonalBE();
                            objE_AccidenteFactorPersonal.IdEmpresa = Parametros.intEmpresaId;
                            objE_AccidenteFactorPersonal.IdAccidente = IdAccidente;
                            objE_AccidenteFactorPersonal.IdAccidenteFactorPersonal = item.IdAccidenteFactorPersonal;
                            objE_AccidenteFactorPersonal.IdFactorPersonal = item.IdFactorPersonal;
                            objE_AccidenteFactorPersonal.DescFactorPersonal = item.DescFactorPersonal;
                            objE_AccidenteFactorPersonal.FlagEstado = true;
                            objE_AccidenteFactorPersonal.Usuario = Parametros.strUsuarioLogin;
                            objE_AccidenteFactorPersonal.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_AccidenteFactorPersonal.TipoOper = item.TipoOper;
                            lstAccidenteFactorPersonal.Add(objE_AccidenteFactorPersonal);
                        }

                    }

                    //FACTOR TRABAJO
                    List<AccidenteFactorTrabajoBE> lstAccidenteFactorTrabajo = new List<AccidenteFactorTrabajoBE>();

                    foreach (var item in mListaAccidenteFactorTrabajoOrigen)
                    {
                        if (item.IdFactorTrabajo != 0)
                        {
                            AccidenteFactorTrabajoBE objE_AccidenteFactorTrabajo = new AccidenteFactorTrabajoBE();
                            objE_AccidenteFactorTrabajo.IdEmpresa = Parametros.intEmpresaId;
                            objE_AccidenteFactorTrabajo.IdAccidente = IdAccidente;
                            objE_AccidenteFactorTrabajo.IdAccidenteFactorTrabajo = item.IdAccidenteFactorTrabajo;
                            objE_AccidenteFactorTrabajo.IdFactorTrabajo = item.IdFactorTrabajo;
                            objE_AccidenteFactorTrabajo.DescFactorTrabajo = item.DescFactorTrabajo;
                            objE_AccidenteFactorTrabajo.FlagEstado = true;
                            objE_AccidenteFactorTrabajo.Usuario = Parametros.strUsuarioLogin;
                            objE_AccidenteFactorTrabajo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_AccidenteFactorTrabajo.TipoOper = item.TipoOper;
                            lstAccidenteFactorTrabajo.Add(objE_AccidenteFactorTrabajo);
                        }

                    }

                    //MEDIDA DE PREVENCION
                    List<AccidenteMedidaPrevencionBE> lstAccidenteMedidaPrevencion = new List<AccidenteMedidaPrevencionBE>();

                    foreach (var item in mListaAccidenteMedidaPrevencionOrigen)
                    {
                        if (item.DescMedidaPrevencion.Trim() != "")
                        {
                            AccidenteMedidaPrevencionBE objE_AccidenteMedidaPrevencion = new AccidenteMedidaPrevencionBE();
                            objE_AccidenteMedidaPrevencion.IdEmpresa = Parametros.intEmpresaId;
                            objE_AccidenteMedidaPrevencion.IdAccidente = IdAccidente;
                            objE_AccidenteMedidaPrevencion.IdAccidenteMedidaPrevencion = item.IdAccidenteMedidaPrevencion;
                            objE_AccidenteMedidaPrevencion.DescMedidaPrevencion = item.DescMedidaPrevencion;
                            objE_AccidenteMedidaPrevencion.FlagEstado = true;
                            objE_AccidenteMedidaPrevencion.Usuario = Parametros.strUsuarioLogin;
                            objE_AccidenteMedidaPrevencion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_AccidenteMedidaPrevencion.TipoOper = item.TipoOper;
                            lstAccidenteMedidaPrevencion.Add(objE_AccidenteMedidaPrevencion);
                        }

                    }

                    //ACCION CORRECTIVA
                    List<AccidenteAccionCorrectivaBE> lstAccidenteAccionCorrectiva = new List<AccidenteAccionCorrectivaBE>();

                    foreach (var item in mListaAccidenteAccionCorrectivaOrigen)
                    {
                        if (item.DescAccionCorrectiva.Trim() != "")
                        {
                            AccidenteAccionCorrectivaBE objE_AccidenteAccionCorrectiva = new AccidenteAccionCorrectivaBE();
                            objE_AccidenteAccionCorrectiva.IdEmpresa = Parametros.intEmpresaId;
                            objE_AccidenteAccionCorrectiva.IdAccidente = IdAccidente;
                            objE_AccidenteAccionCorrectiva.IdAccidenteAccionCorrectiva = item.IdAccidenteAccionCorrectiva;
                            objE_AccidenteAccionCorrectiva.DescAccionCorrectiva = item.DescAccionCorrectiva;
                            objE_AccidenteAccionCorrectiva.IdResponsable = item.IdResponsable;
                            objE_AccidenteAccionCorrectiva.FechaCumplimiento = item.FechaCumplimiento;
                            objE_AccidenteAccionCorrectiva.IdSituacion = item.IdSituacion;
                            objE_AccidenteAccionCorrectiva.FlagEstado = true;
                            objE_AccidenteAccionCorrectiva.Usuario = Parametros.strUsuarioLogin;
                            objE_AccidenteAccionCorrectiva.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_AccidenteAccionCorrectiva.TipoOper = item.TipoOper;
                            lstAccidenteAccionCorrectiva.Add(objE_AccidenteAccionCorrectiva);
                        }

                    }

                    //TESTIGO
                    List<AccidenteTestigoBE> lstAccidenteTestigo = new List<AccidenteTestigoBE>();

                    foreach (var item in mListaAccidenteTestigoOrigen)
                    {
                        if (item.IdTestigo != 0)
                        {
                            AccidenteTestigoBE objE_AccidenteTestigo = new AccidenteTestigoBE();
                            objE_AccidenteTestigo.IdEmpresa = Parametros.intEmpresaId;
                            objE_AccidenteTestigo.IdAccidente = IdAccidente;
                            objE_AccidenteTestigo.IdAccidenteTestigo = item.IdAccidenteTestigo;
                            objE_AccidenteTestigo.IdTestigo = item.IdTestigo;
                            objE_AccidenteTestigo.Testigo = item.Testigo;
                            objE_AccidenteTestigo.FlagEstado = true;
                            objE_AccidenteTestigo.Usuario = Parametros.strUsuarioLogin;
                            objE_AccidenteTestigo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_AccidenteTestigo.TipoOper = item.TipoOper;
                            lstAccidenteTestigo.Add(objE_AccidenteTestigo);
                        }

                    }

                    //ENTREVISTADO
                    List<AccidenteEntrevistadoBE> lstAccidenteEntrevistado = new List<AccidenteEntrevistadoBE>();

                    foreach (var item in mListaAccidenteEntrevistadoOrigen)
                    {
                        if (item.IdEntrevistado != 0)
                        {
                            AccidenteEntrevistadoBE objE_AccidenteEntrevistado = new AccidenteEntrevistadoBE();
                            objE_AccidenteEntrevistado.IdEmpresa = Parametros.intEmpresaId;
                            objE_AccidenteEntrevistado.IdAccidente = IdAccidente;
                            objE_AccidenteEntrevistado.IdAccidenteEntrevistado = item.IdAccidenteEntrevistado;
                            objE_AccidenteEntrevistado.IdEntrevistado = item.IdEntrevistado;
                            objE_AccidenteEntrevistado.Entrevistado = item.Entrevistado;
                            objE_AccidenteEntrevistado.FlagEstado = true;
                            objE_AccidenteEntrevistado.Usuario = Parametros.strUsuarioLogin;
                            objE_AccidenteEntrevistado.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_AccidenteEntrevistado.TipoOper = item.TipoOper;
                            lstAccidenteEntrevistado.Add(objE_AccidenteEntrevistado);
                        }

                    }

                    //DOCUMENTO
                    List<AccidenteDocumentoBE> lstAccidenteDocumento = new List<AccidenteDocumentoBE>();

                    foreach (var item in mListaAccidenteDocumentoOrigen)
                    {
                        AccidenteDocumentoBE objE_AccidenteDocumento = new AccidenteDocumentoBE();
                        objE_AccidenteDocumento.IdEmpresa = Parametros.intEmpresaId;
                        objE_AccidenteDocumento.IdAccidente = IdAccidente;
                        objE_AccidenteDocumento.IdAccidenteDocumento = item.IdAccidenteDocumento;
                        objE_AccidenteDocumento.Foto = item.Foto;
                        objE_AccidenteDocumento.DescripcionDocumento = item.DescripcionDocumento;
                        objE_AccidenteDocumento.FlagEstado = true;
                        objE_AccidenteDocumento.Usuario = Parametros.strUsuarioLogin;
                        objE_AccidenteDocumento.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_AccidenteDocumento.TipoOper = item.TipoOper;
                        lstAccidenteDocumento.Add(objE_AccidenteDocumento);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        int intNumero = 0;
                        string strNumero = "";
                        intNumero = objBL_Accidente.Inserta(objAccidente, objAccidenteCoto, lstAccidenteFoto, lstAccidenteActoSubEstandar, lstAccidenteCondicionSubEstandar, lstAccidenteFactorPersonal, lstAccidenteFactorTrabajo, lstAccidenteMedidaPrevencion, lstAccidenteAccionCorrectiva, lstAccidenteTestigo, lstAccidenteEntrevistado, lstAccidenteDocumento);
                        strNumero = FuncionBase.AgregarCaracter(intNumero.ToString(), "0", 7);
                        txtNumero.Text = strNumero;

                        //ActualizaNumero
                        AccidenteBL objBAccidente = new AccidenteBL();
                        objBAccidente.ActualizaNumero(intNumero, txtNumero.Text);

                        //GENERAR EL REPORTE EN EXCEL
                        BSUtils.ExportarFormatoExcel("", intNumero, Convert.ToInt32(cboTipo.EditValue), true);

                        StringBuilder strMensaje = new StringBuilder();
                        strMensaje.Append("***********************************************************************************************************************\n\n");
                        if (Convert.ToInt32(cboDanio.EditValue) == Parametros.intDACTrabajador)
                        {
                            strMensaje.Append("Se Generó el Registro de " + cboTipo.Text + " de Trabajo N°: " + strNumero + "  " + txtResponsable.Text + "\n\n");
                            strMensaje.Append("Razón Social : " + cboEmpresa.Text + "\n\n");
                            strMensaje.Append("Sede         : " + cboUnidadMinera.Text + "\n\n");
                            strMensaje.Append("Tipo         : " + cboTipoAccidente.Text + "\n\n");
                            strMensaje.Append("Regularizar las acciones correctivas y/o preventivas de acuerdo a las fechas descritas en el archivo adjunto" + "\n\n");
                        }
                        else
                        {
                            strMensaje.Append("Se Generó el Registro de " + cboTipo.Text + " de Trabajo N°: " + strNumero + "  " + txtTipoMaterial.Text + "\n\n");
                            strMensaje.Append("Razón Social : " + cboEmpresa.Text + "\n\n");
                            strMensaje.Append("Sede         : " + cboUnidadMinera.Text + "\n\n");
                            strMensaje.Append("Tipo         : " + cboTipoAccidente.Text + "\n\n");
                            strMensaje.Append("Regularizar las acciones correctivas y/o preventivas de acuerdo a las fechas descritas en el archivo adjunto" + "\n\n");
                        }


                        string strMailTO = "";

                        if (Convert.ToInt32(cboDanio.EditValue) == Parametros.intDACTrabajador)
                            strMailTO = strMailInvestigado + ";" + strMailRevisado + ";" + strMailJefeDirecto;
                        else
                            strMailTO = strMailInvestigado + ";" + strMailRevisado + ";" + strMailResponsableArea;


                        foreach (var item in mListaAccidenteAccionCorrectivaOrigen)
                        {
                            PersonaBE objE_Persona = new PersonaBE();
                            objE_Persona = new PersonaBL().Selecciona(0, 0, 0, item.IdResponsable);
                            if (objE_Persona != null)
                            {
                                strMailTO = strMailTO + ";" + objE_Persona.Email;
                                strMensaje.Append(item.DescAccionCorrectiva.Trim() + "  " + item.Responsable + "  " + item.FechaCumplimiento.ToString().Substring(0, 10) + "\n");
                            }
                        }

                        if (Convert.ToInt32(cboEmpresaContratista.EditValue) != Parametros.intEmpresaContratistaNinguno)
                        {
                            ActividadContratistaBE objE_ActividadContratista = new ActividadContratistaBE();
                            objE_ActividadContratista = new ActividadContratistaBL().SeleccionaEmpresa(Convert.ToInt32(cboEmpresaContratista.EditValue));
                            if (objE_ActividadContratista != null)
                            {
                                strMailTO = strMailTO + ";" + objE_ActividadContratista.EmailContratista;
                            }
                        }


                        strMensaje.Append(" " + "\n");
                        strMensaje.Append("Emitido Por el Area de Seguridad y Salud en el Trabajo" + "\n\n");
                        strMensaje.Append("***********************************************************************************************************************\n\n");


                        BSUtils.EmailSend(strMailTO, cboTipo.Text + " DE TRABAJO", strMensaje.ToString(), @"D:\" + cboTipo.Text + " " + strNumero + ".xlsx", "", "", "");

                        XtraMessageBox.Show("Se creó el " + cboTipo.Text + " N° : " + txtNumero.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {

                        objBL_Accidente.Actualiza(objAccidente, objAccidenteCoto, lstAccidenteFoto, lstAccidenteActoSubEstandar, lstAccidenteCondicionSubEstandar, lstAccidenteFactorPersonal, lstAccidenteFactorTrabajo, lstAccidenteMedidaPrevencion, lstAccidenteAccionCorrectiva, lstAccidenteTestigo, lstAccidenteEntrevistado, lstAccidenteDocumento);
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

        private void txtDiasPerdidoHospital_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtDiasPerdidoHospital.Value) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtCostoDia_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCostoDia.EditValue) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtHorasExtra_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtHorasExtra.Value) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtCostoHorasExtra_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCostoHorasExtra.EditValue) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtCostoEnergia_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCostoEnergia.EditValue) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtTiempoTrabajado_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtTiempoTrabajado.Value) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtSalario_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtSalario.EditValue) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtReadaptacionTrabajo_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtReadaptacionTrabajo.EditValue) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtReingresoAccidentado_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtReingresoAccidentado.EditValue) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtParalizacionMaquina_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtParalizacionMaquina.EditValue) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtManoObra_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtManoObra.EditValue) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtRepuestos_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtRepuestos.EditValue) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtTiempoPerdidoTotal_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtTiempoPerdidoTotal.Value) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtNumeroTrabajadores_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtNumeroTrabajadores.Value) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtSalarioPromedio_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtSalarioPromedio.EditValue) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtTiempoPerdidoSupervisor_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtTiempoPerdidoSupervisor.Value) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtCostoHoraSupervisor_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCostoHoraSupervisor.EditValue) > 0)
            {
                CalculaCostoAccidente();
            }
        }


        private void txtCostoAdministrativo_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCostoAdministrativo.EditValue) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtCostoTraslado_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCostoTraslado.EditValue) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtCostoEnfermo_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCostoEnfermo.EditValue) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtCostoMaterial_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCostoMaterial.EditValue) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtCostoParamedico_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCostoParamedico.EditValue) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        private void txtCostoDiverso_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCostoDiverso.EditValue) > 0)
            {
                CalculaCostoAccidente();
            }
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (Convert.ToInt32(cboDanio.EditValue) == Parametros.intDACTrabajador)
            {
                if (intIdResponsable == 0)
                {
                    strMensaje = strMensaje + "- Debe Seleccionar al Responsable del Accidente.\n";
                    flag = true;
                }

                if (intIdJefeDirecto == 0)
                {
                    strMensaje = strMensaje + "- Debe Seleccionar al Jefe Directo.\n";
                    flag = true;
                }
            }

            if (Convert.ToInt32(cboDanio.EditValue) == Parametros.intDACTMaterial)
            {
                if (txtTipoMaterial.Text == "")
                {
                    strMensaje = strMensaje + "- Debe Ingresar el Tipo de Material.\n";
                    flag = true;
                }

                if (intIdResponsableArea == 0)
                {
                    strMensaje = strMensaje + "- Debe Seleccionar al Responsable del Area.\n";
                    flag = true;
                }
            }

            if (intIdInvestigadoPor == 0)
            {
                strMensaje = strMensaje + "- Debe Seleccionar al Investigador del Accidente.\n";
                flag = true;
            }

            if (intIdRevisadoPor == 0)
            {
                strMensaje = strMensaje + "- Debe Seleccionar al Revisor del Accidente.\n";
                flag = true;
            }


            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CargaAccidenteFoto()
        {
            List<AccidenteFotoBE> lstTmpAccidenteFoto = null;
            lstTmpAccidenteFoto = new AccidenteFotoBL().ListaTodosActivo(IdAccidente);

            foreach (AccidenteFotoBE item in lstTmpAccidenteFoto)
            {
                CAccidenteFoto objE_AccidenteFoto = new CAccidenteFoto();
                objE_AccidenteFoto.IdEmpresa = item.IdEmpresa;
                objE_AccidenteFoto.IdAccidente = item.IdAccidente;
                objE_AccidenteFoto.IdAccidenteFoto = item.IdAccidenteFoto;
                objE_AccidenteFoto.Foto = item.Foto;
                objE_AccidenteFoto.DescripcionFoto = item.DescripcionFoto;
                objE_AccidenteFoto.TipoOper = item.TipoOper;
                mListaAccidenteFotoOrigen.Add(objE_AccidenteFoto);
            }

            bsListadoFoto.DataSource = mListaAccidenteFotoOrigen;
            gcAccidenteFoto.DataSource = bsListadoFoto;
            gcAccidenteFoto.RefreshDataSource();
        }

        private void CargaAccidenteActoSubEstandar()
        {
            List<AccidenteActoSubEstandarBE> lstTmpAccidenteActoSubEstandar = null;
            lstTmpAccidenteActoSubEstandar = new AccidenteActoSubEstandarBL().ListaTodosActivo(IdAccidente);

            foreach (AccidenteActoSubEstandarBE item in lstTmpAccidenteActoSubEstandar)
            {
                CAccidenteActoSubEstandar objE_AccidenteActoSubEstandar = new CAccidenteActoSubEstandar();
                objE_AccidenteActoSubEstandar.IdEmpresa = item.IdEmpresa;
                objE_AccidenteActoSubEstandar.IdAccidente = item.IdAccidente;
                objE_AccidenteActoSubEstandar.IdAccidenteActoSubEstandar = item.IdAccidenteActoSubEstandar;
                objE_AccidenteActoSubEstandar.IdActoSubEstandar = item.IdActoSubEstandar;
                objE_AccidenteActoSubEstandar.DescActoSubEstandar = item.DescActoSubEstandar;
                objE_AccidenteActoSubEstandar.TipoOper = item.TipoOper;
                mListaAccidenteActoSubEstandarOrigen.Add(objE_AccidenteActoSubEstandar);
            }

            bsListadoActoSubEstandar.DataSource = mListaAccidenteActoSubEstandarOrigen;
            gcAccidenteActoSubEstandar.DataSource = bsListadoActoSubEstandar;
            gcAccidenteActoSubEstandar.RefreshDataSource();
        }

        private void CargaAccidenteCondicionSubEstandar()
        {
            List<AccidenteCondicionSubEstandarBE> lstTmpAccidenteCondicionSubEstandar = null;
            lstTmpAccidenteCondicionSubEstandar = new AccidenteCondicionSubEstandarBL().ListaTodosActivo(IdAccidente);

            foreach (AccidenteCondicionSubEstandarBE item in lstTmpAccidenteCondicionSubEstandar)
            {
                CAccidenteCondicionSubEstandar objE_AccidenteCondicionSubEstandar = new CAccidenteCondicionSubEstandar();
                objE_AccidenteCondicionSubEstandar.IdEmpresa = item.IdEmpresa;
                objE_AccidenteCondicionSubEstandar.IdAccidente = item.IdAccidente;
                objE_AccidenteCondicionSubEstandar.IdAccidenteCondicionSubEstandar = item.IdAccidenteCondicionSubEstandar;
                objE_AccidenteCondicionSubEstandar.IdCondicionSubEstandar = item.IdCondicionSubEstandar;
                objE_AccidenteCondicionSubEstandar.DescCondicionSubEstandar = item.DescCondicionSubEstandar;
                objE_AccidenteCondicionSubEstandar.TipoOper = item.TipoOper;
                mListaAccidenteCondicionSubEstandarOrigen.Add(objE_AccidenteCondicionSubEstandar);
            }

            bsListadoCondicionSubEstandar.DataSource = mListaAccidenteCondicionSubEstandarOrigen;
            gcAccidenteCondicionSubEstandar.DataSource = bsListadoCondicionSubEstandar;
            gcAccidenteCondicionSubEstandar.RefreshDataSource();
        }

        private void CargaAccidenteFactorPersonal()
        {
            List<AccidenteFactorPersonalBE> lstTmpAccidenteFactorPersonal = null;
            lstTmpAccidenteFactorPersonal = new AccidenteFactorPersonalBL().ListaTodosActivo(IdAccidente);

            foreach (AccidenteFactorPersonalBE item in lstTmpAccidenteFactorPersonal)
            {
                CAccidenteFactorPersonal objE_AccidenteFactorPersonal = new CAccidenteFactorPersonal();
                objE_AccidenteFactorPersonal.IdEmpresa = item.IdEmpresa;
                objE_AccidenteFactorPersonal.IdAccidente = item.IdAccidente;
                objE_AccidenteFactorPersonal.IdAccidenteFactorPersonal = item.IdAccidenteFactorPersonal;
                objE_AccidenteFactorPersonal.IdFactorPersonal = item.IdFactorPersonal;
                objE_AccidenteFactorPersonal.DescFactorPersonal = item.DescFactorPersonal;
                objE_AccidenteFactorPersonal.TipoOper = item.TipoOper;
                mListaAccidenteFactorPersonalOrigen.Add(objE_AccidenteFactorPersonal);
            }

            bsListadoFactorPersonal.DataSource = mListaAccidenteFactorPersonalOrigen;
            gcAccidenteFactorPersonal.DataSource = bsListadoFactorPersonal;
            gcAccidenteFactorPersonal.RefreshDataSource();
        }

        private void CargaAccidenteFactorTrabajo()
        {
            List<AccidenteFactorTrabajoBE> lstTmpAccidenteFactorTrabajo = null;
            lstTmpAccidenteFactorTrabajo = new AccidenteFactorTrabajoBL().ListaTodosActivo(IdAccidente);

            foreach (AccidenteFactorTrabajoBE item in lstTmpAccidenteFactorTrabajo)
            {
                CAccidenteFactorTrabajo objE_AccidenteFactorTrabajo = new CAccidenteFactorTrabajo();
                objE_AccidenteFactorTrabajo.IdEmpresa = item.IdEmpresa;
                objE_AccidenteFactorTrabajo.IdAccidente = item.IdAccidente;
                objE_AccidenteFactorTrabajo.IdAccidenteFactorTrabajo = item.IdAccidenteFactorTrabajo;
                objE_AccidenteFactorTrabajo.IdFactorTrabajo = item.IdFactorTrabajo;
                objE_AccidenteFactorTrabajo.DescFactorTrabajo = item.DescFactorTrabajo;
                objE_AccidenteFactorTrabajo.TipoOper = item.TipoOper;
                mListaAccidenteFactorTrabajoOrigen.Add(objE_AccidenteFactorTrabajo);
            }

            bsListadoFactorTrabajo.DataSource = mListaAccidenteFactorTrabajoOrigen;
            gcAccidenteFactorTrabajo.DataSource = bsListadoFactorTrabajo;
            gcAccidenteFactorTrabajo.RefreshDataSource();
        }

        private void CargaAccidenteMedidaPrevencion()
        {
            List<AccidenteMedidaPrevencionBE> lstTmpAccidenteMedidaPrevencion = null;
            lstTmpAccidenteMedidaPrevencion = new AccidenteMedidaPrevencionBL().ListaTodosActivo(IdAccidente);

            foreach (AccidenteMedidaPrevencionBE item in lstTmpAccidenteMedidaPrevencion)
            {
                CAccidenteMedidaPrevencion objE_AccidenteMedidaPrevencion = new CAccidenteMedidaPrevencion();
                objE_AccidenteMedidaPrevencion.IdEmpresa = item.IdEmpresa;
                objE_AccidenteMedidaPrevencion.IdAccidente = item.IdAccidente;
                objE_AccidenteMedidaPrevencion.IdAccidenteMedidaPrevencion = item.IdAccidenteMedidaPrevencion;
                objE_AccidenteMedidaPrevencion.DescMedidaPrevencion = item.DescMedidaPrevencion;
                objE_AccidenteMedidaPrevencion.TipoOper = item.TipoOper;
                mListaAccidenteMedidaPrevencionOrigen.Add(objE_AccidenteMedidaPrevencion);
            }

            bsListadoMedidaPrevencion.DataSource = mListaAccidenteMedidaPrevencionOrigen;
            gcAccidenteMedidaPrevencion.DataSource = bsListadoMedidaPrevencion;
            gcAccidenteMedidaPrevencion.RefreshDataSource();
        }

        private void CargaAccidenteAccionCorrectiva()
        {
            List<AccidenteAccionCorrectivaBE> lstTmpAccidenteAccionCorrectiva = null;
            lstTmpAccidenteAccionCorrectiva = new AccidenteAccionCorrectivaBL().ListaTodosActivo(IdAccidente);

            mListaAccidenteAccionCorrectivaOrigen.Clear();

            foreach (AccidenteAccionCorrectivaBE item in lstTmpAccidenteAccionCorrectiva)
            {
                CAccidenteAccionCorrectiva objE_AccidenteAccionCorrectiva = new CAccidenteAccionCorrectiva();
                objE_AccidenteAccionCorrectiva.IdEmpresa = item.IdEmpresa;
                objE_AccidenteAccionCorrectiva.IdAccidente = item.IdAccidente;
                objE_AccidenteAccionCorrectiva.IdAccidenteAccionCorrectiva = item.IdAccidenteAccionCorrectiva;
                objE_AccidenteAccionCorrectiva.DescAccionCorrectiva = item.DescAccionCorrectiva;
                objE_AccidenteAccionCorrectiva.IdResponsable = item.IdResponsable;
                objE_AccidenteAccionCorrectiva.Responsable = item.Responsable;
                objE_AccidenteAccionCorrectiva.FechaCumplimiento = item.FechaCumplimiento;
                objE_AccidenteAccionCorrectiva.IdSituacion = item.IdSituacion;
                objE_AccidenteAccionCorrectiva.DescSituacion = item.DescSituacion;
                objE_AccidenteAccionCorrectiva.TipoOper = item.TipoOper;
                mListaAccidenteAccionCorrectivaOrigen.Add(objE_AccidenteAccionCorrectiva);
            }

            bsListadoAccionCorrectiva.DataSource = mListaAccidenteAccionCorrectivaOrigen;
            gcAccidenteAccionCorrectiva.DataSource = bsListadoAccionCorrectiva;
            gcAccidenteAccionCorrectiva.RefreshDataSource();
        }

        private void CargaAccidenteTestigo()
        {
            List<AccidenteTestigoBE> lstTmpAccidenteTestigo = null;
            lstTmpAccidenteTestigo = new AccidenteTestigoBL().ListaTodosActivo(IdAccidente);

            foreach (AccidenteTestigoBE item in lstTmpAccidenteTestigo)
            {
                CAccidenteTestigo objE_AccidenteTestigo = new CAccidenteTestigo();
                objE_AccidenteTestigo.IdEmpresa = item.IdEmpresa;
                objE_AccidenteTestigo.IdAccidente = item.IdAccidente;
                objE_AccidenteTestigo.IdAccidenteTestigo = item.IdAccidenteTestigo;
                objE_AccidenteTestigo.IdTestigo = item.IdTestigo;
                objE_AccidenteTestigo.Testigo = item.Testigo;
                objE_AccidenteTestigo.TipoOper = item.TipoOper;
                mListaAccidenteTestigoOrigen.Add(objE_AccidenteTestigo);
            }

            bsListadoTestigo.DataSource = mListaAccidenteTestigoOrigen;
            gcAccidenteTestigo.DataSource = bsListadoTestigo;
            gcAccidenteTestigo.RefreshDataSource();
        }

        private void CargaAccidenteEntrevistado()
        {
            List<AccidenteEntrevistadoBE> lstTmpAccidenteEntrevistado = null;
            lstTmpAccidenteEntrevistado = new AccidenteEntrevistadoBL().ListaTodosActivo(IdAccidente);

            foreach (AccidenteEntrevistadoBE item in lstTmpAccidenteEntrevistado)
            {
                CAccidenteEntrevistado objE_AccidenteEntrevistado = new CAccidenteEntrevistado();
                objE_AccidenteEntrevistado.IdEmpresa = item.IdEmpresa;
                objE_AccidenteEntrevistado.IdAccidente = item.IdAccidente;
                objE_AccidenteEntrevistado.IdAccidenteEntrevistado = item.IdAccidenteEntrevistado;
                objE_AccidenteEntrevistado.IdEntrevistado = item.IdEntrevistado;
                objE_AccidenteEntrevistado.Entrevistado = item.Entrevistado;
                objE_AccidenteEntrevistado.TipoOper = item.TipoOper;
                mListaAccidenteEntrevistadoOrigen.Add(objE_AccidenteEntrevistado);
            }

            bsListadoEntrevistado.DataSource = mListaAccidenteEntrevistadoOrigen;
            gcAccidenteEntrevistado.DataSource = bsListadoEntrevistado;
            gcAccidenteEntrevistado.RefreshDataSource();
        }

        private void CargaAccidenteDocumento()
        {
            List<AccidenteDocumentoBE> lstTmpAccidenteDocumento = null;
            lstTmpAccidenteDocumento = new AccidenteDocumentoBL().ListaTodosActivo(IdAccidente);

            foreach (AccidenteDocumentoBE item in lstTmpAccidenteDocumento)
            {
                CAccidenteDocumento objE_AccidenteDocumento = new CAccidenteDocumento();
                objE_AccidenteDocumento.IdEmpresa = item.IdEmpresa;
                objE_AccidenteDocumento.IdAccidente = item.IdAccidente;
                objE_AccidenteDocumento.IdAccidenteDocumento = item.IdAccidenteDocumento;
                objE_AccidenteDocumento.Foto = item.Foto;
                objE_AccidenteDocumento.DescripcionDocumento = item.DescripcionDocumento;
                objE_AccidenteDocumento.TipoOper = item.TipoOper;
                mListaAccidenteDocumentoOrigen.Add(objE_AccidenteDocumento);
            }

            bsListadoDocumento.DataSource = mListaAccidenteDocumentoOrigen;
            gcAccidenteDocumento.DataSource = bsListadoDocumento;
            gcAccidenteDocumento.RefreshDataSource();
        }

        private void CalculaCostoAccidente()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                Int32 intDiasPerdido = 0;
                Decimal decCostoDia = 0;
                Decimal decTotalCostoDia = 0;
                Int32 intHorasExtra = 0;
                Decimal decCostoHorasExtra = 0;
                Decimal decTotalCostoHorasExtra = 0;
                Decimal decCostoEnergia = 0;
                Int32 intTiempoTrabajado = 0;
                Decimal decSalario = 0;
                Decimal decSubTotalReemplazo = 0;
                Decimal decReadaptacionTrabajo = 0;
                Decimal decReingresoAccidentado = 0;
                Decimal decParalizacionMaquina = 0;
                Decimal decManoObra = 0;
                Decimal decRepuestos = 0;
                Decimal decTiempoPerdidoTotal = 0;
                Int32 intNumeroTrabajadores = 0;
                Decimal decSalarioPromedio = 0;
                Decimal decSubTotalSalario = 0;
                Int32 intTiempoPerdidoSupervisor = 0;
                Decimal decCostoHoraSupervisor = 0;
                Decimal decCostoTotalSupervisor = 0;
                Decimal decCostoTotalAccidentado = 0;
                Decimal decCostoAdministrativo = 0;
                Decimal decCostoTraslado = 0;
                Decimal decCostoEnfermo = 0;
                Decimal decCostoMaterial = 0;
                Decimal decCostoParamedico = 0;
                Decimal decCostoDiverso = 0;
                Decimal decCostoTotal = 0;

                intDiasPerdido = Convert.ToInt32(txtDiasPerdidoHospital.Value);
                decCostoDia = Convert.ToDecimal(txtCostoDia.EditValue);
                decTotalCostoDia = intDiasPerdido * decCostoDia;
                txtTotalCostoDia.EditValue = decTotalCostoDia;

                intHorasExtra = Convert.ToInt32(txtHorasExtra.Value);
                decCostoHorasExtra = Convert.ToDecimal(txtCostoHorasExtra.EditValue);
                decTotalCostoHorasExtra = intHorasExtra * decCostoHorasExtra;
                txtTotalCostoHorasExtra.EditValue = decTotalCostoHorasExtra;

                decCostoEnergia = Convert.ToDecimal(txtCostoEnergia.EditValue);

                intTiempoTrabajado = Convert.ToInt32(txtTiempoTrabajado.Value);
                decSalario = Convert.ToDecimal(txtSalario.EditValue);
                decSubTotalReemplazo = intTiempoTrabajado * decSalario;
                txtSubTotalReemplazo.EditValue = decSubTotalReemplazo;

                decReadaptacionTrabajo = Convert.ToDecimal(txtReadaptacionTrabajo.EditValue);
                decReingresoAccidentado = Convert.ToDecimal(txtReingresoAccidentado.EditValue);
                decParalizacionMaquina = Convert.ToDecimal(txtParalizacionMaquina.EditValue);

                decManoObra = Convert.ToDecimal(txtManoObra.EditValue);
                decRepuestos = Convert.ToDecimal(txtRepuestos.EditValue);

                decTiempoPerdidoTotal = Convert.ToDecimal(txtTiempoPerdidoTotal.Value);
                intNumeroTrabajadores = Convert.ToInt32(txtNumeroTrabajadores.Value);
                decSalarioPromedio = Convert.ToDecimal(txtSalarioPromedio.EditValue);
                decSubTotalSalario = decTiempoPerdidoTotal * intNumeroTrabajadores * decSalarioPromedio;
                txtSubTotalSalario.EditValue = decSubTotalSalario;

                intTiempoPerdidoSupervisor = Convert.ToInt32(txtTiempoPerdidoSupervisor.Value);
                decCostoHoraSupervisor = Convert.ToDecimal(txtCostoHoraSupervisor.EditValue);
                decCostoTotalSupervisor = intTiempoPerdidoSupervisor * decCostoHoraSupervisor;
                txtCostoTotalSupervisor.EditValue = decCostoTotalSupervisor;

                decCostoTotalAccidentado = decTotalCostoDia + decTotalCostoHorasExtra + decCostoEnergia + decSubTotalReemplazo + decReadaptacionTrabajo + decReingresoAccidentado + decParalizacionMaquina + decManoObra + decRepuestos + decSubTotalSalario + decCostoTotalSupervisor;
                txtCostoTotalAccidentado.EditValue = decCostoTotalAccidentado;

                decCostoAdministrativo = Convert.ToDecimal(txtCostoAdministrativo.EditValue);
                decCostoTraslado = Convert.ToDecimal(txtCostoTraslado.EditValue);
                decCostoEnfermo = Convert.ToDecimal(txtCostoEnfermo.EditValue);
                decCostoMaterial = Convert.ToDecimal(txtCostoMaterial.EditValue);
                decCostoParamedico = Convert.ToDecimal(txtCostoParamedico.EditValue);
                decCostoDiverso = Convert.ToDecimal(txtCostoDiverso.EditValue);

                decCostoTotal = decCostoTotalAccidentado + decCostoAdministrativo + decCostoTraslado + decCostoEnfermo + decCostoMaterial + decCostoParamedico + decCostoDiverso;
                txtCostoTotal.EditValue = decCostoTotal;


                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool GetDateFormat(DateTime startDate, DateTime endDate, out string mensaje)
        {

            bool status = false;
            /*Valida fecha*/
            if (startDate.Date <= endDate.Date)
            {
                status = true;
                TimeSpan difference = endDate.Subtract(startDate.Date);

                StringBuilder sb = new StringBuilder();

                if (difference.Ticks == 0)
                {
                    sb.Append("0 días");
                }
                else if (difference.Ticks > 0)
                {
                    // This is to convert the timespan to datetime object
                    DateTime totalDate = DateTime.MinValue + difference;

                    int differenceInYears = totalDate.Year - 1;
                    int differenceInMonths = totalDate.Month - 1;
                    int differenceInDays = totalDate.Day - 1;

                    if (differenceInYears > 0)
                        sb.AppendFormat("{0} año(s)", differenceInYears);

                    if (differenceInMonths > 0)
                        if (differenceInMonths == 1)
                            sb.AppendFormat(" {0} mes", differenceInMonths);
                        else
                            sb.AppendFormat(" {0} meses", differenceInMonths);

                    if (differenceInDays > 0)
                        if (differenceInDays == 1)
                            sb.AppendFormat(" {0} día", differenceInDays);
                        else
                            sb.AppendFormat(" {0} días", differenceInDays);
                }

                mensaje = sb.ToString();
            }
            else
            {
                mensaje = "Error";
            }
            return status;

        }

        #endregion

        public class CAccidenteFoto
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdAccidente { get; set; }
            public Int32 IdAccidenteFoto { get; set; }
            public byte[] Foto { get; set; }
            public string DescripcionFoto { get; set; }
            public Int32 TipoOper { get; set; }

            public CAccidenteFoto()
            {

            }
        }

        public class CAccidenteActoSubEstandar
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdAccidente { get; set; }
            public Int32 IdAccidenteActoSubEstandar { get; set; }
            public Int32 IdActoSubEstandar { get; set; }
            public string DescActoSubEstandar { get; set; }
            public Int32 TipoOper { get; set; }

            public CAccidenteActoSubEstandar()
            {

            }
        }

        public class CAccidenteCondicionSubEstandar
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdAccidente { get; set; }
            public Int32 IdAccidenteCondicionSubEstandar { get; set; }
            public Int32 IdCondicionSubEstandar { get; set; }
            public string DescCondicionSubEstandar { get; set; }
            public Int32 TipoOper { get; set; }

            public CAccidenteCondicionSubEstandar()
            {

            }
        }

        public class CAccidenteFactorPersonal
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdAccidente { get; set; }
            public Int32 IdAccidenteFactorPersonal { get; set; }
            public Int32 IdFactorPersonal { get; set; }
            public string DescFactorPersonal { get; set; }
            public Int32 TipoOper { get; set; }

            public CAccidenteFactorPersonal()
            {

            }
        }

        public class CAccidenteFactorTrabajo
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdAccidente { get; set; }
            public Int32 IdAccidenteFactorTrabajo { get; set; }
            public Int32 IdFactorTrabajo { get; set; }
            public string DescFactorTrabajo { get; set; }
            public Int32 TipoOper { get; set; }

            public CAccidenteFactorTrabajo()
            {

            }
        }

        public class CAccidenteMedidaPrevencion
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdAccidente { get; set; }
            public Int32 IdAccidenteMedidaPrevencion { get; set; }
            public string DescMedidaPrevencion { get; set; }
            public Int32 TipoOper { get; set; }

            public CAccidenteMedidaPrevencion()
            {

            }
        }

        public class CAccidenteAccionCorrectiva
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdAccidente { get; set; }
            public Int32 IdAccidenteAccionCorrectiva { get; set; }
            public string DescAccionCorrectiva { get; set; }
            public Int32 IdResponsable { get; set; }
            public string Responsable { get; set; }
            public DateTime FechaCumplimiento { get; set; }
            public Int32 IdSituacion { get; set; }
            public string DescSituacion { get; set; }
            public Int32 TipoOper { get; set; }

            public CAccidenteAccionCorrectiva()
            {

            }
        }

        public class CAccidenteTestigo
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdAccidente { get; set; }
            public Int32 IdAccidenteTestigo { get; set; }
            public Int32 IdTestigo { get; set; }
            public string Testigo { get; set; }
            public Int32 TipoOper { get; set; }

            public CAccidenteTestigo()
            {

            }
        }

        public class CAccidenteEntrevistado
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdAccidente { get; set; }
            public Int32 IdAccidenteEntrevistado { get; set; }
            public Int32 IdEntrevistado { get; set; }
            public string Entrevistado { get; set; }
            public Int32 TipoOper { get; set; }

            public CAccidenteEntrevistado()
            {

            }
        }

        public class CAccidenteDocumento
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdAccidente { get; set; }
            public Int32 IdAccidenteDocumento { get; set; }
            public byte[] Foto { get; set; }
            public string DescripcionDocumento { get; set; }
            public Int32 TipoOper { get; set; }

            public CAccidenteDocumento()
            {

            }
        }

        
    }
}