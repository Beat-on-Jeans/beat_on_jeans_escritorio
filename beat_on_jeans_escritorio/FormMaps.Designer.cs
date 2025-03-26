namespace beat_on_jeans_escritorio
{
    partial class FormMaps
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
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCalles = new System.Windows.Forms.ComboBox();
            this.bindingSourceUbicaciones = new System.Windows.Forms.BindingSource(this.components);
            this.labelNombreLocal = new System.Windows.Forms.Label();
            this.labelLocal = new System.Windows.Forms.Label();
            this.labelValoracionMedia = new System.Windows.Forms.Label();
            this.labelValoracion = new System.Windows.Forms.Label();
            this.labelUbicacionLocal = new System.Windows.Forms.Label();
            this.labelUbicacion = new System.Windows.Forms.Label();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUbicaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(12, 12);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(537, 594);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 12.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(569, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selecciona una calle";
            // 
            // comboBoxCalles
            // 
            this.comboBoxCalles.AllowDrop = true;
            this.comboBoxCalles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(226)))));
            this.comboBoxCalles.DataSource = this.bindingSourceUbicaciones;
            this.comboBoxCalles.DisplayMember = "Ubicacion";
            this.comboBoxCalles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCalles.Font = new System.Drawing.Font("Figtree Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCalles.FormattingEnabled = true;
            this.comboBoxCalles.Location = new System.Drawing.Point(583, 48);
            this.comboBoxCalles.Name = "comboBoxCalles";
            this.comboBoxCalles.Size = new System.Drawing.Size(258, 28);
            this.comboBoxCalles.TabIndex = 2;
            this.comboBoxCalles.ValueMember = "ID";
            // 
            // bindingSourceUbicaciones
            // 
            this.bindingSourceUbicaciones.DataSource = typeof(beat_on_jeans_escritorio.Models.Locales);
            // 
            // labelNombreLocal
            // 
            this.labelNombreLocal.AutoSize = true;
            this.labelNombreLocal.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreLocal.Location = new System.Drawing.Point(569, 180);
            this.labelNombreLocal.Name = "labelNombreLocal";
            this.labelNombreLocal.Size = new System.Drawing.Size(131, 28);
            this.labelNombreLocal.TabIndex = 3;
            this.labelNombreLocal.Text = "Nombre local";
            // 
            // labelLocal
            // 
            this.labelLocal.AutoSize = true;
            this.labelLocal.Font = new System.Drawing.Font("Figtree Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocal.Location = new System.Drawing.Point(570, 208);
            this.labelLocal.Name = "labelLocal";
            this.labelLocal.Size = new System.Drawing.Size(52, 20);
            this.labelLocal.TabIndex = 4;
            this.labelLocal.Text = "label3";
            // 
            // labelValoracionMedia
            // 
            this.labelValoracionMedia.AutoSize = true;
            this.labelValoracionMedia.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValoracionMedia.Location = new System.Drawing.Point(569, 250);
            this.labelValoracionMedia.Name = "labelValoracionMedia";
            this.labelValoracionMedia.Size = new System.Drawing.Size(171, 28);
            this.labelValoracionMedia.TabIndex = 5;
            this.labelValoracionMedia.Text = "Valoración media";
            // 
            // labelValoracion
            // 
            this.labelValoracion.AutoSize = true;
            this.labelValoracion.Font = new System.Drawing.Font("Figtree Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValoracion.Location = new System.Drawing.Point(570, 278);
            this.labelValoracion.Name = "labelValoracion";
            this.labelValoracion.Size = new System.Drawing.Size(53, 20);
            this.labelValoracion.TabIndex = 6;
            this.labelValoracion.Text = "label4";
            // 
            // labelUbicacionLocal
            // 
            this.labelUbicacionLocal.AutoSize = true;
            this.labelUbicacionLocal.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUbicacionLocal.Location = new System.Drawing.Point(569, 323);
            this.labelUbicacionLocal.Name = "labelUbicacionLocal";
            this.labelUbicacionLocal.Size = new System.Drawing.Size(151, 28);
            this.labelUbicacionLocal.TabIndex = 7;
            this.labelUbicacionLocal.Text = "Ubicación local";
            // 
            // labelUbicacion
            // 
            this.labelUbicacion.AutoSize = true;
            this.labelUbicacion.Font = new System.Drawing.Font("Figtree Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUbicacion.Location = new System.Drawing.Point(570, 351);
            this.labelUbicacion.Name = "labelUbicacion";
            this.labelUbicacion.Size = new System.Drawing.Size(52, 20);
            this.labelUbicacion.TabIndex = 8;
            this.labelUbicacion.Text = "label5";
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(104)))), ((int)(((byte)(27)))));
            this.buttonAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(104)))), ((int)(((byte)(27)))));
            this.buttonAceptar.FlatAppearance.BorderSize = 0;
            this.buttonAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAceptar.Font = new System.Drawing.Font("Figtree Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAceptar.ForeColor = System.Drawing.Color.White;
            this.buttonAceptar.Location = new System.Drawing.Point(583, 102);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(124, 37);
            this.buttonAceptar.TabIndex = 9;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = false;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::beat_on_jeans_escritorio.Properties.Resources.RectangleComboBox;
            this.pictureBox1.Location = new System.Drawing.Point(576, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::beat_on_jeans_escritorio.Properties.Resources.RectangleNaranja;
            this.pictureBox2.Location = new System.Drawing.Point(575, 99);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(140, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // FormMaps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 618);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.labelUbicacion);
            this.Controls.Add(this.labelUbicacionLocal);
            this.Controls.Add(this.labelValoracion);
            this.Controls.Add(this.labelValoracionMedia);
            this.Controls.Add(this.labelLocal);
            this.Controls.Add(this.labelNombreLocal);
            this.Controls.Add(this.comboBoxCalles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gMapControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "FormMaps";
            this.Text = "FormMaps";
            this.Load += new System.EventHandler(this.FormMaps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUbicaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCalles;
        private System.Windows.Forms.Label labelNombreLocal;
        private System.Windows.Forms.Label labelLocal;
        private System.Windows.Forms.Label labelValoracionMedia;
        private System.Windows.Forms.Label labelValoracion;
        private System.Windows.Forms.Label labelUbicacionLocal;
        private System.Windows.Forms.Label labelUbicacion;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.BindingSource bindingSourceUbicaciones;
    }
}