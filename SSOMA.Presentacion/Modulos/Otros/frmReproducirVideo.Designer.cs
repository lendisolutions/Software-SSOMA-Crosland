namespace SSOMA.Presentacion.Modulos.Otros
{
    partial class frmReproducirVideo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReproducirVideo));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.btnPausa = new DevExpress.XtraEditors.SimpleButton();
            this.btnParar = new DevExpress.XtraEditors.SimpleButton();
            this.btnReproducir = new DevExpress.XtraEditors.SimpleButton();
            this.btnCargar = new DevExpress.XtraEditors.SimpleButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(-3, -3);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(1084, 706);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // btnPausa
            // 
            this.btnPausa.ImageOptions.Image = global::SSOMA.Presentacion.Properties.Resources.Pausa_16x16;
            this.btnPausa.ImageOptions.ImageIndex = 1;
            this.btnPausa.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPausa.Location = new System.Drawing.Point(604, 710);
            this.btnPausa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPausa.Name = "btnPausa";
            this.btnPausa.Size = new System.Drawing.Size(73, 28);
            this.btnPausa.TabIndex = 19;
            this.btnPausa.Text = "Pausa";
            this.btnPausa.Click += new System.EventHandler(this.btnPausa_Click);
            // 
            // btnParar
            // 
            this.btnParar.ImageOptions.Image = global::SSOMA.Presentacion.Properties.Resources.Parar_16x16;
            this.btnParar.ImageOptions.ImageIndex = 1;
            this.btnParar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnParar.Location = new System.Drawing.Point(525, 710);
            this.btnParar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(73, 28);
            this.btnParar.TabIndex = 18;
            this.btnParar.Text = "Parar";
            this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // btnReproducir
            // 
            this.btnReproducir.ImageOptions.Image = global::SSOMA.Presentacion.Properties.Resources.Reproducir_16x16;
            this.btnReproducir.ImageOptions.ImageIndex = 1;
            this.btnReproducir.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnReproducir.Location = new System.Drawing.Point(410, 710);
            this.btnReproducir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReproducir.Name = "btnReproducir";
            this.btnReproducir.Size = new System.Drawing.Size(109, 28);
            this.btnReproducir.TabIndex = 17;
            this.btnReproducir.Text = "Reproducir";
            this.btnReproducir.Click += new System.EventHandler(this.btnReproducir_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.ImageOptions.Image = global::SSOMA.Presentacion.Properties.Resources.Reproducir_16x16;
            this.btnCargar.ImageOptions.ImageIndex = 1;
            this.btnCargar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCargar.Location = new System.Drawing.Point(307, 710);
            this.btnCargar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(84, 28);
            this.btnCargar.TabIndex = 20;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmReproducirVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 749);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.btnPausa);
            this.Controls.Add(this.btnParar);
            this.Controls.Add(this.btnReproducir);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReproducirVideo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reproducir Video";
            this.Load += new System.EventHandler(this.frmReproducirVideo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private DevExpress.XtraEditors.SimpleButton btnReproducir;
        private DevExpress.XtraEditors.SimpleButton btnParar;
        private DevExpress.XtraEditors.SimpleButton btnPausa;
        private DevExpress.XtraEditors.SimpleButton btnCargar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}