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
            this.comboBoxSeleccionarUsuario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonCrearUsuario = new System.Windows.Forms.Button();
            this.buttonEditarUsuarios = new System.Windows.Forms.Button();
            this.buttonEliminarUsuarios = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSeleccionarUsuario
            // 
            this.comboBoxSeleccionarUsuario.FormattingEnabled = true;
            this.comboBoxSeleccionarUsuario.Items.AddRange(new object[] {
            "Superusuario",
            "Usuario de administación",
            "Usuario de mantenimiento de datos",
            "Local",
            "Músico"});
            this.comboBoxSeleccionarUsuario.Location = new System.Drawing.Point(175, 43);
            this.comboBoxSeleccionarUsuario.Name = "comboBoxSeleccionarUsuario";
            this.comboBoxSeleccionarUsuario.Size = new System.Drawing.Size(179, 21);
            this.comboBoxSeleccionarUsuario.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selecciona un usuario";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(60, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(679, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // buttonCrearUsuario
            // 
            this.buttonCrearUsuario.Location = new System.Drawing.Point(60, 274);
            this.buttonCrearUsuario.Name = "buttonCrearUsuario";
            this.buttonCrearUsuario.Size = new System.Drawing.Size(93, 39);
            this.buttonCrearUsuario.TabIndex = 3;
            this.buttonCrearUsuario.Text = "Crear";
            this.buttonCrearUsuario.UseVisualStyleBackColor = true;
            // 
            // buttonEditarUsuarios
            // 
            this.buttonEditarUsuarios.Location = new System.Drawing.Point(188, 274);
            this.buttonEditarUsuarios.Name = "buttonEditarUsuarios";
            this.buttonEditarUsuarios.Size = new System.Drawing.Size(93, 39);
            this.buttonEditarUsuarios.TabIndex = 4;
            this.buttonEditarUsuarios.Text = "Editar";
            this.buttonEditarUsuarios.UseVisualStyleBackColor = true;
            // 
            // buttonEliminarUsuarios
            // 
            this.buttonEliminarUsuarios.Location = new System.Drawing.Point(316, 274);
            this.buttonEliminarUsuarios.Name = "buttonEliminarUsuarios";
            this.buttonEliminarUsuarios.Size = new System.Drawing.Size(93, 39);
            this.buttonEliminarUsuarios.TabIndex = 5;
            this.buttonEliminarUsuarios.Text = "Eliminar";
            this.buttonEliminarUsuarios.UseVisualStyleBackColor = true;
            // 
            // FormGestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonEliminarUsuarios);
            this.Controls.Add(this.buttonEditarUsuarios);
            this.Controls.Add(this.buttonCrearUsuario);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSeleccionarUsuario);
            this.Name = "FormGestionUsuarios";
            this.Text = "FormGestionUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSeleccionarUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonCrearUsuario;
        private System.Windows.Forms.Button buttonEditarUsuarios;
        private System.Windows.Forms.Button buttonEliminarUsuarios;
    }
}