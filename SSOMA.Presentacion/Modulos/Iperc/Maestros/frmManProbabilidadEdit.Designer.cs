namespace SSOMA.Presentacion.Modulos.Iperc.Maestros
{
    partial class frmManProbabilidadEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManProbabilidadEdit));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.txtIndicePersona = new DevExpress.XtraEditors.TextEdit();
            this.txtValorProbabilidad = new DevExpress.XtraEditors.SpinEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtIndiceProcedimiento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtIndiceCapacitacion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtIndiceFrecuencia = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndicePersona.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorProbabilidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndiceProcedimiento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndiceCapacitacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndiceFrecuencia.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(817, 198);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(724, 198);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 25;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.txtIndiceFrecuencia);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.txtIndiceCapacitacion);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.txtIndiceProcedimiento);
            this.grdDatos.Controls.Add(this.txtValorProbabilidad);
            this.grdDatos.Controls.Add(this.lblFecha);
            this.grdDatos.Controls.Add(this.lblDescripcion);
            this.grdDatos.Controls.Add(this.txtIndicePersona);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(913, 188);
            this.grdDatos.TabIndex = 24;
            this.grdDatos.Text = "Datos";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(12, 67);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(107, 16);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Indice de Persona:";
            // 
            // txtIndicePersona
            // 
            this.txtIndicePersona.Location = new System.Drawing.Point(160, 64);
            this.txtIndicePersona.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIndicePersona.Name = "txtIndicePersona";
            this.txtIndicePersona.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIndicePersona.Properties.MaxLength = 100;
            this.txtIndicePersona.Size = new System.Drawing.Size(744, 22);
            this.txtIndicePersona.TabIndex = 1;
            // 
            // txtValorProbabilidad
            // 
            this.txtValorProbabilidad.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtValorProbabilidad.Location = new System.Drawing.Point(160, 35);
            this.txtValorProbabilidad.Name = "txtValorProbabilidad";
            this.txtValorProbabilidad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtValorProbabilidad.Properties.MaxValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.txtValorProbabilidad.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtValorProbabilidad.Size = new System.Drawing.Size(100, 22);
            this.txtValorProbabilidad.TabIndex = 189;
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
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 97);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(142, 16);
            this.labelControl1.TabIndex = 190;
            this.labelControl1.Text = "Indice de Procedimiento:";
            // 
            // txtIndiceProcedimiento
            // 
            this.txtIndiceProcedimiento.Location = new System.Drawing.Point(160, 94);
            this.txtIndiceProcedimiento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIndiceProcedimiento.Name = "txtIndiceProcedimiento";
            this.txtIndiceProcedimiento.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIndiceProcedimiento.Properties.MaxLength = 100;
            this.txtIndiceProcedimiento.Size = new System.Drawing.Size(744, 22);
            this.txtIndiceProcedimiento.TabIndex = 191;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 127);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(133, 16);
            this.labelControl2.TabIndex = 192;
            this.labelControl2.Text = "Indice de Capacitación:";
            // 
            // txtIndiceCapacitacion
            // 
            this.txtIndiceCapacitacion.Location = new System.Drawing.Point(160, 124);
            this.txtIndiceCapacitacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIndiceCapacitacion.Name = "txtIndiceCapacitacion";
            this.txtIndiceCapacitacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIndiceCapacitacion.Properties.MaxLength = 100;
            this.txtIndiceCapacitacion.Size = new System.Drawing.Size(744, 22);
            this.txtIndiceCapacitacion.TabIndex = 193;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 157);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(123, 16);
            this.labelControl3.TabIndex = 194;
            this.labelControl3.Text = "Indice de Frecuencia:";
            // 
            // txtIndiceFrecuencia
            // 
            this.txtIndiceFrecuencia.Location = new System.Drawing.Point(160, 154);
            this.txtIndiceFrecuencia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIndiceFrecuencia.Name = "txtIndiceFrecuencia";
            this.txtIndiceFrecuencia.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIndiceFrecuencia.Properties.MaxLength = 100;
            this.txtIndiceFrecuencia.Size = new System.Drawing.Size(744, 22);
            this.txtIndiceFrecuencia.TabIndex = 195;
            // 
            // frmManProbabilidadEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 235);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManProbabilidadEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmManProbabilidadEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndicePersona.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorProbabilidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndiceProcedimiento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndiceCapacitacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndiceFrecuencia.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.TextEdit txtIndicePersona;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtIndiceFrecuencia;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtIndiceCapacitacion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtIndiceProcedimiento;
        private DevExpress.XtraEditors.SpinEdit txtValorProbabilidad;
        private DevExpress.XtraEditors.LabelControl lblFecha;
    }
}