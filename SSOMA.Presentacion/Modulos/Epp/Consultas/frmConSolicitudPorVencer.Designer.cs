namespace SSOMA.Presentacion.Modulos.Epp.Consultas
{
    partial class frmConSolicitudPorVencer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConSolicitudPorVencer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtJefe = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtResponsable = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.gcSolicitudEpp = new DevExpress.XtraGrid.GridControl();
            this.gvSolicitudEpp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaSolicitud = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEmpresaResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnidadMineraResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAreaResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSectorResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtJefe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResponsable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSolicitudEpp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSolicitudEpp)).BeginInit();
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
            this.splitContainerControl1.Panel2.Controls.Add(this.gcSolicitudEpp);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1246, 619);
            this.splitContainerControl1.SplitterPosition = 57;
            this.splitContainerControl1.TabIndex = 63;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtJefe);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtResponsable);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1246, 57);
            this.groupControl1.TabIndex = 28;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // txtJefe
            // 
            this.txtJefe.Location = new System.Drawing.Point(120, 30);
            this.txtJefe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtJefe.Name = "txtJefe";
            this.txtJefe.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtJefe.Properties.MaxLength = 100;
            this.txtJefe.Size = new System.Drawing.Size(393, 22);
            this.txtJefe.TabIndex = 162;
            this.txtJefe.EditValueChanged += new System.EventHandler(this.txtJefe_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 33);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 16);
            this.labelControl1.TabIndex = 161;
            this.labelControl1.Text = "Solicitante:";
            // 
            // txtResponsable
            // 
            this.txtResponsable.Location = new System.Drawing.Point(615, 30);
            this.txtResponsable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtResponsable.Name = "txtResponsable";
            this.txtResponsable.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtResponsable.Properties.MaxLength = 100;
            this.txtResponsable.Size = new System.Drawing.Size(393, 22);
            this.txtResponsable.TabIndex = 160;
            this.txtResponsable.EditValueChanged += new System.EventHandler(this.txtResponsable_EditValueChanged);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(532, 33);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(77, 16);
            this.labelControl12.TabIndex = 159;
            this.labelControl12.Text = "Responsable:";
            // 
            // gcSolicitudEpp
            // 
            this.gcSolicitudEpp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSolicitudEpp.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcSolicitudEpp.Location = new System.Drawing.Point(0, 0);
            this.gcSolicitudEpp.MainView = this.gvSolicitudEpp;
            this.gcSolicitudEpp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcSolicitudEpp.Name = "gcSolicitudEpp";
            this.gcSolicitudEpp.Size = new System.Drawing.Size(1246, 556);
            this.gcSolicitudEpp.TabIndex = 66;
            this.gcSolicitudEpp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSolicitudEpp});
            // 
            // gvSolicitudEpp
            // 
            this.gvSolicitudEpp.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvSolicitudEpp.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvSolicitudEpp.Appearance.ViewCaption.Options.UseFont = true;
            this.gvSolicitudEpp.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvSolicitudEpp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn8,
            this.gcFechaSolicitud,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn1,
            this.gcEmpresaResponsable,
            this.gcUnidadMineraResponsable,
            this.gcAreaResponsable,
            this.gcSectorResponsable,
            this.gridColumn6,
            this.gridColumn5,
            this.gcDias});
            this.gvSolicitudEpp.GridControl = this.gcSolicitudEpp;
            this.gvSolicitudEpp.Name = "gvSolicitudEpp";
            this.gvSolicitudEpp.OptionsSelection.MultiSelect = true;
            this.gvSolicitudEpp.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvSolicitudEpp.OptionsView.ColumnAutoWidth = false;
            this.gvSolicitudEpp.OptionsView.ShowGroupPanel = false;
            this.gvSolicitudEpp.OptionsView.ShowViewCaption = true;
            this.gvSolicitudEpp.ViewCaption = "LISTADO DE SOLICITUDES DE EPPS POR VENCER";
            this.gvSolicitudEpp.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvSolicitudEpp_RowCellStyle);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdSolicitudEpp";
            this.gridColumn3.FieldName = "IdSolicitudEpp";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Número";
            this.gridColumn8.FieldName = "Numero";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 65;
            // 
            // gcFechaSolicitud
            // 
            this.gcFechaSolicitud.Caption = "Fecha Solicitud";
            this.gcFechaSolicitud.FieldName = "Fecha";
            this.gcFechaSolicitud.Name = "gcFechaSolicitud";
            this.gcFechaSolicitud.OptionsColumn.AllowEdit = false;
            this.gcFechaSolicitud.OptionsColumn.AllowFocus = false;
            this.gcFechaSolicitud.Visible = true;
            this.gcFechaSolicitud.VisibleIndex = 1;
            this.gcFechaSolicitud.Width = 70;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Solicitante";
            this.gridColumn2.FieldName = "Jefe";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 230;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Responsable";
            this.gridColumn4.FieldName = "Responsable";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
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
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 150;
            // 
            // gcEmpresaResponsable
            // 
            this.gcEmpresaResponsable.Caption = "Empresa Responsable";
            this.gcEmpresaResponsable.FieldName = "EmpresaResponsable";
            this.gcEmpresaResponsable.Name = "gcEmpresaResponsable";
            this.gcEmpresaResponsable.OptionsColumn.AllowEdit = false;
            this.gcEmpresaResponsable.OptionsColumn.AllowFocus = false;
            this.gcEmpresaResponsable.Visible = true;
            this.gcEmpresaResponsable.VisibleIndex = 5;
            this.gcEmpresaResponsable.Width = 180;
            // 
            // gcUnidadMineraResponsable
            // 
            this.gcUnidadMineraResponsable.Caption = "Sede Responsable";
            this.gcUnidadMineraResponsable.FieldName = "UnidadMineraResponsable";
            this.gcUnidadMineraResponsable.Name = "gcUnidadMineraResponsable";
            this.gcUnidadMineraResponsable.OptionsColumn.AllowEdit = false;
            this.gcUnidadMineraResponsable.OptionsColumn.AllowFocus = false;
            this.gcUnidadMineraResponsable.Visible = true;
            this.gcUnidadMineraResponsable.VisibleIndex = 6;
            this.gcUnidadMineraResponsable.Width = 130;
            // 
            // gcAreaResponsable
            // 
            this.gcAreaResponsable.Caption = "Area Responsable";
            this.gcAreaResponsable.FieldName = "AreaResponsable";
            this.gcAreaResponsable.Name = "gcAreaResponsable";
            this.gcAreaResponsable.OptionsColumn.AllowEdit = false;
            this.gcAreaResponsable.OptionsColumn.AllowFocus = false;
            this.gcAreaResponsable.Visible = true;
            this.gcAreaResponsable.VisibleIndex = 7;
            this.gcAreaResponsable.Width = 130;
            // 
            // gcSectorResponsable
            // 
            this.gcSectorResponsable.Caption = "Sector Responsable";
            this.gcSectorResponsable.FieldName = "SectorResponsable";
            this.gcSectorResponsable.Name = "gcSectorResponsable";
            this.gcSectorResponsable.OptionsColumn.AllowEdit = false;
            this.gcSectorResponsable.OptionsColumn.AllowFocus = false;
            this.gcSectorResponsable.Visible = true;
            this.gcSectorResponsable.VisibleIndex = 8;
            this.gcSectorResponsable.Width = 130;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "IdSituacion";
            this.gridColumn6.FieldName = "IdSituacion";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.Caption = "Situación";
            this.gridColumn5.FieldName = "Situacion";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 9;
            this.gridColumn5.Width = 70;
            // 
            // gcDias
            // 
            this.gcDias.Caption = "Dias Por Vencer";
            this.gcDias.FieldName = "Dias";
            this.gcDias.Name = "gcDias";
            this.gcDias.OptionsColumn.AllowEdit = false;
            this.gcDias.OptionsColumn.AllowFocus = false;
            this.gcDias.Visible = true;
            this.gcDias.VisibleIndex = 10;
            this.gcDias.Width = 60;
            // 
            // frmConSolicitudPorVencer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 646);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmConSolicitudPorVencer";
            this.Text = "Consulta de Solicitud Por Vender";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConSolicitudPorVencer_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtJefe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResponsable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSolicitudEpp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSolicitudEpp)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtResponsable;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtJefe;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gcSolicitudEpp;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSolicitudEpp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaSolicitud;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcEmpresaResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnidadMineraResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn gcAreaResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gcDias;
        private DevExpress.XtraGrid.Columns.GridColumn gcSectorResponsable;
    }
}