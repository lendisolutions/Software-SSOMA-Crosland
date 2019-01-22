namespace SSOMA.Presentacion.Modulos.Otros
{
    partial class frmBuscaCondicionSubEstandar
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
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.lblPersona = new DevExpress.XtraEditors.LabelControl();
            this.gcCondicionSubEstandar = new DevExpress.XtraGrid.GridControl();
            this.gvCondicionSubEstandar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondicionSubEstandar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCondicionSubEstandar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(88, 7);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(635, 22);
            this.txtDescripcion.TabIndex = 78;
            this.txtDescripcion.EditValueChanged += new System.EventHandler(this.txtDescripcion_EditValueChanged);
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // lblPersona
            // 
            this.lblPersona.Location = new System.Drawing.Point(12, 10);
            this.lblPersona.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(70, 16);
            this.lblPersona.TabIndex = 79;
            this.lblPersona.Text = "Descripción:";
            // 
            // gcCondicionSubEstandar
            // 
            this.gcCondicionSubEstandar.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcCondicionSubEstandar.Location = new System.Drawing.Point(1, 39);
            this.gcCondicionSubEstandar.MainView = this.gvCondicionSubEstandar;
            this.gcCondicionSubEstandar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcCondicionSubEstandar.Name = "gcCondicionSubEstandar";
            this.gcCondicionSubEstandar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.gcCondicionSubEstandar.Size = new System.Drawing.Size(733, 585);
            this.gcCondicionSubEstandar.TabIndex = 77;
            this.gcCondicionSubEstandar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCondicionSubEstandar});
            // 
            // gvCondicionSubEstandar
            // 
            this.gvCondicionSubEstandar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn1});
            this.gvCondicionSubEstandar.GridControl = this.gcCondicionSubEstandar;
            this.gvCondicionSubEstandar.GroupPanelText = "Resultado de la Busqueda";
            this.gvCondicionSubEstandar.Name = "gvCondicionSubEstandar";
            this.gvCondicionSubEstandar.OptionsView.ColumnAutoWidth = false;
            this.gvCondicionSubEstandar.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.gvCondicionSubEstandar.OptionsView.RowAutoHeight = true;
            this.gvCondicionSubEstandar.OptionsView.ShowGroupPanel = false;
            this.gvCondicionSubEstandar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvCondicionSubEstandar_KeyDown);
            this.gvCondicionSubEstandar.DoubleClick += new System.EventHandler(this.gvCondicionSubEstandar_DoubleClick);
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn5.Caption = "IdCondicionSubEstandar";
            this.gridColumn5.FieldName = "IdCondicionSubEstandar";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Descripción";
            this.gridColumn1.FieldName = "DescCondicionSubEstandar";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 500;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            this.repositoryItemMemoEdit1.ReadOnly = true;
            // 
            // frmBuscaCondicionSubEstandar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 630);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblPersona);
            this.Controls.Add(this.gcCondicionSubEstandar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBuscaCondicionSubEstandar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda Condición Sub Estandar";
            this.Load += new System.EventHandler(this.frmBuscaCondicionSubEstandar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondicionSubEstandar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCondicionSubEstandar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl lblPersona;
        private DevExpress.XtraGrid.GridControl gcCondicionSubEstandar;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCondicionSubEstandar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
    }
}