namespace SSOMA.Presentacion.Modulos.Otros
{
    partial class frmBuscaEquipoProteccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaEquipoProteccion));
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.lblPersona = new DevExpress.XtraEditors.LabelControl();
            this.gcEquipoProteccion = new DevExpress.XtraGrid.GridControl();
            this.gvEquipoProteccion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEquipoProteccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEquipoProteccion)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(88, 10);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(635, 22);
            this.txtDescripcion.TabIndex = 80;
            this.txtDescripcion.EditValueChanged += new System.EventHandler(this.txtDescripcion_EditValueChanged);
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // lblPersona
            // 
            this.lblPersona.Location = new System.Drawing.Point(12, 13);
            this.lblPersona.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(70, 16);
            this.lblPersona.TabIndex = 81;
            this.lblPersona.Text = "Descripción:";
            // 
            // gcEquipoProteccion
            // 
            this.gcEquipoProteccion.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcEquipoProteccion.Location = new System.Drawing.Point(1, 40);
            this.gcEquipoProteccion.MainView = this.gvEquipoProteccion;
            this.gcEquipoProteccion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcEquipoProteccion.Name = "gcEquipoProteccion";
            this.gcEquipoProteccion.Size = new System.Drawing.Size(731, 543);
            this.gcEquipoProteccion.TabIndex = 82;
            this.gcEquipoProteccion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEquipoProteccion});
            // 
            // gvEquipoProteccion
            // 
            this.gvEquipoProteccion.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvEquipoProteccion.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvEquipoProteccion.Appearance.ViewCaption.Options.UseFont = true;
            this.gvEquipoProteccion.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvEquipoProteccion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gcCodigo});
            this.gvEquipoProteccion.GridControl = this.gcEquipoProteccion;
            this.gvEquipoProteccion.Name = "gvEquipoProteccion";
            this.gvEquipoProteccion.OptionsSelection.MultiSelect = true;
            this.gvEquipoProteccion.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvEquipoProteccion.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvEquipoProteccion.OptionsView.ColumnAutoWidth = false;
            this.gvEquipoProteccion.OptionsView.ShowGroupPanel = false;
            this.gvEquipoProteccion.OptionsView.ShowViewCaption = true;
            this.gvEquipoProteccion.ViewCaption = "LISTADO DE EQUIPOS DE PROTECCIÓN PERSONAL";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdEquipoProteccion";
            this.gridColumn3.FieldName = "IdEquipoProteccion";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Descripción";
            this.gcCodigo.FieldName = "DescEquipoProteccion";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsColumn.AllowEdit = false;
            this.gcCodigo.OptionsColumn.AllowFocus = false;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 1;
            this.gcCodigo.Width = 500;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(636, 591);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 84;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::SSOMA.Presentacion.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageIndex = 1;
            this.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(543, 591);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(87, 28);
            this.btnAceptar.TabIndex = 83;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmBuscaEquipoProteccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 627);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gcEquipoProteccion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblPersona);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscaEquipoProteccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda de Equipo de Protección Personal";
            this.Load += new System.EventHandler(this.frmBuscaEquipoProteccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEquipoProteccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEquipoProteccion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl lblPersona;
        private DevExpress.XtraGrid.GridControl gcEquipoProteccion;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEquipoProteccion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnAceptar;
    }
}