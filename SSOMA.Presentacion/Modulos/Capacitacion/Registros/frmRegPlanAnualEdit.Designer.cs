namespace SSOMA.Presentacion.Modulos.Capacitacion.Registros
{
    partial class frmRegPlanAnualEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegPlanAnualEdit));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtDuracion = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtPeriodo = new DevExpress.XtraEditors.SpinEdit();
            this.cboSituacion = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.cboResponsableCapacitacion = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.cboClase = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboLugar = new DevExpress.XtraEditors.LookUpEdit();
            this.txtCosto = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboTema = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gcPlanAnualDetalle = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvEppDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtCodigo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gcCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtCantidad = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bsListado = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuracion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboResponsableCapacitacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLugar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTema.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPlanAnualDetalle)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvEppDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListado)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(809, 317);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 67;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(716, 317);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 66;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(902, 310);
            this.xtraTabControl1.TabIndex = 69;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.labelControl12);
            this.xtraTabPage1.Controls.Add(this.txtDuracion);
            this.xtraTabPage1.Controls.Add(this.labelControl11);
            this.xtraTabPage1.Controls.Add(this.txtPeriodo);
            this.xtraTabPage1.Controls.Add(this.cboSituacion);
            this.xtraTabPage1.Controls.Add(this.labelControl10);
            this.xtraTabPage1.Controls.Add(this.cboResponsableCapacitacion);
            this.xtraTabPage1.Controls.Add(this.labelControl9);
            this.xtraTabPage1.Controls.Add(this.lblFecha);
            this.xtraTabPage1.Controls.Add(this.cboClase);
            this.xtraTabPage1.Controls.Add(this.labelControl4);
            this.xtraTabPage1.Controls.Add(this.cboTipo);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.cboLugar);
            this.xtraTabPage1.Controls.Add(this.txtCosto);
            this.xtraTabPage1.Controls.Add(this.labelControl6);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.cboTema);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(895, 276);
            this.xtraTabPage1.Text = "Datos del Programa Anual de Capacitación";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(198, 183);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(44, 16);
            this.labelControl12.TabIndex = 210;
            this.labelControl12.Text = "Minutos";
            // 
            // txtDuracion
            // 
            this.txtDuracion.EditValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtDuracion.Location = new System.Drawing.Point(119, 179);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDuracion.Properties.MaxValue = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.txtDuracion.Properties.MinValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtDuracion.Size = new System.Drawing.Size(73, 22);
            this.txtDuracion.TabIndex = 209;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(18, 183);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(55, 16);
            this.labelControl11.TabIndex = 208;
            this.labelControl11.Text = "Duración:";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.EditValue = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.txtPeriodo.Location = new System.Drawing.Point(119, 97);
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
            this.txtPeriodo.TabIndex = 207;
            // 
            // cboSituacion
            // 
            this.cboSituacion.Location = new System.Drawing.Point(119, 239);
            this.cboSituacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSituacion.Name = "cboSituacion";
            this.cboSituacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSituacion.Properties.NullText = "";
            this.cboSituacion.Size = new System.Drawing.Size(766, 22);
            this.cboSituacion.TabIndex = 206;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(19, 242);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(57, 16);
            this.labelControl10.TabIndex = 205;
            this.labelControl10.Text = "Situación:";
            // 
            // cboResponsableCapacitacion
            // 
            this.cboResponsableCapacitacion.Location = new System.Drawing.Point(119, 153);
            this.cboResponsableCapacitacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboResponsableCapacitacion.Name = "cboResponsableCapacitacion";
            this.cboResponsableCapacitacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboResponsableCapacitacion.Properties.NullText = "";
            this.cboResponsableCapacitacion.Size = new System.Drawing.Size(766, 22);
            this.cboResponsableCapacitacion.TabIndex = 204;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(18, 157);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(77, 16);
            this.labelControl9.TabIndex = 203;
            this.labelControl9.Text = "Responsable:";
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(19, 100);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(48, 16);
            this.lblFecha.TabIndex = 202;
            this.lblFecha.Text = "Periodo:";
            // 
            // cboClase
            // 
            this.cboClase.Location = new System.Drawing.Point(119, 70);
            this.cboClase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboClase.Name = "cboClase";
            this.cboClase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboClase.Properties.NullText = "";
            this.cboClase.Size = new System.Drawing.Size(766, 22);
            this.cboClase.TabIndex = 201;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(19, 73);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 16);
            this.labelControl4.TabIndex = 200;
            this.labelControl4.Text = "Clase:";
            // 
            // cboTipo
            // 
            this.cboTipo.Location = new System.Drawing.Point(119, 42);
            this.cboTipo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipo.Properties.NullText = "";
            this.cboTipo.Size = new System.Drawing.Size(766, 22);
            this.cboTipo.TabIndex = 199;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(19, 46);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(30, 16);
            this.labelControl3.TabIndex = 198;
            this.labelControl3.Text = "Tipo:";
            // 
            // cboLugar
            // 
            this.cboLugar.Location = new System.Drawing.Point(119, 126);
            this.cboLugar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboLugar.Name = "cboLugar";
            this.cboLugar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLugar.Properties.NullText = "";
            this.cboLugar.Size = new System.Drawing.Size(766, 22);
            this.cboLugar.TabIndex = 197;
            // 
            // txtCosto
            // 
            this.txtCosto.EditValue = "0.00";
            this.txtCosto.Location = new System.Drawing.Point(119, 207);
            this.txtCosto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.Properties.Appearance.Options.UseFont = true;
            this.txtCosto.Properties.DisplayFormat.FormatString = "n2";
            this.txtCosto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCosto.Properties.Mask.EditMask = "n2";
            this.txtCosto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCosto.Properties.Mask.ShowPlaceHolders = false;
            this.txtCosto.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCosto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCosto.Size = new System.Drawing.Size(105, 24);
            this.txtCosto.TabIndex = 196;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(18, 211);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(89, 16);
            this.labelControl6.TabIndex = 195;
            this.labelControl6.Text = "P. Unitario S/.: ";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 130);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 16);
            this.labelControl1.TabIndex = 194;
            this.labelControl1.Text = "Sede\\Lugar:";
            // 
            // cboTema
            // 
            this.cboTema.Location = new System.Drawing.Point(119, 15);
            this.cboTema.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTema.Name = "cboTema";
            this.cboTema.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTema.Properties.NullText = "";
            this.cboTema.Size = new System.Drawing.Size(766, 22);
            this.cboTema.TabIndex = 193;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 19);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 16);
            this.labelControl2.TabIndex = 192;
            this.labelControl2.Text = "Tema:";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gcPlanAnualDetalle);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(895, 276);
            this.xtraTabPage2.Text = "Cronograma";
            // 
            // gcPlanAnualDetalle
            // 
            this.gcPlanAnualDetalle.ContextMenuStrip = this.mnuContextual;
            this.gcPlanAnualDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPlanAnualDetalle.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcPlanAnualDetalle.Location = new System.Drawing.Point(0, 0);
            this.gcPlanAnualDetalle.MainView = this.gvEppDetalle;
            this.gcPlanAnualDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcPlanAnualDetalle.Name = "gcPlanAnualDetalle";
            this.gcPlanAnualDetalle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtCodigo,
            this.gcTxtCantidad});
            this.gcPlanAnualDetalle.Size = new System.Drawing.Size(895, 276);
            this.gcPlanAnualDetalle.TabIndex = 30;
            this.gcPlanAnualDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEppDetalle});
            // 
            // mnuContextual
            // 
            this.mnuContextual.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(139, 56);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripMenuItem.Image")));
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem.Image")));
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // gvEppDetalle
            // 
            this.gvEppDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn1,
            this.gridColumn11,
            this.gridColumn2,
            this.gcCantidad,
            this.gridColumn15});
            this.gvEppDetalle.GridControl = this.gcPlanAnualDetalle;
            this.gvEppDetalle.Name = "gvEppDetalle";
            this.gvEppDetalle.OptionsSelection.MultiSelect = true;
            this.gvEppDetalle.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvEppDetalle.OptionsView.ColumnAutoWidth = false;
            this.gvEppDetalle.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.gvEppDetalle.OptionsView.RowAutoHeight = true;
            this.gvEppDetalle.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdEmpresa";
            this.gridColumn5.FieldName = "IdEmpresa";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdPlanAnual";
            this.gridColumn1.FieldName = "IdPlanAnual";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "IdPlanAnualDetalle";
            this.gridColumn11.FieldName = "IdPlanAnualDetalle";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mes";
            this.gridColumn2.ColumnEdit = this.gcTxtCodigo;
            this.gridColumn2.FieldName = "DescMes";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 100;
            // 
            // gcTxtCodigo
            // 
            this.gcTxtCodigo.Name = "gcTxtCodigo";
            this.gcTxtCodigo.Click += new System.EventHandler(this.gcTxtCodigo_Click);
            // 
            // gcCantidad
            // 
            this.gcCantidad.Caption = "Semana";
            this.gcCantidad.ColumnEdit = this.gcTxtCantidad;
            this.gcCantidad.FieldName = "Semana";
            this.gcCantidad.Name = "gcCantidad";
            this.gcCantidad.Visible = true;
            this.gcCantidad.VisibleIndex = 1;
            this.gcCantidad.Width = 60;
            // 
            // gcTxtCantidad
            // 
            this.gcTxtCantidad.AutoHeight = false;
            this.gcTxtCantidad.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gcTxtCantidad.MaxValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.gcTxtCantidad.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gcTxtCantidad.Name = "gcTxtCantidad";
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "TipoOper";
            this.gridColumn15.FieldName = "TipoOper";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            // 
            // frmRegPlanAnualEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 354);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegPlanAnualEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmRegPlanAnualEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuracion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboResponsableCapacitacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLugar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTema.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPlanAnualDetalle)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvEppDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.SpinEdit txtDuracion;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.SpinEdit txtPeriodo;
        public DevExpress.XtraEditors.LookUpEdit cboSituacion;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        public DevExpress.XtraEditors.LookUpEdit cboResponsableCapacitacion;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        public DevExpress.XtraEditors.LookUpEdit cboClase;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.LookUpEdit cboTipo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.LookUpEdit cboLugar;
        public DevExpress.XtraEditors.TextEdit txtCosto;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.LookUpEdit cboTema;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.BindingSource bsListado;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private DevExpress.XtraGrid.GridControl gcPlanAnualDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEppDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gcCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtCodigo;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit gcTxtCantidad;
    }
}