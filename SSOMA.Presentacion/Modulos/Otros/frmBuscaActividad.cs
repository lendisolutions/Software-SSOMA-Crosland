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
    public partial class frmBuscaActividad : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ActividadBE> mLista = new List<ActividadBE>();
        public List<ActividadBE> pListaActividad { get; set; }
        public ActividadBE pActividadBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }

        public int intIdEmpresa { get; set; }
        public int intIdUnidadMinera { get; set; }
        public int intIdArea { get; set; }
        public int intIdSector { get; set; }
        
        #endregion

        #region "Eventos"

        public frmBuscaActividad()
        {
            InitializeComponent();
        }

        private void frmBuscaActividad_Load(object sender, EventArgs e)
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
                gcActividad.Focus();
            }
        }

        private void gvActividad_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvActividad_KeyDown(object sender, KeyEventArgs e)
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
            mLista = new ActividadBL().ListaTodosActivo(intIdEmpresa, intIdUnidadMinera, intIdArea, intIdSector);
            gcActividad.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcActividad.DataSource = mLista.Where(obj =>
                                                   obj.DescActividad.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        private void SeleccionarRegistro()
        {
            if (gvActividad.RowCount > 0)
            {
                ActividadBE objActividad = new ActividadBE();
                if (pFlagMultiSelect)
                {
                    List<ActividadBE> lista = new List<ActividadBE>();
                    foreach (int i in gvActividad.GetSelectedRows())
                    {
                        objActividad = (ActividadBE)gvActividad.GetRow(i);
                        lista.Add(objActividad);
                    }
                    pListaActividad = lista;
                }
                else
                {
                    int index = gvActividad.FocusedRowHandle;
                    objActividad = (ActividadBE)gvActividad.GetRow(index);
                    pActividadBE = objActividad;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Busqueda Actividad");
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