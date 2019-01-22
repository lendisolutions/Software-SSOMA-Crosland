namespace SSOMA.Presentacion.Modulos.Otros
{
    partial class frmBuscaProbabilidad
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
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProbabilidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProbabilidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtClasificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtResponsable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSituacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCondicionSubEstandar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtObservacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 17);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 16);
            this.labelControl1.TabIndex = 29;
            this.labelControl1.Text = "Descripción:";
            // 
            // gcProbabilidad
            // 
            this.gcProbabilidad.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcProbabilidad.Location = new System.Drawing.Point(5, 43);
            this.gcProbabilidad.MainView = this.gvProbabilidad;
            this.gcProbabilidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcProbabilidad.Name = "gcProbabilidad";
            this.gcProbabilidad.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtClasificacion,
            this.gcTxtResponsable,
            this.gcTxtSituacion,
            this.gcTxtCondicionSubEstandar,
            this.gcTxtObservacion});
            this.gcProbabilidad.Size = new System.Drawing.Size(1109, 393);
            this.gcProbabilidad.TabIndex = 79;
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
            this.gvProbabilidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvProbabilidad_KeyDown);
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
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(81, 14);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(635, 22);
            this.txtDescripcion.TabIndex = 82;
            this.txtDescripcion.EditValueChanged += new System.EventHandler(this.txtDescripcion_EditValueChanged);
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // frmBuscaProbabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 436);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.gcProbabilidad);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmBuscaProbabilidad";
            this.Text = "Análisis de la Probabilidad";
            this.Load += new System.EventHandler(this.frmBuscaProbabilidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcProbabilidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProbabilidad)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gcProbabilidad;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProbabilidad;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcIndicePersona;
        private DevExpress.XtraGrid.Columns.GridColumn gcIndiceProcedimiento;
        private DevExpress.XtraGrid.Columns.GridColumn gcIndiceCapacitacion;
        private DevExpress.XtraGrid.Columns.GridColumn gcIndiceFrecuencia;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtClasificacion;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtResponsable;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtSituacion;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtCondicionSubEstandar;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtObservacion;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
    }
}