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
    public partial class frmBuscaCondicionSubEstandar : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CondicionSubEstandarBE> mLista = new List<CondicionSubEstandarBE>();
        public List<CondicionSubEstandarBE> pListaCondicionSubEstandar { get; set; }
        public CondicionSubEstandarBE pCondicionSubEstandarBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }

        #endregion

        #region "Eventos"

        public frmBuscaCondicionSubEstandar()
        {
            InitializeComponent();
        }

        private void frmBuscaCondicionSubEstandar_Load(object sender, EventArgs e)
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
                gcCondicionSubEstandar.Focus();
            }
        }

        private void gvCondicionSubEstandar_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvCondicionSubEstandar_KeyDown(object sender, KeyEventArgs e)
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
            mLista = new CondicionSubEstandarBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcCondicionSubEstandar.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcCondicionSubEstandar.DataSource = mLista.Where(obj =>
                                                   obj.DescCondicionSubEstandar.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        private void SeleccionarRegistro()
        {
            if (gvCondicionSubEstandar.RowCount > 0)
            {
                CondicionSubEstandarBE objCondicionSubEstandar = new CondicionSubEstandarBE();
                if (pFlagMultiSelect)
                {
                    List<CondicionSubEstandarBE> lista = new List<CondicionSubEstandarBE>();
                    foreach (int i in gvCondicionSubEstandar.GetSelectedRows())
                    {
                        objCondicionSubEstandar = (CondicionSubEstandarBE)gvCondicionSubEstandar.GetRow(i);
                        lista.Add(objCondicionSubEstandar);
                    }
                    pListaCondicionSubEstandar = lista;
                }
                else
                {
                    int index = gvCondicionSubEstandar.FocusedRowHandle;
                    objCondicionSubEstandar = (CondicionSubEstandarBE)gvCondicionSubEstandar.GetRow(index);
                    pCondicionSubEstandarBE = objCondicionSubEstandar;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Busqueda CondicionSubEstandar");
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