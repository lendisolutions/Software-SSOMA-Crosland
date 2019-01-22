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
    public partial class frmBuscaSeveridad : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SeveridadBE> mLista = new List<SeveridadBE>();
        public List<SeveridadBE> pListaSeveridad { get; set; }
        public SeveridadBE pSeveridadBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }

        #endregion

        #region "Eventos"

        public frmBuscaSeveridad()
        {
            InitializeComponent();
        }

        private void frmBuscaSeveridad_Load(object sender, EventArgs e)
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
                gcSeveridad.Focus();
            }
        }

        private void gvSeveridad_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvSeveridad_KeyDown(object sender, KeyEventArgs e)
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
            mLista = new SeveridadBL().ListaTodosActivo(0);
            gcSeveridad.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcSeveridad.DataSource = mLista.Where(obj =>
                                                   obj.DescSeveridad.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        private void SeleccionarRegistro()
        {
            if (gvSeveridad.RowCount > 0)
            {
                SeveridadBE objSeveridad = new SeveridadBE();
                if (pFlagMultiSelect)
                {
                    List<SeveridadBE> lista = new List<SeveridadBE>();
                    foreach (int i in gvSeveridad.GetSelectedRows())
                    {
                        objSeveridad = (SeveridadBE)gvSeveridad.GetRow(i);
                        lista.Add(objSeveridad);
                    }
                    pListaSeveridad = lista;
                }
                else
                {
                    int index = gvSeveridad.FocusedRowHandle;
                    objSeveridad = (SeveridadBE)gvSeveridad.GetRow(index);
                    pSeveridadBE = objSeveridad;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Busqueda Severidad");
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