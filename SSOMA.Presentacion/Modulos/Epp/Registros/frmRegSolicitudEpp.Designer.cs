﻿namespace SSOMA.Presentacion.Modulos.Epp.Registros
{
    partial class frmRegSolicitudEpp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegSolicitudEpp));
            this.tlbMenu = new SSOMA.Presentacion.ControlUser.UIToolBar();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
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
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSolicitudEpp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSolicitudEpp)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Margin = new System.Windows.Forms.Padding(5);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1202, 30);
            this.tlbMenu.TabIndex = 0;
            this.tlbMenu.NewClick += new SSOMA.Presentacion.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new SSOMA.Presentacion.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new SSOMA.Presentacion.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new SSOMA.Presentacion.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new SSOMA.Presentacion.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new SSOMA.Presentacion.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new SSOMA.Presentacion.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcSolicitudEpp);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1202, 616);
            this.splitContainerControl1.SplitterPosition = 59;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
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
            this.groupControl1.Size = new System.Drawing.Size(1202, 59);
            this.groupControl1.TabIndex = 26;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(601, 33);
            this.txtPeriodo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
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
            this.labelControl7.Location = new System.Drawing.Point(547, 37);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(50, 16);
            this.labelControl7.TabIndex = 59;
            this.labelControl7.Text = "Número:";
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(315, 33);
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
            this.labelControl1.Location = new System.Drawing.Point(230, 37);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 16);
            this.labelControl1.TabIndex = 57;
            this.labelControl1.Text = "Fecha Desde: ";
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(96, 33);
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
            this.lblFecha.Location = new System.Drawing.Point(10, 37);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(82, 16);
            this.lblFecha.TabIndex = 55;
            this.lblFecha.Text = "Fecha Desde: ";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(446, 33);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(85, 25);
            this.btnConsultar.TabIndex = 54;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // gcSolicitudEpp
            // 
            this.gcSolicitudEpp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSolicitudEpp.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcSolicitudEpp.Location = new System.Drawing.Point(0, 0);
            this.gcSolicitudEpp.MainView = this.gvSolicitudEpp;
            this.gcSolicitudEpp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcSolicitudEpp.Name = "gcSolicitudEpp";
            this.gcSolicitudEpp.Size = new System.Drawing.Size(1202, 551);
            this.gcSolicitudEpp.TabIndex = 65;
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
            this.gridColumn6,
            this.gridColumn5});
            this.gvSolicitudEpp.GridControl = this.gcSolicitudEpp;
            this.gvSolicitudEpp.Name = "gvSolicitudEpp";
            this.gvSolicitudEpp.OptionsSelection.MultiSelect = true;
            this.gvSolicitudEpp.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvSolicitudEpp.OptionsView.ColumnAutoWidth = false;
            this.gvSolicitudEpp.OptionsView.ShowGroupPanel = false;
            this.gvSolicitudEpp.OptionsView.ShowViewCaption = true;
            this.gvSolicitudEpp.ViewCaption = "LISTADO DE REGISTROS DE SOLICITUDES DE EPPS";
            this.gvSolicitudEpp.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvSolicitudEpp_RowCellStyle);
            this.gvSolicitudEpp.DoubleClick += new System.EventHandler(this.gvSolicitudEpp_DoubleClick);
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
            this.gcFechaSolicitud.Width = 80;
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
            this.gridColumn2.Width = 240;
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
            this.gridColumn1.Width = 200;
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
            this.gcAreaResponsable.Width = 180;
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
            this.gridColumn5.VisibleIndex = 8;
            this.gridColumn5.Width = 80;
            // 
            // frmRegSolicitudEpp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 646);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.tlbMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmRegSolicitudEpp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRegSolicitudEpp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSolicitudEpp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSolicitudEpp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraGrid.GridControl gcSolicitudEpp;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSolicitudEpp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaSolicitud;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcEmpresaResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn gcAreaResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnidadMineraResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}