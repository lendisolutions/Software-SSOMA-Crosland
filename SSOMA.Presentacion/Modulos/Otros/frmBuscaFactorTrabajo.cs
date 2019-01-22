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

namespace SSOMA.Presentacion.Modulos.Otros
{
    public partial class frmBuscaFactorTrabajo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<FactorTrabajoBE> mLista = new List<FactorTrabajoBE>();
        public List<FactorTrabajoBE> pListaFactorTrabajo { get; set; }
        public FactorTrabajoBE pFactorTrabajoBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }

        #endregion

        #region "Eventos"

        public frmBuscaFactorTrabajo()
        {
            InitializeComponent();
        }

        private void frmBuscaFactorTrabajo_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtDescripcion_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
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
                gcFactorTrabajo.Focus();
            }
        }

        private void gvFactorTrabajo_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvFactorTrabajo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarRegistro();
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new FactorTrabajoBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcFactorTrabajo.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcFactorTrabajo.DataSource = mLista.Where(obj =>
                                                   obj.DescFactorTrabajo.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        private void SeleccionarRegistro()
        {
            if (gvFactorTrabajo.RowCount > 0)
            {
                FactorTrabajoBE objFactorTrabajo = new FactorTrabajoBE();
                if (pFlagMultiSelect)
                {
                    List<FactorTrabajoBE> lista = new List<FactorTrabajoBE>();
                    foreach (int i in gvFactorTrabajo.GetSelectedRows())
                    {
                        objFactorTrabajo = (FactorTrabajoBE)gvFactorTrabajo.GetRow(i);
                        lista.Add(objFactorTrabajo);
                    }
                    pListaFactorTrabajo = lista;
                }
                else
                {
                    int index = gvFactorTrabajo.FocusedRowHandle;
                    objFactorTrabajo = (FactorTrabajoBE)gvFactorTrabajo.GetRow(index);
                    pFactorTrabajoBE = objFactorTrabajo;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Busqueda FactorTrabajo");
            }
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