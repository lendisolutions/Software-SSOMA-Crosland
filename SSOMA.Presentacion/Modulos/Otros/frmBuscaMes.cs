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
    public partial class frmBuscaMes : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<MesBE> mLista = new List<MesBE>();
        public List<MesBE> pListaMes { get; set; }
        public MesBE pMesBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }

        #endregion

        #region "Eventos"

        public frmBuscaMes()
        {
            InitializeComponent();
        }

        private void frmBuscaMes_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvMes_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvMes_KeyDown(object sender, KeyEventArgs e)
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
            mLista = new MesBL().ListaTodosActivo();
            gcMes.DataSource = mLista;
        }

        private void SeleccionarRegistro()
        {
            if (gvMes.RowCount > 0)
            {
                MesBE objMes = new MesBE();
                if (pFlagMultiSelect)
                {
                    List<MesBE> lista = new List<MesBE>();
                    foreach (int i in gvMes.GetSelectedRows())
                    {
                        objMes = (MesBE)gvMes.GetRow(i);
                        lista.Add(objMes);
                    }
                    pListaMes = lista;
                }
                else
                {
                    int index = gvMes.FocusedRowHandle;
                    objMes = (MesBE)gvMes.GetRow(index);
                    pMesBE = objMes;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Busqueda Mes");
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