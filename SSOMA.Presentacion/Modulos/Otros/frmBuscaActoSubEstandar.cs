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
    public partial class frmBuscaActoSubEstandar : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ActoSubEstandarBE> mLista = new List<ActoSubEstandarBE>();
        public List<ActoSubEstandarBE> pListaActoSubEstandar { get; set; }
        public ActoSubEstandarBE pActoSubEstandarBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }

        #endregion

        #region "Eventos"

        public frmBuscaActoSubEstandar()
        {
            InitializeComponent();
        }

        private void frmBuscaActoSubEstandar_Load(object sender, EventArgs e)
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
                gcActoSubEstandar.Focus();
            }
        }

        private void gvActoSubEstandar_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvActoSubEstandar_KeyDown(object sender, KeyEventArgs e)
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
            mLista = new ActoSubEstandarBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcActoSubEstandar.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcActoSubEstandar.DataSource = mLista.Where(obj =>
                                                   obj.DescActoSubEstandar.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        private void SeleccionarRegistro()
        {
            if (gvActoSubEstandar.RowCount > 0)
            {
                ActoSubEstandarBE objActoSubEstandar = new ActoSubEstandarBE();
                if (pFlagMultiSelect)
                {
                    List<ActoSubEstandarBE> lista = new List<ActoSubEstandarBE>();
                    foreach (int i in gvActoSubEstandar.GetSelectedRows())
                    {
                        objActoSubEstandar = (ActoSubEstandarBE)gvActoSubEstandar.GetRow(i);
                        lista.Add(objActoSubEstandar);
                    }
                    pListaActoSubEstandar = lista;
                }
                else
                {
                    int index = gvActoSubEstandar.FocusedRowHandle;
                    objActoSubEstandar = (ActoSubEstandarBE)gvActoSubEstandar.GetRow(index);
                    pActoSubEstandarBE = objActoSubEstandar;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Busqueda ActoSubEstandar");
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