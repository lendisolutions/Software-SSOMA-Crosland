namespace SSOMA.Presentacion.Modulos.Epp.Reportes
{
    partial class frmReppEppConsumoAnualEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReppEppConsumoAnualEmpresa));
            this.btnInforme = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnInforme
            // 
            this.btnInforme.Image = global::SSOMA.Presentacion.Properties.Resources.m_Reportes_16x16;
            this.btnInforme.ImageIndex = 1;
            this.btnInforme.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnInforme.Location = new System.Drawing.Point(209, 34);
            this.btnInforme.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInforme.Name = "btnInforme";
            this.btnInforme.Size = new System.Drawing.Size(87, 28);
            this.btnInforme.TabIndex = 80;
            this.btnInforme.Text = "Informe";
            this.btnInforme.Click += new System.EventHandler(this.btnInforme_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(303, 34);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 79;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmReppEppConsumoAnualEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 96);
            this.Controls.Add(this.btnInforme);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReppEppConsumoAnualEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmReppEppConsumoAnualEmpresa_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnInforme;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
    }
}