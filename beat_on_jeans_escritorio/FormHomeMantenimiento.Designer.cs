namespace beat_on_jeans_escritorio
{
    partial class FormHomeMantenimiento
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
            this.dataGridViewLocales = new System.Windows.Forms.DataGridView();
            this.NombreLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorreoLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValoracionTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewMusicos = new System.Windows.Forms.DataGridView();
            this.labelLocales = new System.Windows.Forms.Label();
            this.labelMusicos = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NombreMusico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorreoMusico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoPostal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceMusicos = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMusicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMusicos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLocales
            // 
            this.dataGridViewLocales.AllowUserToAddRows = false;
            this.dataGridViewLocales.AllowUserToDeleteRows = false;
            this.dataGridViewLocales.AllowUserToOrderColumns = true;
            this.dataGridViewLocales.AllowUserToResizeColumns = false;
            this.dataGridViewLocales.AllowUserToResizeRows = false;
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
            this.ValoracionTotal,
            this.Ubicacion});
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
            this.dataGridViewLocales.Location = new System.Drawing.Point(496, 186);
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
            // ValoracionTotal
            // 
            this.ValoracionTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValoracionTotal.FillWeight = 150F;
            this.ValoracionTotal.HeaderText = "Valoración media";
            this.ValoracionTotal.Name = "ValoracionTotal";
            this.ValoracionTotal.ReadOnly = true;
            // 
            // Ubicacion
            // 
            this.Ubicacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ubicacion.FillWeight = 150F;
            this.Ubicacion.HeaderText = "Ubicación";
            this.Ubicacion.Name = "Ubicacion";
            this.Ubicacion.ReadOnly = true;
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
            this.NombreMusico,
            this.CorreoMusico,
            this.CodigoPostal});
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
            this.dataGridViewMusicos.Location = new System.Drawing.Point(30, 186);
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
            // labelLocales
            // 
            this.labelLocales.AutoSize = true;
            this.labelLocales.Font = new System.Drawing.Font("Figtree Medium", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocales.Location = new System.Drawing.Point(489, 133);
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
            this.labelMusicos.Location = new System.Drawing.Point(23, 133);
            this.labelMusicos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMusicos.Name = "labelMusicos";
            this.labelMusicos.Size = new System.Drawing.Size(136, 38);
            this.labelMusicos.TabIndex = 12;
            this.labelMusicos.Text = "Musicos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::beat_on_jeans_escritorio.Properties.Resources.rectanguloNaranja;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(911, 594);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // NombreMusico
            // 
            this.NombreMusico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombreMusico.FillWeight = 150F;
            this.NombreMusico.HeaderText = "Nombre del Músico";
            this.NombreMusico.Name = "NombreMusico";
            this.NombreMusico.ReadOnly = true;
            // 
            // CorreoMusico
            // 
            this.CorreoMusico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CorreoMusico.FillWeight = 150F;
            this.CorreoMusico.HeaderText = "Correo del músico";
            this.CorreoMusico.Name = "CorreoMusico";
            this.CorreoMusico.ReadOnly = true;
            // 
            // CodigoPostal
            // 
            this.CodigoPostal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CodigoPostal.FillWeight = 150F;
            this.CodigoPostal.HeaderText = "Ubicacion";
            this.CodigoPostal.Name = "CodigoPostal";
            this.CodigoPostal.ReadOnly = true;
            // 
            // bindingSourceMusicos
            // 
            this.bindingSourceMusicos.DataSource = typeof(beat_on_jeans_escritorio.Models.UsuariosCSharpOrm);
            // 
            // FormHomeMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 618);
            this.Controls.Add(this.dataGridViewLocales);
            this.Controls.Add(this.dataGridViewMusicos);
            this.Controls.Add(this.labelLocales);
            this.Controls.Add(this.labelMusicos);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormHomeMantenimiento";
            this.Text = "FormHomeMantenimiento";
            this.Load += new System.EventHandler(this.FormHomeMantenimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMusicos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMusicos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLocales;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorreoLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValoracionTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubicacion;
        private System.Windows.Forms.DataGridView dataGridViewMusicos;
        private System.Windows.Forms.Label labelLocales;
        private System.Windows.Forms.Label labelMusicos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreMusico;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorreoMusico;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoPostal;
        private System.Windows.Forms.BindingSource bindingSourceMusicos;
    }
}