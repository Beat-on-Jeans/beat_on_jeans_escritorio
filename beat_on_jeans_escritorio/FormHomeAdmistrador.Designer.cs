namespace beat_on_jeans_escritorio
{
    partial class FormHomeAdmistrador
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewLocales = new System.Windows.Forms.DataGridView();
            this.dataGridViewMusicos = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo_Postal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelLocales = new System.Windows.Forms.Label();
            this.labelMusicos = new System.Windows.Forms.Label();
            this.dataGridViewEventosProgramados = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Musico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorreoLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValoracionMedia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceActuaciones = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceLocales = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceMusicos = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMusicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventosProgramados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceActuaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceLocales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMusicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Figtree Medium", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 325);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Actuaciones";
            // 
            // dataGridViewLocales
            // 
            this.dataGridViewLocales.AllowUserToAddRows = false;
            this.dataGridViewLocales.AllowUserToDeleteRows = false;
            this.dataGridViewLocales.AllowUserToOrderColumns = true;
            this.dataGridViewLocales.AllowUserToResizeColumns = false;
            this.dataGridViewLocales.AllowUserToResizeRows = false;
            this.dataGridViewLocales.AutoGenerateColumns = false;
            this.dataGridViewLocales.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(226)))));
            this.dataGridViewLocales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewLocales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(104)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(104)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLocales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLocales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLocales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreLocal,
            this.CorreoLocal,
            this.ValoracionMedia,
            this.Ubicacion});
            this.dataGridViewLocales.DataSource = this.bindingSourceLocales;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLocales.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLocales.EnableHeadersVisualStyles = false;
            this.dataGridViewLocales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(226)))));
            this.dataGridViewLocales.Location = new System.Drawing.Point(496, 80);
            this.dataGridViewLocales.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewLocales.MultiSelect = false;
            this.dataGridViewLocales.Name = "dataGridViewLocales";
            this.dataGridViewLocales.ReadOnly = true;
            this.dataGridViewLocales.RowHeadersVisible = false;
            this.dataGridViewLocales.RowHeadersWidth = 25;
            this.dataGridViewLocales.RowTemplate.Height = 24;
            this.dataGridViewLocales.Size = new System.Drawing.Size(416, 225);
            this.dataGridViewLocales.TabIndex = 15;
            // 
            // dataGridViewMusicos
            // 
            this.dataGridViewMusicos.AllowUserToAddRows = false;
            this.dataGridViewMusicos.AllowUserToDeleteRows = false;
            this.dataGridViewMusicos.AllowUserToOrderColumns = true;
            this.dataGridViewMusicos.AllowUserToResizeColumns = false;
            this.dataGridViewMusicos.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(226)))));
            this.dataGridViewMusicos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewMusicos.AutoGenerateColumns = false;
            this.dataGridViewMusicos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(226)))));
            this.dataGridViewMusicos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewMusicos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(104)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Poppins", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(104)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMusicos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewMusicos.ColumnHeadersHeight = 40;
            this.dataGridViewMusicos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Correo,
            this.Codigo_Postal});
            this.dataGridViewMusicos.DataSource = this.bindingSourceMusicos;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMusicos.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewMusicos.EnableHeadersVisualStyles = false;
            this.dataGridViewMusicos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(226)))));
            this.dataGridViewMusicos.Location = new System.Drawing.Point(30, 80);
            this.dataGridViewMusicos.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewMusicos.MultiSelect = false;
            this.dataGridViewMusicos.Name = "dataGridViewMusicos";
            this.dataGridViewMusicos.ReadOnly = true;
            this.dataGridViewMusicos.RowHeadersVisible = false;
            this.dataGridViewMusicos.RowHeadersWidth = 25;
            this.dataGridViewMusicos.RowTemplate.Height = 24;
            this.dataGridViewMusicos.Size = new System.Drawing.Size(416, 225);
            this.dataGridViewMusicos.TabIndex = 14;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.FillWeight = 150F;
            this.Nombre.HeaderText = "Nombre del Músico";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Correo
            // 
            this.Correo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Correo.FillWeight = 150F;
            this.Correo.HeaderText = "Correo del músico";
            this.Correo.Name = "Correo";
            this.Correo.ReadOnly = true;
            // 
            // Codigo_Postal
            // 
            this.Codigo_Postal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Codigo_Postal.FillWeight = 150F;
            this.Codigo_Postal.HeaderText = "Codigo Postal";
            this.Codigo_Postal.Name = "Codigo_Postal";
            this.Codigo_Postal.ReadOnly = true;
            // 
            // labelLocales
            // 
            this.labelLocales.AutoSize = true;
            this.labelLocales.Font = new System.Drawing.Font("Figtree Medium", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocales.Location = new System.Drawing.Point(489, 27);
            this.labelLocales.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLocales.Name = "labelLocales";
            this.labelLocales.Size = new System.Drawing.Size(127, 38);
            this.labelLocales.TabIndex = 13;
            this.labelLocales.Text = "Locales";
            // 
            // labelMusicos
            // 
            this.labelMusicos.AutoSize = true;
            this.labelMusicos.Font = new System.Drawing.Font("Figtree Medium", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMusicos.Location = new System.Drawing.Point(23, 27);
            this.labelMusicos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMusicos.Name = "labelMusicos";
            this.labelMusicos.Size = new System.Drawing.Size(136, 38);
            this.labelMusicos.TabIndex = 12;
            this.labelMusicos.Text = "Musicos";
            // 
            // dataGridViewEventosProgramados
            // 
            this.dataGridViewEventosProgramados.AllowUserToAddRows = false;
            this.dataGridViewEventosProgramados.AllowUserToDeleteRows = false;
            this.dataGridViewEventosProgramados.AllowUserToOrderColumns = true;
            this.dataGridViewEventosProgramados.AllowUserToResizeColumns = false;
            this.dataGridViewEventosProgramados.AllowUserToResizeRows = false;
            this.dataGridViewEventosProgramados.AutoGenerateColumns = false;
            this.dataGridViewEventosProgramados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(226)))));
            this.dataGridViewEventosProgramados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewEventosProgramados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(104)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Poppins", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(104)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEventosProgramados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewEventosProgramados.ColumnHeadersHeight = 40;
            this.dataGridViewEventosProgramados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Local,
            this.Musico});
            this.dataGridViewEventosProgramados.DataSource = this.bindingSourceActuaciones;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEventosProgramados.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewEventosProgramados.EnableHeadersVisualStyles = false;
            this.dataGridViewEventosProgramados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(226)))));
            this.dataGridViewEventosProgramados.Location = new System.Drawing.Point(30, 376);
            this.dataGridViewEventosProgramados.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewEventosProgramados.MultiSelect = false;
            this.dataGridViewEventosProgramados.Name = "dataGridViewEventosProgramados";
            this.dataGridViewEventosProgramados.ReadOnly = true;
            this.dataGridViewEventosProgramados.RowHeadersVisible = false;
            this.dataGridViewEventosProgramados.RowHeadersWidth = 25;
            this.dataGridViewEventosProgramados.RowTemplate.Height = 24;
            this.dataGridViewEventosProgramados.Size = new System.Drawing.Size(882, 201);
            this.dataGridViewEventosProgramados.TabIndex = 16;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fecha.FillWeight = 150F;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Local
            // 
            this.Local.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Local.FillWeight = 150F;
            this.Local.HeaderText = "Local";
            this.Local.Name = "Local";
            this.Local.ReadOnly = true;
            // 
            // Musico
            // 
            this.Musico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Musico.FillWeight = 150F;
            this.Musico.HeaderText = "Musico";
            this.Musico.Name = "Musico";
            this.Musico.ReadOnly = true;
            // 
            // NombreLocal
            // 
            this.NombreLocal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombreLocal.FillWeight = 150F;
            this.NombreLocal.HeaderText = "Nombre del local";
            this.NombreLocal.Name = "NombreLocal";
            this.NombreLocal.ReadOnly = true;
            // 
            // CorreoLocal
            // 
            this.CorreoLocal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CorreoLocal.FillWeight = 150F;
            this.CorreoLocal.HeaderText = "Correo del local";
            this.CorreoLocal.Name = "CorreoLocal";
            this.CorreoLocal.ReadOnly = true;
            // 
            // ValoracionMedia
            // 
            this.ValoracionMedia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValoracionMedia.FillWeight = 150F;
            this.ValoracionMedia.HeaderText = "Valoración media";
            this.ValoracionMedia.Name = "ValoracionMedia";
            this.ValoracionMedia.ReadOnly = true;
            // 
            // Ubicacion
            // 
            this.Ubicacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ubicacion.FillWeight = 150F;
            this.Ubicacion.HeaderText = "Ubicación";
            this.Ubicacion.Name = "Ubicacion";
            this.Ubicacion.ReadOnly = true;
            // 
            // bindingSourceActuaciones
            // 
            this.bindingSourceActuaciones.DataSource = typeof(beat_on_jeans_escritorio.Models.ActuacionesHomeOrm);
            // 
            // bindingSourceLocales
            // 
            this.bindingSourceLocales.DataSource = typeof(beat_on_jeans_escritorio.Models.UsuariosCSharpOrm);
            // 
            // bindingSourceMusicos
            // 
            this.bindingSourceMusicos.DataSource = typeof(beat_on_jeans_escritorio.Models.UsuariosCSharpOrm);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::beat_on_jeans_escritorio.Properties.Resources.rectanguloNaranja;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(911, 594);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // FormHomeAdmistrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 618);
            this.Controls.Add(this.dataGridViewEventosProgramados);
            this.Controls.Add(this.dataGridViewLocales);
            this.Controls.Add(this.dataGridViewMusicos);
            this.Controls.Add(this.labelLocales);
            this.Controls.Add(this.labelMusicos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormHomeAdmistrador";
            this.Text = "FormHomeAdmistrador";
            this.Load += new System.EventHandler(this.FormHomeAdmistrador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMusicos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventosProgramados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceActuaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceLocales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMusicos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewLocales;
        private System.Windows.Forms.DataGridView dataGridViewMusicos;
        private System.Windows.Forms.Label labelLocales;
        private System.Windows.Forms.Label labelMusicos;
        private System.Windows.Forms.BindingSource bindingSourceActuaciones;
        private System.Windows.Forms.DataGridView dataGridViewEventosProgramados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Local;
        private System.Windows.Forms.DataGridViewTextBoxColumn Musico;
        private System.Windows.Forms.BindingSource bindingSourceLocales;
        private System.Windows.Forms.BindingSource bindingSourceMusicos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_Postal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorreoLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValoracionMedia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubicacion;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}