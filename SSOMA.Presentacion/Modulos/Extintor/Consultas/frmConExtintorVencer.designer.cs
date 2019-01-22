namespace SSOMA.Presentacion.Modulos.Extintor.Consultas
{
    partial class frmConExtintorVencer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConExtintorVencer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboDias = new DevExpress.XtraEditors.SpinEdit();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gcExtintor = new DevExpress.XtraGrid.GridControl();
            this.gvExtintor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaIngreso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaVencimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcExtintor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExtintor)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstpExportarExcel,
            this.toolStripSeparator1,
            this.toolstpSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1246, 27);
            this.toolStrip1.TabIndex = 62;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolstpExportarExcel
            // 
            this.toolstpExportarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpExportarExcel.Image = global::SSOMA.Presentacion.Properties.Resources.Excel_16x16;
            this.toolstpExportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpExportarExcel.Name = "toolstpExportarExcel";
            this.toolstpExportarExcel.Size = new System.Drawing.Size(24, 24);
            this.toolstpExportarExcel.ToolTipText = "Exportar Excel";
            this.toolstpExportarExcel.Click += new System.EventHandler(this.toolstpExportarExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolstpSalir
            // 
            this.toolstpSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpSalir.Image = ((System.Drawing.Image)(resources.GetObject("toolstpSalir.Image")));
            this.toolstpSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpSalir.Name = "toolstpSalir";
            this.toolstpSalir.Size = new System.Drawing.Size(24, 24);
            this.toolstpSalir.ToolTipText = "Salir";
            this.toolstpSalir.Click += new System.EventHandler(this.toolstpSalir_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 27);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcExtintor);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1246, 619);
            this.splitContainerControl1.SplitterPosition = 53;
            this.splitContainerControl1.TabIndex = 63;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cboDias);
            this.groupControl1.Controls.Add(this.txtCodigo);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Controls.Add(this.cboEmpresa);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1246, 53);
            this.groupControl1.TabIndex = 28;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // cboDias
            // 
            this.cboDias.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cboDias.Location = new System.Drawing.Point(434, 31);
            this.cboDias.Name = "cboDias";
            this.cboDias.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDias.Properties.MaxValue = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.cboDias.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cboDias.Size = new System.Drawing.Size(66, 22);
            this.cboDias.TabIndex = 220;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(692, 31);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.MaxLength = 10;
            this.txtCodigo.Size = new System.Drawing.Size(101, 22);
            this.txtCodigo.TabIndex = 219;
            this.txtCodigo.ToolTip = "Numero de Incidente";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(638, 34);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(44, 16);
            this.labelControl7.TabIndex = 218;
            this.labelControl7.Text = "Código:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(399, 34);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(29, 16);
            this.labelControl6.TabIndex = 217;
            this.labelControl6.Text = "Días:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(541, 31);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(85, 25);
            this.btnConsultar.TabIndex = 216;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Location = new System.Drawing.Point(68, 30);
            this.cboEmpresa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Properties.NullText = "";
            this.cboEmpresa.Size = new System.Drawing.Size(324, 22);
            this.cboEmpresa.TabIndex = 215;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 34);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 16);
            this.labelControl2.TabIndex = 214;
            this.labelControl2.Text = "Empresa:";
            // 
            // gcExtintor
            // 
            this.gcExtintor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcExtintor.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcExtintor.Location = new System.Drawing.Point(0, 0);
            this.gcExtintor.MainView = this.gvExtintor;
            this.gcExtintor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcExtintor.Name = "gcExtintor";
            this.gcExtintor.Size = new System.Drawing.Size(1246, 560);
            this.gcExtintor.TabIndex = 65;
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
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn5,
            this.gridColumn11,
            this.gridColumn9,
            this.gridColumn4,
            this.gridColumn2,
            this.gridColumn6,
            this.gridColumn1,
            this.gcFechaIngreso,
            this.gcFechaVencimiento});
            this.gvExtintor.GridControl = this.gcExtintor;
            this.gvExtintor.Name = "gvExtintor";
            this.gvExtintor.OptionsSelection.MultiSelect = true;
            this.gvExtintor.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvExtintor.OptionsView.ColumnAutoWidth = false;
            this.gvExtintor.OptionsView.ShowGroupPanel = false;
            this.gvExtintor.OptionsView.ShowViewCaption = true;
            this.gvExtintor.ViewCaption = "LISTADO DE EXTINTORES POR VENCER";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdIncidente";
            this.gridColumn3.FieldName = "IdIncidente";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Sede";
            this.gridColumn7.FieldName = "DescUnidadMinera";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 90;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Código";
            this.gridColumn8.FieldName = "Codigo";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 100;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Serie";
            this.gridColumn5.FieldName = "Serie";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 120;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Clasificación";
            this.gridColumn11.FieldName = "AbreviaturaClasificacion";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            this.gridColumn11.Width = 120;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Tipo";
            this.gridColumn9.FieldName = "AbreviaturaTipo";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 120;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Proveedor";
            this.gridColumn4.FieldName = "Proveedor";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 200;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Marca";
            this.gridColumn2.FieldName = "Marca";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 6;
            this.gridColumn2.Width = 120;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Capacidad";
            this.gridColumn6.FieldName = "Capacidad";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 150;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ubicación";
            this.gridColumn1.FieldName = "Ubicacion";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 8;
            this.gridColumn1.Width = 500;
            // 
            // gcFechaIngreso
            // 
            this.gcFechaIngreso.Caption = "Fecha Ingreso";
            this.gcFechaIngreso.FieldName = "FechaIngreso";
            this.gcFechaIngreso.Name = "gcFechaIngreso";
            this.gcFechaIngreso.OptionsColumn.AllowEdit = false;
            this.gcFechaIngreso.OptionsColumn.AllowFocus = false;
            this.gcFechaIngreso.Visible = true;
            this.gcFechaIngreso.VisibleIndex = 9;
            this.gcFechaIngreso.Width = 100;
            // 
            // gcFechaVencimiento
            // 
            this.gcFechaVencimiento.Caption = "Fecha Vencimiento";
            this.gcFechaVencimiento.FieldName = "FechaVencimiento";
            this.gcFechaVencimiento.Name = "gcFechaVencimiento";
            this.gcFechaVencimiento.OptionsColumn.AllowEdit = false;
            this.gcFechaVencimiento.OptionsColumn.AllowFocus = false;
            this.gcFechaVencimiento.Visible = true;
            this.gcFechaVencimiento.VisibleIndex = 10;
            this.gcFechaVencimiento.Width = 100;
            // 
            // frmConExtintorVencer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 646);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmConExtintorVencer";
            this.Text = "frmConExtintorVencer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConExtintorVencer_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcExtintor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExtintor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolstpExportarExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolstpSalir;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcExtintor;
        private DevExpress.XtraGrid.Views.Grid.GridView gvExtintor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaIngreso;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaVencimiento;
        private DevExpress.XtraEditors.SpinEdit cboDias;
        public DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        public DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}