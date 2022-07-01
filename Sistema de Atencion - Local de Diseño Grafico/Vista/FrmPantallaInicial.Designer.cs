
namespace Vista
{
    partial class FrmPantallaInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPantallaInicial));
            this.btnImportarDesdeArchivos = new System.Windows.Forms.Button();
            this.btnImportarDesdeBBDD = new System.Windows.Forms.Button();
            this.lblBienevido = new System.Windows.Forms.Label();
            this.lblNombreEmpresa = new System.Windows.Forms.Label();
            this.lblImportar = new System.Windows.Forms.Label();
            this.pBoxLogoEmpresa = new System.Windows.Forms.PictureBox();
            this.btnSalirApp = new System.Windows.Forms.Button();
            this.pBarDescargaDatos = new System.Windows.Forms.ProgressBar();
            this.tmrEvaluarDescarga = new System.Windows.Forms.Timer(this.components);
            this.lblLecturaDeDatos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogoEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportarDesdeArchivos
            // 
            this.btnImportarDesdeArchivos.BackColor = System.Drawing.Color.Transparent;
            this.btnImportarDesdeArchivos.BackgroundImage = global::Vista.Properties.Resources.Boton14;
            this.btnImportarDesdeArchivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImportarDesdeArchivos.FlatAppearance.BorderSize = 0;
            this.btnImportarDesdeArchivos.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnImportarDesdeArchivos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SpringGreen;
            this.btnImportarDesdeArchivos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SpringGreen;
            this.btnImportarDesdeArchivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportarDesdeArchivos.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnImportarDesdeArchivos.Location = new System.Drawing.Point(10, 248);
            this.btnImportarDesdeArchivos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImportarDesdeArchivos.Name = "btnImportarDesdeArchivos";
            this.btnImportarDesdeArchivos.Size = new System.Drawing.Size(213, 80);
            this.btnImportarDesdeArchivos.TabIndex = 0;
            this.btnImportarDesdeArchivos.Text = "Importar desde Archivos";
            this.btnImportarDesdeArchivos.UseVisualStyleBackColor = false;
            this.btnImportarDesdeArchivos.Click += new System.EventHandler(this.btnImportarDesdeArchivos_Click);
            // 
            // btnImportarDesdeBBDD
            // 
            this.btnImportarDesdeBBDD.BackColor = System.Drawing.Color.Transparent;
            this.btnImportarDesdeBBDD.BackgroundImage = global::Vista.Properties.Resources.Boton14;
            this.btnImportarDesdeBBDD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImportarDesdeBBDD.FlatAppearance.BorderSize = 0;
            this.btnImportarDesdeBBDD.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnImportarDesdeBBDD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SpringGreen;
            this.btnImportarDesdeBBDD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SpringGreen;
            this.btnImportarDesdeBBDD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportarDesdeBBDD.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnImportarDesdeBBDD.Location = new System.Drawing.Point(703, 248);
            this.btnImportarDesdeBBDD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImportarDesdeBBDD.Name = "btnImportarDesdeBBDD";
            this.btnImportarDesdeBBDD.Size = new System.Drawing.Size(213, 80);
            this.btnImportarDesdeBBDD.TabIndex = 1;
            this.btnImportarDesdeBBDD.Text = "Importar desde Base de Datos";
            this.btnImportarDesdeBBDD.UseVisualStyleBackColor = false;
            this.btnImportarDesdeBBDD.Click += new System.EventHandler(this.btnImportarDesdeBBDD_Click);
            // 
            // lblBienevido
            // 
            this.lblBienevido.AutoSize = true;
            this.lblBienevido.BackColor = System.Drawing.Color.Transparent;
            this.lblBienevido.Font = new System.Drawing.Font("Arial", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblBienevido.Location = new System.Drawing.Point(344, 18);
            this.lblBienevido.Name = "lblBienevido";
            this.lblBienevido.Size = new System.Drawing.Size(213, 36);
            this.lblBienevido.TabIndex = 3;
            this.lblBienevido.Text = "BIENVENIDO";
            // 
            // lblNombreEmpresa
            // 
            this.lblNombreEmpresa.AutoSize = true;
            this.lblNombreEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreEmpresa.Font = new System.Drawing.Font("Forte", 74F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombreEmpresa.ForeColor = System.Drawing.Color.Navy;
            this.lblNombreEmpresa.Location = new System.Drawing.Point(242, 72);
            this.lblNombreEmpresa.Name = "lblNombreEmpresa";
            this.lblNombreEmpresa.Size = new System.Drawing.Size(403, 108);
            this.lblNombreEmpresa.TabIndex = 4;
            this.lblNombreEmpresa.Text = "E-Grafiq";
            // 
            // lblImportar
            // 
            this.lblImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImportar.AutoSize = true;
            this.lblImportar.BackColor = System.Drawing.Color.Transparent;
            this.lblImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblImportar.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblImportar.Location = new System.Drawing.Point(53, 198);
            this.lblImportar.Name = "lblImportar";
            this.lblImportar.Size = new System.Drawing.Size(804, 32);
            this.lblImportar.TabIndex = 5;
            this.lblImportar.Text = "Seleccione una opcion para importar  los datos al sistema...";
            // 
            // pBoxLogoEmpresa
            // 
            this.pBoxLogoEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.pBoxLogoEmpresa.BackgroundImage = global::Vista.Properties.Resources.FondoApp3;
            this.pBoxLogoEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBoxLogoEmpresa.Location = new System.Drawing.Point(10, 59);
            this.pBoxLogoEmpresa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBoxLogoEmpresa.Name = "pBoxLogoEmpresa";
            this.pBoxLogoEmpresa.Size = new System.Drawing.Size(225, 137);
            this.pBoxLogoEmpresa.TabIndex = 6;
            this.pBoxLogoEmpresa.TabStop = false;
            // 
            // btnSalirApp
            // 
            this.btnSalirApp.BackColor = System.Drawing.Color.Transparent;
            this.btnSalirApp.BackgroundImage = global::Vista.Properties.Resources.Boton9;
            this.btnSalirApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalirApp.FlatAppearance.BorderSize = 0;
            this.btnSalirApp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnSalirApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnSalirApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalirApp.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSalirApp.Location = new System.Drawing.Point(10, 7);
            this.btnSalirApp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalirApp.Name = "btnSalirApp";
            this.btnSalirApp.Size = new System.Drawing.Size(146, 46);
            this.btnSalirApp.TabIndex = 7;
            this.btnSalirApp.Text = "Salir";
            this.btnSalirApp.UseVisualStyleBackColor = false;
            this.btnSalirApp.Click += new System.EventHandler(this.btnSalirApp_Click);
            // 
            // pBarDescargaDatos
            // 
            this.pBarDescargaDatos.Location = new System.Drawing.Point(312, 272);
            this.pBarDescargaDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBarDescargaDatos.MarqueeAnimationSpeed = 1;
            this.pBarDescargaDatos.Name = "pBarDescargaDatos";
            this.pBarDescargaDatos.Size = new System.Drawing.Size(317, 13);
            this.pBarDescargaDatos.Step = 1;
            this.pBarDescargaDatos.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBarDescargaDatos.TabIndex = 8;
            this.pBarDescargaDatos.Visible = false;
            // 
            // lblLecturaDeDatos
            // 
            this.lblLecturaDeDatos.BackColor = System.Drawing.Color.White;
            this.lblLecturaDeDatos.Location = new System.Drawing.Point(312, 302);
            this.lblLecturaDeDatos.Name = "lblLecturaDeDatos";
            this.lblLecturaDeDatos.Size = new System.Drawing.Size(317, 15);
            this.lblLecturaDeDatos.TabIndex = 9;
            this.lblLecturaDeDatos.Visible = false;
            // 
            // FrmPantallaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vista.Properties.Resources.FondoApp;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(926, 338);
            this.ControlBox = false;
            this.Controls.Add(this.lblLecturaDeDatos);
            this.Controls.Add(this.pBarDescargaDatos);
            this.Controls.Add(this.btnSalirApp);
            this.Controls.Add(this.pBoxLogoEmpresa);
            this.Controls.Add(this.lblImportar);
            this.Controls.Add(this.lblNombreEmpresa);
            this.Controls.Add(this.lblBienevido);
            this.Controls.Add(this.btnImportarDesdeBBDD);
            this.Controls.Add(this.btnImportarDesdeArchivos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPantallaInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenido";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPantallaInicial_FormClosing);
            this.Load += new System.EventHandler(this.FrmPantallaInicial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogoEmpresa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportarDesdeArchivos;
        private System.Windows.Forms.Button btnImportarDesdeBBDD;
        private System.Windows.Forms.Label lblBienevido;
        private System.Windows.Forms.Label lblNombreEmpresa;
        private System.Windows.Forms.Label lblImportar;
        private System.Windows.Forms.PictureBox pBoxLogoEmpresa;
        private System.Windows.Forms.Button btnSalirApp;
        private System.Windows.Forms.ProgressBar pBarDescargaDatos;
        private System.Windows.Forms.Timer tmrEvaluarDescarga;
        private System.Windows.Forms.Label lblLecturaDeDatos;
    }
}