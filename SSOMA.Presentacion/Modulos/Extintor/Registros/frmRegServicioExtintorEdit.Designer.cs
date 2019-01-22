namespace SSOMA.Presentacion.Modulos.Extintor.Registros
{
    partial class frmRegServicioExtintorEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegServicioExtintorEdit));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.cboServicio = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaServicio = new DevExpress.XtraEditors.DateEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.gcExtintor = new DevExpress.XtraGrid.GridControl();
            this.gvExtintor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboServicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaServicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaServicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcExtintor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExtintor)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.cboServicio);
            this.grdDatos.Controls.Add(this.labelControl14);
            this.grdDatos.Controls.Add(this.deFechaServicio);
            this.grdDatos.Controls.Add(this.labelControl7);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(1008, 63);
            this.grdDatos.TabIndex = 22;
            this.grdDatos.Text = "Datos del Servicio";
            // 
            // cboServicio
            // 
            this.cboServicio.Location = new System.Drawing.Point(294, 29);
            this.cboServicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboServicio.Name = "cboServicio";
            this.cboServicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboServicio.Properties.NullText = "";
            this.cboServicio.Size = new System.Drawing.Size(328, 22);
            this.cboServicio.TabIndex = 191;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(238, 32);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(50, 16);
            this.labelControl14.TabIndex = 190;
            this.labelControl14.Text = "Servicio:";
            // 
            // deFechaServicio
            // 
            this.deFechaServicio.EditValue = null;
            this.deFechaServicio.Location = new System.Drawing.Point(125, 29);
            this.deFechaServicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deFechaServicio.Name = "deFechaServicio";
            this.deFechaServicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaServicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaServicio.Size = new System.Drawing.Size(105, 22);
            this.deFechaServicio.TabIndex = 172;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(13, 32);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(88, 16);
            this.labelControl7.TabIndex = 171;
            this.labelControl7.Text = "Fecha Servicio:";
            // 
            // gcExtintor
            // 
            this.gcExtintor.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcExtintor.Location = new System.Drawing.Point(0, 71);
            this.gcExtintor.MainView = this.gvExtintor;
            this.gcExtintor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcExtintor.Name = "gcExtintor";
            this.gcExtintor.Size = new System.Drawing.Size(1008, 624);
            this.gcExtintor.TabIndex = 68;
            this.gcExtintor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvExtintor});
            // 
            // gvExtintor
            // 
            this.gvExtintor.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvExtintor.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvExtintor.Appearance.ViewCaption.Options.UseFont = true;
            this.gvExtintor.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvExtintor.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn1,
            this.gcCodigo,
            this.gridColumn7,
            this.gridColumn6,
            this.gridColumn9});
            this.gvExtintor.GridControl = this.gcExtintor;
            this.gvExtintor.Name = "gvExtintor";
            this.gvExtintor.OptionsSelection.MultiSelect = true;
            this.gvExtintor.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvExtintor.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvExtintor.OptionsView.ColumnAutoWidth = false;
            this.gvExtintor.OptionsView.ShowGroupPanel = false;
            this.gvExtintor.OptionsView.ShowViewCaption = true;
            this.gvExtintor.ViewCaption = "LISTADO DE EXTINTORES";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdExtintor";
            this.gridColumn3.FieldName = "IdExtintor";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdExtintorDetalle";
            this.gridColumn1.FieldName = "IdMovimientoExtintor";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código Extintor";
            this.gcCodigo.FieldName = "Codigo";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsColumn.AllowEdit = false;
            this.gcCodigo.OptionsColumn.AllowFocus = false;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 1;
            this.gcCodigo.Width = 100;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tipo";
            this.gridColumn7.FieldName = "AbreviaturaTipo";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 50;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Capacidad";
            this.gridColumn6.FieldName = "Capacidad";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 70;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Ubicación";
            this.gridColumn9.FieldName = "Ubicacion";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 500;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(909, 703);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 70;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(816, 703);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 69;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmRegServicioExtintorEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 741);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.gcExtintor);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegServicioExtintorEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmRegServicioExtintorEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboServicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaServicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaServicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcExtintor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExtintor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraGrid.GridControl gcExtintor;
        private DevExpress.XtraGrid.Views.Grid.GridView gvExtintor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnGrabar;
        public DevExpress.XtraEditors.DateEdit deFechaServicio;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.LookUpEdit cboServicio;
        private DevExpress.XtraEditors.LabelControl labelControl14;
    }
}