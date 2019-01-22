namespace SSOMA.Presentacion.Modulos.Iperc.Maestros
{
    partial class frmManSeveridad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManSeveridad));
            this.tlbMenu = new SSOMA.Presentacion.ControlUser.UIToolBar();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcSeveridad = new DevExpress.XtraGrid.GridControl();
            this.gvSeveridad = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIndicePersona = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtClasificacion = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gcTxtResponsable = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gcTxtSituacion = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gcTxtCondicionSubEstandar = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gcTxtObservacion = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSeveridad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSeveridad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtClasificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtResponsable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSituacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCondicionSubEstandar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtObservacion)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(799, 30);
            this.tlbMenu.TabIndex = 34;
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
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcSeveridad);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(799, 316);
            this.splitContainerControl1.SplitterPosition = 63;
            this.splitContainerControl1.TabIndex = 35;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnBuscar);
            this.groupControl1.Controls.Add(this.txtDescripcion);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(799, 78);
            this.groupControl1.TabIndex = 34;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(451, 38);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(78, 26);
            this.btnBuscar.TabIndex = 29;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(83, 39);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(362, 22);
            this.txtDescripcion.TabIndex = 28;
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 43);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 16);
            this.labelControl1.TabIndex = 27;
            this.labelControl1.Text = "Descripción:";
            // 
            // gcSeveridad
            // 
            this.gcSeveridad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSeveridad.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcSeveridad.Location = new System.Drawing.Point(0, 0);
            this.gcSeveridad.MainView = this.gvSeveridad;
            this.gcSeveridad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcSeveridad.Name = "gcSeveridad";
            this.gcSeveridad.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtClasificacion,
            this.gcTxtResponsable,
            this.gcTxtSituacion,
            this.gcTxtCondicionSubEstandar,
            this.gcTxtObservacion});
            this.gcSeveridad.Size = new System.Drawing.Size(799, 247);
            this.gcSeveridad.TabIndex = 78;
            this.gcSeveridad.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSeveridad});
            // 
            // gvSeveridad
            // 
            this.gvSeveridad.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gvSeveridad.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvSeveridad.Appearance.ViewCaption.Options.UseFont = true;
            this.gvSeveridad.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvSeveridad.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn17,
            this.gridColumn1,
            this.gcCodigo,
            this.gcIndicePersona});
            this.gvSeveridad.GridControl = this.gcSeveridad;
            this.gvSeveridad.Name = "gvSeveridad";
            this.gvSeveridad.OptionsSelection.MultiSelect = true;
            this.gvSeveridad.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvSeveridad.OptionsView.ColumnAutoWidth = false;
            this.gvSeveridad.OptionsView.RowAutoHeight = true;
            this.gvSeveridad.OptionsView.ShowGroupPanel = false;
            this.gvSeveridad.OptionsView.ShowViewCaption = true;
            this.gvSeveridad.ViewCaption = "ANÁLISIS DE LA SEVERIDAD";
            this.gvSeveridad.DoubleClick += new System.EventHandler(this.gvSeveridad_DoubleClick);
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "IdEmpresa";
            this.gridColumn17.FieldName = "IdEmpresa";
            this.gridColumn17.Name = "gridColumn17";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdSeveridad";
            this.gridColumn1.FieldName = "IdSeveridad";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Valor";
            this.gcCodigo.FieldName = "ValorSeveridad";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsColumn.AllowEdit = false;
            this.gcCodigo.OptionsColumn.AllowFocus = false;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            this.gcCodigo.Width = 50;
            // 
            // gcIndicePersona
            // 
            this.gcIndicePersona.AppearanceCell.Options.UseTextOptions = true;
            this.gcIndicePersona.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcIndicePersona.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcIndicePersona.Caption = "Indice de Severidad";
            this.gcIndicePersona.FieldName = "DescSeveridad";
            this.gcIndicePersona.Name = "gcIndicePersona";
            this.gcIndicePersona.OptionsColumn.AllowEdit = false;
            this.gcIndicePersona.OptionsColumn.AllowFocus = false;
            this.gcIndicePersona.Visible = true;
            this.gcIndicePersona.VisibleIndex = 1;
            this.gcIndicePersona.Width = 500;
            // 
            // gcTxtClasificacion
            // 
            this.gcTxtClasificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtClasificacion.Name = "gcTxtClasificacion";
            // 
            // gcTxtResponsable
            // 
            this.gcTxtResponsable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtResponsable.Name = "gcTxtResponsable";
            // 
            // gcTxtSituacion
            // 
            this.gcTxtSituacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtSituacion.Name = "gcTxtSituacion";
            // 
            // gcTxtCondicionSubEstandar
            // 
            this.gcTxtCondicionSubEstandar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtCondicionSubEstandar.Name = "gcTxtCondicionSubEstandar";
            // 
            // gcTxtObservacion
            // 
            this.gcTxtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtObservacion.Name = "gcTxtObservacion";
            // 
            // frmManSeveridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 346);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.tlbMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManSeveridad";
            this.Load += new System.EventHandler(this.frmManSeveridad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSeveridad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSeveridad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtClasificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtResponsable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSituacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCondicionSubEstandar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtObservacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gcSeveridad;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSeveridad;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcIndicePersona;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtClasificacion;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtResponsable;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtSituacion;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtCondicionSubEstandar;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtObservacion;
    }
}