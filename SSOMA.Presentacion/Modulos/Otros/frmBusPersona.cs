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
using SSOMA.Presentacion.Utils;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Otros
{
    public partial class frmBusPersona : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PersonaBE> pListaPersona { get; set; }
        public PersonaBE pPersonaBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }
        public Boolean pFlagTodoPersonal = false;
        // Variables para paginacion
        private int intPagina = 1;
        private int intRegistrosPorPagina = 0;
        private int intRegistrosTotal = 0;
        private int intPaginaPrimero = 1;
        private int intPaginaUltima = 0;

        private List<PersonaBE> mLista = new List<PersonaBE>();
        
        #endregion

        #region "Eventos"

        public frmBusPersona()
        {
            InitializeComponent();
        }

        private void frmBusPersona_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionPersona), "DescTablaElemento", "IdTablaElemento", true);
            cboSituacion.EditValue = Parametros.intSPActivo;

            intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
            CalcularPaginas();
            CargarBusqueda(intPagina, intRegistrosPorPagina);
            HabilitarBotones(false, false, true, true);

            CargarBusqueda();

        }

        private void cboSituacion_EditValueChanged(object sender, EventArgs e)
        {
            if (cboSituacion.EditValue != null)
            {
                intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
                CalcularPaginas();
                CargarBusqueda(intPagina, intRegistrosPorPagina);
                HabilitarBotones(false, false, true, true);

                CargarBusqueda();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtDescripcion_EditValueChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.ToString().Length > 2)
            {
                CargarBusqueda();
            }

        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                CargarBusqueda();
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarRegistro();
            }
            if (e.KeyCode == Keys.Down)
            {
                gcPersona.Focus();
            }
        }

        private void gvPersona_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvPersona_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarRegistro();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            intPagina = intPaginaPrimero;
            cboPagina.EditValue = intPagina;
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            cboPagina.EditValue = intPagina;

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            intPagina = intPagina - 1;
            cboPagina.EditValue = intPagina;
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            intPagina = intPagina + 1;
            cboPagina.EditValue = intPagina;
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            intPagina = intPaginaUltima;
            cboPagina.EditValue = intPagina;
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void txtCantidadRegistros_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCantidadRegistros.Text.Length > 0)
            {
                intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
                CalcularPaginas();
                CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
            }
        }

        private void cboPagina_EditValueChanged(object sender, EventArgs e)
        {
            intPagina = int.Parse(cboPagina.EditValue.ToString());
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);
            if (intPaginaPrimero == intPaginaUltima)
                HabilitarBotones(false, false, false, false);
            CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
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

        #endregion

        #region "Metodos"

        private void CargarBusqueda(int pagina, int registros)
        {
            if (pFlagTodoPersonal)
                gcPersona.DataSource = new PersonaBL().SeleccionaBusqueda(0, 0, Convert.ToInt32(cboSituacion.EditValue), txtDescripcion.Text, pagina, registros);
            else
                gcPersona.DataSource = new PersonaBL().SeleccionaBusqueda(Parametros.intEmpresaId, 0, Convert.ToInt32(cboSituacion.EditValue), txtDescripcion.Text, pagina, registros);
        }

        private void CargarBusqueda()
        {
            if (pFlagTodoPersonal)
                gcPersona.DataSource = new PersonaBL().SeleccionaBusqueda(0, 0, Convert.ToInt32(cboSituacion.EditValue), txtDescripcion.Text, intPaginaPrimero, intRegistrosPorPagina);
            else
                gcPersona.DataSource = new PersonaBL().SeleccionaBusqueda(Parametros.intEmpresaId, 0, Convert.ToInt32(cboSituacion.EditValue),txtDescripcion.Text, intPaginaPrimero, intRegistrosPorPagina);
            CalcularPaginas();
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);
            if (intPaginaPrimero == intPaginaUltima)
                HabilitarBotones(false, false, false, false);

        }

        private void SeleccionarRegistro()
        {
            if (gvPersona.RowCount > 0)
            {
                PersonaBE objPersona = new PersonaBE();
                if (pFlagMultiSelect)
                {
                    List<PersonaBE> lista = new List<PersonaBE>();
                    foreach (int i in gvPersona.GetSelectedRows())
                    {
                        objPersona = (PersonaBE)gvPersona.GetRow(i);
                        lista.Add(objPersona);
                    }
                    pListaPersona = lista;
                }
                else
                {
                    int index = gvPersona.FocusedRowHandle;
                    objPersona = (PersonaBE)gvPersona.GetRow(index);
                    pPersonaBE = objPersona;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Busqueda Persona");
            }
        }

        private void CalcularPaginas()
        {
            cboPagina.Properties.Items.Clear();
            intRegistrosTotal = CantidadRegistros();
            if (intRegistrosTotal > 0)
            {
                intPaginaUltima = intRegistrosTotal / intRegistrosPorPagina;
                int Residuo = intRegistrosTotal % intRegistrosPorPagina;
                if (Residuo > 0)
                    intPaginaUltima += 1;
                for (int i = 0; i < intPaginaUltima; i++)
                {
                    cboPagina.Properties.Items.Add(i + 1);
                }
                cboPagina.SelectedIndex = 0;
            }
        }

        private void HabilitarBotones(bool bolFirst, bool bolPrevious, bool bolNext, bool bolLast)
        {
            btnFirst.Enabled = bolFirst;
            btnPrevious.Enabled = bolPrevious;
            btnNext.Enabled = bolNext;
            btnLast.Enabled = bolLast;
        }

        private int CantidadRegistros()
        {
            int intRowCount = 0;
            if (pFlagTodoPersonal)
                intRowCount = new PersonaBL().SeleccionaBusquedaCount(0, 0, Convert.ToInt32(cboSituacion.EditValue), txtDescripcion.Text);
            else
                intRowCount = new PersonaBL().SeleccionaBusquedaCount(Parametros.intEmpresaId, 0, Convert.ToInt32(cboSituacion.EditValue), txtDescripcion.Text);
            return intRowCount;
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                SeleccionarRegistro();
            }
        }


        #endregion

        
    }
}