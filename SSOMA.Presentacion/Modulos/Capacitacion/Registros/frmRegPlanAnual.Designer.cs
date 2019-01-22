namespace SSOMA.Presentacion.Modulos.Capacitacion.Registros
{
    partial class frmRegPlanAnual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegPlanAnual));
            this.tlbMenu = new SSOMA.Presentacion.ControlUser.UIToolBar();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.cboUnidadMinera = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.txtPeriodo = new DevExpress.XtraEditors.SpinEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.gcPlanAnual = new DevExpress.XtraGrid.GridControl();
            this.gvPlanAnual = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEmpresaInvolucrada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.picImage = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnidadMinera.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPlanAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlanAnual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Margin = new System.Windows.Forms.Padding(5);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1279, 30);
            this.tlbMenu.TabIndex = 32;
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
            this.splitContainerControl1.Panel2.Controls.Add(this.gcPlanAnual);
            this.splitContainerControl1.Panel2.Controls.Add(this.picImage);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1279, 627);
            this.splitContainerControl1.SplitterPosition = 53;
            this.splitContainerControl1.TabIndex = 33;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Controls.Add(this.cboUnidadMinera);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.cboEmpresa);
            this.groupControl1.Controls.Add(this.labelControl17);
            this.groupControl1.Controls.Add(this.txtPeriodo);
            this.groupControl1.Controls.Add(this.lblFecha);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1279, 53);
            this.groupControl1.TabIndex = 26;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(951, 29);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(95, 26);
            this.btnConsultar.TabIndex = 193;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cboUnidadMinera
            // 
            this.cboUnidadMinera.Location = new System.Drawing.Point(509, 31);
            this.cboUnidadMinera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboUnidadMinera.Name = "cboUnidadMinera";
            this.cboUnidadMinera.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUnidadMinera.Properties.NullText = "";
            this.cboUnidadMinera.Size = new System.Drawing.Size(298, 22);
            this.cboUnidadMinera.TabIndex = 192;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(469, 34);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 16);
            this.labelControl4.TabIndex = 191;
            this.labelControl4.Text = "Sede:";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Location = new System.Drawing.Point(71, 31);
            this.cboEmpresa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Properties.NullText = "";
            this.cboEmpresa.Size = new System.Drawing.Size(392, 22);
            this.cboEmpresa.TabIndex = 190;
            this.cboEmpresa.EditValueChanged += new System.EventHandler(this.cboEmpresa_EditValueChanged);
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(8, 34);
            this.labelControl17.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(55, 16);
            this.labelControl17.TabIndex = 189;
            this.labelControl17.Text = "Empresa:";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.EditValue = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.txtPeriodo.Location = new System.Drawing.Point(872, 31);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPeriodo.Properties.MaxValue = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.txtPeriodo.Properties.MinValue = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.txtPeriodo.Size = new System.Drawing.Size(73, 22);
            this.txtPeriodo.TabIndex = 188;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(818, 34);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(48, 16);
            this.lblFecha.TabIndex = 56;
            this.lblFecha.Text = "Periodo:";
            // 
            // gcPlanAnual
            // 
            this.gcPlanAnual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPlanAnual.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcPlanAnual.Location = new System.Drawing.Point(0, 0);
            this.gcPlanAnual.MainView = this.gvPlanAnual;
            this.gcPlanAnual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcPlanAnual.Name = "gcPlanAnual";
            this.gcPlanAnual.Size = new System.Drawing.Size(1279, 568);
            this.gcPlanAnual.TabIndex = 65;
            this.gcPlanAnual.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPlanAnual});
            // 
            // gvPlanAnual
            // 
            this.gvPlanAnual.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvPlanAnual.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvPlanAnual.Appearance.ViewCaption.Options.UseFont = true;
            this.gvPlanAnual.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvPlanAnual.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn2,
            this.gridColumn6,
            this.gridColumn9,
            this.gridColumn8,
            this.gridColumn13,
            this.gcEmpresaInvolucrada,
            this.gridColumn1});
            this.gvPlanAnual.GridControl = this.gcPlanAnual;
            this.gvPlanAnual.Name = "gvPlanAnual";
            this.gvPlanAnual.OptionsSelection.MultiSelect = true;
            this.gvPlanAnual.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvPlanAnual.OptionsView.ColumnAutoWidth = false;
            this.gvPlanAnual.OptionsView.ShowGroupPanel = false;
            this.gvPlanAnual.OptionsView.ShowViewCaption = true;
            this.gvPlanAnual.ViewCaption = "PROGRAMA ANUAL DE CAPACITACIONES DE SEGURIDAD Y SALUD EN EL TRABAJO";
            this.gvPlanAnual.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvPlanAnual_RowCellStyle);
            this.gvPlanAnual.DoubleClick += new System.EventHandler(this.gvPlanAnual_DoubleClick);
            this.gvPlanAnual.Layout += new System.EventHandler(this.gvPlanAnual_Layout);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdPlanAnual";
            this.gridColumn3.FieldName = "IdPlanAnual";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tema";
            this.gridColumn4.FieldName = "DescTema";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 400;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.Caption = "Tipo";
            this.gridColumn2.FieldName = "DescTipoCapacitacion";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 120;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Clase";
            this.gridColumn6.FieldName = "DescClaseCapacitacion";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 100;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Lugar\\Sede";
            this.gridColumn9.FieldName = "DescLugar";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            this.gridColumn9.Width = 200;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Responsable";
            this.gridColumn8.FieldName = "DescResponsableCapacitacion";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 150;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "F. Cumplimiento";
            this.gridColumn13.FieldName = "FechaCumplimiento";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 5;
            this.gridColumn13.Width = 90;
            // 
            // gcEmpresaInvolucrada
            // 
            this.gcEmpresaInvolucrada.Caption = "Costo S/.";
            this.gcEmpresaInvolucrada.DisplayFormat.FormatString = "#,0.00";
            this.gcEmpresaInvolucrada.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcEmpresaInvolucrada.FieldName = "Costo";
            this.gcEmpresaInvolucrada.Name = "gcEmpresaInvolucrada";
            this.gcEmpresaInvolucrada.OptionsColumn.AllowEdit = false;
            this.gcEmpresaInvolucrada.OptionsColumn.AllowFocus = false;
            this.gcEmpresaInvolucrada.Visible = true;
            this.gcEmpresaInvolucrada.VisibleIndex = 6;
            this.gcEmpresaInvolucrada.Width = 90;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Situación";
            this.gridColumn1.FieldName = "DescSituacion";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            this.gridColumn1.Width = 80;
            // 
            // picImage
            // 
            this.picImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.picImage.Location = new System.Drawing.Point(483, 91);
            this.picImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picImage.Name = "picImage";
            this.picImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.picImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picImage.Properties.ZoomAccelerationFactor = 1D;
            this.picImage.Size = new System.Drawing.Size(313, 386);
            this.picImage.TabIndex = 68;
            // 
            // frmRegPlanAnual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 657);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.tlbMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmRegPlanAnual";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRegPlanAnual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnidadMinera.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPlanAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlanAnual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraGrid.GridControl gcPlanAnual;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPlanAnual;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gcEmpresaInvolucrada;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SpinEdit txtPeriodo;
        public DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        public DevExpress.XtraEditors.LookUpEdit cboUnidadMinera;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.PictureEdit picImage;
    }
}