namespace SSOMA.Presentacion.Modulos.Medico.Registros
{
    partial class frmRegSctrEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegSctrEdit));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btnEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdcionar = new DevExpress.XtraEditors.SimpleButton();
            this.gcSctr = new DevExpress.XtraGrid.GridControl();
            this.gvSctr = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEmpresaResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaSolicitud = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAreaResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboNacionalidad = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtSexo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipoDocumento = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboMes = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtDni = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaNacimiento = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            this.txtCargo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmpresa = new DevExpress.XtraEditors.TextEdit();
            this.txtSolicitante = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscarSolicitante = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSctr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSctr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNacionalidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSexo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaNacimiento.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaNacimiento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCargo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSolicitante.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1182, 494);
            this.xtraTabControl1.TabIndex = 120;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xtraTabPage1.Appearance.Header.Options.UseFont = true;
            this.xtraTabPage1.Controls.Add(this.btnEliminar);
            this.xtraTabPage1.Controls.Add(this.btnAdcionar);
            this.xtraTabPage1.Controls.Add(this.gcSctr);
            this.xtraTabPage1.Controls.Add(this.cboNacionalidad);
            this.xtraTabPage1.Controls.Add(this.labelControl9);
            this.xtraTabPage1.Controls.Add(this.txtSexo);
            this.xtraTabPage1.Controls.Add(this.labelControl6);
            this.xtraTabPage1.Controls.Add(this.cboTipoDocumento);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.cboMes);
            this.xtraTabPage1.Controls.Add(this.labelControl7);
            this.xtraTabPage1.Controls.Add(this.txtDni);
            this.xtraTabPage1.Controls.Add(this.labelControl8);
            this.xtraTabPage1.Controls.Add(this.deFechaNacimiento);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.labelControl4);
            this.xtraTabPage1.Controls.Add(this.deFecha);
            this.xtraTabPage1.Controls.Add(this.txtCargo);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.labelControl23);
            this.xtraTabPage1.Controls.Add(this.txtEmpresa);
            this.xtraTabPage1.Controls.Add(this.txtSolicitante);
            this.xtraTabPage1.Controls.Add(this.labelControl5);
            this.xtraTabPage1.Controls.Add(this.btnBuscarSolicitante);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1175, 459);
            this.xtraTabPage1.Text = "Registro de SCTR";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageIndex = 1;
            this.btnEliminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(100, 99);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(87, 28);
            this.btnEliminar.TabIndex = 195;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAdcionar
            // 
            this.btnAdcionar.Image = global::SSOMA.Presentacion.Properties.Resources.Agregar_16x16;
            this.btnAdcionar.ImageIndex = 1;
            this.btnAdcionar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAdcionar.Location = new System.Drawing.Point(9, 99);
            this.btnAdcionar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdcionar.Name = "btnAdcionar";
            this.btnAdcionar.Size = new System.Drawing.Size(85, 28);
            this.btnAdcionar.TabIndex = 194;
            this.btnAdcionar.Text = "Adicionar";
            this.btnAdcionar.Click += new System.EventHandler(this.btnAdcionar_Click);
            // 
            // gcSctr
            // 
            this.gcSctr.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcSctr.Location = new System.Drawing.Point(3, 140);
            this.gcSctr.MainView = this.gvSctr;
            this.gcSctr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcSctr.Name = "gcSctr";
            this.gcSctr.Size = new System.Drawing.Size(1166, 312);
            this.gcSctr.TabIndex = 193;
            this.gcSctr.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSctr});
            // 
            // gvSctr
            // 
            this.gvSctr.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvSctr.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvSctr.Appearance.ViewCaption.Options.UseFont = true;
            this.gvSctr.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvSctr.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gcEmpresaResponsable,
            this.gcFechaSolicitud,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn10,
            this.gridColumn9,
            this.gridColumn6,
            this.gridColumn2,
            this.gcAreaResponsable,
            this.gridColumn1,
            this.gridColumn11,
            this.gridColumn7});
            this.gvSctr.GridControl = this.gcSctr;
            this.gvSctr.Name = "gvSctr";
            this.gvSctr.OptionsSelection.MultiSelect = true;
            this.gvSctr.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvSctr.OptionsView.ColumnAutoWidth = false;
            this.gvSctr.OptionsView.ShowGroupPanel = false;
            this.gvSctr.OptionsView.ShowViewCaption = true;
            this.gvSctr.ViewCaption = "LISTADO DE REGISTROS DE AFILIACIONES DE SCTR";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdSctr";
            this.gridColumn3.FieldName = "IdSctr";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gcEmpresaResponsable
            // 
            this.gcEmpresaResponsable.Caption = "Empresa";
            this.gcEmpresaResponsable.FieldName = "RazonSocial";
            this.gcEmpresaResponsable.Name = "gcEmpresaResponsable";
            this.gcEmpresaResponsable.OptionsColumn.AllowEdit = false;
            this.gcEmpresaResponsable.OptionsColumn.AllowFocus = false;
            this.gcEmpresaResponsable.Visible = true;
            this.gcEmpresaResponsable.VisibleIndex = 0;
            this.gcEmpresaResponsable.Width = 180;
            // 
            // gcFechaSolicitud
            // 
            this.gcFechaSolicitud.Caption = "Fecha Solicitud";
            this.gcFechaSolicitud.FieldName = "Fecha";
            this.gcFechaSolicitud.Name = "gcFechaSolicitud";
            this.gcFechaSolicitud.OptionsColumn.AllowEdit = false;
            this.gcFechaSolicitud.OptionsColumn.AllowFocus = false;
            this.gcFechaSolicitud.Visible = true;
            this.gcFechaSolicitud.VisibleIndex = 1;
            this.gcFechaSolicitud.Width = 90;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Mes";
            this.gridColumn5.FieldName = "DescMes";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Mes ";
            this.gridColumn4.FieldName = "Mes";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Width = 90;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Tipo Docmento";
            this.gridColumn10.FieldName = "TipoDocumento";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 120;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "N° Documento";
            this.gridColumn9.FieldName = "NumeroDocumento";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "IdPersona";
            this.gridColumn6.FieldName = "IdPersona";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Solicitante";
            this.gridColumn2.FieldName = "Solicitante";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            this.gridColumn2.Width = 300;
            // 
            // gcAreaResponsable
            // 
            this.gcAreaResponsable.Caption = "Sexo";
            this.gcAreaResponsable.FieldName = "Sexo";
            this.gcAreaResponsable.Name = "gcAreaResponsable";
            this.gcAreaResponsable.OptionsColumn.AllowEdit = false;
            this.gcAreaResponsable.OptionsColumn.AllowFocus = false;
            this.gcAreaResponsable.Visible = true;
            this.gcAreaResponsable.VisibleIndex = 6;
            this.gcAreaResponsable.Width = 70;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Fch. Nacimiento";
            this.gridColumn1.FieldName = "FechaNacimiento";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Nacionalidad";
            this.gridColumn11.FieldName = "Nacionalidad";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 8;
            this.gridColumn11.Width = 90;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Cargo";
            this.gridColumn7.FieldName = "Cargo";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 9;
            this.gridColumn7.Width = 250;
            // 
            // cboNacionalidad
            // 
            this.cboNacionalidad.Location = new System.Drawing.Point(1034, 66);
            this.cboNacionalidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboNacionalidad.Name = "cboNacionalidad";
            this.cboNacionalidad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNacionalidad.Properties.NullText = "";
            this.cboNacionalidad.Size = new System.Drawing.Size(135, 22);
            this.cboNacionalidad.TabIndex = 192;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(917, 69);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(77, 16);
            this.labelControl9.TabIndex = 191;
            this.labelControl9.Text = "Nacionalidad:";
            // 
            // txtSexo
            // 
            this.txtSexo.Location = new System.Drawing.Point(710, 69);
            this.txtSexo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSexo.Name = "txtSexo";
            this.txtSexo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSexo.Properties.MaxLength = 100;
            this.txtSexo.Properties.ReadOnly = true;
            this.txtSexo.Size = new System.Drawing.Size(187, 22);
            this.txtSexo.TabIndex = 189;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(671, 72);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(33, 16);
            this.labelControl6.TabIndex = 190;
            this.labelControl6.Text = "Sexo:";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.Location = new System.Drawing.Point(1034, 39);
            this.cboTipoDocumento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoDocumento.Properties.NullText = "";
            this.cboTipoDocumento.Size = new System.Drawing.Size(135, 22);
            this.cboTipoDocumento.TabIndex = 188;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(917, 42);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(116, 16);
            this.labelControl1.TabIndex = 187;
            this.labelControl1.Text = "Tipo de Documento:";
            // 
            // cboMes
            // 
            this.cboMes.Location = new System.Drawing.Point(253, 9);
            this.cboMes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboMes.Name = "cboMes";
            this.cboMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMes.Properties.NullText = "";
            this.cboMes.Size = new System.Drawing.Size(135, 22);
            this.cboMes.TabIndex = 185;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(219, 12);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(28, 16);
            this.labelControl7.TabIndex = 184;
            this.labelControl7.Text = "Mes:";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(1060, 9);
            this.txtDni.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDni.Name = "txtDni";
            this.txtDni.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDni.Properties.MaxLength = 20;
            this.txtDni.Properties.ReadOnly = true;
            this.txtDni.Size = new System.Drawing.Size(109, 22);
            this.txtDni.TabIndex = 185;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(969, 12);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(87, 16);
            this.labelControl8.TabIndex = 186;
            this.labelControl8.Text = "N° Documento:";
            // 
            // deFechaNacimiento
            // 
            this.deFechaNacimiento.EditValue = null;
            this.deFechaNacimiento.Location = new System.Drawing.Point(792, 39);
            this.deFechaNacimiento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deFechaNacimiento.Name = "deFechaNacimiento";
            this.deFechaNacimiento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaNacimiento.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaNacimiento.Size = new System.Drawing.Size(105, 22);
            this.deFechaNacimiento.TabIndex = 180;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(671, 42);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(106, 16);
            this.labelControl3.TabIndex = 179;
            this.labelControl3.Text = "Fecha Nacimiento:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(11, 12);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(91, 16);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Fecha Solicitud:";
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(108, 9);
            this.deFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFecha.Size = new System.Drawing.Size(105, 22);
            this.deFecha.TabIndex = 9;
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(108, 69);
            this.txtCargo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCargo.Properties.MaxLength = 100;
            this.txtCargo.Properties.ReadOnly = true;
            this.txtCargo.Size = new System.Drawing.Size(555, 22);
            this.txtCargo.TabIndex = 145;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 72);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 16);
            this.labelControl2.TabIndex = 146;
            this.labelControl2.Text = "Cargo:";
            // 
            // labelControl23
            // 
            this.labelControl23.Location = new System.Drawing.Point(11, 42);
            this.labelControl23.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(55, 16);
            this.labelControl23.TabIndex = 184;
            this.labelControl23.Text = "Empresa:";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Location = new System.Drawing.Point(108, 39);
            this.txtEmpresa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmpresa.Properties.MaxLength = 100;
            this.txtEmpresa.Properties.ReadOnly = true;
            this.txtEmpresa.Size = new System.Drawing.Size(555, 22);
            this.txtEmpresa.TabIndex = 183;
            // 
            // txtSolicitante
            // 
            this.txtSolicitante.Location = new System.Drawing.Point(464, 9);
            this.txtSolicitante.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSolicitante.Name = "txtSolicitante";
            this.txtSolicitante.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSolicitante.Properties.MaxLength = 50;
            this.txtSolicitante.Size = new System.Drawing.Size(465, 22);
            this.txtSolicitante.TabIndex = 178;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(394, 12);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(64, 16);
            this.labelControl5.TabIndex = 176;
            this.labelControl5.Text = "Solicitante:";
            // 
            // btnBuscarSolicitante
            // 
            this.btnBuscarSolicitante.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarSolicitante.Image")));
            this.btnBuscarSolicitante.Location = new System.Drawing.Point(930, 8);
            this.btnBuscarSolicitante.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscarSolicitante.Name = "btnBuscarSolicitante";
            this.btnBuscarSolicitante.Size = new System.Drawing.Size(28, 23);
            this.btnBuscarSolicitante.TabIndex = 177;
            this.btnBuscarSolicitante.Click += new System.EventHandler(this.btnBuscarSolicitante_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(1083, 502);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 122;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(990, 502);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 121;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmRegSctrEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 540);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.xtraTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegSctrEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmRegSctrEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSctr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSctr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNacionalidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSexo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaNacimiento.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaNacimiento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCargo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSolicitante.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        public DevExpress.XtraEditors.LookUpEdit cboNacionalidad;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtSexo;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.LookUpEdit cboTipoDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.LookUpEdit cboMes;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtDni;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        public DevExpress.XtraEditors.DateEdit deFechaNacimiento;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.DateEdit deFecha;
        private DevExpress.XtraEditors.TextEdit txtCargo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraEditors.TextEdit txtEmpresa;
        private DevExpress.XtraEditors.TextEdit txtSolicitante;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnBuscarSolicitante;
        private DevExpress.XtraGrid.GridControl gcSctr;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSctr;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gcEmpresaResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaSolicitud;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gcAreaResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        public DevExpress.XtraEditors.SimpleButton btnEliminar;
        public DevExpress.XtraEditors.SimpleButton btnAdcionar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}