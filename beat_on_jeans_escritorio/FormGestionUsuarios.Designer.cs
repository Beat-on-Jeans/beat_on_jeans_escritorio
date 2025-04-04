namespace beat_on_jeans_escritorio
{
    partial class FormGestionUsuarios
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBoxRolFiltro = new System.Windows.Forms.ComboBox();
            this.bindingSourceRoles = new System.Windows.Forms.BindingSource(this.components);
            this.buttonEliminarUsuario = new System.Windows.Forms.Button();
            this.buttonCrearUsuario = new System.Windows.Forms.Button();
            this.bindingSourceUsuarios = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.comboBoxBuscarUsuario = new System.Windows.Forms.ComboBox();
            this.bindingSourceGmails = new System.Windows.Forms.BindingSource(this.components);
            this.buttonModificarUsuario = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rOLIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contrasenaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioMobilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuariosCSharpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelContrasena = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonLimipiar = new System.Windows.Forms.Button();
            this.textBoxUbicacion = new System.Windows.Forms.TextBox();
            this.labelCodigoUbicacion = new System.Windows.Forms.Label();
            this.comboBoxRol = new System.Windows.Forms.ComboBox();
            this.textBoxContrasena = new System.Windows.Forms.TextBox();
            this.textBoxCorreo = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelCorreo = new System.Windows.Forms.Label();
            this.labelRol = new System.Windows.Forms.Label();
            this.groupBoxBotones = new System.Windows.Forms.GroupBox();
            this.comboBoxAccionUsuario = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGmails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Figtree", 11.25F);
            label1.Location = new System.Drawing.Point(245, 247);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(108, 18);
            label1.TabIndex = 10;
            label1.Text = "Buscar Usuario";
            // 
            // comboBoxRolFiltro
            // 
            this.comboBoxRolFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(226)))));
            this.comboBoxRolFiltro.DataSource = this.bindingSourceRoles;
            this.comboBoxRolFiltro.DisplayMember = "Nombre_Rol";
            this.comboBoxRolFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRolFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxRolFiltro.Font = new System.Drawing.Font("Figtree", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRolFiltro.FormattingEnabled = true;
            this.comboBoxRolFiltro.Location = new System.Drawing.Point(31, 276);
            this.comboBoxRolFiltro.Name = "comboBoxRolFiltro";
            this.comboBoxRolFiltro.Size = new System.Drawing.Size(179, 28);
            this.comboBoxRolFiltro.TabIndex = 1;
            this.comboBoxRolFiltro.ValueMember = "ID";
            // 
            // bindingSourceRoles
            // 
            this.bindingSourceRoles.DataSource = typeof(beat_on_jeans_escritorio.Models.Roles);
            // 
            // buttonEliminarUsuario
            // 
            this.buttonEliminarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(196)))), ((int)(((byte)(182)))));
            this.buttonEliminarUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonEliminarUsuario.FlatAppearance.BorderSize = 0;
            this.buttonEliminarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEliminarUsuario.Font = new System.Drawing.Font("Figtree", 10F, System.Drawing.FontStyle.Bold);
            this.buttonEliminarUsuario.ForeColor = System.Drawing.Color.White;
            this.buttonEliminarUsuario.Location = new System.Drawing.Point(117, 132);
            this.buttonEliminarUsuario.Name = "buttonEliminarUsuario";
            this.buttonEliminarUsuario.Size = new System.Drawing.Size(127, 32);
            this.buttonEliminarUsuario.TabIndex = 3;
            this.buttonEliminarUsuario.Text = "Eliminar";
            this.buttonEliminarUsuario.UseVisualStyleBackColor = false;
            this.buttonEliminarUsuario.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonCrearUsuario
            // 
            this.buttonCrearUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(104)))), ((int)(((byte)(27)))));
            this.buttonCrearUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonCrearUsuario.FlatAppearance.BorderSize = 0;
            this.buttonCrearUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCrearUsuario.Font = new System.Drawing.Font("Figtree", 10F, System.Drawing.FontStyle.Bold);
            this.buttonCrearUsuario.ForeColor = System.Drawing.Color.White;
            this.buttonCrearUsuario.Location = new System.Drawing.Point(106, 132);
            this.buttonCrearUsuario.Name = "buttonCrearUsuario";
            this.buttonCrearUsuario.Size = new System.Drawing.Size(147, 31);
            this.buttonCrearUsuario.TabIndex = 4;
            this.buttonCrearUsuario.Text = "Crear Usuario";
            this.buttonCrearUsuario.UseVisualStyleBackColor = false;
            this.buttonCrearUsuario.Click += new System.EventHandler(this.buttonCrearUsuario_Click);
            // 
            // bindingSourceUsuarios
            // 
            this.bindingSourceUsuarios.DataSource = typeof(beat_on_jeans_escritorio.Models.Usuarios);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::beat_on_jeans_escritorio.Properties.Resources.RectangleNaranja;
            this.pictureBox4.Location = new System.Drawing.Point(93, 119);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(172, 56);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::beat_on_jeans_escritorio.Properties.Resources.RectangleAzul;
            this.pictureBox3.Location = new System.Drawing.Point(93, 119);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(172, 56);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::beat_on_jeans_escritorio.Properties.Resources.RectangleComboBox;
            this.pictureBox5.Location = new System.Drawing.Point(22, 269);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(195, 42);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            // 
            // comboBoxBuscarUsuario
            // 
            this.comboBoxBuscarUsuario.DataSource = this.bindingSourceGmails;
            this.comboBoxBuscarUsuario.DisplayMember = "Correo";
            this.comboBoxBuscarUsuario.Font = new System.Drawing.Font("Figtree", 10.25F);
            this.comboBoxBuscarUsuario.FormattingEnabled = true;
            this.comboBoxBuscarUsuario.Location = new System.Drawing.Point(248, 279);
            this.comboBoxBuscarUsuario.Name = "comboBoxBuscarUsuario";
            this.comboBoxBuscarUsuario.Size = new System.Drawing.Size(490, 25);
            this.comboBoxBuscarUsuario.TabIndex = 13;
            this.comboBoxBuscarUsuario.ValueMember = "ROL_ID";
            this.comboBoxBuscarUsuario.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // bindingSourceGmails
            // 
            this.bindingSourceGmails.DataSource = typeof(beat_on_jeans_escritorio.Models.Usuarios);
            // 
            // buttonModificarUsuario
            // 
            this.buttonModificarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(226)))));
            this.buttonModificarUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonModificarUsuario.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(226)))));
            this.buttonModificarUsuario.FlatAppearance.BorderSize = 0;
            this.buttonModificarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModificarUsuario.Font = new System.Drawing.Font("Figtree", 10F);
            this.buttonModificarUsuario.Location = new System.Drawing.Point(104, 134);
            this.buttonModificarUsuario.Margin = new System.Windows.Forms.Padding(0);
            this.buttonModificarUsuario.Name = "buttonModificarUsuario";
            this.buttonModificarUsuario.Size = new System.Drawing.Size(149, 27);
            this.buttonModificarUsuario.TabIndex = 2;
            this.buttonModificarUsuario.Text = "Modificar usuario";
            this.buttonModificarUsuario.UseVisualStyleBackColor = false;
            this.buttonModificarUsuario.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Figtree", 11.25F);
            this.label2.Location = new System.Drawing.Point(23, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Roles";
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.AllowUserToAddRows = false;
            this.dataGridViewUsuarios.AllowUserToDeleteRows = false;
            this.dataGridViewUsuarios.AllowUserToOrderColumns = true;
            this.dataGridViewUsuarios.AllowUserToResizeColumns = false;
            this.dataGridViewUsuarios.AllowUserToResizeRows = false;
            this.dataGridViewUsuarios.AutoGenerateColumns = false;
            this.dataGridViewUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(226)))));
            this.dataGridViewUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(104)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Figtree", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(104)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewUsuarios.ColumnHeadersHeight = 30;
            this.dataGridViewUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.rOLIDDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.correoDataGridViewTextBoxColumn,
            this.contrasenaDataGridViewTextBoxColumn,
            this.rolesDataGridViewTextBoxColumn,
            this.usuarioMobilDataGridViewTextBoxColumn,
            this.usuariosCSharpDataGridViewTextBoxColumn});
            this.dataGridViewUsuarios.DataSource = this.bindingSourceUsuarios;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Figtree", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUsuarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewUsuarios.EnableHeadersVisualStyles = false;
            this.dataGridViewUsuarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(226)))));
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(22, 328);
            this.dataGridViewUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewUsuarios.MultiSelect = false;
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.ReadOnly = true;
            this.dataGridViewUsuarios.RowHeadersVisible = false;
            this.dataGridViewUsuarios.RowHeadersWidth = 25;
            this.dataGridViewUsuarios.RowTemplate.Height = 24;
            this.dataGridViewUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(883, 262);
            this.dataGridViewUsuarios.TabIndex = 15;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rOLIDDataGridViewTextBoxColumn
            // 
            this.rOLIDDataGridViewTextBoxColumn.DataPropertyName = "ROL_ID";
            this.rOLIDDataGridViewTextBoxColumn.HeaderText = "ROL_ID";
            this.rOLIDDataGridViewTextBoxColumn.Name = "rOLIDDataGridViewTextBoxColumn";
            this.rOLIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // correoDataGridViewTextBoxColumn
            // 
            this.correoDataGridViewTextBoxColumn.DataPropertyName = "Correo";
            this.correoDataGridViewTextBoxColumn.HeaderText = "Correo";
            this.correoDataGridViewTextBoxColumn.Name = "correoDataGridViewTextBoxColumn";
            this.correoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contrasenaDataGridViewTextBoxColumn
            // 
            this.contrasenaDataGridViewTextBoxColumn.DataPropertyName = "Contrasena";
            this.contrasenaDataGridViewTextBoxColumn.HeaderText = "Contrasena";
            this.contrasenaDataGridViewTextBoxColumn.Name = "contrasenaDataGridViewTextBoxColumn";
            this.contrasenaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rolesDataGridViewTextBoxColumn
            // 
            this.rolesDataGridViewTextBoxColumn.DataPropertyName = "Roles";
            this.rolesDataGridViewTextBoxColumn.HeaderText = "Roles";
            this.rolesDataGridViewTextBoxColumn.Name = "rolesDataGridViewTextBoxColumn";
            this.rolesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioMobilDataGridViewTextBoxColumn
            // 
            this.usuarioMobilDataGridViewTextBoxColumn.DataPropertyName = "UsuarioMobil";
            this.usuarioMobilDataGridViewTextBoxColumn.HeaderText = "UsuarioMobil";
            this.usuarioMobilDataGridViewTextBoxColumn.Name = "usuarioMobilDataGridViewTextBoxColumn";
            this.usuarioMobilDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuariosCSharpDataGridViewTextBoxColumn
            // 
            this.usuariosCSharpDataGridViewTextBoxColumn.DataPropertyName = "UsuariosCSharp";
            this.usuariosCSharpDataGridViewTextBoxColumn.HeaderText = "UsuariosCSharp";
            this.usuariosCSharpDataGridViewTextBoxColumn.Name = "usuariosCSharpDataGridViewTextBoxColumn";
            this.usuariosCSharpDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Figtree", 11.25F);
            this.labelNombre.Location = new System.Drawing.Point(21, 31);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(64, 18);
            this.labelNombre.TabIndex = 17;
            this.labelNombre.Text = "Nombre";
            // 
            // labelContrasena
            // 
            this.labelContrasena.AutoSize = true;
            this.labelContrasena.Font = new System.Drawing.Font("Figtree", 11.25F);
            this.labelContrasena.Location = new System.Drawing.Point(21, 145);
            this.labelContrasena.Name = "labelContrasena";
            this.labelContrasena.Size = new System.Drawing.Size(86, 18);
            this.labelContrasena.TabIndex = 18;
            this.labelContrasena.Text = "Contraseña";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonLimipiar);
            this.groupBox1.Controls.Add(this.textBoxUbicacion);
            this.groupBox1.Controls.Add(this.labelCodigoUbicacion);
            this.groupBox1.Controls.Add(this.comboBoxRol);
            this.groupBox1.Controls.Add(this.textBoxContrasena);
            this.groupBox1.Controls.Add(this.textBoxCorreo);
            this.groupBox1.Controls.Add(this.textBoxNombre);
            this.groupBox1.Controls.Add(this.labelCorreo);
            this.groupBox1.Controls.Add(this.labelContrasena);
            this.groupBox1.Controls.Add(this.labelNombre);
            this.groupBox1.Controls.Add(this.labelRol);
            this.groupBox1.Font = new System.Drawing.Font("Figtree", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 213);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info Usuario";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonLimipiar
            // 
            this.buttonLimipiar.Location = new System.Drawing.Point(458, 184);
            this.buttonLimipiar.Name = "buttonLimipiar";
            this.buttonLimipiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimipiar.TabIndex = 29;
            this.buttonLimipiar.Text = "Limpiar";
            this.buttonLimipiar.UseVisualStyleBackColor = true;
            this.buttonLimipiar.Click += new System.EventHandler(this.buttonLimipiar_Click);
            // 
            // textBoxUbicacion
            // 
            this.textBoxUbicacion.AcceptsTab = true;
            this.textBoxUbicacion.Font = new System.Drawing.Font("Figtree", 10F);
            this.textBoxUbicacion.Location = new System.Drawing.Point(315, 112);
            this.textBoxUbicacion.Name = "textBoxUbicacion";
            this.textBoxUbicacion.Size = new System.Drawing.Size(218, 23);
            this.textBoxUbicacion.TabIndex = 28;
            // 
            // labelCodigoUbicacion
            // 
            this.labelCodigoUbicacion.AutoSize = true;
            this.labelCodigoUbicacion.Font = new System.Drawing.Font("Figtree", 11.25F);
            this.labelCodigoUbicacion.Location = new System.Drawing.Point(312, 91);
            this.labelCodigoUbicacion.Name = "labelCodigoUbicacion";
            this.labelCodigoUbicacion.Size = new System.Drawing.Size(75, 18);
            this.labelCodigoUbicacion.TabIndex = 25;
            this.labelCodigoUbicacion.Text = "Ubicación";
            // 
            // comboBoxRol
            // 
            this.comboBoxRol.DataSource = this.bindingSourceRoles;
            this.comboBoxRol.DisplayMember = "Nombre_Rol";
            this.comboBoxRol.Font = new System.Drawing.Font("Figtree", 10F);
            this.comboBoxRol.FormattingEnabled = true;
            this.comboBoxRol.Location = new System.Drawing.Point(315, 52);
            this.comboBoxRol.Name = "comboBoxRol";
            this.comboBoxRol.Size = new System.Drawing.Size(218, 24);
            this.comboBoxRol.TabIndex = 24;
            this.comboBoxRol.ValueMember = "ID";
            this.comboBoxRol.SelectedIndexChanged += new System.EventHandler(this.comboBoxRol_SelectedIndexChanged);
            // 
            // textBoxContrasena
            // 
            this.textBoxContrasena.Font = new System.Drawing.Font("Figtree", 10F);
            this.textBoxContrasena.Location = new System.Drawing.Point(24, 166);
            this.textBoxContrasena.Name = "textBoxContrasena";
            this.textBoxContrasena.Size = new System.Drawing.Size(249, 23);
            this.textBoxContrasena.TabIndex = 23;
            this.textBoxContrasena.TextChanged += new System.EventHandler(this.textBoxContrasena_TextChanged);
            // 
            // textBoxCorreo
            // 
            this.textBoxCorreo.Font = new System.Drawing.Font("Figtree", 10F);
            this.textBoxCorreo.Location = new System.Drawing.Point(24, 112);
            this.textBoxCorreo.Name = "textBoxCorreo";
            this.textBoxCorreo.Size = new System.Drawing.Size(249, 23);
            this.textBoxCorreo.TabIndex = 22;
            this.textBoxCorreo.TextChanged += new System.EventHandler(this.textBoxCorreo_TextChanged);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Font = new System.Drawing.Font("Figtree", 10F);
            this.textBoxNombre.Location = new System.Drawing.Point(24, 52);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(249, 23);
            this.textBoxNombre.TabIndex = 21;
            // 
            // labelCorreo
            // 
            this.labelCorreo.AutoSize = true;
            this.labelCorreo.Font = new System.Drawing.Font("Figtree", 11.25F);
            this.labelCorreo.Location = new System.Drawing.Point(21, 91);
            this.labelCorreo.Name = "labelCorreo";
            this.labelCorreo.Size = new System.Drawing.Size(55, 18);
            this.labelCorreo.TabIndex = 19;
            this.labelCorreo.Text = "Correo";
            // 
            // labelRol
            // 
            this.labelRol.AutoSize = true;
            this.labelRol.Font = new System.Drawing.Font("Figtree", 11.25F);
            this.labelRol.Location = new System.Drawing.Point(312, 31);
            this.labelRol.Name = "labelRol";
            this.labelRol.Size = new System.Drawing.Size(29, 18);
            this.labelRol.TabIndex = 16;
            this.labelRol.Text = "Rol";
            this.labelRol.Click += new System.EventHandler(this.labelRol_Click);
            // 
            // groupBoxBotones
            // 
            this.groupBoxBotones.Controls.Add(this.comboBoxAccionUsuario);
            this.groupBoxBotones.Controls.Add(this.buttonModificarUsuario);
            this.groupBoxBotones.Controls.Add(this.pictureBox2);
            this.groupBoxBotones.Controls.Add(this.buttonCrearUsuario);
            this.groupBoxBotones.Controls.Add(this.pictureBox4);
            this.groupBoxBotones.Controls.Add(this.buttonEliminarUsuario);
            this.groupBoxBotones.Controls.Add(this.pictureBox3);
            this.groupBoxBotones.Location = new System.Drawing.Point(574, 30);
            this.groupBoxBotones.Name = "groupBoxBotones";
            this.groupBoxBotones.Size = new System.Drawing.Size(331, 213);
            this.groupBoxBotones.TabIndex = 20;
            this.groupBoxBotones.TabStop = false;
            this.groupBoxBotones.Text = "Accion con el usuario";
            // 
            // comboBoxAccionUsuario
            // 
            this.comboBoxAccionUsuario.Font = new System.Drawing.Font("Figtree", 10F);
            this.comboBoxAccionUsuario.FormattingEnabled = true;
            this.comboBoxAccionUsuario.Location = new System.Drawing.Point(6, 28);
            this.comboBoxAccionUsuario.Name = "comboBoxAccionUsuario";
            this.comboBoxAccionUsuario.Size = new System.Drawing.Size(319, 24);
            this.comboBoxAccionUsuario.TabIndex = 9;
            this.comboBoxAccionUsuario.SelectedIndexChanged += new System.EventHandler(this.comboBoxAccionUsuario_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::beat_on_jeans_escritorio.Properties.Resources.RectangleModificar;
            this.pictureBox2.Location = new System.Drawing.Point(92, 119);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(172, 56);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(763, 279);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(136, 23);
            this.buttonBuscar.TabIndex = 21;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // FormGestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 618);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.groupBoxBotones);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewUsuarios);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxBuscarUsuario);
            this.Controls.Add(label1);
            this.Controls.Add(this.comboBoxRolFiltro);
            this.Controls.Add(this.pictureBox5);
            this.Name = "FormGestionUsuarios";
            this.Text = "FormGestionUsuarios";
            this.Load += new System.EventHandler(this.FormGestionUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGmails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxRolFiltro;
        private System.Windows.Forms.Button buttonEliminarUsuario;
        private System.Windows.Forms.Button buttonCrearUsuario;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contrasenaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn correoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn musicosDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox comboBoxBuscarUsuario;
        private System.Windows.Forms.Button buttonModificarUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bindingSourceRoles;
        private System.Windows.Forms.BindingSource bindingSourceUsuarios;
        private System.Windows.Forms.DataGridView dataGridViewUsuarios;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelContrasena;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelCorreo;
        private System.Windows.Forms.TextBox textBoxContrasena;
        private System.Windows.Forms.TextBox textBoxCorreo;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.ComboBox comboBoxRol;
        private System.Windows.Forms.Label labelRol;
        private System.Windows.Forms.GroupBox groupBoxBotones;
        private System.Windows.Forms.ComboBox comboBoxAccionUsuario;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rOLIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioMobilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuariosCSharpDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonLimipiar;
        private System.Windows.Forms.TextBox textBoxUbicacion;
        private System.Windows.Forms.Label labelCodigoUbicacion;
        private System.Windows.Forms.BindingSource bindingSourceGmails;
        private System.Windows.Forms.Button buttonBuscar;
    }
}