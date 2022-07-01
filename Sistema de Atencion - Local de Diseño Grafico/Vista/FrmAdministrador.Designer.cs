
namespace Vista
{
    partial class FrmAdministrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdministrador));
            this.btnAtenderClienteTemporal = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnAtenderClienteAsociado = new System.Windows.Forms.Button();
            this.btnGestionClientes = new System.Windows.Forms.Button();
            this.btnGestionProductos = new System.Windows.Forms.Button();
            this.btnGestionUsuarios = new System.Windows.Forms.Button();
            this.btnCambiarPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAtenderClienteTemporal
            // 
            this.btnAtenderClienteTemporal.BackColor = System.Drawing.Color.Transparent;
            this.btnAtenderClienteTemporal.BackgroundImage = global::Vista.Properties.Resources.Boton2;
            this.btnAtenderClienteTemporal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAtenderClienteTemporal.FlatAppearance.BorderSize = 0;
            this.btnAtenderClienteTemporal.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAtenderClienteTemporal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAtenderClienteTemporal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAtenderClienteTemporal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtenderClienteTemporal.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAtenderClienteTemporal.ForeColor = System.Drawing.SystemColors.ControlText;
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
            this.btnCerrarSesion.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.Black;
            this.btnCerrarSesion.Location = new System.Drawing.Point(276, 299);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(201, 69);
            this.btnCerrarSesion.TabIndex = 6;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAtenderClienteAsociado
            // 
            this.btnAtenderClienteAsociado.BackColor = System.Drawing.Color.Transparent;
            this.btnAtenderClienteAsociado.BackgroundImage = global::Vista.Properties.Resources.Boton2;
            this.btnAtenderClienteAsociado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAtenderClienteAsociado.FlatAppearance.BorderSize = 0;
            this.btnAtenderClienteAsociado.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAtenderClienteAsociado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAtenderClienteAsociado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAtenderClienteAsociado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtenderClienteAsociado.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAtenderClienteAsociado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAtenderClienteAsociado.Location = new System.Drawing.Point(276, 12);
            this.btnAtenderClienteAsociado.Name = "btnAtenderClienteAsociado";
            this.btnAtenderClienteAsociado.Size = new System.Drawing.Size(201, 80);
            this.btnAtenderClienteAsociado.TabIndex = 1;
            this.btnAtenderClienteAsociado.Text = "Atender Cliente Asociado";
            this.btnAtenderClienteAsociado.UseVisualStyleBackColor = false;
            this.btnAtenderClienteAsociado.Click += new System.EventHandler(this.btnAtenderClienteAsociado_Click);
            // 
            // btnGestionClientes
            // 
            this.btnGestionClientes.BackColor = System.Drawing.Color.Transparent;
            this.btnGestionClientes.BackgroundImage = global::Vista.Properties.Resources.Boton2;
            this.btnGestionClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGestionClientes.FlatAppearance.BorderSize = 0;
            this.btnGestionClientes.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnGestionClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGestionClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGestionClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionClientes.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGestionClientes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGestionClientes.Location = new System.Drawing.Point(276, 117);
            this.btnGestionClientes.Name = "btnGestionClientes";
            this.btnGestionClientes.Size = new System.Drawing.Size(201, 69);
            this.btnGestionClientes.TabIndex = 3;
            this.btnGestionClientes.Text = "Gestion Clientes";
            this.btnGestionClientes.UseVisualStyleBackColor = false;
            this.btnGestionClientes.Click += new System.EventHandler(this.btnGestionClientes_Click);
            // 
            // btnGestionProductos
            // 
            this.btnGestionProductos.BackColor = System.Drawing.Color.Transparent;
            this.btnGestionProductos.BackgroundImage = global::Vista.Properties.Resources.Boton2;
            this.btnGestionProductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGestionProductos.FlatAppearance.BorderSize = 0;
            this.btnGestionProductos.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnGestionProductos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGestionProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGestionProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionProductos.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGestionProductos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGestionProductos.Location = new System.Drawing.Point(12, 213);
            this.btnGestionProductos.Name = "btnGestionProductos";
            this.btnGestionProductos.Size = new System.Drawing.Size(201, 69);
            this.btnGestionProductos.TabIndex = 4;
            this.btnGestionProductos.Text = "Gestion Productos";
            this.btnGestionProductos.UseVisualStyleBackColor = false;
            this.btnGestionProductos.Click += new System.EventHandler(this.btnGestionProductos_Click);
            // 
            // btnGestionUsuarios
            // 
            this.btnGestionUsuarios.BackColor = System.Drawing.Color.Transparent;
            this.btnGestionUsuarios.BackgroundImage = global::Vista.Properties.Resources.Boton2;
            this.btnGestionUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGestionUsuarios.FlatAppearance.BorderSize = 0;
            this.btnGestionUsuarios.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnGestionUsuarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGestionUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGestionUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionUsuarios.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGestionUsuarios.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGestionUsuarios.Location = new System.Drawing.Point(12, 117);
            this.btnGestionUsuarios.Name = "btnGestionUsuarios";
            this.btnGestionUsuarios.Size = new System.Drawing.Size(201, 69);
            this.btnGestionUsuarios.TabIndex = 2;
            this.btnGestionUsuarios.Text = "Gestion Usuarios";
            this.btnGestionUsuarios.UseVisualStyleBackColor = false;
            this.btnGestionUsuarios.Click += new System.EventHandler(this.btnGestionUsuarios_Click);
            // 
            // btnCambiarPassword
            // 
            this.btnCambiarPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnCambiarPassword.BackgroundImage = global::Vista.Properties.Resources.Boton2;
            this.btnCambiarPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCambiarPassword.FlatAppearance.BorderSize = 0;
            this.btnCambiarPassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCambiarPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCambiarPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarPassword.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCambiarPassword.Location = new System.Drawing.Point(276, 214);
            this.btnCambiarPassword.Name = "btnCambiarPassword";
            this.btnCambiarPassword.Size = new System.Drawing.Size(201, 69);
            this.btnCambiarPassword.TabIndex = 5;
            this.btnCambiarPassword.Text = "Cambiar contraseña";
            this.btnCambiarPassword.UseVisualStyleBackColor = false;
            this.btnCambiarPassword.Click += new System.EventHandler(this.btnCambiarPassword_Click);
            // 
            // FrmAdministrador
            // 
            this.AcceptButton = this.btnAtenderClienteAsociado;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vista.Properties.Resources.FondoApp;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCerrarSesion;
            this.ClientSize = new System.Drawing.Size(496, 379);
            this.Controls.Add(this.btnCambiarPassword);
            this.Controls.Add(this.btnAtenderClienteTemporal);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnAtenderClienteAsociado);
            this.Controls.Add(this.btnGestionClientes);
            this.Controls.Add(this.btnGestionProductos);
            this.Controls.Add(this.btnGestionUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdministrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAdministrador_FormClosing);
            this.Load += new System.EventHandler(this.FrmAdministrador_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAtenderClienteTemporal;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnAtenderClienteAsociado;
        private System.Windows.Forms.Button btnGestionClientes;
        private System.Windows.Forms.Button btnGestionProductos;
        private System.Windows.Forms.Button btnGestionUsuarios;
        private System.Windows.Forms.Button btnCambiarPassword;
    }
}