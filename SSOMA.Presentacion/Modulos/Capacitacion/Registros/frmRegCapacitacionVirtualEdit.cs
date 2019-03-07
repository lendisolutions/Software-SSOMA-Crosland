using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SSOMA.Presentacion.Modulos.Capacitacion.Registros
{
    public partial class frmRegCapacitacionVirtualEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public string  strDescTema { get; set; }
        public string strParticipante { get; set; }

        #endregion

        #region "Eventos"

        public frmRegCapacitacionVirtualEdit()
        {
            InitializeComponent();
        }

        private void frmRegCapacitacionVirtualEdit_Load(object sender, EventArgs e)
        {
            txtDescripcion.Text = strDescTema;
            txtParticipante.Text = strParticipante;
        }

        #endregion

        #region "Metodos"

        #endregion


    }
}