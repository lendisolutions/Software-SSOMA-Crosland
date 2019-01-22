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
    public partial class frmBuscaRiesgo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<RiesgoBE> mLista = new List<RiesgoBE>();
        public List<RiesgoBE> pListaRiesgo { get; set; }
        public RiesgoBE pRiesgoBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }

        public string strRiesgo = "";

        #endregion

        #region "Eventos"

        public frmBuscaRiesgo()
        {
            InitializeComponent();
        }

        private void frmBuscaRiesgo_Load(object sender, EventArgs e)
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
            
            if (e.KeyCode == Keys.Down)
            {
                gcRiesgo.Focus();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int[] rows = gvRiesgo.GetSelectedRows();

            for (int i = 0; i < rows.Length; i++)
            {
                strRiesgo = strRiesgo + gvRiesgo.GetRowCellValue(rows[i], gvRiesgo.Columns.ColumnByFieldName("DescRiesgo")).ToString() + " , ";

            }

            strRiesgo = strRiesgo.Substring(0, strRiesgo.Length - 2);

            if (strRiesgo == "")
            {
                XtraMessageBox.Show("Debe seleccionar al menos un riesgo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new RiesgoBL().ListaTodosActivo(0);
            gcRiesgo.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcRiesgo.DataSource = mLista.Where(obj =>
                                                   obj.DescRiesgo.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }



        #endregion

        
    }
}