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
    public partial class frmBuscaSustitucion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SustitucionBE> mLista = new List<SustitucionBE>();
        public List<SustitucionBE> pListaSustitucion { get; set; }
        public SustitucionBE pSustitucionBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }

        public string strSustitucion = "";

        #endregion

        #region "Eventos"

        public frmBuscaSustitucion()
        {
            InitializeComponent();
        }

        private void frmBuscaSustitucion_Load(object sender, EventArgs e)
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
                gcSustitucion.Focus();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int[] rows = gvSustitucion.GetSelectedRows();

            for (int i = 0; i < rows.Length; i++)
            {
                strSustitucion = strSustitucion + gvSustitucion.GetRowCellValue(rows[i], gvSustitucion.Columns.ColumnByFieldName("DescSustitucion")).ToString() + " , ";

            }

            strSustitucion = strSustitucion.Substring(0, strSustitucion.Length - 2);

            if (strSustitucion == "")
            {
                XtraMessageBox.Show("Debe seleccionar al menos un Sustitucion.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            mLista = new SustitucionBL().ListaTodosActivo(0);
            gcSustitucion.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcSustitucion.DataSource = mLista.Where(obj =>
                                                   obj.DescSustitucion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        #endregion


    }
}