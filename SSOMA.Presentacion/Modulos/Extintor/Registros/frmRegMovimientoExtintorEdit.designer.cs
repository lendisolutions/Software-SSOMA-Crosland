namespace SSOMA.Presentacion.Modulos.Extintor.Registros
{
    partial class frmRegMovimientoExtintorEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegMovimientoExtintorEdit));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btnBuscarAutorizadoPor = new DevExpress.XtraEditors.SimpleButton();
            this.btnBucarHechoPor = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtAutorizadoPor = new DevExpress.XtraEditors.TextEdit();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.txtHechoPor = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtUbicacion = new DevExpress.XtraEditors.MemoEdit();
            this.cboExtintor = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtObservacion = new DevExpress.XtraEditors.MemoEdit();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cboUnidadMinera = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboArea = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutorizadoPor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHechoPor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUbicacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExtintor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnidadMinera.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboArea.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(630, 465);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 67;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(538, 465);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 66;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 4);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(727, 454);
            this.xtraTabControl1.TabIndex = 65;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xtraTabPage1.Appearance.Header.Options.UseFont = true;
            this.xtraTabPage1.Controls.Add(this.btnBuscarAutorizadoPor);
            this.xtraTabPage1.Controls.Add(this.btnBucarHechoPor);
            this.xtraTabPage1.Controls.Add(this.labelControl4);
            this.xtraTabPage1.Controls.Add(this.txtAutorizadoPor);
            this.xtraTabPage1.Controls.Add(this.lblDescripcion);
            this.xtraTabPage1.Controls.Add(this.txtHechoPor);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.txtUbicacion);
            this.xtraTabPage1.Controls.Add(this.cboExtintor);
            this.xtraTabPage1.Controls.Add(this.labelControl9);
            this.xtraTabPage1.Controls.Add(this.txtObservacion);
            this.xtraTabPage1.Controls.Add(this.deFecha);
            this.xtraTabPage1.Controls.Add(this.labelControl7);
            this.xtraTabPage1.Controls.Add(this.cboUnidadMinera);
            this.xtraTabPage1.Controls.Add(this.labelControl6);
            this.xtraTabPage1.Controls.Add(this.cboEmpresa);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.cboArea);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.labelControl10);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(720, 419);
            this.xtraTabPage1.Text = "Movimiento del Extintor";
            // 
            // btnBuscarAutorizadoPor
            // 
            this.btnBuscarAutorizadoPor.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarAutorizadoPor.Image")));
            this.btnBuscarAutorizadoPor.Location = new System.Drawing.Point(688, 277);
            this.btnBuscarAutorizadoPor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscarAutorizadoPor.Name = "btnBuscarAutorizadoPor";
            this.btnBuscarAutorizadoPor.Size = new System.Drawing.Size(28, 23);
            this.btnBuscarAutorizadoPor.TabIndex = 183;
            this.btnBuscarAutorizadoPor.Click += new System.EventHandler(this.btnBuscarAutorizadoPor_Click);
            // 
            // btnBucarHechoPor
            // 
            this.btnBucarHechoPor.Image = ((System.Drawing.Image)(resources.GetObject("btnBucarHechoPor.Image")));
            this.btnBucarHechoPor.Location = new System.Drawing.Point(688, 250);
            this.btnBucarHechoPor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBucarHechoPor.Name = "btnBucarHechoPor";
            this.btnBucarHechoPor.Size = new System.Drawing.Size(28, 23);
            this.btnBucarHechoPor.TabIndex = 182;
            this.btnBucarHechoPor.Click += new System.EventHandler(this.btnBucarHechoPor_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 279);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(89, 16);
            this.labelControl4.TabIndex = 180;
            this.labelControl4.Text = "Autorizado Por:";
            // 
            // txtAutorizadoPor
            // 
            this.txtAutorizadoPor.Location = new System.Drawing.Point(122, 278);
            this.txtAutorizadoPor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAutorizadoPor.Name = "txtAutorizadoPor";
            this.txtAutorizadoPor.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAutorizadoPor.Properties.MaxLength = 100;
            this.txtAutorizadoPor.Properties.ReadOnly = true;
            this.txtAutorizadoPor.Size = new System.Drawing.Size(564, 22);
            this.txtAutorizadoPor.TabIndex = 181;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(10, 247);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 16);
            this.lblDescripcion.TabIndex = 178;
            this.lblDescripcion.Text = "Hecho Por:";
            // 
            // txtHechoPor
            // 
            this.txtHechoPor.Location = new System.Drawing.Point(122, 251);
            this.txtHechoPor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHechoPor.Name = "txtHechoPor";
            this.txtHechoPor.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHechoPor.Properties.MaxLength = 100;
            this.txtHechoPor.Properties.ReadOnly = true;
            this.txtHechoPor.Size = new System.Drawing.Size(564, 22);
            this.txtHechoPor.TabIndex = 179;
            this.txtHechoPor.EditValueChanged += new System.EventHandler(this.txtHechoPor_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 159);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 16);
            this.labelControl1.TabIndex = 177;
            this.labelControl1.Text = "Ubicación:";
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(122, 156);
            this.txtUbicacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUbicacion.Properties.MaxLength = 300;
            this.txtUbicacion.Size = new System.Drawing.Size(594, 91);
            this.txtUbicacion.TabIndex = 176;
            // 
            // cboExtintor
            // 
            this.cboExtintor.Location = new System.Drawing.Point(122, 17);
            this.cboExtintor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboExtintor.Name = "cboExtintor";
            this.cboExtintor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboExtintor.Properties.NullText = "";
            this.cboExtintor.Size = new System.Drawing.Size(594, 22);
            this.cboExtintor.TabIndex = 175;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(10, 309);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(75, 16);
            this.labelControl9.TabIndex = 174;
            this.labelControl9.Text = "Observación:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(122, 308);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacion.Properties.MaxLength = 300;
            this.txtObservacion.Size = new System.Drawing.Size(594, 91);
            this.txtObservacion.TabIndex = 173;
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(122, 126);
            this.deFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFecha.Size = new System.Drawing.Size(105, 22);
            this.deFecha.TabIndex = 170;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(10, 129);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(39, 16);
            this.labelControl7.TabIndex = 169;
            this.labelControl7.Text = "Fecha:";
            // 
            // cboUnidadMinera
            // 
            this.cboUnidadMinera.Location = new System.Drawing.Point(122, 71);
            this.cboUnidadMinera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboUnidadMinera.Name = "cboUnidadMinera";
            this.cboUnidadMinera.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUnidadMinera.Properties.NullText = "";
            this.cboUnidadMinera.Size = new System.Drawing.Size(594, 22);
            this.cboUnidadMinera.TabIndex = 164;
            this.cboUnidadMinera.EditValueChanged += new System.EventHandler(this.cboUnidadMinera_EditValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(10, 102);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(32, 16);
            this.labelControl6.TabIndex = 163;
            this.labelControl6.Text = "Area:";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Location = new System.Drawing.Point(122, 44);
            this.cboEmpresa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Properties.NullText = "";
            this.cboEmpresa.Size = new System.Drawing.Size(594, 22);
            this.cboEmpresa.TabIndex = 162;
            this.cboEmpresa.EditValueChanged += new System.EventHandler(this.cboEmpresa_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 75);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 16);
            this.labelControl3.TabIndex = 161;
            this.labelControl3.Text = "Sede:";
            // 
            // cboArea
            // 
            this.cboArea.Location = new System.Drawing.Point(122, 98);
            this.cboArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboArea.Name = "cboArea";
            this.cboArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboArea.Properties.NullText = "";
            this.cboArea.Size = new System.Drawing.Size(594, 22);
            this.cboArea.TabIndex = 160;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 48);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 16);
            this.labelControl2.TabIndex = 159;
            this.labelControl2.Text = "Empresa:";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(10, 21);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(48, 16);
            this.labelControl10.TabIndex = 155;
            this.labelControl10.Text = "Extintor:";
            // 
            // frmRegMovimientoExtintorEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 501);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.xtraTabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegMovimientoExtintorEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmRegMovimientoExtintorEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutorizadoPor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHechoPor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUbicacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExtintor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnidadMinera.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboArea.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.MemoEdit txtObservacion;
        public DevExpress.XtraEditors.DateEdit deFecha;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.LookUpEdit cboUnidadMinera;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.LookUpEdit cboArea;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        public DevExpress.XtraEditors.LookUpEdit cboExtintor;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtUbicacion;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtAutorizadoPor;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.TextEdit txtHechoPor;
        private DevExpress.XtraEditors.SimpleButton btnBuscarAutorizadoPor;
        private DevExpress.XtraEditors.SimpleButton btnBucarHechoPor;
    }
}