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
    public partial class frmBuscaPeligro : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PeligroBE> mLista = new List<PeligroBE>();
        public List<PeligroBE> pListaPeligro { get; set; }
        public PeligroBE pPeligroBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }

        #endregion

        #region "Eventos"

        public frmBuscaPeligro()
        {
            InitializeComponent();
        }

        private void frmBuscaPeligro_Load(object sender, EventArgs e)
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
                gcPeligro.Focus();
            }
        }

        private void gvPeligro_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvPeligro_KeyDown(object sender, KeyEventArgs e)
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
            mLista = new PeligroBL().ListaTodosActivo(0,0);
            gcPeligro.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcPeligro.DataSource = mLista.Where(obj =>
                                                   obj.DescPeligro.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        private void SeleccionarRegistro()
        {
            if (gvPeligro.RowCount > 0)
            {
                PeligroBE objPeligro = new PeligroBE();
                if (pFlagMultiSelect)
                {
                    List<PeligroBE> lista = new List<PeligroBE>();
                    foreach (int i in gvPeligro.GetSelectedRows())
                    {
                        objPeligro = (PeligroBE)gvPeligro.GetRow(i);
                        lista.Add(objPeligro);
                    }
                    pListaPeligro = lista;
                }
                else
                {
                    int index = gvPeligro.FocusedRowHandle;
                    objPeligro = (PeligroBE)gvPeligro.GetRow(index);
                    pPeligroBE = objPeligro;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Busqueda Peligro");
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