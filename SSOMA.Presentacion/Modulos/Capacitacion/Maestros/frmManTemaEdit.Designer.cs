namespace SSOMA.Presentacion.Modulos.Capacitacion.Maestros
{
    partial class frmManTemaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManTemaEdit));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.txtPeriodo = new DevExpress.XtraEditors.SpinEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gcTemaDetalle = new DevExpress.XtraGrid.GridControl();
            this.gvTemaDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Archivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtArchivo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtDescripcion = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.deFechaFin = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.txtObjetivo = new DevExpress.XtraEditors.MemoEdit();
            this.deFechaIni = new DevExpress.XtraEditors.DateEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.cboCategoriaTema = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescripcion = new DevExpress.XtraEditors.MemoEdit();
            this.btnEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.picImage = new DevExpress.XtraEditors.PictureEdit();
            this.bsListadoTemaDetalle = new System.Windows.Forms.BindingSource(this.components);
            this.mnuContextualTemaDetalle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoTemaDetalleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarTemaDetalleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTemaDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTemaDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtArchivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObjetivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIni.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCategoriaTema.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoTemaDetalle)).BeginInit();
            this.mnuContextualTemaDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(835, 496);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(742, 496);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 16;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.EditValue = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.txtPeriodo.Location = new System.Drawing.Point(162, 13);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPeriodo.Properties.Mask.EditMask = "n0";
            this.txtPeriodo.Properties.MaxValue = new decimal(new int[] {
            2200,
            0,
            0,
            0});
            this.txtPeriodo.Properties.MinValue = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.txtPeriodo.Size = new System.Drawing.Size(60, 22);
            this.txtPeriodo.TabIndex = 191;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(13, 16);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(48, 16);
            this.lblFecha.TabIndex = 190;
            this.lblFecha.Text = "Periodo:";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 3);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(933, 486);
            this.xtraTabControl1.TabIndex = 192;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnEliminar);
            this.xtraTabPage1.Controls.Add(this.btnAgregar);
            this.xtraTabPage1.Controls.Add(this.picImage);
            this.xtraTabPage1.Controls.Add(this.txtDescripcion);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.gcTemaDetalle);
            this.xtraTabPage1.Controls.Add(this.deFechaFin);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.txtPeriodo);
            this.xtraTabPage1.Controls.Add(this.lblFecha);
            this.xtraTabPage1.Controls.Add(this.labelControl18);
            this.xtraTabPage1.Controls.Add(this.txtObjetivo);
            this.xtraTabPage1.Controls.Add(this.deFechaIni);
            this.xtraTabPage1.Controls.Add(this.labelControl17);
            this.xtraTabPage1.Controls.Add(this.cboCategoriaTema);
            this.xtraTabPage1.Controls.Add(this.labelControl15);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(926, 452);
            this.xtraTabPage1.Text = "Datos Generales del Tema de Capacitación";
            // 
            // gcTemaDetalle
            // 
            this.gcTemaDetalle.ContextMenuStrip = this.mnuContextualTemaDetalle;
            this.gcTemaDetalle.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcTemaDetalle.Location = new System.Drawing.Point(0, 203);
            this.gcTemaDetalle.MainView = this.gvTemaDetalle;
            this.gcTemaDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcTemaDetalle.Name = "gcTemaDetalle";
            this.gcTemaDetalle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtArchivo,
            this.gcTxtDescripcion});
            this.gcTemaDetalle.Size = new System.Drawing.Size(926, 249);
            this.gcTemaDetalle.TabIndex = 203;
            this.gcTemaDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTemaDetalle});
            // 
            // gvTemaDetalle
            // 
            this.gvTemaDetalle.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gvTemaDetalle.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvTemaDetalle.Appearance.ViewCaption.Options.UseFont = true;
            this.gvTemaDetalle.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvTemaDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn23,
            this.gridColumn3,
            this.gridColumn26,
            this.Archivo,
            this.gridColumn29,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn33});
            this.gvTemaDetalle.GridControl = this.gcTemaDetalle;
            this.gvTemaDetalle.Name = "gvTemaDetalle";
            this.gvTemaDetalle.OptionsSelection.MultiSelect = true;
            this.gvTemaDetalle.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvTemaDetalle.OptionsView.ColumnAutoWidth = false;
            this.gvTemaDetalle.OptionsView.RowAutoHeight = true;
            this.gvTemaDetalle.OptionsView.ShowGroupPanel = false;
            this.gvTemaDetalle.OptionsView.ShowViewCaption = true;
            this.gvTemaDetalle.ViewCaption = "ARCHIVOS ADJUNTOS QUE COMPONEN EL TEMA DE CAPACITACION";
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
            this.gridColumn26.Caption = "IdTemaDetalle";
            this.gridColumn26.FieldName = "IdTemaDetalle";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.OptionsColumn.AllowFocus = false;
            // 
            // Archivo
            // 
            this.Archivo.Caption = "Archivo";
            this.Archivo.FieldName = "Archivo";
            this.Archivo.Name = "Archivo";
            // 
            // gridColumn29
            // 
            this.gridColumn29.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn29.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn29.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn29.Caption = "Archivo";
            this.gridColumn29.ColumnEdit = this.gcTxtArchivo;
            this.gridColumn29.FieldName = "NombreArchivo";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 0;
            this.gridColumn29.Width = 300;
            // 
            // gcTxtArchivo
            // 
            this.gcTxtArchivo.AllowFocused = false;
            this.gcTxtArchivo.AutoHeight = false;
            this.gcTxtArchivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtArchivo.Name = "gcTxtArchivo";
            this.gcTxtArchivo.DoubleClick += new System.EventHandler(this.gcTxtArchivo_DoubleClick);
            this.gcTxtArchivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gcTxtArchivo_KeyDown);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Extension";
            this.gridColumn1.FieldName = "Extension";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Descripción del Documento";
            this.gridColumn2.ColumnEdit = this.gcTxtDescripcion;
            this.gridColumn2.FieldName = "Descripcion";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 400;
            // 
            // gcTxtDescripcion
            // 
            this.gcTxtDescripcion.AutoHeight = false;
            this.gcTxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gcTxtDescripcion.Name = "gcTxtDescripcion";
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "TipoOper";
            this.gridColumn33.FieldName = "TipoOper";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.AllowEdit = false;
            this.gridColumn33.OptionsColumn.AllowFocus = false;
            // 
            // deFechaFin
            // 
            this.deFechaFin.EditValue = null;
            this.deFechaFin.Location = new System.Drawing.Point(338, 173);
            this.deFechaFin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deFechaFin.Name = "deFechaFin";
            this.deFechaFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaFin.Size = new System.Drawing.Size(105, 22);
            this.deFechaFin.TabIndex = 172;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 71);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 16);
            this.labelControl1.TabIndex = 192;
            this.labelControl1.Text = "Objetivo:";
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(272, 176);
            this.labelControl18.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(60, 16);
            this.labelControl18.TabIndex = 171;
            this.labelControl18.Text = "Fecha Fin:";
            // 
            // txtObjetivo
            // 
            this.txtObjetivo.Location = new System.Drawing.Point(162, 71);
            this.txtObjetivo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtObjetivo.Name = "txtObjetivo";
            this.txtObjetivo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObjetivo.Properties.MaxLength = 800;
            this.txtObjetivo.Size = new System.Drawing.Size(539, 43);
            this.txtObjetivo.TabIndex = 191;
            // 
            // deFechaIni
            // 
            this.deFechaIni.EditValue = null;
            this.deFechaIni.Location = new System.Drawing.Point(161, 173);
            this.deFechaIni.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deFechaIni.Name = "deFechaIni";
            this.deFechaIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaIni.Size = new System.Drawing.Size(105, 22);
            this.deFechaIni.TabIndex = 170;
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(13, 176);
            this.labelControl17.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(73, 16);
            this.labelControl17.TabIndex = 169;
            this.labelControl17.Text = "Fecha Inicio:";
            // 
            // cboCategoriaTema
            // 
            this.cboCategoriaTema.Location = new System.Drawing.Point(162, 41);
            this.cboCategoriaTema.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboCategoriaTema.Name = "cboCategoriaTema";
            this.cboCategoriaTema.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCategoriaTema.Properties.NullText = "";
            this.cboCategoriaTema.Size = new System.Drawing.Size(539, 22);
            this.cboCategoriaTema.TabIndex = 186;
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(13, 43);
            this.labelControl15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(60, 16);
            this.labelControl15.TabIndex = 185;
            this.labelControl15.Text = "Categoria:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 123);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 16);
            this.labelControl2.TabIndex = 204;
            this.labelControl2.Text = "Descripcion:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(162, 122);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Properties.MaxLength = 800;
            this.txtDescripcion.Size = new System.Drawing.Size(539, 43);
            this.txtDescripcion.TabIndex = 205;
            // 
            // btnEliminar
            // 
            this.btnEliminar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.ImageOptions.Image")));
            this.btnEliminar.ImageOptions.ImageIndex = 1;
            this.btnEliminar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(882, 49);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(29, 28);
            this.btnEliminar.TabIndex = 207;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.ImageOptions.Image")));
            this.btnAgregar.ImageOptions.ImageIndex = 1;
            this.btnAgregar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(882, 19);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(29, 28);
            this.btnAgregar.TabIndex = 208;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // picImage
            // 
            this.picImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.picImage.EditValue = ((object)(resources.GetObject("picImage.EditValue")));
            this.picImage.Location = new System.Drawing.Point(709, 16);
            this.picImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picImage.Name = "picImage";
            this.picImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.picImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picImage.Size = new System.Drawing.Size(167, 176);
            this.picImage.TabIndex = 206;
            // 
            // mnuContextualTemaDetalle
            // 
            this.mnuContextualTemaDetalle.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuContextualTemaDetalle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoTemaDetalleToolStripMenuItem,
            this.eliminarTemaDetalleToolStripMenuItem,
            this.toolStripSeparator1});
            this.mnuContextualTemaDetalle.Name = "contextMenuStrip1";
            this.mnuContextualTemaDetalle.Size = new System.Drawing.Size(137, 62);
            // 
            // nuevoTemaDetalleToolStripMenuItem
            // 
            this.nuevoTemaDetalleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoTemaDetalleToolStripMenuItem.Image")));
            this.nuevoTemaDetalleToolStripMenuItem.Name = "nuevoTemaDetalleToolStripMenuItem";
            this.nuevoTemaDetalleToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.nuevoTemaDetalleToolStripMenuItem.Text = "Nuevo";
            this.nuevoTemaDetalleToolStripMenuItem.Click += new System.EventHandler(this.nuevoTemaDetalleToolStripMenuItem_Click);
            // 
            // eliminarTemaDetalleToolStripMenuItem
            // 
            this.eliminarTemaDetalleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarTemaDetalleToolStripMenuItem.Image")));
            this.eliminarTemaDetalleToolStripMenuItem.Name = "eliminarTemaDetalleToolStripMenuItem";
            this.eliminarTemaDetalleToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.eliminarTemaDetalleToolStripMenuItem.Text = "Eliminar";
            this.eliminarTemaDetalleToolStripMenuItem.Click += new System.EventHandler(this.eliminarTemaDetalleToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // frmManTemaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 537);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManTemaEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmManTemaEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTemaDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTemaDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtArchivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObjetivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIni.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCategoriaTema.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoTemaDetalle)).EndInit();
            this.mnuContextualTemaDetalle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.SpinEdit txtPeriodo;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraGrid.GridControl gcTemaDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTemaDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn Archivo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gcTxtArchivo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gcTxtDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        public DevExpress.XtraEditors.DateEdit deFechaFin;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.MemoEdit txtObjetivo;
        public DevExpress.XtraEditors.DateEdit deFechaIni;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        public DevExpress.XtraEditors.LookUpEdit cboCategoriaTema;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.MemoEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnEliminar;
        private DevExpress.XtraEditors.SimpleButton btnAgregar;
        private DevExpress.XtraEditors.PictureEdit picImage;
        public System.Windows.Forms.ContextMenuStrip mnuContextualTemaDetalle;
        private System.Windows.Forms.ToolStripMenuItem nuevoTemaDetalleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarTemaDetalleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.BindingSource bsListadoTemaDetalle;
    }
}