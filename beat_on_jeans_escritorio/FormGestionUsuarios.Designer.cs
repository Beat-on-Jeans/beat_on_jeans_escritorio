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
            this.comboBoxRoles = new System.Windows.Forms.ComboBox();
            this.bindingSourceRoles = new System.Windows.Forms.BindingSource(this.components);
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonNuevoUsuario = new System.Windows.Forms.Button();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rOLIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceUsuarios = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.comboBoxBuscarUsuario = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(12, 70);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(147, 22);
            label1.TabIndex = 10;
            label1.Text = "Buscar Usuario";
            // 
            // comboBoxRoles
            // 
            this.comboBoxRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(226)))));
            this.comboBoxRoles.DataSource = this.bindingSourceRoles;
            this.comboBoxRoles.DisplayMember = "Nombre_Rol";
            this.comboBoxRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRoles.FormattingEnabled = true;
            this.comboBoxRoles.Location = new System.Drawing.Point(20, 276);
            this.comboBoxRoles.Name = "comboBoxRoles";
            this.comboBoxRoles.Size = new System.Drawing.Size(179, 28);
            this.comboBoxRoles.TabIndex = 1;
            this.comboBoxRoles.ValueMember = "ID";
            this.comboBoxRoles.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsuarios_SelectedIndexChanged);
            // 
            // bindingSourceRoles
            // 
            this.bindingSourceRoles.DataSource = typeof(beat_on_jeans_escritorio.Models.Roles);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(196)))), ((int)(((byte)(182)))));
            this.buttonEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonEliminar.FlatAppearance.BorderSize = 0;
            this.buttonEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminar.ForeColor = System.Drawing.Color.White;
            this.buttonEliminar.Location = new System.Drawing.Point(632, 271);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(107, 28);
            this.buttonEliminar.TabIndex = 3;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = false;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonNuevoUsuario
            // 
            this.buttonNuevoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(104)))), ((int)(((byte)(27)))));
            this.buttonNuevoUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonNuevoUsuario.FlatAppearance.BorderSize = 0;
            this.buttonNuevoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNuevoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNuevoUsuario.ForeColor = System.Drawing.Color.White;
            this.buttonNuevoUsuario.Location = new System.Drawing.Point(759, 29);
            this.buttonNuevoUsuario.Name = "buttonNuevoUsuario";
            this.buttonNuevoUsuario.Size = new System.Drawing.Size(167, 27);
            this.buttonNuevoUsuario.TabIndex = 4;
            this.buttonNuevoUsuario.Text = "Crear Usuario";
            this.buttonNuevoUsuario.UseVisualStyleBackColor = false;
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.AutoGenerateColumns = false;
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.rOLIDDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridViewUsuarios.DataSource = this.bindingSourceUsuarios;
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(11, 320);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(915, 286);
            this.dataGridViewUsuarios.TabIndex = 5;
            this.dataGridViewUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridViewUsuarios.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewUsuarios_CellFormatting);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // rOLIDDataGridViewTextBoxColumn
            // 
            this.rOLIDDataGridViewTextBoxColumn.DataPropertyName = "ROL_ID";
            this.rOLIDDataGridViewTextBoxColumn.HeaderText = "ROL_ID";
            this.rOLIDDataGridViewTextBoxColumn.Name = "rOLIDDataGridViewTextBoxColumn";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Correo";
            this.dataGridViewTextBoxColumn2.HeaderText = "Correo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Contrasena";
            this.dataGridViewTextBoxColumn3.HeaderText = "Contrasena";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // bindingSourceUsuarios
            // 
            this.bindingSourceUsuarios.DataSource = typeof(beat_on_jeans_escritorio.Models.Usuarios);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::beat_on_jeans_escritorio.Properties.Resources.RectangleNaranja;
            this.pictureBox4.Location = new System.Drawing.Point(759, 22);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(167, 42);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::beat_on_jeans_escritorio.Properties.Resources.RectangleAzul;
            this.pictureBox3.Location = new System.Drawing.Point(625, 264);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(121, 41);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::beat_on_jeans_escritorio.Properties.Resources.rectanguloNaranja;
            this.pictureBox1.Location = new System.Drawing.Point(2, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(932, 606);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::beat_on_jeans_escritorio.Properties.Resources.RectangleComboBox;
            this.pictureBox5.Location = new System.Drawing.Point(11, 269);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(195, 42);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            // 
            // comboBoxBuscarUsuario
            // 
            this.comboBoxBuscarUsuario.FormattingEnabled = true;
            this.comboBoxBuscarUsuario.Location = new System.Drawing.Point(169, 70);
            this.comboBoxBuscarUsuario.Name = "comboBoxBuscarUsuario";
            this.comboBoxBuscarUsuario.Size = new System.Drawing.Size(757, 21);
            this.comboBoxBuscarUsuario.TabIndex = 13;
            this.comboBoxBuscarUsuario.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::beat_on_jeans_escritorio.Properties.Resources.RectangleModificar;
            this.pictureBox2.Location = new System.Drawing.Point(759, 262);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(162, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // buttonModificar
            // 
            this.buttonModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(226)))));
            this.buttonModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonModificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(226)))));
            this.buttonModificar.FlatAppearance.BorderSize = 0;
            this.buttonModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModificar.Location = new System.Drawing.Point(759, 271);
            this.buttonModificar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(162, 27);
            this.buttonModificar.TabIndex = 2;
            this.buttonModificar.Text = "Modificar usuario";
            this.buttonModificar.UseVisualStyleBackColor = false;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Roles";
            // 
            // FormGestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 618);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxBuscarUsuario);
            this.Controls.Add(label1);
            this.Controls.Add(this.comboBoxRoles);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.buttonNuevoUsuario);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dataGridViewUsuarios);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormGestionUsuarios";
            this.Text = "FormGestionUsuarios";
            this.Load += new System.EventHandler(this.FormGestionUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBoxRoles;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonNuevoUsuario;
        private System.Windows.Forms.DataGridView dataGridViewUsuarios;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contrasenaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn correoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn musicosDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox comboBoxBuscarUsuario;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bindingSourceRoles;
        private System.Windows.Forms.BindingSource bindingSourceUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rOLIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}