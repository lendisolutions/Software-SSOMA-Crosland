using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Otros
{
    public partial class frmBuscaServicioExtintor : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ServicioExtintorBE> mLista = new List<ServicioExtintorBE>();
        public ServicioExtintorBE _Be { get; set; }
        
        #endregion

        #region "Eventos"

        public frmBuscaServicioExtintor()
        {
            InitializeComponent();
        }

        private void frmBuscaServicioExtintor_Load(object sender, EventArgs e)
        {
            Carga();
        }

        private void gvServicioExtintor_DoubleClick(object sender, EventArgs e)
        {
            Aceptar1();
        }

        private void txtDescripcion_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        #endregion

        #region "Metodos"

        private void Carga()
        {
            mLista = new ServicioExtintorBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcServicioExtintor.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcServicioExtintor.DataSource = mLista.Where(obj =>
                                                   obj.DescServicioExtintor.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        private void Aceptar1()
        {
            _Be = (ServicioExtintorBE)gvServicioExtintor.GetRow(gvServicioExtintor.FocusedRowHandle);
            this.DialogResult = DialogResult.OK;
        }

        #endregion
        
    }
}