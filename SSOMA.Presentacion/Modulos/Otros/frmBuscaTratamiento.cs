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
    public partial class frmBuscaTratamiento : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TratamientoBE> mLista = new List<TratamientoBE>();
        public List<TratamientoBE> pListaTratamiento { get; set; }
        public TratamientoBE pTratamientoBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }

        public string strTratamiento = "";

        #endregion

        #region "Eventos"

        public frmBuscaTratamiento()
        {
            InitializeComponent();
        }

        private void frmBuscaTratamiento_Load(object sender, EventArgs e)
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
                gcTratamiento.Focus();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int[] rows = gvTratamiento.GetSelectedRows();

            for (int i = 0; i < rows.Length; i++)
            {
                strTratamiento = strTratamiento + gvTratamiento.GetRowCellValue(rows[i], gvTratamiento.Columns.ColumnByFieldName("DescTratamiento")).ToString() + " , ";

            }

            strTratamiento = strTratamiento.Substring(0, strTratamiento.Length - 2);

            if (strTratamiento == "")
            {
                XtraMessageBox.Show("Debe seleccionar al menos un Tratamiento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            mLista = new TratamientoBL().ListaTodosActivo(0);
            gcTratamiento.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTratamiento.DataSource = mLista.Where(obj =>
                                                   obj.DescTratamiento.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        #endregion


    }
}