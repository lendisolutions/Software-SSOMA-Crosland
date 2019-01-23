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

namespace SSOMA.Presentacion.Modulos.Otros
{
    public partial class frmReproducirVideo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public String strRuta { get; set; }

        #endregion

        #region "Eventos"

        public frmReproducirVideo()
        {
            InitializeComponent();
        }

        private void frmReproducirVideo_Load(object sender, EventArgs e)
        {

        }

        private void btnReproducir_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = strRuta;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void btnPausa_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strRuta = openFileDialog1.FileName;
            }
        }

        #endregion

        #region "Metodos"

        #endregion


    }
}