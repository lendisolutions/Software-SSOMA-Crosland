namespace SSOMA.Presentacion.Modulos.Iperc.Maestros
{
    partial class frmManProbabilidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManProbabilidad));
            this.tlbMenu = new SSOMA.Presentacion.ControlUser.UIToolBar();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcProbabilidad = new DevExpress.XtraGrid.GridControl();
            this.gvProbabilidad = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIndicePersona = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIndiceProcedimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIndiceCapacitacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIndiceFrecuencia = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.gcProbabilidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProbabilidad)).BeginInit();
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
            this.tlbMenu.Size = new System.Drawing.Size(1091, 30);
            this.tlbMenu.TabIndex = 33;
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
            this.splitContainerControl1.Panel2.Controls.Add(this.gcProbabilidad);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1091, 462);
            this.splitContainerControl1.SplitterPosition = 63;
            this.splitContainerControl1.TabIndex = 34;
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
            this.groupControl1.Size = new System.Drawing.Size(1091, 78);
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
            // gcProbabilidad
            // 
            this.gcProbabilidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcProbabilidad.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcProbabilidad.Location = new System.Drawing.Point(0, 0);
            this.gcProbabilidad.MainView = this.gvProbabilidad;
            this.gcProbabilidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcProbabilidad.Name = "gcProbabilidad";
            this.gcProbabilidad.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtClasificacion,
            this.gcTxtResponsable,
            this.gcTxtSituacion,
            this.gcTxtCondicionSubEstandar,
            this.gcTxtObservacion});
            this.gcProbabilidad.Size = new System.Drawing.Size(1091, 393);
            this.gcProbabilidad.TabIndex = 78;
            this.gcProbabilidad.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProbabilidad});
            // 
            // gvProbabilidad
            // 
            this.gvProbabilidad.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gvProbabilidad.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvProbabilidad.Appearance.ViewCaption.Options.UseFont = true;
            this.gvProbabilidad.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvProbabilidad.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn17,
            this.gridColumn1,
            this.gcCodigo,
            this.gcIndicePersona,
            this.gcIndiceProcedimiento,
            this.gcIndiceCapacitacion,
            this.gcIndiceFrecuencia});
            this.gvProbabilidad.GridControl = this.gcProbabilidad;
            this.gvProbabilidad.Name = "gvProbabilidad";
            this.gvProbabilidad.OptionsSelection.MultiSelect = true;
            this.gvProbabilidad.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvProbabilidad.OptionsView.ColumnAutoWidth = false;
            this.gvProbabilidad.OptionsView.RowAutoHeight = true;
            this.gvProbabilidad.OptionsView.ShowGroupPanel = false;
            this.gvProbabilidad.OptionsView.ShowViewCaption = true;
            this.gvProbabilidad.ViewCaption = "ANÁLISIS DE LA PROBABILIDAD";
            this.gvProbabilidad.DoubleClick += new System.EventHandler(this.gvProbabilidad_DoubleClick);
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "IdEmpresa";
            this.gridColumn17.FieldName = "IdEmpresa";
            this.gridColumn17.Name = "gridColumn17";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdProbabilidad";
            this.gridColumn1.FieldName = "IdProbabilidad";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Valor";
            this.gcCodigo.FieldName = "ValorProbabilidad";
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
            this.gcIndicePersona.Caption = "Indice de Personas Expuestas";
            this.gcIndicePersona.FieldName = "IndicePersona";
            this.gcIndicePersona.Name = "gcIndicePersona";
            this.gcIndicePersona.OptionsColumn.AllowEdit = false;
            this.gcIndicePersona.OptionsColumn.AllowFocus = false;
            this.gcIndicePersona.Visible = true;
            this.gcIndicePersona.VisibleIndex = 1;
            this.gcIndicePersona.Width = 100;
            // 
            // gcIndiceProcedimiento
            // 
            this.gcIndiceProcedimiento.AppearanceCell.Options.UseTextOptions = true;
            this.gcIndiceProcedimiento.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcIndiceProcedimiento.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcIndiceProcedimiento.Caption = "Indice de Procedimientos de Trabajo";
            this.gcIndiceProcedimiento.FieldName = "IndiceProcedimiento";
            this.gcIndiceProcedimiento.Name = "gcIndiceProcedimiento";
            this.gcIndiceProcedimiento.OptionsColumn.AllowEdit = false;
            this.gcIndiceProcedimiento.OptionsColumn.AllowFocus = false;
            this.gcIndiceProcedimiento.Visible = true;
            this.gcIndiceProcedimiento.VisibleIndex = 2;
            this.gcIndiceProcedimiento.Width = 225;
            // 
            // gcIndiceCapacitacion
            // 
            this.gcIndiceCapacitacion.AppearanceCell.Options.UseTextOptions = true;
            this.gcIndiceCapacitacion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcIndiceCapacitacion.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcIndiceCapacitacion.Caption = "Indice de Capacitación y Entrenamiento";
            this.gcIndiceCapacitacion.FieldName = "IndiceCapacitacion";
            this.gcIndiceCapacitacion.Name = "gcIndiceCapacitacion";
            this.gcIndiceCapacitacion.OptionsColumn.AllowEdit = false;
            this.gcIndiceCapacitacion.OptionsColumn.AllowFocus = false;
            this.gcIndiceCapacitacion.Visible = true;
            this.gcIndiceCapacitacion.VisibleIndex = 3;
            this.gcIndiceCapacitacion.Width = 380;
            // 
            // gcIndiceFrecuencia
            // 
            this.gcIndiceFrecuencia.AppearanceCell.Options.UseTextOptions = true;
            this.gcIndiceFrecuencia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcIndiceFrecuencia.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcIndiceFrecuencia.Caption = "Indice de Frecuencia y Exposición";
            this.gcIndiceFrecuencia.FieldName = "IndiceFrecuencia";
            this.gcIndiceFrecuencia.Name = "gcIndiceFrecuencia";
            this.gcIndiceFrecuencia.OptionsColumn.AllowEdit = false;
            this.gcIndiceFrecuencia.OptionsColumn.AllowFocus = false;
            this.gcIndiceFrecuencia.Visible = true;
            this.gcIndiceFrecuencia.VisibleIndex = 4;
            this.gcIndiceFrecuencia.Width = 160;
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
            // frmManProbabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 492);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.tlbMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManProbabilidad";
            this.Load += new System.EventHandler(this.frmManProbabilidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProbabilidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProbabilidad)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gcProbabilidad;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProbabilidad;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcIndicePersona;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtCondicionSubEstandar;
        private DevExpress.XtraGrid.Columns.GridColumn gcIndiceProcedimiento;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtClasificacion;
        private DevExpress.XtraGrid.Columns.GridColumn gcIndiceCapacitacion;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn gcIndiceFrecuencia;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtObservacion;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtSituacion;
    }
}