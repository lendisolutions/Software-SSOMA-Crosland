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
using SSOMA.Presentacion.Utils;
using SSOMA.Presentacion.Funciones;
using SSOMA.Presentacion.Modulos.Otros;


namespace SSOMA.Presentacion.Modulos.Extintor.Registros
{
    public partial class frmRegServicioExtintorEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ExtintorBE> lstExtintor;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }
        public int intIdEmpresa { get; set; }
        public int intIdUnidadMinera { get; set; }

        int _IdExtintor = 0;

        public int IdExtintor
        {
            get { return _IdExtintor; }
            set { _IdExtintor = value; }
        }

        #endregion

        #region "Eventos"

        public frmRegServicioExtintorEdit()
        {
            InitializeComponent();
        }

        private void frmRegServicioExtintorEdit_Load(object sender, EventArgs e)
        {
            deFechaServicio.DateTime = DateTime.Now;
            BSUtils.LoaderLook(cboServicio, new ServicioExtintorBL().ListaTodosActivo(0), "DescServicioExtintor", "IdServicioExtintor", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Movimiento Extintor - Nuevo";

            }

            Cargar();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                ExtintorDetalleBL objBL_ExtintorDetalle = new ExtintorDetalleBL();
                List<ExtintorDetalleBE> lstServicio = new List<ExtintorDetalleBE>();

                int[] rows = gvExtintor.GetSelectedRows();

                for (int i = 0; i < rows.Length; i++)
                {
                    ExtintorDetalleBE objE_ExtintorDetalle = new ExtintorDetalleBE();
                    objE_ExtintorDetalle.IdExtintorDetalle = 0;
                    objE_ExtintorDetalle.IdExtintor = int.Parse(gvExtintor.GetRowCellValue(rows[i], gvExtintor.Columns.ColumnByFieldName("IdExtintor")).ToString());
                    objE_ExtintorDetalle.Fecha = Convert.ToDateTime(deFechaServicio.DateTime.ToShortDateString());
                    objE_ExtintorDetalle.IdServicioExtintor = Convert.ToInt32(cboServicio.EditValue);
                    objE_ExtintorDetalle.DescServicioExtintor = cboServicio.Text;
                    objE_ExtintorDetalle.FlagEstado = true;
                    objE_ExtintorDetalle.Usuario = Parametros.strUsuarioLogin;
                    objE_ExtintorDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_ExtintorDetalle.IdEmpresa = intIdEmpresa;
                    lstServicio.Add(objE_ExtintorDetalle);
                }


                if (pOperacion == Operacion.Nuevo)
                {
                    objBL_ExtintorDetalle.InsertaMasivo(lstServicio);
                    XtraMessageBox.Show("El servicio del extintor se creó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                this.Close();


               
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            lstExtintor = new ExtintorBL().ListaTodosActivo(intIdEmpresa, intIdUnidadMinera);
            gcExtintor.DataSource = lstExtintor;
        }

        #endregion

        
    }
}