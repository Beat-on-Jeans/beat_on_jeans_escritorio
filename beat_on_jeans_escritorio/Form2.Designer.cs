namespace beat_on_jeans_escritorio
{
    partial class Form2
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
            this.buttonGestionSoporte = new System.Windows.Forms.Button();
            this.buttonGestionUsuarios = new System.Windows.Forms.Button();
            this.buttonGestionMusicos = new System.Windows.Forms.Button();
            this.buttonGestionLocales = new System.Windows.Forms.Button();
            this.buttonGestionDatosSistema = new System.Windows.Forms.Button();
            this.buttonMapas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGestionSoporte
            // 
            this.buttonGestionSoporte.Location = new System.Drawing.Point(27, 29);
            this.buttonGestionSoporte.Name = "buttonGestionSoporte";
            this.buttonGestionSoporte.Size = new System.Drawing.Size(109, 45);
            this.buttonGestionSoporte.TabIndex = 0;
            this.buttonGestionSoporte.Text = "Gestión Soporte";
            this.buttonGestionSoporte.UseVisualStyleBackColor = true;
            // 
            // buttonGestionUsuarios
            // 
            this.buttonGestionUsuarios.Location = new System.Drawing.Point(186, 29);
            this.buttonGestionUsuarios.Name = "buttonGestionUsuarios";
            this.buttonGestionUsuarios.Size = new System.Drawing.Size(109, 45);
            this.buttonGestionUsuarios.TabIndex = 1;
            this.buttonGestionUsuarios.Text = "Gestión Usuarios";
            this.buttonGestionUsuarios.UseVisualStyleBackColor = true;
            // 
            // buttonGestionMusicos
            // 
            this.buttonGestionMusicos.Location = new System.Drawing.Point(348, 31);
            this.buttonGestionMusicos.Name = "buttonGestionMusicos";
            this.buttonGestionMusicos.Size = new System.Drawing.Size(109, 43);
            this.buttonGestionMusicos.TabIndex = 2;
            this.buttonGestionMusicos.Text = "Gestión Músicos";
            this.buttonGestionMusicos.UseVisualStyleBackColor = true;
            // 
            // buttonGestionLocales
            // 
            this.buttonGestionLocales.Location = new System.Drawing.Point(505, 31);
            this.buttonGestionLocales.Name = "buttonGestionLocales";
            this.buttonGestionLocales.Size = new System.Drawing.Size(109, 43);
            this.buttonGestionLocales.TabIndex = 3;
            this.buttonGestionLocales.Text = "Gestión Locales";
            this.buttonGestionLocales.UseVisualStyleBackColor = true;
            // 
            // buttonGestionDatosSistema
            // 
            this.buttonGestionDatosSistema.Location = new System.Drawing.Point(654, 31);
            this.buttonGestionDatosSistema.Name = "buttonGestionDatosSistema";
            this.buttonGestionDatosSistema.Size = new System.Drawing.Size(109, 43);
            this.buttonGestionDatosSistema.TabIndex = 4;
            this.buttonGestionDatosSistema.Text = "Gestión Datos del Sistema";
            this.buttonGestionDatosSistema.UseVisualStyleBackColor = true;
            // 
            // buttonMapas
            // 
            this.buttonMapas.Location = new System.Drawing.Point(348, 137);
            this.buttonMapas.Name = "buttonMapas";
            this.buttonMapas.Size = new System.Drawing.Size(109, 43);
            this.buttonMapas.TabIndex = 5;
            this.buttonMapas.Text = "Mapas";
            this.buttonMapas.UseVisualStyleBackColor = true;
            this.buttonMapas.Click += new System.EventHandler(this.buttonMapas_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonMapas);
            this.Controls.Add(this.buttonGestionDatosSistema);
            this.Controls.Add(this.buttonGestionLocales);
            this.Controls.Add(this.buttonGestionMusicos);
            this.Controls.Add(this.buttonGestionUsuarios);
            this.Controls.Add(this.buttonGestionSoporte);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGestionSoporte;
        private System.Windows.Forms.Button buttonGestionUsuarios;
        private System.Windows.Forms.Button buttonGestionMusicos;
        private System.Windows.Forms.Button buttonGestionLocales;
        private System.Windows.Forms.Button buttonGestionDatosSistema;
        private System.Windows.Forms.Button buttonMapas;
    }
}