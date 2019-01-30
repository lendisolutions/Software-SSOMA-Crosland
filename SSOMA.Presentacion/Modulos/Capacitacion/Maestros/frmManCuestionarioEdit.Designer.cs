namespace SSOMA.Presentacion.Modulos.Capacitacion.Maestros
{
    partial class frmManCuestionarioEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManCuestionarioEdit));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.txtDescripcion = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaFin = new DevExpress.XtraEditors.DateEdit();
            this.txtDuracion = new DevExpress.XtraEditors.SpinEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaIni = new DevExpress.XtraEditors.DateEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.txtNotaMaxima = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNotaAprobatoria = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuracion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIni.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotaMaxima.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotaAprobatoria.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(782, 232);
            this.xtraTabControl1.TabIndex = 193;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.txtNotaAprobatoria);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.txtNotaMaxima);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.txtDescripcion);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.deFechaFin);
            this.xtraTabPage1.Controls.Add(this.txtDuracion);
            this.xtraTabPage1.Controls.Add(this.lblFecha);
            this.xtraTabPage1.Controls.Add(this.labelControl18);
            this.xtraTabPage1.Controls.Add(this.deFechaIni);
            this.xtraTabPage1.Controls.Add(this.labelControl17);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(775, 198);
            this.xtraTabPage1.Text = "Datos Generales del Cuestionario";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(161, 18);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Properties.MaxLength = 800;
            this.txtDescripcion.Size = new System.Drawing.Size(605, 43);
            this.txtDescripcion.TabIndex = 205;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 19);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 16);
            this.labelControl2.TabIndex = 204;
            this.labelControl2.Text = "Descripcion:";
            // 
            // deFechaFin
            // 
            this.deFechaFin.EditValue = null;
            this.deFechaFin.Location = new System.Drawing.Point(338, 69);
            this.deFechaFin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deFechaFin.Name = "deFechaFin";
            this.deFechaFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaFin.Size = new System.Drawing.Size(105, 22);
            this.deFechaFin.TabIndex = 172;
            // 
            // txtDuracion
            // 
            this.txtDuracion.EditValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.txtDuracion.Location = new System.Drawing.Point(161, 154);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDuracion.Properties.Mask.EditMask = "n0";
            this.txtDuracion.Properties.MaxValue = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.txtDuracion.Properties.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtDuracion.Size = new System.Drawing.Size(60, 22);
            this.txtDuracion.TabIndex = 191;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(13, 157);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(121, 16);
            this.lblFecha.TabIndex = 190;
            this.lblFecha.Text = "Duración en Minutos:";
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(272, 72);
            this.labelControl18.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(60, 16);
            this.labelControl18.TabIndex = 171;
            this.labelControl18.Text = "Fecha Fin:";
            // 
            // deFechaIni
            // 
            this.deFechaIni.EditValue = null;
            this.deFechaIni.Location = new System.Drawing.Point(161, 69);
            this.deFechaIni.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deFechaIni.Name = "deFechaIni";
            this.deFechaIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaIni.Size = new System.Drawing.Size(105, 22);
            this.deFechaIni.TabIndex = 170;
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(13, 72);
            this.labelControl17.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(73, 16);
            this.labelControl17.TabIndex = 169;
            this.labelControl17.Text = "Fecha Inicio:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(682, 241);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 195;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(589, 240);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 194;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtNotaMaxima
            // 
            this.txtNotaMaxima.EditValue = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.txtNotaMaxima.Location = new System.Drawing.Point(161, 98);
            this.txtNotaMaxima.Name = "txtNotaMaxima";
            this.txtNotaMaxima.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNotaMaxima.Properties.Mask.EditMask = "n0";
            this.txtNotaMaxima.Properties.MaxValue = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.txtNotaMaxima.Properties.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtNotaMaxima.Size = new System.Drawing.Size(60, 22);
            this.txtNotaMaxima.TabIndex = 207;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 101);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 16);
            this.labelControl1.TabIndex = 206;
            this.labelControl1.Text = "Nota Máxima:";
            // 
            // txtNotaAprobatoria
            // 
            this.txtNotaAprobatoria.EditValue = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.txtNotaAprobatoria.Location = new System.Drawing.Point(161, 126);
            this.txtNotaAprobatoria.Name = "txtNotaAprobatoria";
            this.txtNotaAprobatoria.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNotaAprobatoria.Properties.Mask.EditMask = "n0";
            this.txtNotaAprobatoria.Properties.MaxValue = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.txtNotaAprobatoria.Properties.MinValue = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.txtNotaAprobatoria.Size = new System.Drawing.Size(60, 22);
            this.txtNotaAprobatoria.TabIndex = 209;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 129);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(102, 16);
            this.labelControl3.TabIndex = 208;
            this.labelControl3.Text = "Nota Aprobatoria:";
            // 
            // frmManCuestionarioEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 277);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.xtraTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManCuestionarioEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmManCuestionarioEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuracion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIni.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotaMaxima.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotaAprobatoria.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.MemoEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.DateEdit deFechaFin;
        private DevExpress.XtraEditors.SpinEdit txtDuracion;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        public DevExpress.XtraEditors.DateEdit deFechaIni;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.SpinEdit txtNotaMaxima;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit txtNotaAprobatoria;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}