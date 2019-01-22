namespace SSOMA.Presentacion.Modulos.Inspeccion.Consultas
{
    partial class frmConInspeccionTrabajoPlaneada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConInspeccionTrabajoPlaneada));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.gcInspeccionTrabajoDetalle = new DevExpress.XtraGrid.GridControl();
            this.gvInspeccionTrabajoDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtCondicionSubEstandar = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtClasificacion = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtResponsable = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gcFechaEjecucion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtObservacion = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtSituacion = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInspeccionTrabajoDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInspeccionTrabajoDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCondicionSubEstandar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtClasificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtResponsable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtObservacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSituacion)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(1121, 27);
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
            this.splitContainerControl1.Panel2.Controls.Add(this.gcInspeccionTrabajoDetalle);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1121, 586);
            this.splitContainerControl1.SplitterPosition = 67;
            this.splitContainerControl1.TabIndex = 66;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.deFechaHasta);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.deFechaDesde);
            this.groupControl1.Controls.Add(this.lblFecha);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1121, 67);
            this.groupControl1.TabIndex = 30;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(311, 36);
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
            this.labelControl1.Location = new System.Drawing.Point(226, 40);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 16);
            this.labelControl1.TabIndex = 57;
            this.labelControl1.Text = "Fecha Desde: ";
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(92, 36);
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
            this.lblFecha.Location = new System.Drawing.Point(6, 40);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(82, 16);
            this.lblFecha.TabIndex = 55;
            this.lblFecha.Text = "Fecha Desde: ";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(442, 36);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(85, 25);
            this.btnConsultar.TabIndex = 54;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // gcInspeccionTrabajoDetalle
            // 
            this.gcInspeccionTrabajoDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcInspeccionTrabajoDetalle.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcInspeccionTrabajoDetalle.Location = new System.Drawing.Point(0, 0);
            this.gcInspeccionTrabajoDetalle.MainView = this.gvInspeccionTrabajoDetalle;
            this.gcInspeccionTrabajoDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcInspeccionTrabajoDetalle.Name = "gcInspeccionTrabajoDetalle";
            this.gcInspeccionTrabajoDetalle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtClasificacion,
            this.gcTxtResponsable,
            this.gcTxtSituacion,
            this.gcTxtCondicionSubEstandar,
            this.gcTxtObservacion});
            this.gcInspeccionTrabajoDetalle.Size = new System.Drawing.Size(1121, 513);
            this.gcInspeccionTrabajoDetalle.TabIndex = 80;
            this.gcInspeccionTrabajoDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInspeccionTrabajoDetalle});
            // 
            // gvInspeccionTrabajoDetalle
            // 
            this.gvInspeccionTrabajoDetalle.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gvInspeccionTrabajoDetalle.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvInspeccionTrabajoDetalle.Appearance.ViewCaption.Options.UseFont = true;
            this.gvInspeccionTrabajoDetalle.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvInspeccionTrabajoDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn9,
            this.gridColumn8,
            this.gridColumn7,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn18,
            this.gcFechaEjecucion,
            this.gridColumn6,
            this.gridColumn2,
            this.gridColumn21});
            this.gvInspeccionTrabajoDetalle.GridControl = this.gcInspeccionTrabajoDetalle;
            this.gvInspeccionTrabajoDetalle.Name = "gvInspeccionTrabajoDetalle";
            this.gvInspeccionTrabajoDetalle.OptionsSelection.MultiSelect = true;
            this.gvInspeccionTrabajoDetalle.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvInspeccionTrabajoDetalle.OptionsView.ColumnAutoWidth = false;
            this.gvInspeccionTrabajoDetalle.OptionsView.RowAutoHeight = true;
            this.gvInspeccionTrabajoDetalle.OptionsView.ShowGroupPanel = false;
            this.gvInspeccionTrabajoDetalle.OptionsView.ShowViewCaption = true;
            this.gvInspeccionTrabajoDetalle.ViewCaption = "LISTADO DE INSPECCIONES INTERNAS DE SEGURIDAD Y SALUD EN EL TRABAJO PLANEADAS";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "N° Inspección";
            this.gridColumn10.FieldName = "Numero";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Fecha";
            this.gridColumn9.FieldName = "Fecha";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Hora";
            this.gridColumn8.DisplayFormat.FormatString = "t";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn8.FieldName = "Hora";
            this.gridColumn8.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Sede";
            this.gridColumn7.FieldName = "DescUnidadMinera";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Area Inspeccionada";
            this.gridColumn1.FieldName = "DescArea";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Foto";
            this.gridColumn3.FieldName = "Foto";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 250;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "Condición SubEstandar";
            this.gridColumn4.ColumnEdit = this.gcTxtCondicionSubEstandar;
            this.gridColumn4.FieldName = "CondicionSubEstandar";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 300;
            // 
            // gcTxtCondicionSubEstandar
            // 
            this.gcTxtCondicionSubEstandar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtCondicionSubEstandar.Name = "gcTxtCondicionSubEstandar";
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn5.Caption = "Acción Correctiva";
            this.gridColumn5.ColumnEdit = this.gcTxtClasificacion;
            this.gridColumn5.FieldName = "AccionCorrectiva";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 300;
            // 
            // gcTxtClasificacion
            // 
            this.gcTxtClasificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtClasificacion.Name = "gcTxtClasificacion";
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn18.Caption = "Responsable";
            this.gridColumn18.ColumnEdit = this.gcTxtResponsable;
            this.gridColumn18.FieldName = "Responsable";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 8;
            this.gridColumn18.Width = 200;
            // 
            // gcTxtResponsable
            // 
            this.gcTxtResponsable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtResponsable.Name = "gcTxtResponsable";
            // 
            // gcFechaEjecucion
            // 
            this.gcFechaEjecucion.AppearanceCell.Options.UseTextOptions = true;
            this.gcFechaEjecucion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcFechaEjecucion.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcFechaEjecucion.Caption = "Fecha Ejecución";
            this.gcFechaEjecucion.FieldName = "FechaEjecucion";
            this.gcFechaEjecucion.Name = "gcFechaEjecucion";
            this.gcFechaEjecucion.OptionsColumn.AllowEdit = false;
            this.gcFechaEjecucion.OptionsColumn.AllowFocus = false;
            this.gcFechaEjecucion.Visible = true;
            this.gcFechaEjecucion.VisibleIndex = 9;
            this.gcFechaEjecucion.Width = 80;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Foto Cumplimiento";
            this.gridColumn6.FieldName = "FotoCumplimiento";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 10;
            this.gridColumn6.Width = 250;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "Observación";
            this.gridColumn2.ColumnEdit = this.gcTxtObservacion;
            this.gridColumn2.FieldName = "Observacion";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 11;
            this.gridColumn2.Width = 300;
            // 
            // gcTxtObservacion
            // 
            this.gcTxtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtObservacion.Name = "gcTxtObservacion";
            // 
            // gridColumn21
            // 
            this.gridColumn21.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn21.AppearanceCell.Options.UseFont = true;
            this.gridColumn21.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn21.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn21.Caption = "Situación";
            this.gridColumn21.ColumnEdit = this.gcTxtSituacion;
            this.gridColumn21.FieldName = "DescSituacion";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.AllowFocus = false;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 12;
            this.gridColumn21.Width = 80;
            // 
            // gcTxtSituacion
            // 
            this.gcTxtSituacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtSituacion.Name = "gcTxtSituacion";
            // 
            // frmConInspeccionTrabajoPlaneada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 613);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmConInspeccionTrabajoPlaneada";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConInspeccionTrabajoPlaneada_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInspeccionTrabajoDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInspeccionTrabajoDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCondicionSubEstandar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtClasificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtResponsable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtObservacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSituacion)).EndInit();
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
        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraGrid.GridControl gcInspeccionTrabajoDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInspeccionTrabajoDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtCondicionSubEstandar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtClasificacion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaEjecucion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtObservacion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtSituacion;
    }
}