namespace SSOMA.Presentacion.Modulos.Epp.Registros
{
    partial class frmRegEpp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegEpp));
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
            this.gcEpp = new DevExpress.XtraGrid.GridControl();
            this.gvEpp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaEntrega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEmpresaInvolucrada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSedeResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAreaInvolucrada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSectorResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEpp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEpp)).BeginInit();
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
            this.tlbMenu.TabIndex = 1;
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
            this.splitContainerControl1.Panel2.Controls.Add(this.gcEpp);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1202, 616);
            this.splitContainerControl1.SplitterPosition = 57;
            this.splitContainerControl1.TabIndex = 2;
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
            this.groupControl1.Size = new System.Drawing.Size(1202, 57);
            this.groupControl1.TabIndex = 26;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(601, 33);
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
            // gcEpp
            // 
            this.gcEpp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEpp.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcEpp.Location = new System.Drawing.Point(0, 0);
            this.gcEpp.MainView = this.gvEpp;
            this.gcEpp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcEpp.Name = "gcEpp";
            this.gcEpp.Size = new System.Drawing.Size(1202, 553);
            this.gcEpp.TabIndex = 65;
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
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn8,
            this.gcFechaEntrega,
            this.gridColumn4,
            this.gridColumn1,
            this.gcEmpresaInvolucrada,
            this.gcSedeResponsable,
            this.gcAreaInvolucrada,
            this.gcSectorResponsable});
            this.gvEpp.GridControl = this.gcEpp;
            this.gvEpp.Name = "gvEpp";
            this.gvEpp.OptionsSelection.MultiSelect = true;
            this.gvEpp.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvEpp.OptionsView.ColumnAutoWidth = false;
            this.gvEpp.OptionsView.ShowGroupPanel = false;
            this.gvEpp.OptionsView.ShowViewCaption = true;
            this.gvEpp.ViewCaption = "LISTADO DE REGISTROS DE ENTREGA DE EPPS";
            this.gvEpp.DoubleClick += new System.EventHandler(this.gvEpp_DoubleClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdEpp";
            this.gridColumn3.FieldName = "IdEpp";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdSolicitudEpp";
            this.gridColumn5.FieldName = "IdSolicitudEpp";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "N° Solicitud";
            this.gridColumn2.FieldName = "NumeroSolicitud";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "N° Entrega";
            this.gridColumn8.FieldName = "Numero";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
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
            this.gcFechaEntrega.VisibleIndex = 2;
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
            this.gcEmpresaInvolucrada.VisibleIndex = 5;
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
            this.gcSedeResponsable.VisibleIndex = 6;
            this.gcSedeResponsable.Width = 130;
            // 
            // gcAreaInvolucrada
            // 
            this.gcAreaInvolucrada.Caption = "Area Responsable";
            this.gcAreaInvolucrada.FieldName = "AreaResponsable";
            this.gcAreaInvolucrada.Name = "gcAreaInvolucrada";
            this.gcAreaInvolucrada.OptionsColumn.AllowEdit = false;
            this.gcAreaInvolucrada.OptionsColumn.AllowFocus = false;
            this.gcAreaInvolucrada.Visible = true;
            this.gcAreaInvolucrada.VisibleIndex = 7;
            this.gcAreaInvolucrada.Width = 230;
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
            this.gcSectorResponsable.Width = 230;
            // 
            // frmRegEpp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 646);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.tlbMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmRegEpp";
            this.Text = "Registro de Epps";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRegEpp_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.gcEpp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEpp)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gcEpp;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEpp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcEmpresaInvolucrada;
        private DevExpress.XtraGrid.Columns.GridColumn gcAreaInvolucrada;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gcSedeResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn gcSectorResponsable;
    }
}