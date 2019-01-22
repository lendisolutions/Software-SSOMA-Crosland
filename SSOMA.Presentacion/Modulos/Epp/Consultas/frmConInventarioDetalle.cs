using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion.Modulos.Epp.Consultas
{
    public partial class frmConInventarioDetalle : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<KardexBE> mLista = new List<KardexBE>();

        public int IdEmpresa { get; set; }
        public int IdUnidadMinera { get; set; }
        public string DescOrdenInterna { get; set; }
        public int IdEquipo { get; set; }
        public string Codigo { get; set; }
        public string DescEquipo { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        #endregion

        #region "Eventos"

        public frmConInventarioDetalle()
        {
            InitializeComponent();
        }

        private void frmConInventarioDetalle_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = Codigo;
            txtNombreProducto.Text = DescEquipo;
           

            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new KardexBL().ListaInventarioDetalle(IdEmpresa, IdUnidadMinera, DescOrdenInterna, IdEquipo, FechaDesde, FechaHasta);
            gcInventarioDetalle.DataSource = mLista;
        }

        #endregion

    }
}