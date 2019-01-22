namespace SSOMA.Presentacion.Modulos.Epp.Reportes
{
    partial class frmRepSolicitudEpp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepSolicitudEpp));
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.rbdSolicitudPorVencer = new System.Windows.Forms.RadioButton();
            this.rbdSolicitudVencida = new System.Windows.Forms.RadioButton();
            this.btnInforme = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Location = new System.Drawing.Point(79, 12);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Properties.NullText = "";
            this.cboEmpresa.Size = new System.Drawing.Size(280, 20);
            this.cboEmpresa.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Empresa:";
            // 
            // rbdSolicitudPorVencer
            // 
            this.rbdSolicitudPorVencer.AutoSize = true;
            this.rbdSolicitudPorVencer.Checked = true;
            this.rbdSolicitudPorVencer.Location = new System.Drawing.Point(79, 38);
            this.rbdSolicitudPorVencer.Name = "rbdSolicitudPorVencer";
            this.rbdSolicitudPorVencer.Size = new System.Drawing.Size(130, 17);
            this.rbdSolicitudPorVencer.TabIndex = 8;
            this.rbdSolicitudPorVencer.TabStop = true;
            this.rbdSolicitudPorVencer.Text = "Solicitudes Por Vencer";
            this.rbdSolicitudPorVencer.UseVisualStyleBackColor = true;
            // 
            // rbdSolicitudVencida
            // 
            this.rbdSolicitudVencida.AutoSize = true;
            this.rbdSolicitudVencida.Location = new System.Drawing.Point(79, 61);
            this.rbdSolicitudVencida.Name = "rbdSolicitudVencida";
            this.rbdSolicitudVencida.Size = new System.Drawing.Size(120, 17);
            this.rbdSolicitudVencida.TabIndex = 9;
            this.rbdSolicitudVencida.Text = "Solicitudes Vencidas";
            this.rbdSolicitudVencida.UseVisualStyleBackColor = true;
            // 
            // btnInforme
            // 
            this.btnInforme.Image = global::SSOMA.Presentacion.Properties.Resources.m_Reportes_16x16;
            this.btnInforme.ImageIndex = 1;
            this.btnInforme.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnInforme.Location = new System.Drawing.Point(271, 71);
            this.btnInforme.Name = "btnInforme";
            this.btnInforme.Size = new System.Drawing.Size(75, 23);
            this.btnInforme.TabIndex = 71;
            this.btnInforme.Text = "Informe";
            this.btnInforme.Click += new System.EventHandler(this.btnInforme_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(352, 71);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 70;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmRepSolicitudEpp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 106);
            this.Controls.Add(this.btnInforme);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.rbdSolicitudVencida);
            this.Controls.Add(this.rbdSolicitudPorVencer);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepSolicitudEpp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmRepSolicitudEpp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.RadioButton rbdSolicitudPorVencer;
        private System.Windows.Forms.RadioButton rbdSolicitudVencida;
        private DevExpress.XtraEditors.SimpleButton btnInforme;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
    }
}