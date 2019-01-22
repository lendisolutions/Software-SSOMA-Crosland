namespace SSOMA.Presentacion.Modulos.Iperc.Maestros
{
    partial class frmManValoracionRiesgoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManValoracionRiesgoEdit));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.txtDescValoracionRiesgo = new DevExpress.XtraEditors.MemoEdit();
            this.txtValoracion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCalificacion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.txtClasificacion = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescValoracionRiesgo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValoracion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCalificacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClasificacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(817, 235);
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
            this.btnGrabar.Location = new System.Drawing.Point(727, 235);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 28;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.txtDescValoracionRiesgo);
            this.grdDatos.Controls.Add(this.txtValoracion);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.txtCalificacion);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.lblFecha);
            this.grdDatos.Controls.Add(this.lblDescripcion);
            this.grdDatos.Controls.Add(this.txtClasificacion);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(911, 227);
            this.grdDatos.TabIndex = 27;
            this.grdDatos.Text = "Datos";
            // 
            // txtDescValoracionRiesgo
            // 
            this.txtDescValoracionRiesgo.Location = new System.Drawing.Point(160, 94);
            this.txtDescValoracionRiesgo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescValoracionRiesgo.Name = "txtDescValoracionRiesgo";
            this.txtDescValoracionRiesgo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescValoracionRiesgo.Properties.MaxLength = 800;
            this.txtDescValoracionRiesgo.Size = new System.Drawing.Size(744, 97);
            this.txtDescValoracionRiesgo.TabIndex = 197;
            // 
            // txtValoracion
            // 
            this.txtValoracion.Location = new System.Drawing.Point(160, 35);
            this.txtValoracion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtValoracion.Name = "txtValoracion";
            this.txtValoracion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValoracion.Properties.MaxLength = 100;
            this.txtValoracion.Size = new System.Drawing.Size(744, 22);
            this.txtValoracion.TabIndex = 196;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 202);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 16);
            this.labelControl3.TabIndex = 194;
            this.labelControl3.Text = "Calificación:";
            // 
            // txtCalificacion
            // 
            this.txtCalificacion.Location = new System.Drawing.Point(160, 199);
            this.txtCalificacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCalificacion.Name = "txtCalificacion";
            this.txtCalificacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCalificacion.Properties.MaxLength = 100;
            this.txtCalificacion.Size = new System.Drawing.Size(744, 22);
            this.txtCalificacion.TabIndex = 195;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 97);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 16);
            this.labelControl1.TabIndex = 190;
            this.labelControl1.Text = "Descripción:";
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(12, 38);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(65, 16);
            this.lblFecha.TabIndex = 188;
            this.lblFecha.Text = "Valoración:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(12, 67);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(75, 16);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Clasificación:";
            // 
            // txtClasificacion
            // 
            this.txtClasificacion.Location = new System.Drawing.Point(160, 64);
            this.txtClasificacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtClasificacion.Name = "txtClasificacion";
            this.txtClasificacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClasificacion.Properties.MaxLength = 100;
            this.txtClasificacion.Size = new System.Drawing.Size(744, 22);
            this.txtClasificacion.TabIndex = 1;
            // 
            // frmManValoracionRiesgoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 276);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManValoracionRiesgoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmManValoracionRiesgoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescValoracionRiesgo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValoracion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCalificacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClasificacion.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.TextEdit txtValoracion;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtCalificacion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.TextEdit txtClasificacion;
        private DevExpress.XtraEditors.MemoEdit txtDescValoracionRiesgo;
    }
}