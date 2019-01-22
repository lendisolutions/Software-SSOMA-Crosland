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
    public partial class frmBuscaSenalizacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SenalizacionBE> mLista = new List<SenalizacionBE>();
        public List<SenalizacionBE> pListaSenalizacion { get; set; }
        public SenalizacionBE pSenalizacionBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }

        public string strSenalizacion = "";

        #endregion

        #region "Eventos"

        public frmBuscaSenalizacion()
        {
            InitializeComponent();
        }

        private void frmBuscaSenalizacion_Load(object sender, EventArgs e)
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
                gcSenalizacion.Focus();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int[] rows = gvSenalizacion.GetSelectedRows();

            for (int i = 0; i < rows.Length; i++)
            {
                strSenalizacion = strSenalizacion + gvSenalizacion.GetRowCellValue(rows[i], gvSenalizacion.Columns.ColumnByFieldName("DescSenalizacion")).ToString() + " , ";

            }

            strSenalizacion = strSenalizacion.Substring(0, strSenalizacion.Length - 2);

            if (strSenalizacion == "")
            {
                XtraMessageBox.Show("Debe seleccionar al menos un Senalizacion.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            mLista = new SenalizacionBL().ListaTodosActivo(0);
            gcSenalizacion.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcSenalizacion.DataSource = mLista.Where(obj =>
                                                   obj.DescSenalizacion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        #endregion


    }
}