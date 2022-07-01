
namespace Vista
{
    partial class FrmUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuario));
            this.btnAtenderClienteTemporal = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnAtenderClienteAsociado = new System.Windows.Forms.Button();
            this.btnCambiarPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAtenderClienteTemporal
            // 
            this.btnAtenderClienteTemporal.BackColor = System.Drawing.Color.Transparent;
            this.btnAtenderClienteTemporal.BackgroundImage = global::Vista.Properties.Resources.Boton14;
            this.btnAtenderClienteTemporal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAtenderClienteTemporal.FlatAppearance.BorderSize = 0;
            this.btnAtenderClienteTemporal.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAtenderClienteTemporal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAtenderClienteTemporal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAtenderClienteTemporal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtenderClienteTemporal.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAtenderClienteTemporal.Location = new System.Drawing.Point(12, 12);
            this.btnAtenderClienteTemporal.Name = "btnAtenderClienteTemporal";
            this.btnAtenderClienteTemporal.Size = new System.Drawing.Size(201, 80);
            this.btnAtenderClienteTemporal.TabIndex = 0;
            this.btnAtenderClienteTemporal.Text = "Atender Cliente Eventual";
            this.btnAtenderClienteTemporal.UseVisualStyleBackColor = false;
            this.btnAtenderClienteTemporal.Click += new System.EventHandler(this.btnAtenderClienteTemporal_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSesion.BackgroundImage = global::Vista.Properties.Resources.Boton9;
            this.btnCerrarSesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrarSesion.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCerrarSesion.Location = new System.Drawing.Point(276, 111);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(201, 80);
            this.btnCerrarSesion.TabIndex = 3;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAtenderClienteAsociado
            // 
            this.btnAtenderClienteAsociado.BackColor = System.Drawing.Color.Transparent;
            this.btnAtenderClienteAsociado.BackgroundImage = global::Vista.Properties.Resources.Boton14;
            this.btnAtenderClienteAsociado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAtenderClienteAsociado.FlatAppearance.BorderSize = 0;
            this.btnAtenderClienteAsociado.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAtenderClienteAsociado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAtenderClienteAsociado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAtenderClienteAsociado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtenderClienteAsociado.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAtenderClienteAsociado.Location = new System.Drawing.Point(276, 12);
            this.btnAtenderClienteAsociado.Name = "btnAtenderClienteAsociado";
            this.btnAtenderClienteAsociado.Size = new System.Drawing.Size(201, 80);
            this.btnAtenderClienteAsociado.TabIndex = 1;
            this.btnAtenderClienteAsociado.Text = "Atender Cliente Asociado";
            this.btnAtenderClienteAsociado.UseVisualStyleBackColor = false;
            this.btnAtenderClienteAsociado.Click += new System.EventHandler(this.btnAtenderClienteAsociado_Click);
            // 
            // btnCambiarPassword
            // 
            this.btnCambiarPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnCambiarPassword.BackgroundImage = global::Vista.Properties.Resources.Boton14;
            this.btnCambiarPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCambiarPassword.FlatAppearance.BorderSize = 0;
            this.btnCambiarPassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCambiarPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCambiarPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarPassword.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCambiarPassword.Location = new System.Drawing.Point(12, 111);
            this.btnCambiarPassword.Name = "btnCambiarPassword";
            this.btnCambiarPassword.Size = new System.Drawing.Size(201, 80);
            this.btnCambiarPassword.TabIndex = 2;
            this.btnCambiarPassword.Text = "Cambiar Contraseña";
            this.btnCambiarPassword.UseVisualStyleBackColor = false;
            this.btnCambiarPassword.Click += new System.EventHandler(this.btnCambiarPassword_Click);
            // 
            // FrmUsuario
            // 
            this.AcceptButton = this.btnAtenderClienteAsociado;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vista.Properties.Resources.FondoApp;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCerrarSesion;
            this.ClientSize = new System.Drawing.Size(500, 203);
            this.Controls.Add(this.btnCambiarPassword);
            this.Controls.Add(this.btnAtenderClienteTemporal);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnAtenderClienteAsociado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUsuario_FormClosing);
            this.Load += new System.EventHandler(this.FrmUsuario_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAtenderClienteTemporal;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnAtenderClienteAsociado;
        private System.Windows.Forms.Button btnCambiarPassword;
    }
}