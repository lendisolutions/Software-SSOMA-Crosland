namespace SSOMA.Presentacion.Modulos.Configuracion
{
    partial class frmManHoraTrabajada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManHoraTrabajada));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.btnImportarHoras = new DevExpress.XtraEditors.SimpleButton();
            this.gcHoraTrabajada = new DevExpress.XtraGrid.GridControl();
            this.gvHoraTrabajada = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEmpresaResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHoraTrabajada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHoraTrabajada)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.btnConsultar);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtPeriodo);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblFecha);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnImportarHoras);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcHoraTrabajada);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1167, 649);
            this.splitContainerControl1.SplitterPosition = 52;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(153, 16);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(85, 25);
            this.btnConsultar.TabIndex = 64;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(61, 16);
            this.txtPeriodo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(86, 22);
            this.txtPeriodo.TabIndex = 63;
            this.txtPeriodo.ToolTip = "Numero de Incidente";
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(7, 20);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(48, 16);
            this.lblFecha.TabIndex = 62;
            this.lblFecha.Text = "Periodo:";
            // 
            // btnImportarHoras
            // 
            this.btnImportarHoras.Image = global::SSOMA.Presentacion.Properties.Resources.Excel_16x16;
            this.btnImportarHoras.Location = new System.Drawing.Point(255, 15);
            this.btnImportarHoras.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnImportarHoras.Name = "btnImportarHoras";
            this.btnImportarHoras.Size = new System.Drawing.Size(132, 26);
            this.btnImportarHoras.TabIndex = 28;
            this.btnImportarHoras.Text = "Importar Horas";
            this.btnImportarHoras.Click += new System.EventHandler(this.btnImportarHoras_Click);
            // 
            // gcHoraTrabajada
            // 
            this.gcHoraTrabajada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHoraTrabajada.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcHoraTrabajada.Location = new System.Drawing.Point(0, 0);
            this.gcHoraTrabajada.MainView = this.gvHoraTrabajada;
            this.gcHoraTrabajada.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcHoraTrabajada.Name = "gcHoraTrabajada";
            this.gcHoraTrabajada.Size = new System.Drawing.Size(1167, 591);
            this.gcHoraTrabajada.TabIndex = 66;
            this.gcHoraTrabajada.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHoraTrabajada});
            // 
            // gvHoraTrabajada
            // 
            this.gvHoraTrabajada.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvHoraTrabajada.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Navy;
            this.gvHoraTrabajada.Appearance.ViewCaption.Options.UseFont = true;
            this.gvHoraTrabajada.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gvHoraTrabajada.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn4,
            this.gcEmpresaResponsable,
            this.gridColumn3,
            this.gridColumn5});
            this.gvHoraTrabajada.GridControl = this.gcHoraTrabajada;
            this.gvHoraTrabajada.Name = "gvHoraTrabajada";
            this.gvHoraTrabajada.OptionsSelection.MultiSelect = true;
            this.gvHoraTrabajada.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvHoraTrabajada.OptionsView.ColumnAutoWidth = false;
            this.gvHoraTrabajada.OptionsView.ShowGroupPanel = false;
            this.gvHoraTrabajada.OptionsView.ShowViewCaption = true;
            this.gvHoraTrabajada.ViewCaption = "LISTADO DE HORAS TRABAJADAS";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mes";
            this.gridColumn2.FieldName = "DescMes";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "CROSLAND LOGISTICA SAC";
            this.gridColumn1.FieldName = "CROSLAND_LOGISTICA_SAC";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 180;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "CROSLAND FINANZAS SAC";
            this.gridColumn4.FieldName = "CROSLAND_FINANZAS_SAC";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 180;
            // 
            // gcEmpresaResponsable
            // 
            this.gcEmpresaResponsable.Caption = "CROSLAND REPUESTOS SAC";
            this.gcEmpresaResponsable.FieldName = "CROSLAND_REPUESTOS_SAC";
            this.gcEmpresaResponsable.Name = "gcEmpresaResponsable";
            this.gcEmpresaResponsable.OptionsColumn.AllowEdit = false;
            this.gcEmpresaResponsable.OptionsColumn.AllowFocus = false;
            this.gcEmpresaResponsable.Visible = true;
            this.gcEmpresaResponsable.VisibleIndex = 3;
            this.gcEmpresaResponsable.Width = 180;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "CROSLAND_AUTOMOTRIZ_SAC";
            this.gridColumn3.FieldName = "CROSLAND_AUTOMOTRIZ_SAC";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 180;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "CROSLAND_TECNICA_SAC";
            this.gridColumn5.FieldName = "CROSLAND_TECNICA_SAC";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 180;
            // 
            // frmManHoraTrabajada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 649);
            this.Controls.Add(this.splitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManHoraTrabajada";
            this.Text = "Mantenimiento - Horas Trabajadas";
            this.Load += new System.EventHandler(this.frmManHoraTrabajada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHoraTrabajada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHoraTrabajada)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btnImportarHoras;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraGrid.GridControl gcHoraTrabajada;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHoraTrabajada;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcEmpresaResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}