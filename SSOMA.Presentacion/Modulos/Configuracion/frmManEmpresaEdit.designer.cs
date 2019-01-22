namespace SSOMA.Presentacion.Modulos.Configuracion
{
    partial class frmManEmpresaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManEmpresaEdit));
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.cboTipoEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumeroTrabajadores = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtActividadEconomica = new DevExpress.XtraEditors.TextEdit();
            this.txtRuc = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTelefono = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtRazonSocial = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDireccion = new DevExpress.XtraEditors.TextEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.btnEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.picImage = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroTrabajadores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActividadEconomica.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefono.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRazonSocial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.labelControl11);
            this.groupControl3.Controls.Add(this.btnEliminar);
            this.groupControl3.Controls.Add(this.btnAgregar);
            this.groupControl3.Controls.Add(this.picImage);
            this.groupControl3.Controls.Add(this.cboTipoEmpresa);
            this.groupControl3.Controls.Add(this.labelControl7);
            this.groupControl3.Controls.Add(this.txtNumeroTrabajadores);
            this.groupControl3.Controls.Add(this.labelControl6);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Controls.Add(this.txtActividadEconomica);
            this.groupControl3.Controls.Add(this.txtRuc);
            this.groupControl3.Controls.Add(this.labelControl4);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Controls.Add(this.txtTelefono);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.txtRazonSocial);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Controls.Add(this.txtDireccion);
            this.groupControl3.Location = new System.Drawing.Point(1, 2);
            this.groupControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(894, 242);
            this.groupControl3.TabIndex = 0;
            this.groupControl3.Text = "Datos";
            // 
            // cboTipoEmpresa
            // 
            this.cboTipoEmpresa.Location = new System.Drawing.Point(132, 198);
            this.cboTipoEmpresa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTipoEmpresa.Name = "cboTipoEmpresa";
            this.cboTipoEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoEmpresa.Properties.NullText = "";
            this.cboTipoEmpresa.Size = new System.Drawing.Size(285, 22);
            this.cboTipoEmpresa.TabIndex = 13;
            this.cboTipoEmpresa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTipoEmpresa_KeyPress);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(14, 202);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(30, 16);
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "Tipo:";
            // 
            // txtNumeroTrabajadores
            // 
            this.txtNumeroTrabajadores.Location = new System.Drawing.Point(132, 171);
            this.txtNumeroTrabajadores.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumeroTrabajadores.Name = "txtNumeroTrabajadores";
            this.txtNumeroTrabajadores.Properties.DisplayFormat.FormatString = "f0";
            this.txtNumeroTrabajadores.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNumeroTrabajadores.Properties.Mask.EditMask = "f0";
            this.txtNumeroTrabajadores.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNumeroTrabajadores.Properties.MaxLength = 4;
            this.txtNumeroTrabajadores.Size = new System.Drawing.Size(54, 22);
            this.txtNumeroTrabajadores.TabIndex = 11;
            this.txtNumeroTrabajadores.ToolTip = "Periodo";
            this.txtNumeroTrabajadores.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroTrabajadores_KeyPress);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(15, 175);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(100, 16);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "N° Trabajadores:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(14, 148);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(114, 16);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Activiad Económica:";
            // 
            // txtActividadEconomica
            // 
            this.txtActividadEconomica.Location = new System.Drawing.Point(132, 144);
            this.txtActividadEconomica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtActividadEconomica.Name = "txtActividadEconomica";
            this.txtActividadEconomica.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtActividadEconomica.Properties.MaxLength = 100;
            this.txtActividadEconomica.Size = new System.Drawing.Size(517, 22);
            this.txtActividadEconomica.TabIndex = 9;
            this.txtActividadEconomica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtActividadEconomica_KeyPress);
            // 
            // txtRuc
            // 
            this.txtRuc.Location = new System.Drawing.Point(132, 36);
            this.txtRuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRuc.Properties.MaxLength = 11;
            this.txtRuc.Size = new System.Drawing.Size(143, 22);
            this.txtRuc.TabIndex = 1;
            this.txtRuc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRuc_KeyPress);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(15, 39);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(29, 16);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "RUC:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 121);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 16);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(132, 117);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelefono.Properties.MaxLength = 20;
            this.txtTelefono.Size = new System.Drawing.Size(143, 22);
            this.txtTelefono.TabIndex = 7;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 66);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(78, 16);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Razón Social:";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(132, 63);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRazonSocial.Size = new System.Drawing.Size(517, 22);
            this.txtRazonSocial.TabIndex = 3;
            this.txtRazonSocial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRazonSocial_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 94);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(57, 16);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(132, 90);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Size = new System.Drawing.Size(517, 22);
            this.txtDireccion.TabIndex = 5;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(803, 252);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(707, 252);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(751, 220);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(27, 16);
            this.labelControl11.TabIndex = 44;
            this.labelControl11.Text = "Logo";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageIndex = 1;
            this.btnEliminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(853, 69);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(29, 28);
            this.btnEliminar.TabIndex = 42;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageIndex = 1;
            this.btnAgregar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(853, 39);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(29, 28);
            this.btnAgregar.TabIndex = 43;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // picImage
            // 
            this.picImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.picImage.EditValue = ((object)(resources.GetObject("picImage.EditValue")));
            this.picImage.Location = new System.Drawing.Point(678, 36);
            this.picImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picImage.Name = "picImage";
            this.picImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.picImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picImage.Properties.ZoomAccelerationFactor = 1D;
            this.picImage.Size = new System.Drawing.Size(167, 176);
            this.picImage.TabIndex = 41;
            // 
            // frmManEmpresaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 283);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.groupControl3);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManEmpresaEdit";
            this.Load += new System.EventHandler(this.frmManEmpresaEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroTrabajadores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActividadEconomica.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefono.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRazonSocial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDireccion;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtRazonSocial;
        private DevExpress.XtraEditors.TextEdit txtRuc;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtTelefono;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtActividadEconomica;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.TextEdit txtNumeroTrabajadores;
        public DevExpress.XtraEditors.LookUpEdit cboTipoEmpresa;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.SimpleButton btnEliminar;
        private DevExpress.XtraEditors.SimpleButton btnAgregar;
        private DevExpress.XtraEditors.PictureEdit picImage;
    }
}