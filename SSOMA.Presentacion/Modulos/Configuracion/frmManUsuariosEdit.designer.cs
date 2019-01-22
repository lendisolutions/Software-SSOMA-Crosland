namespace SSOMA.Presentacion.Modulos.Configuracion
{
    partial class frmManUsuariosEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManUsuariosEdit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.chkMaster = new DevExpress.XtraEditors.CheckEdit();
            this.lblMaster = new DevExpress.XtraEditors.LabelControl();
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.lblEmpresa = new DevExpress.XtraEditors.LabelControl();
            this.cboPerfil = new DevExpress.XtraEditors.LookUpEdit();
            this.lblPerfil = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.txtPersona = new DevExpress.XtraEditors.TextEdit();
            this.lblDes = new DevExpress.XtraEditors.LabelControl();
            this.chkEstado = new DevExpress.XtraEditors.CheckEdit();
            this.lblUsuario = new DevExpress.XtraEditors.LabelControl();
            this.lblEstado = new DevExpress.XtraEditors.LabelControl();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.trwMenu = new System.Windows.Forms.TreeView();
            this.grpPermisos = new System.Windows.Forms.GroupBox();
            this.lblMenu = new System.Windows.Forms.Label();
            this.chkAllowPrint = new System.Windows.Forms.CheckBox();
            this.chkAllowWrite = new System.Windows.Forms.CheckBox();
            this.chkAllowUpdate = new System.Windows.Forms.CheckBox();
            this.chkAllowDelete = new System.Windows.Forms.CheckBox();
            this.chkAllowRead = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tvwUnidadNegocio = new System.Windows.Forms.TreeView();
            this.imgLista = new System.Windows.Forms.ImageList(this.components);
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMaster.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPerfil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersona.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEstado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            this.grpPermisos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.chkMaster);
            this.panel1.Controls.Add(this.lblMaster);
            this.panel1.Controls.Add(this.cboEmpresa);
            this.panel1.Controls.Add(this.lblEmpresa);
            this.panel1.Controls.Add(this.cboPerfil);
            this.panel1.Controls.Add(this.lblPerfil);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.txtPersona);
            this.panel1.Controls.Add(this.lblDes);
            this.panel1.Controls.Add(this.chkEstado);
            this.panel1.Controls.Add(this.lblUsuario);
            this.panel1.Controls.Add(this.lblEstado);
            this.panel1.Controls.Add(this.txtUsuario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1035, 198);
            this.panel1.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(636, 73);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(28, 23);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // chkMaster
            // 
            this.chkMaster.Location = new System.Drawing.Point(96, 153);
            this.chkMaster.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkMaster.Name = "chkMaster";
            this.chkMaster.Properties.Caption = "";
            this.chkMaster.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.chkMaster.Size = new System.Drawing.Size(87, 22);
            this.chkMaster.TabIndex = 11;
            // 
            // lblMaster
            // 
            this.lblMaster.Location = new System.Drawing.Point(19, 156);
            this.lblMaster.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblMaster.Name = "lblMaster";
            this.lblMaster.Size = new System.Drawing.Size(44, 16);
            this.lblMaster.TabIndex = 10;
            this.lblMaster.Text = "Master:";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Location = new System.Drawing.Point(98, 21);
            this.cboEmpresa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.cboEmpresa.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.cboEmpresa.Properties.ShowFooter = false;
            this.cboEmpresa.Properties.ShowHeader = false;
            this.cboEmpresa.Size = new System.Drawing.Size(539, 22);
            this.cboEmpresa.TabIndex = 1;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Location = new System.Drawing.Point(19, 27);
            this.lblEmpresa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(55, 16);
            this.lblEmpresa.TabIndex = 0;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // cboPerfil
            // 
            this.cboPerfil.Location = new System.Drawing.Point(98, 47);
            this.cboPerfil.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboPerfil.Name = "cboPerfil";
            this.cboPerfil.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPerfil.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.cboPerfil.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.cboPerfil.Properties.ShowFooter = false;
            this.cboPerfil.Properties.ShowHeader = false;
            this.cboPerfil.Size = new System.Drawing.Size(539, 22);
            this.cboPerfil.TabIndex = 3;
            this.cboPerfil.EditValueChanged += new System.EventHandler(this.cboPerfil_EditValueChanged);
            // 
            // lblPerfil
            // 
            this.lblPerfil.Location = new System.Drawing.Point(19, 55);
            this.lblPerfil.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(34, 16);
            this.lblPerfil.TabIndex = 2;
            this.lblPerfil.Text = "Perfil:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(98, 124);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(117, 22);
            this.txtPassword.TabIndex = 9;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(19, 130);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 16);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password:";
            // 
            // txtPersona
            // 
            this.txtPersona.Location = new System.Drawing.Point(98, 73);
            this.txtPersona.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPersona.Name = "txtPersona";
            this.txtPersona.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPersona.Size = new System.Drawing.Size(539, 22);
            this.txtPersona.TabIndex = 5;
            // 
            // lblDes
            // 
            this.lblDes.Location = new System.Drawing.Point(19, 80);
            this.lblDes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDes.Name = "lblDes";
            this.lblDes.Size = new System.Drawing.Size(70, 16);
            this.lblDes.TabIndex = 4;
            this.lblDes.Text = "Descripción:";
            // 
            // chkEstado
            // 
            this.chkEstado.Location = new System.Drawing.Point(610, 153);
            this.chkEstado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Properties.Caption = "";
            this.chkEstado.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.chkEstado.Size = new System.Drawing.Size(22, 22);
            this.chkEstado.TabIndex = 13;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Location = new System.Drawing.Point(19, 106);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(48, 16);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(562, 156);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 16);
            this.lblEstado.TabIndex = 12;
            this.lblEstado.Text = "Estado:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(98, 98);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtUsuario.Size = new System.Drawing.Size(117, 22);
            this.txtUsuario.TabIndex = 7;
            // 
            // trwMenu
            // 
            this.trwMenu.CheckBoxes = true;
            this.trwMenu.Location = new System.Drawing.Point(6, 206);
            this.trwMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trwMenu.Name = "trwMenu";
            this.trwMenu.Size = new System.Drawing.Size(437, 463);
            this.trwMenu.TabIndex = 2;
            this.trwMenu.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trwMenu_AfterCheck);
            this.trwMenu.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trwMenu_NodeMouseClick);
            // 
            // grpPermisos
            // 
            this.grpPermisos.Controls.Add(this.lblMenu);
            this.grpPermisos.Controls.Add(this.chkAllowPrint);
            this.grpPermisos.Controls.Add(this.chkAllowWrite);
            this.grpPermisos.Controls.Add(this.chkAllowUpdate);
            this.grpPermisos.Controls.Add(this.chkAllowDelete);
            this.grpPermisos.Controls.Add(this.chkAllowRead);
            this.grpPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPermisos.Location = new System.Drawing.Point(453, 206);
            this.grpPermisos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpPermisos.Name = "grpPermisos";
            this.grpPermisos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpPermisos.Size = new System.Drawing.Size(180, 418);
            this.grpPermisos.TabIndex = 1;
            this.grpPermisos.TabStop = false;
            this.grpPermisos.Text = "Permisos";
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.BackColor = System.Drawing.Color.Transparent;
            this.lblMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(27, 42);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(0, 17);
            this.lblMenu.TabIndex = 0;
            // 
            // chkAllowPrint
            // 
            this.chkAllowPrint.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowPrint.Image = ((System.Drawing.Image)(resources.GetObject("chkAllowPrint.Image")));
            this.chkAllowPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAllowPrint.Location = new System.Drawing.Point(20, 214);
            this.chkAllowPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAllowPrint.Name = "chkAllowPrint";
            this.chkAllowPrint.Size = new System.Drawing.Size(103, 31);
            this.chkAllowPrint.TabIndex = 5;
            this.chkAllowPrint.Text = "Imprimir";
            this.chkAllowPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllowPrint.UseVisualStyleBackColor = false;
            this.chkAllowPrint.CheckedChanged += new System.EventHandler(this.chkAllowRead_CheckedChanged);
            // 
            // chkAllowWrite
            // 
            this.chkAllowWrite.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowWrite.Image = ((System.Drawing.Image)(resources.GetObject("chkAllowWrite.Image")));
            this.chkAllowWrite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAllowWrite.Location = new System.Drawing.Point(20, 100);
            this.chkAllowWrite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAllowWrite.Name = "chkAllowWrite";
            this.chkAllowWrite.Size = new System.Drawing.Size(110, 34);
            this.chkAllowWrite.TabIndex = 2;
            this.chkAllowWrite.Text = "Escritura";
            this.chkAllowWrite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllowWrite.UseVisualStyleBackColor = false;
            this.chkAllowWrite.CheckedChanged += new System.EventHandler(this.chkAllowRead_CheckedChanged);
            // 
            // chkAllowUpdate
            // 
            this.chkAllowUpdate.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowUpdate.Image = ((System.Drawing.Image)(resources.GetObject("chkAllowUpdate.Image")));
            this.chkAllowUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAllowUpdate.Location = new System.Drawing.Point(20, 138);
            this.chkAllowUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAllowUpdate.Name = "chkAllowUpdate";
            this.chkAllowUpdate.Size = new System.Drawing.Size(112, 34);
            this.chkAllowUpdate.TabIndex = 3;
            this.chkAllowUpdate.Text = "Modificar";
            this.chkAllowUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllowUpdate.UseVisualStyleBackColor = false;
            this.chkAllowUpdate.CheckedChanged += new System.EventHandler(this.chkAllowRead_CheckedChanged);
            // 
            // chkAllowDelete
            // 
            this.chkAllowDelete.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowDelete.Image = ((System.Drawing.Image)(resources.GetObject("chkAllowDelete.Image")));
            this.chkAllowDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAllowDelete.Location = new System.Drawing.Point(20, 176);
            this.chkAllowDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAllowDelete.Name = "chkAllowDelete";
            this.chkAllowDelete.Size = new System.Drawing.Size(103, 34);
            this.chkAllowDelete.TabIndex = 4;
            this.chkAllowDelete.Text = "Eliminar";
            this.chkAllowDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllowDelete.UseVisualStyleBackColor = false;
            this.chkAllowDelete.CheckedChanged += new System.EventHandler(this.chkAllowRead_CheckedChanged);
            // 
            // chkAllowRead
            // 
            this.chkAllowRead.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowRead.Image = ((System.Drawing.Image)(resources.GetObject("chkAllowRead.Image")));
            this.chkAllowRead.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAllowRead.Location = new System.Drawing.Point(20, 62);
            this.chkAllowRead.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAllowRead.Name = "chkAllowRead";
            this.chkAllowRead.Size = new System.Drawing.Size(112, 34);
            this.chkAllowRead.TabIndex = 1;
            this.chkAllowRead.Text = "Lectura  ";
            this.chkAllowRead.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllowRead.UseVisualStyleBackColor = false;
            this.chkAllowRead.CheckedChanged += new System.EventHandler(this.chkAllowRead_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tvwUnidadNegocio);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(639, 206);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(395, 464);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permisos de Sedes";
            // 
            // tvwUnidadNegocio
            // 
            this.tvwUnidadNegocio.CheckBoxes = true;
            this.tvwUnidadNegocio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwUnidadNegocio.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwUnidadNegocio.ImageIndex = 0;
            this.tvwUnidadNegocio.ImageList = this.imgLista;
            this.tvwUnidadNegocio.Location = new System.Drawing.Point(3, 20);
            this.tvwUnidadNegocio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tvwUnidadNegocio.Name = "tvwUnidadNegocio";
            this.tvwUnidadNegocio.SelectedImageIndex = 0;
            this.tvwUnidadNegocio.Size = new System.Drawing.Size(389, 440);
            this.tvwUnidadNegocio.TabIndex = 3;
            this.tvwUnidadNegocio.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwUnidadNegocio_AfterCheck);
            // 
            // imgLista
            // 
            this.imgLista.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLista.ImageStream")));
            this.imgLista.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLista.Images.SetKeyName(0, "Empresa_16x16.gif");
            this.imgLista.Images.SetKeyName(1, "UnidadMinera_16x16.gif");
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(545, 641);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(450, 641);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmManUsuariosEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 672);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grpPermisos);
            this.Controls.Add(this.trwMenu);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmManUsuariosEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Usuarios";
            this.Load += new System.EventHandler(this.frmManUsuariosEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMaster.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPerfil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersona.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEstado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            this.grpPermisos.ResumeLayout(false);
            this.grpPermisos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.CheckEdit chkMaster;
        private DevExpress.XtraEditors.LabelControl lblMaster;
        private DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraEditors.LabelControl lblEmpresa;
        private DevExpress.XtraEditors.LookUpEdit cboPerfil;
        private DevExpress.XtraEditors.LabelControl lblPerfil;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.TextEdit txtPersona;
        private DevExpress.XtraEditors.LabelControl lblDes;
        private DevExpress.XtraEditors.CheckEdit chkEstado;
        private DevExpress.XtraEditors.LabelControl lblUsuario;
        private DevExpress.XtraEditors.LabelControl lblEstado;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private System.Windows.Forms.TreeView trwMenu;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private System.Windows.Forms.GroupBox grpPermisos;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.CheckBox chkAllowWrite;
        private System.Windows.Forms.CheckBox chkAllowUpdate;
        private System.Windows.Forms.CheckBox chkAllowDelete;
        private System.Windows.Forms.CheckBox chkAllowRead;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tvwUnidadNegocio;
        private System.Windows.Forms.CheckBox chkAllowPrint;
        private System.Windows.Forms.ImageList imgLista;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
    }
}