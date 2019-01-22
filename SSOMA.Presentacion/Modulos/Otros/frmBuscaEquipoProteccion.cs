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
    public partial class frmBuscaEquipoProteccion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EquipoProteccionBE> mLista = new List<EquipoProteccionBE>();
        public List<EquipoProteccionBE> pListaEquipoProteccion { get; set; }
        public EquipoProteccionBE pEquipoProteccionBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }

        public string strEquipoProteccion = "";

        #endregion

        #region "Eventos"

        public frmBuscaEquipoProteccion()
        {
            InitializeComponent();
        }

        private void frmBuscaEquipoProteccion_Load(object sender, EventArgs e)
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
                gcEquipoProteccion.Focus();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int[] rows = gvEquipoProteccion.GetSelectedRows();

            for (int i = 0; i < rows.Length; i++)
            {
                strEquipoProteccion = strEquipoProteccion + gvEquipoProteccion.GetRowCellValue(rows[i], gvEquipoProteccion.Columns.ColumnByFieldName("DescEquipoProteccion")).ToString() + " , ";

            }

            strEquipoProteccion = strEquipoProteccion.Substring(0, strEquipoProteccion.Length - 2);

            if (strEquipoProteccion == "")
            {
                XtraMessageBox.Show("Debe seleccionar al menos un EquipoProteccion.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            mLista = new EquipoProteccionBL().ListaTodosActivo(0);
            gcEquipoProteccion.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcEquipoProteccion.DataSource = mLista.Where(obj =>
                                                   obj.DescEquipoProteccion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        #endregion


    }
}