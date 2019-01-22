namespace SSOMA.Presentacion.Modulos.Epp.Consultas
{
    partial class frmConEPPVencido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConEPPVencido));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtResponsable = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.gcEpp = new DevExpress.XtraGrid.GridControl();
            this.gvEpp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaEntrega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEmpresaInvolucrada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnidadMineraResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAreaInvolucrada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaVencimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTipoEntrega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtResponsable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEpp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEpp)).BeginInit();
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
            this.toolStrip1.TabIndex = 63;
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
            this.splitContainerControl1.Panel2.Controls.Add(this.gcEpp);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1246, 619);
            this.splitContainerControl1.SplitterPosition = 52;
            this.splitContainerControl1.TabIndex = 64;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtResponsable);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1246, 52);
            this.groupControl1.TabIndex = 29;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // txtResponsable
            // 
            this.txtResponsable.Location = new System.Drawing.Point(97, 28);
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
            this.labelControl12.Location = new System.Drawing.Point(14, 32);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(77, 16);
            this.labelControl12.TabIndex = 159;
            this.labelControl12.Text = "Responsable:";
            // 
            // gcEpp
            // 
            this.gcEpp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEpp.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcEpp.Location = new System.Drawing.Point(0, 0);
            this.gcEpp.MainView = this.gvEpp;
            this.gcEpp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcEpp.Name = "gcEpp";
            this.gcEpp.Size = new System.Drawing.Size(1246, 561);
            this.gcEpp.TabIndex = 67;
            this.gcEpp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEpp});
            // 
            // gvEpp
            // 
            this.gvEpp.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvEpp.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvEpp.Appearance.ViewCaption.Options.UseFont = true;
            this.gvEpp.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvEpp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn8,
            this.gcFechaEntrega,
            this.gridColumn4,
            this.gridColumn1,
            this.gcEmpresaInvolucrada,
            this.gcUnidadMineraResponsable,
            this.gcAreaInvolucrada,
            this.gridColumn2,
            this.gridColumn5,
            this.gcFechaVencimiento,
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn10,
            this.gcTipoEntrega});
            this.gvEpp.GridControl = this.gcEpp;
            this.gvEpp.Name = "gvEpp";
            this.gvEpp.OptionsSelection.MultiSelect = true;
            this.gvEpp.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvEpp.OptionsView.ColumnAutoWidth = false;
            this.gvEpp.OptionsView.ShowGroupPanel = false;
            this.gvEpp.OptionsView.ShowViewCaption = true;
            this.gvEpp.ViewCaption = "LISTADO DE REGISTROS EPP\'S VENCIDOS";
            this.gvEpp.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvEpp_RowCellStyle);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdIncidente";
            this.gridColumn3.FieldName = "IdIncidente";
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
            // gcFechaEntrega
            // 
            this.gcFechaEntrega.Caption = "Fecha Entrega";
            this.gcFechaEntrega.FieldName = "Fecha";
            this.gcFechaEntrega.Name = "gcFechaEntrega";
            this.gcFechaEntrega.OptionsColumn.AllowEdit = false;
            this.gcFechaEntrega.OptionsColumn.AllowFocus = false;
            this.gcFechaEntrega.Visible = true;
            this.gcFechaEntrega.VisibleIndex = 1;
            this.gcFechaEntrega.Width = 80;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Responsable";
            this.gridColumn4.FieldName = "Responsable";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
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
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 140;
            // 
            // gcEmpresaInvolucrada
            // 
            this.gcEmpresaInvolucrada.Caption = "Empresa Responsable";
            this.gcEmpresaInvolucrada.FieldName = "EmpresaResponsable";
            this.gcEmpresaInvolucrada.Name = "gcEmpresaInvolucrada";
            this.gcEmpresaInvolucrada.OptionsColumn.AllowEdit = false;
            this.gcEmpresaInvolucrada.OptionsColumn.AllowFocus = false;
            this.gcEmpresaInvolucrada.Visible = true;
            this.gcEmpresaInvolucrada.VisibleIndex = 4;
            this.gcEmpresaInvolucrada.Width = 180;
            // 
            // gcUnidadMineraResponsable
            // 
            this.gcUnidadMineraResponsable.Caption = "Sede Responsable";
            this.gcUnidadMineraResponsable.FieldName = "UnidadMineraResponsable";
            this.gcUnidadMineraResponsable.Name = "gcUnidadMineraResponsable";
            this.gcUnidadMineraResponsable.OptionsColumn.AllowEdit = false;
            this.gcUnidadMineraResponsable.OptionsColumn.AllowFocus = false;
            this.gcUnidadMineraResponsable.Visible = true;
            this.gcUnidadMineraResponsable.VisibleIndex = 5;
            this.gcUnidadMineraResponsable.Width = 120;
            // 
            // gcAreaInvolucrada
            // 
            this.gcAreaInvolucrada.Caption = "Area Responsable";
            this.gcAreaInvolucrada.FieldName = "AreaResponsable";
            this.gcAreaInvolucrada.Name = "gcAreaInvolucrada";
            this.gcAreaInvolucrada.OptionsColumn.AllowEdit = false;
            this.gcAreaInvolucrada.OptionsColumn.AllowFocus = false;
            this.gcAreaInvolucrada.Visible = true;
            this.gcAreaInvolucrada.VisibleIndex = 6;
            this.gcAreaInvolucrada.Width = 120;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Coódigo";
            this.gridColumn2.FieldName = "Codigo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            this.gridColumn2.Width = 60;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Descripción";
            this.gridColumn5.FieldName = "DescEquipo";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 8;
            this.gridColumn5.Width = 250;
            // 
            // gcFechaVencimiento
            // 
            this.gcFechaVencimiento.Caption = "Fecha Vencimiento";
            this.gcFechaVencimiento.FieldName = "FechaVencimiento";
            this.gcFechaVencimiento.Name = "gcFechaVencimiento";
            this.gcFechaVencimiento.OptionsColumn.AllowEdit = false;
            this.gcFechaVencimiento.OptionsColumn.AllowFocus = false;
            this.gcFechaVencimiento.Visible = true;
            this.gcFechaVencimiento.VisibleIndex = 9;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Cant.";
            this.gridColumn7.FieldName = "Cantidad";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 10;
            this.gridColumn7.Width = 55;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Precio S/.";
            this.gridColumn9.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "Precio";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 11;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Total S/.";
            this.gridColumn10.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "Total";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 12;
            // 
            // gcTipoEntrega
            // 
            this.gcTipoEntrega.Caption = "Tipo Entrega";
            this.gcTipoEntrega.FieldName = "DescTipoEntrega";
            this.gcTipoEntrega.Name = "gcTipoEntrega";
            this.gcTipoEntrega.OptionsColumn.AllowEdit = false;
            this.gcTipoEntrega.OptionsColumn.AllowFocus = false;
            this.gcTipoEntrega.Visible = true;
            this.gcTipoEntrega.VisibleIndex = 13;
            // 
            // frmConEPPVencido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 646);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmConEPPVencido";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConEPPVencido_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtResponsable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEpp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEpp)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gcEpp;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEpp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcEmpresaInvolucrada;
        private DevExpress.XtraGrid.Columns.GridColumn gcAreaInvolucrada;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaVencimiento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gcTipoEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnidadMineraResponsable;
    }
}