namespace SSOMA.Presentacion.Modulos.Accidente.Consultas
{
    partial class frmConAccidenteMortales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConAccidenteMortales));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboEmpresaResponsable = new DevExpress.XtraEditors.LookUpEdit();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.gcAccidente = new DevExpress.XtraGrid.GridControl();
            this.gvAccidente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaEntrega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEmpresaInvolucrada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSedeResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAreaInvolucrada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProbabilidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGrado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCostoEstimado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresaResponsable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAccidente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccidente)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(1368, 27);
            this.toolStrip1.TabIndex = 65;
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
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcAccidente);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1368, 728);
            this.splitContainerControl1.SplitterPosition = 69;
            this.splitContainerControl1.TabIndex = 66;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.cboEmpresaResponsable);
            this.groupControl1.Controls.Add(this.txtPeriodo);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.deFechaHasta);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.deFechaDesde);
            this.groupControl1.Controls.Add(this.lblFecha);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1368, 69);
            this.groupControl1.TabIndex = 30;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 38);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(131, 16);
            this.labelControl2.TabIndex = 62;
            this.labelControl2.Text = "Empresa Responsable:";
            // 
            // cboEmpresaResponsable
            // 
            this.cboEmpresaResponsable.Location = new System.Drawing.Point(143, 36);
            this.cboEmpresaResponsable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboEmpresaResponsable.Name = "cboEmpresaResponsable";
            this.cboEmpresaResponsable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresaResponsable.Properties.NullText = "";
            this.cboEmpresaResponsable.Size = new System.Drawing.Size(298, 22);
            this.cboEmpresaResponsable.TabIndex = 61;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(1038, 35);
            this.txtPeriodo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(86, 22);
            this.txtPeriodo.TabIndex = 60;
            this.txtPeriodo.ToolTip = "Numero de Incidente";
            this.txtPeriodo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPeriodo_KeyUp);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(984, 39);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(50, 16);
            this.labelControl7.TabIndex = 59;
            this.labelControl7.Text = "Número:";
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(752, 35);
            this.deFechaHasta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(124, 22);
            this.deFechaHasta.TabIndex = 58;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(667, 39);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 16);
            this.labelControl1.TabIndex = 57;
            this.labelControl1.Text = "Fecha Desde: ";
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(533, 35);
            this.deFechaDesde.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(124, 22);
            this.deFechaDesde.TabIndex = 56;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(447, 39);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(82, 16);
            this.lblFecha.TabIndex = 55;
            this.lblFecha.Text = "Fecha Desde: ";
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(883, 35);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(85, 25);
            this.btnConsultar.TabIndex = 54;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // gcAccidente
            // 
            this.gcAccidente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAccidente.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcAccidente.Location = new System.Drawing.Point(0, 0);
            this.gcAccidente.MainView = this.gvAccidente;
            this.gcAccidente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcAccidente.Name = "gcAccidente";
            this.gcAccidente.Size = new System.Drawing.Size(1368, 653);
            this.gcAccidente.TabIndex = 69;
            this.gcAccidente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAccidente});
            // 
            // gvAccidente
            // 
            this.gvAccidente.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAccidente.Appearance.FooterPanel.Options.UseFont = true;
            this.gvAccidente.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvAccidente.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvAccidente.Appearance.ViewCaption.Options.UseFont = true;
            this.gvAccidente.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvAccidente.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn2,
            this.gcFechaEntrega,
            this.gridColumn8,
            this.gridColumn4,
            this.gridColumn1,
            this.gcEmpresaInvolucrada,
            this.gcSedeResponsable,
            this.gcAreaInvolucrada,
            this.gcProbabilidad,
            this.gcGrado,
            this.gcCostoEstimado});
            this.gvAccidente.GridControl = this.gcAccidente;
            this.gvAccidente.Name = "gvAccidente";
            this.gvAccidente.OptionsSelection.MultiSelect = true;
            this.gvAccidente.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvAccidente.OptionsView.ColumnAutoWidth = false;
            this.gvAccidente.OptionsView.ShowGroupPanel = false;
            this.gvAccidente.OptionsView.ShowViewCaption = true;
            this.gvAccidente.ViewCaption = "LISTADO DE ACCIDENTES DE TRABAJO MORTALES";
            this.gvAccidente.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvAccidente_RowCellStyle);
            this.gvAccidente.Layout += new System.EventHandler(this.gvAccidente_Layout);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdAccidente";
            this.gridColumn3.FieldName = "IdAccidente";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Daño";
            this.gridColumn5.FieldName = "DescDanio";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 90;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "N° Accidente";
            this.gridColumn2.FieldName = "Numero";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 80;
            // 
            // gcFechaEntrega
            // 
            this.gcFechaEntrega.Caption = "Fecha";
            this.gcFechaEntrega.FieldName = "Fecha";
            this.gcFechaEntrega.Name = "gcFechaEntrega";
            this.gcFechaEntrega.OptionsColumn.AllowEdit = false;
            this.gcFechaEntrega.OptionsColumn.AllowFocus = false;
            this.gcFechaEntrega.Visible = true;
            this.gcFechaEntrega.VisibleIndex = 2;
            this.gcFechaEntrega.Width = 80;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Hora";
            this.gridColumn8.DisplayFormat.FormatString = "t";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn8.FieldName = "Hora";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 65;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Accidentado";
            this.gridColumn4.FieldName = "Responsable";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 250;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Cargo";
            this.gridColumn1.FieldName = "Cargo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            this.gridColumn1.Width = 180;
            // 
            // gcEmpresaInvolucrada
            // 
            this.gcEmpresaInvolucrada.Caption = "Empresa Responsable";
            this.gcEmpresaInvolucrada.FieldName = "EmpresaResponsable";
            this.gcEmpresaInvolucrada.Name = "gcEmpresaInvolucrada";
            this.gcEmpresaInvolucrada.OptionsColumn.AllowEdit = false;
            this.gcEmpresaInvolucrada.OptionsColumn.AllowFocus = false;
            this.gcEmpresaInvolucrada.Visible = true;
            this.gcEmpresaInvolucrada.VisibleIndex = 6;
            this.gcEmpresaInvolucrada.Width = 180;
            // 
            // gcSedeResponsable
            // 
            this.gcSedeResponsable.Caption = "Sede Responsable";
            this.gcSedeResponsable.FieldName = "UnidadMineraResponsable";
            this.gcSedeResponsable.Name = "gcSedeResponsable";
            this.gcSedeResponsable.OptionsColumn.AllowEdit = false;
            this.gcSedeResponsable.OptionsColumn.AllowFocus = false;
            this.gcSedeResponsable.Visible = true;
            this.gcSedeResponsable.VisibleIndex = 7;
            this.gcSedeResponsable.Width = 90;
            // 
            // gcAreaInvolucrada
            // 
            this.gcAreaInvolucrada.Caption = "Area Responsable";
            this.gcAreaInvolucrada.FieldName = "AreaResponsable";
            this.gcAreaInvolucrada.Name = "gcAreaInvolucrada";
            this.gcAreaInvolucrada.OptionsColumn.AllowEdit = false;
            this.gcAreaInvolucrada.OptionsColumn.AllowFocus = false;
            this.gcAreaInvolucrada.Visible = true;
            this.gcAreaInvolucrada.VisibleIndex = 8;
            this.gcAreaInvolucrada.Width = 210;
            // 
            // gcProbabilidad
            // 
            this.gcProbabilidad.Caption = "Probabilidad  de Ocurrencia";
            this.gcProbabilidad.FieldName = "DescProbabilidadOcurrencia";
            this.gcProbabilidad.Name = "gcProbabilidad";
            this.gcProbabilidad.OptionsColumn.AllowEdit = false;
            this.gcProbabilidad.OptionsColumn.AllowFocus = false;
            this.gcProbabilidad.Visible = true;
            this.gcProbabilidad.VisibleIndex = 9;
            this.gcProbabilidad.Width = 90;
            // 
            // gcGrado
            // 
            this.gcGrado.Caption = "Grado del Accidente";
            this.gcGrado.FieldName = "DescGradoAccidente";
            this.gcGrado.Name = "gcGrado";
            this.gcGrado.OptionsColumn.AllowEdit = false;
            this.gcGrado.OptionsColumn.AllowFocus = false;
            this.gcGrado.Visible = true;
            this.gcGrado.VisibleIndex = 10;
            this.gcGrado.Width = 110;
            // 
            // gcCostoEstimado
            // 
            this.gcCostoEstimado.Caption = "Costo Estimado S/.";
            this.gcCostoEstimado.DisplayFormat.FormatString = "#,0.00";
            this.gcCostoEstimado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcCostoEstimado.FieldName = "CostoTotal";
            this.gcCostoEstimado.Name = "gcCostoEstimado";
            this.gcCostoEstimado.OptionsColumn.AllowEdit = false;
            this.gcCostoEstimado.OptionsColumn.AllowFocus = false;
            this.gcCostoEstimado.Visible = true;
            this.gcCostoEstimado.VisibleIndex = 11;
            this.gcCostoEstimado.Width = 120;
            // 
            // frmConAccidenteMortales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 755);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmConAccidenteMortales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConAccidenteMortales_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresaResponsable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAccidente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccidente)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LookUpEdit cboEmpresaResponsable;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraGrid.GridControl gcAccidente;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAccidente;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcEmpresaInvolucrada;
        private DevExpress.XtraGrid.Columns.GridColumn gcSedeResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn gcAreaInvolucrada;
        private DevExpress.XtraGrid.Columns.GridColumn gcProbabilidad;
        private DevExpress.XtraGrid.Columns.GridColumn gcGrado;
        private DevExpress.XtraGrid.Columns.GridColumn gcCostoEstimado;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}