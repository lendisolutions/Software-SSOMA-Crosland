using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Modulos.Inspeccion.Rpt;

namespace SSOMA.Presentacion.Modulos.Inspeccion.Registros
{
    public partial class frmRegInspeccionTrabajo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<InspeccionTrabajoBE> mLista = new List<InspeccionTrabajoBE>();

        #endregion

        #region "Eventos"

        public frmRegInspeccionTrabajo()
        {
            InitializeComponent();
        }

        private void frmRegInspeccionTrabajo_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            deFechaDesde.EditValue = DateTime.Now.AddDays(-30);
            deFechaHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegInspeccionTrabajoEdit objManInspeccionTrabajo = new frmRegInspeccionTrabajoEdit();
                objManInspeccionTrabajo.lstInspeccionTrabajo = mLista;
                objManInspeccionTrabajo.pOperacion = frmRegInspeccionTrabajoEdit.Operacion.Nuevo;
                objManInspeccionTrabajo.IdInspeccionTrabajo = 0;
                objManInspeccionTrabajo.StartPosition = FormStartPosition.CenterParent;
                objManInspeccionTrabajo.ShowDialog();
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
                        InspeccionTrabajoBE objE_InspeccionTrabajo = new InspeccionTrabajoBE();
                        objE_InspeccionTrabajo.IdInspeccionTrabajo = int.Parse(gvInspeccionTrabajo.GetFocusedRowCellValue("IdInspeccionTrabajo").ToString());
                        objE_InspeccionTrabajo.Usuario = Parametros.strUsuarioLogin;
                        objE_InspeccionTrabajo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_InspeccionTrabajo.IdEmpresa = Parametros.intEmpresaId;

                        InspeccionTrabajoBL objBL_InspeccionTrabajo = new InspeccionTrabajoBL();
                        objBL_InspeccionTrabajo.Elimina(objE_InspeccionTrabajo);
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

                if (gvInspeccionTrabajo.RowCount > 0)
                {
                    int IdInspeccionTrabajo = 0;
                    IdInspeccionTrabajo = int.Parse(gvInspeccionTrabajo.GetFocusedRowCellValue("IdInspeccionTrabajo").ToString());
                    List<ReporteInspeccionTrabajoBE> lstReporte = null;

                    lstReporte = new ReporteInspeccionTrabajoBL().Listado(IdInspeccionTrabajo);

                    if (lstReporte != null)
                    {
                        RptVistaReportes objRptAccUsu = new RptVistaReportes();
                        objRptAccUsu.VerRptInspeccionTrabajo(lstReporte);
                        objRptAccUsu.ShowDialog();
                    }
                    else
                    { 
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                Cursor = Cursors.Default;

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
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoInspeccionTrabajos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvInspeccionTrabajo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvInspeccionTrabajo_DoubleClick(object sender, EventArgs e)
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

        private void enviarFotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                string strMailTO = "";
                string strNumero = "";

                int intIdInspeccionTrabajo = 0;
                intIdInspeccionTrabajo = int.Parse(gvInspeccionTrabajo.GetFocusedRowCellValue("IdInspeccionTrabajo").ToString());
                strNumero = gvInspeccionTrabajo.GetFocusedRowCellValue("Numero").ToString();

                InspeccionTrabajoBE objE_InspeccionTrabajo = null;
                objE_InspeccionTrabajo = new InspeccionTrabajoBL().Selecciona(intIdInspeccionTrabajo);
                if (objE_InspeccionTrabajo != null)
                {
                    strMailTO = objE_InspeccionTrabajo.MailSectorResponsable;
                }

                //TRAEMOS LOS CORREOS DE LOS RESONSABLES DE LAS ACCIONES CORRECTIVAS PENDIENTES
                List<InspeccionTrabajoDetalleBE> lstInspeccionTrabajoDetalle = null;
                lstInspeccionTrabajoDetalle = new InspeccionTrabajoDetalleBL().ListaSituacion(intIdInspeccionTrabajo, Parametros.intDITPendiente);
                if (lstInspeccionTrabajoDetalle.Count == 0)
                {
                    XtraMessageBox.Show("La Inspección de Trabajo no tiene acciones correctivas pendienes", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor = Cursors.Default;
                    return;
                }
                else
                {
                    foreach (var item in lstInspeccionTrabajoDetalle)
                    {
                        PersonaBE objE_Persona = new PersonaBE();
                        objE_Persona = new PersonaBL().Selecciona(0, 0, 0, item.IdResponsable);
                        if (objE_Persona != null)
                        {
                            strMailTO = strMailTO + ";" + objE_Persona.Email;
                        }
                    }
                }

                StringBuilder strMensaje = new StringBuilder();
                strMensaje.Append("**************************************************************************************************************************\n\n");
                strMensaje.Append("Se adjunta las Acciones Correctivas Pendientes " + "\n\n");
                strMensaje.Append("Comunicarse con el Area de Seguridad y Salud en el Trabajo" + "\n\n");
                strMensaje.Append("**************************************************************************************************************************\n\n");

                //ELIMINAMOS LOR ARCHIVOS CREADOS
                foreach (var item in Directory.GetFiles(@"D:\", "*.pdf"))
                {
                    File.SetAttributes(item, FileAttributes.Normal);
                    File.Delete(item);
                }

                //GENERAR EL REPORTE EN PDF
                List<ReporteInspeccionTrabajoBE> lstReporteInspeccion = null;
                lstReporteInspeccion = new ReporteInspeccionTrabajoBL().ListadoPendiente(intIdInspeccionTrabajo);
                rptInspeccionTrabajo objReporte = new rptInspeccionTrabajo();
                objReporte.SetDataSource(lstReporteInspeccion);
                objReporte.ExportToDisk(ExportFormatType.PortableDocFormat, @"D:\" + strNumero + ".pdf");

                BSUtils.EmailSend(strMailTO, "Inspección Interna de Trabajo", strMensaje.ToString(), @"D:\" + strNumero + ".pdf","", "", "");

                XtraMessageBox.Show("El Correo se envio correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            
            mLista = new InspeccionTrabajoBL().ListaFecha(Parametros.intEmpresaId, 0, 0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcInspeccionTrabajo.DataSource = mLista;
        }

        private void CargarNumero(int Numero)
        {
            mLista = new InspeccionTrabajoBL().ListaNumero(Numero);
            gcInspeccionTrabajo.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvInspeccionTrabajo.RowCount > 0)
            {
                InspeccionTrabajoBE objInspeccionTrabajo = new InspeccionTrabajoBE();
                objInspeccionTrabajo.IdInspeccionTrabajo = int.Parse(gvInspeccionTrabajo.GetFocusedRowCellValue("IdInspeccionTrabajo").ToString());

                frmRegInspeccionTrabajoEdit objManInspeccionTrabajoEdit = new frmRegInspeccionTrabajoEdit();
                objManInspeccionTrabajoEdit.pOperacion = frmRegInspeccionTrabajoEdit.Operacion.Modificar;
                objManInspeccionTrabajoEdit.IdInspeccionTrabajo = objInspeccionTrabajo.IdInspeccionTrabajo;
                objManInspeccionTrabajoEdit.StartPosition = FormStartPosition.CenterParent;
                objManInspeccionTrabajoEdit.ShowDialog();

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

            if (gvInspeccionTrabajo.GetFocusedRowCellValue("IdInspeccionTrabajo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una InspeccionTrabajo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}