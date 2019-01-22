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
    public partial class frmBuscaEquipo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EquipoBE> mLista = new List<EquipoBE>();
        public List<EquipoBE> pListaEquipo { get; set; }
        public EquipoBE pEquipoBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }

        public int IdEmpresa = 0;

        #endregion

        #region "Eventos"

        public frmBuscaEquipo()
        {
            InitializeComponent();
        }

        private void frmBuscaEquipo_Load(object sender, EventArgs e)
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
                gcEquipo.Focus();
            }
        }

        private void gvEquipo_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvEquipo_KeyDown(object sender, KeyEventArgs e)
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
            mLista = new EquipoBL().ListaTodosActivo(IdEmpresa);
            gcEquipo.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcEquipo.DataSource = mLista.Where(obj =>
                                                   obj.DescEquipo.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        private void SeleccionarRegistro()
        {
            if (gvEquipo.RowCount > 0)
            {
                EquipoBE objEquipo = new EquipoBE();
                if (pFlagMultiSelect)
                {
                    List<EquipoBE> lista = new List<EquipoBE>();
                    foreach (int i in gvEquipo.GetSelectedRows())
                    {
                        objEquipo = (EquipoBE)gvEquipo.GetRow(i);
                        lista.Add(objEquipo);
                    }
                    pListaEquipo = lista;
                }
                else
                {
                    int index = gvEquipo.FocusedRowHandle;
                    objEquipo = (EquipoBE)gvEquipo.GetRow(index);
                    pEquipoBE = objEquipo;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Busqueda Equipo");
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