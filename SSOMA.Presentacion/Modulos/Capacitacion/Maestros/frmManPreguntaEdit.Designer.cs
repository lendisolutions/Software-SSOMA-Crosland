namespace SSOMA.Presentacion.Modulos.Capacitacion.Maestros
{
    partial class frmManPreguntaEdit
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManPreguntaEdit));
            this.gcTxtArchivo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gcRespuesta = new DevExpress.XtraGrid.GridControl();
            this.mnuContextualRespuesta = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoRespuestaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarRespuestaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gvRespuesta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPuntaje = new DevExpress.XtraEditors.SpinEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.txtDescPregunta = new DevExpress.XtraEditors.MemoEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.bsListadoRespuesta = new System.Windows.Forms.BindingSource(this.components);
            this.gcTxtDescRespuesta = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtArchivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRespuesta)).BeginInit();
            this.mnuContextualRespuesta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRespuesta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPuntaje.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescPregunta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoRespuesta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtDescRespuesta)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTxtArchivo
            // 
            this.gcTxtArchivo.AllowFocused = false;
            this.gcTxtArchivo.AutoHeight = false;
            this.gcTxtArchivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtArchivo.Name = "gcTxtArchivo";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(3, 8);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1048, 486);
            this.xtraTabControl1.TabIndex = 195;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gcRespuesta);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.txtPuntaje);
            this.xtraTabPage1.Controls.Add(this.lblFecha);
            this.xtraTabPage1.Controls.Add(this.txtDescPregunta);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1041, 452);
            this.xtraTabPage1.Text = "Datos Generales de la Pregunta del Cuestionario";
            // 
            // gcRespuesta
            // 
            this.gcRespuesta.ContextMenuStrip = this.mnuContextualRespuesta;
            this.gcRespuesta.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcRespuesta.Location = new System.Drawing.Point(8, 98);
            this.gcRespuesta.MainView = this.gvRespuesta;
            this.gcRespuesta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcRespuesta.Name = "gcRespuesta";
            this.gcRespuesta.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtDescRespuesta});
            this.gcRespuesta.Size = new System.Drawing.Size(1030, 350);
            this.gcRespuesta.TabIndex = 203;
            this.gcRespuesta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRespuesta});
            // 
            // mnuContextualRespuesta
            // 
            this.mnuContextualRespuesta.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuContextualRespuesta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoRespuestaToolStripMenuItem,
            this.eliminarRespuestaToolStripMenuItem,
            this.toolStripSeparator1});
            this.mnuContextualRespuesta.Name = "contextMenuStrip1";
            this.mnuContextualRespuesta.Size = new System.Drawing.Size(137, 62);
            // 
            // nuevoRespuestaToolStripMenuItem
            // 
            this.nuevoRespuestaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoRespuestaToolStripMenuItem.Image")));
            this.nuevoRespuestaToolStripMenuItem.Name = "nuevoRespuestaToolStripMenuItem";
            this.nuevoRespuestaToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.nuevoRespuestaToolStripMenuItem.Text = "Nuevo";
            this.nuevoRespuestaToolStripMenuItem.Click += new System.EventHandler(this.nuevoRespuestaToolStripMenuItem_Click);
            // 
            // eliminarRespuestaToolStripMenuItem
            // 
            this.eliminarRespuestaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarRespuestaToolStripMenuItem.Image")));
            this.eliminarRespuestaToolStripMenuItem.Name = "eliminarRespuestaToolStripMenuItem";
            this.eliminarRespuestaToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.eliminarRespuestaToolStripMenuItem.Text = "Eliminar";
            this.eliminarRespuestaToolStripMenuItem.Click += new System.EventHandler(this.eliminarRespuestaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // gvRespuesta
            // 
            this.gvRespuesta.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gvRespuesta.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvRespuesta.Appearance.ViewCaption.Options.UseFont = true;
            this.gvRespuesta.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvRespuesta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn23,
            this.gridColumn3,
            this.gridColumn26,
            this.gridColumn4,
            this.gridColumn29,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn33});
            this.gvRespuesta.GridControl = this.gcRespuesta;
            this.gvRespuesta.Name = "gvRespuesta";
            this.gvRespuesta.OptionsSelection.MultiSelect = true;
            this.gvRespuesta.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvRespuesta.OptionsView.ColumnAutoWidth = false;
            this.gvRespuesta.OptionsView.RowAutoHeight = true;
            this.gvRespuesta.OptionsView.ShowGroupPanel = false;
            this.gvRespuesta.OptionsView.ShowViewCaption = true;
            this.gvRespuesta.ViewCaption = "RESPUESTAS DE LA PREGUNTA";
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "IdEmpresa";
            this.gridColumn23.FieldName = "IdEmpresa";
            this.gridColumn23.Name = "gridColumn23";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdTema";
            this.gridColumn3.FieldName = "IdTema";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "IdCuestionario";
            this.gridColumn26.FieldName = "IdCuestionario";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "IdPregunta";
            this.gridColumn4.FieldName = "IdPregunta";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn29
            // 
            this.gridColumn29.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn29.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn29.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn29.Caption = "IdRespuesta";
            this.gridColumn29.ColumnEdit = this.gcTxtArchivo;
            this.gridColumn29.FieldName = "IdRespuesta";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Width = 300;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Descripción de la Respuesta";
            this.gridColumn2.ColumnEdit = this.gcTxtDescRespuesta;
            this.gridColumn2.FieldName = "DescRespuesta";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 900;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Correcto";
            this.gridColumn1.FieldName = "FlagCorrecto";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "TipoOper";
            this.gridColumn33.FieldName = "TipoOper";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.AllowEdit = false;
            this.gridColumn33.OptionsColumn.AllowFocus = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 20);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(157, 16);
            this.labelControl1.TabIndex = 192;
            this.labelControl1.Text = "Descripción de la Pregunta:";
            // 
            // txtPuntaje
            // 
            this.txtPuntaje.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPuntaje.Location = new System.Drawing.Point(171, 69);
            this.txtPuntaje.Name = "txtPuntaje";
            this.txtPuntaje.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPuntaje.Properties.Mask.EditMask = "n0";
            this.txtPuntaje.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtPuntaje.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPuntaje.Size = new System.Drawing.Size(60, 22);
            this.txtPuntaje.TabIndex = 191;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(8, 72);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(143, 16);
            this.lblFecha.TabIndex = 190;
            this.lblFecha.Text = "Puntaje de la Pregunta : ";
            // 
            // txtDescPregunta
            // 
            this.txtDescPregunta.Location = new System.Drawing.Point(171, 19);
            this.txtDescPregunta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescPregunta.Name = "txtDescPregunta";
            this.txtDescPregunta.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescPregunta.Properties.MaxLength = 800;
            this.txtDescPregunta.Size = new System.Drawing.Size(867, 43);
            this.txtDescPregunta.TabIndex = 191;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(955, 501);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 194;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(862, 501);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 193;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // gcTxtDescRespuesta
            // 
            this.gcTxtDescRespuesta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtDescRespuesta.Name = "gcTxtDescRespuesta";
            // 
            // frmManPreguntaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 537);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManPreguntaEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManPreguntaEdit";
            this.Load += new System.EventHandler(this.frmManPreguntaEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtArchivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRespuesta)).EndInit();
            this.mnuContextualRespuesta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvRespuesta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPuntaje.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescPregunta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoRespuesta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtDescRespuesta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraGrid.GridControl gcRespuesta;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRespuesta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit txtPuntaje;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.MemoEdit txtDescPregunta;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        public System.Windows.Forms.ContextMenuStrip mnuContextualRespuesta;
        private System.Windows.Forms.ToolStripMenuItem nuevoRespuestaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarRespuestaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.BindingSource bsListadoRespuesta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gcTxtArchivo;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtDescRespuesta;
    }
}