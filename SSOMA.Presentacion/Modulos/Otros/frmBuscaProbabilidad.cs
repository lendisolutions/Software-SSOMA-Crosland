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
    public partial class frmBuscaProbabilidad : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ProbabilidadBE> mLista = new List<ProbabilidadBE>();
        public List<ProbabilidadBE> pListaProbabilidad { get; set; }
        public ProbabilidadBE pProbabilidadBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }

        #endregion

        #region "Eventos"

        public frmBuscaProbabilidad()
        {
            InitializeComponent();
        }

        private void frmBuscaProbabilidad_Load(object sender, EventArgs e)
        {
            gcProbabilidad.Focus();
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
                gcProbabilidad.Focus();
            }
        }

        private void gvProbabilidad_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvProbabilidad_KeyDown(object sender, KeyEventArgs e)
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
            mLista = new ProbabilidadBL().ListaTodosActivo(0);
            gcProbabilidad.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcProbabilidad.DataSource = mLista.Where(obj =>
                                                   obj.IndiceCapacitacion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        private void SeleccionarRegistro()
        {
            if (gvProbabilidad.RowCount > 0)
            {
                ProbabilidadBE objProbabilidad = new ProbabilidadBE();
                if (pFlagMultiSelect)
                {
                    List<ProbabilidadBE> lista = new List<ProbabilidadBE>();
                    foreach (int i in gvProbabilidad.GetSelectedRows())
                    {
                        objProbabilidad = (ProbabilidadBE)gvProbabilidad.GetRow(i);
                        lista.Add(objProbabilidad);
                    }
                    pListaProbabilidad = lista;
                }
                else
                {
                    int index = gvProbabilidad.FocusedRowHandle;
                    objProbabilidad = (ProbabilidadBE)gvProbabilidad.GetRow(index);
                    pProbabilidadBE = objProbabilidad;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Busqueda Probabilidad");
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