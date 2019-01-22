namespace SSOMA.Presentacion.Modulos.Iperc.Maestros
{
    partial class frmManSeveridadEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManSeveridadEdit));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.txtValorSeveridad = new DevExpress.XtraEditors.SpinEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.txtDescSeveridad = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorSeveridad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescSeveridad.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(817, 104);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(724, 104);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 28;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.txtValorSeveridad);
            this.grdDatos.Controls.Add(this.lblFecha);
            this.grdDatos.Controls.Add(this.lblDescripcion);
            this.grdDatos.Controls.Add(this.txtDescSeveridad);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(913, 96);
            this.grdDatos.TabIndex = 27;
            this.grdDatos.Text = "Datos";
            // 
            // txtValorSeveridad
            // 
            this.txtValorSeveridad.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtValorSeveridad.Location = new System.Drawing.Point(160, 35);
            this.txtValorSeveridad.Name = "txtValorSeveridad";
            this.txtValorSeveridad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtValorSeveridad.Properties.MaxValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.txtValorSeveridad.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtValorSeveridad.Size = new System.Drawing.Size(100, 22);
            this.txtValorSeveridad.TabIndex = 189;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(12, 38);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(35, 16);
            this.lblFecha.TabIndex = 188;
            this.lblFecha.Text = "Valor:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(12, 67);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(113, 16);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Indice de Severidad";
            // 
            // txtDescSeveridad
            // 
            this.txtDescSeveridad.Location = new System.Drawing.Point(160, 64);
            this.txtDescSeveridad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescSeveridad.Name = "txtDescSeveridad";
            this.txtDescSeveridad.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescSeveridad.Properties.MaxLength = 100;
            this.txtDescSeveridad.Size = new System.Drawing.Size(744, 22);
            this.txtDescSeveridad.TabIndex = 1;
            // 
            // frmManSeveridadEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 142);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManSeveridadEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmManSeveridadEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorSeveridad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescSeveridad.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.SpinEdit txtValorSeveridad;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.TextEdit txtDescSeveridad;
    }
}