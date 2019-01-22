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
    public partial class frmBuscaEliminacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EliminacionBE> mLista = new List<EliminacionBE>();
        public List<EliminacionBE> pListaEliminacion { get; set; }
        public EliminacionBE pEliminacionBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }

        public string strEliminacion = "";

        #endregion

        #region "Eventos"

        public frmBuscaEliminacion()
        {
            InitializeComponent();
        }

        private void frmBuscaEliminacion_Load(object sender, EventArgs e)
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
                gcEliminacion.Focus();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int[] rows = gvEliminacion.GetSelectedRows();

            for (int i = 0; i < rows.Length; i++)
            {
                strEliminacion = strEliminacion + gvEliminacion.GetRowCellValue(rows[i], gvEliminacion.Columns.ColumnByFieldName("DescEliminacion")).ToString() + " , ";

            }

            strEliminacion = strEliminacion.Substring(0, strEliminacion.Length - 2);

            if (strEliminacion == "")
            {
                XtraMessageBox.Show("Debe seleccionar al menos un Eliminacion.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            mLista = new EliminacionBL().ListaTodosActivo(0);
            gcEliminacion.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcEliminacion.DataSource = mLista.Where(obj =>
                                                   obj.DescEliminacion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        #endregion


    }
}