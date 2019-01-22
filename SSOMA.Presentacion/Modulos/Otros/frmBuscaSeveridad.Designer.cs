namespace SSOMA.Presentacion.Modulos.Otros
{
    partial class frmBuscaSeveridad
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
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcSeveridad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSeveridad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtClasificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtResponsable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSituacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCondicionSubEstandar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtObservacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcSeveridad
            // 
            this.gcSeveridad.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcSeveridad.Location = new System.Drawing.Point(6, 43);
            this.gcSeveridad.MainView = this.gvSeveridad;
            this.gcSeveridad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcSeveridad.Name = "gcSeveridad";
            this.gcSeveridad.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtClasificacion,
            this.gcTxtResponsable,
            this.gcTxtSituacion,
            this.gcTxtCondicionSubEstandar,
            this.gcTxtObservacion});
            this.gcSeveridad.Size = new System.Drawing.Size(810, 247);
            this.gcSeveridad.TabIndex = 79;
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
            this.gvSeveridad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvSeveridad_KeyDown);
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
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(84, 13);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(635, 22);
            this.txtDescripcion.TabIndex = 84;
            this.txtDescripcion.EditValueChanged += new System.EventHandler(this.txtDescripcion_EditValueChanged);
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 16);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 16);
            this.labelControl1.TabIndex = 83;
            this.labelControl1.Text = "Descripción:";
            // 
            // frmBuscaSeveridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 290);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gcSeveridad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBuscaSeveridad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Análisis de la Severidad";
            this.Load += new System.EventHandler(this.frmBuscaSeveridad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcSeveridad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSeveridad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtClasificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtResponsable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSituacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCondicionSubEstandar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtObservacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}