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
    public partial class frmBuscaFactorPersonal : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<FactorPersonalBE> mLista = new List<FactorPersonalBE>();
        public List<FactorPersonalBE> pListaFactorPersonal { get; set; }
        public FactorPersonalBE pFactorPersonalBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }

        #endregion

        #region "Eventos"

        public frmBuscaFactorPersonal()
        {
            InitializeComponent();
        }

        private void frmBuscaFactorPersonal_Load(object sender, EventArgs e)
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
                gcFactorPersonal.Focus();
            }
        }

        private void gvFactorPersonal_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvFactorPersonal_KeyDown(object sender, KeyEventArgs e)
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
            mLista = new FactorPersonalBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcFactorPersonal.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcFactorPersonal.DataSource = mLista.Where(obj =>
                                                   obj.DescFactorPersonal.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        private void SeleccionarRegistro()
        {
            if (gvFactorPersonal.RowCount > 0)
            {
                FactorPersonalBE objFactorPersonal = new FactorPersonalBE();
                if (pFlagMultiSelect)
                {
                    List<FactorPersonalBE> lista = new List<FactorPersonalBE>();
                    foreach (int i in gvFactorPersonal.GetSelectedRows())
                    {
                        objFactorPersonal = (FactorPersonalBE)gvFactorPersonal.GetRow(i);
                        lista.Add(objFactorPersonal);
                    }
                    pListaFactorPersonal = lista;
                }
                else
                {
                    int index = gvFactorPersonal.FocusedRowHandle;
                    objFactorPersonal = (FactorPersonalBE)gvFactorPersonal.GetRow(index);
                    pFactorPersonalBE = objFactorPersonal;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Busqueda FactorPersonal");
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