namespace SSOMA.Presentacion.Modulos.Medico.Consultas
{
    partial class frmConSolicitudEPS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConSolicitudEPS));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSolicitante = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.gcSolicitud = new DevExpress.XtraGrid.GridControl();
            this.gvSolicitud = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaSolicitud = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEmpresaResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnidadMineraResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAreaResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSolicitante.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSolicitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSolicitud)).BeginInit();
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
            this.toolStrip1.TabIndex = 64;
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
            this.splitContainerControl1.Panel2.Controls.Add(this.gcSolicitud);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1246, 619);
            this.splitContainerControl1.SplitterPosition = 54;
            this.splitContainerControl1.TabIndex = 65;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cboEmpresa);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtSolicitante);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1246, 54);
            this.groupControl1.TabIndex = 29;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Location = new System.Drawing.Point(84, 30);
            this.cboEmpresa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Properties.NullText = "";
            this.cboEmpresa.Size = new System.Drawing.Size(298, 22);
            this.cboEmpresa.TabIndex = 162;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 34);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 16);
            this.labelControl1.TabIndex = 161;
            this.labelControl1.Text = "Empresa:";
            // 
            // txtSolicitante
            // 
            this.txtSolicitante.Location = new System.Drawing.Point(612, 30);
            this.txtSolicitante.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSolicitante.Name = "txtSolicitante";
            this.txtSolicitante.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSolicitante.Properties.MaxLength = 100;
            this.txtSolicitante.Size = new System.Drawing.Size(393, 22);
            this.txtSolicitante.TabIndex = 160;
            this.txtSolicitante.EditValueChanged += new System.EventHandler(this.txtSolicitante_EditValueChanged);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(529, 33);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(64, 16);
            this.labelControl12.TabIndex = 159;
            this.labelControl12.Text = "Solicitante:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(388, 28);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(85, 25);
            this.btnConsultar.TabIndex = 54;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // gcSolicitud
            // 
            this.gcSolicitud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSolicitud.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcSolicitud.Location = new System.Drawing.Point(0, 0);
            this.gcSolicitud.MainView = this.gvSolicitud;
            this.gcSolicitud.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcSolicitud.Name = "gcSolicitud";
            this.gcSolicitud.Size = new System.Drawing.Size(1246, 559);
            this.gcSolicitud.TabIndex = 66;
            this.gcSolicitud.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSolicitud});
            // 
            // gvSolicitud
            // 
            this.gvSolicitud.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvSolicitud.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvSolicitud.Appearance.ViewCaption.Options.UseFont = true;
            this.gvSolicitud.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvSolicitud.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn8,
            this.gcFechaSolicitud,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn4,
            this.gcEmpresaResponsable,
            this.gcUnidadMineraResponsable,
            this.gcAreaResponsable,
            this.gridColumn6,
            this.gridColumn5});
            this.gvSolicitud.GridControl = this.gcSolicitud;
            this.gvSolicitud.Name = "gvSolicitud";
            this.gvSolicitud.OptionsSelection.MultiSelect = true;
            this.gvSolicitud.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvSolicitud.OptionsView.ColumnAutoWidth = false;
            this.gvSolicitud.OptionsView.ShowGroupPanel = false;
            this.gvSolicitud.OptionsView.ShowViewCaption = true;
            this.gvSolicitud.ViewCaption = "LISTADO DE REGISTROS DE SOLICITUDES DE INFORMACIÓN DE EPS";
            this.gvSolicitud.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvSolicitud_RowCellStyle);
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
            this.gcFechaSolicitud.Width = 90;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Solicitante";
            this.gridColumn2.FieldName = "Solicitante";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 300;
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
            this.gridColumn1.Width = 200;
            // 
            // gcEmpresaResponsable
            // 
            this.gcEmpresaResponsable.Caption = "Empresa";
            this.gcEmpresaResponsable.FieldName = "RazonSocial";
            this.gcEmpresaResponsable.Name = "gcEmpresaResponsable";
            this.gcEmpresaResponsable.OptionsColumn.AllowEdit = false;
            this.gcEmpresaResponsable.OptionsColumn.AllowFocus = false;
            this.gcEmpresaResponsable.Visible = true;
            this.gcEmpresaResponsable.VisibleIndex = 5;
            this.gcEmpresaResponsable.Width = 180;
            // 
            // gcUnidadMineraResponsable
            // 
            this.gcUnidadMineraResponsable.Caption = "Sede";
            this.gcUnidadMineraResponsable.FieldName = "DescUnidadMinera";
            this.gcUnidadMineraResponsable.Name = "gcUnidadMineraResponsable";
            this.gcUnidadMineraResponsable.OptionsColumn.AllowEdit = false;
            this.gcUnidadMineraResponsable.OptionsColumn.AllowFocus = false;
            this.gcUnidadMineraResponsable.Visible = true;
            this.gcUnidadMineraResponsable.VisibleIndex = 6;
            this.gcUnidadMineraResponsable.Width = 130;
            // 
            // gcAreaResponsable
            // 
            this.gcAreaResponsable.Caption = "Area";
            this.gcAreaResponsable.FieldName = "DescArea";
            this.gcAreaResponsable.Name = "gcAreaResponsable";
            this.gcAreaResponsable.OptionsColumn.AllowEdit = false;
            this.gcAreaResponsable.OptionsColumn.AllowFocus = false;
            this.gcAreaResponsable.Visible = true;
            this.gcAreaResponsable.VisibleIndex = 7;
            this.gcAreaResponsable.Width = 300;
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
            this.gridColumn5.FieldName = "DescSituacion";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 8;
            this.gridColumn5.Width = 80;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Fecha Ingreso";
            this.gridColumn4.FieldName = "FechaIngreso";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 90;
            // 
            // frmConSolicitudEPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 646);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmConSolicitudEPS";
            this.Text = "Consulta de Solicitud de Información de EPS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConSolicitudEPS_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSolicitante.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSolicitud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSolicitud)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtSolicitante;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraGrid.GridControl gcSolicitud;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSolicitud;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaSolicitud;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcEmpresaResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnidadMineraResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn gcAreaResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        public DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}