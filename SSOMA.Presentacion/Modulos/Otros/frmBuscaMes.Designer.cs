namespace SSOMA.Presentacion.Modulos.Otros
{
    partial class frmBuscaMes
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
            this.gcMes = new DevExpress.XtraGrid.GridControl();
            this.gvMes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMes
            // 
            this.gcMes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMes.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcMes.Location = new System.Drawing.Point(0, 0);
            this.gcMes.MainView = this.gvMes;
            this.gcMes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcMes.Name = "gcMes";
            this.gcMes.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.gcMes.Size = new System.Drawing.Size(282, 406);
            this.gcMes.TabIndex = 81;
            this.gcMes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMes});
            // 
            // gvMes
            // 
            this.gvMes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gvMes.GridControl = this.gcMes;
            this.gvMes.GroupPanelText = "Resultado de la Busqueda";
            this.gvMes.Name = "gvMes";
            this.gvMes.OptionsView.ColumnAutoWidth = false;
            this.gvMes.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.gvMes.OptionsView.RowAutoHeight = true;
            this.gvMes.OptionsView.ShowGroupPanel = false;
            this.gvMes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvMes_KeyDown);
            this.gvMes.DoubleClick += new System.EventHandler(this.gvMes_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Descripción";
            this.gridColumn1.FieldName = "Descripcion";
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
            // frmBuscaMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 406);
            this.Controls.Add(this.gcMes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBuscaMes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecciona Mes";
            this.Load += new System.EventHandler(this.frmBuscaMes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMes;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMes;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
    }
}